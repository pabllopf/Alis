# Issue: AZ9WLQxvb3Yg5Wvlzs08

- Rule: csharpsquid:S1144
- File: 6_Ideation/Math/src/Util/RandomUtils.cs
- Line: 43
- Severity: MAJOR
- Message: Remove the unused private field 'Rng'.

## Code Snippet

```csharp
private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();
```

## Context

Field used in `#else` branches (non-NET6_0_OR_GREATER targets). Unused when `NET6_0_OR_GREATER` is defined.

