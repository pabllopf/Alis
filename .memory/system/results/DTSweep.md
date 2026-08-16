# Result: DTSweep.cs

File: `4_Operation/Physic/src/Common/Decomposition/CDT/Delaunay/Sweep/DTSweep.cs`
CoverageBefore: 62.4% (SonarCloud; Line 63.4%, Branch 59.2%); local coverlet baseline 82.2% line / 75.2% branch
CoverageAfter: 86.6% line / 79.6% branch (local coverlet, net8.0; 659 lines tracked)
TestsAdded: 9 (DTSweepRemainingCoverageTests.cs)
Commit: test: coverage DTSweep.cs
Status: PARTIALLY_REMEDIATED

## Summary

DTSweep.cs is the poly2tri-style constrained Delaunay sweep (141 complexity / 766 ncloc). The
committed suite (15 test files, 225 Sweep tests) already covered the main sweep, left-side edge
fills, legalization and the polygon finalization. Local coverlet pinpointed the remaining
uncovered regions; SonarCloud's stale delta (241 lines / 84 branches) is broader because it
reflects the pre-existing committed state.

## Work performed

Added 9 deterministic tests to `DTSweepRemainingCoverageTests.cs` (xUnit, net8.0, no
randomness, no reflection, observable behavior only):

Right-side below-edge fill chain (previously fully uncovered):
- `Triangulate_RightConstraintAboveDeepValley_ProducesTriangles` — constraint above a deep
  valley; triggers FillRightAboveEdgeEvent's Ccw branch, FillRightBelowEdgeEvent and
  FillRightConvexEdgeEvent entry (lines 314-318, 331-336, 353-366, 380-382).
- `Triangulate_RightConstraintAboveDeepPit_ProducesTriangles`
- `Triangulate_RightConstraintAboveWideValley_ProducesTriangles`
- `Triangulate_RightConstraintAboveFarValley_ProducesTriangles`
  (variants of the same family covering the whole fill chain body)

LargeHole_DontFill final `return true` (line 787):
- `Triangulate_DeepFlatValleyPointSet_ProducesTriangles` — deep valley + high plateau row
- `Triangulate_DeepSteppedValleyPointSet_ProducesTriangles`

Collinear constrained-edge handling:
- `Triangulate_ConstraintThroughInteriorPoints_ProducesTriangles` — constraint passing through
  two collinear interior points (Contains path)
- `Triangulate_ConstraintAlongCollinearRow_ProducesTriangles`
- `Triangulate_CrossingDiagonalsThroughPoint_ThrowsIntersectingConstraints` — documents the
  degenerate self-intersecting input behavior (InvalidOperationException)

## Remaining uncovered lines — BLOCKED_BY_PRODUCTION_CODE

- 110-124 — FinalizationConvexHull tail/head cleanup blocks: only reachable when the final
  sweep triangles contain both adjacent front points; deterministic search over 14k geometries
  could not produce the configuration.
- 319-321, 338-343 — FillRightConcaveEdgeEvent/FillRightConvexEdgeEvent recursion branches:
  require a 4-node surviving front chain; the recursion structurally terminates into
  `Orient2d(..., Tail.Next = null)` → NullReferenceException, i.e. reaching these lines forces a
  crash in the production code (latent bug, same family as poly2tri upstream).
- 527-528, 547-548 — EdgeEvent collinear `PointOnEdgeException` throws: the contained-vertex
  variant is covered; the throw variant requires a collinear vertex outside the current triangle
  which deterministic collinear configs did not produce.
- 777-778, 783-784 — LargeHole_DontFill early-return-false branches: require next2/prev2 front
  nodes with 0-90 degree angles; the sweep's fill rule consumes the required chain shapes.
- 858-970 — FillBasin/FillBasinReq/IsShallow deep recursion: needs a descent-then-ascent basin
  V whose ascending arm survives the advancing-front fill; the fill rule consumes ascending
  chains (14k-geometry search found none).

## Verification

- Targeted run: 234 passed / 0 failed (net8.0, `FullyQualifiedName~Sweep`).
- Local coverlet: DTSweep.cs 571/659 lines = 86.6% (was 82.2%); branches 79.6% (was 75.2%).
- Full Physic test project builds clean.
