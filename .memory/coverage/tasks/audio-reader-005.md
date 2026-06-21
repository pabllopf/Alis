# Coverage Task: AudioReader

## File
1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioReader.cs

## SonarCloud Key
pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioReader.cs

## Coverage
30.2%

## Status
ALREADY COVERED - Not processed

## Reason
- 28 existing tests cover constructor, Load validation, Dispose, NextFrame state checks, ResolveBitDepth
- Remaining uncovered methods (LoadMetadata, Load, NextFrame) depend on external FFmpeg/ffprobe execution
- Cannot be tested without mocking FfMpegWrapper or using integration tests

## Existing Tests
AudioReaderTest.cs - 28 tests covering:
- Constructor validation (file missing, valid file, custom executables)
- Load validation (invalid bit depth, metadata not loaded, bit depth 0/negative/64)
- Dispose (single, multiple)
- NextFrame state checks
- Property state (CurrentSampleOffset, MetadataLoaded, Metadata, Filename)
- ResolveBitDepth (all bit depths, unknown format, null/empty format)

## Recommendation
Not actionable without extracting FFmpeg-dependent logic into testable interfaces.
