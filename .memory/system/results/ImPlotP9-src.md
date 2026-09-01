# Result: ImPlotP9.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP9.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 36.5% (162/444 instrumented lines, local coverlet, ImPlotP9NullLabelCoverageTests run)
TestsAdded: 39 (ImPlotP9NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP9.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP9.cs is a `public static partial class ImPlot` partial. 39 methods convert strings to
native byte buffers:
- PlotLine × 16 (`string labelId, ref int/uint/long/ulong xs, ref ... ys, count[, flags][, offset][, stride]`)
  — body is a single line `ImPlotNative.ImPlot_PlotLine_*(Encoding.UTF8.GetBytes(labelId), ...)`.
  Passing null label throws `ArgumentNullException` at the GetBytes call before P/Invoke.
- PlotLineG × 2 (`IntPtr getter/data`).
- PlotPieChart × 21 (`string[] labelIds, float/double/sbyte/byte/short/ushort...[] values, ...`)
  — body has a managed prelude loop `byte[][] nativeLabelIds = new byte[labelIds.Length][]`
  filling `nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i])` BEFORE the native call.
  Passing a null element inside `labelIds` throws `ArgumentNullException` in the loop, covering the
  allocation, the loop, and the `GetBytes(labelIds[i])` line.

Added `ImPlotP9NullLabelCoverageTests.cs` (39 plain `[Fact]`, deterministic): for PlotLine/PlotLineG
pass `(string)null` label; for PlotPieChart pass `new string[] { "A", null }` so the prelude loop
throws. Each throws before any native call, covering the wrapper signature line and the prelude /
GetBytes statements.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

- The `ImPlotNative.ImPlot_*` P/Invoke call line and any pure native-boundary statements (not
  reached because the exception is raised first), plus non-string methods in the partial. Reaching
  them requires the native cimgui/implot library at runtime; not coverable deterministically under
  plain `[Fact]`.

## Verification

- ImPlotP9NullLabelCoverageTests-filtered run: 39 passed / 0 failed (net8.0).
- Full project build (Debug): 0 warnings / 0 errors.
- Local coverlet: ImPlotP9.cs 36.5% (162/444 instrumented lines).