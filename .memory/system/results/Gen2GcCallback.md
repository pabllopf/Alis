# Result: Gen2GcCallback.cs

File: `4_Operation/Ecs/src/Redifinition/Gen2GcCallback.cs`
CoverageBefore: 43.8% (SonarCloud stale; local coverlet 78/150 = 52.0%)
CoverageAfter: 52.0% (78/150 lines, local coverlet; unchanged)
TestsAdded: 0 (finalizer and static-ctor callback unreachable; production design)
Commit: test: coverage Gen2GcCallback.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Gen2GcCallback.cs is the Gen-2 GC finalizer callback helper (15 complexity / 104 LOC per
SonarCloud). The committed suite (`Gen2GcCallbackDirectTest.cs` /
`Gen2GcCallbackRemainingCoverageTests.cs`) covers 78/150 lines locally (52.0%); targeted run:
18 passed / 0 failed on `Alis.Core.Ecs.Test` (net8.0).

Covered: both Register overloads, the Gen2CollectionOccured accessor (getter/setter under lock),
all null/false/true registration paths, and the internal callback fields.

## Remaining uncovered lines (72) — BLOCKED_BY_PRODUCTION_CODE

- 105-112 — the static constructor's registered lambda body (Gen2CollectionOccured snapshot
  under lock + invoke).
- 165-201 — the entire `~Gen2GcCallback()` finalizer: list removal, weak-handle allocation
  check, dead-target free/return, `_callback1`/`_callback0` invocation branches, and
  `GC.ReRegisterForFinalize`.

The finalizer can never run in a test:

1. The only creation paths are the two `Register` overloads, both of which add the instance to
   the static `_registeredCallbacks` list (lines 139-143, 154-158) that is never cleared.
2. A reachable-from-the-static-list object is never collectable, so `~Gen2GcCallback` never
   executes regardless of `GC.Collect`/`GC.WaitForPendingFinalizers` pressure — the committed
   `Finalizer_*` tests pass trivially as no-ops.
3. Both constructors are `private`, so no test can create an instance outside the list; the
   static constructor's registered callback only fires from within the same unreachable
   finalizer.

Requires a production change (e.g., an internal test-only removal API or an
`InternalsVisibleTo`-visible unregister path) to cover; out of scope for coverage work.

## Verification

- Targeted run: 18 passed / 0 failed (net8.0).
- Local coverlet: Gen2GcCallback.cs 78/150 lines (52.0%).
