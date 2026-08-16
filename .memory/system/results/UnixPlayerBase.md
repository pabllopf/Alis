# Result: UnixPlayerBase.cs

File: `4_Operation/Audio/src/Players/UnixPlayerBase.cs`
CoverageBefore: 88.3% (SonarCloud); local coverlet baseline 76.2% line (64/84)
CoverageAfter: 86.9% line (73/84, local coverlet, net8.0)
TestsAdded: 4 (UnixPlayerBaseRemainingCoverageTests.cs)
Commit: test: coverage UnixPlayerBase.cs
Status: PARTIALLY_REMEDIATED

## Summary

UnixPlayerBase.cs (332 LOC, abstract bash-driven audio player base). The remaining uncovered
lines were the playback-finished handler, the audio-duration guard and the afinfo parsing.

## Work performed

Added 4 tests to `UnixPlayerBaseRemainingCoverageTests.cs` (xUnit, net8.0), reusing the
established `TestPlayerForCoverage` subclass pattern (`GetBashCommand => "true"`, temp files):
- `HandlePlaybackFinished_WithPlayingTrue_InvokesEvent` — Play then invoke the exposed handler;
  covers the Playing branch and event invocation (325-330).
- `HandlePlaybackFinished_WhenNotPlaying_DoesNotInvokeEvent` — double invocation; second call
  no-ops (326, 331).
- `PlayLoop_WithRealWavFile_ParsesDuration` — PlayLoop with a valid WAV temp file; covers the
  PlayLoop→GetAudioDuration→afinfo path.
- `GetAudioDuration_WithMissingFile_ThrowsFileNotFoundException` — reflection-invoked private
  GetAudioDuration on a missing file; covers the FileNotFoundException guard (255-256).

## Remaining uncovered lines — BLOCKED_BY_PRODUCTION_CODE

- 204-208 — Resume with a live process: requires Playing && Paused with a still-running
  `_process`. The `sleep 5; true` probe kept the process alive but Pause's `kill -STOP` left
  the test host blocked on the redirected process pipe (verified via hang dump:
  `ReadBytesFromProcessPipe`); the candidate test was removed to avoid a flaky hang.
- 276-282 — afinfo "estimated duration" parsing: depends on the host `afinfo` output format;
  on this machine the duration line does not match the parser (returns the 1.0 default).
- 206-207 — `Paused = false` after the resume command: same live-process blocker as above.

## Verification

- Targeted run: 4 passed / 0 failed (net8.0).
- Merged suite: 55 passed / 17 skipped / 0 failed (net8.0, UnixPlayerBase filter).
- Local coverlet: 73/84 = 86.9% line (was 76.2%).
