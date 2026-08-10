# Sprite.cs

- **File**: `2_Application/Alis/src/Core/Ecs/Components/Render/Sprite.cs`
- **Coverage Before**: 31.6%
- **Coverage After**: ~40.0% (combined with existing tests; remaining are OpenGL-bound paths)
- **Tests Added**: 5
- **Uncovered Lines**: OpenGL-bound paths (`Render`, `LoadTexture`, shader init) require GL context unavailable on CI
- **Status**: COMPLETED
