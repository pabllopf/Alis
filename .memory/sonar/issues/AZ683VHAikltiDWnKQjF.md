# Issue: AZ683VHAikltiDWnKQjF

- **Rule**: csharpsquid:S2325
- **File**: 1_Presentation/Engine/src/Menus/TopMenu.cs
- **Line**: 188
- **Severity**: MINOR
- **Message**: Make 'RenderGameObjectMenu' a static method.
- **Status**: committed

## Remediation

Changed `RenderGameObjectMenu` from instance method to `static`. No instance members accessed.

## Commit

`2c21639a0`
