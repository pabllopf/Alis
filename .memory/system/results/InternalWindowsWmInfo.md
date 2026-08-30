# Result: InternalWindowsWmInfo.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/InternalWindowsWmInfo.cs`
CoverageBefore: 0.0% (SonarCloud; 3 uncovered lines)
CoverageAfter: 100.0% (3/3 instrumented lines, local coverlet, InternalWindowsWmInfo-filtered run)
TestsAdded: 3 (InternalWindowsWmInfoCoverageTests.cs, plain [Fact])
Commit: test: coverage InternalWindowsWmInfo.cs
Status: REMEDIATED

## Summary

InternalWindowsWmInfo.cs is a plain sequential-layout struct with 3 `IntPtr` auto-properties
(`Window`, `Hdc`, `HInstance`), no logic.

Committed `InternalWindowsWmInfoTest.cs` (2 tests) uses `[RequireSdl2ImageFact]`, which
skips when `libsdl2_image` cannot be resolved (CI/SonarCloud run), hence 0.0%.

Added `InternalWindowsWmInfoCoverageTests.cs` (3 plain `[Fact]`): default values,
set/store round trip, and value-type copy independence.

## Verification

- InternalWindowsWmInfoCoverageTests-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: InternalWindowsWmInfo.cs 100.0% (3/3 instrumented lines, line-rate 1.0).