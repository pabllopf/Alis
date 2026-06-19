---
status: Done
---

## Test File

4_Operation/Physic/test/Collisions/AabbTest.cs

## Test Class

Alis.Core.Physic.Test.Collisions.AABBTest

## Tests

Total: 35 (29 existing + 6 new)

### New Tests

| Test | What it covers |
|------|---------------|
| RayCast_WithDoInteriorCheckFalse_ShouldReturnTrue_WhenRayStartsInside | doInteriorCheck=false: ray inside AABB skips interior check |
| RayCast_WithDoInteriorCheckTrue_ShouldReturnFalse_WhenRayStartsInside | ray inside AABB with interior check: tmin < 0 → false |
| RayCast_ShouldReturnFalse_WhenMaxFractionLessThanTmin | MaxFraction shorter than intersection distance |
| RayCast_ShouldHandleNegativeDirection_WithSwap | ray from right-to-left: t1>t2 swap in ProcessAxis with positive normal |
| Contains_Point_ShouldReturnFalse_WhenOnLowerBound | point exactly on LowerBound (epsilon boundary) |
| Contains_Point_ShouldReturnFalse_WhenOnUpperBound | point exactly on UpperBound (epsilon boundary) |

## Framework

xUnit, net8.0
