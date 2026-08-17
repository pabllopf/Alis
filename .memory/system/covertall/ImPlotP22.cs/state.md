# Coverage State — ImPlotP22.cs

Target:
./1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP22.cs

Project:
./1_Presentation/Extension/Graphic/Ui/src/Alis.Extension.Graphic.Ui.csproj

Test project:
./1_Presentation/Extension/Graphic/Ui/test/Alis.Extension.Graphic.Ui.Test.csproj

Agent:
covertall-agent-implotp22

Baseline commit:
2e91a3e6cfb3a7ba79b612b87b591954d0c1a5b4

Initial line coverage:
97.58% (161/165)

Initial branch coverage:
100%

Current line coverage:
100% (165/165)

Current branch coverage:
100%

Tests before:
existing (ImPlotP22ExecutionTests + ImPlotP22RemainingCoverageTests)

Tests after:
+1 ExecutionTests method (PlotLine_ShortRef_Overloads_Execute_Inside_Plot)

Files modified:
- 1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP22.cs (call sites: added missing `ref` on xs/ys for short PlotLine native calls)
- 1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotNative.cs (DllImport declaration for ImPlot_PlotLine_S16PtrS16Ptr: `short xs, ys` -> `ref ...`)
- 1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP22ExecutionTests.cs (new test)

Tests added:
- PlotLine_ShortRef_Overloads_Execute_Inside_Plot

Commits:
pending

Remaining uncovered lines:
none

Remaining uncovered branches:
none

Status:
COMPLETED

Last update:
2026-08-17T12:40:00Z

Notes:
- The 4 short PlotLine overloads (ref short xs, ref short ys) could not be
  executed by tests: the wrapper passed `xs, ys` BY VALUE into
  ImPlot_PlotLine_S16PtrS16Ptr and the DllImport declared them by value. The
  native function expects pointers ("Ptr" in the name); passing the scalar
  value made the native code dereference a garbage address and hang the test
  host. Fixed by adding `ref` in the DllImport declaration and the 4 call
  sites, matching the byte/ushort sibling overloads.
- Verified full test project passes and mandatory coverage command reports
  ImPlotP22.cs at 100% line and 100% branch coverage.