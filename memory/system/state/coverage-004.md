# coverage-004 — AudioWriter.cs (remaining uncovered lines)

## State
Completed

## Commit
02b7c0b4b

## Timestamp
2026-07-09T16:20:00-03:00

## File
`1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioWriter.cs`
`1_Presentation/Extension/Media/FFmpeg/test/Audio/AudioWriterCoverageTest.cs`

## Methods Covered
- `OpenWrite()` body in filename mode (command building, File.Exists/File.Delete before FfMpegWrapper throws)
- `OpenWrite()` body in stream mode (command building, csc creation before FfMpegWrapper throws)

## Estimated Improvement
~5% (OpenWrite partial body coverage)

## Notes
- Used fake executable `"ffmpeg-not-installed"` to guarantee FfMpegWrapper throws without requiring ffmpeg to be absent from the test machine
- Cannot fully cover OpenWrite success path (needs ffmpeg installed) or CloseWrite Kill path (defensive, unreachable after WaitForExit)
- Coverage: 57.8% → 63.4% after previous tests; these OpenWrite tests will further improve
