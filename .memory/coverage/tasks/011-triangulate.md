# COVERAGE TASK

## File
`4_Operation/Physic/src/Common/Decomposition/Triangulate.cs`

## Coverage
55.1% | 29 uncovered lines | 0 uncovered conditions

## Methods to Cover
- `ConvexPartition(Vertices, TriangulationAlgorithm, bool, float, bool)` — switch branches
- `ValidatePolygon(Vertices)` — internal validation method

## Existing Tests
`test/Common/Decomposition/TriangulateTest.cs` — 2 tests (type access, Earclip algorithm)

## Approach
Pure algorithm with switch dispatch. Test each algorithm branch with simple convex polygon + exception case.
