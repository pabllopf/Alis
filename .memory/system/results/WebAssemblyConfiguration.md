# Result: WebAssemblyConfiguration.cs

File: `4_Operation/Graphic/src/Platforms/Web/WebAssemblyConfiguration.cs`
CoverageBefore: 54.6% (SonarCloud stale; local coverlet 194/358 = 54.2%)
CoverageAfter: 90.8% (330/358 lines, local coverlet; +36.6%)
TestsAdded: 8 (desktop-safe WebAssemblyPlatformFactory tests)
Commit: test: coverage WebAssemblyConfiguration.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

WebAssemblyConfiguration.cs hosts three types (75 complexity / 216 LOC per SonarCloud):
`WebAssemblyConfigurationBuilder` (158/158), `WebAssemblyConfiguration` (36/36) and
`WebAssemblyPlatformFactory` (0/164 before — all its tests were `[WebOnly]`-gated and skipped
on macOS). The committed suite covered the builder and configuration fully but never exercised
the factory on this host.

## Work performed

Added 8 desktop-safe `[Fact]` tests to `WebAssemblyConfigurationTest.cs` (no `[WebOnly]` gate)
that exercise `WebAssemblyPlatformFactory`:
- `CreateDefault` → returns a constructed platform (the platform ctor is pure managed).
- `Create(null config)` and `Create(null action)` → ArgumentNullException.
- `Create(config)`, `Create(action)`, `CreateForGameDevelopment`, `CreateForLowEndDevice`,
  `CreateForHighEndDevice` → InvalidOperationException, because `platform.Initialize(...)` hits
  the Emscripten EGL P/Invoke and returns false outside the browser (the factory then throws at
  line 339). This covers the full preset-config construction and the factory body up to the
  EGL boundary. Targeted run: 8 passed / 3 platform-gated skipped.

## Remaining uncovered lines (14) — BLOCKED_BY_PRODUCTION_CODE

- 342-353 — `Create(config)` Fullscreen/PointerLock branches and the final `return platform;`.
  Only reachable when `platform.Initialize(...)` returns true, which requires a live browser
  EGL surface (same blocker family as WebAssemblyGameContext.cs / WebAssemblyPlatformIntegration).
- 368, 394, 416, 440 — the `return Create(...)` lines of the action overload and the three
  preset factories: unreachable because `Create` always throws at the EGL boundary on desktop.

## Verification

- Targeted run: 8 passed / 3 skipped (net8.0).
- Local coverlet: WebAssemblyConfiguration.cs 330/358 lines (90.8%); factory 136/164 (82.9%).
