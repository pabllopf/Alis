# Coverage Summary

## VideoWriter.cs

- **File**: `1_Presentation/Extension/Media/FFmpeg/src/Video/VideoWriter.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 97.1%
- **Tests Added**: 48
- **Uncovered Lines**: Lines 260-263 (`catch` block in `CloseWrite` — cannot be hit on macOS since `Process.Kill()` never throws for valid processes)

## SceneManager.cs

- **File**: `2_Application/Alis/src/Core/Ecs/Systems/Manager/Scene/SceneManager.cs`
- **Coverage Before**: 98.6%
- **Coverage After**: 100.0%
- **Tests Added**: 1
- **Uncovered Lines**: None

## UnixPlayerBase.cs

- **File**: `4_Operation/Audio/src/Players/UnixPlayerBase.cs`
- **Coverage Before**: 98.5%
- **Coverage After**: 100.0%
- **Tests Added**: 1
- **Uncovered Lines**: None (line 282 `}` is non-executable closing brace)
