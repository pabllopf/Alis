# Result: WebAssemblyPlatformIntegration.cs

File: `4_Operation/Graphic/src/Platforms/Web/WebAssemblyPlatformIntegration.cs`
CoverageBefore: 0.0% (SonarCloud stale; local coverlet 166/304 = 54.6%)
CoverageAfter: 54.6% (166/304 lines, local coverlet; unchanged)
TestsAdded: 0 (all remaining lines require a constructed WebAssemblyGameContext; blocked)
Commit: test: coverage WebAssemblyPlatformIntegration.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

WebAssemblyPlatformIntegration.cs is a single file hosting six types (62 complexity / 207 LOC
per SonarCloud): `WebAssemblyPlatformIntegration`, `MultiplatformGameEngine`,
`InputManager`, `DisplayManager`, `SystemInfo` and `QuickStart`. The committed suite
(`WebAssemblyPlatformIntegrationExecutionTests.cs` / `_SafeTests.cs` / `_CoverageTests.cs` /
`_Test.cs` — commit 3bb446d58) covers 166/304 lines locally (54.6%); targeted run: 46 passed /
37 skipped (`[WebOnly]`) / 83 total on `Alis.Core.Graphic.Test` (net8.0).

Covered (166 lines): the full `WebAssemblyPlatformIntegration` and `SystemInfo` statics
(72/72 and 20/20 — all delegate to EmscriptenWeb which falls back to safe defaults on desktop),
the constructor throw-paths of `MultiplatformGameEngine` (`WebAssemblyGameContext.Create`
throws), `InputManager`/`DisplayManager` null-context construction and first-call
NullReferenceException probes, `DisplayManager.SetFullscreen(true)` first-line, and
`QuickStart.LogPlatformInfo` (all statics, safe on desktop).

## Root cause — instance construction is impossible on macOS

The remaining 138 uncovered lines are exclusively instance members of `MultiplatformGameEngine`
(24 lines: property getters 236/240/244, ctor body 255-257 after `Create` throws, Run 265-267,
Dispose family 273-293), `InputManager` (32 lines: GetMovementInput body 324-346, IsJumpPressed
355-356, IsAttackPressed 366-367, GetCameraInput 382-387), `DisplayManager` (1 line: the
`SetFullscreen(false)` else-branch 436-437) and the `QuickStart.RunMinimalGame` body
(538-549). Every one requires a successfully-constructed `WebAssemblyGameContext`:

1. `MultiplatformGameEngine` ctor line 254 calls `WebAssemblyGameContext.Create(width, height,
   title)` → `WebAssemblyPlatformFactory.Create` → `platform.Initialize(...)` →
   `InitializeEglContext()` → `EGL.GetDisplay(IntPtr.Zero)` (native P/Invoke, Emscripten EGL
   only).
2. On macOS the EGL surface is unavailable, `Initialize` returns false, the factory throws
   `InvalidOperationException`, so the engine ctor never completes — lines 255-257 and every
   instance member below are unreachable.
3. `WebAssemblyGameContext` is `sealed` with instance members; Moq cannot mock it and AOT rules
   forbid reflection/emit. No test can create the context locally.

Identical blocker family to WebAssemblyGameContext.cs (already recorded). Targeted run: 46
passed / 37 skipped (`[WebOnly]`) / 83 total.
