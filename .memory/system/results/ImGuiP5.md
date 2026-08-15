# Result: ImGuiP5.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP5.cs`
CoverageBefore: 91.19% (673/738 lines, local coverlet; SonarCloud stale 0.0%)
CoverageAfter: 91.19%
TestsAdded: 0
Commit: none
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Every remaining uncovered line routes through a production wrapper whose managed signature is
incorrect for the native contract, so exercising it crashes the test host or throws before reaching
native code. No tests can be added without modifying `src/`.

## Per-method root causes

1. `AcceptDragDropPayload` (lines 46, 55-58): the cimgui entry point is
   `return *ImGui::AcceptDragDropPayload(type, flags)` with no NULL guard (verified by
   disassembly), and `ImGui::AcceptDragDropPayload` returns NULL whenever no drag-drop is active
   (`g.DragDropActive == false`). Calling it outside a real drag NULL-derefs → crash.
2. `CheckboxFlags` `ref int` / `ref uint` (769-773, 782-786): pass `flags` **by value** to
   `igCheckboxFlags_IntPtr` / `igCheckboxFlags_UintPtr`, but the native side expects `int*` /
   `uint*` pointers → native reads the literal value as an address → crash.
3. `CollapsingHeader` `ref bool pVisible` overloads (826-830, 839-843): pass `pVisible` **by value**
   to `igCollapsingHeader_BoolPtr` where native expects `bool*` → crash.
4. `ColorEdit3` (940-945, 954-958), `ColorPicker3` (992-997, 1006-1010),
   `ColorPicker4` (1018-1023, 1032-1036, 1046-1051): pass the `Vector3F` / `Vector4F` colour
   **by value** where the native parameter is `float col[3]` / `float col[4]` (which decays to
   `float*`) → crash. The covered `ColorEdit4(IntPtr label, ...)` variants correctly use `ref col`.
5. `BeginTabItem` (605-608, 617-620, 630-633): `BeginTabItem` aborts inside native
   `ImGui::TabItemEx` in this environment (assert, verified via `--blame-crash` minidump); the
   matching `TabItemButton` wrapper runs fine.
6. `Combo` (1099-1109, 1120-1130): pass a `byte[][]` (nested array) to
   `igCombo_Str_arr`, which the default interop marshaller rejects with
   `MarshalDirectiveException: There is no marshaling support for nested arrays` (same defect as
   ImPlot.cs `SetupAxisTicks`).

## Verification

- Native `igAcceptDragDropPayload` wrapper disassembled (no NULL check, unconditional deref).
- The by-value-as-pointer and nested-array patterns were empirically confirmed to crash/throw in
  the sibling files ImPlot.cs and ImGuiP3.cs.
- Full ImGui suite still 3802 passed / 2 skipped — no regressions introduced.
