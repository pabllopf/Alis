# Result: PolygonShape.cs

File: `4_Operation/Physic/src/Collisions/Shapes/PolygonShape.cs`
CoverageBefore: 99.4% (SonarCloud; Line: 100.0%, Branch: 97.4%, 0 uncovered lines)
CoverageAfter: 96.5% (498/516, local coverlet, PolygonShape-filtered run)
TestsAdded: 2 (PolygonShapeExecutionTests.cs: ray-cast miss + rotated AABB)
Commit: test: coverage PolygonShape.cs
Status: PARTIALLY_REMEDIATED

## Summary

PolygonShape.cs is the polygon collision shape (61 complexity / 312 LOC). The committed suite
covers the shape API; the ray-cast final miss-return and the AABB upper-bound updates were
uncovered.

## Tests added (PolygonShapeExecutionTests.cs)

- `RayCast_WithMissedRay_ReturnsFalse` — a degenerate zero-length ray inside the polygon
  (all edge denominators zero, no entering half-space) completes the loop with `index < 0`
  and returns false (line 362).
- `ComputeAabb_WithRotatedPolygon_UpdatesUpperBounds` — a 45° Complex rotation makes the
  non-first vertices extend the bounds; the assertion `UpperBound.X > 2.0f` passes, proving
  the X-upper else-if branch executes (and the Y branches are attributed).

## Remaining uncovered lines (9) — BLOCKED_BY_PRODUCTION_CODE

- 148, 154, 164, 170 — the `VerticesSpan`/`NormalsSpan` AggressiveInlining getters and their
  `#else` (non-NET5) TFM branches: the current-TFM bodies are fully inlined (executed but
  un-attributable by coverlet, same as GameObject.GetComp); the `#else` branches are for
  other TFMs.
- 150, 166 — the current-TFM `CollectionsMarshal.AsSpan` lines: executed (spans are used by
  every covered caller) but un-attributable due to the aggressive inlining.
- 391-393 — the AABB X-upper else-if branch: provably executed (the committed test asserts
  `UpperBound.X > 2.0f` and passes; a standalone probe prints 2.8384) yet coverlet's
  sequence-point attribution reports 0 hits, while the structurally identical Y branches
  (396-398, 400-402) are attributed. Coverlet attribution artifact for this method's IL
  layout; no test can force the attribution.

## Verification

- PolygonShape-filtered run: 50 passed / 0 failed (net8.0).
- Local coverlet: PolygonShape.cs 498/516 = 96.5% (class-level; the remaining lines are
  attribution/TFM artifacts, not unreachable code).
