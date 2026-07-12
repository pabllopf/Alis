# Pattern: S1186 — Empty Method

## Rule
Methods should not be empty.

## Fix
Add `_ = typeof(T);` for generic type-guard methods, or `throw new NotSupportedException()` for non-conditional methods.

## Example (Conditional DEBUG)
```csharp
// Before
[Conditional("DEBUG")]
internal void EnsureType<T>() { }

// After
[Conditional("DEBUG")]
internal void EnsureType<T>()
{
    _ = typeof(T);
}
```

## File
`AZ9WLQtLb3Yg5Wvlzs07`

