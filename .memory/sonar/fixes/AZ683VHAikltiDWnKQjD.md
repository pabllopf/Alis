# Fix: AZ683VHAikltiDWnKQjD

- **Rule**: csharpsquid:S2325
- **Pattern**: Make method static
- **File**: TopMenu.cs
- **Method**: RenderAssetsMenu

## What Changed

- Changed method signature from `private void RenderAssetsMenu()` to `private static void RenderAssetsMenu()`

## Why

Method does not access any instance members. Only uses static ImGui API calls and `RenderMenuItem()`.
