# Coverage Task: AudioReader.cs

## File
`1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioReader.cs`

## Coverage
- **Overall**: 56.3%
- **Uncovered Lines**: pending

## Methods Requiring Tests
1. `LoadMetadataAsync(bool)` - Async metadata loading with stream parsing
2. `Load(int bitDepth)` - Load audio for reading with bit depth validation
3. `NextFrame()` / `NextFrame(int)` / `NextFrame(AudioFrame)` - Frame reading methods

## Existing Tests
- Constructor validation tests (non-existent file, zero/negative channels, invalid bit depth, etc.)
- Property getter tests (CurrentSampleOffset, MetadataLoaded, Metadata, Channels, SampleRate, BitDepth)
- Dispose pattern tests (basic)
- ResolveBitDepth tests (8, 16, 24, 32, 64-bit formats)

## New Tests Generated
1. AudioReaderCoverageTest.Dispose_ShouldCallDisposeTrueAndSuppressFinalize
2. AudioReaderCoverageTest.Dispose_WithDisposingFalse_ShouldNotReleaseResources
3. AudioReaderCoverageTest.Dispose_WithDisposingTrue_ShouldReleaseDataStream
4. AudioReaderCoverageTest.ResolveBitDepth_ShouldSet8BitFor8BitFormat
5. AudioReaderCoverageTest.ResolveBitDepth_ShouldSet16BitFor16BitFormat
6. AudioReaderCoverageTest.ResolveBitDepth_ShouldSet24BitFor24BitFormat
7. AudioReaderCoverageTest.ResolveBitDepth_ShouldSet32BitFor32BitFormat
8. AudioReaderCoverageTest.ResolveBitDepth_ShouldSet64BitFor64BitFormat
9. AudioReaderCoverageTest.ResolveBitDepth_ShouldHandleUnknownFormats
10. AudioReaderCoverageTest.ResolveBitDepth_ShouldNotModifyAlreadySetBitDepth
11. AudioReaderCoverageTest.ResolveBitDepth_ShouldHandleNullSampleFormat
12. AudioReaderCoverageTest.ResolveBitDepth_ShouldHandleEmptySampleFormat
13. AudioReaderCoverageTest.LoadMetadataAsync_WhenAlreadyLoaded_ShouldThrowInvalidOperationException
14. AudioReaderCoverageTest.LoadMetadataAsync_WithIgnoreStreamErrors_ShouldCatchStreamErrors
15. AudioReaderCoverageTest.Load_WhenMetadataNotLoaded_ShouldThrowInvalidOperationException
16. AudioReaderCoverageTest.Load_WithBitDepth24_ShouldThrowWhenMetadataNotLoaded
17. AudioReaderCoverageTest.Load_WithBitDepth32_ShouldThrowWhenMetadataNotLoaded
18. AudioReaderCoverageTest.Load_WhenAlreadyLoaded_ShouldThrowInvalidOperationException
19. AudioReaderCoverageTest.NextFrame_WithoutLoadingAudio_ShouldThrowInvalidOperationException
20. AudioReaderCoverageTest.NextFrame_Int_WithoutLoadingAudio_ShouldThrowInvalidOperationException
21. AudioReaderCoverageTest.NextFrame_Frame_WhenNotOpened_ShouldThrowInvalidOperationException
22. AudioReaderCoverageTest.Ffmpeg_Field_ShouldBeAccessibleViaReflection
23. AudioReaderCoverageTest.Ffprobe_Field_ShouldBeAccessibleViaReflection
24. AudioReaderCoverageTest.LoadedBitDepth_Field_ShouldDefaultTo16
25. AudioReaderCoverageTest.DataStream_Property_ShouldBeNullInitially
26. AudioReaderCoverageTest.OpenedForReading_Property_ShouldBeFalseInitially
27. AudioReaderCoverageTest.CurrentSampleOffset_Property_ShouldDefaultTo0
28. AudioReaderCoverageTest.MetadataLoaded_Property_ShouldDefaultToFalse
29. AudioReaderCoverageTest.Metadata_Property_ShouldBeNullInitially
30. AudioReaderCoverageTest.LoadMetadata_ShouldCallLoadMetadataAsync

## Status
**COMPLETED** - 31/31 tests passed successfully

## Target Framework
- net8.0

## Dependencies
- No Moq required - uses real objects and reflection
- Tests handle ffmpeg/ffprobe not being installed gracefully
