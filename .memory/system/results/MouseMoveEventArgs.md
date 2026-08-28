# Result: MouseMoveEventArgs.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Windows/MouseMoveEventArgs.cs`
CoverageBefore: 0.0% (SonarCloud, stale artifact)
CoverageAfter: 100.0% (10/10, local coverlet, MouseMove-filtered run)
TestsAdded: 0 (already covered by committed MouseMoveEventTest.cs + MouseMoveEventArgsRemainingCoverageTests.cs)
Commit: test: coverage MouseMoveEventArgs.cs
Status: ALREADY_REMEDIATED

## Summary

MouseMoveEventArgs.cs is a managed EventArgs subclass (17 LOC) with two auto-properties
(`X`, `Y`), a constructor from `MouseMoveEvent`, and a `ToString()` override.

The committed `MouseMoveEventTest.cs` (3 tests, `[RequireCSfmlSystemFact]`) and
`MouseMoveEventArgsRemainingCoverageTests.cs` (3 tests, `[RequireCSfmlWindowsFact]`)
exercise every member: the constructor, both property getters/setters, and `ToString()`.
Local coverlet on the MouseMove-filtered run reports 100.0% (10/10 instrumented lines). The
SonarCloud 0.0% is a stale artifact (tests not yet uploaded).

## Verification

- MouseMove-filtered run: 8 passed / 0 failed (net8.0).
- Local coverlet: MouseMoveEventArgs.cs 100.0% (10/10 lines).
