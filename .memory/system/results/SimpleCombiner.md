# Result: SimpleCombiner.cs

File: `4_Operation/Physic/src/Common/PolygonManipulation/SimpleCombiner.cs`
CoverageBefore: 96.6% (SonarCloud; Line: 96.8%, Branch: 96.2%, 6 uncovered lines)
CoverageAfter: 96.8% (360/372, local coverlet, SimpleCombiner-filtered run; unchanged)
TestsAdded: 0 (remaining lines reachable only through internal merge-collapse flows)
Commit: test: coverage SimpleCombiner.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

SimpleCombiner.cs is the triangle-to-polygon combiner (54 complexity / 223 LOC). The
committed suite (SimpleCombinerTests + polygon suites, 19 filtered tests) covers
PolygonizeTriangles, MarkDegenerateTriangles, merge flows and polygon building.

## Remaining uncovered lines (6) — BLOCKED_BY_PRODUCTION_CODE

- 97-99 — the corrupt-polygon skip (`poly.Count < 3`): the poly reaches that branch only when
  it collapses below 3 vertices during internal triangle merging, not from raw input — direct
  2-vertex inputs crash `MarkDegenerateTriangles` first (verified: IndexOutOfRange).
- 274-276 — `RemoveEmptyPolygons`: an empty polygon can only arise from the internal merge
  flow; an empty input polygon crashes `MarkDegenerateTriangles` before removal runs.

Both paths are internal-flow edge cases not constructible from public inputs; the committed
and probed fixtures (including degenerate 2-vertex and empty polygons) crash in
`MarkDegenerateTriangles` rather than reaching them.

## Verification

- SimpleCombiner-filtered run: 19 passed / 0 failed (net8.0).
- Local coverlet: SimpleCombiner.cs 360/372 = 96.8% (matches SonarCloud line metric).
