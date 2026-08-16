# Result: FastestStack.cs

File: `4_Operation/Ecs/src/Collections/FastestStack.cs`
CoverageBefore: 96.7% (SonarCloud; Line: 97.4%, Branch: 94.4%, 7 uncovered lines)
CoverageAfter: 97.4% (528/542, local coverlet, FastestStack-filtered run; unchanged)
TestsAdded: 0 (remaining lines are dead version guards + allocation-limit clamp)
Commit: test: coverage FastestStack.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

FastestStack.cs is the struct-based fast stack (87 complexity / 361 LOC). The committed suite
(142 filtered tests) covers push/pop/peek/grow/clear/enumeration and the ICollection members.

## Remaining uncovered lines (8) — BLOCKED_BY_PRODUCTION_CODE

- 576-577, 646-647 — the enumerator's `InvalidOperation_EnumFailedVersion` guards in MoveNext
  and `IEnumerator.Reset`. `FastestStack<T>` is a struct and `GetEnumerator()` captures it by
  value (`new Enumerator(this)`), so the enumerator's `_version` (readonly, captured at
  construction) can never differ from its private `_fastestStack` copy's `_version` — the
  guards are dead by design. Verified: mutating the stack through a local after obtaining the
  enumerator never triggers the throw in either the testhost or a standalone probe.
- 465-467 — `Grow`'s `MaxArrayLength` clamp: only fires when the doubling growth exceeds the
  array-length limit (requires a pre-existing array of ~1 billion elements), unreachable in
  any process.

## Verification

- FastestStack-filtered run: 142 passed / 0 failed (net8.0).
- Local coverlet: FastestStack.cs 528/542 = 97.4% (Enumerator 94/102, the 8 lines above).
