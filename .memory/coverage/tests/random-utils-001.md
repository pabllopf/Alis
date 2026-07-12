## TEST FILE

### File
6_Ideation/Math/test/Util/RandomUtilsTest.cs

### Test Added
`StaticConstructor_InitializesRngField`

### Pattern
Reflection access to private static field to force `.cctor` execution.

### Source

```csharp
[Fact]
public void StaticConstructor_InitializesRngField()
{
    FieldInfo field = typeof(RandomUtils).GetField("Rng", BindingFlags.Static | BindingFlags.NonPublic);

    Assert.NotNull(field);

    object value = field.GetValue(null);

    Assert.NotNull(value);
}
```

### Reason
Line 43 (field initializer) was not covered because the `Rng` field has no references under `NET6_0_OR_GREATER` compilation. Directly accessing the field via reflection forces the type initializer to run.
