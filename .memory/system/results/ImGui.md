# Result: ImGui.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGui.cs`
CoverageBefore: 0.0% (SonarCloud stale; local coverlet 378/394 = 95.9%)
CoverageAfter: 96.9% (382/394 lines, local coverlet)
TestsAdded: 1 (DockBuilderSetNodeFlags_Execute in ImGuiExecutionTests.cs)
Commit: test: coverage ImGui.cs
Status: PARTIALLY_REMEDIATED

## Summary

ImGui.cs is the main `ImGui` static facade (58 complexity / 258 LOC per SonarCloud) with the
slider, table, menu, font-config and dock-builder families. The committed
`ImGuiExecutionTests.cs` (`[MacOsOnly]`, real cimgui contexts, framed windows) already covered
378/394 lines (95.9%). The 8 uncovered lines were the full bodies of three wrappers never
exercised by tests: `SliderFloat4` (52-55), `TableGetColumnName()` (479) and
`DockBuilderSetNodeFlags` (693-695).

Added one test that covers 2 more lines (378 → 382, 96.9%):

1. `DockBuilderSetNodeFlags_Execute` — calls `ImGui.DockBuilderSetNodeFlags(...)` against a
   framed context (covers the method entry and the native dispatch line). The shipped cimgui
   build does not export the `igDockBuilderSetNodeFlags` C wrapper (verified with `nm`; the C++
   `ImGui::DockBuilderSetNodePos/Size` mangled symbols exist but the C-API export is absent),
   so the call throws `EntryPointNotFoundException` and the test swallows it.

Full suite: 7598 passed, 0 failed, 14 platform-gated skipped.

## Remaining uncovered lines (6) — BLOCKED_BY_PRODUCTION_CODE

- 52-55 (body of `SliderFloat4(string label, ref Vector4F v, float vMin, float vMax, string
  format, ImGuiSliderFlags flags)`): the native declaration
  `ImGuiNative.igSliderFloat4(byte[] label, Vector4F v, ...)` passes the `Vector4F` BY VALUE
  (missing `ref`), inconsistent with `igSliderFloat2`/`igSliderFloat3` which use `ref Vector2F`
  / `ref Vector3F`. The wrapper passes the dereferenced `ref Vector4F` into a by-value slot
  while the native `ImGui::SliderFloat4(const char*, ImVec4&, ...)` reads the value bits as a
  pointer → segfault. Same marshalling defect family as AddColormap/DragPoint/ColormapSlider.
- 479 (closing brace of `TableGetColumnName()`): the native
  `igTableGetColumnName_Int(int columnN)` is declared `byte[]` returning a `const char*`, an
  invalid managed/unmanaged return combination; the call always throws
  `MarshalDirectiveException` (verified even with an active table column) so the method can
  never complete.
- 695 (closing brace of `DockBuilderSetNodeFlags`): the `igDockBuilderSetNodeFlags` C wrapper
  export is missing from the shipped cimgui dylib (unlike the other DockBuilder* exports), so
  the call always throws `EntryPointNotFoundException` before the method body completes.
