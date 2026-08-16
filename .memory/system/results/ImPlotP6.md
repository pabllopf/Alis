# Result: ImPlotP6.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP6.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (162/162, local coverlet)
TestsAdded: 0 (already remediated in commit 8737dec9f)
Commit: test: coverage ImPlotP6.cs
Status: ALREADY_REMEDIATED

## Summary

ImPlotP6.cs is another `ImPlot.PlotStairs` wrapper family partial over
`ImPlotNative.ImPlot_PlotStairs_*` P/Invokes. Committed tests cover it fully:

- `test/Extras/Plot/ImPlotP6Tests.cs`
- `test/Extras/Plot/ImPlotP6ExecutionTests.cs` (native-backed execution inside active plots)
- `test/Extras/Plot/ImPlotP6RemainingCoverageTests.cs` (DllNotFoundException-gated overloads)

## Verification

- `dotnet test Alis.Extension.Graphic.Ui.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~ImPlotP6"`: 66 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): `ImPlotP6.cs` 162/162 lines = 100.0%.
