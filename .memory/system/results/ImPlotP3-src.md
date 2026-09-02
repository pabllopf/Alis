# Result: ImPlotP3.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP3.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 33.3% (94/282 instrumented lines, local coverlet, ImPlotP3NullLabelCoverageTests run)
TestsAdded: 47 (ImPlotP3NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP3.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP3.cs is a `public static partial class ImPlot` partial holding 47 `PlotErrorBars` overloads, each a
one-line body `ImPlotNative.ImPlot_PlotErrorBars_*(Encoding.UTF8.GetBytes(labelId), ...)`. Null first
string `labelId` throws `ArgumentNullException` at the call site before any native call. Flags enum is
`ImPlotErrorBarsFlags`.

Two structural forms (signatures matched exactly, distinguished by ref arity):
- 3-ref (`ref T xs, ref T ys, ref T err`): float(2: offset, offset+stride), double(4), sbyte(4), byte(4),
  short(4), ushort(4), int(4), uint(4), long(4), ulong(4) = 38.
- 4-ref (`ref T xs, ref T ys, ref T neg, ref T pos`): float(4), double(4), sbyte(1: base only) = 9.

Total 47. Added `ImPlotP3NullLabelCoverageTests.cs` (47 plain [Fact]); 3-ref calls use `err`, 4-ref use
`neg/pos` (arity disambiguates). All `Assert.Throws<ArgumentNullException>`.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

The `ImPlotNative.ImPlot_PlotErrorBars_*` P/Invoke call lines (not reached because the exception on
GetBytes(labelId) is raised first). Requires native implot at runtime.

## Verification

- ImPlotP3NullLabelCoverageTests-filtered run: 47 passed / 0 failed (net8.0).
- Full project build (Debug): 0 errors.
- Local coverlet: ImPlotP3.cs 33.3% (94/282 instrumented lines).