# Result: ImPlot.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlot.cs`
CoverageBefore: 88.18% (local coverlet; SonarCloud stale 0.0%)
CoverageAfter: 88.18%
TestsAdded: 0
Commit: none
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

The remaining uncovered lines cannot be exercised from a test without modifying `src/`. Every
attempt to invoke the native wrappers crashes the test host or throws before reaching native code.
Root causes (all production bugs in the managed wrappers / DllImport signatures):

1. `PlotStems` `ref int` / `ref uint` overloads (lines 93-224) pass `xs, ys` **by value** to
   `ImPlot_PlotStems_S32PtrS32Ptr` / `ImPlot_PlotStems_U32PtrU32Ptr`, but the native side expects
   `const int*` / `const uint*` pointers. The marshaller forwards the literal value as the pointer
   (address 1) → native segfault. Compare the covered `ref long` overload (line 235) which
   correctly passes `ref xs, ref ys`.
2. `SetNextAxisLinks` (lines 757-759) and `SetupAxisLinks` (lines 1115-1117) pass
   `double linkMin, double linkMax` **by value** where the native signature expects `double*`
   pointers → native segfault (address 0.0).
3. All 6 `SetupAxisTicks` overloads (lines 1158-1225) route through
   `ImPlot_SetupAxisTicks_doublePtr` / `ImPlot_SetupAxisTicks_double` whose DllImport declares
   `byte[][] labels`. Default interop has no support for nested arrays, so every call throws
   `MarshalDirectiveException: Cannot marshal 'parameter #4': There is no marshaling support for
   nested arrays` (verified via caught-exception probe, ImPlot.cs line 1160). When invoked inside a
   plot the exception skips `EndPlot`, and the `finally` teardown's `igEndFrame` then aborts with
   the ImGui assert "Mismatched Begin/BeginChild vs End/EndChild calls".

## Verification

- New execution tests were written following the `ImPlotExecutionTests` pattern
  (`CreateContexts`/`BeginPlot`/`SetupAxes`/`SetupFinish`/`EndPlot`/`DestroyContexts` +
  `[RequireImNodesSystemFact]`).
- Context lifecycle probe passed; every wrapper under test crashed or threw.
- `--blame-crash` minidump confirmed the abort originates in
  `ImGui::ErrorCheckEndFrameSanityChecks` → `__assert_rtn` on the window-stack balance check.
- All `ImPlot_*` native entry points exist in `cimgui.dylib` (verified via `nm`), so the failures
  are marshalling/shape bugs in the managed wrappers, not missing symbols.

## Uncovered lines (unremediable without production changes)

- PlotStems ref int: 94-96, 107-109, 121-123, 136-138, 152-154
- PlotStems ref uint: 164-166, 177-179, 191-193, 206-208, 222-224
- SetNextAxisLinks: 757-759
- SetupAxisLinks: 1115-1117
- SetupAxisTicks: 1159-1161, 1171-1173, 1184-1186, 1196-1198, 1209-1211, 1223-1225
