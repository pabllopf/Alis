# Result: Sdl.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Sdl.cs`
CoverageBefore: 19.6% (SonarCloud; stale — local no-hook 818/834 = 98.1%)
CoverageAfter: 99.0% (826/834, local coverlet, hook-enabled run; +8 lines from new tests)
TestsAdded: 6 (Sdl2TestBootstrap.cs + Sdl2MainThreadExecutionTests.cs main-thread hook pattern; SdlCoverageTests.TouchDeviceQuery)
Commit: test: coverage Sdl.cs
Status: PARTIALLY_REMEDIATED

## Summary

Sdl.cs is the static SDL2 wrapper surface (381 complexity / 1042 LOC). The committed suite
(SdlTests, Sdl2AdditionalTests, SdlManagedHelpersTests, etc.) covers 818/834 executable lines
(98.1%). The 16 remaining lines were thin one-line wrappers:

- Covered now (8): `CreateWindow` (658-662), `CreateWindowAndRenderer` (673),
  `CreateContext` (1038), `CreateCursor` (3038), `GetTouchDevice` (3099) — exercised on the
  process main thread via the new `Sdl2TestBootstrap` + `StartupHook` (ALIS_SDL2_HOOK=1 +
  DOTNET_STARTUP_HOOKS), because SDL2's Cocoa driver aborts AppKit with
  "API misuse: setting the main menu on a non-main thread" on xUnit worker threads. The new
  execution tests are guarded no-ops when the hook is absent (CI-safe; no-hook full suite 557
  passed / 0 failed).

## Remaining uncovered (8) — BLOCKED_BY_PRODUCTION_CODE

- 1466-1470 — `GetGrabbedWindow`: the bundled `sdl2.dylib` in the test output crashes the
  process on `SDL_GetGrabbedWindow` (verified with a standalone probe; crash occurs before any
  SDL_Init, both with and without the hook).
- 3106 / 3114 / 3121 — `GetNumTouchFingers`, `GetTouchFinger`, `GetTouchDeviceType` with zero
  touch IDs: `SDL_GetTouch(0)` returns NULL and the bundled SDL2 dereferences it (verified with
  a standalone probe: process crash).
- 4106 — `MapRgb`: requires a valid `SDL_PixelFormat*`; no export exists in NativeSdl to obtain
  one (`SDL_GetPixelFormatFromEnum`/`SDL_FreeFormat` are not declared), and creating a format
  pointer by hand is unsafe.

## Verification

- Hook-enabled (`ALIS_SDL2_HOOK=1` + scratch reflection DOTNET_STARTUP_HOOKS): target filter
  run 6/6 passed; all 8 target wrapper lines hit.
- No-hook full suite: 557 passed, 0 failed, 0 skipped.
