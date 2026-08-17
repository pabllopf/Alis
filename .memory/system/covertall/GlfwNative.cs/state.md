# State — GlfwNative.cs

Target: 1_Presentation/Extension/Graphic/Glfw/src/GlfwNative.cs
Project: 1_Presentation/Extension/Graphic/Glfw/src/Alis.Extension.Graphic.Glfw.csproj
Test project: 1_Presentation/Extension/Graphic/Glfw/test/Alis.Extension.Graphic.Glfw.Test.csproj
Agent: cover-agent-001
Baseline commit: 2e91a3e6cfb3a7ba79b612b87b591954d0c1a5b4
Initial line coverage: 91.43% (128/140) — best reliably measured run (with repo hook)
Initial branch coverage: 72.22% (13/18)
Current line coverage: 91.43%
Current branch coverage: 72.22%
Tests before: 596
Tests after: 596
Files modified: none
Tests added: 0
Commits: none
Remaining uncovered lines: 384-387, 1714-1716, 1731-1733, 2002-2003
Remaining uncovered branches: 383/path1, 412/path0, 478/path0, 1713/path0, 1730/path1
Status: BLOCKED
Last update: 2026-08-17

## Blocker

Uncovered code in GlfwNative.cs requires either a connected joystick/gamepad
device or the GLFW main-thread hook with reliable instrumentation:

1. Lines 384-387 (GetJoystickHats loop body) + branch 383/path1: requires a
   joystick WITH hats (count > 0). No joystick is connected on this machine
   (verified: JoystickPresent(0..15) all false, GetJoystickHats/Buttons return 0).
   HARDWARE DEPENDENT.

2. Lines 1714-1716 (GetJoystickAxes `if (count > 0)` body) + branch 1713/path0:
   the `count == 0` path is covered by missing-device queries; the `count > 0`
   body requires a joystick WITH axes. HARDWARE DEPENDENT.

3. Lines 1731-1733 (GetJoystickButtons loop body) + branch 1730/path1: requires
   a joystick WITH buttons. HARDWARE DEPENDENT.

4. Branch 412/path0 and 478/path0 (GetJoystickGuid / GetGamepadName null path):
   covered by the guarded tests in GlfwNativeExecutionTests
   (GetJoystickGuid_MissingDevice_ReturnsNull, GetGamepadName_MissingDevice_ReturnsNull)
   only when GlfwTestBootstrap.Ready is true in the instrumented process. The
   hook's execution is flaky in this environment (instrumentation race with the
   preload hook; Ready occasionally false because Initialize() can throw late).
   In the runs where instrumentation succeeded, Ready was false so the guarded
   tests early-returned; in runs where Ready was true, instrumentation raced.

5. Lines 2002-2003 (GlfwError throw): the private error callback. Triggering it
   requires making GLFW report an error after glfwInit, e.g.
   GlfwNative.GetClientApi(Window.None). Any test that calls a GlfwNative
   method on a worker thread without the main-thread hook triggers the static
   ctor's glfwInit() on the worker thread, which HANGS the process on macOS
   (verified empirically: a candidate test suite hung repeatedly; removing the
   GlfwNative-touching tests restored the 596-test suite to a 112ms pass).
   A candidate error-path test was written, caused hangs, and was removed.

## Notes

- GlfwNative's static ctor (lines 62-65) calls Init() + SetErrorCallback. On
  macOS this must happen on the process main thread; the repo's own tests
  therefore gate every GlfwNative-touching test behind
  `[RequireGlfwFact]` + `if (!GlfwTestBootstrap.Ready) return;`.
- The repo's startup-hook infrastructure (StartupHook + GlfwTestBootstrap +
  MainThreadNativeWorker, ALIS_GLFW_HOOK=1 + DOTNET_STARTUP_HOOKS) is the only
  way to run GLFW on the main thread in-process. It works only with a temporary
  preload hook (outside the repo) because the test assembly's generated Memory
  module initializer cannot resolve Alis.Core.Aspect.Memory during the
  startup-hook phase.
- A concurrent agent is actively working on the same Glfw test project
  (commit 14f55cc2e added GameWindowConstructorTests; their in-flight edits add
  a RequireNoGlfwFact attribute). Their files were left untouched.