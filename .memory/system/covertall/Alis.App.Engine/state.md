# Project Coverage State

Project:
./1_Presentation/Engine/src/Alis.App.Engine.csproj

Test project:
./1_Presentation/Engine/test/Alis.App.Engine.Test.csproj

Status:
PARTIAL

Agent:
covertall-agent-engine

Started: 2026-09-10
Last update: 2026-09-10

Initial coverage (coverlet XPlat, net8.0 Debug):
17.22% lines (440/2555, Engine src only)

Current coverage:
19.18% lines (490/2555)

Tests: 194 baseline → 202 (8 added)

Files modified (test side):
- test/SpaceWorkLifecycleTest.cs (new)
- test/TopMenuActionExecutionTest.cs (new)

Coverage work:
- SpaceWork: constructor default vs existing projectConfig.json path, default
  Fps/IsRunning state, OnInit/OnStart NotImplementedException paths
  (27/95 -> 65/95)
- TopMenuAction: Preferences/Quit Alis (NotImplementedException) and
  New Scene (NotSupportedException) via ExecuteMenuAction public API

Commits:
- ab820ae95 test: cover project config and lifecycle branches of SpaceWork.cs
- d7e5d0b5d test: cover exception paths of TopMenuAction.cs

Remaining opportunities (not testable, rationale):
- Engine.cs (876 lines, 100% unhit): full editor render loop, requires live
  GLFW/ImGui/OpenGL window context; calling OnRender from tests would invoke
  native ImGui APIs without an ImGui context and aborts the test host.
- Windows/DockSpaceMenu/BottomMenu/ConsoleWindow Render() bodies and Demo
  Run() bodies: same native ImGui dependency (previous agents already
  documented ImPlot P/Invoke bodies aborting the test host).
- Shortcut static constructor Linux/Windows branches: platform-bound
  (OperatingSystem.IsLinux()/IsWindows() cannot be forced on macOS).
- TopMenuAction remaining ~200 lines: mostly single Logger statements in
  actions that require _spaceWork with live ImGui context (Save writes INI
  via ImGui.SaveIniSettingsToDisk; OpenUrl launches real processes).

Test result: PASS (202/202). Attempts: 1
