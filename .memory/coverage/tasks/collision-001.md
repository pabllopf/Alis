## COVERAGE TASK

### File
`4_Operation/Physic/src/Collisions/Collision.cs`

### Coverage
70.4%

### Uncovered Lines
201

### Uncovered Conditions
111

### Existing Tests
- CollisionTest.cs (21 tests)

### New Tests
- CollisionCoverageTest.cs (17 tests)

### Key Paths Covered
- CollidePolygonAndCircle barycentric early returns (u1, u2, face center)
- CollideEdgeAndCircle Region B early return
- CollideEdgeAndCircle Region AB early return and normal flip
- CollidePolygons clip early return (np < 2)
- CollideEdgeAndPolygon with HasVertex0/HasVertex3 combinations
- CollideEdgeAndPolygon back face collision
- CollideEdgeAndPolygon polygon axis primary path
- CollideEdgeAndPolygon edge axis unknown/edge separation exceeded
- TestOverlap with EdgeShape
- GetPointStates empty old manifold
