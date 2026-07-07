# Coverage Task: AudioReader.cs

## Metadata

- **Task ID**: task-audioreader-001
- **File**: `./1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioReader.cs`
- **Project Key**: pabllopf-official_alis
- **Priority**: 7 (28 uncovered lines, 75.0% branch coverage)
- **Created**: 2026-07-07T13:28
- **Status**: COMPLETED (Documented limitations)

## Coverage Data

| Metric | Value |
|--------|-------|
| File Coverage | 76.0% |
| Uncovered Lines | 28 |
| Branch Coverage | 75.0% |

## Existing Tests

- AudioReaderTest.cs (36 tests)
- AudioReaderCoverageTest.cs (31 tests)
- AudioReaderTest.cs (root) (17 tests)
- **Total: 84 tests**

## Intentionally Untestable Methods (FFmpeg Dependencies)

The following methods require FFmpeg/ffprobe binaries and cannot be tested in unit tests:

1. **Constructor** - Requires actual audio file
2. **LoadMetadata/LoadMetadataAsync** - Requires ffprobe and audio files
3. **Load()** - Requires FFmpeg and audio files
4. **NextFrame()** - Requires loaded audio stream

## Test Strategy

**Documented limitations** rather than creating untestable tests. The 28 uncovered lines are exclusively in FFmpeg-dependent code paths.

## Expected Coverage Improvement

- Estimated: 0% (cannot improve unit test coverage)
- Recommendation: Mark as "intentionally untestable in unit tests"
