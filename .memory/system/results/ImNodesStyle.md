# ImNodesStyle.cs

## File
1_Presentation/Extension/Graphic/Ui/src/Extras/Node/ImNodesStyle.cs

## Coverage (SonarCloud, master)
- Line: 0.0%, Uncovered Lines: 17 (SonarCloud master)

## Local verification
- `dotnet test --filter FullyQualifiedName~ImNodesStyle`: 43/43 passed, 0 skipped.
- Tests cover all 17 properties (init + get/set round trip in
  ImNodesStyleTest.cs + ImNodesStyleRemainingCoverageTests.cs).

## Analysis
Full property surface exercised by existing tests; SonarCloud 0% is a
CI-environment artifact (cimgui/imnodes gating). Coverlet report quirk same as
ImPlotStyle (struct accessors not attributed in cobertura).

## Outcome
No new tests required.
