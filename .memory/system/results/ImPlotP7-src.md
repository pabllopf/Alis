# Result: ImPlotP7.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP7.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 33.3% (108/324 instrumented lines, local coverlet, ImPlotP7NullLabelCoverageTests run)
TestsAdded: 54 (ImPlotP7NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP7.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP7.cs is a `public static partial class ImPlot` partial holding 54 `PlotScatter` overloads, each a
one-line body `ImPlotNative.ImPlot_PlotScatter_*(Encoding.UTF8.GetBytes(labelId), ...)`. Null first
string `labelId` throws `ArgumentNullException` at the call site before any native call. Flags enum is
`ImPlotScatterFlags`.

Families (signatures matched exactly):
- Single-array (non-ref `T[] values`, xscale/xstart doubles): byte(1: only fullest offset+stride),
  short(6), ushort(6), int(6), uint(6), long(6), ulong(6) = 37.
- Dual-xy scalar (`ref T xs, ref T ys`): float(4), double(4), sbyte(4), byte(4), short(1: base only) = 17.

Total 54. Added `ImPlotP7NullLabelCoverageTests.cs` (54 plain [Fact]) generated to match each exact
overload and parameter mode (ref/non-ref, arity, flags), all `Assert.Throws<ArgumentNullException>`.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

The `ImPlotNative.ImPlot_PlotScatter_*` P/Invoke call lines (not reached because the exception on
GetBytes(labelId) is raised first). Requires native implot at runtime.

## Verification

- ImPlotP7NullLabelCoverageTests-filtered run: 54 passed / 0 failed (net8.0).
- Full project build (Debug): 0 errors.
- Local coverlet: ImPlotP7.cs 33.3% (108/324 instrumented lines).