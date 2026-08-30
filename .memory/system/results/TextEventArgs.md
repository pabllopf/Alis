# Result: TextEventArgs.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Windows/TextEventArgs.cs`
CoverageBefore: 0.0% (SonarCloud; 3 uncovered lines)
CoverageAfter: 100.0% (4/4 instrumented lines, local coverlet, TextEventArgs-filtered run)
TestsAdded: 4 (TextEventArgsCoverageTests.cs, plain [Fact])
Commit: test: coverage TextEventArgs.cs
Status: REMEDIATED

## Summary

TextEventArgs.cs is a small event-args class deriving from `EventArgs` with one string
auto-property (`Unicode`), a constructor from `TextEvent` (converts the codepoint via
`char.ConvertFromUtf32`), and a `ToString` override.

Committed `TextEventArgsRemainingCoverageTests.cs` (2 tests) uses
`[RequireCSfmlWindowsFact]`, which skips when the SFML native libraries cannot be resolved
(CI/SonarCloud run), hence 0.0%.

Added `TextEventArgsCoverageTests.cs` (4 plain `[Fact]`): constructor codepoint conversion,
setter round trip, `ToString` format, and `EventArgs` derivation.

## Verification

- TextEventArgsCoverageTests-filtered run: 4 passed / 0 failed (net8.0).
- Local coverlet: TextEventArgs.cs 100.0% (4/4 instrumented lines, line-rate 1.0).