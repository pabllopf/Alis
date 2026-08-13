# ImGuiP5.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP5.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 82.38% (304/369 lines)
- **Tests Added**: 7 (ImGuiP5ExecutionTests.cs, macOS-only, real native cimgui execution)
- **Uncovered Lines**: BeginTabItem (3), BeginPopupModal open path (3), CheckboxFlags (2), CollapsingHeader ref bool (2), ColorEdit3 (2), ColorPicker3/4 (5), AcceptDragDropPayload (2), Combo post-throw (4) — native binding bugs (bool*/float*/int* marshaled by value) crash the native host; Combo throws MarshalDirectiveException
- **Status**: COMPLETED
