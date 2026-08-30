# Result: InternalMirWmInfo.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/InternalMirWmInfo.cs`
CoverageBefore: 0.0% (SonarCloud; 2 uncovered lines)
CoverageAfter: 100.0% (4/4, local coverlet, InternalMirWmInfo-filtered run)
TestsAdded: 3 (InternalMirWmInfoCoverageTests.cs, plain [Fact])
Commit: test: coverage InternalMirWmInfo.cs
Status: REMEDIATED

## Summary

InternalMirWmInfo.cs is a sequential-layout struct with 2 `IntPtr` auto-properties
(`Connection`, `Surface`). Only the property getter/setter lines are instrumented.

Committed `InternalMirWmInfoTest.cs` (3 tests) already covered the type but all use
`[RequireSdl2ImageFact]`, which skips when `libsdl2_image` cannot be resolved
(CI/SonarCloud run), hence 0.0%.

Added `InternalMirWmInfoCoverageTests.cs` (3 plain `[Fact]`): default (zeroed) field
values, set/store round trip on the auto-properties, and value-type copy independence.

## Verification

- InternalMirWmInfo-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: InternalMirWmInfo.cs 100.0% (4/4 instrumented lines,
  line-rate 1.0, branch-rate 1.0).