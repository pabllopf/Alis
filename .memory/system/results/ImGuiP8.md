# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Ui/src/ImGuiP8.cs
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 93.4% (local existing suite, 113/121 lines; verified via XPlat Code Coverage)
TestsAdded: 0
Commit: (none)
Status: BLOCKED_BY_PRODUCTION_CODE
Details:
- Existing committed suite (ImGuiP8ExecutionTests/ImGuiP8Test/ImGuiP8RemainingCoverageTests/ImGuiP8SliderTests, 51 tests) already covers 93.4% when cimgui native lib is loadable.
- Remaining uncovered: SliderFloat4 overloads (lines 402-406, 418-422 in ImGuiP8.cs).
- Adding an execution test for SliderFloat4 reproducibly crashes the native test host: assertion in SliderBehavior (imgui_widgets.cpp:2880, invalid ImGuiSliderFlags). Root cause is production P/Invoke defect: ImGuiNative.igSliderFloat4 marshals Vector4F by value (ImGuiNative.cs:3098-3099) while native igSliderFloat4(const char*, float* v, ...) expects a pointer. Source protection forbids editing production code.
- Reworked test addition was fully reverted; tree is clean for this file.