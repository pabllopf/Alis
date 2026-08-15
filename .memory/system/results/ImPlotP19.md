# Result: ImPlotP19.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP19.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (162/162, local coverlet)
TestsAdded: 0 (already remediated in commit 90537bedd)
Commit: test: coverage ImPlotP19.cs
Status: ALREADY_REMEDIATED

## Summary

ImPlotP19.cs is the `ImPlot.PlotStairs` wrapper family (54 overloads) over
`ImPlotNative.ImPlot_PlotStairs_*` P/Invokes. Committed tests cover it fully:

- `test/Extras/Plot/ImPlotP19Tests.cs` (114 lines)
- `test/Extras/Plot/ImPlotP19ExecutionTests.cs` (446 lines, native-backed execution inside
  active plot windows)
- `test/Extras/Plot/ImPlotP19RemainingCoverageTests.cs` (780 lines,
  `DllNotFoundException`-gated `WithoutNativeLibrary` overload coverage)

## Verification

- `dotnet test Alis.Extension.Graphic.Ui.Test.csproj -c Debug -f net8.0 --filter
  "FullyQualifiedName~ImPlotP19"`: 65 passed, 0 failed, 0 skipped.
- Local coverlet (XPlat Code Coverage, cobertura): `ImPlotP19.cs` 162/162 lines = 100.0%.
