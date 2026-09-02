# Result: ImPlotP22.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP22.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 33.3% (110/330 instrumented lines, local coverlet, ImPlotP22NullLabelCoverageTests run)
TestsAdded: 55 (ImPlotP22NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP22.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP22.cs is a `public static partial class ImPlot` partial holding 55 `PlotLine` overloads in two
families, each a one-line body `ImPlotNative.ImPlot_PlotLine_*(Encoding.UTF8.GetBytes(labelId), ...)`.
Null first string `labelId` throws `ArgumentNullException` at the call site before any native call.

Families (signatures matched exactly):
- Single-array (non-ref `T[] values`): short(1, fullest 8-arg overload), ushort(6), int(6), uint(6),
  long(6), ulong(6) = 31.
- Dual-xy scalar (`ref T xs, ref T ys`): float, double, sbyte, byte, short, ushort × 4 variants = 24.

Added `ImPlotP22NullLabelCoverageTests.cs` (55 plain [Fact]) generated to match each exact overload and
parameter mode (non-ref array vs ref scalar pair), all `Assert.Throws<ArgumentNullException>`.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

The `ImPlotNative.ImPlot_PlotLine_*` P/Invoke call lines in the partial (not reached because the
exception on GetBytes(labelId) is raised first). Requires native implot at runtime.

## Verification

- ImPlotP22NullLabelCoverageTests-filtered run: 55 passed / 0 failed (net8.0).
- Full project build (Debug): 0 errors.
- Local coverlet: ImPlotP22.cs 33.3% (110/330 instrumented lines).