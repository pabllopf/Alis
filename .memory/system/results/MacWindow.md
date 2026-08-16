# Result: MacWindow.cs

File: `4_Operation/Graphic/src/Platforms/Osx/Native/MacWindow.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (47/47, local coverlet, hook-enabled run)
TestsAdded: 0 (already remediated in commit 18170af8a)
Commit: test: coverage MacWindow.cs
Status: ALREADY_REMEDIATED

## Summary

MacWindow.cs is the macOS-native NSWindow wrapper (16 complexity / 59 LOC,
`#if osxarm64 || osxarm || osxx64 || osx`). Committed `MacWindowExecutionTests.cs` +
`MacOpenGLContextExecutionTests.cs` + `test/StartupHook.cs` (macOS main-thread hook pattern,
env-gated for CI) cover 47/47 lines = 100.0%.

## Verification

- Hook-enabled run (`ALIS_MACWINDOW_HOOK=1` + scratch reflection `DOTNET_STARTUP_HOOKS`,
  invoking MacWindowBootstrap + MacOpenGLContextBootstrap on the main thread): 6 passed,
  0 failed; `MacWindow.cs` 47/47 = 100.0%.
- No-hook (CI-equivalent) run: 6 passed as guarded no-ops.
