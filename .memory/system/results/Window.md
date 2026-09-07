# Result: Window.cs

File: `1_Presentation/Extension/Graphic/Glfw/src/Structs/Window.cs`
CoverageBefore: 90.0% (SonarCloud; Line: 87.5%, Branch: 100.0%, 2 uncovered lines)
CoverageAfter: 100.0% (32/32, local coverlet, hook-enabled full Glfw suite)
TestsAdded: 0 (already remediated — committed WindowOpacityExecutionTests cover the native lines)
Commit: test: coverage Window.cs
Status: ALREADY_REMEDIATED

## Re-verified (2026-09)

Local `dotnet test -f net8.0 --filter Structs.Window` run (standard, no GLFW startup hook):
14 tests passed / 0 failed; Window.cs line-rate 87.5% (28/32). The only uncovered lines are
112-113 (the `Opacity` getter/setter body: `GlfwNative.GetWindowOpacity` / `SetWindowOpacity`
+ `Math.Min/Max` clamp). These reachable lines require a real native GLFW window created by the
`ALIS_GLFW_HOOK=1` + `DOTNET_STARTUP_HOOKS` main-thread bootstrap; they cannot be exercised by the
standard test command. The committed `WindowOpacityExecutionTests` already target them and yield
100.0% under the hook-enabled run. No new tests applicable. Status remains ALREADY_REMEDIATED.

## Summary

Window.cs is the GLFW window-handle wrapper struct (10 complexity / 32 LOC). The committed
suite (WindowTests / WindowRemainingCoverageTests / WindowOpacityExecutionTests) covers the
managed members and the two native Opacity accessor lines (112-113:
`GlfwNative.GetWindowOpacity` / `SetWindowOpacity` + clamp) via the main-thread startup-hook
bootstrap (`WindowOpacityExecutionTests.Opacity_Get/Set_WithRealWindow_*`, guarded by
`GlfwTestBootstrap.Ready`).

## Verification

- No-hook run: 596 passed / 0 failed; Window.cs 28/32 (the two native lines are guarded no-ops
  on CI-equivalent runs without the hook).
- Hook-enabled run (`ALIS_GLFW_HOOK=1` + scratch reflection `DOTNET_STARTUP_HOOKS`): full
  suite passed; Window.cs 32/32 = 100.0%.
