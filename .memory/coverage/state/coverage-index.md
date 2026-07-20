# Coverage Index

## Project
- **Project**: pabllopf-official_alis
- **Branch**: master
- **Overall Coverage**: 65.7%
- **Line Coverage**: 63.6%
- **Branch Coverage**: 75.7%
- **Uncovered Lines**: 20,922
- **Uncovered Conditions**: 2,921

## Last Updated
2026-07-19T18:50:00Z

## Targets (sorted by uncovered lines)

| Priority | File | Coverage | Uncovered Lines |
|----------|------|----------|-----------------|
| 1 | 4_Operation/Ecs/src/GameObject.cs | 21.7% | 742 |
| 2 | 1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs | 0.0% | 179 |
| 3 | 1_Presentation/Extension/Media/FFmpeg/src/FFMpegWrapper.cs | 0.0% | 173 |
| 4 | 4_Operation/Graphic/src/Ui/Font.cs | 24.2% | 170 |
| 5 | 1_Presentation/Extension/Graphic/Glfw/src/GlfwNative.cs | 0.0% | 140 |
| 6 | 2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs | 46.6% | 136 |
| 7 | 4_Operation/Ecs/src/Kernel/CommandBuffer.cs | 32.4% | 128 |
| 8 | 4_Operation/Ecs/src/Kernel/Archetypes/Archetype.cs | 78.8% | 127 |
| 9 | 1_Presentation/Extension/Network/src/Internal/Events.cs | 44.0% | 121 |
| 10 | 1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioReader.cs | 0.0% | 119 |
| 11 | 2_Application/Alis/src/Core/Ecs/Systems/Manager/Graphic/GraphicManager.cs | 41.1% | 118 |
| 12 | 1_Presentation/Extension/Cloud/GoogleDrive/src/GoogleDriveCloudManager.cs | 53.4% | 111 |
| 13 | 1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioWriter.cs | 0.0% | 110 |
| 14 | 1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioPlayer.cs | 0.0% | 99 |
| 15 | 4_Operation/Graphic/src/OpenGL/Gl.cs | 54.2% | 94 |
| 16 | 4_Operation/Audio/src/Players/BrowserPlayer.cs | 61.0% | 85 |
| 17 | 4_Operation/Graphic/src/OpenGL/Constructs/GLShaderProgram.cs | 58.8% | 74 |
| 18 | 2_Application/Alis/src/Core/Ecs/Systems/Scope/ContextHandler.cs | 54.9% | 73 |
| 19 | 1_Presentation/Extension/Cloud/DropBox/src/DropBoxCloudManager.cs | 63.9% | 60 |
| 20 | 4_Operation/Graphic/src/Platforms/Web/EmscriptenWeb.cs | 77.7% | 59 |
| 21 | 4_Operation/Ecs/src/Collections/ArchetypeNeighborCache.cs | 55.5% | 37 |

## Processed Tasks

### 2026-07-19
- `ArchetypeNeighborCache.cs` — Added 16 tests covering Traverse, TraverseArchetype, Lookup, Set, round-robin, boundary conditions, and eviction. (Commit: fc4f034f6)
- `ComponentHandle.cs` — Added 3 tests covering Retrieve<T>() mismatched type error path. (Commit: 1cc73cba2)
- `EnumerableHelpers.cs` — Added 11 tests covering ToArray and GetEmptyEnumerator with various collection types. (Commit: c0327efb4)
- `Gen2GcCallback.cs` — Added 8 tests covering Register overloads and Gen2CollectionOccured event. (Commit: e8a431a2d)
