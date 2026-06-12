# Issue: AZ683VHAikltiDWnKQjG

- **Rule**: csharpsquid:S2325
- **File**: 1_Presentation/Engine/src/Menus/TopMenu.cs
- **Line**: 217
- **Severity**: MINOR
- **Message**: Make 'RenderComponentMenu' a static method.
- **Status**: committed

## Remediation

Changed `RenderComponentMenu` from instance method to `static`. No instance members accessed.

## Commit

`804101f3c`
