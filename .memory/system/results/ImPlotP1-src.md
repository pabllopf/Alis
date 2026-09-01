# Result: ImPlotP1.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP1.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 13.5% (65/480 instrumented lines, local coverlet, ImPlotP1NullLabelCoverageTests run)
TestsAdded: 31 (ImPlotP1NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP1.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP1.cs is a `public static partial class ImPlot` partial holding ~65 static wrappers. 31 of
them take a `string` param (name/label/groupId/labelId/titleId/plotTitleId/fmt/format) that flows
into `Encoding.UTF8.GetBytes(...)`, and each body is a single line whose first statement is that
`GetBytes` call (no managed prelude loop). Passing null for the first string makes
`Encoding.UTF8.GetBytes(null)` throw `ArgumentNullException` at the call site before any native
P/Invoke.

Added `ImPlotP1NullLabelCoverageTests.cs` (31 plain `[Fact]`, deterministic on every platform):
- AddColormap fast(4) — Vec4Ptr/U32Ptr × qual.
- Annotation(fmt) (1).
- BeginAlignedPlots (2), BeginDragDropSourceItem (2), BeginLegendPopup (2).
- BeginPlot (3), BeginSubplots (4, incl. ref-row/col-ratios).
- BustColorCache (1), ColormapButton (3).
- ColormapScale (5, label+format), ColormapSlider (4, label+format).
Each throws from an evaluation-path `GetBytes(null)` line, covering the wrapper signature line and
the `GetBytes(...)` statement line.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

- The native `ImPlotNative.ImPlot_*` P/Invoke call line and pure native-boundary branches of the
  ~34 remaining methods (CreateContext/DestroyContext/DragLine/DragPoint/DragRect/End*/etc.) that
  have no string prelude. Entering these requires the native cimgui/implot library at runtime;
  environment-dependent, not coverable deterministically under plain `[Fact]`.

## Verification

- ImPlotP1NullLabelCoverageTests-filtered run: 31 passed / 0 failed (net8.0).
- Full project build (Debug): 0 warnings / 0 errors.
- Local coverlet: ImPlotP1.cs 13.5% (65/480 instrumented lines).