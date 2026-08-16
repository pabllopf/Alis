# Result: ImPlotP9.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP9.cs`
CoverageBefore: 80.7% (SonarCloud); local coverlet baseline 79.7% line (177/222)
CoverageAfter: 84.2% line (187/222, local coverlet, net8.0)
TestsAdded: 3 (ImPlotP9ExecutionTests.cs)
Commit: test: coverage ImPlotP9.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP9.cs is a partial class of thin cimgui wrappers (PlotLine S32/U32/S64/U64 overloads,
PlotLineG, PlotPieChart for 7 value types). The committed tests are vacuous on hosts where the
native library loads (their `if (!CanLoadCImguiLibrary())` guards are empty). Following the
established ImPlotP10/P11 execution pattern, real ImGui+ImPlot contexts are created natively
(dyld context-slot sync) and the wrappers are invoked inside an active plot.

## Work performed

Added 3 tests to `ImPlotP9ExecutionTests.cs` (xUnit, net8.0, `[RequireImNodesSystemFact]`):
- `PlotLine_S64_Overloads_Execute_Inside_Plot` — all 4 long overloads (lines 158-200).
- `PlotLine_U64_Overloads_Execute_Inside_Plot` — all 4 ulong overloads (lines 212-254).
- `PlotLineG_Overloads_Execute_Inside_Plot` — both getter overloads via a Cdecl function
  pointer (lines 266-279).

Each runs inside `BeginPlot`/`SetupAxes`/`SetupFinish`/`EndPlot` with fresh native contexts.

## Remaining uncovered lines — BLOCKED_BY_PRODUCTION_CODE

- 50-146 — PlotLine int (S32) and uint (U32) overloads: the native `ImPlot_PlotLine_S32PtrS32Ptr`
  and `ImPlot_PlotLine_U32PtrU32Ptr` entry points HANG the test host on this machine
  (verified per-overload with a 90s timeout, probe test class; also hangs with a single
  `PlotLine(..., count=1)` call). Native library defect in this cimgui build.
- 298-729 — PlotPieChart overloads (float/double/sbyte/byte/short/ushort): all
  `ImPlot_PlotPieChart_*` entry points hang the test host identically. Native library defect.

## Verification

- Targeted run: 3 passed / 0 failed (net8.0).
- Merged suite (ImPlotP9 filter): all pass; ImPlotP9.cs 187/222 = 84.2% line (was 79.7%).
- Hang probes removed after verification (ScratchImPlotP9Probe.cs not committed).
