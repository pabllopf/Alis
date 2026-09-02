# Result: ImPlotP5.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP5.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 33.3% (84/252 instrumented lines, local coverlet, ImPlotP5NullLabelCoverageTests run)
TestsAdded: 42 (ImPlotP5NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP5.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP5.cs is a `public static partial class ImPlot` partial holding 42 `PlotErrorBars`/`PlotHeatmap`
overloads, each a one-line body `ImPlotNative.ImPlot_Plot*_(Encoding.UTF8.GetBytes(labelId), ...)`. Null
first string `labelId` throws `ArgumentNullException` at the call site before any native call.

Families (signatures matched exactly):
- PlotErrorBars (4-ref `ref T xs, ref T ys, ref T neg, ref T pos`, flags `ImPlotErrorBarsFlags`):
  sbyte(3: no base), byte(4), short(4), ushort(4), int(4), uint(4), long(4), ulong(4) = 31.
- PlotHeatmap (non-ref `T[] values`, rows/cols/scaleMin/scaleMax/labelFmt/boundsMin/boundsMax/flags,
  flags `ImPlotHeatmapFlags`): float(7), double(4) = 11. bounds args use `new ImPlotPoint()`.

Total 42. Added `ImPlotP5NullLabelCoverageTests.cs` (42 plain [Fact]) matching each exact overload and
parameter mode, all `Assert.Throws<ArgumentNullException>`.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

The `ImPlotNative.ImPlot_Plot*_*` P/Invoke call lines (not reached because the exception on
GetBytes(labelId) is raised first). Requires native implot at runtime.

## Verification

- ImPlotP5NullLabelCoverageTests-filtered run: 42 passed / 0 failed (net8.0).
- Full project build (Debug): 0 errors.
- Local coverlet: ImPlotP5.cs 33.3% (84/252 instrumented lines).