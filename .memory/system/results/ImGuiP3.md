# Result: ImGuiP3.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP3.cs`
CoverageBefore: 90.79% (808/890 lines, local coverlet; SonarCloud stale 0.0%)
CoverageAfter: 97.98% (872/890 lines)
TestsAdded: 3 (ImGuiP3RemainingCoverageExecutionTests.cs)
Commit: `test: ImGuiP3.cs`
Status: PARTIALLY_REMEDIATED

## Summary

Added `ImGuiP3RemainingCoverageExecutionTests.cs` following the established `ImGuiExecutionTests`
pattern (`CreateFramedContext` + `[MacOsOnly]` + NewFrame/Begin/End/EndFrame cycle). It covers:

1. `EndCombo` (lines 139-141) — the combo popup is forced open with `ImGui.OpenPopup(id)` where the
   popup id is replicated exactly as `BeginCombo` computes it: `ImHashStr("##ComboPopup", 0, GetID(label))`
   via the exported `igImHashStr` helper (seed = `igGetID_Str(label)` inside the window), opened on a
   prior frame so the next-frame `BeginCombo` returns true.
2. `EndMenu` (lines 203-205) — menu popup forced open with `ImGui.OpenPopup("p3-menu")` on a prior
   frame inside a `BeginMenuBar`/`BeginMainMenuBar` context; next-frame `BeginMenu` returns true.
3. `GetColumnIndex`/`GetColumnOffset` (both overloads)/`GetColumnsCount`/`GetColumnWidth` (both
   overloads), lines 350-407 — plain column-state queries executed inside a framed window.

Full ImGui suite: 3802 passed, 2 skipped (previously 3799), no regressions.

## Blocked lines (unremediable without production changes)

- `EndDragDropSource` (155-157) / `EndDragDropTarget` (163-165): the guarded `BeginDragDropSource()` /
  `BeginDragDropTarget()` return false because `g.DragDropActive` is only set by real mouse dragging
  (`UpdateDragDrop` in `igNewFrame`). The native End* assert (`g.DragDropActive` /
  `g.DragDropWithinSource`), so unguarded calls abort the host. Not simulatable via the public API.
- `EndTabItem` (235-237): `BeginTabItem` aborts inside native `ImGui::TabItemEx` (assert at
  imgui.cpp ~line 8144) in this environment even inside a proper `BeginTabBar` frame. Confirmed via
  `--blame-crash` minidump (`TabItemEx + 228` → `__assert_rtn`); a matching `TabItemButton` test
  passes, so the crash is specific to `BeginTabItem`.
