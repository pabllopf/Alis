## COVERAGE TEST PATTERN

### Target
AABB.cs — RayCast Y-axis normal assignment

### Pattern
Shallow diagonal ray entering AABB through Y-axis face.

```csharp
[Fact]
public void RayCast_WithShallowDiagonalFromBelowLeft_ShouldSetNormalY()
{
    Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(10.0f, 10.0f));
    RayCastInput input = new RayCastInput
    {
        Point1 = new Vector2F(-10.0f, -10.0f),
        Point2 = new Vector2F(20.0f, 6.0f),
        MaxFraction = 1.0f
    };

    bool hit = aabb.RayCast(out RayCastOutput output, ref input);

    Assert.True(hit);
    Assert.True(output.Fraction > 0.5f);
    Assert.Equal(-1.0f, output.Normal.Y);
}
```

### Key Insight
The Y-axis `t1 > tmin` branch (line 420) only triggers when the ray's Y-axis entry time exceeds the X-axis entry time. Requires `dY > dX/2` to allow Y-axis entry before X-axis exit.
