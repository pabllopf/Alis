# Result: ImGuiStoragePair.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiStoragePair.cs`
CoverageBefore: 0.0% (SonarCloud; 2 uncovered lines)
CoverageAfter: 100.0% (4/4, local coverlet, ImGuiStoragePair-filtered run)
TestsAdded: 3 (ImGuiStoragePairCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGuiStoragePair.cs
Status: REMEDIATED

## Summary

ImGuiStoragePair.cs is a struct with 2 auto-properties (`uint Key` and `UnionValue Value`,
the latter an explicit-layout 3-member union {int, float, IntPtr}).

Committed `ImGuiStoragePairTest.cs` already covered the type but all tests use
`[RequireCImguiSystemFact]`, which skips when the native cimgui library cannot be resolved
(CI/SonarCloud run), hence 0.0%.

Added `ImGuiStoragePairCoverageTests.cs` (3 plain `[Fact]`): default (zeroed) values across
Key and all three union members, set/store round trip, and value-type copy independence.

Note: mutating `copy.Value.ValuePtr` directly is impossible (CS1612) because `Value` is an
auto-property, so the copy test assigns a fresh `UnionValue` instead.

## Verification

- ImGuiStoragePair-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: ImGuiStoragePair.cs 100.0% (4/4 instrumented lines,
  line-rate 1.0, branch-rate 1.0).