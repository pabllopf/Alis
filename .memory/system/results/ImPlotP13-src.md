# Result: ImPlotP13.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP13.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 33.3% (106/318 instrumented lines, local coverlet, ImPlotP13NullLabelCoverageTests run)
TestsAdded: 53 (ImPlotP13NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP13.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP13.cs is a `public static partial class ImPlot` partial holding 53 `PlotStairs`/`PlotStairsG`/
`PlotStems` overloads, each a one-line body `ImPlotNative.ImPlot_Plot*_(Encoding.UTF8.GetBytes(labelId), ...)`.
Null first string `labelId` throws `ArgumentNullException` at the call site before any native call.

Families (signatures matched exactly):
- PlotStairs (dual-xy scalar `ref T xs, ref T ys`, flags enum `ImPlotStairsFlags`): byte(1: only
  offset+stride), short(4), ushort(4), int(4), uint(4), long(4), ulong(4) = 25.
- PlotStairsG (`IntPtr getter, IntPtr data, int count`): 2 (base, +flags). Has 2 GetBytes per body but
  label null throws on the first.
- PlotStems (non-ref `T[] values`, @ref/scale/start/flags/offset/stride, flags enum `ImPlotStemsFlags`):
  float(7), double(7), sbyte(7), byte(5: no offset/stride variants) = 26.

Total 53. Added `ImPlotP13NullLabelCoverageTests.cs` (53 plain [Fact]) matching each exact overload and
parameter mode, all `Assert.Throws<ArgumentNullException>`.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

The `ImPlotNative.ImPlot_Plot*_*` P/Invoke call lines (not reached because the exception on
GetBytes(labelId) is raised first). Requires native implot at runtime.

## Verification

- ImPlotP13NullLabelCoverageTests-filtered run: 53 passed / 0 failed (net8.0).
- Full project build (Debug): 0 errors.
- Local coverlet: ImPlotP13.cs 33.3% (106/318 instrumented lines).