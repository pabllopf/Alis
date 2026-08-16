# Result: ImPlotP4.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP4.cs`
CoverageBefore: 66.7% (SonarCloud Line: 66.7%; local 212/318-equivalent pattern: closing braces uncovered)
CoverageAfter: 100.0% (216/216, local coverlet, ImPlotP4-filtered run)
TestsAdded: 4 (ImPlotP4ExecutionTests.cs, 36 PlotHeatmap overloads exercised)
Commit: test: coverage ImPlotP4.cs
Status: REMEDIATED

## Summary

ImPlotP4.cs is the `ImPlot` partial with 36 PlotHeatmap wrapper overloads (36 complexity /
151 LOC). Existing committed tests only exercised null-label/no-library paths, leaving all
36 wrapper completion lines uncovered (closing braces only hit when the native call returns).

## Tests added (ImPlotP4ExecutionTests.cs)

Real-native execution inside an active `ImPlot.BeginPlot`/`EndPlot` with the cimgui context
bootstrap (same pattern as ImPlotP7/P8ExecutionTests): double (3), sbyte (7), byte (7),
short (7), ushort (7) and int (5) PlotHeatmap overloads with 2x2 value arrays. All native
declarations use proper array marshalling (verified in ImPlotNative.cs — unlike the broken
PlotShaded S16/U16/S32/U32/S64/U64 declarations), so every call completes safely.

## Verification

- ImPlotP4-filtered run: 76 passed / 0 failed (net8.0, local cimgui).
- Full Ui suite: 7644 passed / 14 skipped / 0 failed.
- Local coverlet: ImPlotP4.cs 216/216 = 100.0% (before: 66.7%).
