# Result: Version.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/Version.cs`
CoverageBefore: 0.0% (SonarCloud; 5 uncovered lines)
CoverageAfter: 100.0% (10/10 instrumented lines, local coverlet, Version-filtered run)
TestsAdded: 5 (VersionCoverageTests.cs, plain [Fact])
Commit: test: coverage Version.cs
Status: REMEDIATED

## Summary

Version.cs declares the `[StructLayout(LayoutKind.Explicit)]` `Version` struct with 3
public byte fields (`major`, `minor`, `patch`) at sequential field offsets plus a 3-int
constructor casting to byte, no logic.

Committed `VersionTest.cs` (3 tests) already covered the constructor, default zero and byte
truncation but all use `[RequireSdl2ImageFact]`, which skips when `libsdl2_image` cannot be
resolved (CI/SonarCloud run), hence 0.0%.

Added `VersionCoverageTests.cs` with plain `[Fact]` tests: constructor assignment, default
zero values, byte truncation, direct field round trip, and value-type copy independence.

## Verification

- VersionCoverageTests-filtered run: 5 passed / 0 failed, 0 skipped (net8.0).
- Local coverlet: Version.cs 100.0% (10/10 instrumented lines, line-rate 1.0, branch-rate 1.0).