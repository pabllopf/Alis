# Fix: AZ683VIFikltiDWnKQjL

- **Rule**: csharpsquid:S1481
- **Pattern**: Remove unused local variable
- **File**: Installer.cs

## What Changed

- Changed `IntPtr imguiContext = InitializeImGui();` to `InitializeImGui();`

## Why

Variable was assigned but never used. The method already sets the context internally.
