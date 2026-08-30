# Result: ImGuiListClipper.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiListClipper.cs`
CoverageBefore: 0.0% (SonarCloud; 6 uncovered lines)
CoverageAfter: 100.0% (12/12 instrumented lines, local coverlet, ImGuiListClipper-filtered run)
TestsAdded: 4 (ImGuiListClipperCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGuiListClipper.cs
Status: REMEDIATED

## Summary

ImGuiListClipper.cs is a plain struct with 6 auto-properties (`DisplayStart`,
`DisplayEnd`, `ItemsCount`, `ItemsHeight`, `StartPosY`, `TempData`) and no logic.

Committed `ImGuiListClipperTest.cs` (6 tests) and
`ImGuiListClipperRemainingCoverageTests.cs` (3 tests) already covered every property but
all of them use `[RequireCImguiSystemFact]`, which skips when the `cimgui` native library
cannot be resolved (the CI/SonarCloud run has no cimgui, hence 0.0%).

Added `ImGuiListClipperCoverageTests.cs` with plain `[Fact]` tests: default zero values,
integer round trip, float/pointer round trip, and value-type copy independence.

## Verification

- ImGuiListClipper-filtered run: 18 passed / 0 failed, 0 skipped (net8.0).
- Local coverlet: ImGuiListClipper.cs 100.0% (12/12 instrumented lines, line-rate 1.0, branch-rate 1.0).