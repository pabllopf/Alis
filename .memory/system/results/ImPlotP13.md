# ImPlotP13.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP13.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 77.35% (123/159 lines)
- **Tests Added**: 7 (ImPlotP13ExecutionTests.cs, macOS-only, real native cimgui execution)
- **Uncovered Lines**: 12 PlotStairs overloads (ref short/int/uint ×4 each) — ImPlotNative S16Ptr/S32Ptr/U32Ptr bindings take pointer params by value (SIGSEGV); production binding bugs
- **Status**: COMPLETED
