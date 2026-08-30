# Result: DisplayMode.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/DisplayMode.cs`
CoverageBefore: 0.0% (SonarCloud; 1 uncovered lines)
CoverageAfter: 100.0% (2/2, local coverlet, DisplayMode-filtered run)
TestsAdded: 3 (DisplayModeCoverageTests.cs, plain [Fact])
Commit: test: coverage DisplayMode.cs
Status: REMEDIATED

## Summary

DisplayMode.cs is a sequential-layout struct with uint/int public fields (format, w, h,
refresh_rate) and an `IntPtr DriverData` auto-property. Only the property getter/setter lines
are instrumented.

Committed `DisplayModeTest.cs` already covered the type but all tests use
`[RequireSdl2ImageFact]`, which skips when `libsdl2_image` cannot be resolved
(CI/SonarCloud run), hence 0.0%.

Added `DisplayModeCoverageTests.cs` (3 plain `[Fact]`): default (zeroed) values including
DriverData IntPtr.Zero, set/store round trip across fields and property, and value-type copy
independence.

## Verification

- DisplayMode-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: Alis.Extension.Graphic.Sdl2.Structs.DisplayMode.cs 100.0% (2/2
  instrumented lines, line-rate 1.0, branch-rate 1.0).