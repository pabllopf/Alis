# ImGuiP8.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP8.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 93.38% (113/121 lines)
- **Tests Added**: 7 (ImGuiP8ExecutionTests.cs, macOS-only, real native cimgui execution)
- **Uncovered Lines**: SliderFloat4 (2 overloads) — Vector4F marshaled by value where native expects const float* (SIGSEGV); production binding bug (same as ImGuiP1 DragFloat4)
- **Status**: COMPLETED
