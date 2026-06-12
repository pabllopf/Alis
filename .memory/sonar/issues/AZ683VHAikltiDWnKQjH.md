# Issue: AZ683VHAikltiDWnKQjH

- **Rule**: csharpsquid:S2325
- **File**: 1_Presentation/Engine/src/Menus/TopMenu.cs
- **Line**: 232
- **Severity**: MINOR
- **Message**: Make 'RenderToolsMenu' a static method.
- **Status**: committed

## Remediation

Changed `RenderToolsMenu` from instance method to `static`. No instance members accessed.

## Commit

`90b7427b9`
