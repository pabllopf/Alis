# Result: WebAssemblyGameContext.cs

File: `4_Operation/Graphic/src/Platforms/Web/WebAssemblyGameContext.cs`
CoverageBefore: 0.0% (SonarCloud stale; local coverlet 80/270 = 29.6%)
CoverageAfter: 29.6% (80/270 lines, local coverlet; unchanged)
TestsAdded: 0 (blocked)
Commit: test: coverage WebAssemblyGameContext.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

WebAssemblyGameContext is a `sealed` WebAssembly-only game context (66 complexity / 230 LOC per
SonarCloud) exposing the platform, input, display and configuration subsystems plus the
Show/Hide/Run lifecycle. The committed `WebAssemblyGameContextTest.cs` /
`WebAssemblyGameContextSafeTests.cs` / `WebAssemblyGameContextExecutionTests.cs` already cover
80/270 lines (29.6%); the targeted run passes 23 and platform-skips 37 tests (`[WebOnly]`).

The 80 covered lines are exclusively: the constructor throw-paths (line 120 null-check and
line 122 `WebAssemblyPlatformFactory.Create` which throws), the parameterless-ctor delegation,
the static expression-bodied helpers (VibrateGamepad, IsFullscreen, LockPointer/UnlockPointer,
IsPointerLocked, ConsoleLog/Warn/Error, ShowAlert/ShowConfirm, GetDeviceLanguage,
GetBatteryLevel, IsCharging, IsOnline, GetRefreshRate) and the fully-covered
`GameContextPresets` (110/110) config factories. Nothing requires a successfully-constructed
instance.

## Root cause — instance construction is impossible on macOS

`new WebAssemblyGameContext(configuration)` (line 118) cannot complete on a non-WebAssembly host:

1. `_platform = WebAssemblyPlatformFactory.Create(configuration)` (line 122) →
   `WebAssemblyPlatformFactory.Create` (WebAssemblyConfiguration.cs:328) → `platform.Initialize(...)`
   → `WebAssemblyPlatform.Initialize` (WebAssemblyPlatform.cs:156) → `InitializeEglContext()`
   → `EGL.GetDisplay(IntPtr.Zero)` (native P/Invoke, Emscripten EGL only).
2. On macOS the EGL native surface is unavailable, `Initialize` returns false (its `catch` swallows),
   and the factory throws `InvalidOperationException("Failed to initialize WebAssembly platform")`.
3. The constructor therefore never reaches lines 123-129 (coverage confirms: 120/122 hit,
   123-129 never hit) — no `WebAssemblyGameContext` instance can exist locally, so every
   remaining uncovered line is an instance member.

## Remaining uncovered lines (95) — BLOCKED_BY_PRODUCTION_CODE, per-line

All require a constructed instance (unreachable on macOS):

- 73, 78, 83, 88, 93, 98 — property getters (Platform, InputManager, InputContext,
  DisplayManager, Configuration, IsRunning).
- 123-129 — constructor body after the platform factory call (`new WebAssemblyInputManager` /
  `WebAssemblyInputContext` / `WebAssemblyDisplayManager`, `_isRunning`, `_disposed`).
- 135, 136 — parameterless constructor body.
- 151, 161 — `Create(...)` return (constructor throws inside the expression).
- 167-169, 175-177 — `Show()` / `Hide()` (delegate to `_platform.ShowWindow/HideWindow`).
- 183-202 — `Run(updateCallback)`: null-guard, already-running guard, `_isRunning = true`,
  `ShowWindow`, try/finally with `RunGameLoop` and `OnShutdown`.
- 208-230 — `RunGameLoop`: the `while (_platform.PollEvents() && _isRunning)` iteration body
  (`_inputContext.Update()`, `_displayManager.Update()`, callback/`OnUpdate` invocation,
  exception log, `MakeContextCurrent`, `OnFrame`, `SwapBuffers`) — infinite browser loop.
- 236-238, 244-246 — `RegisterAction` overloads.
- 251, 256, 300, 305, 325, 330 — input wrappers (IsActionActive, IsActionJustPressed,
  IsMouseButtonDown, GetMouseWheelDelta, GetConnectedGamepadIndices, TryGetGamepadState).
- 261, 266, 271 — window wrappers (GetWidth, GetHeight, GetAspectRatio).
- 277-279, 285-287 — SetSize / SetTitle.
- 293-295 — GetMousePosition (out params).
- 310, 315, 320 — keyboard wrappers (IsKeyDown, TryGetKeyPressed, TryGetInputText).
- 340, 345, 350 — fullscreen wrappers (ToggleFullscreen, EnterFullscreen, ExitFullscreen).
- 376-378 — `Stop()`.
- 446-453 — `Dispose()` (double-dispose guard, `Cleanup`, `_disposed = true`).

EGL / WebAssembly (Emscripten JS) interop is required for construction; identical blocker
family to EmscriptenWeb.cs (Ui module). Targeted run: 23 passed / 37 skipped (`[WebOnly]`) /
60 total on `Alis.Core.Graphic.Test` (net8.0).
