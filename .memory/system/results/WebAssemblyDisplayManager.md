# Result: WebAssemblyDisplayManager.cs

File: `4_Operation/Graphic/src/Platforms/Web/WebAssemblyDisplayManager.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 90.4% (142/157 lines, local coverlet)
TestsAdded: 2 (WebAssemblyDisplayManagerCatchCoverageTests.cs)
Commit: test: coverage WebAssemblyDisplayManager.cs
Status: PARTIALLY_REMEDIATED

## Summary

WebAssemblyDisplayManager is the WebAssembly display subsystem (70 complexity / 239 LOC per
SonarCloud; the file also declares DisplayMode, ScreenOrientation, DisplayQuality and the
event-args types). It is constructed from the native-free `WebAssemblyPlatform` parameterless
ctor, and all EmscriptenWeb static calls fall back to safe defaults on a desktop host
(DllNotFoundException caught by the facade), so most behavior is testable on macOS.

The committed suite (`WebAssemblyDisplayManagerExecutionTests.cs`, `...Test.cs`,
`...CoverageTests.cs`, `...CoverageFinalTests.cs`) already covered 139/157 lines (88.5%).
This session added `WebAssemblyDisplayManagerCatchCoverageTests.cs` with 2 tests that drive
the previously-uncovered `SetResolution` failure catch (lines 204-206) by raising exceptions
from the public `OnDisplayResized` / `OnOrientationChanged` event subscribers — the only
deterministic route into it, since `WebAssemblyPlatform.SetSize` itself never throws on
desktop. Coverage: 142/157 = 90.4%. Full filter: 90 passed, 0 failed, 41 platform-gated
skipped.

## Remaining uncovered lines (15) — BLOCKED_BY_PRODUCTION_CODE

- 231-234, 245-248 (EnterFullscreen/ExitFullscreen success bodies): require
  `EmscriptenWeb.RequestFullscreen()`/`ExitFullscreen()` to return true, which needs the
  `libemscripten` WebAssembly runtime absent on desktop hosts.
- 377-380 (Update fullscreen-change branch): requires `EmscriptenWeb.IsFullscreenEnabled()`
  to return true (native), with `_isFullscreen` initially false.
- 342-344 (SaveScreenshot catch): dead code — the try body is `return true` unconditionally
  and cannot throw.

## Verification

- WebAssemblyDisplayManager filter (net8.0, Debug): 90 passed, 0 failed, 41 skipped.
- Local coverlet: 142/157 lines (90.4%); new tests cover lines 204-206.
