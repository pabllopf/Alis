# Result: ImPlotP7.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP7.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (162/162, local coverlet)
TestsAdded: 0 (already remediated, committed ImPlotP7Tests/ExecutionTests/RemainingCoverageTests)
Commit: test: coverage ImPlotP7.cs
Status: ALREADY_REMEDIATED

## Summary

ImPlotP7.cs is another `ImPlot.PlotStairs` wrapper family partial over
`ImPlotNative.ImPlot_PlotStairs_*` P/Invokes. Committed tests cover it fully:

- `test/Extras/Plot/ImPlotP7Tests.cs`
- `test/Extras/Plot/ImPlotP7ExecutionTests.cs`
- `test/Extras/Plot/ImPlotP7RemainingCoverageTests.cs`

## Verification

- `dotnet test Alis.Extension.Graphic.Ui.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~ImPlotP7"`: 63 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): `ImPlotP7.cs` 162/162 lines = 100.0%.
