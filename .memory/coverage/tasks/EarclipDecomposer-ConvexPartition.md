## COVERAGE TASK

### File
4_Operation/Physic/src/Common/Decomposition/EarclipDecomposer.cs

### Coverage
91.7% (18 uncovered lines)

### Method
ConvexPartition(Vertices, float tolerance)

### Existing Tests
EarclipDecomposerTest.cs — type accessibility, single triangle partition

### Gap
Only basic triangle tested. No square, pentagon, concave polygon, or tolerance variations.

### Approach
Add tests for ConvexPartition with:
- Square (4 vertices, convex)
- Pentagon/hexagon (5+ vertices, convex)
- Concave (L-shape)
- Negative tolerance edge (tolerance = -1)
