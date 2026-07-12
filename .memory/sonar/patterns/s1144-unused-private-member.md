# Pattern: S1144 — Unused Private Member

## Rule
Remove unused private types or members.

## Fix (Conditional Usage)
Wrap field with `#if !TARGET_FRAMEWORK` guard to match its usage condition.

## Example
```csharp
// Before
private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

// After
#if !NET6_0_OR_GREATER
private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();
#endif
```

## File
`AZ9WLQxvb3Yg5Wvlzs08`

