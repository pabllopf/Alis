## COVERAGE TEST

### File
4_Operation/Physic/src/Collisions/Shapes/CircleShape.cs

### Tests Added
1. `RayCast_WhenRayZeroLength_ReturnsFalse`
2. `RayCast_WhenRayPointsAwayFromCircle_ReturnsFalse`

### Location
4_Operation/Physic/test/Collisions/Shapes/CircleShapeTest.cs

### Behavior Verified
1. Zero-length ray (Point1 == Point2) returns false via `rr < SettingEnv.Epsilon`
2. Ray starting beyond circle pointing away returns false via `0.0f <= a` being false

### Patterns
```csharp
// Zero-length ray
RayCastInput input = new RayCastInput
{
    Point1 = new Vector2F(0.0f, 0.0f),
    Point2 = new Vector2F(0.0f, 0.0f),
    MaxFraction = 1.0f
};
bool hit = circle.RayCast(out _, ref input, ref transform, 0);
Assert.False(hit);

// Ray pointing away
RayCastInput input = new RayCastInput
{
    Point1 = new Vector2F(10.0f, 0.0f),
    Point2 = new Vector2F(20.0f, 0.0f),
    MaxFraction = 1.0f
};
bool hit = circle.RayCast(out _, ref input, ref transform, 0);
Assert.False(hit);
```

### Estimated Coverage Improvement
~2.0% (96.0% → ~98.0%)
