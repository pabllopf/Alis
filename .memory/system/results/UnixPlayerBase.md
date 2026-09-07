# Result: UnixPlayerBase.cs

File: `4_Operation/Audio/src/Players/UnixPlayerBase.cs`
CoverageBefore: 80.95% (136/168, local coverlet net8.0, UnixPlayerBase filter)
CoverageAfter: 92.85% (156/168, local coverlet net8.0, UnixPlayerBase filter)
TestsAdded: 2 (UnixPlayerBasePauseResumeCoverageTests.cs, UnixPlayerBaseGetAudioDurationCoverageTests.cs; plus previous UnixPlayerBaseRemainingCoverageTests.cs)
Commit: test: UnixPlayerBase.cs
Status: PARTIALLY_REMEDIATED (BLOCKED_BY_PRODUCTION_CODE for Resume live-process branch)

## Summary

UnixPlayerBase.cs (abstract bash-driven audio player base, `IPlayer`). Prior pass covered the
playback-finished handler and the afinfo guard. This pass covered the Pause live-process body
and the afinfo "estimated duration" parse branch.

## Work performed

- `UnixPlayerBasePauseResumeCoverageTests.cs` — `Pause_WhenPlayingAndNotPaused_SetsPausedTrue`:
  uses a private `LongRunningPlayer` subclass (`GetBashCommand => "(sleep 30) #"`) so the spawned
  bash stays alive long enough to hit `Pause()`'s `Playing && !Paused && _process != null` body
  (189-193). Verified `Paused` flips to true, then `Stop()` cleans up the process. A companion
  Resume test was removed because it hangs (see below).
- `UnixPlayerBaseGetAudioDurationCoverageTests.cs` — `PlayLoop_WithLoopTrue_AndRealWavFile_ExecutesGetAudioDuration`:
  writes a byte-exact valid WAV (blockAlign written as `short`, matching the WAV spec) and calls
  `PlayLoop(.., loop: true)`, driving `GetAudioDuration` → `/usr/bin/afinfo` → the
  `estimated duration` parse branch (276-280) and the background loop `Task.Delay` (179). The
  previous worker's WAV was malformed (blockAlign written as `int`), so `afinfo` returned
  `AudioFileOpenURL failed` and the parse branch was never reached. On this machine the parse
  succeeds under `es-ES` (`double.TryParse("1,000000")` → 1.0).

## Remaining uncovered lines — BLOCKED_BY_PRODUCTION_CODE

- 204-208 — `Resume()` with a live process: requires `Playing && Paused` with a still-running
  `_process`. `Pause()` stops the process with `kill -STOP`; once the process is in the stopped
  (T) state, `Process.Start()` for the following `kill -CONT` command hangs at ~100% CPU and the
  STOPped child is never resumed (verified with a standalone .NET repro: resume's
  `StartBashProcess`/`WaitForExit` blocks; the `kill -CONT` bash never spawns). Requires the
  real STOP/CONT subprocess dance → BLOCKED_BY_PRODUCTION_CODE.
- 282 — closing brace of the `if (line != null)` block: cobertura artifact, unreachable because
  `return seconds` at 280 exits the method.

## Verification

- Targeted run (UnixPlayerBase filter): 56 passed / 17 skipped / 0 failed (net8.0), 1 s.
- Local coverlet: 156/168 = 92.85% line (was 136/168 = 80.95%).