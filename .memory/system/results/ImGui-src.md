# Result: ImGui.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGui.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 12.7% (50/394 instrumented lines, local coverlet, ImGuiNullLabelCoverageTests run)
TestsAdded: 25 (ImGuiNullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGui.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImGui.cs is a `public static partial class ImGui` partial. 25 methods convert a `string` label (or
`scene`) into a native byte buffer via `Encoding.UTF8.GetBytes(...)` as the first statement of a
one-line body (no managed prelude loop). Passing null for the label throws `ArgumentNullException`
at the call site before any native P/Invoke.

Added `ImGuiNullLabelCoverageTests.cs` (25 plain `[Fact]`, deterministic on every platform):
- SliderFloat4 (1), SliderInt/SliderInt2/SliderInt3/SliderInt4 (3 each = 12), SliderScalar (3),
  SliderScalarN (3), SmallButton (1), TabItemButton (2), TableHeader (1), TableSetupColumn (1),
  DockBuilderDockWindow (1).

For `ref`/`IntPtr`/`Vector4F` args, neutral non-null values are passed so the null FIRST string is
the one flowing into `GetBytes(null)` and throws deterministically. Each covers the wrapper
signature line and the `GetBytes(label)` statement line.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

- The `ImGuiNative.ig*` P/Invoke call line and pure native-boundary statements (not reached because
  the exception is raised first on the GetBytes argument), plus the ~31 non-string native wrappers
  in the partial. Requires native cimgui at runtime; not coverable deterministically under plain
  `[Fact]`.

## Verification

- ImGuiNullLabelCoverageTests-filtered run: 25 passed / 0 failed (net8.0).
- Full project build (Debug): 0 warnings / 0 errors.
- Local coverlet: ImGui.cs 12.7% (50/394 instrumented lines).