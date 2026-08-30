# Result: InternalOs2WmInfo.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/InternalOs2WmInfo.cs`
CoverageBefore: 0.0% (SonarCloud; 2 uncovered lines)
CoverageAfter: 100.0% (4/4, local coverlet, InternalOs2WmInfo-filtered run)
TestsAdded: 3 (InternalOs2WmInfoCoverageTests.cs, plain [Fact])
Commit: test: coverage InternalOs2WmInfo.cs
Status: REMEDIATED

## Summary

InternalOs2WmInfo.cs is a sequential-layout struct with 2 `IntPtr` auto-properties
(`Hwnd`, `HwndFrame`). Only the property getter/setter lines are instrumented.

Committed `InternalOs2WmInfoTest.cs` (3 tests) already covered the type but all use
`[RequireSdl2ImageFact]`, which skips when `libsdl2_image` cannot be resolved
(CI/SonarCloud run), hence 0.0%.

Added `InternalOs2WmInfoCoverageTests.cs` (3 plain `[Fact]`): default (zeroed) field
values, set/store round trip on the auto-properties, and value-type copy independence.

## Verification

- InternalOs2WmInfo-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: InternalOs2WmInfo.cs 100.0% (4/4 instrumented lines,
  line-rate 1.0, branch-rate 1.0).