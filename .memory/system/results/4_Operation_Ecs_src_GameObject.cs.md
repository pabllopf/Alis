# GameObject.cs Coverage Remediation Result

## File
4_Operation/Ecs/src/GameObject.cs

## Coverage (SonarCloud, master)
- Before: 47.3% line, 498 uncovered lines (complexity 207)

## Local coverlet verification (net8.0, XPlat)
- Before: 48.8% (950/1946 instrumented lines)
- After: 91.3% (1776/1946 instrumented lines, +826 lines)
- 3149 tests pass (0 failed), of which 28 are new.

## What was uncovered
The multi-arity `Add<T1..Tn>` / `Remove<T1..Tn>` bodies for arities 2 through 8
(source ranges roughly 461-538, 585-668, 719-808, 867-961, 1027-1127, 1199-1305,
1383-1496). The `InvokeComponentWorldEvents<T1..Tn>` and `InvokePerEntityEvents<T1..Tn>`
helpers were already covered by the existing generic-event arity tests.

## New tests
- File: 4_Operation/Ecs/test/GameObjectMultiArityAddRemoveTests.cs
- 28 tests: for each arity 2..8 a store/verify add test, a remove test, and both
  deferred paths (EnterDisallowState / ExitDisallowState) for add and remove.
- Components used: Position, Velocity, Health, Armor, Damage, TestComponent,
  TestComponent2, Models.Transform.
- Pure managed, no native dependency, runs on CI.

## Status
COMPLETED