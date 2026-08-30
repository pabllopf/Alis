# Result: ImDrawVert.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImDrawVert.cs`
CoverageBefore: 0.0% (SonarCloud; 3 uncovered lines)
CoverageAfter: 100.0% (3/3 instrumented lines, local coverlet, ImDrawVert-filtered run)
TestsAdded: 3 (ImDrawVertCoverageTests.cs, plain [Fact])
Commit: test: coverage ImDrawVert.cs
Status: REMEDIATED

## Summary

ImDrawVert.cs is a plain struct with 3 auto-properties (`Pos` as `Vector2F`, `Uv` as
`Vector2F`, `Col` as uint), no logic.

Committed `ImDrawVertTest.cs` (8 tests) and `ImDrawVertRemainingCoverageTests.cs` already
covered every member but all use `[RequireCImguiSystemFact]`, which skips when the `cimgui`
native library cannot be resolved (CI/SonarCloud run), hence 0.0%.

Added `ImDrawVertCoverageTests.cs` (3 plain `[Fact]`): default values, set/store round
trip, and value-type copy independence.

## Verification

- ImDrawVertCoverageTests-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: ImDrawVert.cs 100.0% (3/3 instrumented lines, line-rate 1.0).