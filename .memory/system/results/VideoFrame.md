# Result: VideoFrame.cs

File: `1_Presentation/Extension/Media/FFmpeg/src/Video/VideoFrame.cs`
CoverageBefore: 78.3% (SonarCloud, stale — reflects pre-existing committed test state)
CoverageAfter: 100.0% (local coverlet, line-rate 1 / branch-rate 1)
TestsAdded: 0 (already fully covered by committed VideoFrameTest / VideoFrameCoverageTests / VideoFrameRemainingCoverageTests)
Commit: test: coverage VideoFrame.cs
Status: REMEDIATED (NO-OP — stale SonarCloud delta)

## Summary

VideoFrame.cs (RGB24 frame buffer, Load/Save/GetPixels/Dispose, 184 LOC) is already covered
100% by the committed test suite (VideoFrameTest.cs, VideoFrameCoverageTests.cs,
VideoFrameRemainingCoverageTests.cs — committed in `fix: all unit tests` /
`fix: unlesss tests`). SonarCloud's 78.3% / 16 uncovered lines reflects an older analysis of
the master branch; the local coverlet run against the current committed tests reports
line-rate 1.0 / branch-rate 1.0 with zero uncovered lines.

## Verification

- `dotnet test ... --filter FullyQualifiedName~VideoFrame` (net8.0): all pass.
- Local coverlet: VideoFrame.cs 100% line / 100% branch, uncovered set empty.
- No production changes required; no new tests needed.

## Re-issue verification (2026-09-07)

Re-measured on the macOS host with the committed suite:
`dotnet test 1_Presentation/Extension/Media/FFmpeg/test/Alis.Extension.Media.FFmpeg.Test.csproj -c Debug -f net8.0 --filter "FullyQualifiedName~VideoFrame" --collect:"XPlat Code Coverage"`

- Results: 77 passed / 0 skipped / 0 failed (120 ms).
- VideoFrame.cs class: line-rate 1.0, branch-rate 1.0, complexity 21 — zero `hits="0"` lines.
  Every member is exercised: ctor (incl. all 4 validation branches), Width/Height/RawData,
  Load (full/partial/chunked/empty paths incl. RawData resize), Save (png/bmp/extra params/
  existing-file delete/nonexistent-ffmpeg Win32Exception), GetPixels (0,0 / edge / length),
  Dispose (incl. `Dispose(bool)` both branches via the committed reflection test).
- Verified the RequireFfmpegFact attribute is not silently skipping: `avformat` native lib
  resolves on this host, so the Save process-piping paths execute for real (OpenInput hits=5,
  body/write hits=4 on 5 calls — the Win32Exception call throws inside OpenInput, line 157).
- No uncovered lines found → no new tests can add coverage. BLOCKED-free.

Status (this pass): ALREADY_COVERED / NO-OP — no tests added.
