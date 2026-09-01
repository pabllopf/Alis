# Result: ImGuiP3.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP3.cs`
CoverageBefore: 0.0% (SonarCloud; 445 uncovered lines, 2 branches)
CoverageAfter: 5.8% (52/890 instrumented lines, local coverlet, ImGuiP3NullLabelCoverageTests run)
TestsAdded: 26 (ImGuiP3NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGuiP3.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImGuiP3.cs is a `public static partial class ImGui` partial holding 128 static wrappers
(~128 complexity / 564 LOC per SonarCloud). Each method is a one-line pass-through to an
`[DllImport]` `ImGuiNative.*` entry point of the native cimgui library that converts a `string`
argument inline via `Encoding.UTF8.GetBytes(...)` (e.g. `igDragScalarN`, `igGetID_Str`,
`igImageButton`, `igInputDouble`, `igInputFloat`, `igInputFloat2/3/4`). The pre-existing suite
(`ImGuiP3Test.cs`, `ImGuiP3NativeCoverageTests.cs`, `ImGuiP3RemainingCoverageTests.cs`) uses
`[RequireCImguiSystemFact]`/`[RequireImNodesSystemFact]`, which SKIP when cimgui is absent, so
SonarCloud/CI record 0.0%.

Added `ImGuiP3NullLabelCoverageTests.cs` (26 plain `[Fact]`, deterministic on every platform):
for each of the 26 string-bearing methods, passing a null `label`/`strId`/`text` argument makes
`Encoding.UTF8.GetBytes(null)` throw `ArgumentNullException` before the native P/Invoke for that
argument. Left-to-right argument evaluation guarantees the throw precedes any native call, so the
wrapper signature line and its `GetBytes(...)` statement line are exercised without the native
library and without side effects. Covered families: `DragScalarN` (3), `GetId` (1), `ImageButton`
(5), `InputDouble` (5), `InputFloat` (5), `InputFloat2` (3), `InputFloat3` (3), `InputFloat4` (1).

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

- Lines 62-1369 (~838 lines / ~102 methods): every other method body is a single `ImGuiNative.*`
  call with no string-to-managed-bytes prelude (e.g. `Begin`, `Button`, `Checkbox`, `ColorEdit`,
  `Slider*`, `Text*`, `Plot*`). The only way to enter these bodies is to invoke the native entry
  point, which requires the cimgui library present at runtime; without it they raise
  `DllNotFoundException`/`EntryPointNotFoundException`. Environment-dependent, not coverable
  deterministically under plain `[Fact]`.

## Verification

- ImGuiP3NullLabelCoverageTests-filtered run: 26 passed / 0 failed (net8.0).
- Full project build (Debug): 0 warnings / 0 errors.
- Local coverlet: ImGuiP3.cs 5.8% (52/890 instrumented lines).