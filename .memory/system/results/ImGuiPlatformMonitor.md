# Result: ImGuiPlatformMonitor.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiPlatformMonitor.cs`
CoverageBefore: 0.0% (SonarCloud; 6 uncovered lines)
CoverageAfter: 100.0% (10/10 instrumented lines, local coverlet, ImGuiPlatformMonitor-filtered run)
TestsAdded: 3 (ImGuiPlatformMonitorCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGuiPlatformMonitor.cs
Status: REMEDIATED

## Summary

ImGuiPlatformMonitor.cs is a plain struct with 5 auto-properties (`MainPos`, `MainSize`,
`WorkPos`, `WorkSize` as `Vector2F`, plus `DpiScale`), no logic.

Committed `ImGuiPlatformMonitorTest.cs` (5 tests) and `ImGuiPlatformMonitorTests.cs` (7
tests) already covered every property but all use `[RequireCImguiSystemFact]`, which skips
when the `cimgui` native library cannot be resolved (CI/SonarCloud run has no cimgui,
hence 0.0%).

Added `ImGuiPlatformMonitorCoverageTests.cs` with plain `[Fact]` tests: default zero
values, vector/float round trip, and value-type copy independence.

## Verification

- ImGuiPlatformMonitor-filtered run: 16 passed / 0 failed, 0 skipped (net8.0).
- Local coverlet: ImGuiPlatformMonitor.cs 100.0% (10/10 instrumented lines, line-rate 1.0, branch-rate 1.0).