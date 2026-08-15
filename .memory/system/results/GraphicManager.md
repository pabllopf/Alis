# GraphicManager.cs

- **File**: `2_Application/Alis/src/Core/Ecs/Systems/Manager/Graphic/GraphicManager.cs`
- **Coverage Before**: 39.6% (SonarCloud); 58.8% local baseline
- **Coverage After**: 65.6% (145/221 lines, local coverlet)
- **Tests Added**: 4 (GraphicManagerPreviewCoverageTests.cs — preview-mode init/render paths, debug-disabled collider loop)
- **Uncovered Lines**: 76 — non-preview OnInit/OnDraw require a live macOS platform window (NSWindow/OpenGL context); BuildNewKeys needs the platform field; collider debug render needs the full shader GL surface
- **Status**: COMPLETED
