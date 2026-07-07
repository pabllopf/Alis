# Coverage Task: AudioPlayer.cs

## Metadata

- **Task ID**: task-audioplayer-001
- **File**: `./1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioPlayer.cs`
- **Project Key**: pabllopf-official_alis
- **Priority**: 8 (19 uncovered lines, 76.2% branch coverage)
- **Created**: 2026-07-07T13:30
- **Status**: COMPLETED (Documented limitations)

## Coverage Data

| Metric | Value |
|--------|-------|
| File Coverage | 79.3% |
| Uncovered Lines | 19 |
| Branch Coverage | 76.2% |

## Existing Tests

- AudioPlayerTest.cs (Audio) (18 tests)
- AudioPlayerTest.cs (root) (22 tests)
- AudioPlayerWindowTest.cs (9 tests)
- **Total: 49 tests**

## Intentionally Untestable Methods (FFplay Dependencies)

The following methods require FFplay binary and cannot be tested in unit tests:

1. **Play()** - Requires FFplay binary and audio file
2. **PlayInBackground()** - Requires FFplay binary and audio file
3. **OpenWrite()** - Requires FFplay binary
4. **CloseWrite()** - Requires opened FFplay process
5. **GetStreamForWriting()** - Requires FFplay binary

## Test Strategy

**Documented limitations** rather than creating untestable tests. The 19 uncovered lines are exclusively in FFplay-dependent code paths.

## Expected Coverage Improvement

- Estimated: 0% (cannot improve unit test coverage)
- Recommendation: Mark as "intentionally untestable in unit tests"
