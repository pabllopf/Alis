# Result: ImGuiTextFilter.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiTextFilter.cs`
CoverageBefore: 0.0% (SonarCloud; 3 uncovered lines)
CoverageAfter: 100.0% (8/8 instrumented lines, local coverlet, ImGuiTextFilter-filtered run)
TestsAdded: 3 (ImGuiTextFilterCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGuiTextFilter.cs
Status: REMEDIATED

## Summary

ImGuiTextFilter.cs is a plain struct with 3 properties (`InputBuf` backed by a private
`byte[]` field, `Filters` as `ImVector`, `CountGrep` as int), no logic.

Committed `ImGuiTextFilterTest.cs` (3 tests) and `ImGuiTextFilterTests.cs` (6 tests) already
covered every property but all use `[RequireCImguiSystemFact]`, which skips when the
`cimgui` native library cannot be resolved (CI/SonarCloud run), hence 0.0%.

Added `ImGuiTextFilterCoverageTests.cs` with plain `[Fact]` tests: default values,
set/store round trip, and value-type copy independence.

## Verification

- ImGuiTextFilterCoverageTests-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: ImGuiTextFilter.cs 100.0% (8/8 instrumented lines, line-rate 1.0).