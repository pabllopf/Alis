# Issue: AZ683VHAikltiDWnKQjJ

- **Rule**: csharpsquid:S2325
- **File**: 1_Presentation/Engine/src/Menus/TopMenu.cs
- **Line**: 259
- **Severity**: MINOR
- **Message**: Make 'RenderHelpMenu' a static method.
- **Status**: committed

## Remediation

Changed `RenderHelpMenu` from instance method to `static`. No instance members accessed.

## Commit

`8af1f0bae`
