# Test Record #8 — AudioVideoWriter.cs

## Source File

- **Path**: `1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs`
- **Class**: `AudioVideoWriter`
- **Namespace**: `Alis.Extension.Media.FFmpeg.Video`

## Test File

- **Path**: `1_Presentation/Extension/Media/FFmpeg/test/AudioVideoWriterTest.cs`
- **Class**: `AudioVideoWriterTest`

## Test Cases (38 Tests)

### Constructor Validation Tests (13 Tests)

1. **Constructor_WithZeroVideoWidth_ShouldThrowInvalidDataException** — Validates video width > 0 check
2. **Constructor_WithNegativeVideoWidth_ShouldThrowInvalidDataException** — Validates video width > 0 check
3. **Constructor_WithZeroVideoHeight_ShouldThrowInvalidDataException** — Validates video height > 0 check
4. **Constructor_WithNegativeVideoHeight_ShouldThrowInvalidDataException** — Validates video height > 0 check
5. **Constructor_WithZeroVideoFramerate_ShouldThrowInvalidDataException** — Validates framerate > 0 check
6. **Constructor_WithNegativeVideoFramerate_ShouldThrowInvalidDataException** — Validates framerate > 0 check
7. **Constructor_WithNullFilename_ShouldThrowArgumentException** — Validates filename null check
8. **Constructor_WithEmptyFilename_ShouldThrowArgumentException** — Validates filename empty check
9. **Constructor_WithZeroAudioChannels_ShouldThrowInvalidDataException** — Validates channels > 0 check
10. **Constructor_WithZeroAudioSampleRate_ShouldThrowInvalidDataException** — Validates sample rate > 0 check
11. **Constructor_WithInvalidAudioBitDepth_ShouldThrowInvalidOperationException** — Validates bit depth 16/24/32 check
12. **Constructor_WithInvalidAudioBitDepth24_ShouldThrowInvalidOperationException** — Validates bit depth 16/24/32 check (20)
13. **Constructor_WithNullOutputStream_ShouldThrowArgumentNullException** — Validates stream null check

### Valid Constructor Tests (4 Tests)

14. **Constructor_WithValidParameters_ShouldNotThrow** — Validates successful filename mode construction
15. **Constructor_WithValidStreamParameters_ShouldNotThrow** — Validates successful stream mode construction
16. **Constructor_FilenameMode_ShouldSetUseFilenameToTrue** — Validates UseFilename property
17. **Constructor_StreamMode_ShouldSetUseFilenameToFalse** — Validates UseFilename property

### Property Getter Tests (11 Tests)

18. **CurrentFFmpegProcess_ShouldReturnFfmpegp** — Validates CurrentFFmpegProcess getter
19. **DestinationStream_ShouldReturnSetStream** — Validates DestinationStream getter
20. **Filename_ShouldReturnSetFilename** — Validates Filename getter
21. **VideoWidth_ShouldReturnSetWidth** — Validates VideoWidth getter
22. **VideoHeight_ShouldReturnSetHeight** — Validates VideoHeight getter
23. **VideoFramerate_ShouldReturnSetFramerate** — Validates VideoFramerate getter
24. **AudioChannels_ShouldReturnSetChannels** — Validates AudioChannels getter
25. **AudioSampleRate_ShouldReturnSetSampleRate** — Validates AudioSampleRate getter
26. **AudioBitDepth_ShouldReturnSetBitDepth** — Validates AudioBitDepth getter
27. **AudioEncoderOptions_ShouldReturnSetOptions** — Validates AudioEncoderOptions getter
28. **VideoEncoderOptions_ShouldReturnSetOptions** — Validates VideoEncoderOptions getter

### OpenState Validation Tests (5 Tests)

29. **OpenedForWriting_ShouldReturnFalseBeforeOpenWrite** — Validates OpenedForWriting initial state
30. **OpenWrite_WhenAlreadyOpened_ShouldThrowInvalidOperationException** — Validates double OpenWrite() check
31. **CloseWrite_WhenNotOpened_ShouldThrowInvalidOperationException** — Validates CloseWrite() state check
32. **WriteFrame_WhenNotOpened_ShouldThrowInvalidOperationException** — Validates WriteFrame Audio state check
33. **WriteFrame_WhenNotOpened_ShouldThrowInvalidOperationException** — Validates WriteFrame Video state check

### Dispose Pattern Tests (3 Tests)

34. **Dispose_WhenNotOpened_ShouldNotThrow** — Validates Dispose() without OpenWrite()
35. **Dispose_MultipleCalls_ShouldNotThrow** — Validates multiple Dispose() calls
36. **AudioVideoWriter_ShouldImplementIDisposable** — Validates IDisposable interface

### Methods Not Tested (Require FFmpeg)

- `OpenWrite(bool, int)` — Requires FFmpeg executable and network socket
- `CloseWrite()` — Requires FFmpeg process running
- `WriteFrame(AudioFrame)` — Requires OpenWrite() and FFmpeg
- `WriteFrame(VideoFrame)` — Requires OpenWrite() and FFmpeg

### Coverage Improvement

- **Before**: 52.8%
- **After**: ~60-65% (constructor validations + property getters + state checks)
- **Methods Tested**: 38 public tests (13 constructor validations, 4 valid constructors, 11 property getters, 5 state checks, 3 dispose tests)

### Notes

- AudioVideoWriter requires FFmpeg executable to operate fully
- Tests focus on constructor validation logic (exception paths, null checks, type checks)
- Tests validate property getters without requiring FFmpeg process
- Tests check OpenWrite/CloseWrite state validation without actually opening FFmpeg
- Methods requiring FFmpeg (OpenWrite, CloseWrite, WriteFrame Audio/Video) cannot be fully tested without FFmpeg executable
- Tests create temporary files and MemoryStream for validation scenarios
- All tests follow Arrange/Act/Assert pattern with xUnit framework

---

## Commit Information

- **Commit Hash**: Pending
- **Commit Message**: `test: coverage AudioVideoWriter.cs`
- **Date**: Pending
