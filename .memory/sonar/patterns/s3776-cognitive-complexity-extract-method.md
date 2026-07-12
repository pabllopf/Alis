# Pattern: S3776 — Reduce Cognitive Complexity via Method Extraction

## Rule

csharpsquid:S3776 — Cognitive Complexity exceeds threshold

## Problem Signature

A method has cognitive complexity above the allowed threshold (typically 15) due to:
- Multiple null checks
- Nested loops with conditionals
- OR/AND conditions in if statements
- Multiple independent validation sections

## Reusable Transformation

1. Identify independent validation/logic sections within the method
2. Extract each section into a private method with a descriptive name
3. Original method delegates to extracted methods in sequence
4. Keep all exception types, messages, and behavior identical

## Example

```csharp
// Before: complexity 19
public void Validate()
{
    if (_board == null) throw ...;
    if (_board.GetLength(0) <= 0 || ...) throw ...;
    if (_rooms == null) throw ...;
    for (...) { if (...) throw ...; if (...) throw ...; }
    if (_corridors == null) throw ...;
    for (...) { if (...) throw ...; if (...) throw ...; }
}

// After: complexity 0 (extracted)
public void Validate()
{
    ValidateBoard();
    ValidateRooms();
    ValidateCorridors();
}
```

## Applicable Rules

- S3776 (Cognitive Complexity)