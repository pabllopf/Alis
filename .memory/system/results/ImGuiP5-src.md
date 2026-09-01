# Result: ImGuiP5.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP5.cs`
CoverageBefore: 0.0% (SonarCloud; 369 uncovered lines, 16 branches)
CoverageAfter: 17.3% (128/738 instrumented lines, local coverlet, ImGuiP5NullLabelCoverageTests run)
TestsAdded: 60 (ImGuiP5NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGuiP5.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImGuiP5.cs is a `public static partial class ImGui` partial holding 91 static wrappers
(60 with a string parameter that flows into `Encoding.UTF8.GetBytes(...)`). Most are one-line
pass-throughs to an `[DllImport]` `ImGuiNative.*` entry point of the native cimgui library.
The pre-existing suite (all `ImGuiP5*.cs` tests) uses gated facts that SKIP without cimgui, so
SonarCloud/CI record 0.0%.

Added `ImGuiP5NullLabelCoverageTests.cs` (60 plain `[Fact]`, deterministic on every platform):
for each of the 58 single-call string wrappers, passing a null `label`/`strId`/`type`/`name`/
`descId`/`fmt`/`id` makes `Encoding.UTF8.GetBytes(null)` throw `ArgumentNullException` before the
native P/Invoke (left-to-right argument order guarantees the throw precedes any native call),
covering the signature line and the `GetBytes(...)` statement line. For the 2 `Combo` overloads
(which have a managed `itemsNative`/`GetBytes(items[i])` prelude loop before the native call),
a null element inside `items` throws in the loop, covering the wrapper signature, the
`byte[][] itemsNative = new byte[items.Length][];` allocation, the loop, and the
`Encoding.UTF8.GetBytes(items[i])` line.

Covered families: AcceptDragDropPayload (2), ArrowButton (1), Begin (3), BeginChild-string (4),
BeginCombo (2), BeginListBox (2), BeginMenu (2), BeginPopup (2), BeginPopupContextItem (2),
BeginPopupContextVoid (2), BeginPopupContextWindow (2), BeginPopupModal (3), BeginTabBar (2),
BeginTabItem (3), BeginTable (4), BulletText (1), Button (2), Checkbox (1), CheckboxFlags (2),
CollapsingHeader (4), ColorButton (3), ColorEdit3 (2), ColorPicker3 (2), ColorPicker4 (3),
Columns-string (2), Combo (2).

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

- Lines 60-1130 (~610 lines): every remaining method body is a single `ImGuiNative.*` call with
  no string-to-managed-bytes prelude (e.g. `BeginChild(uint,..)`, `BeginChildFrame`, `BeginGroup`,
  `BeginTooltip`, `Bullet`, `CalcItemWidth`, `CloseCurrentPopup`, `ColorConvert*`, `BeginMainMenuBar`,
  `BeginDragDropSource`, `BeginDisabled`). Entering these bodies requires invoking the native
  entry point and thus the cimgui library at runtime; without it they raise
  `DllNotFoundException`/`EntryPointNotFoundException`. Environment-dependent, not coverable
  deterministically under plain `[Fact]`.
- `Columns()`/`Columns(int)` and `BeginPopupContextItem()`/`BeginPopupContextVoid()`/
  `BeginPopupContextWindow()` (no-arg forms) hard-code `GetBytes("")` constant strings, so no
  null probe applies.

## Verification

- ImGuiP5NullLabelCoverageTests-filtered run: 60 passed / 0 failed (net8.0).
- Full project build (Debug): 0 warnings / 0 errors.
- Local coverlet: ImGuiP5.cs 17.3% (128/738 instrumented lines).