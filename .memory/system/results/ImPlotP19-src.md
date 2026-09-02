# Result: ImPlotP19.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP19.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 33.3% (108/324 instrumented lines, local coverlet, ImPlotP19NullLabelCoverageTests run)
TestsAdded: 54 (ImPlotP19NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP19.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP19.cs is a `public static partial class ImPlot` partial holding 54 `PlotStairs` overloads in two
families, each a one-line body `ImPlotNative.ImPlot_PlotStairs_*(Encoding.UTF8.GetBytes(labelId), ...)`.
Null first string `labelId` throws `ArgumentNullException` at the call site before any native call.
Flags enum is `ImPlotStairsFlags`.

Families (signatures matched exactly):
- Single-array (non-ref `T[] values`): byte(3: variants with flags/offset/stride), short(6), ushort(6),
  int(6), uint(6), long(6), ulong(6) = 39.
- Dual-xy scalar (`ref T xs, ref T ys`): float(4), double(4), sbyte(4), byte(3, no stride variant) = 15.

Total 54. Added `ImPlotP19NullLabelCoverageTests.cs` (54 plain [Fact]) generated to match each exact
overload and parameter mode, all `Assert.Throws<ArgumentNullException>`.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

The `ImPlotNative.ImPlot_PlotStairs_*` P/Invoke call lines in the partial (not reached because the
exception on GetBytes(labelId) is raised first). Requires native implot at runtime.

## Verification

- ImPlotP19NullLabelCoverageTests-filtered run: 54 passed / 0 failed (net8.0).
- Full project build (Debug): 0 errors.
- Local coverlet: ImPlotP19.cs 33.3% (108/324 instrumented lines).