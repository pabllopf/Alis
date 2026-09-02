# Result: ImPlotP21.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP21.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 33.3% (100/300 instrumented lines, local coverlet, ImPlotP21NullLabelCoverageTests run)
TestsAdded: 50 (ImPlotP21NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP21.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP21.cs is a `public static partial class ImPlot` partial holding 50 `PlotShaded` overloads, each a
one-line body `ImPlotNative.ImPlot_PlotShaded_*(Encoding.UTF8.GetBytes(labelId), ...)`. Null first string
`labelId` throws `ArgumentNullException` at the call site before any native call. Flags enum is
`ImPlotShadedFlags`.

Two structural forms (signatures matched exactly), distinguished by arity (2 refs vs 3 refs):
- Two-arg (`ref T xs, ref T ys` + double yref): sbyte, byte, short, ushort, int, uint, long, ulong,
  each 5 (base, +yref, +flags, +offset, +stride) = 40.
- Three-arg (`ref T xs, ref T ys1, ref T ys2`): float(4), double(4), sbyte(2) = 10.

Total 50. Added `ImPlotP21NullLabelCoverageTests.cs` (50 plain [Fact]); 3-ref calls resolve to the
three-arg overloads, 2-ref to two-arg (arity disambiguates). All `Assert.Throws<ArgumentNullException>`.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

The `ImPlotNative.ImPlot_PlotShaded_*` P/Invoke call lines (not reached because the exception on
GetBytes(labelId) is raised first). Requires native implot at runtime.

## Verification

- ImPlotP21NullLabelCoverageTests-filtered run: 50 passed / 0 failed (net8.0).
- Full project build (Debug): 0 errors.
- Local coverlet: ImPlotP21.cs 33.3% (100/300 instrumented lines).