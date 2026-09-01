# Result: ImGuiP4.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP4.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 30.6% (131/428 instrumented lines, local coverlet, ImGuiP4NullLabelCoverageTests run)
TestsAdded: 60 (ImGuiP4NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGuiP4.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImGuiP4.cs is a `public static partial class ImGui` partial with 60 string-converting wrappers. 42
of them take one or more string params that flow into `Encoding.UTF8.GetBytes(...)`; there are NO
managed prelude loops. Every method's body either calls `GetBytes(firstString)` as the first
statement or forwards (via `=>`) to a full-form overload that does. Passing null for the first
string throws `ArgumentNullException` at the call site before any native P/Invoke.

Added `ImGuiP4NullLabelCoverageTests.cs` (60 plain `[Fact]`, deterministic on every platform):
- TableSetupColumn × 3, Text, TextColored, TextDisabled, TextUnformatted, TextWrapped.
- TreeNode × 3, TreeNodeEx × 4, TreePush.
- Value × 5, VSliderFloat × 3, VSliderInt × 3, VSliderScalar × 3.
- InputText byte[] × 4, IntPtr × 3, ref string × 4; InputTextMultiline × 3; InputTextWithHint × 4.
- CalcTextSize × 11, Begin.

For methods with `ref string input` / `ref int` / `ref float` / `IntPtr` args, those are given
non-null neutral values so the null FIRST string is the one flowing into `GetBytes(null)` and
throws deterministically. Each throws before the native call, covering the wrapper signature line
and the `GetBytes(...)` statement line.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

- The `ImGuiNative.ig*` P/Invoke call line and pure native-boundary statements (not reached because
  the exception is raised first), plus non-string methods (TableSetupScrollFreeze, TreePop,
  Unindent, UpdatePlatformWindows, TreePush(IntPtr), etc.). Requires native cimgui at runtime; not
  coverable deterministically under plain `[Fact]`.

## Verification

- ImGuiP4NullLabelCoverageTests-filtered run: 60 passed / 0 failed (net8.0).
- Full project build (Debug): 0 warnings / 0 errors.
- Local coverlet: ImGuiP4.cs 30.6% (131/428 instrumented lines).