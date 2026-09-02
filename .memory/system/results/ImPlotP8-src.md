# Result: ImPlotP8.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP8.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 33.3% (106/318 instrumented lines, local coverlet, ImPlotP8NullLabelCoverageTests run)
TestsAdded: 53 (ImPlotP8NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP8.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP8.cs is a `public static partial class ImPlot` partial holding 53 `PlotShaded`/`PlotShadedG`/
`PlotStairs` overloads, each a one-line body `ImPlotNative.ImPlot_Plot*_(Encoding.UTF8.GetBytes(labelId), ...)`.
Null first string `labelId` throws `ArgumentNullException` at the call site before any native call.

Families (signatures matched exactly):
- PlotShaded (triple-xy scalar `ref T xs, ref T ys1, ref T ys2`, flags enum `ImPlotShadedFlags`):
  sbyte(2: offset, offset+stride), byte(4), short(4), ushort(4), int(4), uint(4), long(4), ulong(4) = 30.
- PlotShadedG (`IntPtr getter1, data1, getter2, data2, int count`): 2 (base, +flags).
- PlotStairs (non-ref `T[] values`, xscale/xstart, flags enum `ImPlotStairsFlags`): float(6), double(6),
  sbyte(6), byte(3: only base/xscale/xstart) = 21.

Total 53. Added `ImPlotP8NullLabelCoverageTests.cs` (53 plain [Fact]) matching each exact overload and
parameter mode, all `Assert.Throws<ArgumentNullException>`.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

The `ImPlotNative.ImPlot_Plot*_*` P/Invoke call lines (not reached because the exception on
GetBytes(labelId) is raised first). Requires native implot at runtime.

## Verification

- ImPlotP8NullLabelCoverageTests-filtered run: 53 passed / 0 failed (net8.0).
- Full project build (Debug): 0 errors.
- Local coverlet: ImPlotP8.cs 33.3% (106/318 instrumented lines).