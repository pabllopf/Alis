# ImPlotP22.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP22.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 92.72% (153/165 lines)
- **Tests Added**: 11 (ImPlotP22ExecutionTests.cs, macOS-only, real native cimgui execution; 51/55 PlotLine overloads)
- **Uncovered Lines**: 4 ref short PlotLine overloads — native binding declares by-value short where cimgui expects const short* (SIGSEGV); production binding bug
- **Status**: COMPLETED
