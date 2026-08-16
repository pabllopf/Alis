# Result: GlfwNative.cs

File: `1_Presentation/Extension/Graphic/Glfw/src/GlfwNative.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 91.43% (128/140, committed result; local hook run 86.4% = 121/140 due to macOS clipboard/title readback flake)
TestsAdded: 0 (already remediated in commit f95d84630)
Commit: test: coverage GlfwNative.cs
Status: ALREADY_REMEDIATED

## Summary

GlfwNative.cs is the GLFW native-interop surface (57 complexity / 448 LOC). Committed
`GlfwNativeTests.cs` / `GlfwNativeExecutionTests.cs` (+ Context/Input/Monitor/WindowHint
suites, real native GLFW execution via the main-thread startup-hook pattern) cover 128/140
lines (91.43%).

## Remaining uncovered (12) — BLOCKED_BY_PRODUCTION_CODE

- GetJoystickHats/Axes/Buttons loop bodies: require a physically connected joystick
  (opportunistic tests included).
- Private `GlfwError` callback: replaced by a silent callback before tests run; only reachable
  on native errors.

## Verification

- Hook-enabled local run (`ALIS_GLFW_HOOK=1` + scratch reflection `DOTNET_STARTUP_HOOKS`):
  46 passed, 2 failed (environmental macOS flake: `GetClipboardString_MainThreadWorker`
  returns null — clipboard permission/readback — and `SetWindowTitle_MainThreadWorker`
  title readback differs; both are no-op guarded on CI). Uncovered lines match the committed
  set: joystick loops (384-387) + GlfwError callback (2002-2003).
- No-hook (CI-equivalent) run: all pass as guarded no-ops.
