# State — GameWindow.cs

Target: 1_Presentation/Extension/Graphic/Glfw/src/GameWindow.cs
Project: 1_Presentation/Extension/Graphic/Glfw/src/Alis.Extension.Graphic.Glfw.csproj
Test project: 1_Presentation/Extension/Graphic/Glfw/test/Alis.Extension.Graphic.Glfw.Test.csproj
Agent: cover-agent-001
Baseline commit: 2e91a3e6cfb3a7ba79b612b87b591954d0c1a5b4
Initial line coverage: 0.00% (0/10)
Initial branch coverage: 100.00% (0/0)
Current line coverage: 100.00% (10/10)
Current branch coverage: 100.00% (0/0)
Tests before: 596
Tests after: 596
Files modified: none
Tests added: 0
Commits: none
Remaining uncovered lines: none
Remaining uncovered branches: none
Status: COMPLETED
Last update: 2026-08-17

## Execution environment

GLFW on macOS requires initialization and window creation on the process main
thread. The repo's own test infrastructure (GlfwTestBootstrap.cs / StartupHook /
MainThreadNativeWorker) runs the GameWindow constructors on the main thread via
a .NET startup hook, enabled with:

    ALIS_GLFW_HOOK=1
    DOTNET_STARTUP_HOOKS=<...>/Alis.Extension.Graphic.Glfw.Test.dll

Without these env vars the existing GameWindowExecutionTests are documented
no-ops ("Tests are harmless no-ops when the startup hook was not installed"),
which is why the baseline was 0%.

A pre-existing environment issue prevented the hook from working out of the box:
the test assembly's Memory-generator module initializer could not resolve
`Alis.Core.Aspect.Memory` during the startup-hook phase. This was worked around
with a temporary preload hook (outside the repo) that Assembly.LoadFroms the
Alis.* assemblies from the test output before the test hook runs. With the hook
active, the full suite passes and OpenCover reports GameWindow.cs at 10/10
sequence points (100% line) and 0/0 branches (100%).

## Caveat — other agent's in-flight test

While this work was in progress, another agent committed
`test/GameWindowConstructorTests.cs` (commit 14f55cc2e, "release: memory").
Those tests call `new GameWindow()` with no GLFW initialization, which HANGS the
native glfwCreateWindow call on macOS and therefore hangs the entire test
project for the plain `dotnet test` invocation. Verified: filtering out
`GameWindowConstructorTests` yields 596/596 pass in 4s. Those tests belong to
another agent's in-flight work and were left untouched.