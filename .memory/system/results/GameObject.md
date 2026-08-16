# Result: GameObject.cs

File: `4_Operation/Ecs/src/GameObject.cs`
CoverageBefore: 96.9% (SonarCloud; Line: 99.9%, Branch: 84.7%, 1 uncovered line)
CoverageAfter: 99.9% (1944/1946, local coverlet, GameObject-filtered run)
TestsAdded: 7 (GameObjectGenericEventArityTests.cs: direct multi-arity generic-event invocations)
Commit: test: coverage GameObject.cs
Status: PARTIALLY_REMEDIATED

## Summary

GameObject.cs is the ECS entity facade (207 complexity / 1153 LOC). The committed suite covers
the Add/Remove/Get component flows; the multi-arity `InvokePerEntityEvents<T1..T8>` public
statics were never called by any production path — every `Add<T1..T8>` method invokes only the
arity-1 overload — so their GenericEvent invocation blocks were unreachable through the normal
API.

## Tests added (GameObjectGenericEventArityTests.cs)

Direct calls to the public statics `GameObject.InvokePerEntityEvents<T1..T8>` with
`hasGenericEvent=true`, a prepared `ComponentEvent` (internal `GenericEvent` field set via
InternalsVisibleTo, with a no-op `IGenericAction<GameObject>` registered) and 2..8 component
refs — covering the arity-2..8 GenericEvent invocation blocks (576-577, 710-712, 856-859,
1015-1019, 1186-1191, 1369-1375, 1566-1573).

## Remaining uncovered line (1) — BLOCKED_BY_PRODUCTION_CODE

- 188 — the closing brace of `if (lookup.Version != EntityVersion) { Throw_EntityIsDead(); }`
  in the internal alive-check: the guard method always throws, so the if-body never completes
  and the brace is unreachable.

## Verification

- GameObject-filtered run: 727 passed / 0 failed (net8.0).
- Local coverlet: GameObject.cs 1944/1946 = 99.9% (before: 96.9% overall / arity blocks 0%).
