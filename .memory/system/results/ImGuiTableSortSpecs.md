# Result: ImGuiTableSortSpecs.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiTableSortSpecs.cs`
CoverageBefore: 0.0% (SonarCloud; 3 uncovered lines)
CoverageAfter: 100.0% (3/3 instrumented lines, local coverlet, ImGuiTableSortSpecs-filtered run)
TestsAdded: 3 (ImGuiTableSortSpecsCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGuiTableSortSpecs.cs
Status: REMEDIATED

## Summary

ImGuiTableSortSpecs.cs is a plain struct with 3 auto-properties (`Specs` as `IntPtr`,
`SpecsCount` as int, `SpecsDirty` as byte), no logic.

Committed `ImGuiTableSortSpecsTest.cs` (3 tests) already covered every member but all use
`[RequireCImguiSystemFact]`, which skips when the `cimgui` native library cannot be
resolved (CI/SonarCloud run), hence 0.0%.

Added `ImGuiTableSortSpecsCoverageTests.cs` (3 plain `[Fact]`): default values,
set/store round trip, and value-type copy independence.

## Verification

- ImGuiTableSortSpecsCoverageTests-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: ImGuiTableSortSpecs.cs 100.0% (3/3 instrumented lines, line-rate 1.0).