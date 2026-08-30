# Result: InternalGameControllerButtonBindHat.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/InternalGameControllerButtonBindHat.cs`
CoverageBefore: 0.0% (SonarCloud; 2 uncovered lines)
CoverageAfter: 100.0% (4/4, local coverlet, InternalGameControllerButtonBindHat-filtered run)
TestsAdded: 3 (InternalGameControllerButtonBindHatCoverageTests.cs, plain [Fact])
Commit: test: coverage InternalGameControllerButtonBindHat.cs
Status: REMEDIATED

## Summary

InternalGameControllerButtonBindHat.cs is a sequential-layout struct with 2 `int`
auto-properties (`Hat`, `HatMask`). Only the property getter/setter lines are instrumented.

Committed `InternalGameControllerButtonBindHatTest.cs` already covered the type but uses
`[RequireSdl2ImageFact]`, which skips when `libsdl2_image` cannot be resolved
(CI/SonarCloud run), hence 0.0%.

Added `InternalGameControllerButtonBindHatCoverageTests.cs` (3 plain `[Fact]`): default
(zeroed) field values, set/store round trip on the auto-properties, and value-type copy
independence.

## Verification

- InternalGameControllerButtonBindHat-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: InternalGameControllerButtonBindHat.cs 100.0% (4/4 instrumented lines,
  line-rate 1.0, branch-rate 1.0).