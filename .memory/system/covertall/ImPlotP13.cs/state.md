# Coverage State — ImPlotP13.cs

Target:
./1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP13.cs

Project:
./1_Presentation/Extension/Graphic/Ui/src/Alis.Extension.Graphic.Ui.csproj

Test project:
./1_Presentation/Extension/Graphic/Ui/test/Alis.Extension.Graphic.Ui.Test.csproj

Agent:
covertall-agent-implotp13

Baseline commit:
2e91a3e6cfb3a7ba79b612b87b591954d0c1a5b4

Initial line coverage:
92.45% (147/159)

Initial branch coverage:
100% (0/0 branch points)

Current line coverage:
100% (159/159)

Current branch coverage:
100%

Tests before:
0 dedicated (covered by ImPlotP13ExecutionTests + ImPlotP13RemainingCoverageTests)

Tests after:
+1 ExecutionTests method (PlotStairs_Short_And_Int_And_Uint_Overloads_Execute)

Files modified:
- 1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP13.cs (call sites: added missing `ref` on xs/ys for short/int/uint PlotStairs native calls)
- 1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotNative.cs (DllImport declarations for ImPlot_PlotStairs_S16PtrS16Ptr, ImPlot_PlotStairs_S32PtrS32Ptr, ImPlot_PlotStairs_U32PtrU32Ptr: `short/int/uint xs, ys` -> `ref ...`)
- 1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP13ExecutionTests.cs (new test)

Tests added:
- PlotStairs_Short_And_Int_And_Uint_Overloads_Execute

Commits:
b5cb17c28

Remaining uncovered lines:
none

Remaining uncovered branches:
none

Status:
COMPLETED

Last update:
2026-08-17T12:40:00Z

Notes:
- The 12 short/int/uint PlotStairs overloads could not be executed by tests:
  the wrappers declared `ref short/int/uint xs, ref ys` but passed `xs, ys`
  BY VALUE into the native calls, and the DllImport declarations also declared
  the parameters by value. The native functions are `*Ptr*Ptr` (pointer
  arguments); passing scalar values made the native code dereference a
  garbage address and hang the entire test host. This is a genuine
  marshalling defect, not a testability limitation. Fixed by adding `ref` in
  both the DllImport declarations (ImPlotNative.cs) and the 12 call sites
  (ImPlotP13.cs), matching the byte/ushort/long/ulong sibling overloads.
- Verified the full test project passes (7660 passed / 14 skipped / 0 failed)
  and mandatory coverage command reports ImPlotP13.cs at 100% line and 100%
  branch coverage.