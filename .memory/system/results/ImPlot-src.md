# Result: ImPlot.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlot.cs`
CoverageBefore: 0.0% (SonarCloud; 457 uncovered lines, 8 branches)
CoverageAfter: 8.3% (76/914 instrumented lines, local coverlet, ImPlotNullLabelCoverageTests run)
TestsAdded: 38 (ImPlotNullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlot.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImPlot.cs is the `public static partial class ImPlot` holding 132 static wrapper methods
(~135 complexity / 597 LOC per SonarCloud). Every method is a one-line pass-through to an
`[DllImport]` `ImPlotNative.*` entry point in the native cimgui library (no managed logic).
The pre-existing coverage (`ImPlotRemainingCoverageTests.cs`, `ImPlotTest.cs`) uses
`[RequireImNodesSystemFact]`/`[RequireCImguiSystemFact]`, which SKIP when cimgui is absent;
SonarCloud/CI therefore records 0.0% even though those files exist.

Added `ImPlotNullLabelCoverageTests.cs` (38 plain `[Fact]`, deterministic on every platform):
each test calls a wrapper with a null string for every parameter that flows into
`Encoding.UTF8.GetBytes(...)`. The null throws `ArgumentNullException` at the call site,
before any `ImPlotNative.*` P/Invoke, so the wrapper signature line and its
`Encoding.UTF8.GetBytes(...)` statement line are exercised without needing the native library
and without side effects. This covers all 38 string-converting overloads across the
`PlotStems` (23), `PlotText` (3), `PushColormap` (1), `SetupAxes` (3), `SetupAxis` (2),
`SetupAxisFormat` (1), `ShowColormapSelector`/`ShowInputMapSelector`/`ShowStyleSelector` (3),
and `TagX`/`TagY` (2) families.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

- Lines 55-1517 (~838 lines / ~94 methods): every remaining method's body is a single
  `ImPlotNative.*` call with no managed prelude (e.g. `PushStyleColor`, `SetNextLineStyle`,
  `StyleColorsDark`, `ShowDemoWindow`, `SetupFinish`). The only way to enter these bodies is
  to invoke the native entry point, which requires the cimgui library present at runtime.
  Calling them without the library raises `DllNotFoundException`/`EntryPointNotFoundException`;
  this is environment-dependent and cannot be covered deterministically under plain `[Fact]`.
  The `CanLoadCImguiLibrary()`-gated `[RequireImNodesSystemFact]` tests cover them only when
  the native lib is installed, which SonarCloud lacks.

## Verification

- ImPlotNullLabelCoverageTests-filtered run: 38 passed / 0 failed (net8.0).
- Full project build (Debug): 0 warnings / 0 errors.
- Local coverlet: ImPlot.cs 8.3% (76/914 instrumented lines).