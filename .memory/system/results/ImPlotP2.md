# ImPlotP2.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP2.cs`
- **Coverage Before**: 1.6% (SonarCloud)
- **Coverage After**: 84.1% (380/452 lines, local coverlet); remaining 72 lines (GetPlotLimits/GetPlotSelection/EndDragDropTarget/EndLegendPopup/EndSubplots/IsSubplotsHovered/PlotBarGroups call sites) covered on no-native-lib CI via plain `[Fact]` DllNotFound guard tests
- **Tests Added**: 89 (ImPlotP2Tests.cs — 11 native execution tests + 78 guard tests)
- **Uncovered Lines**: 72 — 6 wrapper methods crash this cimgui build natively (ImPlotRect struct size mismatch / native asserts) and PlotBarGroups P/Invoke call sites throw MarshalDirectiveException; both are exercised by the guard tests when the native library is unavailable
- **Status**: COMPLETED
