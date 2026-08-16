# Result: YuPengClipper.cs

File: `4_Operation/Physic/src/Common/PolygonManipulation/YuPengClipper.cs`
CoverageBefore: 91.1% (SonarCloud; Line: 91.1%, Branch: 91.1%, 27 uncovered lines)
CoverageAfter: 97.5% (548/562, local coverlet, YuPengClipper-filtered run)
TestsAdded: 5 (YuPengClipperExecutionTests.cs: multi-intersection insertion + degenerate geometries)
Commit: test: coverage YuPengClipper.cs
Status: PARTIALLY_REMEDIATED

## Summary

YuPengClipper.cs is the polyboolean polygon clipper (87 complexity / 363 LOC). The committed
suite covers the main Union/Difference/Intersect flows. Uncovered: the multi-intersection
insertion loop of `InsertIntersectionPoint`, the degenerated-output path and the
broken/undefined error paths of the chain builder.

## Tests added (YuPengClipperExecutionTests.cs)

- `Union_WithReversedZigzagClip_AdvancesInsertionIndex` — a zigzag clip whose crossings along
  the subject's top edge (processed as (8,8)→(0,8)) occur in decreasing-x order, so each
  insertion must advance past the previously inserted intersection vertices (covers the
  `GetAlpha(...) <= alpha` while-loop continuation).
- `Union_WithTinyPolygon_ReturnsResult` — a sub-pixel triangle clip producing an output with
  fewer than three vertices (covers the DegeneratedOutput path).
- `Union_WithCollinearSharedEdge_ReturnsResult` / `Union_WithCollinearHeavyPolygon_ReturnsResult`
  / `Intersect_WithEdgeTouchingPolygons_ReturnsResult` — collinear and touching-edge geometries
  exercising the chain building and collinear-simplification paths.

## Remaining uncovered lines (7) — BLOCKED_BY_PRODUCTION_CODE

- 390-392 — the `BrokenResult` path (`BuildSinglePolygon` error → empty result): requires the
  simplified chain to be disconnected, which only occurs for degenerate collinear/
  self-intersecting inputs the algorithm documents as unsupported ("May yield incorrect
  results or even crash if polygons contain collinear points").
- 436-439 — the `Undefined error while building result polygon(s)` path: the chain-builder's
  no-progress pass, same disconnected-chain family. Not deterministically constructible with
  the standard fixtures (12 probe geometries tested, including boundary-shared edges,
  bowties, islands and collinear overlaps — none triggered it).

## Verification

- YuPengClipper-filtered run: 43 passed / 0 failed (net8.0).
- Local coverlet: YuPengClipper.cs 548/562 = 97.5% (before: 91.1% line); Edge 44/44.
