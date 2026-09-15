# Glfw Native Gate Fix — 2026-09-15

## Files
- 1_Presentation/Extension/Graphic/Glfw/test/Attributes/RequireGlfwFactAttribute.cs
- 1_Presentation/Extension/Graphic/Glfw/test/Attributes/RequireNoGlfwFactAttribute.cs

## Change
Added the bare `{name}.dylib` / `{name}.so` candidates to the native-library resolution so the
redistributed `runtimes/osx-x64|arm64/native/glfw.dylib` dropped into the test output directory is
found. The bundled `glfw.dylib` is self-contained (only system frameworks), so it loads on CI.

## Verified
- Glfw test project: 608 passed, 3 skipped (the 3 skips are the intentional
  `*_WhenGlfwUnavailable_Throws` tests via RequireNoGlfwFact, now correctly skipping because the
  bundled library resolves).

## Impact / limitation
This mirrors the Sdl2 gate fix, but on CI the window/context GLFW tests still no-op because they are
gated on `GlfwTestBootstrap.Ready`, which requires `DOTNET_STARTUP_HOOKS` + `ALIS_GLFW_HOOK=1`
process environment variables that the SonarCloud workflow does not set. GLFW/Cocoa window operations
require the process main thread, so they cannot be triggered from an xUnit worker thread (verified:
thread-safe GLFW calls from a worker thread hang). Full Glfw coverage on CI therefore still requires a
workflow change to install the startup hook.

## Status
COMPLETED (gate fix) — CI coverage for GlfwNative/NativeWindow remains BLOCKED_BY_CI_BOOTSTRAP
