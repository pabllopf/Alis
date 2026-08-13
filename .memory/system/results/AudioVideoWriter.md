# AudioVideoWriter.cs

- **File**: `1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs`
- **Coverage Before**: 0.0% (SonarCloud stale)
- **Coverage After**: 98.3% (176/179, local — 124 existing tests pass)
- **Tests Added**: 0 (existing suite authoritative: AudioVideoWriterTest 37 + Remaining 8 + Coverage 25 + FullCoverage + WriteFrame + OpenWrite)
- **Uncovered Lines**: 379-382 — defensive `catch` around `Ffmpegp.Kill()` (race-only branch between HasExited check and Kill); requires production change or process race to reach
- **Status**: BLOCKED_BY_PRODUCTION_CODE
