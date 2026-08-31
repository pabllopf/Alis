# Result: ImguiIo.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Node/ImguiIo.cs`
CoverageBefore: 0.0% (SonarCloud; 2 uncovered lines)
CoverageAfter: 100.0% (4/4, local coverlet, ImguiIo-filtered run)
TestsAdded: 3 (ImguiIoCoverageTests.cs, plain [Fact])
Commit: test: coverage ImguiIo.cs
Status: REMEDIATED

## Summary

ImguiIo.cs is a struct with 2 auto-properties (an `EmulateThreeButtonMouse` struct holding
a `byte[] Modifier`, and a `LinkDetachWithModifierClick` struct holding a `byte[] Modifier`).
Only the property getter/setter lines are instrumented.

Committed `ImguiIoTest.cs` / `ImguiIoRemainingCoverageTests.cs` already covered the type but
all tests use `[RequireCImguiSystemFact]`, which skips when the native cimgui library cannot
be resolved (CI/SonarCloud run), hence 0.0%.

Added `ImguiIoCoverageTests.cs` (3 plain `[Fact]`, namespace Alis.Extension.Graphic.Ui.Test):
default (null Modifier) values, set/store round trip on both properties, and value-type copy
reference sharing. The run also exercises the sibling `EmulateThreeButtonMouse` (2/2) and
`LinkDetachWithModifierClick` (2/2) structs.

## Verification

- ImguiIo-filtered run: 3 passed / 0 failed (net8.0).
- Local coverlet: ImguiIo.cs 100.0% (4/4 instrumented lines, line-rate 1.0, branch-rate 1.0).