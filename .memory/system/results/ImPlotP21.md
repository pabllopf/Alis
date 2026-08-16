# Result: ImPlotP21.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP21.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (150/150, local coverlet)
TestsAdded: 0 (already remediated, committed ImPlotP21Tests/ExecutionTests/RemainingCoverageTests)
Commit: test: coverage ImPlotP21.cs
Status: ALREADY_REMEDIATED

## Summary

ImPlotP21.cs is an `ImPlot` wrapper family partial over `ImPlotNative` P/Invokes. Committed
tests cover it fully:

- `test/Extras/Plot/ImPlotP21Tests.cs`
- `test/Extras/Plot/ImPlotP21ExecutionTests.cs`
- `test/Extras/Plot/ImPlotP21RemainingCoverageTests.cs`

## Verification

- `dotnet test Alis.Extension.Graphic.Ui.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~ImPlotP21"`: 61 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): `ImPlotP21.cs` 150/150 lines = 100.0%.
