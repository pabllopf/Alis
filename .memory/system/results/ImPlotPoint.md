# Result: ImPlotPoint.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotPoint.cs`
CoverageBefore: 0.0% (SonarCloud; 2 uncovered lines)
CoverageAfter: 100.0% (4/4, local coverlet, ImPlotPoint-filtered run)
TestsAdded: 3 (ImPlotPointCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotPoint.cs
Status: REMEDIATED

## Summary

ImPlotPoint.cs is a struct with 2 `double` auto-properties (`X`, `Y`). Only the property
getter/setter lines are instrumented.

Committed `ImPlotPointTest.cs` already covered the type but all tests use
`[RequireCImguiSystemFact]`, which skips when the native cimgui library cannot be resolved
(CI/SonarCloud run), hence 0.0%.

Added `ImPlotPointCoverageTests.cs` (3 plain `[Fact]`, namespace
Alis.Extension.Graphic.Ui.Test.Extras.Plot): default (zeroed) field values, set/store round
trip, and value-type copy independence.

## Verification

- ImPlotPoint-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: ImPlotPoint.cs 100.0% (4/4 instrumented lines,
  line-rate 1.0, branch-rate 1.0).