# Issue: AZ683VIFikltiDWnKQjL

- **Rule**: csharpsquid:S1481
- **File**: 1_Presentation/Installer/src/Installer.cs
- **Line**: 76
- **Severity**: MINOR
- **Message**: Remove the unused local variable 'imguiContext'.
- **Clean Code Attribute**: INTENTIONAL
- **Status**: committed

## Remediation

Removed unused `IntPtr imguiContext` variable. `InitializeImGui()` already sets the ImGui context internally via `ImGui.SetCurrentContext()`, so the return value was redundant.

## Commit

`60a66f856`
