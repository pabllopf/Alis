# Result: InternalX11WmInfo.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/InternalX11WmInfo.cs`
CoverageBefore: 0.0% (SonarCloud; 2 uncovered lines)
CoverageAfter: 100.0% (4/4, local coverlet, InternalX11WmInfo-filtered run)
TestsAdded: 3 (InternalX11WmInfoCoverageTests.cs, plain [Fact])
Commit: test: coverage InternalX11WmInfo.cs
Status: REMEDIATED

## Summary

InternalX11WmInfo.cs is a sequential-layout struct with 2 `IntPtr` auto-properties
(`Display`, `Window`). Only the property getter/setter lines are instrumented.

Committed `InternalX11WmInfoTest.cs` already covered the type but uses
`[RequireSdl2ImageFact]`, which skips when `libsdl2_image` cannot be resolved
(CI/SonarCloud run), hence 0.0%.

Added `InternalX11WmInfoCoverageTests.cs` (3 plain `[Fact]`): default (zeroed) field
values, set/store round trip on the auto-properties, and value-type copy independence.

## Verification

- InternalX11WmInfo-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: InternalX11WmInfo.cs 100.0% (4/4 instrumented lines,
  line-rate 1.0, branch-rate 1.0).