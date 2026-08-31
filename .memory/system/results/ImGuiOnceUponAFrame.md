# Result: ImGuiOnceUponAFrame.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiOnceUponAFrame.cs`
CoverageBefore: 0.0% (SonarCloud; existing tests skipped)
CoverageAfter: 100.0% (1/1 instrumented line, local coverlet)
TestsAdded: 4 (ImGuiOnceUponAFrameExecutionTests.cs)
Commit: test: coverage ImGuiOnceUponAFrame.cs
Status: REMEDIATED

## Summary

ImGuiOnceUponAFrame.cs is a `public struct` exposing a single executable member: the auto-property
`int RefFrame { get; set; }` (line 40). SonarCloud reported 0.0% because the pre-existing
`ImGuiOnceUponAFrameTest.cs` and `ImGuiOnceUponAFrameRemainingCoverageTests.cs` classes annotate
every test with the custom `[RequireCImguiSystemFact]` attribute, which skips when the native
`cimgui` library cannot be resolved by name via `NativeLibrary.TryLoad`. On this host that lookup
fails, so those classes were skipped and the only executable line stayed uncovered.

The `RefFrame` property needs no native interop — it is a pure managed `int` getter/setter.
A new `ImGuiOnceUponAFrameExecutionTests.cs` class uses plain `[Fact]` attributes (always run) to
exercise:
- `RefFrame` set/get round-trip for an arbitrary value.
- `RefFrame` overwrite semantics and default zero.
- struct value-type copy independence for `RefFrame`.

## Verification

- ImGuiOnceUponAFrameExecutionTests filter (net8.0, Debug): 4 passed, 0 failed, 0 skipped.
- Coverlet cobertura: `ImGuiOnceUponAFrame` class line-rate=1, branch-rate=1; `get_RefFrame` line 40 hit 10 times.
