# Result: ImgAnimation.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Sdl2Image/ImgAnimation.cs`
CoverageBefore: 0.0% (SonarCloud; 4 uncovered lines)
CoverageAfter: 100.0% (8/8 instrumented lines, local coverlet, ImgAnimation-filtered run)
TestsAdded: 3 (ImgAnimationCoverageTests.cs, plain [Fact])
Commit: test: coverage ImgAnimation.cs
Status: REMEDIATED

## Summary

ImgAnimation.cs is a plain struct with 4 auto-properties (`W`, `H`, `Frames`, `Delays`), no
logic.

Committed `ImgAnimationTest.cs` (1 test) used `[RequireSdl2ImageFact]`, which skips when
`libsdl2_image` cannot be resolved (CI/SonarCloud run), hence 0.0%.

Added `ImgAnimationCoverageTests.cs` with plain `[Fact]` tests: default values, set/store
round trip, and value-type copy independence.

## Verification

- ImgAnimationCoverageTests-filtered run: 3 passed / 0 failed, 0 skipped (net8.0).
- Local coverlet: ImgAnimation.cs 100.0% (8/8 instrumented lines, line-rate 1.0).