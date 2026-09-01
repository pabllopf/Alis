# Result: ImPlotP14.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP14.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 33.3% (140/420 instrumented lines, local coverlet, ImPlotP14NullLabelCoverageTests run)
TestsAdded: 70 (ImPlotP14NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP14.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP14.cs is a `public static partial class ImPlot` partial holding 70 `PlotStems` static
overloads. Every method has `string labelId` as its first parameter and its body is a single line
calling `ImPlotNative.ImPlot_PlotStems_*(Encoding.UTF8.GetBytes(labelId), ...)`. There is NO
managed prelude loop — the very first statement dereferences the label, so passing a null
`labelId` makes `Encoding.UTF8.GetBytes(null)` throw `ArgumentNullException` before any native
P/Invoke. Signatures include a `double @ref` param (escaped keyword) plus scale/start/count and
`ref T xs/ys` forms.

Added `ImPlotP14NullLabelCoverageTests.cs` (70 plain `[Fact]`, deterministic on every platform):
one per overload, passing null label. Array overloads use `Array.Empty<T>()`, `ref` overloads use
typed locals, scalar doubles/enums/int offset use `0`/`.None`. Each throws from the
`GetBytes(labelId)` statement, covering the wrapper signature line and that GetBytes line.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

- The `ImPlotNative.ImPlot_PlotStems_*` P/Invoke call line (not reached because the exception is
  raised first). Requires native cimgui/implot at runtime; not coverable deterministically under
  plain `[Fact]`.

## Verification

- ImPlotP14NullLabelCoverageTests-filtered run: 70 passed / 0 failed (net8.0).
- Full project build (Debug): 0 warnings / 0 errors.
- Local coverlet: ImPlotP14.cs 33.3% (140/420 instrumented lines).