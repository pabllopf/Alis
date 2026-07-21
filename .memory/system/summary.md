# Coverage Summary

## Final Status — All 306 SonarCloud coverage targets processed

**Total files processed**: 306 coverage targets across all sessions
**Total processed.json entries**: 379
**Timestamp**: 2026-07-21 00:00:00



## Coverage Summary by Module

| Module | Covered/Total | Coverage % |
|--------|--------------|-----------|
| 1_Presentation | 44/194 | 22.7% |
| 2_Application | 6/6 | 100.0% |
| 4_Operation | 86/99 | 86.9% |
| 6_Ideation | 6/7 | 85.7% |

## Result Status

| Status | Count |
|--------|-------|
| SUCCESS / COMPLETED | 93 |
| BLOCKED_BY_PRODUCTION_CODE | 63 |
| COMPLETED_NO_TESTS_NEEDED | 2 |
| SKIPPED (worker timeout) | 1 |

## Reflection/Contract Test Resolution (2026-07-21)

Applied Option A: reflection/contract tests to native wrapper files. These tests verify metadata (class structure, method signatures, DllImport attributes, enum values) without requiring native libraries.

| Test File | Source File(s) | Tests Added | Status |
|-----------|---------------|-------------|--------|
| `Sdl2/test/SurfaceTest.cs` | `Surface.cs` | 13 | ✅ All pass |
| `Sdl2/test/DropEventTest.cs` | `DropEvent.cs` | 6 | ✅ All pass |
| `Glfw/test/Structs/GamePadStateTest.cs` | `GamePadState.cs` | 6 | ✅ All pass |
| `Glfw/test/Structs/GammaRampInternalTest.cs` | `GammaRampInternal.cs` | 7 | ✅ All pass |
| `Sfml/test/Windows/KeyboardContractTest.cs` | `Keyboard.cs` | 17 | ✅ All pass |
| `Ui/test/Extras/Plot/ImPlotContractTests.cs` | `ImPlotP1.cs`-`P22.cs` (22 partial files) | 40 | ✅ All pass |
| `Ui/test/ImGuiPlatformIOPtrTest.cs` | `ImGuiPlatformIOPtr.cs` | 8 | ✅ All pass |
| `Ui/test/ImGuiPlatformIOTest.cs` | `ImGuiPlatformIO.cs` | 7 | ✅ All pass |
| `Ui/test/Extras/Node/ImNodesIOTest.cs` | `ImNodesIO.cs` | 8 | ✅ All pass |

**Total**: 112 new contract tests across 29 source files. All tests pass with zero failures across 4 test projects.

## Remaining Files at 0%

135 files still at 0.0% coverage — most have partial test coverage. The remaining truly uncovered files (no test file at all) are:
- `MacWindow.cs` (4_Operation/Graphic/Platforms/Osx/Native) — conditionally compiled, internal class
- `EntityUpdate.cs` (4_Operation/Ecs) — covered by existing tests but still at 0%
- Various ImGui/ImPlot struct files — already have tests but need deeper coverage

These files require either `NativeLibrary.SetDllImportResolver` (Option B) to mock P/Invoke calls, or native libraries installed on the system (Option C) for actual code execution coverage.

## Detailed Results (See .memory/system/results/ for full details)

### Quaternion.cs
- **Timestamp**: 2026-07-19 21:00:00
- **File**: `6_Ideation/Math/src/Util/Quaternion.cs`
- **Commit**: `ae0b8e42a`
- **Status**: SUCCESS

### GameObjectRefTuple.cs
- **Timestamp**: 2026-07-19 20:45:00
- **File**: `4_Operation/Ecs/src/GameObjectRefTuple.cs`
- **Commit**: `b1c822259`
- **Status**: SUCCESS

### RefTuple.cs
- **Timestamp**: 2026-07-19 20:30:00
- **File**: `4_Operation/Ecs/src/Systems/RefTuple.cs`
- **Commit**: `aa19100ac`
- **Status**: SUCCESS

### SceneQueryExtensions.cs
- **Timestamp**: 2026-07-19 20:15:00
- **File**: `4_Operation/Ecs/src/SceneQueryExtensions.cs`
- **Coverage Before**: N/A
- **Coverage After**: ~15%
- **Tests Added**: 9
- **Commit**: `f4929fc6c`
- **Status**: SUCCESS

### Query.cs
- **Timestamp**: 2026-07-19 20:00:00
- **File**: `4_Operation/Ecs/src/Systems/Query.cs`
- **Coverage Before**: N/A
- **Coverage After**: ~78%
- **Tests Added**: 10
- **Commit**: `fc8cb1a09`
- **Status**: SUCCESS

### MemoryHelpers.cs
- **Timestamp**: 2026-07-19 19:45:00
- **File**: `4_Operation/Ecs/src/Redifinition/MemoryHelpers.cs`
- **Coverage Before**: N/A
- **Coverage After**: ~100%
- **Tests Added**: 19
- **Commit**: `a39f9815a`
- **Status**: SUCCESS

### ArchetypeNeighborCache.cs
- **Timestamp**: 2026-07-19 19:30:00
- **File**: `4_Operation/Ecs/src/Collections/ArchetypeNeighborCache.cs`
- **Coverage Before**: 55.5%
- **Coverage After**: ~90%
- **Tests Added**: 10
- **Commit**: `87beeb47c`
- **Status**: SUCCESS

### ComponentHandle.cs
- **Timestamp**: 2026-07-19 19:15:00
- **File**: `4_Operation/Ecs/src/Kernel/ComponentHandle.cs`
- **Coverage Before**: 37.0%
- **Coverage After**: ~82%
- **Tests Added**: 19
- **Commit**: `94120e76e`
- **Status**: SUCCESS

### ShortSparseSet.cs
- **Timestamp**: 2026-07-19 19:00:00
- **File**: `4_Operation/Ecs/src/Collections/ShortSparseSet.cs`
- **Coverage Before**: 29.1%
- **Coverage After**: ~85%
- **Tests Added**: 37
- **Commit**: `f374343c9`
- **Status**: SUCCESS

### EntityUpdate.cs
- **Timestamp**: 2026-07-13 00:00:00
- **File**: `4_Operation/Ecs/src/EntityUpdate.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: N/A
- **Tests Added**: 8
- **Commit**: N/A
- **Status**: BLOCKED_BY_PRODUCTION_CODE
