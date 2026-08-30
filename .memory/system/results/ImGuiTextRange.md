# Result: ImGuiTextRange.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiTextRange.cs`
CoverageBefore: 0.0% (SonarCloud; 2 uncovered lines)
CoverageAfter: 100.0% (4/4, local coverlet, ImGuiTextRange-filtered run)
TestsAdded: 3 (ImGuiTextRangeCoverageTests.cs, plain [Fact])
Commit: test: coverage ImGuiTextRange.cs
Status: REMEDIATED

## Summary

ImGuiTextRange.cs is a struct with 2 `IntPtr` auto-properties (`B`, `E`). Only the
property getter/setter lines are instrumented.

Committed `ImGuiTextRangeTest.cs` already covered the type but all tests use
`[RequireCImguiSystemFact]`, which skips when the native cimgui library cannot be resolved
(CI/SonarCloud run), hence 0.0%.

Added `ImGuiTextRangeCoverageTests.cs` (3 plain `[Fact]`): default (zeroed) field values,
set/store round trip on the auto-properties, and value-type copy independence.

## Verification

- ImGuiTextRange-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: ImGuiTextRange.cs 100.0% (4/4 instrumented lines,
  line-rate 1.0, branch-rate 1.0).