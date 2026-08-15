# Result: MacNativePlatform.cs

File: `4_Operation/Graphic/src/Platforms/Osx/MacNativePlatform.cs`
CoverageBefore: 14.2% (SonarCloud stale; local coverlet 362/700 = 51.7%)
CoverageAfter: 65.4% (458/700 lines, local coverlet, hook-enabled; +13.7%)
TestsAdded: 8 (main-thread platform bootstrap tests)
Commit: test: coverage MacNativePlatform.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

MacNativePlatform.cs is the macOS AppKit/OpenGL native platform (101 complexity / 424 LOC per
SonarCloud). The committed suite (`MacNativePlatformTest.cs` / `MacNativePlatformTests.cs` /
`MacNativePlatformRemainingCoverageTests.cs` / `MacNativePlatformFinalCoverageTests.cs`) covered
362/700 lines; the entire `Initialize` path and every window/mouse/proc-address member were only
testable on the process main thread.

## Work performed

Added `MacNativePlatformBootstrap` to `test/StartupHook.cs` (the established main-thread hook
pattern used for MacWindow.cs/MacOpenGLContext.cs) which runs after the window/context
bootstraps and executes: `Initialize(320, 200, "exec")`, GetWindowWidth/Height, ShowWindow/
HideWindow, SetTitle/SetSize, MakeContextCurrent/SwapBuffers, GetWindowPositionX/Y,
GetWindowMetrics, GetMousePositionInView, IsKeyDown, GetProcAddress("glClearColor"),
GetMouseState, TryGetLastKeyPressed, TryGetLastInputCharacters and Cleanup — recording each
result. Added 8 `[MacOsOnly]` tests in `MacNativePlatformTests.cs` asserting the recorded state
(guarded no-ops when the hook is absent). Hook-enabled run: 52 passed / 0 failed on
`Alis.Core.Graphic.Test` (net8.0).

## Remaining uncovered lines (242) — BLOCKED_BY_PRODUCTION_CODE

- 177-262 — `PollEvents` event-loop and mouse/key handler bodies (event-type dispatch,
  HandleMouseEvent cases 1-4/22, UpdateMousePosition, sendEvent/updateWindows). Requires
  synthetic NSEvents delivered through `nextEventMatchingMask:` on the live app — platform
  event-synthesis machinery, not expressible as a deterministic unit test.
- 295-297 — `HandleKeyUpEvent` fallback branch; 312-313, 318-319, 324-325 —
  `ExtractCharacterFromEvent` null/empty guards. Reachable only via the same synthetic key
  events.
- 540-543 — `GetWindowMetrics` else branch (`contentView == IntPtr.Zero`); 568-569 —
  `GetMousePositionInView` null-view guard. Unreachable with a live NSWindow (the view always
  exists).
- 608-610 — `GetProcAddress` failure branch (OpenGL framework always loads on macOS).
- 623-691 — `Initialize(width, height, title, iconPath)` and `SetWindowIcon` bodies. Require a
  real .ico/PNG icon file delivered through ObjC `initWithContentsOfFile:`; the repo's test
  assets contain no macOS icon file, and the path is a production file-loading concern.

## Verification

- Hook-enabled run: 52 passed / 0 failed (net8.0).
- Local coverlet (hook-enabled): MacNativePlatform.cs 458/700 lines (65.4%).
- No-hook (CI-equivalent) run: same 52 tests pass as guarded no-ops.
