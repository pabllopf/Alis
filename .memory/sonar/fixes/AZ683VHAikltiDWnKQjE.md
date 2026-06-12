# Fix: AZ683VHAikltiDWnKQjE

- **Rule**: csharpsquid:S2325
- **Pattern**: Make method static
- **File**: TopMenu.cs
- **Method**: RenderEditMenu

## What Changed

- Changed method signature from `private void RenderEditMenu()` to `private static void RenderEditMenu()`

## Why

Method does not access any instance members. Only uses static ImGui API calls and `RenderMenuItem()`.
