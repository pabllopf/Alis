# Fix: AZ6OPa6Rsynw1OJ1vi46

- **Rule**: S3776 (Cognitive Complexity)
- **File**: AssetsWindow.cs:196
- **Fix**: Extracted `RenderPlusMenu()` helper method from `Render()` to reduce cognitive complexity. The BeginCombo body with 30+ conditional selectable/menu items was moved to a separate method, eliminating nested complexity from the main Render method.
- **Commit**: 5f1b41c2c
