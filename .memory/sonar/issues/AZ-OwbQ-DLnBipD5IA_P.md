# Issue: AZ-OwbQ-DLnBipD5IA_P

- Rule: csharpsquid:S1121
- File: 6_Ideation/Memory/src/AssetRegistry.cs
- Line: 443
- Severity: MAJOR
- Message: Extract the assignment of 'rentedBuffer' from this expression.
- Status: RESOLVED

## Resolution

Extracted the assignment of `rentedBuffer` from the ternary expression into a separate declaration+initialization.
