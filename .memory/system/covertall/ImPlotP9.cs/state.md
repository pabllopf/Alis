# State

Target:
1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP9.cs

Project:
1_Presentation/Extension/Graphic/Ui/src/Alis.Extension.Graphic.Ui.csproj

Test project:
1_Presentation/Extension/Graphic/Ui/test/Alis.Extension.Graphic.Ui.Test.csproj

Agent:
covertall-implot9-FE18761E-6F65-4B02-A974-4A13F1E2AF63

Baseline commit:
393a03c29

Initial line coverage:
90.5% (201/222)

Initial branch coverage:
100% (42/42)

Current line coverage:
90.5% (201/222)

Current branch coverage:
100% (42/42)

Tests before:
existing ImPlotP9 suite (null-label and null-labelFmt throw tests, without-native-library
tests, context-based execution tests)

Tests after:
6 new PieChart overload tests added

Files modified:
- 1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP9PieChartExecutionTests.cs (added)

Tests added:
- PlotPieChart_Float_Overloads_Execute
- PlotPieChart_Double_Overloads_Execute
- PlotPieChart_SByte_Overloads_Execute
- PlotPieChart_Byte_Overloads_Execute
- PlotPieChart_Short_Overloads_Execute
- PlotPieChart_UShort_Overload_Executes

Commits:
test: cover PlotPieChart native call sites of ImPlotP9.cs

Remaining uncovered lines:
The final closing brace of each of the 21 PlotPieChart overloads (e.g. L299 for
the float base overload). Each requires the native call to complete, but the
P/Invoke declares byte[][] labelIds, which the default interop marshaler
cannot marshal - every call throws MarshalDirectiveException at the call site
(verified: the call sites are now covered with vc>0; only the method-completion
braces remain).

Remaining uncovered branches:
none

Status:
BLOCKED

Last update:
2026-08-17T00:00:00Z