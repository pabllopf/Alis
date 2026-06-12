# Fix: AZ683VHAikltiDWnKQjF

- **Rule**: csharpsquid:S2325
- **Pattern**: Make method static
- **File**: TopMenu.cs
- **Method**: RenderGameObjectMenu

## What Changed

- Changed method signature from `private void RenderGameObjectMenu()` to `private static void RenderGameObjectMenu()`

## Why

Method does not access any instance members. Only uses static ImGui API calls and `RenderMenuItem()`.
