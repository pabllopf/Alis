# Coverage State

Target:
./1_Presentation/Extension/Graphic/Glfw/src/NativeWindow.cs

Project:
./1_Presentation/Extension/Graphic/Glfw/src/Alis.Extension.Graphic.Glfw.csproj

Test project:
./1_Presentation/Extension/Graphic/Glfw/test/Alis.Extension.Graphic.Glfw.Test.csproj

Agent:
covertall-nativewindow-1789239

Baseline commit:
f76bd863b9e1a9e1e23df6ed60c74d832ea7f723

Initial line coverage:
97.25% (354/364) - measured with GLFW main-thread bootstrap enabled via
ALIS_GLFW_HOOK=1 and DOTNET_STARTUP_HOOKS (test assembly) combined with a
/tmp preload hook that resolves Alis.Core.Aspect.* from the test bin lib dir.
Without the hook the whole Glfw assembly reports 0% (see previous AGENT runs).

Initial branch coverage:
92.05% (81/88)

Current line coverage:
in progress

Current branch coverage:
in progress

Tests before:
604 passed, 3 skipped (607 total)

Tests after:
in progress

Files modified:
- test/MainThreadNativeWorker.cs (planned)
- test/NativeWindowExecutionTests.cs (planned)
- test/GlfwTestBootstrap.cs (if needed)

Tests added:
in progress

Commits:
none yet

Remaining uncovered lines (baseline):
720, 721 (GetX11SelectionString), 730 (SetX11SelectionString),
1062-1064 (ReleaseHandle catch path), 1327-1329 (OnKey repeat path)

Remaining uncovered branches (baseline):
509 (VideoMode monitor ternary, one path), 720 x2 (X11), 887
(CenterOnScreen monitor ternary, one path), 1322, 1328 x2 (OnKey)

Known platform blockers (to be verified):
- Lines 720/721/730 + branch 720: X11 selection strings are backed by
  PInvokes glfwGetX11SelectionString / glfwSetX11SelectionString which are
  absent from the macOS glfw.dylib build (EntryPointNotFoundException,
  recorded by the existing X11SelectionThrows worker step and asserted at
  NativeWindowExecutionTests.cs:701). Unreachable on macOS hosts.
- Line ~982/983 GlfwNative.SetWindowIcon call in SetIcons:
  Alis.Core.Graphic.Image is a plain managed class; the PInvoke
  signature (Image[] custom marshalling) raises MarshalDirectiveException
  before the call executes (recorded as IconsThrowsInteropException,
  asserted at NativeWindowExecutionTests.cs:682). Unreachable without an
  interop redesign (production change).
- ReleaseHandle catch path (1062-1064): reached only if
  GlfwNative.DestroyWindow throws; native GLFW destroy errors are reported
  via the registered silent error callback instead of exceptions. Likely
  unreachable.

Status:
IN_PROGRESS

Last update:
2026-09-12T19:20:00Z
