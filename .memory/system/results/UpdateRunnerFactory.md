# Result: UpdateRunnerFactory.cs

File: `4_Operation/Ecs/src/Updating/Runners/UpdateRunnerFactory.cs`
CoverageBefore: 33.3% (SonarCloud)
CoverageAfter: 100.0% (local coverlet, all 9 generic classes line-rate=1)
TestsAdded: 27 (UpdateRunnerFactoryCoverageTests.cs)
Commit: test: coverage UpdateRunnerFactory.cs
Status: REMEDIATED

## Summary

This file declares 9 generic `UpdateRunnerFactory<TComp, ...>` classes (arity 0 through 8), each
implementing the internal `IComponentStorageBaseFactory` and `IComponentStorageBaseFactory<TComp>`
interfaces with three explicit-interface one-liner methods: `Create(capacity)` (returns
`ComponentStorageBase`), `CreateStack()` (returns `IdTable`), and
`CreateStronglyTyped(capacity)` (returns `ComponentStorage<TComp>`). Each constructs an
`Update`, `GameObjectUpdate`, or `EntityUpdate` (and an `IdTable`) for the given arity.

SonarCloud reported 33.3% because the explicit-interface methods had no executable coverage.

A new `UpdateRunnerFactoryCoverageTests.cs` class defines one `AllArityComp` struct implementing
all nine `IOnUpdate` arities (0 through 8) and drives every factory arity through both interfaces:
- Arity 0: `UpdateRunnerFactory<AllArityComp>`
- Arity 1: `UpdateRunnerFactory<AllArityComp, int>`
- ... through arity 8 (`... , int x8`).

Each factory is exercised on `Create`, `CreateStack`, and `CreateStronglyTyped` (27 tests), covering
every explicit-interface implementation line.

## Verification

- UpdateRunnerFactoryCoverageTests filter (net8.0, Debug): 27 passed, 0 failed, 0 skipped.
- Coverlet cobertura: all 9 `UpdateRunnerFactory` generic classes line-rate=1, branch-rate=1 (6 instrumented lines each).
