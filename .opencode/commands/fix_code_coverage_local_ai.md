# OpenCode Autonomous SonarCloud Coverage Orchestrator V2

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
summary.md
results/
state/current_task.md
```

Rules:

* Always resume existing state.
* Never process files already present in `processed.json`.
* Never lose progress between sessions.

## Coverage Extraction

Execute:

```bash
./docs/tools/get_info_sonarcloud.py \
  --limit 1 \
  --fetch-source \
  --no-clean \
  --processed-file ./.memory/system/processed.json \
  --output ./.memory/system/state/current_task.md
```

Priority order:

1. Lowest coverage
2. Highest uncovered lines
3. Highest complexity
4. Largest file

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

## Main Loop

Repeat:

1. Extract next coverage task.
2. Spawn worker agent.
3. Wait for completion.
4. Save result.
5. Update summary.
6. Mark processed.
7. Continue.

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
