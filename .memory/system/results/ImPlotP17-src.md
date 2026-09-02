# Result: ImPlotP17.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP17.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 33.3% (106/318 instrumented lines, local coverlet, ImPlotP17NullLabelCoverageTests run)
TestsAdded: 53 (ImPlotP17NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP17.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP17.cs is a `public static partial class ImPlot` partial holding 53 `PlotBars`/`PlotBarsG`/
`PlotDigital`/`PlotDigitalG`/`PlotDummy`/`PlotErrorBars` overloads, each a one-line body
`ImPlotNative.ImPlot_Plot*_(Encoding.UTF8.GetBytes(labelId), ...)`. Null first string `labelId` throws
`ArgumentNullException` at the call site before any native call.

Families (signatures matched exactly):
- PlotBars (dual-xy `ref T xs, ref T ys` + double barSize, flags `ImPlotBarsFlags`): long(1: only offset+stride),
  ulong(4) = 5.
- PlotBarsG (`IntPtr getter, IntPtr data, int count, double barSize`): 2 (base, +flags).
- PlotDigital (dual-xy `ref T xs, ref T ys`, flags `ImPlotDigitalFlags`): float, double, sbyte, byte,
  short, ushort, int, uint, long, ulong × 4 each = 40.
- PlotDigitalG (`IntPtr getter, IntPtr data, int count`): 2 (base, +flags).
- PlotDummy (`string labelId`): 2 (base, +flags `ImPlotDummyFlags`).
- PlotErrorBars (`ref float xs, ref float ys, ref float err, int count`): 2 (base, +flags `ImPlotErrorBarsFlags`).

Total 53. Added `ImPlotP17NullLabelCoverageTests.cs` (53 plain [Fact]) matching each exact overload and
parameter mode, all `Assert.Throws<ArgumentNullException>`.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

The `ImPlotNative.ImPlot_Plot*_*` P/Invoke call lines (not reached because the exception on
GetBytes(labelId) is raised first). Requires native implot at runtime.

## Verification

- ImPlotP17NullLabelCoverageTests-filtered run: 53 passed / 0 failed (net8.0).
- Full project build (Debug): 0 errors.
- Local coverlet: ImPlotP17.cs 33.3% (106/318 instrumented lines).