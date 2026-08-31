# Result: ImGuiStorage.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiStorage.cs`
CoverageBefore: 0.0% (SonarCloud; existing tests skipped)
CoverageAfter: 100.0% (1/1 instrumented line, local coverlet)
TestsAdded: 4 (ImGuiStorageExecutionTests.cs)
Commit: test: coverage ImGuiStorage.cs
Status: REMEDIATED

## Summary

ImGuiStorage.cs is a `public struct` exposing a single executable member: the auto-property
`ImVector Data { get; set; }` (line 40). SonarCloud reported 0.0% because the pre-existing
`ImGuiStorageTest.cs` and `ImGuiStorageTests.cs` classes annotate every test with the custom
`[RequireCImguiSystemFact]` attribute, which skips when the native `cimgui` library cannot be
resolved by name via `NativeLibrary.TryLoad`. On this host that lookup fails, so those classes
were skipped and the only executable line stayed uncovered.

The `Data` property needs no native interop — it is a pure managed `ImVector` struct getter/setter
(ImVector is itself a managed struct with Size/Capacity/Data and a public 3-arg constructor).
A new `ImGuiStorageExecutionTests.cs` class uses plain `[Fact]` attributes (always run) to
exercise:
- `Data` set/get round-trip of a constructed ImVector.
- `Data` overwrite semantics and default zeroed ImVector.
- struct value-type copy independence for `Data`.

## Verification

- ImGuiStorageExecutionTests filter (net8.0, Debug): 4 passed, 0 failed, 0 skipped.
- Coverlet cobertura: `ImGuiStorage` class line-rate=1, branch-rate=1; `get_Data` line 40 hit 16 times.
