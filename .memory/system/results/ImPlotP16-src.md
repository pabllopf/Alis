# Result: ImPlotP16.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP16.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 33.3% (104/312 instrumented lines, local coverlet, ImPlotP16NullLabelCoverageTests run)
TestsAdded: 52 (ImPlotP16NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP16.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP16.cs is a `public static partial class ImPlot` partial holding 52 `PlotBars` overloads, each a
one-line body `ImPlotNative.ImPlot_PlotBars_*(Encoding.UTF8.GetBytes(labelId), ...)`. Null first string
`labelId` throws `ArgumentNullException` at the call site before any native call. Flags enum is
`ImPlotBarsFlags`.

Families (signatures matched exactly):
- Single-array (non-ref `T[] values`, barSize/shift pattern): long(6), ulong(6), uint(5: no bare base,
  starts at +barSize) = 17.
- Dual-xy scalar (`ref T xs, ref T ys` + barSize): float(4), double(4), sbyte(4), byte(4), short(4),
  ushort(4), int(4), uint(4), long(3: no stride variant) = 35.

Total 52. Added `ImPlotP16NullLabelCoverageTests.cs` (52 plain [Fact]) matching each exact overload and
parameter mode (ref/non-ref, barSize/shift arity), all `Assert.Throws<ArgumentNullException>`.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

The `ImPlotNative.ImPlot_PlotBars_*` P/Invoke call lines (not reached because the exception on
GetBytes(labelId) is raised first). Requires native implot at runtime.

## Verification

- ImPlotP16NullLabelCoverageTests-filtered run: 52 passed / 0 failed (net8.0).
- Full project build (Debug): 0 errors.
- Local coverlet: ImPlotP16.cs 33.3% (104/312 instrumented lines).