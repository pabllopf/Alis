# Result: Window.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Windows/Window.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 0.0% (unchanged)
TestsAdded: 0
Commit: (none)
Status: BLOCKED_BY_NATIVE

## Summary

Window.cs is an SFML (CSFML) native window wrapper (`Alis.Extension.Graphic.Sfml.Windows.Window`).
A source scan shows every public method and property body is a direct delegation to a native
`sfWindow_*`/`sfMouse_*`/`sfTouch_*`/`sfWindow_create*` P/Invoke, with no deterministic managed
prelude:

- All 4 title/stream/handle constructors either hit `sfWindow_createUnicode` or
  `sfWindow_createFromHandle` (native) as a base initializer or body call. The only GetBytes site,
  `Encoding.UTF32.GetBytes(title + '\0')`, does NOT throw for a null title (string concatenation
  yields "\0"), so no null-probe exception exists; execution continues to the native call.
- `Position`, `Size`, `Settings`, `PollEvent`, `WaitEvent`, `SetTitle`, `SetIcon`, `Display`, etc.
  all delegate to native.
- `ToString()` returns "[Window] Size(...) Position(...) Settings(...)" but reads `Size`/`Position`/
  `Settings`, all native.
- `Marshal.` is never used (`Marshal.` count = 0), so there is no managed interop layer.

## Why it cannot be deterministically covered (per the engine's deterministic constraints)

- Same direct-string-to-native marshaling behavior verified for SFML (Shader.cs): null C# strings pass
  straight through without a managed `ArgumentNullException` and segfault the host.
- Every non-string member requires the native `csfml-window` library at runtime AND a real created
  window/context. Without the native lib, calls throw `DllNotFoundException` (non-deterministic across
  CI images); with an invalid pointer, they crash.
- The repo's existing SFML tests rely on a main-thread startup-hook bootstrap + `[RequireCSfmlWindowsFact]`
  that SKIPS without native SFML — the skip-without-native pattern the engine identified as the root
  cause of 0% coverage, and not portable/deterministic.

Fabricating native-presence-dependent tests would be non-deterministic. Recorded as BLOCKED_BY_NATIVE
with no test added.

## Verification

- Static analysis only (whole-file scan for managed control flow / Marshal / non-native logic): none.
- No build/test run needed — no tests were generated.