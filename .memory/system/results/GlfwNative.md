# GlfwNative.cs Coverage Remediation Result

- File: 1_Presentation/Extension/Graphic/Glfw/src/GlfwNative.cs
- CoverageBefore: 1.9% (137 uncovered lines, 18 uncovered branches, per SonarCloud master cache 2026-09-14; ncloc 563, complexity 57)
- CoverageAfter: 1.9%
- TestsAdded: 0
- Commit: test: coverage GlfwNative.cs
- Status: BLOCKED_BY_PRODUCTION_CODE

Notes: Every uncovered line in GlfwNative.cs is inside a managed wrapper (properties Monitors/Time/Version/VersionString, GetError, WindowHintStringUTF8/ASCII, GetJoystickHats, GetJoystickGuid, UpdateGamepadMappings(string), GetGamepadName, CreateWindow, GetClipboardString, GetContextVersion, GetJoystickAxes/Buttons/Name, GetKeyName, GetMonitorName, GetProcAddress, GetVideoMode(s), GetWindowAttribute, SetClipboardString, SetWindowTitle, WindowHint overloads, etc.) whose body P/Invokes an [ExcludeFromCodeCoverage] extern requiring the native `glfw` library. The runtime `glfw` library is not bundled, not installed on this dev machine (only Emscripten GLFW headers exist), and is not installed by either CI workflow ([ALIS][SONARCLOUD].yml and [ALIS][EXTENSION][GRAPHIC][GLFW][SONARCLOUD].yml). GlfwNative's static ctor calls Init(), so any wrapper invocation throws TypeInitializationException/DllNotFoundException without the library, which would fail CI. Existing tests (GlfwNativeExecutionTests, GlfwNativeInputTests, GlfwNativeMonitorTests, etc.) are gated by [RequireGlfwFact] and no-op/skip when glfw is absent, which is why SonarCloud measures 1.9%. Covering these lines requires a production-side change (excluding the wrapper bodies from coverage or abstracting the native layer), which is forbidden by the source-protection rules.