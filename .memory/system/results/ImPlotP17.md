# Result: ImPlotP17.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP17.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (159/159, local coverlet)
TestsAdded: 0 (already remediated, committed ImPlotP17Tests/ExecutionTests/RemainingCoverageTests)
Commit: test: coverage ImPlotP17.cs
Status: ALREADY_REMEDIATED

## Summary

ImPlotP17.cs is an `ImPlot` wrapper family partial over `ImPlotNative` P/Invokes. Committed
tests cover it fully:

- `test/Extras/Plot/ImPlotP17Tests.cs`
- `test/Extras/Plot/ImPlotP17ExecutionTests.cs`
- `test/Extras/Plot/ImPlotP17RemainingCoverageTests.cs`

## Verification

- `dotnet test Alis.Extension.Graphic.Ui.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~ImPlotP17"`: all tests passed.
- Local coverlet (XPlat Code Coverage, cobertura): `ImPlotP17.cs` 159/159 lines = 100.0%.
