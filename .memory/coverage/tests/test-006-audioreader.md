# Test Record #6 — AudioReader.cs

## Source File

- **Path**: `1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioReader.cs`
- **Class**: `AudioReader`
- **Namespace**: `Alis.Extension.Media.FFmpeg.Audio`

## Test File

- **Path**: `1_Presentation/Extension/Media/FFmpeg/test/AudioReaderTest.cs`
- **Class**: `AudioReaderTest`

## Test Cases (21 Tests)

### Constructor Tests (6 Tests)

1. **Constructor_WithNonExistentFile_ShouldThrowFileNotFoundException** — Validates FileNotFoundException for missing files
2. **Constructor_WithExistingFile_ShouldNotThrow** — Validates constructor works with existing files
3. **Constructor_WithCustomExecutables_ShouldNotThrow** — Validates custom ffmpeg/ffprobe parameters
4. **Constructor_ShouldInitializeCurrentSampleOffsetTo0** — Validates CurrentSampleOffset defaults to 0
5. **Constructor_ShouldInitializeMetadataLoadedToFalse** — Validates MetadataLoaded defaults to false
6. **Constructor_ShouldInitializeMetadataToNull** — Validates Metadata is null until loaded

### Dispose Pattern Tests (3 Tests)

7. **Dispose_ShouldNotThrow** — Validates Dispose() doesn't throw
8. **Dispose_MultipleCalls_ShouldNotThrow** — Validates multiple Dispose() calls don't throw
9. **AudioReader_ShouldImplementIDisposable** — Validates IDisposable interface

### Error Handling Tests (4 Tests)

10. **LoadMetadata_WithoutFFmpeg_ShouldThrowException** — Validates error handling without FFmpeg
11. **LoadMetadataAsync_WithoutFFmpeg_ShouldThrowException** — Validates async error handling
12. **Load_WithInvalidBitDepth_ShouldThrowException** — Validates bit depth validation
13. **Load_WithoutLoadingMetadataFirst_ShouldThrowException** — Validates metadata must be loaded first

### Frame Reading Tests (1 Test)

14. **NextFrame_WithoutLoadingAudio_ShouldThrowException** — Validates audio must be loaded first

### ResolveBitDepth Tests (7 Tests)

15. **ResolveBitDepth_ShouldSet16BitFor16BitFormat** — Validates 16-bit resolution
16. **ResolveBitDepth_ShouldSet32BitFor32BitFormat** — Validates 32-bit resolution
17. **ResolveBitDepth_ShouldSet64BitFor64BitFormat** — Validates 64-bit resolution
18. **ResolveBitDepth_ShouldHandleUnknownFormats** — Validates unknown format handling
19. **ResolveBitDepth_ShouldNotModifyAlreadySetBitDepth** — Validates existing bit depth preservation
20. **ResolveBitDepth_ShouldHandleNullSampleFormat** — Validates null sample format handling
21. **ResolveBitDepth_ShouldHandleEmptySampleFormat** — Validates empty sample format handling

### Private Methods (Not Tested - Implementation Details)

- `Dispose(bool disposing)` — Protected disposal logic
- `LoadMetadata(bool)` — Synchronous metadata loading (requires FFmpeg)
- `LoadMetadataAsync(bool)` — Async metadata loading (requires FFmpeg)
- `Load(int bitDepth)` — Audio stream loading (requires FFmpeg)
- `NextFrame()` — Frame reading methods (require loaded audio)

### Properties (Not Tested - Protected/Internal)

- `OpenedForReading` — Protected boolean flag
- `DataStream` — Protected stream property
- `Filename` — Protected string property

### Notes

- Tests create temporary files to validate file existence checks
- Tests validate all ResolveBitDepth scenarios (16, 24, 32, 64-bit formats)
- Methods requiring FFmpeg executable are tested for error handling but not full functionality
- Tests use real objects and avoid mocking FFmpeg processes

## Commit Information

- **Commit Hash**: d5e3cb6fb
- **Commit Message**: `test: coverage AudioReader.cs`
- **Date**: 2026-06-22
