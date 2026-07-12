# Pattern: S1186 — Complete Empty Conditional Method via Debug.Assert

## Rule

csharpsquid:S1186 — Empty method body

## Problem Signature

A method decorated with `[Conditional("DEBUG")]` has an empty body. SonarCloud flags it as needing a comment, exception, or implementation.

## Reusable Transformation

1. Check if the method is `[Conditional("DEBUG")]`
2. If so, complete the implementation with `Debug.Assert` logic
3. `Debug.Assert` is also `[Conditional("DEBUG")]` so no Release behavior change
4. Use `System.Diagnostics.Debug.Assert` (already imported in most files)
5. Provide a descriptive assertion message including parameter name and types

## Example

```csharp
// Before
[Conditional("DEBUG")]
internal void EnsureType<T>()
{
}

// After
[Conditional("DEBUG")]
internal void EnsureType<T>()
{
    Debug.Assert(Type == typeof(T), $"Type mismatch for parameter '{Name}': expected {typeof(T)}, got {Type}.");
}
```

## Applicable Rules

- S1186 (Empty method) when method has `[Conditional("DEBUG")]`