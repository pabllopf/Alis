# Result: ImGuiKeyData.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiKeyData.cs`
CoverageBefore: 0.0% (SonarCloud; 4 uncovered lines)
CoverageAfter: 100.0% (8/8 instrumented lines, local coverlet, ImGuiKeyData-filtered run)
TestsAdded: 3 (ImGuiKeyDataCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGuiKeyData.cs
Status: REMEDIATED

## Summary

ImGuiKeyData.cs is a plain struct with 4 auto-properties (`Down`, `DownDuration`,
`DownDurationPrev`, `AnalogValue`), no logic.

Committed `ImGuiKeyDataTest.cs` (4 tests) and `ImGuiKeyDataRemainingCoverageTests.cs` (3
tests) already covered every property but all use `[RequireCImguiSystemFact]`, which skips
when the `cimgui` native library cannot be resolved (CI/SonarCloud run), hence 0.0%.

Added `ImGuiKeyDataCoverageTests.cs` with plain `[Fact]` tests: default values, set/store
round trip, and value-type copy independence.

## Verification

- ImGuiKeyDataCoverageTests-filtered run: 3 passed / 0 failed, 0 skipped (net8.0).
- Local coverlet: ImGuiKeyData.cs 100.0% (8/8 instrumented lines, line-rate 1.0).