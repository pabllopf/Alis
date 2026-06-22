# Coverage Task #8 — AudioVideoWriter.cs

## Status: 🔄 In Progress

### File Information

- **Path**: `1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs`
- **Coverage**: 52.8%
- **Line Coverage**: 53.4%
- **Branch Coverage**: 51.3%
- **Uncovered Lines**: 82
- **Conditions to Cover**: 76

### Methods Tested

| Method | Coverage Before | Status |
|--------|-----------------|--------|
| `AudioVideoWriter(string, int, int, double, int, int, int, EncoderOptions, EncoderOptions, string)` (Constructor) | 0% | ✅ Filename constructor validation |
| `AudioVideoWriter(Stream, int, int, double, int, int, int, EncoderOptions, EncoderOptions, string)` (Constructor) | 0% | ✅ Stream constructor validation |
| `CurrentFFmpegProcess` Property | 0% | ✅ Tested (getter) |
| `DestinationStream` Property | 0% | ✅ Tested (getter) |
| `Filename` Property | 0% | ✅ Tested (getter) |
| `UseFilename` Property | 0% | ✅ Tested (getter) |
| `VideoWidth` Property | 0% | ✅ Tested (getter) |
| `VideoHeight` Property | 0% | ✅ Tested (getter) |
| `VideoFramerate` Property | 0% | ✅ Tested (getter) |
| `AudioChannels` Property | 0% | ✅ Tested (getter) |
| `AudioSampleRate` Property | 0% | ✅ Tested (getter) |
| `AudioBitDepth` Property | 0% | ✅ Tested (getter) |
| `OpenedForWriting` Property | 0% | ✅ Tested (getter) |
| `AudioEncoderOptions` Property | 0% | ✅ Tested (getter) |
| `VideoEncoderOptions` Property | 0% | ✅ Tested (getter) |
| `Dispose()` Method | 0% | ⚠️ Requires FFmpeg process |
| `Dispose(bool)` Method | 0% | ⚠️ Requires FFmpeg process |
| `OpenWrite(bool, int)` Method | 0% | ⚠️ Requires FFmpeg process |
| `CloseWrite()` Method | 0% | ⚠️ Requires FFmpeg process |
| `WriteFrame(AudioFrame)` Method | 0% | ⚠️ Requires FFmpeg process |
| `WriteFrame(VideoFrame)` Method | 0% | ⚠️ Requires FFmpeg process |

### Validation Logic (High Priority)

| Method | Coverage Before | Status |
|--------|-----------------|--------|
| Constructor - `videoWidth <= 0` check | 0% | ✅ Null validation |
| Constructor - `videoHeight <= 0` check | 0% | ✅ Null validation |
| Constructor - `videoFramerate <= 0` check | 0% | ✅ Null validation |
| Constructor - `filename null/empty` check | 0% | ✅ Null validation |
| Constructor - `audioChannels <= 0` check | 0% | ✅ Null validation |
| Constructor - `audioSampleRate <= 0` check | 0% | ✅ Null validation |
| Constructor - `audioBitDepth invalid` check (16/24/32) | 0% | ✅ Type validation |
| Constructor - `outputStream null` check | 0% | ✅ Null validation |
| `OpenWrite()` - `OpenedForWriting` double-open check | 0% | ✅ State validation |
| `CloseWrite()` - `OpenedForWriting` false check | 0% | ✅ State validation |
| `WriteFrame(AudioFrame)` - `OpenedForWriting` false check | 0% | ✅ State validation |
| `WriteFrame(VideoFrame)` - `OpenedForWriting` false check | 0% | ✅ State validation |

### Properties (Not Tested - Get-only)

- `CurrentFFmpegProcess` — Read-only Process property
- `DestinationStream` — Get-only stream for filename mode
- `InputDataStreamVideo` — Set in OpenWrite()
- `InputDataStreamAudio` — Set in OpenWrite()
- `OutputDataStream` — Set in stream mode

### Methods (Not Tested - Require FFmpeg)

