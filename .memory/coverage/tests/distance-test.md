---
status: Done
---

## Test File

4_Operation/Physic/test/Collisions/DistanceTest.cs

## Test Class

Alis.Core.Physic.Test.Collisions.DistanceTest

## Tests

Total: 12 (8 existing + 4 new)

### New Tests

| Test | What it covers |
|------|---------------|
| ComputeDistance_WithSamePosition_ShouldReturnZero | shapes at (0,0): simplex.Count==3 immediate break, distance=0 |
| ComputeDistance_WithYAxisSeparation_ShouldReturnCorrectDistance | Y-axis offset: different GJK 2D orientation path |
| ComputeDistance_WithUseRadiiAndFarApart_ShouldSubtractRadii | far shapes + UseRadii: ApplyRadii subtract, multi-iteration GJK |
| ComputeDistance_WithTouchingShapes_ShouldReturnNearZeroDistance | shapes exactly touching with radii: ApplyRadii collapse, distance=0 |

## Framework

xUnit, net8.0
