# Issue: AZ683VHAikltiDWnKQjD

- **Rule**: csharpsquid:S2325
- **File**: 1_Presentation/Engine/src/Menus/TopMenu.cs
- **Line**: 163
- **Severity**: MINOR
- **Message**: Make 'RenderAssetsMenu' a static method.
- **Status**: committed

## Remediation

Changed `RenderAssetsMenu` from instance method to `static`. No instance members accessed.

## Commit

`575a15ba0`
