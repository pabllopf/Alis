# Result: GameObject.cs

File: `4_Operation/Ecs/src/GameObject.cs`
CoverageBefore: 96.9% (SonarCloud; Line: 99.9%, Branch: 84.7%, 1 uncovered line)
CoverageAfter: 99.9% (1944/1946, local coverlet, GameObject-filtered run)
TestsAdded: 10 (7 GameObjectGenericEventArityTests.cs + 3 GameObjectLatestCoverageTests.cs)
Commit: test: coverage GameObject.cs (1b12284d9, 4af5157af)
Status: PARTIALLY_REMEDIATED

## Summary

GameObject.cs is the ECS entity facade (207 complexity / 1153 LOC). Session 1 (1b12284d9) added
GameObjectGenericEventArityTests.cs covering the multi-arity `InvokePerEntityEvents<T1..T8>`
public statics (arity-2..8 GenericEvent blocks 576-577, 710-712, 856-859, 1015-1019, 1186-1191,
1369-1375, 1566-1573) via direct invocation with `hasGenericEvent=true`. Session 2 (4af5157af)
added GameObjectLatestCoverageTests.cs covering the dead-entity `AssertIsAlive` throw path
(line 187) through the public API: `Get<T>`, `Add`, and `ComponentTypes` on a deleted entity
all throw `InvalidOperationException` with `EntityIsDeadMessage`.

## Remaining uncovered line (1) — BLOCKED_BY_PRODUCTION_CODE

- 188 — the closing brace of `if (lookup.Version != EntityVersion) { Throw_EntityIsDead(); }`
  in the internal alive-check: the guard method always throws, so the if-body never completes
  and the brace is unreachable without editing src/ (forbidden).

## Verification

- Build: dotnet build net8.0 — 0 errors.
- GameObject-filtered run: 727 passed / 0 failed (net8.0).
- Local coverlet: GameObject.cs 1944/1946 = 99.9% (before: 96.9% overall / arity blocks 0%).
