# Coverage Task: BayazitDecomposer

## File
4_Operation/Physic/src/Common/Decomposition/BayazitDecomposer.cs

## Coverage
- **Current**: 11.1%
- **Line Coverage**: 11.6%
- **Branch Coverage**: 9.7%
- **Uncovered Lines**: 152

## Target Methods
- `TriangulatePolygon` - recursive decomposition (lines 61-107)
- `TryFindSplit` - split line finding (lines 112-128)
- `FindLowerIntersection` / `FindUpperIntersection` (lines 133-172)
- `FindBestSplitIndex` (lines 177-201)
- `CalculateVertexScore` (lines 206-227)
- `Copy` (lines 248-263)
- `CanSee`, `CanVertexSee`, `LineIntersectsAnyEdge` (lines 272-317)

## Existing Tests
- `BayazitDecomposerTest.ConvexPartition_WithTriangle_ShouldReturnSinglePart` - only tests convex 3-vertex polygon

## Source Code
See: `4_Operation/Physic/src/Common/Decomposition/BayazitDecomposer.cs` (384 lines)

## Dependencies
- `SettingEnv.MaxPolygonVertices = 8`
- `Vertices` (extends `List<Vector2F>`)
- `Vector2F`
- `LineTools.LineIntersect`
- `MathUtils.Area`

## Status
- **COMMITTED**: 568fbeb92
- **Tests Added**: 14 new tests (covering helper methods: Reflex, Left, Right, LeftOn, RightOn, SquareDist, CanSee, At, Copy)
- **Note**: Concave polygon decomposition paths (TriangulatePolygon recursion, TryFindSplit, intersection finding) cause infinite recursion with certain geometries due to algorithm limitations. Helper method tests cover ~50 lines. Remaining ~100 lines require algorithmic fixes before they can be tested.
