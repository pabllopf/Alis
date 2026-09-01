# Result: ImPlotP2.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP2.cs`
CoverageBefore: 0.0% (SonarCloud; 446 uncovered lines, 60 branches)
CoverageAfter: 6.7% (60/892 instrumented lines, local coverlet, ImPlotP2NullItemCoverageTests run)
TestsAdded: 30 (ImPlotP2NullItemCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotP2.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP2.cs is a `public static partial class ImPlot` partial holding 80 static wrappers
(~109 complexity / 528 LOC per SonarCloud). Most methods are one-line pass-throughs to an
`[DllImport]` `ImPlotNative.*` entry point of the native cimgui library, with no managed
prelude. The pre-existing suite (`ImPlotP2Test.cs`, `ImPlotP2Tests.cs`) exercises these via
`[RequireImNodesSystemFact]`/`[RequireImNodesSystemFact]` and inside an active native plot,
all of which SKIP when cimgui is absent, so SonarCloud/CI record 0.0%.

The deterministically-coverable surface without a native library is the `PlotBarGroups`
overloads whose bodies build a `byte[][] nativeLabelIds` by converting each `string` label
with `Encoding.UTF8.GetBytes(s)` inside a managed loop *before* the native call, plus the two
string-first methods `GetColormapIndex(string name)` and `IsLegendEntryHovered(string labelId)`.

Added `ImPlotP2NullItemCoverageTests.cs` (30 plain `[Fact]`, deterministic on every platform):
- 28 `PlotBarGroups` probes (7 value types float/double/sbyte/byte/short/ushort/int x 4
  overload shapes each): pass `string[] { "A", null }`, which throws `NullReferenceException`
  at the `Encoding.UTF8.GetBytes(s)` prelude, covering the wrapper signature line and the
  `byte[][] nativeLabelIds = new byte[labelIds.Length][];` allocation line before any native
  invocation.
- 1 `GetColormapIndex` probe: null name throws `ArgumentNullException` at `GetBytes(null)`.
- 1 `IsLegendEntryHovered` probe: null labelId throws `ArgumentNullException`.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

- Lines 60-1118 (~832 lines): every other method body is a single `ImPlotNative.*` call with
  no managed prelude (EndDragDropTarget, EndPlot, GetCurrentContext, IsPlotHovered,
  PullColormap, SetNextLineStyle, etc.). The only way to enter them is to invoke the native
  entry point, requiring the cimgui library at runtime; without it they raise
  `DllNotFoundException`/`EntryPointNotFoundException`. Environment-dependent, not coverable
  deterministically under plain `[Fact]`.
- Line 1135 (`uint[]` PlotBarGroups): the single `uint` overload calls
  `ImPlotNative.ImPlot_PlotBarGroups_U32Ptr(labelIds, ...)` directly with raw strings — no
  managed `GetBytes` prelude, so nothing is coverable without native code.

## Verification

- ImPlotP2NullItemCoverageTests-filtered run: 30 passed / 0 failed (net8.0).
- Full project build (Debug): 0 warnings / 0 errors.
- Local coverlet: ImPlotP2.cs 6.7% (60/892 instrumented lines).