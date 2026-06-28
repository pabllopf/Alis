# Coverage Task: AudioVideoWriter.cs

## File
`1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs`

## Coverage
- **Overall**: 54.0%
- **Uncovered Lines**: pending

## Methods Requiring Tests
1. `Dispose(bool disposing)` - Protected dispose method with resource cleanup branches
2. `CloseWrite()` - Closes output with try/finally blocks, socket cleanup
3. `WriteFrame(AudioFrame frame)` - Writes audio data to stream
4. `WriteFrame(VideoFrame frame)` - Writes video data to stream
5. `OpenWrite(bool, int)` - Complex method with socket operations (skipped - requires ffmpeg)

## Existing Tests
- Constructor validation tests (zero/negative dimensions, invalid framerate, etc.)
- Property getter tests (VideoWidth, VideoHeight, AudioChannels, etc.)
- OpenState validation tests
- Dispose pattern tests (basic)

## New Tests Generated
1. AudioVideoWriterCoverageTest.Dispose_ShouldCallDisposeTrueAndSuppressFinalize
2. AudioVideoWriterCoverageTest.Dispose_WithDisposingFalse_ShouldNotReleaseResources
3. AudioVideoWriterCoverageTest.Dispose_WithDisposingTrue_ShouldReleaseDestinationStream
4. AudioVideoWriterCoverageTest.Dispose_WithDisposingTrue_ShouldDisposeCsc
5. AudioVideoWriterCoverageTest.OpenWrite_AlreadyOpened_ShouldThrowInvalidOperationException
6. AudioVideoWriterCoverageTest.CloseWrite_WhenNotOpened_ShouldThrowInvalidOperationException
7. AudioVideoWriterCoverageTest.CloseWrite_FinallyBlock_ShouldSetOpenedForWritingToFalse
8. AudioVideoWriterCoverageTest.CloseWrite_WhenNotOpened_ShouldThrowBeforeTryBlock
9. AudioVideoWriterCoverageTest.CloseWrite_WithNullFfmpegp_ShouldThrowBeforeProcessCheck
10. AudioVideoWriterCoverageTest.WriteFrame_Audio_WhenNotOpened_ShouldThrowInvalidOperationException
11. AudioVideoWriterCoverageTest.WriteFrame_Video_WhenNotOpened_ShouldThrowInvalidOperationException
12. AudioVideoWriterCoverageTest.WriteFrame_Audio_ShouldExtractRawData
13. AudioVideoWriterCoverageTest.WriteFrame_Video_ShouldExtractRawData
14. AudioVideoWriterCoverageTest.Ffmpeg_Field_ShouldBeAccessibleViaReflection
15. AudioVideoWriterCoverageTest.Socket_Field_ShouldBeNullInitially
16. AudioVideoWriterCoverageTest.ConnectedSocket_Field_ShouldBeNullInitially
17. AudioVideoWriterCoverageTest.Csc_Field_ShouldBeNullInitially
18. AudioVideoWriterCoverageTest.InputDataStreamVideo_Property_ShouldBeNullInitially
19. AudioVideoWriterCoverageTest.InputDataStreamAudio_Property_ShouldBeNullInitially
20. AudioVideoWriterCoverageTest.OutputDataStream_Property_ShouldBeNullInitially
21. AudioVideoWriterCoverageTest.StreamConstructor_ShouldSetDestinationStream
22. AudioVideoWriterCoverageTest.StreamMode_ShouldSetUseFilenameToFalse
23. AudioVideoWriterCoverageTest.FilenameMode_ShouldSetDestinationStreamToNull
24. AudioVideoWriterCoverageTest.AudioEncoderOptions_EncoderName_ShouldBeAccessible
25. AudioVideoWriterCoverageTest.AudioEncoderOptions_EncoderArguments_ShouldBeAccessible
26. AudioVideoWriterCoverageTest.VideoEncoderOptions_EncoderName_ShouldBeAccessible
27. AudioVideoWriterCoverageTest.VideoEncoderOptions_Format_ShouldBeAccessible
28. AudioVideoWriterCoverageTest.Constructor_WithBitDepth16_ShouldSucceed
29. AudioVideoWriterCoverageTest.Constructor_WithBitDepth24_ShouldSucceed
30. AudioVideoWriterCoverageTest.Constructor_WithBitDepth32_ShouldSucceed
31. AudioVideoWriterCoverageTest.CurrentFFmpegProcess_ShouldReturnFfmpegp

## Status
**COMPLETED** - 31/31 tests passed successfully

## Target Framework
- net8.0

## Dependencies
- No Moq required - uses real objects and reflection
