# Result: ImPlotP6.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP6.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 33.3% (108/324 instrumented lines, local coverlet, ImPlotP6NullLabelCoverageTests run)
TestsAdded: 54 (ImPlotP6NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP6.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP6.cs is a `public static partial class ImPlot` partial holding 54 `PlotInfLines`/`PlotLine`
overloads, each a one-line body `ImPlotNative.ImPlot_Plot*_(Encoding.UTF8.GetBytes(labelId), ...)`.
Null first string `labelId` throws `ArgumentNullException` at the call site before any native call.

Families (signatures matched exactly, all non-ref value arrays):
- PlotInfLines (flags enum `ImPlotInfLinesFlags`): byte[1: only offset+stride variant],
  short(4), ushort(4), int(4), uint(4), long(4), ulong(4) = 25. Variants: base, +flags, +offset, +flags+offset+stride.
- PlotLine (flags enum `ImPlotLineFlags`, xscale/xstart doubles): float(6), double(6), sbyte(6),
  byte(6), short(5: no stride variant) = 29.

Total 54. Added `ImPlotP6NullLabelCoverageTests.cs` (54 plain [Fact]) matching each exact overload,
all `Assert.Throws<ArgumentNullException>`.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

The `ImPlotNative.ImPlot_Plot*_*` P/Invoke call lines (not reached because the exception on
GetBytes(labelId) is raised first). Requires native implot at runtime.

## Verification

- ImPlotP6NullLabelCoverageTests-filtered run: 54 passed / 0 failed (net8.0).
- Full project build (Debug): 0 errors.
- Local coverlet: ImPlotP6.cs 33.3% (108/324 instrumented lines).