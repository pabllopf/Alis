# Result: JetBrains.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Fonts/JetBrains.cs`
CoverageBefore: 0.0% (SonarCloud; 3 uncovered lines)
CoverageAfter: 100.0% (3/3 instrumented lines, local coverlet, JetBrains-filtered run)
TestsAdded: 3 (JetBrainsCoverageTests.cs, plain [Fact])
Commit: test: coverage JetBrains.cs
Status: REMEDIATED

## Summary

JetBrains.cs is a static class exposing 3 `static readonly string` font-file-name
constants (`NameRegular`, `NameSolid`, `NameLight`), no logic.

Committed `JetBrainsTest.cs` (3 tests) already covered the constants but all use
`[RequireCImguiSystemFact]`, which skips when the `cimgui` native library cannot be
resolved (CI/SonarCloud run), hence 0.0%.

Added `JetBrainsCoverageTests.cs` (3 plain `[Fact]`) asserting each constant is
non-empty.

## Verification

- JetBrainsCoverageTests-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: JetBrains.cs 100.0% (3/3 instrumented lines, line-rate 1.0).