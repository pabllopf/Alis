# Result: MacOpenGLContext.cs

File: `4_Operation/Graphic/src/Platforms/Osx/Native/MacOpenGLContext.cs`
CoverageBefore: 0.0% (SonarCloud stale; also 0/66 without the macOS startup hook)
CoverageAfter: 100.0% (66/66 lines, local coverlet, hook-enabled run)
TestsAdded: 0 (already fully covered by committed hook-gated suite)
Commit: test: coverage MacOpenGLContext.cs
Status: COMPLETE_ALREADY_COVERED

## Summary

MacOpenGLContext.cs is the internal macOS OpenGL context wrapper (10 complexity / 44 LOC per
SonarCloud; `#if osxarm64 || osxarm || osxx64 || osx` guarded). The committed
`MacOpenGLContextExecutionTests.cs` + `test/StartupHook.cs` (`MacOpenGLContextBootstrap` —
main-thread ObjC bootstrap, `ALIS_MACWINDOW_HOOK=1` env-gated for CI) cover 66/66 lines:
100.0% line coverage, verified via coverlet with the hook enabled on
`Alis.Core.Graphic.Test` (net8.0). Targeted run: 6 passed / 0 failed.

Without the hook (plain CI-equivalent run) the 6 tests are guarded no-ops and coverlet reads
0/66; the SonarCloud 0.0% reading is that stale no-hook artifact. No further tests can add
measurable coverage — construction requires a live AppKit window on the process main thread,
which the committed hook infra already performs (same pattern as MacWindow.cs, 100%).

## Verification

- Hook-enabled run: 6 passed / 0 failed; MacOpenGLContext.cs 66/66 = 100.0%.
- No-hook (CI-equivalent) run: 6 passed as guarded no-ops.
