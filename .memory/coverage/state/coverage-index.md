# Coverage Index — Session 2026-06-19

**Project:** pabllopf-official_alis
**Branch:** master
**Overall Coverage:** 47.9% line, 49.9% branch
**Total Uncovered Lines:** 33,309
**Files with Gaps:** 26

## Processed Targets

| File | Coverage | Lines | Status | Tests Written |
|------|----------|-------|--------|---------------|
| AudioPlayerWindow.cs | 0.0% | 35 | Tests written, compile OK, infrastructure blocked | AudioPlayerWindowTest.cs (8 tests) |
| BayazitDecomposer.cs | 11.1% | 152 | Tests written, compile OK, infrastructure blocked | BayazitDecomposerTest.cs (22 tests) |

## Remaining Priority Targets (0% coverage)

| # | File | Lines Uncovered | Notes |
|---|------|-----------------|-------|
| 1 | 1_Presentation/Engine/src/Windows/AssetsWindow.cs | 382 | Heavy ImGui, SKIPPED (low ROI) |
| 2 | 6_Ideation/Fluent/generator/AotReflectionAnalyzer.cs | 131 | Source generator, CHECK TESTABILITY |
| 3 | ~~AudioPlayerWindow.cs~~ | 35 | DONE - tests written |

## Secondary Targets (<50% coverage)

| File | Coverage | Lines Uncovered | Status |
|------|----------|-----------------|--------|
| ~~BayazitDecomposer.cs~~ | 11.1% | 152 | DONE - tests written |
| AudioReader.cs | 17.9% | 97 | NEXT — FFmpeg extension |
| AudioPlayer.cs | 31.4% | 65 | FFmpeg extension |
| Animator.cs | 41.3% | 41 | Core ECS |
| AudioVideoWriter.cs | 45.2% | 99 | FFmpeg extension |
| AudioWriter.cs | 47.2% | 60 | FFmpeg extension |
| AudioManager.cs | 50.0% | 3 | Core ECS |

## Infrastructure Note

Tests CANNOT execute in this environment due to:
- No network access to NuGet.org
- Custom output directories in test projects
- Moq dependency brings Castle.Core which test host needs

Tests WILL work when:
- Network access is available
- OR NuGet packages are pre-cached
- OR Moq dependency is removed from test projects

## Last Updated
2026-06-19T17:05:00Z
