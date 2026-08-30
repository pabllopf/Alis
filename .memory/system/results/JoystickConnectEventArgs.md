# Result: JoystickConnectEventArgs.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Windows/JoystickConnectEventArgs.cs`
CoverageBefore: 0.0% (SonarCloud; 4 uncovered lines)
CoverageAfter: 100.0% (4/4 instrumented lines, local coverlet, JoystickConnectEventArgs-filtered run)
TestsAdded: 4 (JoystickConnectEventArgsCoverageTests.cs, plain [Fact])
Commit: test: coverage JoystickConnectEventArgs.cs
Status: REMEDIATED

## Summary

JoystickConnectEventArgs.cs is a small event-args class deriving from `EventArgs` with one
auto-property (`JoystickId`), a constructor from `JoystickConnectEvent`, and a `ToString`
override.

The committed `JoystickConnectEventArgsRemainingCoverageTests.cs` is an empty placeholder
class (no tests), and `JoystickConnectEventTest.cs` targets the event struct itself, so the
args class had no coverage on SonarCloud.

Added `JoystickConnectEventArgsCoverageTests.cs` (4 plain `[Fact]`): constructor mapping,
setter round trip, `ToString` format, and `EventArgs` derivation.

## Verification

- JoystickConnectEventArgsCoverageTests-filtered run: 4 passed / 0 failed (net8.0).
- Local coverlet: JoystickConnectEventArgs.cs 100.0% (4/4 instrumented lines, line-rate 1.0).