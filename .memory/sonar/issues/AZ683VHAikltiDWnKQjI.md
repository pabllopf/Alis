# Issue: AZ683VHAikltiDWnKQjI

- **Rule**: csharpsquid:S2325
- **File**: 1_Presentation/Engine/src/Menus/TopMenu.cs
- **Line**: 245
- **Severity**: MINOR
- **Message**: Make 'RenderWindowMenu' a static method.
- **Status**: committed

## Remediation

Changed `RenderWindowMenu` from instance method to `static`. No instance members accessed.

## Commit

`2afb7d32f`
