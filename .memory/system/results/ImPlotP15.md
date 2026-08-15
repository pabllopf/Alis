# Result: ImPlotP15.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP15.cs`
CoverageBefore: 0.0% (SonarCloud; local coverlet 426/448 = 95.1%)
CoverageAfter: 95.1% (426/448 lines, local coverlet; unchanged)
TestsAdded: 0 (remaining lines unreachable; committed ExecutionTests already cover the bodies)
Commit: test: coverage ImPlotP15.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP15.cs is the `ImPlot` partial holding the 11 `PlotBarGroups` overloads (uint/long/ulong
value arrays, 65 complexity / 285 LOC per SonarCloud). The committed suite
(`ImPlotP15ExecutionTests.cs` with real native ImGui+ImPlot contexts, plus
`ImPlotP15RemainingCoverageTests.cs`) covers 426/448 lines (95.1%). Every wrapper body is
exercised; only the 11 closing braces remain uncovered: lines 56, 76, 97, 118, 139, 160, 181,
199, 219, 239, 260 (the final `}` of each `PlotBarGroups` overload).

Each wrapper marshals the label ids as a jagged `byte[][]` into
`ImPlotNative.ImPlot_PlotBarGroups_U32Ptr/S64Ptr/U64Ptr(nativeLabelIds, ...)`. The default
interop marshaller rejects jagged `byte[][]` with `MarshalDirectiveException` during argument
marshalling, before the native function is entered, so the P/Invoke call site is hit but the
method can never complete its body — the closing brace is unreachable. This is the same
`byte[][]` marshalling defect observed on `ImGuiP6.ListBox` (ImGuiNative). The committed
ExecutionTests confirm it by wrapping each call in `try { ... } catch (MarshalDirectiveException)`.

Covering the closing braces would require a successful native return, which is impossible with
the current `src/` interop signature. Production interop defect, out of scope.

## Verification

- Full Ui suite passes (7595 passed, 0 failed, 14 platform-gated skipped).
- Local coverlet: ImPlotP15.cs partial 426/448 lines (95.1%); 11 unique uncovered lines, all
  method-closing braces of `PlotBarGroups`.
- The committed tests document the `MarshalDirectiveException` behavior explicitly.
