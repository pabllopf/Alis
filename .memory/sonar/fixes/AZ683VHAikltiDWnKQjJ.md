# Fix: AZ683VHAikltiDWnKQjJ

- **Rule**: csharpsquid:S2325
- **Pattern**: Make method static
- **File**: TopMenu.cs
- **Method**: RenderHelpMenu

## What Changed

- Changed method signature from `private void RenderHelpMenu()` to `private static void RenderHelpMenu()`

## Why

Method does not access any instance members. Only uses static ImGui API calls and `RenderMenuItem()`.
