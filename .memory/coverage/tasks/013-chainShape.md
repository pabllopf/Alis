## COVERAGE TASK

### File

ChainShape.cs

### Path

`4_Operation/Physic/src/Collisions/Shapes/ChainShape.cs`

### Coverage

Unknown (no SonarCloud sync)

### Uncovered Methods

- GetChildEdge (branch coverage: first index, last index, middle index)
- RayCast (delegates to EdgeShape)
- ComputeAabb (transform application)
- ComputeSubmergedArea (returns zero)
- CompareTo (vertex comparison)
- Clone (deep copy)

### Existing Tests

ChainShapeTest.cs — covers constructors, ChildCount, PrevVertex/NextVertex properties, basic GetChildEdge

### Strategy

Add tests for all uncovered public/internal methods with identity transforms for simplicity.
13 tests expected.
