# Result: ImDrawListSplitter.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImDrawListSplitter.cs`
CoverageBefore: 0.0% (SonarCloud; 3 uncovered lines)
CoverageAfter: 100.0% (3/3 instrumented lines, local coverlet, ImDrawListSplitter-filtered run)
TestsAdded: 3 (ImDrawListSplitterCoverageTests.cs, plain [Fact])
Commit: test: coverage ImDrawListSplitter.cs
Status: REMEDIATED

## Summary

ImDrawListSplitter.cs is a plain struct with 3 auto-properties (`Current` as int, `Count`
as int, `Channels` as `ImVector`), no logic.

Committed `ImDrawListSplitterTest.cs` (8 tests) and `ImDrawListSplitterRemainingCoverageTests.cs`
already covered every member but all use `[RequireCImguiSystemFact]`, which skips when the
`cimgui` native library cannot be resolved (CI/SonarCloud run), hence 0.0%.

Added `ImDrawListSplitterCoverageTests.cs` (3 plain `[Fact]`): default values,
set/store round trip, and value-type copy independence.

## Verification

- ImDrawListSplitterCoverageTests-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: ImDrawListSplitter.cs 100.0% (3/3 instrumented lines, line-rate 1.0).