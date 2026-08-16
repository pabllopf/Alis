# Result: EarclipDecomposer.cs

File: `4_Operation/Physic/src/Common/Decomposition/EarclipDecomposer.cs`
CoverageBefore: 94.6% (SonarCloud; Line: 95.9%, Branch: 91.3%, 11 uncovered lines)
CoverageAfter: 99.1% (438/442, local coverlet, EarclipDecomposer-filtered run)
TestsAdded: 0 (existing suite covers every reachable line)
Commit: test: coverage EarclipDecomposer.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

EarclipDecomposer.cs is the ear-clipping polygon decomposer (66 complexity / 312 LOC). The
committed suite (EarclipDecomposerTests + decomposition suites, 18 filtered tests) covers
decompose, triangulate, pinch-point resolution, the Triangle type and the ear-clip loops.

## Remaining uncovered lines (2) — BLOCKED_BY_PRODUCTION_CODE

- 320-321 — `SplitPolygonAtPinchPoint`'s wraparound-duplicate early return
  (`if (sizeA == pin.Count)`). `sizeA = pinchIndexB - pinchIndexA` with
  `0 <= pinchIndexA < pinchIndexB < pin.Count`, so `sizeA <= pin.Count - 1` and the
  comparison can never be true. Dead defensive branch.

## Verification

- EarclipDecomposer-filtered run: 18 passed / 0 failed (net8.0).
- Local coverlet: EarclipDecomposer.cs 438/442 = 99.1%; Triangle 94/94.
