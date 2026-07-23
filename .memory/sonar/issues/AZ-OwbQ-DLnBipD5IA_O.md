# Issue: AZ-OwbQ-DLnBipD5IA_O

- Rule: csharpsquid:S1144
- File: 6_Ideation/Memory/src/AssetRegistry.cs
- Line: 510
- Severity: MAJOR
- Message: Remove the unused private method 'ToLowerHex'.
- Status: RESOLVED

## Resolution

Removed the unused `ToLowerHex(byte[])` overload at line 510. This overload delegated to the `ReadOnlySpan<byte>` overload but was never called in any active TFM build.
