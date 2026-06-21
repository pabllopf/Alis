# Coverage Task: AudioVideoWriter

## File
1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs

## SonarCloud Key
pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs

## Coverage
51.2%

## Status
ALREADY COVERED - Not processed

## Reason
- 30 existing tests cover constructor validation, property setting, Dispose, CloseWrite/WriteFrame state checks
- Remaining uncovered methods (OpenWrite, CloseWrite with actual data, WriteFrame with real frames) depend on external FFmpeg process
- Cannot be tested without mocking FfMpegWrapper or using integration tests

## Existing Tests
AudioVideoWriterTest.cs - 30 tests covering:
- Constructor validation (zero/negative dimensions, zero/negative framerate, empty/null filename, zero channels/sample rate, invalid bit depths)
- Constructor property setting (filename and stream constructors, different resolutions, 4K)
- Dispose (single, multiple)
- CloseWrite validation (not opened)
- WriteFrame validation (not opened for audio/video)
- Property state (CurrentFFmpegProcess, DestinationStream, InputDataStreamVideo, OutputDataStream, OpenedForWriting)

## Recommendation
Not actionable without extracting FFmpeg-dependent logic into testable interfaces.
