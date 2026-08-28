# Result: JoystickButtonEventArgs.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Windows/JoystickButtonEventArgs.cs`
CoverageBefore: 0.0% (SonarCloud, stale artifact)
CoverageAfter: 100.0% (10/10, local coverlet, JoystickButton-filtered run)
TestsAdded: 0 (already covered by committed JoystickButtonEventTest.cs)
Commit: test: coverage JoystickButtonEventArgs.cs
Status: ALREADY_REMEDIATED

## Summary

JoystickButtonEventArgs.cs is a managed EventArgs subclass (17 LOC) with two auto-properties
(`Button`, `JoystickId`), a constructor from `JoystickButtonEvent`, and a `ToString()`
override.

The committed `JoystickButtonEventTest.cs` already covers every member of the class (lines
55-74): `JoystickButtonEventArgs_Constructor_SetsProperties` exercises the constructor and
both property getters; `JoystickButtonEventArgs_ToString_IncludesPropertyNames` exercises
`ToString()`. Local coverlet on the JoystickButton-filtered run reports 100.0% (10/10
instrumented lines). The SonarCloud 0.0% is a stale artifact.

The companion `JoystickButtonEventArgsRemainingCoverageTests.cs` is an empty placeholder
class (no tests); it is left untouched per the "do not refactor unrelated tests" rule. No
new tests are required since coverage is already complete.

## Verification

- JoystickButton-filtered run: 5 passed / 0 failed (net8.0).
- Local coverlet: JoystickButtonEventArgs.cs 100.0% (10/10 lines).
