# Result: ImPlotP16.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP16.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (156/156, local coverlet)
TestsAdded: 0 (already remediated, committed ImPlotP16Tests/ExecutionTests/RemainingCoverageTests)
Commit: test: coverage ImPlotP16.cs
Status: ALREADY_REMEDIATED

## Summary

ImPlotP16.cs is an `ImPlot` wrapper family partial over `ImPlotNative` P/Invokes. Committed
tests cover it fully:

- `test/Extras/Plot/ImPlotP16Tests.cs`
- `test/Extras/Plot/ImPlotP16ExecutionTests.cs`
- `test/Extras/Plot/ImPlotP16RemainingCoverageTests.cs`

## Verification

- `dotnet test Alis.Extension.Graphic.Ui.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~ImPlotP16"`: 64 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): `ImPlotP16.cs` 156/156 lines = 100.0%.
