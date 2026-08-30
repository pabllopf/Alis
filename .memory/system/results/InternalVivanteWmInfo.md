# Result: InternalVivanteWmInfo.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/InternalVivanteWmInfo.cs`
CoverageBefore: 0.0% (SonarCloud; 2 uncovered lines)
CoverageAfter: 100.0% (4/4, local coverlet, InternalVivanteWmInfo-filtered run)
TestsAdded: 3 (InternalVivanteWmInfoCoverageTests.cs, plain [Fact])
Commit: test: coverage InternalVivanteWmInfo.cs
Status: REMEDIATED

## Summary

InternalVivanteWmInfo.cs is a sequential-layout struct with 2 `IntPtr` auto-properties
(`Display`, `Window`). Only the property getter/setter lines are instrumented.

Committed `InternalVivanteWmInfoTest.cs` already covered the type but uses
`[RequireSdl2ImageFact]`, which skips when `libsdl2_image` cannot be resolved
(CI/SonarCloud run), hence 0.0%.

Added `InternalVivanteWmInfoCoverageTests.cs` (3 plain `[Fact]`): default (zeroed) field
values, set/store round trip on the auto-properties, and value-type copy independence.

## Verification

- InternalVivanteWmInfo-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: InternalVivanteWmInfo.cs 100.0% (4/4 instrumented lines,
  line-rate 1.0, branch-rate 1.0).