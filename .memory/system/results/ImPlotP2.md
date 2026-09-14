# ImPlotP2.cs Coverage Remediation Result

- File: 1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP2.cs
- CoverageBefore: 13.5% (386 uncovered lines, 60 uncovered branches)
- CoverageAfter: 84.1% (375/446 instrumented lines hit; 71 lines remain uncovered — native-only methods requiring cimgui context)
- TestsAdded: 30
- Commit: test: coverage ImPlotP2.cs
- Status: COMPLETED

Notes:
- GetColormapIndex(string name) and IsLegendEntryHovered(string labelId) are null-guarded by Encoding.UTF8.GetBytes throwing ArgumentNullException before native call. Tests pass.
- PlotBarGroups: 28 loop-based overloads (float/double/sbyte/byte/short/ushort/int x 4) process labelIds in managed code — a null element throws ArgumentNullException at Encoding.UTF8.GetBytes before native. Tests cover all 28 overloads.
- PlotBarGroups uint overload (line 1135) passes labelIds straight to ImPlotNative — excluded per boundary rule.
- Native-only methods (EndDragDropTarget, EndLegendPopup, EndPlot, EndSubplots, GetColormapColor, GetColormapCount, GetColormapName, GetColormapSize, GetCurrentContext, GetInputMap, GetLastItemColor, GetMarkerName, GetPlotDrawList, GetPlotLimits, GetPlotMousePos, GetPlotPos, GetPlotSelection, GetPlotSize, GetStyle, GetStyleColorName, HideNextItem, IsAxisHovered, IsPlotHovered, IsPlotSelected, IsSubplotsHovered, ItemIcon, MapInputDefault, MapInputReverse, NextColormapColor, PixelsToPlot) require cimgui native library — cannot be tested headless.
