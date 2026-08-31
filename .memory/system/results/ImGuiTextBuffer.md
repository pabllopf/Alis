# Result: ImGuiTextBuffer.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiTextBuffer.cs`
CoverageBefore: 0.0% (SonarCloud; existing tests skipped)
CoverageAfter: 100.0% (1/1 instrumented line, local coverlet)
TestsAdded: 4 (ImGuiTextBufferExecutionTests.cs)
Commit: test: coverage ImGuiTextBuffer.cs
Status: REMEDIATED

## Summary

ImGuiTextBuffer.cs is a `public struct` exposing a single executable member: the auto-property
`ImVector Buf { get; set; }` (line 40). SonarCloud reported 0.0% because the pre-existing
`ImGuiTextBufferTest.cs` and `ImGuiTextBufferTests.cs` classes annotate every test with the custom
`[RequireCImguiSystemFact]` attribute, which skips when the native `cimgui` library cannot be
resolved by name via `NativeLibrary.TryLoad`. On this host that lookup fails, so those classes
were skipped and the only executable line stayed uncovered.

The `Buf` property needs no native interop — it is a pure managed `ImVector` struct getter/setter.
A new `ImGuiTextBufferExecutionTests.cs` class uses plain `[Fact]` attributes (always run) to
exercise:
- `Buf` set/get round-trip of a constructed ImVector.
- `Buf` overwrite semantics and default zeroed ImVector.
- struct value-type copy independence for `Buf`.

## Verification

- ImGuiTextBufferExecutionTests filter (net8.0, Debug): 4 passed, 0 failed, 0 skipped.
- Coverlet cobertura: `ImGuiTextBuffer` class line-rate=1, branch-rate=1; `get_Buf` line 40 hit 16 times.
