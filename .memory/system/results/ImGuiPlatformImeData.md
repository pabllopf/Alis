# Result: ImGuiPlatformImeData.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiPlatformImeData.cs`
CoverageBefore: 0.0% (SonarCloud; 3 uncovered lines)
CoverageAfter: 100.0% (3/3 instrumented lines, local coverlet, ImGuiPlatformImeData-filtered run)
TestsAdded: 3 (ImGuiPlatformImeDataCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGuiPlatformImeData.cs
Status: REMEDIATED

## Summary

ImGuiPlatformImeData.cs is a plain struct with 3 auto-properties (`WantVisible` as byte,
`InputPos` as `Vector2F`, `InputLineHeight` as float), no logic.

Committed `ImGuiPlatformImeDataTest.cs` (8 tests) and `ImGuiPlatformImeDataRemainingCoverageTests.cs`
already covered every member but all use `[RequireCImguiSystemFact]`, which skips when the
`cimgui` native library cannot be resolved (CI/SonarCloud run), hence 0.0%.

Added `ImGuiPlatformImeDataCoverageTests.cs` (3 plain `[Fact]`): default values,
set/store round trip, and value-type copy independence.

## Verification

- ImGuiPlatformImeDataCoverageTests-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: ImGuiPlatformImeData.cs 100.0% (3/3 instrumented lines, line-rate 1.0).