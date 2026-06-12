# Fix: AZ683VHAikltiDWnKQjI

- **Rule**: csharpsquid:S2325
- **Pattern**: Make method static
- **File**: TopMenu.cs
- **Method**: RenderWindowMenu

## What Changed

- Changed method signature from `private void RenderWindowMenu()` to `private static void RenderWindowMenu()`

## Why

Method does not access any instance members. Only uses static ImGui API calls and `RenderMenuItem()`.
