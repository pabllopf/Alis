# Result: ImGuiIO.cs (src)

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiIO.cs`
CoverageBefore: 0.0% (SonarCloud; 741 uncovered lines)
CoverageAfter: 100.0% (1482/1482, local coverlet, ImGuiIOTests-filtered run)
TestsAdded: 747 (ImGuiIOTests.cs, plain [Fact])
Commit: test: coverage ImGuiIO.cs
Status: REMEDIATED

## Summary

ImGuiIO.cs is the huge `ImGuiIo` sequential struct (652 `KeysDataN` auto-properties plus
~90 scalar/IntPtr/Vector2F/ImVectorG properties and 15 native array fields). Every member
is a plain getter/setter or field, so behavior is a value round-trip.

The committed suite (`ImGuiIoTest.cs`, `ImGuiIoRemainingCoverageTests.cs`,
`ImGuiIoKeysDataCoverageTests.cs`) already targets the type, but every test uses
`[RequireCImguiSystemFact]`, which skips when the native cimgui library cannot be resolved
(CI/SonarCloud), hence 0.0%.

Added `ImGuiIOTests.cs` (747 plain `[Fact]`, namespace Alis.Extension.Graphic.Ui.Test):
value round-trip on every scalar/IntPtr/Vector2F/ImVectorG auto-property, the getter-only
`MouseClickedPos0`, every `KeysData0`-`KeysData651` property, and length check on every
native array field. Requires no native library, no reflection, no random, no I/O.

## Verification

- ImGuiIOTests-filtered run: 756 passed / 0 failed (net8.0; includes derived test count).
- Local coverlet: ImGuiIO.cs 100.0% (1482/1482 instrumented lines, line-rate 1.0, branch-rate 1.0).