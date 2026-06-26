## COVERAGE TASK

### File

EdgeShape.cs

### Path

`4_Operation/Physic/src/Collisions/Shapes/EdgeShape.cs`

### Coverage

53.5%

### Uncovered Methods

- RayCast (multiple branches: parallel, out-of-range, outside segment)
- ComputeAabb (min/max sorting branches)
- ComputeProperties (centroid calculation)
- ComputeSubmergedArea
- CompareTo
- Clone

### Existing Tests

EdgeShapeTest.cs — covers constructors, properties, TestPoint, Set, HasVertex flags, edge orientations

### Strategy

Add tests for all uncovered public/internal methods with identity transforms for simplicity.
