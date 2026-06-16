# Issue AZ7KU7-PgfB4D_M8MD1T

- Rule: csharpsquid:S3776
- Severity: CRITICAL
- File: 4_Operation/Ecs/generator/ComponentUpdateTypeRegistryGenerator.cs
- Line: 106
- Message: Refactor this method to reduce its Cognitive Complexity from 21 to the 15 allowed.
- Status: Fixed
- Fixed At: 2026-06-16

## Code Snippet

```csharp
private static ComponentUpdateItemModel GenerateComponentUpdateModel(...)
{
    // 2 early returns, local functions AddMiscFlags and GetContainingTypes
    // complex if with &&/||
}
```

## Fix

Extracted local functions `AddMiscFlags` and `GetContainingTypes` into private static methods.
Simplified compound boolean condition into a local variable `requiresSelfInit`.
