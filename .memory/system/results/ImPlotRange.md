# Result: ImPlotRange.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotRange.cs`
CoverageBefore: 0.0% (SonarCloud; 2 uncovered lines)
CoverageAfter: 100.0% (4/4, local coverlet, ImPlotRange-filtered run)
TestsAdded: 3 (ImPlotRangeCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotRange.cs
Status: REMEDIATED

## Summary

ImPlotRange.cs is a struct with 2 `double` auto-properties (`Min`, `Max`). Only the property
getter/setter lines are instrumented.

Committed `ImPlotRangeTest.cs` already covered the type but uses `[RequireCImguiSystemFact]`,
which skips when the native cimgui library cannot be resolved (CI/SonarCloud run), hence 0.0%.

Added `ImPlotRangeCoverageTests.cs` (3 plain `[Fact]`, namespace
Alis.Extension.Graphic.Ui.Test.Extras.Plot): default (zeroed) field values, set/store round
trip, and value-type copy independence.

## Verification

- ImPlotRange-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: ImPlotRange.cs 100.0% (4/4 instrumented lines,
  line-rate 1.0, branch-rate 1.0).