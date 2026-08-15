# Result: ImGuizMo.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/GuizMo/ImGuizMo.cs`
CoverageBefore: 0.0% (SonarCloud stale; local coverlet 292/298 = 98.0%)
CoverageAfter: 98.0% (292/298 lines, local coverlet; unchanged)
TestsAdded: 0 (DrawCubes body unreachable; production interop defect)
Commit: test: coverage ImGuizMo.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

ImGuizMo.cs is the `ImGuizMo` static partial for the ImGuizmo gizmo wrappers (27 complexity /
182 LOC per SonarCloud). The committed suite (`ImGuizMoTest.cs`, `ImGuizMoExecutionTests.cs`
with real native ImGui context, `ImGuizMoContextCoverageTests.cs`,
`ImGuizMoRemainingCoverageTests.cs` — commit 4f6359c74) covers 292/298 lines locally (98.0%);
targeted run: 46 passed / 2 skipped / 48 total on `Alis.Extension.Graphic.Ui.Test` (net8.0).

Covered: every wrapper except `DrawCubes` — BeginFrame, DecomposeMatrixToComponents, DrawGrid,
Enable/IsUsing, gizmo operation set/get, viewport, style color/dimensions, lambda and callback
API, context management.

## Remaining uncovered lines (3) — BLOCKED_BY_PRODUCTION_CODE

- 158-160 — the entire `DrawCubes` body
  (`ImGuiZmoNative.InternalDrawCubes(view, projection, matrices, matrixCount)`).

`ImGuiZmoNative.InternalDrawCubes` (ImGuiZmoNative.cs:78) declares `float view, float projection,
float matrices` **by value**, but the native `ImGuizmo_DrawCubes` expects `const float*`
pointers. The wrapper receives `ref float view` etc. and forwards the values un-boxed; the
marshaller places the literal value (e.g. 0x3F800000 for 1.0f) in the pointer register, and the
first native dereference segfaults the test host. Same defect family as ImPlot.cs PlotStems
`ref int`/`ref uint`, ImPlotP22 PlotLine `ref short`, ImPlotP13 PlotStairs `ref short/int/uint`.
The only existing test (`DrawCubes_WithoutNativeLibrary_Throws`) is guarded by
`!CanLoadCImguiLibrary()` and no-ops on this machine where the library loads. No test can reach
the call line without modifying `src/` interop signatures.

## Verification

- Targeted run: 46 passed / 2 skipped / 48 total (net8.0).
- Local coverlet: ImGuizMo.cs 292/298 lines (98.0%).
