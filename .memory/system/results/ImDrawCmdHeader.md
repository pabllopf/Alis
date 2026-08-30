# Result: ImDrawCmdHeader.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImDrawCmdHeader.cs`
CoverageBefore: 0.0% (SonarCloud; 3 uncovered lines)
CoverageAfter: 100.0% (3/3 instrumented lines, local coverlet, ImDrawCmdHeader-filtered run)
TestsAdded: 3 (ImDrawCmdHeaderCoverageTests.cs, plain [Fact])
Commit: test: coverage ImDrawCmdHeader.cs
Status: REMEDIATED

## Summary

ImDrawCmdHeader.cs is a plain struct with 3 auto-properties (`ClipRect` as `Vector4F`,
`TextureId` as `IntPtr`, `VtxOffset` as uint), no logic.

Committed `ImDrawCmdHeaderTest.cs` (8 tests) and `ImDrawCmdHeaderRemainingCoverageTests.cs`
already covered every member but all use `[RequireCImguiSystemFact]`, which skips when the
`cimgui` native library cannot be resolved (CI/SonarCloud run), hence 0.0%.

Added `ImDrawCmdHeaderCoverageTests.cs` (3 plain `[Fact]`): default values, set/store
round trip, and value-type copy independence.

## Verification

- ImDrawCmdHeaderCoverageTests-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: ImDrawCmdHeader.cs 100.0% (3/3 instrumented lines, line-rate 1.0).