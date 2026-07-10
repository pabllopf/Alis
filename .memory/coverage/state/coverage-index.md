# Coverage Index

## Project
- Name: Alis
- SonarCloud Key: pabllopf-official_alis
- Branch: master
- Current Coverage: 63.3%

## Processed Files

| File | Coverage | Status | Commit | Date |
|------|----------|--------|--------|------|
| 4_Operation/Ecs/src/Kernel/ComponentRegistry.cs | 81.0% | COMPLETED | 24494aafc | 2026-07-10 |
| 1_Presentation/Extension/Cloud/GoogleDrive/src/GoogleDriveCloudManager.cs | 15.6% | COMPLETED | a6ed2a02a | 2026-07-10 |
| 1_Presentation/Extension/Media/FFmpeg/src/BaseClasses/MediaReader.cs | 79.3% | COMPLETED | 800a64c4e | 2026-07-10 |
| 2_Application/Alis/src/Core/Ecs/Components/Render/Animator.cs | 98.9% | COMPLETED | c5837536f | 2026-07-10 |
| 4_Operation/Ecs/src/Collections/EnumerableHelpers.cs | 90.3% | COMPLETED | 4a8083b7c | 2026-07-10 |
| 4_Operation/Graphic/src/OpenGL/Constructs/GLShader.cs | 41.9% | COMPLETED (19 tests via GlMock) | pending | 2026-07-10 |
| 4_Operation/Graphic/src/OpenGL/Constructs/GLShaderProgram.cs | 0.0% | COMPLETED (19 tests via GlMock) | pending | 2026-07-10 |
| 4_Operation/Graphic/src/OpenGL/Constructs/GLShaderProgramParam.cs | 0.0% | COMPLETED (19 tests via GlMock) | pending | 2026-07-10 |

## Tasks
- TASK-001: ComponentRegistry.cs - cover remaining 19 uncovered lines
- TASK-002: GoogleDriveCloudManager.cs - cover edge-case/exception paths (23 tests added)
- TASK-003: MediaReader.cs - cover CopyToAsync throw paths
- TASK-004: Animator.cs - cover default struct and edge case paths
- TASK-005: EnumerableHelpers.cs - cover resize paths and edge cases
- TASK-006: GLShader + GLShaderProgram + GLShaderProgramParam - cover via mocked OpenGL delegates (19 tests added)
