# Result: ImGuiIO.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiIO.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 100.0% (741/741 lines, local coverlet)
TestsAdded: 0 (already covered by the committed ImGuiIo test surface)
Commit: test: coverage ImGuiIO.cs
Status: ALREADY_REMEDIATED

## Summary

ImGuiIO.cs is the `ImGuiIo` struct (managed auto-properties mirroring the native ImGuiIO
layout). A clean local coverlet run (net8.0, Debug, ImGuiIo filter — 1750 tests from the
committed Ui suite, including ImGuiIoTest/ImGuiIoPtrTest/ImGuiIoPtrTests and the IOPtr
coverage suites) measures 741/741 lines (100.0%).

## Verification

- ImGuiIo filter (net8.0, Debug): 1750 passed, 0 failed, 0 skipped.
- Local coverlet: ImGuiIO.cs 741/741 lines (100.0%), no uncovered lines.
