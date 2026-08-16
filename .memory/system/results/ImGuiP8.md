# Result: ImGuiP8.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP8.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 93.4% (113/121, local coverlet)
TestsAdded: 0 (already remediated in commit 3f4bf404b)
Commit: test: coverage ImGuiP8.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

ImGuiP8.cs is the ImGui slider-family partial (Sliders, SliderScalar, SliderFloat1-4 overloads)
over `ImGuiNative.igSlider*` P/Invokes. Committed `ImGuiP8Test.cs`/`ImGuiP8Tests.cs`/
`ImGuiP8ExecutionTests.cs`/`ImGuiP8RemainingCoverageTests.cs`/`ImGuiP8SliderTests.cs` cover
113/121 lines (93.4%).

## Remaining uncovered (8 lines) — BLOCKED_BY_PRODUCTION_CODE

Lines 402-403 / 405-406 / 418-419 / 421-422: the two `SliderFloat4(label, ref Vector4F, ...)`
overloads. The native `igSliderFloat4` receives the `Vector4F` marshaled by value where the
native signature expects `const float*` — the call-site line is hit but the native call
SIGSEGVs the host, so `return ret != 0` and the closing brace are unreachable. Same production
binding defect as ImGuiP1's DragFloat4.

## Verification

- `dotnet test Alis.Extension.Graphic.Ui.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~ImGuiP8"`: 51 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): `ImGuiP8.cs` 113/121 = 93.4%, identical to
  the committed result (93.38%).
