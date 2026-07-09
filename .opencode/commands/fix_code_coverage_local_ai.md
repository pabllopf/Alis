# OpenCode Autonomous SonarCloud Coverage Orchestrator V4

Deterministic .NET coverage orchestrator optimized for minimal token usage.

## Goal

Process every uncovered SonarCloud file exactly once and resume automatically across sessions until no coverage tasks remain.

## Persistent State

Memory directory:

```text
./.memory/system/
```

Files:

```text
processed.json
sessions_state.json
summary.md
results/
state/current_task.md
```

Rules:

* Always resume existing state.
* Never process files already present in `processed.json`.
* Never lose progress between sessions.

## Session State

File:
```text
sessions_state.json
```

Format:
```json
{
  "sessions": {
    "1": { "file": "src/MyProject/SomeFile.cs", "status": "processing" },
    "2": { "file": "src/MyProject/OtherFile.cs", "status": "processing" }
  }
}
```

Each concurrent session gets a unique numeric ID via the first argument:
```text
/fix_code_coverage_local_ai 1
/fix_code_coverage_local_ai 2
```

The agent stores its ID as SESSION_ID ($1). A file may only be processed by one session at a time.

## Initial Cache

First run (once globally):

```bash
./docs/tools/get_info_sonarcloud.py --cache --project-key pabllopf-official_alis --branch master
```

This downloads all SonarCloud data into `./.memory/system/cache/` and exits.

## Coverage Extraction Loop

After cache is populated, extract the next unclaimed file.

### Candidate File Extraction

```bash
./docs/tools/get_info_sonarcloud.py \
  --limit 1 \
  --fetch-source \
  --no-clean \
  --cache-only \
  --skip {SKIP} \
  --processed-file ./.memory/system/processed.json \
  --output ./.memory/system/state/current_task.md
```

Priority order (built into the extractor):

1. Lowest coverage
2. Highest uncovered lines
3. Highest complexity
4. Largest file

### Session Coordination

Before using the extracted file:

1. Load `./.memory/system/sessions_state.json` (empty object `{}` if missing).
2. Build the set of file paths where `status` is `"processing"` across all sessions.
3. Read the candidate file path from `./.memory/system/state/current_task.md` (extract the line after `### File`).
4. If the candidate path is NOT in the processing set → proceed to Registration.
5. If it IS claimed → increment `SKIP` by 1, delete `current_task.md`, and re-run the extractor. Repeat until an unclaimed file is found.
6. If `NO_REMAINING_COVERAGE_TASKS` is reached → stop.

### Registration

Once an unclaimed file is found:

1. Load `sessions_state.json`.
2. Add entry:
   ```json
   "<SESSION_ID>": {
     "file": "<extracted file path>",
     "status": "processing",
     "started_at": "<current ISO timestamp>"
   }
   ```
3. Preserve all other sessions' entries.
4. Save `sessions_state.json`.

### Release

After the worker finishes:

1. Load `sessions_state.json`.
2. Remove `"<SESSION_ID>"` from the `sessions` object.
3. Save `sessions_state.json`.

Terminate immediately if:

```text
NO_REMAINING_COVERAGE_TASKS
```

## Agent Policy

Exactly one worker agent is allowed per coverage file.

Forbidden:

* explorer agents
* planner agents
* reviewer agents
* validator agents
* nested agents
* agent chains
* additional worker agents

The worker performs the entire lifecycle internally.

Execution model:

```text
Orchestrator
    -> Worker
        -> Analyze
        -> Implement
        -> Validate
        -> Commit
    <- Result
```

## OpenCode Tasks

Maintain only one active task.

Example:

```text
[x] Extract task
[x] Spawn worker
[x] Save result
[x] Update state
[x] Commit
```

Never create todo files.

Never commit task state.

## Main Loop (Infinite)

Repeat until `NO_REMAINING_COVERAGE_TASKS`:

1. Populate cache if empty (`--cache`). In multi-session mode, only one session needs to do this; others will pick up the existing cache.
2. Extract next unclaimed coverage task (see Coverage Extraction Loop → Session Coordination).
3. If `NO_REMAINING_COVERAGE_TASKS` → stop.
4. Register file in `sessions_state.json` under SESSION_ID (see Registration).
5. Spawn worker agent.
6. Wait for completion.
7. Release SESSION_ID from `sessions_state.json` (see Release).
8. Save result.
9. Update summary.
10. Mark processed.
11. Continue.

## Worker Context

The orchestrator only keeps:

* source file path
* coverage metadata
* worker output

The worker loads only:

* target source file
* owning production csproj
* associated test csproj
* existing tests in same namespace
* direct compile dependencies

Never load:

* repository root
* solution file
* unrelated projects
* unrelated tests
* full repository scans

## Worker Responsibilities

Process exactly one source file.

Steps:

1. Analyze uncovered code.
2. Generate missing tests.
3. Build affected test project.
4. Execute affected tests.
5. Generate result.
6. Create commit if successful.

## Testing Rules

Requirements:

* xUnit
* net8.0 tests
* compatible with netstandard2.0 production assemblies
* Arrange Act Assert
* observable behaviour only
* real implementations preferred
* Moq only for interfaces or external dependencies
* InternalsVisibleTo already exists
* You can't generate cobertura files (like cobertura.xml, .trx files, etc) 

Forbidden:

* reflection
* private method testing
* Thread.Sleep
* randomness
* network access
* filesystem side effects
* snapshot testing
* production changes

## Source Protection

Readable:

```text
src/**
```

Writable:

```text
test/**
```

Allowed:

* tests
* fixtures
* builders
* helpers
* mocks

Forbidden:

* edit src
* refactor src
* modify visibility
* modify constructors
* modify interfaces
* modify business logic
* modify InternalsVisibleTo

If production changes are required:

```text
Status: BLOCKED_BY_PRODUCTION_CODE
```

Store the result and continue with the next file.

## Build Rules

Allowed:

```bash
dotnet build <AffectedTestProject.csproj>
```

Forbidden:

```bash
dotnet build
dotnet build *.sln
```

## Test Execution

Preferred:

```bash
dotnet test <AffectedTestProject.csproj> \
  --filter FullyQualifiedName~<TargetClass>
```

Fallback:

```bash
dotnet test <AffectedTestProject.csproj>
```

Forbidden:

```bash
dotnet test
dotnet test *.sln
```

Ignore unrelated failures.

Generated tests must pass.

## Commit Rules

Commit only if:

* build succeeds
* generated tests pass

Include:

* generated tests
* processed.json
* summary.md
* results/*

Commit message:

```text
test: <FileName.cs>
```

One commit per processed file.

## Summary Format

Append to `summary.md`:

```text
Timestamp:
File:
CoverageBefore:
CoverageAfter:
TestsAdded:
Commit:
Status:
```

## Worker Output

Return only:

```text
File:
CoverageBefore:
CoverageAfter:
TestsAdded:
Commit:
Status:
```

No explanations.

No reasoning.

No commentary.