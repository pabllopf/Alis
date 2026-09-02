# Result: ImGuizMo.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/GuizMo/ImGuizMo.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 0.0% (unchanged)
TestsAdded: 0 (none — no deterministic managed logic)
Commit: test: coverage ImGuizMo.cs
Status: BLOCKED_BY_NATIVE

## Summary

ImGuizMo.cs is a `public static class ImGuizMo` native-boundary wrapper over `ImGuiZmoNative` / `ImGuizmo_*`
P/Invoke calls. All 21 public static methods are direct native calls or GCHandle/Marshal marshaling into a
native call (e.g. `Manipulate` pins `float[]` then calls `ImGuiZmoNative.InternalManipulate`; `DrawGrid`,
`DecomposeMatrixToComponents`, `RecomposeMatrixFromComponents`, `ViewManipulate` pass managed `float[]`
through `[DllImport]`; `ShowDemoWindow` depends on `ImGui.Begin` native window state). No string marshaling
(`Encoding.UTF8.GetBytes`) and no deterministic invalid-argument validation that throws managed-side.

The null-array null-probe was empirically tested on macOS in the Ui test project (Recompose/
Decompose/DrawGrid/ViewManipulate/Manipulate with null `float[]`): the test host **segfaulted /
blocked** (`Proceso de host de pruebas bloqueado`), confirming null managed arrays pass a null pointer to
native ImGuizmo which crashes. This class cannot be covered deterministically without a real native
gizmo context.

## Remaining uncovered (BLOCKED_BY_NATIVE)

All method bodies in the file.

## Verification

- No test file generated (record-only task). Probe tests removed after confirming native segfault.
- Full UI test project (filtered existing coverage tests): 50 passed / 0 failed (host healthy).
- Local coverlet: no new coverage (0.0%).