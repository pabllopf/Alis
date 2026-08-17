# Coverage State — ImPlotP15.cs

Target:
./1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP15.cs

Project:
./1_Presentation/Extension/Graphic/Ui/src/Alis.Extension.Graphic.Ui.csproj

Test project:
./1_Presentation/Extension/Graphic/Ui/test/Alis.Extension.Graphic.Ui.Test.csproj

Agent:
covertall-agent-implotp15

Baseline commit:
2e91a3e6cfb3a7ba79b612b87b591954d0c1a5b4

Initial line coverage:
95.09% (213/224)

Initial branch coverage:
100% (22/22)

Current line coverage:
95.09% (213/224)  — maximum achievable

Current branch coverage:
100%

Tests before:
existing (ImPlotP15ExecutionTests + ImPlotP15RemainingCoverageTests)

Tests after:
unchanged

Files modified:
- none

Status:
BLOCKED

Remaining uncovered lines:
- 11 closing-brace sequence points: source lines 56, 76, 97 (uint PlotBarGroups),
  118, 139, 160, 181 (long PlotBarGroups), 199, 219, 239, 260 (ulong PlotBarGroups).

Remaining uncovered branches:
none

Last update:
2026-08-17T12:40:00Z

Blocked justification:
- The 11 PlotBarGroups wrapper methods build a `byte[][]` jagged array for the
  label ids and pass it to the native ImPlot_PlotBarGroups_* DllImport.
  The runtime marshaller rejects jagged arrays unconditionally with
  MarshalDirectiveException: "Cannot marshal 'parameter #1': There is no
  marshaling support for nested arrays." Empirically verified with both a
  non-empty and an empty labels array; the exception is thrown on TYPE, so no
  input can avoid it.
- The native call statement is therefore reached (covered) but the method's
  final sequence point (closing brace) is never executed because the exception
  aborts the method before the `ret`.
- Fixing it requires changing the marshalling of the label ids in production
  (e.g. unsafe IntPtr/byte* array building), which is a substantial production
  redesign. The repository convention (44 MarshalDirectiveException catch
  blocks across Plot tests; Ui project state.md) explicitly treats such native
  marshalling limitations as out of scope for coverage remediation. The same
  partial pattern exists in ImPlotP2.cs PlotBarGroups (88.88%) and was
  accepted.
- 100% line coverage is therefore technically impossible without a production
  redesign; no additional tests can cover these points.