# Result: ImPlotP3.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP3.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (141/141 lines, local coverlet)
TestsAdded: 0 (already covered by committed ImPlotP3ExecutionTests.cs / ImPlotP3RemainingCoverageTests.cs)
Commit: test: coverage ImPlotP3.cs
Status: ALREADY_REMEDIATED

## Summary

ImPlotP3.cs is an `ImPlot` partial wrapper family over `ImPlotNative.ImPlot_*` P/Invokes. The
committed `ImPlotP3ExecutionTests.cs` (real ImGui + ImPlot contexts, framed plots) and
`ImPlotP3RemainingCoverageTests.cs` (no-library guarded paths) cover the class completely: a
clean local coverlet run (net8.0, Debug, ImPlotP3 filter) measures 141/141 lines (100.0%).
All 52 tests in the filter pass.

## Verification

- ImPlotP3 filter (net8.0, Debug): 52 passed, 0 failed, 0 skipped.
- Local coverlet: ImPlotP3.cs 141/141 lines (100.0%), no uncovered lines.
