## Pattern: AABB RayCast Edge Cases

### When to Use

When AABB.RayCast has uncovered branch coverage (doInteriorCheck, tmin < 0, MaxFraction < tmin, negative direction swap).

### Test Template

```csharp
[Fact]
public void RayCast_WithDoInteriorCheckFalse_ShouldReturnTrue_WhenRayStartsInside()
{
    Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(10.0f, 10.0f));
    RayCastInput input = new RayCastInput
    {
        Point1 = new Vector2F(5.0f, 5.0f),
        Point2 = new Vector2F(15.0f, 5.0f),
        MaxFraction = 1.0f
    };

    bool hit = aabb.RayCast(out _, ref input, false);

    Assert.True(hit);
}
```

### Key Dependencies

- `RayCastInput` (Point1, Point2, MaxFraction)
- `RayCastOutput` (Fraction, Normal)
- `SettingEnv.Epsilon` (= 1.192092896e-07f)
- `SettingEnv.MaxFloat` (= 3.402823466e+38f)

### Learned

- `doInteriorCheck=false` allows rays starting inside the AABB to hit (skips tmin < 0 check)
- Negative direction triggers t1 > t2 swap in ProcessAxis and sets positive normal
- Boundary points with epsilon use strict `>` comparison, so exact boundary returns false
