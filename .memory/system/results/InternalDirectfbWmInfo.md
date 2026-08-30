# Result: InternalDirectfbWmInfo.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/InternalDirectfbWmInfo.cs`
CoverageBefore: 0.0% (SonarCloud; 3 uncovered lines)
CoverageAfter: 100.0% (3/3 instrumented lines, local coverlet, InternalDirectfbWmInfo-filtered run)
TestsAdded: 3 (InternalDirectfbWmInfoCoverageTests.cs, plain [Fact])
Commit: test: coverage InternalDirectfbWmInfo.cs
Status: REMEDIATED

## Summary

InternalDirectfbWmInfo.cs is a plain sequential-layout struct with 3 `IntPtr` auto-properties
(`Dfb`, `Window`, `Surface`), no logic.

Committed `InternalDirectfbWmInfoTest.cs` (2 tests) uses `[RequireSdl2ImageFact]`, which
skips when `libsdl2_image` cannot be resolved (CI/SonarCloud run), hence 0.0%.

Added `InternalDirectfbWmInfoCoverageTests.cs` (3 plain `[Fact]`): default values,
set/store round trip, and value-type copy independence.

## Verification

- InternalDirectfbWmInfoCoverageTests-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: InternalDirectfbWmInfo.cs 100.0% (3/3 instrumented lines, line-rate 1.0).