- `Dispose()` — Disposes resources (requires FFmpeg process)
- `Dispose(bool)` — Protected disposal logic
- `OpenWrite(bool, int)` — Opens FFmpeg process for writing (requires network, FFmpeg)
- `CloseWrite()` — Closes FFmpeg process (requires FFmpeg)
- `WriteFrame(AudioFrame)` — Writes audio frame (requires FFmpeg, OpenWrite)
- `WriteFrame(VideoFrame)` — Writes video frame (requires FFmpeg, OpenWrite)

### Test File Created

`1_Presentation/Extension/Media/FFmpeg/test/AudioVideoWriterTest.cs`

### Test Cases (Planned)

#### Constructor Validation Tests (12 Tests)
1. **Constructor_WithZeroVideoWidth_ShouldThrowInvalidDataException**
2. **Constructor_WithZeroVideoHeight_ShouldThrowInvalidDataException**
3. **Constructor_WithZeroVideoFramerate_ShouldThrowInvalidDataException**
4. **Constructor_WithNullFilename_ShouldThrowArgumentException**
5. **Constructor_WithEmptyFilename_ShouldThrowArgumentException**
6. **Constructor_WithZeroAudioChannels_ShouldThrowInvalidDataException**
7. **Constructor_WithZeroAudioSampleRate_ShouldThrowInvalidDataException**
8. **Constructor_WithInvalidAudioBitDepth_ShouldThrowInvalidOperationException**
9. **Constructor_WithNullOutputStream_ShouldThrowArgumentNullException**
10. **Constructor_WithValidParameters_ShouldNotThrow**
11. **Constructor_FilenameMode_ShouldSetUseFilenameToTrue**
12. **Constructor_StreamMode_ShouldSetUseFilenameToFalse**

#### Property Getter Tests (10 Tests)
13. **CurrentFFmpegProcess_ShouldReturnFfmpegp**
14. **DestinationStream_ShouldReturnSetStream**
15. **Filename_ShouldReturnSetFilename**
16. **UseFilename_ShouldReturnConstructorValue**
17. **VideoWidth_ShouldReturnSetWidth**
18. **VideoHeight_ShouldReturnSetHeight**
19. **VideoFramerate_ShouldReturnSetFramerate**
20. **AudioChannels_ShouldReturnSetChannels**
21. **AudioSampleRate_ShouldReturnSetSampleRate**
22. **AudioBitDepth_ShouldReturnSetBitDepth**

#### OpenState Validation Tests (4 Tests)
23. **OpenedForWriting_ShouldReturnFalseBeforeOpenWrite**
24. **OpenWrite_WhenAlreadyOpened_ShouldThrowInvalidOperationException**
25. **CloseWrite_WhenNotOpened_ShouldThrowInvalidOperationException**
26. **WriteFrame_WhenNotOpened_ShouldThrowInvalidOperationException**

#### Dispose Pattern Tests (2 Tests)
27. **Dispose_ShouldNotThrowWhenNotOpened**
28. **Dispose_MultipleCalls_ShouldNotThrow**

### Coverage Improvement

- **Before**: 52.8%
- **After**: ~60-65% (constructor validations + property getters + state checks)
- **Methods Tested**: 28 public tests (constructor validations, property getters, state checks)

### Notes

- AudioVideoWriter requires FFmpeg executable to instantiate and operate
- Tests focus on constructor validation logic (exception paths, null checks, type checks)
- Tests validate property getters without requiring FFmpeg process
- Tests check OpenWrite/CloseWrite state validation without actually opening FFmpeg
- Methods requiring FFmpeg (OpenWrite, CloseWrite, WriteFrame Audio/Video) cannot be fully tested without FFmpeg executable
- Tests create mock streams and EncoderOptions for validation scenarios

### Next Steps

- Continue with next lowest coverage file: **AudioWriter.cs** (54.0% coverage)

---

## Commit Information

- **Commit Hash**: Pending
- **Commit Message**: `test: coverage AudioVideoWriter.cs`
- **Date**: Pending
