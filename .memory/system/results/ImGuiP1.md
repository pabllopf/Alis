# Result: ImGuiP1.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP1.cs`
CoverageBefore: 0.0% (SonarCloud stale; local coverlet 344/392 = 87.8%)
CoverageAfter: 87.8% (344/392 lines, local coverlet; unchanged)
TestsAdded: 0 (blocked)
Commit: test: coverage ImGuiP1.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

ImGuiP1.cs is an `ImGui` partial (46 complexity / 250 LOC per SonarCloud) with the Combo,
CreateContext, Debug*, DockSpace, DragFloat/DragFloat2/DragFloat3/DragFloat4, DragFloatRange2
and DragInt families. The committed `ImGuiP1ExecutionTests.cs` / `ImGuiP1Test.cs` /
`ImGuiP1RemainingCoverageTests.cs` (real cimgui contexts, framed windows, `[MacOsOnly]`) already
cover 344/392 lines (87.8%). The only uncovered code is the body of the six `DragFloat4`
overloads (24 lines: 486-489, 499-502, 513-516, 528-531, 544-547, 561-564).

## Remaining uncovered lines (24) — BLOCKED_BY_PRODUCTION_CODE

All 24 lines belong to the `DragFloat4(string label, ref Vector4F v, ...)` overloads
(ImGuiP1.cs lines 485-565). Each body calls
`ImGuiNative.igDragFloat4(label, v, vSpeed, vMin, vMax, format, flags)` where the native
declaration at ImGuiNative.cs:611 is:

```
public static extern byte igDragFloat4(byte[] label, Vector4F v, float vSpeed, float vMin,
    float vMax, byte[] format, ImGuiSliderFlags flags);
```

The `Vector4F v` is passed BY VALUE (missing `ref`), inconsistent with `igDragFloat` /
`igDragFloat2` / `igDragFloat3` which use `ref float` / `ref Vector2F` / `ref Vector3F`. The
wrapper passes the dereferenced `ref Vector4F` into a by-value slot while the native
`ImGui::DragFloat4(const char*, float v[4], ...)` reads the register value as a pointer →
segfault. Identical defect family to `igSliderFloat4` (ImGui.cs, also blocked) and to
AddColormap / DragPoint / ColormapSlider. The dylib does export `igDragFloat4`, so a test
would reach native and crash the whole test host; the existing gated test
`DragFloat4_1_WithoutNativeLibrary_Throws` only covers the no-library path (silent no-op when
`libcimgui.dylib` loads).

Full suite: 7598 passed, 0 failed, 14 platform-gated skipped.
