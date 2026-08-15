# ImFontPtr.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/ImFontPtr.cs`
- **Coverage Before**: 6.3% (SonarCloud)
- **Coverage After**: 100.0% line and branch (120/120 lines, local coverlet with the full ImFontPtr filter, net8.0)
- **Tests Added**: 3 (ImFontPtrCoverageTests.cs — RenderChar with framed context, AddRemapChar overwrite true/false)
- **Skipped**: none. The previous entry reported RenderChar as blocked by a native crash; that crash was caused by running `igNewFrame` without synchronizing the GImGui slot across the multiple loaded cimgui dylib copies. Replicating the `SyncContextSlots` pattern from ImGuiP3ExecutionTests lets `RenderChar` run inside a real frame, and it passes.
- **Status**: COMPLETED
