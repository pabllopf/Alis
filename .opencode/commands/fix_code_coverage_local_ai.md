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
summary.md
results/
state/current_task.md
```

Rules:

* Always resume existing state.
* Never process files already present in `processed.json`.
* Never lose progress between sessions.

## Initial Cache

First run (once per session):

```bash
./docs/tools/get_info_sonarcloud.py --cache --project-key pabllopf-official_alis --branch master
```

This downloads all SonarCloud data into `./.memory/system/cache/` and exits.

## Coverage Extraction Loop

After cache is populated, loop:

### Skip Logic

1. Read `./.memory/system/processed.json` to obtain the set of already-processed file keys.
2. Run `get_info_sonarcloud` with `--skip N` starting at `0`:
   ```bash
   ./docs/tools/get_info_sonarcloud.py \
     --limit 1 \
     --fetch-source \
     --no-clean \
     --cache-only \
     --skip 0 \
     --output ./.memory/system/state/current_task.md
   ```
3. Parse the output and extract the `### File` line.
4. Compare that file key against the set from `processed.json`:
   - If the file **is already in** `processed.json`, increment `--skip` by 1 and re-run (step 2).
   - If the file **is not** in `processed.json`, **add it to `processed.json` immediately** (append to array and save), then proceed with the task.
5. This ensures other concurrent sessions skip it from the moment it is picked up.
6. Repeat until an unprocessed file is found or `NO_REMAINING_COVERAGE_TASKS` is returned.

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

## Main Loop (Infinite)

Repeat until `NO_REMAINING_COVERAGE_TASKS`:

1. Populate cache if empty (`--cache`).
2. Extract next coverage task via Skip Logic above (file is added to `processed.json` immediately upon selection).
3. If `NO_REMAINING_COVERAGE_TASKS` → stop.
4. Spawn worker agent.
5. Wait for completion.
6. Save result.
7. Update summary.
8. Commit `processed.json` + results (file already in list from step 2).
9. Continue.

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
* AOT compatible — no dynamic code and no runtime reflection, tests must run under Native AOT without trimming or reflection fallbacks
* Arrange Act Assert
* observable behaviour only
* real implementations preferred
* Moq only for interfaces or external dependencies (and never to bypass internal visibility)
* InternalsVisibleTo already exists
* You can't generate cobertura files (like cobertura.xml, .trx files, etc) 

Forbidden (AOT compatibility):

* reflection — `System.Reflection`, `Type.GetMethod/GetProperty/GetField`, `MemberInfo`, `MethodInfo.Invoke`, `PropertyInfo.GetValue/SetValue`, `FieldInfo`
* runtime type discovery — `Assembly.GetTypes()`, `Type.GetType()`, `Assembly.Load`, `AppDomain.CurrentDomain`
* runtime instantiation — `Activator.CreateInstance(Type)`, unconstrained generic instantiation via reflection
* runtime code generation — `System.Reflection.Emit`, runtime IL emit, dynamic method generation, `Expression<T>.Compile()`, `dynamic` keyword
* dynamic proxies — `DispatchProxy`, runtime-generated mocks (hand-written fakes only)
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