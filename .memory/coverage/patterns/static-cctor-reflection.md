## PATTERN: Static Constructor Coverage via Reflection

### Problem
Static field initializers in `beforefieldinit` classes may not be covered when the field has zero references in the active compilation path (e.g., conditional compilation with `#if`).

### Solution
Use reflection to access the private static field, forcing the type initializer to execute:

```csharp
[Fact]
public void StaticConstructor_InitializesRngField()
{
    FieldInfo field = typeof(TargetClass).GetField("FieldName", BindingFlags.Static | BindingFlags.NonPublic);
    Assert.NotNull(field);
    object value = field.GetValue(null);
    Assert.NotNull(value);
}
```

### Applicable To
- Conditional compilation paths (`#if NET6_0_OR_GREATER`)
- Lazy-initialized static fields
- Private fields unreferenced in the active TFM path
