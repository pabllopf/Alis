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
100%

Current line coverage:
100% (169/169)

Current branch coverage:
100%

Tests before:
existing (ImPlotP15ExecutionTests + ImPlotP15RemainingCoverageTests)

Tests after:
updated (removed the now-dead MarshalDirectiveException try/catch blocks so
the PlotBarGroups wrapper overloads execute against the real native library)

Files modified:
- 1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP15.cs (11 PlotBarGroups wrappers: pass labelIds directly instead of building an unmarshalable byte[][])
- 1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotNative.cs (3 DllImport declarations: byte[][] labelIds -> [MarshalAs(LPArray, LPStr)] string[] labelIds for PlotBarGroups_U32Ptr/S64Ptr/U64Ptr)
- 1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP2.cs (1 wrapper, uint count-only PlotBarGroups: compilation requirement of the U32Ptr DllImport change)
- 1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP15ExecutionTests.cs (4 test methods updated)

Commits:
pending

Remaining uncovered lines:
none

Remaining uncovered branches:
none

Status:
COMPLETED

Last update:
2026-08-17T13:10:00Z

Notes:
- Previously BLOCKED: the 11 PlotBarGroups wrappers marshalled the label ids
  as byte[][] (jagged array), which the runtime unconditionally rejects with
  MarshalDirectiveException ("no marshaling support for nested arrays"),
  leaving the closing-brace sequence points permanently uncovered.
- Resolved as a genuine production defect fix (rule 27): changed the
  DllImports to marshal the label ids as string[] with LPStr (a char**),
  which is what the native const char** parameter expects, and simplified the
  11 wrappers to pass labelIds directly. Verified with a standalone probe that
  the native ImPlot_PlotBarGroups_U32Ptr call completes inside a real plot
  context (no MarshalDirectiveException, no native assert).
- ImPlotP2.cs uint count-only wrapper (ImPlot_PlotBarGroups_U32Ptr caller)
  updated for compilation. The other PlotBarGroups variants (FloatPtr etc.)
  in ImPlotP2.cs still use byte[][] and remain a pre-existing, out-of-scope
  defect.
- Verified full test project passes (7660 passed / 14 skipped / 0 failed) and
  mandatory coverage command reports ImPlotP15.cs at 100% line and 100%
  branch coverage.