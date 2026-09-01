# Result: ImGuiP1.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP1.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 19.6% (77/392 instrumented lines, local coverlet, ImGuiP1NullLabelCoverageTests run)
TestsAdded: 36 (ImGuiP1NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGuiP1.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImGuiP1.cs is a `public static partial class ImGui` partial. 36 methods convert a `string` label/text
into a native byte buffer via `Encoding.UTF8.GetBytes(...)` as the argument to an `ImGuiNative.ig*`
P/Invoke. Passing null for the first string throws `ArgumentNullException` at the call site before any
native call.

Added `ImGuiP1NullLabelCoverageTests.cs` (36 plain `[Fact]`, deterministic on every platform):
- Combo (2, `ref int`), DebugCheckVersionAndDataLayout (1), DebugTextEncoding (1),
  DragFloat (6), DragFloat2 (6, `ref Vector2F`), DragFloat3 (6, `ref Vector3F`),
  DragFloat4 (6, `ref Vector4F`), DragFloatRange2 (7, two `ref float`), DragInt (1).

For `ref`/Vector args neutral non-null values are passed so the null FIRST string is the one flowing
into `GetBytes(null)`. For DragFloatRange2 overloads containing `format`/`formatMax`, the `GetBytes(label)`
is evaluated before the `GetBytes("")` prefixed overloads, so null label throws first.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

- The `ImGuiNative.ig*` P/Invoke call line and native-boundary statements (not reached because the
  exception is raised first on the GetBytes argument), plus the ~10 non-string native wrappers
  (CreateContext, DockSpace, DockSpaceOverViewport). Requires native cimgui at runtime.

## Verification

- ImGuiP1NullLabelCoverageTests-filtered run: 36 passed / 0 failed (net8.0).
- Full project build (Debug): 0 errors.
- Local coverlet: ImGuiP1.cs 19.6% (77/392 instrumented lines).