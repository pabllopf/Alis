# WindowsPlayer.cs

- **File**: `4_Operation/Audio/src/Players/WindowsPlayer.cs`
- **Coverage Before**: 38.1% (SonarCloud); 38.6% local baseline
- **Coverage After**: 48.3% (70/145 lines, local coverlet)
- **Tests Added**: 8 (WindowsPlayerUnixCoverageTests.cs — winmm-missing paths, not-playing no-ops)
- **Uncovered Lines**: 75 — mciSendString success/error-code branches and active playback state transitions require winmm.dll (Windows-only); covered by existing `[WindowsOnly]` tests on Windows CI
- **Status**: COMPLETED
