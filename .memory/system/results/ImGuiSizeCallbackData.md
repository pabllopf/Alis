# Result: ImGuiSizeCallbackData.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiSizeCallbackData.cs`
CoverageBefore: 0.0% (SonarCloud; 4 uncovered lines)
CoverageAfter: 100.0% (8/8 instrumented lines, local coverlet, ImGuiSizeCallbackData-filtered run)
TestsAdded: 3 (ImGuiSizeCallbackDataCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGuiSizeCallbackData.cs
Status: REMEDIATED

## Summary

ImGuiSizeCallbackData.cs is a plain struct with 4 auto-properties (`UserData` as IntPtr,
plus `Pos`, `CurrentSize`, `DesiredSize` as `Vector2F`), no logic.

Committed `ImGuiSizeCallbackDataTest.cs` (8 tests) already covered every property but all
use `[RequireCImguiSystemFact]`, which skips when the `cimgui` native library cannot be
resolved (CI/SonarCloud run), hence 0.0%.

Added `ImGuiSizeCallbackDataCoverageTests.cs` with plain `[Fact]` tests: default values,
set/store round trip, and value-type copy independence.

## Verification

- ImGuiSizeCallbackDataCoverageTests-filtered run: 3 passed / 0 failed, 0 skipped (net8.0).
- Local coverlet: ImGuiSizeCallbackData.cs 100.0% (8/8 instrumented lines, line-rate 1.0).