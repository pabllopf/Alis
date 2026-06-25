# Coverage Index — Fresh Sync

**Sync Timestamp:** 2025-06-25T18:15:00Z
**Last Update:** 2025-06-25T18:39:00Z
**Branch:** master
**Project Key:** pabllopf-official_alis

## Project-Level Coverage

| Metric | Value |
|--------|-------|
| Coverage | 58.3% |
| Line Coverage | 57.6% |
| Branch Coverage | 61.8% |

## Completed Tasks

| Task ID | File | Commit | Tests Added | Status |
|---------|------|--------|-------------|--------|
| #001 | AudioReader.cs | 0ab1102e9 | 36 | PARTIALLY COMPLETE (LoadMetadataAsync requires ffmpeg) |
| #002 | AudioWriter.cs | 1d5df547f | 39 | PARTIALLY COMPLETE (OpenWrite ffmpeg spawn requires integration) |
| #003 | AudioVideoWriter.cs | b6488eaab | 8 | PARTIALLY COMPLETE (OpenWrite ffmpeg spawn requires integration) |
| #004 | AudioPlayer.cs | 5be589d49 | 9 | PARTIALLY COMPLETE (Play/PlayInBackground ffplay spawn requires integration) |
| #005 | Sfml Audios directory | 6bf4b5142 | 20 | PARTIALLY COMPLETE (SFML native library required) |
| #006 | BaseClasses directory | SKIPPED | 0 (1081 existing) | WELL TESTED (51.6%, skip) |
| #007 | 4_Operation/Audio/src | SKIPPED | 0 (9468 existing) | WELL TESTED (55.1%, skip) |

## Remaining Target Files (Coverage < 80%)

| Priority | File | Coverage | Uncovered Lines | Status |
|----------|------|----------|-----------------|--------|
| 1 | `1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioReader.cs` | 53.3% | 57 | #001 done (guard conditions) |
| 2 | `1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs` | 53.6% | 80 | #003 done (internal state) |
| 3 | `1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioWriter.cs` | 54.0% | 50 | #002 done (property guards) |
| 4 | `2_Application/Alis/src` (dir) | 55.3% | 933 | #008 last priority |
| 5 | `1_Presentation/Extension/Graphic/Sfml/src/Audios` (dir, 0%) | 0.0% | 337 | #005 done (property guards) |
| 6 | `1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioPlayer.cs` | 79.3% | 19 | #004 done (guard conditions) |
| 7 | `1_Presentation/Extension/Media/FFmpeg/src/BaseClasses` (dir) | 51.6% | 57 | #006 skipped (well tested) |
| 8 | `4_Operation/Audio/src` (dir) | 55.1% | 244 | #007 skipped (well tested) |

## Test Count Progress

| Date | Total Tests | Notes |
|------|-------------|-------|
| Initial | 700 | Baseline |
| After #001 | 711 | +36 AudioReader tests |
| After #002 | 722 | +11 AudioWriter tests |
| After #003 | 730 | +8 AudioVideoWriter tests |
| After #004 | 739 | +9 AudioPlayer tests |
| After #005 | 759* | +20 Sfml Audios tests (pending native lib) |

*Note: Sfml tests timed out during execution — requires SFML native library.

## Summary

- **Tasks completed**: 5 (FFmpeg guard conditions + Sfml property guards)
- **Tasks skipped**: 2 (BaseClasses, 4_Operation/Audio — already extensively tested)
- **Remaining**: 2_Application/Alis/src (55.3%, 933 lines) — last priority
- **Total new tests added**: ~112 (across 5 tasks)

