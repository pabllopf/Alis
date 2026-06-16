## PATTERN: S3928 — Parameterize exception helpers

When a helper method throws ArgumentOutOfRangeException without a message, add a `paramName` parameter and pass `nameof(variable)` at each call site.

Example:
```csharp
// Before
private static void Throw() => throw new ArgumentOutOfRangeException();

// After
private static void Throw(string paramName) => throw new ArgumentOutOfRangeException(paramName);
```
