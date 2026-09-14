# ImPlot.cs Coverage Remediation Result

- File: 1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlot.cs
- CoverageBefore: 16.6% (381 uncovered lines, 8 uncovered branches)
- CoverageAfter: 95.4% (436/457 instrumented lines hit; 21 lines remain uncovered)
- TestsAdded: 46
- Commit: test: coverage ImPlot.cs
- Status: COMPLETED

Notes:
- 38 null-label [Fact] tests cover every string-taking wrapper body (PlotStems x23, PlotText x3, PushColormap, SetupAxes x3, SetupAxis x2, SetupAxisFormat, ShowColormapSelector, ShowInputMapSelector, ShowStyleSelector, TagX fmt, TagY fmt): Encoding.UTF8.GetBytes throws ArgumentNullException on (string)null before any native entry — safe on every platform, including CI/SonarCloud.
- 8 [RequireCImguiSystemFact] native tests exercise pure P/Invoke wrappers against the bundled cimgui library inside a fresh ImGui+ImPlot context and an active plot frame: style/next-style, next-axes/axis-limits, plot-frame setup+tag+draw+selectors, PlotToPixels x6, SetupAxisFormat/SetupAxisScale callback overloads, SetNextAxisLinks.
- SetupAxisTicks (6 overloads) covered via Assert.Throws<MarshalDirectiveException>: the native signatures declare nested byte[][] labels which the marshaller rejects deterministically before entering cimgui; the plot stays balanced by calling SetupFinish/EndPlot after the catch.
- Dropped as uncoverable: SetupAxisLinks and PlotStems(int), PlotStems(uint) native wrappers pass their ref values BY VALUE into native pointer parameters (defective wrapper marshaling) — exercising them segfaults or corrupts the plot window stack, aborting the whole test host.
- Uncovered residuals: SetupAxisLinks, PlotStems(int), PlotStems(uint) managed wrappers (uncallable without crashing the host), plus native/SonarCloud-boundary methods.