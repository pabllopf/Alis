# Result: WindowsPlayer.cs

File: `4_Operation/Audio/src/Players/WindowsPlayer.cs`
CoverageBefore: 38.1% (SonarCloud stale; local coverlet 140/290 = 48.3%)
CoverageAfter: 48.3% (140/290 lines, local coverlet; unchanged)
TestsAdded: 0 (all remaining lines require winmm.dll; Windows-only platform)
Commit: test: coverage WindowsPlayer.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

WindowsPlayer.cs is the Windows MCI/winmm audio player (33 complexity / 189 LOC per SonarCloud).
The committed suite (`WindowsPlayerTest.cs` / `WindowsPlayerTests.cs` /
`WindowsPlayerLogicTests.cs` / `WindowsPlayerStubbedTests.cs` /
`WindowsPlayerCrossPlatformTests.cs` / `WindowsPlayerUnixCoverageTests.cs`) covers 140/290
lines locally (48.3%); targeted run: 53 passed / 61 not-run (platform-gated `[WindowsOnly]`) /
114 total on `Alis.Core.Audio.Test` (net8.0).

Covered on macOS: constructor, the FileNotFound fallback paths (resource extraction throw
propagates), the `DllNotFoundException` boundary of every MCI command (verified via
`[UnixOnly]` tests), the not-playing no-op guards of Pause/Resume/Stop, Dispose, and
`HandlePlaybackFinished` internals.

## Remaining uncovered lines (150) — BLOCKED_BY_PRODUCTION_CODE

Every remaining line requires `winmm.dll` (`mciSendString` / `mciGetErrorString` /
`waveOutSetVolume`) to load and return success on a Windows host:

- 86-90 — Dispose's `Stop` `InvalidOperationException` catch (only when MCI is available and
  errors).
- 123, 128, 161, 166 — `Play`/`PlayLoop` resource-extraction catch branches (only reachable
  when the asset lookup itself throws for an existing-file path).
- 137-145, 173-196 — `Play`/`PlayLoop` success paths (state flags, timer wiring,
  `Task.CompletedTask`).
- 204-213, 224-230, 241-247 — Pause/Resume/Stop success paths.
- 265-266 — `SetVolume` (waveOutSetVolume).
- 333-348 — `ExecuteMsiCommand` error path (result != 0 → InvalidOperationException with
  mciGetErrorString) and the Status-length timer parse.

`mciSendString` DllImport on macOS throws `DllNotFoundException` before line 333 is reached, so
the `result != 0` branch and all post-call lines are unreachable on this host. Same platform
family as BrowserPlayer.cs (WebAssembly-only). Requires a Windows CI host; out of scope for
coverage work.

## Verification

- Targeted run: 53 passed / 61 platform-gated not-run (net8.0).
- Local coverlet: WindowsPlayer.cs 140/290 lines (48.3%).
