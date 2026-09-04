# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP20.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 100.0% (174/174 lines, existing committed suite; verified via XPlat Code Coverage)
TestsAdded: 0
Commit: (none)
Status: ALREADY_COVERED_LOCALLY
Details:
- ImPlotP20.cs wraps ImPlotNative.ImPlot_PlotHeatmap (int, uint, long, ulong generic element overloads with 2-3 array arg forms) and ImPlotNative.ImPlot_PlotHistogram (float, double, sbyte, byte readers) for the value-element generic PlotHeatmap/PlotHistogram families (117 LOC, 41 complexity per SonarCloud, 0.0% CI coverage).
- Existing committed suite (ImPlotP20ExecutionTests + ImPlotP20RemainingCoverageTests + ImPlotP20Tests, 49 tests) executes every wrapper overload inside a live cimgui context (BeginPlot/SetupAxes/SetupFinish, context slots synced across loaded cimgui images). Local coverlet: 174/174 lines hit (100%).
- SonarCloud 0% is a CI artifact: native cimgui library is absent there, so RequireImNodesSystemFact execution tests are skipped and the DllNotFoundException guards assert on no-op paths only.
- No new tests needed; nothing commit-worthy (no test-file changes).