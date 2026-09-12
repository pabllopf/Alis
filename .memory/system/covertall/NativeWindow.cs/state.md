# Coverage State

Target:
./1_Presentation/Extension/Graphic/Glfw/src/NativeWindow.cs

Project:
./1_Presentation/Extension/Graphic/Glfw/src/Alis.Extension.Graphic.Glfw.csproj

Test project:
./1_Presentation/Extension/Graphic/Glfw/test/Alis.Extension.Graphic.Glfw.Test.csproj

Agent:
covertall-nativewindow

Baseline commit:
f76bd863b9e1a9e1e23df6ed60c74d832ea7f723
(final iteration base: 9ce48470947a46a4189dd419b10c2fdd5a0b4d80 - the
"scan: all slns" commit picked up the first iteration while this agent
worked)

Initial line coverage:
97.25% (354/364) - requires running the Glfw test project with the
main-thread bootstrap: ALIS_GLFW_HOOK=1 plus DOTNET_STARTUP_HOOKS pointing
at the test assembly and a /tmp preload hook that resolves the
Alis.Core.Aspect.* assemblies for the generated ModuleInitializer (shared
ResourceAccessorGenerator limitation, see .memory/system/covertall/index.md).
Without the hook the module reports 0%.

Initial branch coverage:
92.05% (81/88)

Current line coverage:
98.08% (357/364)

Current branch coverage:
95.45% (84/88)

Tests before:
607 total (604 passed, 3 skipped)

Tests after:
611 total (608 passed, 3 skipped, 0 failures, measured with the bootstrap)

Files modified:
- src/NativeWindow.cs (OnKey repeat-state condition fix)
- test/MainThreadNativeWorker.cs
- test/NativeWindowExecutionTests.cs

Tests added:
- OnKey_WhenStateIsPress_RaisesPressEvent
- OnKey_WhenStateIsRelease_RaisesReleaseEvent
- OnKey_WhenStateIsRepeat_RaisesRepeatEvent
- OnKey_WhenFiredForEveryState_RaisesActionEventThreeTimes
- FireOnKey_RaisesKeyEvents expectations corrected
- worker step FireKeyStatesWithSubscribers + repeat fire without subscribers

Commits:
9ce484709 (scan, first iteration), final commit pending

Remaining uncovered lines (blocked):
- 720, 721 (GetX11SelectionString) and 730 (SetX11SelectionString):
  X11-only entry points absent from the macOS glfw build;
  EntryPointNotFoundException before the lines execute; asserted at
  NativeWindowExecutionTests.cs:701.
- 983 GlfwNative.SetWindowIcon call inside SetIcons: Array of managed
  Alis.Core.Graphic.Image cannot be marshaled; MarshalDirectiveException
  raised before execution (IconsThrowsInteropException asserted).
  Requires a GlfwNative interop redesign outside this file.
- 1062-1064 ReleaseHandle catch path: DestroyWindow failures are reported
  through the GLFW error callback, never as managed exceptions.

Remaining uncovered branches (blocked):
- 509 (VideoMode getter) and 887 (CenterOnScreen) non-None monitor paths:
  require a successful SetWindowMonitor display-mode transition, which
  segfaults GLFW on this host (DiagnosticReports
  dotnet-2026-09-12-191525.ips); fallback paths covered.
- two branch points at 720: unfoldable X11 ternary (see above).

Status:
BLOCKED (all reachable behavior covered; 7 lines / 4 branches are platform
or interop blockers documented above)

Last update:
2026-09-12T19:35:00Z
