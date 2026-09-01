# Result: ImPlotP11.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP11.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 36.2% (160/442 instrumented lines, local coverlet, ImPlotP11NullLabelCoverageTests run)
TestsAdded: 42 (ImPlotP11NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP11.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP11.cs is a `public static partial class ImPlot` partial. 42 methods convert strings to
native byte buffers:
- PlotScatter × 23 (`string labelId, float/double/sbyte/byte/...[] values, count[, xscale][, xstart][, flags][, offset][, stride]`)
  — single line body `ImPlotNative.ImPlot_PlotScatter_*(Encoding.UTF8.GetBytes(labelId), ...)`.
  Passing null label throws `ArgumentNullException` at the GetBytes call before P/Invoke.
- PlotPieChart × 19 (`string[] labelIds, ushort/int/uint/long/ulong...[] values, ...`) — managed
  prelude loop `nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i])` BEFORE the native call.
  A null element inside `labelIds` throws `ArgumentNullException` in the loop, covering the
  allocation, loop, and GetBytes line.

Added `ImPlotP11NullLabelCoverageTests.cs` (42 plain `[Fact]`, deterministic): null `labelId` for
PlotScatter; `new string[] { "A", null }` for PlotPieChart.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

- The `ImPlotNative.ImPlot_*` P/Invoke call line and pure native-boundary statements (not reached
  because the exception is raised first). Requires native cimgui/implot at runtime; not coverable
  deterministically under plain `[Fact]`.

## Verification

- ImPlotP11NullLabelCoverageTests-filtered run: 42 passed / 0 failed (net8.0).
- Full project build (Debug): 0 warnings / 0 errors.
- Local coverlet: ImPlotP11.cs 36.2% (160/442 instrumented lines).