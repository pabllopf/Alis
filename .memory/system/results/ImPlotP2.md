# Result: ImPlotP2.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP2.cs`
CoverageBefore: 1.6% (SonarCloud stale; local coverlet 760/904 = 84.1%)
CoverageAfter: 84.1% (760/904 lines, local coverlet; unchanged)
TestsAdded: 0 (remaining lines crash the host; blocked)
Commit: test: coverage ImPlotP2.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP2.cs is a large `ImPlot` partial (110 complexity / 534 LOC per SonarCloud) holding the
state-query wrappers (GetPlotLimits/GetPlotSelection/GetPlotMousePos family), the plot
Begin/End lifecycle (EndDragDropTarget/EndLegendPopup/EndSubplots/IsSubplotsHovered) and the
32 `PlotBarGroups` array overloads. The committed suite (`ImPlotP2Test.cs` /
`ImPlotP2Tests.cs` with real native ImGui+ImPlot contexts, `ImPlotP2RemainingCoverageTests.cs`)
covers 760/904 lines locally (84.1%); targeted run: 361 passed / 0 failed on
`Alis.Extension.Graphic.Ui.Test` (net8.0).

Covered: context/colormap queries, GetPlotMousePos, GetPlotPos/GetPlotSize/GetPlotDrawList,
IsAxisHovered/IsLegendEntryHovered/IsPlotHovered/IsPlotSelected, HideNextItem,
NextColormapColor, PixelsToPlot, ItemIcon, MapInputDefault/Reverse, and the PlotBarGroups
overload bodies up to the P/Invoke call.

## Remaining uncovered lines — BLOCKED_BY_PRODUCTION_CODE

Two distinct families, both verified unsafe by probing:

1. Native-state-requiring wrappers (lines 45-47 EndDragDropTarget, 53-55 EndLegendPopup,
   69-71 EndSubplots, 406-409 IsSubplotsHovered, and the GetPlotLimits overloads 191-196/
   204-208/217-220, GetPlotSelection overloads 273-278/286-290/299-302). Calling them inside an
   active plot (paired with the documented Begin counterparts) aborts the test host with
   `BadImageFormatException: Index not found (0x80131124)` — the installed cimgui build's
   internal state checks (BeginSubplots/legend/drag-drop plumbing) do not survive the wrapper's
   P/Invoke ABI for these entry points. Probe attempt: 11 tests failed and the run had to be
   reverted; the baseline suite is otherwise green.

2. PlotBarGroups closing braces (lines 571, 591, 612, 634, 653, 673, 694, 716, 735, 755, 776,
   798, 817, 837, 858, 880, 899, 919, 940, 962, 981, 1001, 1022, 1044, 1063, 1083, 1104, 1126,
   1145). Same `byte[][]` jagged-label marshalling defect as ImPlotP15/ImPlot.cs: the default
   interop marshaller rejects jagged arrays with `MarshalDirectiveException` before the native
   function is entered, so the call site is hit but the method can never complete — closing
   braces are unreachable without production interop changes.

## Verification

- Targeted run: 361 passed / 0 failed (net8.0).
- Local coverlet: ImPlotP2.cs partial 760/904 lines (84.1%).
- Probe (reverted): plot-state queries + Begin/End pairs crash the host.
