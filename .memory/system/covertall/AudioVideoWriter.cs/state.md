Target: 1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs
Project: 1_Presentation/Extension/Media/FFmpeg/src/Alis.Extension.Media.FFmpeg.csproj
Test project: 1_Presentation/Extension/Media/FFmpeg/test/Alis.Extension.Media.FFmpeg.Test.csproj
Agent: covertall-avw-001
Baseline commit: 5982b189c9da64ce81250a914856599fa93debca
Initial line coverage: 99.4% (176/177 sequence points)
Initial branch coverage: 100% (78/78)
Current line coverage: 100% (179/179 sequence points)
Current branch coverage: 100% (78/78)
Tests before: 1556
Tests after: 1557
Files modified:
  - 1_Presentation/Extension/Media/FFmpeg/test/Video/AudioVideoWriterCloseWriteCatchCoverageTests.cs (added)
Tests added:
  - CloseWrite_WhenProcessHandleDisposedDuringWait_ThrowsAfterSwallowingKillError
Commits:
  - test: cover swallow-catch path of CloseWrite in AudioVideoWriter.cs
Remaining uncovered lines: none
Remaining uncovered branches: none
Status: COMPLETED
Last update: 2026-08-16T20:20:00Z
