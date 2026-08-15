# Result: ImPlotP1.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP1.cs`
CoverageBefore: 0.0% (SonarCloud; local coverlet 240/480 = 50.0%)
CoverageAfter: 50.0% (240/480 lines, local coverlet; unchanged)
TestsAdded: 0 (all attempted tests crash the native test host)
Commit: test: coverage ImPlotP1.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlotP1.cs is an `ImPlot` partial (66 complexity / 308 LOC per SonarCloud) whose wrappers call
`ImPlotNative` interop directly (no try/catch). The existing committed suite
(`ImPlotP1Test.cs`, `ImPlotP1ExecutionTests.cs`) covers 240/480 lines (50.0%) via real native
contexts (`CreateContexts()` + `BeginPlot`/`SetupAxes`/`SetupFinish`). The 120 remaining
uncovered lines live entirely in 8 method groups: `AddColormap` x4, `BeginSubplots` x4,
`ColormapScale` x5, `ColormapSlider` x4, `DragLineX` x3, `DragLineY` x3, `DragPoint` x3,
`DragRect` x2, `EndDragDropSource`.

Every attempt to execute these methods against the shipped `libcimgui.dylib` (Debug + Release,
both present in the Ui test output, exports confirmed with `nm`) aborts/segfaults the native
test host (the whole run is cancelled, `Proceso de host de pruebas bloqueado`):

- `AddColormap` (lines 48-93): native assert abort `"The colormap size must be greater than 1!"`
  (implot.cpp:4372). Root cause: `ImPlotNative.ImPlot_AddColormap_Vec4Ptr(byte[] name,
  Vector4F cols, int size, byte qual)` declares `Vector4F cols` **by value** while cimgui expects
  `const ImVec4* cols` (a pointer). The by-value struct is passed in SSE registers; native reads
  a garbage pointer/`size` from the wrong registers. Production marshalling defect.
- `BeginSubplots` (330-385): `ImPlotNative.ImPlot_BeginSubplots(..., float rowRatios,
  float colRatios)` passes the ratio arrays **by value** while cimgui expects
  `const float* row_ratios/col_ratios`; native dereferences garbage → crash.
- `ColormapScale` (463-520): crash inside native (no assertion text; hard fault).
- `ColormapSlider` (528-574): `float t` declared by value while cimgui expects `float* t`, plus
  argument-order mismatch (`out`/`format`/`cmap` land in the wrong registers) → crash.
- `DragLineX/Y` (611-692), `DragPoint` (702-740), `DragRect` (752-774): `double x/y/x1...` and
  `Vector4F col` declared **by value** while cimgui expects `double*` / `const ImVec4*` (in-out
  pointers) → crash.
- `EndDragDropSource` (787-790): crashes when there is no active ImGui drag-drop payload (the
  `BeginDragDropSourceAxis` returns false without an in-flight drag).

These are the same by-value-as-pointer interop defect class previously observed in
`ImGuiNative._igInputInt3` (`ImGuiP6.cs`) and `ImPlot_AddColormap`. They cannot be exercised
from managed tests: the wrappers have no catch block and the native process aborts before any
managed code resumes. Fixing requires a `src/` interop change (out of scope).

The pre-existing `ImPlotP1RemainingCoverageTests.cs` (`[RequireImNodesSystemFact]` + `if
(!CanLoadCImguiLibrary())` guard) is a silent no-op on this machine because the dylib loads, so
the guard body never runs.

## Verification

- `ImPlotP1ExecutionTests.cs` original suite: passes (5/5).
- New tests for all 8 blocked groups each individually cancelled the run with a native abort /
  segfault (`Serie de pruebas anulada` / `Proceso de host de pruebas bloqueado`); the 
  `AddColormap` abort surfaced the native assertion message; the others fault without text.
- Test attempts were removed; the test file was restored to its committed state (no diff).
