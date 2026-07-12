# Issue: AZ9WLQtLb3Yg5Wvlzs07

- Rule: csharpsquid:S1186
- File: 4_Operation/Graphic/src/OpenGL/Constructs/GLShaderProgramParam.cs
- Line: 231
- Severity: CRITICAL
- Message: Add a nested comment explaining why this method is empty, throw a 'NotSupportedException' or complete the implementation.

## Code Snippet

```csharp
[Conditional("DEBUG")]
internal void EnsureType<T>()
{
}
```

## Context

Type-guard method called from all SetValue overloads. Only active in DEBUG builds via `[Conditional("DEBUG")]`.

