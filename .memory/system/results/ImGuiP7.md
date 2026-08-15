# Result: ImGuiP7.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP7.cs`
CoverageBefore: 0.6% (SonarCloud; local coverlet 838/978 = 85.7%)
CoverageAfter: 93.5% (914/978 lines, local coverlet; +7.8%)
TestsAdded: 19 (null-label overload probes: PlotHistogram×7, PlotLines×7, Selectable×3, SetDragDropPayload×2)
Commit: test: coverage ImGuiP7.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImGuiP7.cs is a large `ImGui` partial (155 complexity / 640 LOC per SonarCloud). The committed
suite (`ImGuiP7Test.cs` / `ImGuiP7Tests.cs` / `ImGuiP7ExecutionTests.cs` /
`ImGuiP7RemainingCoverageTests.cs` / `ImGuiP7NativeCoverageTests.cs` /
`ImGuiP7WorkerTests.cs` / `ImGuiP7NativeTest.cs`) covered 838/978 lines; 18 string-taking
wrapper bodies (PlotHistogram/PlotLines `ref float` overloads, Selectable `ref bool` overloads,
SetDragDropPayload overloads) were not exercised by any test.

## Work performed

Added 19 null-label tests to `ImGuiP7Test.cs` following the `RequireCImguiSystemFact` +
`Assert.Throws<ArgumentNullException>` convention (same as ImPlotP22/P13). Each wrapper calls
`Encoding.UTF8.GetBytes(label)` first, so a null label throws ArgumentNullException at the call
site — the wrapper body is entered and the P/Invoke call line is covered without entering native
code. Targeted run: 235 passed / 0 failed on `Alis.Extension.Graphic.Ui.Test` (net8.0).

## Remaining uncovered lines (32) — BLOCKED_BY_PRODUCTION_CODE

- 155, 167, 180, 194, 209, 225, 242 — PlotHistogram closing braces; 253, 265, 278, 292, 307,
  323, 340 — PlotLines closing braces. The `ref float` value is forwarded by value to
  `igPlotHistogram_FloatPtr`/`igPlotLines_FloatPtr` whose DllImports declare `float values`
  (ImGuiNative.cs:2006/2021) while the native side expects `const float*` — a successful return
  is impossible (by-value-pointer family).
- 799-800, 812-813, 826-827 — Selectable `return ret != 0;` and closing braces: `pSelected`
  forwarded by value to `igSelectable_BoolPtr` (ImGuiNative.cs:2276) while native expects
  `bool*`; the null-label exception prevents the return line.
- 843-846, 855-858 — SetAllocatorFunctions bodies. Calling `igSetAllocatorFunctions` with the
  test's IntPtr.Zero allocators would install null global allocators and crash every subsequent
  ImGui allocation in the host process; the committed RemainingCoverageTests only exercise these
  when the library is unavailable. Untestable without production changes.
- 954-955, 968-969 — SetDragDropPayload return and closing braces (unreachable after the
  null-type exception at the call).

## Verification

- Targeted run: 235 passed / 0 failed (net8.0).
- Local coverlet: ImGuiP7.cs partial 914/978 lines (93.5%).
