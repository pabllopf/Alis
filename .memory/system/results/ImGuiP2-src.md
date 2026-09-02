# Result: ImGuiP2.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP2.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 25.8% (83/322 instrumented lines, local coverlet, ImGuiP2NullLabelCoverageTests run)
TestsAdded: 39 (ImGuiP2NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGuiP2.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImGuiP2.cs is a `public static partial class ImGui` partial holding 39 Drag* overloads, each body a one-line
`ImGuiNative.igDrag*(Encoding.UTF8.GetBytes(label), ...)` call. Null first string `label` throws
`ArgumentNullException` at the call site before any native P/Invoke (label is the first string, marshaled
via Encoding.UTF8 at the call site). Flags enum `ImGuiSliderFlags`; data type enum `ImGuiDataType.S32`.

Families (signatures matched exactly):
- DragInt: 5 (vSpeed, vMin, vMax, format, flags) — no bare-base overload.
- DragInt2 / DragInt3 / DragInt4: 6 each (base, vSpeed, vMin, vMax, format, flags).
- DragIntRange2: 7 (base, vSpeed, vMin, vMax, format, formatMax, flags).
- DragScalar: 6 (IntPtr-based; base, vSpeed, pMin, pMax, format, flags).
- DragScalarN: 3 (base, vSpeed, pMin).

Total 39. Added `ImGuiP2NullLabelCoverageTests.cs` (39 plain [Fact]) matching each exact overload and
parameter mode, using `ref int` locals / `(string)null` casts to resolve overloads, all
`Assert.Throws<ArgumentNullException>`.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

The `ImGuiNative.igDrag*` P/Invoke call lines (not reached because the exception on GetBytes(label) is
raised first). Requires native cimgui at runtime.

## Verification

- ImGuiP2NullLabelCoverageTests-filtered run: 39 passed / 0 failed (net8.0).
- Full project build (Debug): 0 errors.
- Local coverlet: ImGuiP2.cs 25.8% (83/322 instrumented lines).