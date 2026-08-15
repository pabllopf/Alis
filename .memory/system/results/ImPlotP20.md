# Result: ImPlotP20.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP20.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (87/87 lines, local coverlet)
TestsAdded: 0 (already covered by committed ImPlotP20ExecutionTests.cs)
Commit: test: coverage ImPlotP20.cs
Status: ALREADY_REMEDIATED

## Summary

ImPlotP20.cs is the `ImPlot.PlotHeatmap` (int/uint/long/ulong arrays) and
`PlotHistogram` (float/double/sbyte/byte arrays) wrapper families (41 complexity / 117 LOC
per SonarCloud), all single-expression bodies over `ImPlotNative.ImPlot_PlotHeatmap_*` /
`ImPlot_PlotHistogram_*` P/Invokes.

The committed `ImPlotP20ExecutionTests.cs` (8 tests, `[RequireImNodesSystemFact]`, real
ImGui + ImPlot contexts with dyld slot synchronization, framed plots via BeginPlot /
SetupAxes / SetupFinish / EndPlot) exercises every overload; the 41 `WithoutNativeLibrary`
guards in `ImPlotP20RemainingCoverageTests.cs` cover the no-library paths. A clean local
coverlet run (net8.0, Debug, after a fresh restore — an earlier 0.0% reading was corrupted by
a concurrent build writing shared obj/ assets) measures the class at 87/87 lines (100.0%).
All 49 tests in the ImPlotP20 filter pass.

## Verification

- ImPlotP20 filter (net8.0, Debug): 49 passed, 0 failed, 0 skipped.
- Local coverlet: ImPlotP20.cs 87/87 lines (100.0%), no uncovered lines.
