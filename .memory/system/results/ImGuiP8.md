# ImGuiP8.cs Coverage Remediation Result

- File: 1_Presentation/Extension/Graphic/Ui/src/ImGuiP8.cs
- CoverageBefore: 0.0% (121 uncovered lines, 10 uncovered branches)
- CoverageAfter: existing ImGuiP8ExecutionTests cover all Show* windows, style/font selectors and UserGuide, and every SliderAngle/SliderFloat/SliderFloat2/SliderFloat3 overload (7 execution tests pass)
- TestsAdded: 0
- Commit: test: ImGuiP8.cs
- Status: BLOCKED_BY_PRODUCTION_CODE

Notes: The two SliderFloat4 overloads in ImGuiP8.cs pass the Vector4F struct by value where the native cimgui API expects a pointer, so any invocation faults the test host (native assertion / blocked process). Fixing requires editing src/ImGuiP8.cs, which is forbidden by the source-protection policy; execution tests were attempted and reverted to keep the suite green.
