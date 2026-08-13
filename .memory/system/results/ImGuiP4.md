# ImGuiP4.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP4.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 74.77% (160/214 lines)
- **Tests Added**: 9 (ImGuiP4ExecutionTests.cs, macOS-only, real native cimgui execution)
- **Uncovered Lines**: CalcTextSize (11) — binding passes `byte` where native expects `const char*` (SIGSEGV in ImFont::CalcTextSizeA); InputText (12) — all wrappers forward IntPtr.Zero buffer (native assert abort). Production binding bugs; requires src change.
- **Status**: BLOCKED_BY_PRODUCTION_CODE
