# Result: InternalAndroidWmInfo.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/InternalAndroidWminfo.cs`
CoverageBefore: 0.0% (SonarCloud; 2 uncovered lines)
CoverageAfter: 100.0% (4/4, local coverlet, InternalAndroidWmInfo-filtered run)
TestsAdded: 3 (InternalAndroidWmInfoCoverageTests.cs, plain [Fact])
Commit: test: coverage InternalAndroidWmInfo.cs
Status: REMEDIATED

## Summary

InternalAndroidWmInfo.cs is a sequential-layout struct with 2 `IntPtr` auto-properties
(`Window`, `Surface`). Only the property getter/setter lines are instrumented.

Committed `InternalAndroidWmInfoTest.cs` (3 tests) already covered the type but all use
`[RequireSdl2ImageFact]`, which skips when `libsdl2_image` cannot be resolved
(CI/SonarCloud run), hence 0.0%.

Added `InternalAndroidWmInfoCoverageTests.cs` (3 plain `[Fact]`): default (zeroed) field
values, set/store round trip on the auto-properties, and value-type copy independence.

## Verification

- InternalAndroidWmInfo-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: InternalAndroidWminfo.cs 100.0% (4/4 instrumented lines,
  line-rate 1.0, branch-rate 1.0).