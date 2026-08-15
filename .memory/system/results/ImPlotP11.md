# Result: ImPlotP11.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP11.cs`
CoverageBefore: 0.0% (SonarCloud; local coverlet 404/442 = 91.4%)
CoverageAfter: 91.4% (404/442 lines, local coverlet; unchanged)
TestsAdded: 0 (remaining lines unreachable; committed ExecutionTests already cover the bodies)
Commit: test: coverage ImPlotP11.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP11.cs is the `ImPlot` partial holding the 19 `PlotPieChart` overloads (ushort/int/uint/
long/ulong value arrays, 61 complexity / 270 LOC per SonarCloud). The committed suite
(`ImPlotP11ExecutionTests.cs`, `ImPlotP11RemainingCoverageTests.cs`, `ImPlotP11Tests.cs`)
covers 404/442 lines (91.4%). Only the 19 closing braces remain uncovered: lines 58, 80, 103,
123, 144, 166, 189, 209, 230, 252, 275, 295, 316, 338, 361, 381, 402, 424, 447 (the final `}`
of each `PlotPieChart` overload).

Each wrapper marshals the label ids as a jagged `byte[][]` into
`ImPlotNative.ImPlot_PlotPieChart_U16Ptr/U32Ptr/S32Ptr/S64Ptr/U64Ptr(nativeLabelIds, ...)`. The
default interop marshaller rejects jagged `byte[][]` with `MarshalDirectiveException` during
argument marshalling, before the native function runs, so the call site is hit but the method
cannot complete — the closing brace is unreachable. Same `byte[][]` marshalling defect as
`ImPlotP15.PlotBarGroups` and `ImGuiP6.ListBox`. The committed ExecutionTests wrap each call in
`catch (MarshalDirectiveException)` (and a secondary `catch (System.Exception)`).

## Verification

- Full Ui suite passes (7595 passed, 0 failed, 14 platform-gated skipped).
- Local coverlet: ImPlotP11.cs partial 404/442 lines (91.4%); 19 unique uncovered lines, all
  `PlotPieChart` method-closing braces.
- Native declaration `ImPlot_PlotPieChart_*Ptr(byte[][] labelIds, ...)` at ImPlotNative.cs:2309+.
