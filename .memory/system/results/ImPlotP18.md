# Result: ImPlotP18.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP18.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (100/100, local coverlet)
TestsAdded: 0 (already remediated, committed ImPlotP18Tests/ExecutionTests/RemainingCoverageTests)
Commit: test: coverage ImPlotP18.cs
Status: ALREADY_REMEDIATED

## Summary

ImPlotP18.cs is an `ImPlot` wrapper family partial over `ImPlotNative` P/Invokes. Committed
tests cover it fully: ImPlotP18Tests.cs / ImPlotP18ExecutionTests.cs / ImPlotP18RemainingCoverageTests.cs.

## Verification

- `dotnet test Alis.Extension.Graphic.Ui.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~ImPlotP18"`: 56 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): `ImPlotP18.cs` 100/100 lines = 100.0%.
