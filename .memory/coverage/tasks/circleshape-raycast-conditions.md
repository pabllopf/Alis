## COVERAGE TASK

### File
4_Operation/Physic/src/Collisions/Shapes/CircleShape.cs

### Coverage
96.0%

### Uncovered Lines
2

### Uncovered Conditions
2

### Methods
- `RayCast` — `rr < SettingEnv.Epsilon` branch (zero-length ray) and `0.0f <= a` false branch (ray pointing away from circle)

### Existing Tests
24 tests in CircleShapeTest.cs covering constructor, Position, ChildCount, TestPoint (inside/outside/center/edge), ComputeAabb, MassData, RayCast (hit/miss/inside/beyond max fraction), ComputeSubmergedArea (above/below/partial), CompareTo (equal/different), Clone, density/radius changes.

### Tests Added
1. `RayCast_WhenRayZeroLength_ReturnsFalse` — covers `rr < SettingEnv.Epsilon`
2. `RayCast_WhenRayPointsAwayFromCircle_ReturnsFalse` — covers `0.0f <= a` false

### Estimated Coverage Improvement
~2.0% (96.0% → ~98.0%)
