# Result: ImNodesIO.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Node/ImNodesIO.cs`
CoverageBefore: 0.0% (SonarCloud; 5 uncovered lines)
CoverageAfter: 100.0% (10/10 instrumented lines, local coverlet, ImNodesIO-filtered run)
TestsAdded: 3 (ImNodesIOCoverageTests.cs, plain [Fact])
Commit: test: coverage ImNodesIO.cs
Status: REMEDIATED

## Summary

ImNodesIO.cs declares the `ImNodesIo` struct with 5 auto-properties
(`ThreeButtonMouse`, `DetachWithModifierClick`, `SelectModifier`, `AltMouseButton`,
`AutoPanningSpeed`), no logic.

Committed `ImNodesIoTest.cs` (8 tests) already covered every property but all use
`[RequireCImguiSystemFact]`, which skips when the `cimgui` native library cannot be
resolved (CI/SonarCloud run has no cimgui, hence 0.0%).

Added `ImNodesIOCoverageTests.cs` with plain `[Fact]` tests: default values
(null modifiers, zero button/speed), property set/store round trip, and value-type copy
independence.

## Verification

- ImNodesIO-filtered run: 11 passed / 0 failed, 0 skipped (net8.0).
- Local coverlet: ImNodesIo.cs 100.0% (10/10 instrumented lines, line-rate 1.0, branch-rate 1.0).