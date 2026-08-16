File:
pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotStyle.cs

CoverageBefore:
63.5% (SonarCloud)

CoverageAfter:
100.0% (52/52 executable lines, local coverlet, ImNodes-hook suite subset)

Justification: SonarCloud analysis runs the ImNodes-hook suites (RequireImNodesSystemFact) while the RequireCImguiSystemFact suite (ImPlotStyleTest.cs) does not contribute on that runner. The 19 uncovered lines were exactly Colors1..Colors19 (property lines 182-272). Added ImPlotStyleAdditionalCoverageTests.cs covering all 19 with RequireImNodesSystemFact; measured 100% with only the ImNodes-hook subset (11 tests) and 100% with the full ImPlotStyle filter (115 tests).

TestsAdded:
4 (ImPlotStyleAdditionalCoverageTests.cs: MiddleColorProperties_RoundTrip, UpperColorProperties_RoundTrip, MiddleColorProperties_AreZeroByDefault, UpperColorProperties_AreZeroByDefault)

Commit:
test: coverage ImPlotStyle.cs

Status:
REMEDIATED
