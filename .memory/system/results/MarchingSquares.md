# Result: MarchingSquares.cs

File: `4_Operation/Physic/src/Common/TextureTools/MarchingSquares.cs`
CoverageBefore: 79.9% (SonarCloud); local coverlet baseline 74.4% line / 70.6% branch
CoverageAfter: 75.3% (259/344 unique instrumentable lines) line / ~70% branch (local coverlet, net8.0 — unchanged)
TestsAdded: 0 (13 candidate strip-geometry tests verified to add zero coverage; not committed)
Commit: test: coverage MarchingSquares.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

MarchingSquares.cs (1080 LOC, marching-squares contour extraction with scan-line polygon
combination). The committed suite already covers the core cell processing (MarchSquare,
ProcessKey, Lerp/Xlerp/Ylerp, CombLeft, InsertPolyIntoPoly, RemoveParallelVerticesAfterInsertion
partially). The remaining 88 uncovered lines split into two blocks, both unreachable without a
production change:

1. CombineScanLines family (lines 299-463, 85 lines: CombineScanLines body, CanCombine,
   FindStartingPoint, HasValidStart, HasMatchingVertex, MergePolygons,
   UpdatePolygonReferences) — DEAD CODE. `ProcessCell` always writes `ctx.Ps[x, 0]`
   (MarchingSquares.cs:276), so after `ProcessGridCells` only row 0 of `ps` is populated while
   `CombineScanLines` reads rows `y` and `y-1` for `y >= 1` — every access is null, so
   `CanCombine` always returns false and the merge body is unreachable through
   `DetectSquares(combine: true)`. Verified empirically with 13 diverse deterministic
   fields (horizontal/vertical/diagonal strips, thin row/column, checkerboard, box, comb,
   coarse cells): all pass but cover zero of these lines.

2. RemoveParallelVerticesAfterInsertion wrap-around (lines 734-736) — requires the CombLeft
   match point to be the last element of the accumulated polygon; not producible with any of
   the 13 candidate fields or the existing 36-test suite.

## Verification

- Targeted run: 49 passed / 0 failed (net8.0, MarchingSquares filter — 36 existing + 13
  candidate tests, all green).
- Local coverlet: MarchingSquares.cs 74.4% line / 70.6% branch, 88 uncovered lines,
  unchanged by the candidates.
- Fixing the remaining lines requires a production change (`ps` must be indexed by the scan
  row in `ProcessCell`); the 13 candidate tests were removed to keep the repo coverage-honest.

## Re-verification (2026-09-07)

- Re-ran the MarchingSquares filter with XPlat Code Coverage (net8.0): 39 existing tests
  passed / 0 failed; MarchingSquares class 344 unique instrumentable lines, 259 covered
  (75.3%), 85 missed.
- All 85 missed lines are exclusively in lines 299-463 (CombineScanLines family + CanCombine,
  FindStartingPoint, HasValidStart, HasMatchingVertex, MergePolygons, UpdatePolygonReferences).
- Confirmed with additional probe fields (solid square, dumbbell, overlapping rectangles,
  slope, annulus): `CanCombine` never returns true because `ProcessCell` hardcodes the write
  target as `ctx.Ps[x, 0]`; `CombineScanLines` then reads `ps[x, y]`/`ps[x, y-1]` for `y >= 1`
  which are all null. The merge body is DEAD CODE.
- No new tests added (all candidate fields cover zero of the 85 lines). Status unchanged:
  BLOCKED_BY_PRODUCTION_CODE.
