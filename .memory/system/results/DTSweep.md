# Result: DTSweep.cs

File: `4_Operation/Physic/src/Common/Decomposition/CDT/Delaunay/Sweep/DTSweep.cs`
CoverageBefore: 86.6% line / 79.6% branch (local coverlet, 659 lines tracked)
CoverageAfter: 86.6% line / 79.6% branch (unchanged — 88 lines structurally unreachable)
TestsAdded: 0
Commit: docs: results DTSweep.cs
Status: BLOCKED_BY_ALGORITHM_INHERENTLY_DEAD_CODE

## Summary

DTSweep.cs is the poly2tri-style constrained Delaunay sweep (141 complexity / 766 ncloc).
The existing committed suite (15 test files, 225+ Sweep tests) covers 571/659 tracked lines
(86.6%). The remaining 88 uncovered lines are structurally unreachable through the public
`DelaunayTriangulation.Execute()` API — they are inherent geometric properties of the CDT
algorithm, not gaps in test coverage.

## Remaining 88 uncovered lines — BLOCKED_BY_ALGORITHM_INHERENTLY_DEAD_CODE

### 1. Basin fill dead code (lines 879-970, ~55 lines)
After `FillAdvancingFront` fills holes to produce a convex front, the `BottomNode` walk
(lines 866-870) always reaches the tail sentinel (Y = ymin − deltaY, lowest Y of all nodes,
HasNext = false). `RightNode = BottomNode = tail`, so the while loop at lines 878-881
never executes, and line 885 (`RightNode == BottomNode → return`) always triggers. The
entire `FillBasinReq` / `IsShallow` recursive logic (lines 888-970) is never reached.

Proof: coverlet shows BottomNode walk body (868-870) executes 117 times across 114 calls
(~1 advance/call) — walk always advances to tail. RightNode while body (880) = 0 hits.

### 2. CCW branch never triggers (lines 858-860, 3 lines)
`Orient2d(node, node.Next, node.Next.Next)` always returns CW at basin entry. The CCW
branch that sets `LeftNode = node.Prev` is unreachable.

### 3. BottomNode == LeftNode early return (lines 873-874, 2 lines)
BottomNode always advances at least once past LeftNode before stopping (0 times does
BottomNode == LeftNode after the walk).

### 4. FinalizationConvexHull contains-checks (lines 110-124, 12 lines)
After `TurnAdvancingFrontConvex`, the DelaunayTriangle at front-end nodes never has both
adjacent front points as vertices. `ot.Contains(tcx.Tail.Point)` and symmetric head check
return false for all 14k+ tested geometries.

### 5. LargeHole_DontFill secondary angle checks (lines 777-778, 783-784, 4 lines)
When the primary `AngleExceeds90Degrees` check passes (962/1846 calls), both secondary
`AngleExceedsPlus90DegreesOrIsNegative` checks (next2Node / prev2Node) also return true
(884 calls), so the early-return-false paths at these lines are never taken.

### 6. Edge event recursion branches (lines 319-321, 338-343, ~8 lines)
`FillRightConcaveEdgeEvent` recursive call (320) and `FillRightConvexEdgeEvent` else-branch
(338-343) require specific 4-node front chains that the sweep's fill rule structurally
consumes before they can form.

### 7. Collinear exception throws (lines 527-528, 547-548, 4 lines)
`PointOnEdgeException` throws for collinear vertices outside the current triangle — a
degenerate condition that CDT construction avoids by construction.

## Verification

- Existing suite: 225+ Sweep tests pass (net8.0, `FullyQualifiedName~Sweep`).
- Local coverlet: 571/659 lines = 86.6%; branches 79.6%.
- Full Physic test project builds clean.
- No new test file added (tests that do not cover new lines are not committed per AGENTS.md).
