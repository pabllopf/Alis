# Result: ImGuiTableColumnSortSpecs.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiTableColumnSortSpecs.cs`
CoverageBefore: 0.0% (SonarCloud; 4 uncovered lines)
CoverageAfter: 100.0% (8/8 instrumented lines, local coverlet, ImGuiTableColumnSortSpecs-filtered run)
TestsAdded: 3 (ImGuiTableColumnSortSpecsCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGuiTableColumnSortSpecs.cs
Status: REMEDIATED

## Summary

ImGuiTableColumnSortSpecs.cs is a plain struct with 4 auto-properties (`ColumnUserId`,
`ColumnIndex`, `SortOrder`, `SortDirection`), no logic.

Committed `ImGuiTableColumnSortSpecsTest.cs` (8 tests) and
`ImGuiTableColumnSortSpecsRemainingCoverageTests.cs` (12 tests) already covered every
property but all use `[RequireCImguiSystemFact]`, which skips when the `cimgui` native
library cannot be resolved (CI/SonarCloud run), hence 0.0%.

Added `ImGuiTableColumnSortSpecsCoverageTests.cs` with plain `[Fact]` tests: default
values, set/store round trip (incl. enum direction), and value-type copy independence.

## Verification

- ImGuiTableColumnSortSpecsCoverageTests-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: ImGuiTableColumnSortSpecs.cs 100.0% (8/8 instrumented lines, line-rate 1.0).