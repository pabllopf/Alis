# ImGuizMo.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/Extras/GuizMo/ImGuizMo.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 98.0% (146/149 lines)
- **Tests Added**: 8 (ImGuizMoExecutionTests.cs, macOS-only, real native cimgui execution; all 20 wrappers)
- **Uncovered Lines**: DrawCubes — native dereferences gContext.DrawList (abort even with SetDrawList); other draw calls fixed via SetDrawList() inside window
- **Status**: COMPLETED
