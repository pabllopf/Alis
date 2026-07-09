# OpenCode Coverage Orchestrator V5

Deterministic .NET coverage orchestrator. One file at a time, auto-resume, multi-session safe.

## Session ID

Pass via command: `/fix_code_coverage_local_ai => <ID>`
Resolution: `{{input}}` → `$OPencode_SESSION_ID` → `default`

```bash
SID="${input:-${OPencode_SESSION_ID:-default}}"
SESSION_DIR=".memory/system/sessions/$SID"
```

| File | Purpose |
|------|---------|
| `processed.json` | Completed files |
| `summary.md` | Running log |
| `results/` | Per-file outputs |
| `state/current_task.md` | Current task payload |
| `cache/` | SonarCloud cache (shared) |
| `lock/` | Per-file lock dirs |

Rules:
- Resume from `processed.json` for this SID
- Skip files in `processed.json`
- Acquire `lock/<filehash>` before processing; skip if held
- Never lose progress

## Initial Cache

```bash
./docs/tools/get_info_sonarcloud.py --cache \
  --project-key pabllopf-official_alis --branch master
```

Output: `$SESSION_DIR/cache/`

## Extraction Loop

```bash
./docs/tools/get_info_sonarcloud.py \
  --limit 1 --fetch-source --no-clean --cache-only \
  --processed-file $SESSION_DIR/processed.json \
  --output $SESSION_DIR/state/current_task.md
```

Priority: lowest coverage → highest uncovered lines → highest complexity → largest file.

Terminate on: `NO_REMAINING_COVERAGE_TASKS`

## Agent Policy

Exactly 1 worker per file. Forbidden: explorer, planner, reviewer, validator, nested, chains, extra workers.

Worker owns full lifecycle internally:
```
Orchestrator → Worker → [Analyze → Implement → Validate → Commit] → Result
```

Maintain 1 active task. Never create todo files. Never commit task state.

## Main Loop

Repeat until `NO_REMAINING_COVERAGE_TASKS`:
1. Populate cache if empty (`--cache`)
2. Extract next task (`--cache-only`)
3. `NO_REMAINING_COVERAGE_TASKS` → stop
4. Spawn worker agent
5. Wait for completion
6. Save result → update summary → mark processed → continue

## Worker Context

Orchestrator passes: source path + coverage metadata + output path.

Worker loads only: target source, owning production csproj, test csproj, existing tests in namespace, direct compile deps.

Never load: repo root, .sln, unrelated projects/tests, full scans.

## Worker Responsibilities

1. Analyze uncovered code
2. Generate tests (xUnit, net8.0, netstandard2.0-compatible, AAA)
3. `dotnet build <TestProject.csproj>`
4. `dotnet test <TestProject.csproj> --filter FullyQualifiedName~<TargetClass>`
5. Return result; commit if build + tests pass

## Testing Rules

| Allow | Forbid |
|-------|--------|
| xUnit, net8.0 | Reflection |
| AAA pattern | Private method testing |
| Real impls preferred | `Thread.Sleep` |
| Moq only for interfaces/externals | Randomness |
| InternalsVisibleTo exists | Network / FS side effects |
| Observable behaviour only | Snapshot testing |
| | Production changes |

## Source Protection

| Readable | Writable | Forbidden |
|----------|----------|-----------|
| `src/**` | `test/**` | Edit src, refactor, modify visibility/ctors/interfaces/biz logic/InternalsVisibleTo |

If production change needed → `Status: BLOCKED_BY_PRODUCTION_CODE` → store result, continue.

## Build & Test

| Action | Command |
|--------|---------|
| Build | `dotnet build <TestProject.csproj>` |
| Test | `dotnet test <TestProject.csproj> --filter FullyQualifiedName~<TargetClass>` |
| Test (fallback) | `dotnet test <TestProject.csproj>` |
| Forbidden | `dotnet build` / `dotnet test` (no args) or `*.sln` |

Ignore unrelated failures. Generated tests must pass.

## Commit Rules

Only if build + generated tests pass. One commit per file.

```bash
git add test/** $SESSION_DIR/processed.json $SESSION_DIR/summary.md $SESSION_DIR/results/*
git commit -m "test: <FileName.cs>"
```

## Summary Format

Append to `$SESSION_DIR/summary.md`:
```
Timestamp: | File: | CoverageBefore: | CoverageAfter: | TestsAdded: | Commit: | Status:
```

## Worker Output

Return only (no explanations/reasoning/commentary):
```
File: | CoverageBefore: | CoverageAfter: | TestsAdded: | Commit: | Status:
```
