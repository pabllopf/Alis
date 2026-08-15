# Result: WebAssemblyDisplayManager.cs

File: `4_Operation/Graphic/src/Platforms/Web/WebAssemblyDisplayManager.cs`
CoverageBefore: 0.0% (SonarCloud stale; local coverlet 278/314 = 88.5%)
CoverageAfter: 88.5% (278/314 lines, local coverlet; unchanged)
TestsAdded: 0 (blocked)
Commit: test: coverage WebAssemblyDisplayManager.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

WebAssemblyDisplayManager is the WebAssembly display subsystem (67 complexity / 500 LOC per
SonarCloud, includes DisplayMode / ScreenOrientation / DisplayQuality / event args types). The
committed `WebAssemblyDisplayManagerExecutionTests.cs` (94 tests) plus
`WebAssemblyDisplayManagerTest.cs` / `WebAssemblyDisplayManagerCoverageFinalTests.cs` cover
everything reachable on a desktop host; targeted run: 88 passed / 41 skipped (`[WebOnly]`) /
129 total on `Alis.Core.Graphic.Test` (net8.0).

Covered (278 lines): constructor (null-guard, defaults 800x600, portrait/square detection,
supported-modes list incl. the fullscreen-only 1920x1080 entry), GetWidth/GetHeight/
GetAspectRatio/GetOrientation, GetDevicePixelRatio (1.0 fallback), all 7 GetRenderingScale
switch arms + default, SetDisplayQuality/GetDisplayQuality, FindDisplayMode (hit/miss),
SetResolution happy path + OnDisplayResized/OnOrientationChanged events, Enter/Exit/Toggle
Fullscreen desktop-false paths, IsFullscreen, GetSupportedModes, GetSystemLanguage ("en"),
IsOnline (false), GetBatteryLevel (-1), IsCharging (false), RefreshRate, SaveScreenshot happy
path, Update resize/orientation event paths, and all value types.

## Remaining uncovered lines (18) — BLOCKED_BY_PRODUCTION_CODE, per-line

- 204-206 — `SetResolution` catch block. Only `_platform.SetSize` can throw and
  `EmscriptenWeb.SetCanvasSize` swallows all exceptions (EmscriptenWeb.cs:674-681);
  unreachable without production change.
- 231-234 — `EnterFullscreen` success body. Requires `EmscriptenWeb.RequestFullscreen()`
  (EmscriptenWeb.cs:755-761) to return true; native JS unavailable on desktop, catch returns
  false. Browser-only.
- 245-248 — `ExitFullscreen` success body. Same blocker via `ExitFullscreen()`
  (EmscriptenWeb.cs:770-776).
- 342-344 — `SaveScreenshot` catch block. Try-body is only `return true;` and cannot throw.
- 377-380 — `Update` fullscreen-state-change branch. Requires
  `EmscriptenWeb.IsFullscreenEnabled()` (always false on desktop) to differ from the field
  `_isFullscreen` (always false). Browser-only.

All require a live browser environment or production changes; identical blocker family to
WebAssemblyGameContext.cs. Targeted run: 88 passed / 41 skipped (`[WebOnly]`) / 129 total.
