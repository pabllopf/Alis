# Result: ImGuiP6.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP6.cs`
CoverageBefore: 0.0% (SonarCloud; 367 uncovered lines, 16 branches)
CoverageAfter: 11.7% (86/734 instrumented lines, local coverlet, ImGuiP6NullLabelCoverageTests run)
TestsAdded: 39 (ImGuiP6NullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGuiP6.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImGuiP6.cs is a `public static partial class ImGui` partial holding 90 static wrappers
(39 with a string parameter flowing into `Encoding.UTF8.GetBytes(...)`). Most are one-line
pass-throughs to an `[DllImport]` `ImGuiNative.*` entry point of the native cimgui library.
The pre-existing suite (all `ImGuiP6*.cs` tests) uses gated facts that SKIP without cimgui, so
SonarCloud/CI record 0.0%.

Added `ImGuiP6NullLabelCoverageTests.cs` (39 plain `[Fact]`, deterministic on every platform):
for each single-call string wrapper, passing a null `label`/`strId`/`iniFilename`/`iniData`/
`filename`/`fmt` makes `Encoding.UTF8.GetBytes(null)` throw `ArgumentNullException` before the
native P/Invoke, covering the signature line and the `GetBytes(...)` statement line. For the 2
`ListBox` overloads (which have a managed `itemsNative`/`GetBytes(items[i])` prelude loop before
the native call), a null element inside `items` throws in the loop, covering the wrapper
signature, the `byte[][] itemsNative = new byte[items.Length][];` allocation, the loop, and the
`GetBytes(items[i])` line.

Covered families: InputFloat4 (2), InputInt (4), InputInt2 (2), InputInt3 (2), InputInt4 (2),
InputScalar (5), InputScalarN (5), InvisibleButton (2), IsPopupOpen (2), LabelText (1),
ListBox (2), LoadIniSettingsFromDisk (1), LoadIniSettingsFromMemory (2), LogText (1),
LogToFile (1), MenuItem (5).

Note: `LoadIniSettingsFromMemory(string iniData, uint iniSize)` passes `GetBytes(iniData)` and a
`uint` size; a null iniData throws first. `LogToFile(int autoOpenDepth, string filename)` passes
`GetBytes(filename)`; null filename throws.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

- Lines 55-1106 (~648 lines): every remaining method body is a single `ImGuiNative.*` call with
  no string-to-managed-bytes prelude (e.g. the various `Begin*`/`End*`/`Is*`/`Color*`/`Plot*`
  and `Mem*`/`Dummy`/`Separator`/`Set*` helpers). Entering these bodies requires invoking the
  native entry point and thus the cimgui library at runtime. Environment-dependent, not coverable
  deterministically under plain `[Fact]`.

## Verification

- ImGuiP6NullLabelCoverageTests-filtered run: 39 passed / 0 failed (net8.0).
- Full project build (Debug): 0 warnings / 0 errors.
- Local coverlet: ImGuiP6.cs 11.7% (86/734 instrumented lines).