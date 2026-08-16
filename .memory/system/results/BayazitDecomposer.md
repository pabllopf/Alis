# Result: BayazitDecomposer.cs

File: `4_Operation/Physic/src/Common/Decomposition/BayazitDecomposer.cs`
CoverageBefore: 95.1% (SonarCloud; Line: 94.2%, Branch: 97.2%, 10 uncovered lines)
CoverageAfter: 94.2% (324/344, local coverlet, Bayazit-filtered run; unchanged)
TestsAdded: 0 (remaining lines are specific geometric edge cases not reachable with standard fixtures)
Commit: test: coverage BayazitDecomposer.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

BayazitDecomposer.cs is the Bayazit convex decomposition (55 complexity / 205 LOC). The
committed suite (BayazitDecomposerTest/CoverageTest/CoverageTests/RemainingCoverageTests,
45 filtered tests) covers triangulate, reflex detection, split finding, scoring and the
recursive decomposition.

## Remaining uncovered lines (10) — BLOCKED_BY_PRODUCTION_CODE

- 71-78 — the adjacent-split branch (`lowerIndex == (upperIndex + 1) % Count`) of
  `TriangulatePolygon`: requires the reflex vertex's lower and upper split-target intersection
  indices to be consecutive — a specific notch geometry not reached by triangles,
  rectangles, concave polygons, stars or the probed notch/step shapes.
- 213-215 — the aligned-candidate score branch of `CalculateVertexScore`: requires a reflex
  candidate whose adjacent edge lines both pass through another reflex vertex (strict
  collinearity). Not deterministically constructible with the tested fixtures.

## Verification

- Bayazit-filtered run: 45 passed / 0 failed (net8.0).
- Local coverlet: BayazitDecomposer.cs 324/344 = 94.2% (matches SonarCloud line metric).
