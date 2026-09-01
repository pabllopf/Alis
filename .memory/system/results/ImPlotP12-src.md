# Result: ImPlotP12.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP12.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 25.0% (100/400 instrumented lines, local coverlet, ImPlotP12NullLabelCoverageTests run)
TestsAdded: 50 (ImPlotP12NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP12.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP12.cs is a `public static partial class ImPlot` partial holding 50 `PlotHistogram` static
overloads returning `double`. Every method has `string labelId` as its first parameter and its body
is a single line calling `ImPlotNative.ImPlot_PlotHistogram_*(Encoding.UTF8.GetBytes(labelId), ...)`.
There is NO managed prelude loop — the very first statement dereferences the label, so passing a
null `labelId` makes `Encoding.UTF8.GetBytes(null)` throw `ArgumentNullException` before any native
P/Invoke. Signatures include `int count/bins`, `double barScale`, `ImPlotRange range` /
`ImPlotRect` struct params, and `ImPlotHistogramFlags flags`.

Added `ImPlotP12NullLabelCoverageTests.cs` (50 plain `[Fact]`, deterministic on every platform):
one per overload, passing null label. Array overloads use `Array.Empty<T>()`; struct params use
`default(ImPlotRange)`/`default(ImPlotRect)`; scalars/enums use `0`/`.None`. Each throws from the
`GetBytes(labelId)` statement, covering the wrapper signature line and that GetBytes line.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

- The `ImPlotNative.ImPlot_PlotHistogram_*` P/Invoke call line and the `double ret = ...`
  assignment (not reached because the exception is raised first on the GetBytes argument).
  Requires native cimgui/implot at runtime; not coverable deterministically under plain `[Fact]`.

## Verification

- ImPlotP12NullLabelCoverageTests-filtered run: 50 passed / 0 failed (net8.0).
- Full project build (Debug): 0 warnings / 0 errors.
- Local coverlet: ImPlotP12.cs 25.0% (100/400 instrumented lines).