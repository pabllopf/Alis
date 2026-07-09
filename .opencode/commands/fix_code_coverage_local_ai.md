# OpenCode Coverage Orchestrator V5

Deterministic .NET coverage orchestrator. One file at a time, auto-resume, multi-session safe.

## Session ID

Pass via command: `/fix_code_coverage_local_ai => <ID>`
Resolution: `{{input}}` → `$OPencode_SESSION_ID` → `default`

```bash
SID="${input:-${OPencode_SESSION_ID:-default}}"
STATE=".memory/system"
```

| Path | Scope | Purpose |
|------|-------|---------|
| `$STATE/processed.json` | Shared | Completed files |
| `$STATE/sessions.json` | Shared | Claims registry (who processes what) |
| `$STATE/summary.md` | Shared | Running log |
| `$STATE/results/` | Shared | Per-file outputs |
| `$STATE/cache/` | Shared | SonarCloud cache |

## Session Registry (`sessions.json`)

Format:
```json
{
  "claims": {
    "relative/file/path.cs": { "sid": "1", "since": "2024-07-09T10:00:00", "status": "processing" }
  }
}
```

If `sessions.json` doesn't exist, create it as `{"claims":{}}`.

Stale claims (older than 30 min) are considered dead; ignore them.

## Initial Cache

```bash
./docs/tools/get_info_sonarcloud.py --cache \
  --project-key pabllopf-official_alis --branch master
```

Output: `$STATE/cache/`

## Extraction (Skip Claimed Files)

BEFORE any analysis or code generation, you must skip files already claimed by other sessions.

The script `--skip N` skips the first N files from the sorted list. Use it to jump past claimed files.

Step-by-step:

1. Read `sessions.json` → build list of claimed file paths with `status: "processing"` and claim age < 30 min
2. Set `SKIP=0`
3. Run extraction:
   ```bash
   ./docs/tools/get_info_sonarcloud.py \
     --limit 1 --fetch-source --no-clean --cache-only \
     --processed-file $STATE/processed.json \
     --skip $SKIP \
     --output $STATE/sessions/$SID/current_task.md
   ```
4. If output contains `NO_REMAINING_COVERAGE_TASKS` → stop
5. Parse `current_task.md` → get the `File:` value (relative path)
6. If the file path is in the claimed list → increment `SKIP` by 1, go to step 3
7. If the file is NOT claimed → write your claim to `sessions.json`: `claims["<file_path>"] = {"sid": "$SID", "since": "<ISO-timestamp>", "status": "processing"}`
8. Only then proceed to spawn worker

After worker completes:
9. Remove your claim from `sessions.json` (or set `status: "done"`)
10. Continue loop

Priority: lowest coverage → highest uncovered lines → highest complexity → largest file.

Critical: you must NEVER skip verifying `sessions.json` before extraction. Always check first.

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
2. Read `sessions.json`, build claimed file list
3. Run extraction with `--skip N`, increment N for each claimed file encountered
4. `NO_REMAINING_COVERAGE_TASKS` → stop
5. Write claim to `sessions.json`
6. Spawn worker agent
7. Wait for completion
8. Remove claim → save result → append to summary → mark processed → continue

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
git add test/** $STATE/processed.json $STATE/summary.md $STATE/results/*
git commit -m "test: <FileName.cs> [session $SID]"
```

## Summary Format

Append to `$STATE/summary.md`:
```
Timestamp: | Session: $SID | File: | CoverageBefore: | CoverageAfter: | TestsAdded: | Commit: | Status:
```

## Worker Output

Return only (no explanations/reasoning/commentary):
```
File: | CoverageBefore: | CoverageAfter: | TestsAdded: | Commit: | Status:
```
