# Result: ImDrawChannel.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImDrawChannel.cs`
CoverageBefore: 0.0% (SonarCloud; 4 uncovered lines)
CoverageAfter: 100.0% (4/4 instrumented lines, local coverlet, ImDrawChannel-filtered run)
TestsAdded: 4 (ImDrawChannelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImDrawChannel.cs
Status: REMEDIATED

## Summary

ImDrawChannel.cs is a plain struct with 2 auto-properties (`CmdBuffer`, `IdxBuffer`) and 2
computed getters (`CmdBufferPtr`, `IdxBufferPtr`) that wrap the buffers in `ImVectorG<T>`.

Committed `ImDrawChannelTest.cs` (4 tests) and `ImDrawChannelRemainingCoverageTests.cs` (5
tests) already covered every member but all use `[RequireCImguiSystemFact]`, which skips
when the `cimgui` native library cannot be resolved (CI/SonarCloud run), hence 0.0%.

Added `ImDrawChannelCoverageTests.cs` (4 plain `[Fact]`) covering default values,
set/store round trip, the two computed buffer-ptr getters, and value-type copy
independence.

## Verification

- ImDrawChannelCoverageTests-filtered run: 4 passed / 0 failed (net8.0).
- Local coverlet: ImDrawChannel.cs 100.0% (4/4 instrumented lines, line-rate 1.0).