# Issue: AZ69k12mUs3jAr3sDLt2

- **Rule**: csharpsquid:S3241
- **Severity**: MINOR
- **File**: 1_Presentation/Installer/src/Installer.cs
- **Line**: 109
- **Message**: Change return type to 'void'; not a single caller uses the returned value.
- **Status**: FIXED

## Description

Method `InitializeImGui()` returned `IntPtr` but no caller ever used the return value.
The only call site at line 76 (`InitializeImGui();`) discards the returned pointer.

## Fix

Changed return type from `IntPtr` to `void`, removed `return imguiContext;` statement,
and updated the XML doc comment to reflect the change.
