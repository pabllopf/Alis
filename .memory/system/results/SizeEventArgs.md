# Result: SizeEventArgs.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Windows/SizeEventArgs.cs`
CoverageBefore: 0.0% (SonarCloud, stale artifact)
CoverageAfter: 100.0% (10/10, local coverlet, SizeEvent-filtered run)
TestsAdded: 0 (already covered by committed SizeEventTest.cs + SizeEventArgsRemainingCoverageTests.cs)
Commit: test: coverage SizeEventArgs.cs
Status: ALREADY_REMEDIATED

## Summary

SizeEventArgs.cs is a managed EventArgs subclass with two auto-properties (`Width`,
`Height`), a constructor from `SizeEvent`, and a `ToString()` override.

The committed `SizeEventTest.cs` (3 tests, `[RequireCSfmlSystemFact]`) and
`SizeEventArgsRemainingCoverageTests.cs` (3 tests, `[RequireCSfmlWindowsFact]`) exercise
every member: the constructor, both property getters/setters, and `ToString()`. Local
coverlet on the SizeEvent-filtered run reports 100.0% (10/10 instrumented lines). The
SonarCloud 0.0% is a stale artifact (tests not yet uploaded).

## Verification

- SizeEvent-filtered run: 6 passed / 0 failed (net8.0).
- Local coverlet: SizeEventArgs.cs 100.0% (10/10 lines).
