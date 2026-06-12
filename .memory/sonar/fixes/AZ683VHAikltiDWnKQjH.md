# Fix: AZ683VHAikltiDWnKQjH

- **Rule**: csharpsquid:S2325
- **Pattern**: Make method static
- **File**: TopMenu.cs
- **Method**: RenderToolsMenu

## What Changed

- Changed method signature from `private void RenderToolsMenu()` to `private static void RenderToolsMenu()`

## Why

Method does not access any instance members. Only uses static ImGui API calls and `RenderMenuItem()`.
