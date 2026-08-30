# Result: UserEvent.cs

File: `1_Presentation/Extension/Graphic/Sdl2/src/Structs/UserEvent.cs`
CoverageBefore: 0.0% (SonarCloud; 2 uncovered lines)
CoverageAfter: 100.0% (2/2 instrumented lines, local coverlet, UserEvent-filtered run)
TestsAdded: 3 (UserEventCoverageTests.cs, plain [Fact])
Commit: test: coverage UserEvent.cs
Status: REMEDIATED

## Summary

UserEvent.cs is a sequential-layout struct with 4 public mutable fields (`type`,
`timestamp`, `windowID`, `code`) and 2 `IntPtr` auto-properties (`Data1`, `Data2`). Only
the property getter/setter lines are instrumented.

Committed `UserEventTest.cs` (3 tests) already covered the type but all use
`[RequireSdl2ImageFact]`, which skips when `libsdl2_image` cannot be resolved
(CI/SonarCloud run), hence 0.0%.

Added `UserEventCoverageTests.cs` (3 plain `[Fact]`): default (zeroed) field values,
set/store round trip on the auto-properties, and direct field mutation.

## Verification

- UserEventCoverageTests-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: UserEvent.cs 100.0% (2/2 instrumented lines, line-rate 1.0).