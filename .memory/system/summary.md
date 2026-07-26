# Coverage Summary

## VideoWriter.cs

- **File**: `1_Presentation/Extension/Media/FFmpeg/src/Video/VideoWriter.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 97.1%
- **Tests Added**: 48
- **Uncovered Lines**: Lines 260-263 (`catch` block in `CloseWrite` — cannot be hit on macOS since `Process.Kill()` never throws for valid processes)
