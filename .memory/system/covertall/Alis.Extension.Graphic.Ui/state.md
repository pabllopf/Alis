# Project Coverage State

Project:
./1_Presentation/Extension/Graphic/Ui/src/Alis.Extension.Graphic.Ui.csproj

Test project:
./1_Presentation/Extension/Graphic/Ui/test/Alis.Extension.Graphic.Ui.Test.csproj

Status:
COMPLETED

Agent:
covertall-agent-001

Started:
2026-08-16T22:30:00Z

Last update:
2026-08-16T22:50:00Z

Initial coverage:
94.54% (21972/23240 lines in Ui/src)

Current coverage:
94.54%

Tests before:
~2600

Tests after:
unchanged

Files modified:
- none

Coverage work:
- Baseline measured: 94.54%. Only one class below 70%: ImPlotP1.cs (50%).
- ImPlotP1.cs uncovered lines are the ImPlot native P/Invoke bodies
  (ImPlot_AddColormap_Vec4Ptr / _U32Ptr etc.).
- Existing tests (ImPlotP1RemainingCoverageTests) only exercise the
  DllNotFound path and skip when the native library loads.
- Probe test written (ImPlotP1NativeProbeTest) calling AddColormap with the
  real library present (libcimgui.dylib is in test bin, symbols present):
  the native call ABORTS the entire test host with a native assertion
  ("The colormap size must be greater than 1!" from implot.cpp). The wrapper
  declares `Vector4F cols` by value while the native signature expects a
  `const ImVec4*` pointer, so argument marshalling is mismatched.
- Conclusion: the native ImPlot execution paths cannot be exercised safely
  in this environment; every call either throws DllNotFoundException (when
  the library is absent, i.e., CI) or aborts the test host (when present).
  Testing them is unsafe and out of scope. Probe removed.

Remaining opportunities:
- ImPlotP1.cs native bodies: require either the library being absent (already
  covered via DllNotFound tests on CI) or fixing the native marshalling
  (production change, out of scope for coverage remediation).

Last commit:
none

Attempts:
1