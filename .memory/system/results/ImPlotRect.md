# Result: ImPlotRect.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotRect.cs`
CoverageBefore: 0.0% (SonarCloud; 2 uncovered lines)
CoverageAfter: 100.0% (4/4, local coverlet, ImPlotRect-filtered run)
TestsAdded: 3 (ImPlotRectCoverageTests.cs, plain [Fact])
Commit: test: coverage ImPlotRect.cs
Status: REMEDIATED

## Summary

ImPlotRect.cs is a struct with 2 auto-properties of type `ImPlotRange` (`X`, `Y`). Only the
property getter/setter lines are instrumented.

Committed `ImPlotRectTest.cs` already covered the type but uses `[RequireCImguiSystemFact]`,
which skips when the native cimgui library cannot be resolved (CI/SonarCloud run), hence 0.0%.

Added `ImPlotRectCoverageTests.cs` (3 plain `[Fact]`, namespace
Alis.Extension.Graphic.Ui.Test.Extras.Plot): default (zeroed) field values across both
ranges, set/store round trip, and value-type copy independence.

## Verification

- ImPlotRect-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: ImPlotRect.cs 100.0% (4/4 instrumented lines,
  line-rate 1.0, branch-rate 1.0).