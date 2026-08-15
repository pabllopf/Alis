# Result: NativeWindow.cs

File: `1_Presentation/Extension/Graphic/Glfw/src/NativeWindow.cs`
CoverageBefore: 0.0% (SonarCloud; also 0/728 locally without the GLFW startup hook)
CoverageAfter: 98.63% (718/728 lines, local coverlet, hook-enabled run)
TestsAdded: 1 (Fullscreen_Parameterless_AppliesAndRestores) + worker-step wiring
Commit: test: coverage NativeWindow.cs
Status: PARTIALLY_REMEDIATED

## Summary

NativeWindow.cs is a thin SafeHandle wrapper over real GLFW window operations. GLFW 3.4 on macOS
requires window creation and every window operation on the process main thread, so the repo ships a
startup-hook infrastructure (`StartupHook` + `GlfwTestBootstrap` + `MainThreadNativeWorker`) that
runs the native steps on the main thread before the entry point. That infrastructure had two gaps:

1. The hook never invoked `MainThreadNativeWorker.Run()`, so none of the native steps executed and
   the whole execution suite was a silent no-op (Ready=false on CI → all tests early-return).
   Fixed in `GlfwTestBootstrap.cs` by invoking `Run()` after `Initialize()`.
2. `Fullscreen()` (parameterless) was never exercised. Added a worker step that applies it on the
   primary monitor and restores windowed mode, plus `Fullscreen_Parameterless_AppliesAndRestores`
   in `NativeWindowExecutionTests.cs`.

With the hook enabled, the existing + new suite covers 718/728 lines (98.63%). All 588 tests pass
both with and without the hook (the no-hook run keeps them as guarded no-ops).

## Remaining uncovered lines (10) — BLOCKED_BY_PRODUCTION_CODE

- 702-703 (`GetX11SelectionString` tail) and 712 (`SetX11SelectionString`): the native entry
  points `glfwGetX11SelectionString`/`glfwSetX11SelectionString` are not exported by the GLFW
  dylib on macOS, so the interop call throws `EntryPointNotFoundException` at the boundary (the
  call-site line is hit, the body never completes). X11-only.
- 959 (`SetIcons` call): `glfwSetWindowIcon` receives an `Image[]` that the default interop
  marshaller rejects with `MarshalDirectiveException` during argument marshalling, before the
  statement probe. Production marshalling defect.
- 1038-1040 (`ReleaseHandle` catch): `glfwDestroyWindow` never throws a managed exception for a
  valid handle; forcing it would require corrupting the GLFW window state (unsafe). Defensive
  catch, not safely coverable.
- 1303-1305 (`OnKey` KeyRepeat branch): dead code. `InputState.Release = 0`, so
  `state.HasFlag(InputState.Release)` is always true, and the `else` (repeat) branch is
  unreachable for every `InputState` value. Production enum-design defect.

## Verification

- Hook-enabled full suite: 588 passed, 0 failed, 0 skipped.
- No-hook (CI-equivalent) full suite: 588 passed, 0 failed, 0 skipped.
- The committed `DOTNET_STARTUP_HOOKS` path is environment-dependent: under `dotnet test`, the
  test-assembly hook cannot resolve its module-initializer dependency
  (`Alis.Core.Aspect.Memory`) in the hook-loading context. A dependency-free reflection hook
  (loaded from a scratch directory, not committed) was used to validate the wiring; the committed
  hook matches the repo's existing design and takes effect when the runtime can resolve it
  (e.g. running the Exe directly in a CI image that sets the env vars).
