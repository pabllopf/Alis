# Result: AudioVideoWriter.cs

File: `1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 98.3% (176/179 lines, local coverlet; unchanged)
TestsAdded: 0 (3-line swallow catch in CloseWrite is unreachable deterministically)
Commit: test: coverage AudioVideoWriter.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

AudioVideoWriter.cs (67 complexity / 221 LOC per SonarCloud) is already covered at 98.3%
(176/179 lines) by the committed suite: `AudioVideoWriterTest.cs` (root),
`test/Video/AudioVideoWriterTest.cs`, `AudioVideoWriterCoverageTest.cs`,
`AudioVideoWriterFullCoverageTest.cs`, `AudioVideoWriterOpenWriteCoverageTests.cs` (fake
ffmpeg script that connects to the writer's TCP socket, full OpenWrite + CloseWrite with a
live `sleep 30` process, killing it), `AudioVideoWriterRemainingCoverageTests.cs` and
`AudioVideoWriterWriteFrameCoverageTest.cs`. All 124 tests in the AudioVideoWriter filter
pass on net8.0 Debug with real ffmpeg installed.

## Remaining uncovered lines (3) — BLOCKED_BY_PRODUCTION_CODE

Lines 379-382 (the empty `catch { /* Swallow exception */ }` inside CloseWrite) are the only
uncovered lines. They require `Ffmpegp.HasExited` or `Ffmpegp.Kill()` to throw while
`Ffmpegp.WaitForExit(5000)` returned false (live process, line 370):

- A live process: `HasExited` is false and `Kill()` succeeds (SIGKILL) — no exception, the
  existing OpenWrite/CloseWrite fake-ffmpeg tests already cover this whole path.
- A disposed/closed process: `WaitForExit(5000)` itself throws `InvalidOperationException`,
  which propagates out of CloseWrite before the try/catch is entered.
- The only remaining trigger is a non-deterministic race (process exits between the
  WaitForExit return and the Kill call), which violates the no-race, no-flake testing rules.

Deterministic coverage requires a production refactor (e.g., injectable/overridable process
kill strategy), which is out of scope. Same unreachable-catch defect family as
AudioWriter.cs and VideoWriter.cs CloseWrite.

## Verification

- AudioVideoWriter filter (net8.0, Debug): 124 passed, 0 failed, 0 skipped.
- Local coverlet: AudioVideoWriter.cs 176/179 lines (98.3%); only lines 379-382 uncovered.
