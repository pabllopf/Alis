# MacNativePlatform.cs

- **File**: `4_Operation/Graphic/src/Platforms/Osx/MacNativePlatform.cs`
- **Coverage Before**: 14.2% (SonarCloud); 15.7% local baseline
- **Coverage After**: 43.7% (153/350 lines, local coverlet)
- **Tests Added**: 9 (MacNativePlatformTests.cs — key mapping, mouse/window state, macOS proc-address and cursor queries)
- **Uncovered Lines**: 197 — Initialize/PollEvents/event handlers/GetWindowMetrics require a real AppKit window session and live NSEvents; native windowing constraint
- **Status**: COMPLETED
