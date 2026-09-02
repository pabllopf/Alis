# Result: ImPlotP15.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP15.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 25.4% (86/338 instrumented lines, local coverlet, ImPlotP15NullLabelCoverageTests run)
TestsAdded: 43 (ImPlotP15NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP15.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP15.cs is a `public static partial class ImPlot` partial holding 43 `PlotBars` overloads
(types: float(6), double(6), sbyte(6), byte(6), short(6), ushort(6), int(6), uint(1)). Each is a
one-line body `ImPlotNative.ImPlot_PlotBars_*(Encoding.UTF8.GetBytes(labelId), values, count, ...)`.
Passing null for the first string `labelId` throws `ArgumentNullException` at the call site before any
native call.

NOTE on signatures (matched exactly): only the `float` overloads use `ref` (variants 0,1,2,4,5 use
`ref float[] values`; variant 3 uses plain `float[]`). All other types use plain `T[] values` in every
overload. The `uint` type has only the base variant 0.

Added `ImPlotP15NullLabelCoverageTests.cs` (43 plain [Fact]) generated to match each exact overload
(`ref` vs non-ref per type/variant), all `Assert.Throws<ArgumentNullException>`.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

The `ImPlotNative.ImPlot_PlotBars_*` P/Invoke call lines and ~11 other native members in the partial
(could not be reached because the exception on GetBytes(labelId) is raised first). Requires native
implot at runtime.

## Verification

- ImPlotP15NullLabelCoverageTests-filtered run: 43 passed / 0 failed (net8.0).
- Full project build (Debug): 0 errors.
- Local coverlet: ImPlotP15.cs 25.4% (86/338 instrumented lines).