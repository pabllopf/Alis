# Project Coverage State

Project:
1_Presentation/Extension/Graphic/Glfw/src/Alis.Extension.Graphic.Glfw.csproj

Test project:
1_Presentation/Extension/Graphic/Glfw/test/Alis.Extension.Graphic.Glfw.Test.csproj

Status:
COMPLETED

Agent:
cover-agent-glfw-001

Started:
2026-08-24T21:05:00Z

Last update:
2026-08-24T21:50:00Z

Initial coverage:
33.75% lines (272/806) — measured WITHOUT the GLFW main-thread hook (vstest run)
35.9% — SonarCloud reported

Current coverage (with working GLFW hook pipeline):
96.28% lines (776/806), 90.55% branches, 99.61% methods

Tests before:
599

Tests after:
607 (+8)

Files modified:
- test/MainThreadNativeWorker.cs
- test/NativeWindowCoverageTests.cs (new)

Coverage work:
- Built a working GLFW main-thread measurement pipeline (temp, outside repo):
  GlfwPreloadHook startup hook + xunit console runner (net10) + coverlet.console.
  This lets the 596 existing guarded tests exercise real GLFW, revealing the
  true 96.28% line coverage instead of the hook-less 33.75%.
- Added 8 tests + 6 MainThreadNativeWorker steps covering NativeWindow.cs
  null-handler branches (events fired without subscribers), null-title
  assignment/construction, fullscreen video mode, disposed event, Equals(object)
  with non-window and different-window args, and a no-client-API constructor.
  Branch coverage improved from 80.90% to 90.55%.

Remaining opportunities (all BLOCKED):
- GlfwNative.cs (12 lines): joystick hardware paths + error callback (crashes).
- NativeWindow.cs (10 lines): X11 selection on macOS (platform), SetIcons
  class-array marshaling defect, ReleaseHandle catch (defensive), OnKey
  KeyRepeat dead branch (HasFlag(0) always true).
- Vulkan.cs (8 lines): requires a Vulkan loader/device.

Baseline commit:
2734a0dfa7afe77a9827bef131b66a5c5ab2784e

Last commit:
a7a49a235 test: cover null-handler branches of NativeWindow.cs

Attempts:
1