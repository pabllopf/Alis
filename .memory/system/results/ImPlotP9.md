# Result: ImPlotP9.cs

File:
pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP9.cs

CoverageBefore:
80.7% (SonarCloud, line 79.7%; local coverlet baseline 177/222 = 79.7%, 45 uncovered lines — matches SonarCloud exactly)

CoverageAfter:
90.5% line (201/222, local coverlet; 21 uncovered lines, all closing braces of the 21 PlotPieChart overloads, blocked by production interop defect)

TestsAdded:
11 (ImPlotP9AdditionalCoverageTests.cs: 5 native PlotLine/PlotLineG execution tests, 6 PlotPieChart MarshalDirectiveException tests)

Commit:
test: coverage ImPlotP9.cs

Status:
PARTIALLY_REMEDIATED (21 lines BLOCKED_BY_PRODUCTION_CODE)

## Summary

ImPlotP9.cs is the `ImPlot` partial holding the `PlotLine` overloads (S32/U32/S64/U64
ref-array family), `PlotLineG` and the `PlotPieChart` overloads (float/double/sbyte/byte/
short/ushort). Committed suites (ImPlotP9Test.cs null-label probes, ImPlotP9RemainingCoverageTests.cs
guarded no-ops) covered 177/222 lines. The prior session's untracked ImPlotP9ExecutionTests.cs was
never committed and was concurrently overwritten by another agent (repurposed to PlotScatter/
PlotShaded for ImPlotP10); it was left untouched.

## Work performed

Measured local coverlet baseline: 45 uncovered lines, exactly matching SonarCloud. Diagnosed
each uncovered line and added ImPlotP9AdditionalCoverageTests.cs (11 tests, 382 lines):

- PlotLine S32/U32 overloads (8 closing braces, lines 50/63/77/92/104/117/131/146): native
  `ImPlot_PlotLine_S32PtrS32Ptr`/`_U32PtrU32Ptr` declare `int`/`uint` BY VALUE while cimgui
  expects `const ImS32*`/`const ImU32*` (value-as-pointer interop defect). A count of 0 makes
  the native side short-circuit before dereferencing, so the wrappers return cleanly inside a
  real ImGui+ImPlot context (verified by probe). 4+4 native execution tests cover all braces.
- PlotLine S64/U64 overloads (8 closing braces): `ref long`/`ref ulong` marshal as real
  pointers; executed with count 1 inside an active plot (P13-style helper pattern).
- PlotLineG overloads (2 closing braces): executed with a real getter delegate and zero count
  inside an active plot.
- PlotPieChart overloads (21 native-call lines + 21 closing braces): root cause identified —
  `ImPlotNative.ImPlot_PlotPieChart_*Ptr(byte[][] labelIds, ...)` cannot marshal nested arrays:
  `MarshalDirectiveException: There is no marshaling support for nested arrays`, thrown before
  native entry (confirmed by direct ImPlotNative call, with and without null-terminated label
  bytes, inside and outside a plot). Earlier host crashes were the MarshalDirectiveException
  unwinding through an un-ended BeginPlot into `igEndFrame` → `ImGui::ErrorCheckEndFrameSanityChecks`
  abort. The 21 native-call lines are covered by Assert.Throws<MarshalDirectiveException> tests
  executed OUTSIDE a plot (no BeginPlot → no EndFrame abort).

## Remaining uncovered lines (21) — BLOCKED_BY_PRODUCTION_CODE

Closing braces of all 21 PlotPieChart overloads: 299, 320, 342, 365, 385, 406, 428, 451, 471,
492, 514, 537, 557, 578, 600, 623, 643, 664, 686, 709, 729. The wrappers always throw
MarshalDirectiveException at the native-call line (unmarshalable `byte[][]` DllImport
parameter), so the method can never complete. Fixing requires a src/ interop signature change
(e.g., `byte[][]` → `IntPtr` with manual char** layout) — out of scope.

## Verification

- Targeted run: 92/92 passed, 0 failed, no host crash (committed suites 78 + new suite 11 +
  other agent's untracked execution file 3), net8.0.
- Local coverlet: ImPlotP9.cs partial 201/222 lines = 90.5% line (branch-rate 1.0; no branches
  in this file).
- Note: the untracked ImPlotP9ExecutionTests.cs belongs to a concurrent agent's ImPlotP10 work;
  it was not committed here and may change at any time.
