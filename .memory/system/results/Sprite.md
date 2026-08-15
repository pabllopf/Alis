# Sprite.cs (ECS)

- **File**: `2_Application/Alis/src/Core/Ecs/Components/Render/Sprite.cs`
- **Coverage Before**: 31.6% (SonarCloud); 34.3% local baseline
- **Coverage After**: 99.1% (214/216 lines, local coverlet)
- **Tests Added**: 5 (SpriteRenderCoverageTests.cs — fake OpenGL function pointers exercise LoadTexture, shared resource initialization, error paths and the full render pipeline without a live GL context)
- **Uncovered Lines**: 323, 357 — closing braces of exception-terminated resource-fallback branches
- **Status**: COMPLETED
