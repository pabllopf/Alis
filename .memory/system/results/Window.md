# Result: Window.cs

File: `1_Presentation/Extension/Graphic/Glfw/src/Structs/Window.cs`
CoverageBefore: 90.0% (SonarCloud; Line: 87.5%, Branch: 100.0%, 2 uncovered lines)
CoverageAfter: 100.0% (32/32, local coverlet, hook-enabled full Glfw suite)
TestsAdded: 0 (already remediated — committed WindowOpacityExecutionTests cover the native lines)
Commit: test: coverage Window.cs
Status: ALREADY_REMEDIATED

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
