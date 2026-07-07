# Coverage Task: AudioVideoWriter.cs

## Metadata

- **Task ID**: task-audiovideowriter-001
- **File**: `./1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs`
- **Project Key**: pabllopf-official_alis
- **Priority**: 4 (75 uncovered lines, 53.9% branch coverage)
- **Created**: 2026-07-07T13:18
- **Status**: COMPLETED (Documented limitations)

## Coverage Data

| Metric | Value |
|--------|-------|
| File Coverage | 56.3% |
| Uncovered Lines | 75 |
| Branch Coverage | 53.9% |

## Existing Tests

- AudioVideoWriterTest.cs (30 tests, 702 lines)
- AudioVideoWriterCoverageTest.cs (31 tests, 759 lines)

## Intentionally Untestable Methods (FFmpeg Dependencies)

The following methods require FFmpeg binary and cannot be tested in unit tests:

1. **Constructor (filename)** - Initializes FFmpeg process with file output
2. **Constructor (stream)** - Initializes FFmpeg process with stream output
3. **WriteVideoFrame** - Encodes video frames via FFmpeg
4. **WriteAudioFrame** - Encodes audio frames via FFmpeg
5. **Dispose** - Cleans up FFmpeg process and sockets

## Test Strategy

**Documented limitations** rather than creating untestable tests. The 75 uncovered lines are exclusively in FFmpeg-dependent code paths that require:
- Actual FFmpeg binary installed
- Valid video/audio files for testing
- Network socket availability

## Expected Coverage Improvement

- Estimated: 0% (cannot improve unit test coverage)
- Recommendation: Mark as "intentionally untestable in unit tests"

## Commit Message

```
docs: AudioVideoWriter.cs intentionally untestable (FFmpeg dependencies)
```
