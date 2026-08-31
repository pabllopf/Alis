# Result: LinkDetachWithModifierClick.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Node/LinkDetachWithModifierClick.cs`
CoverageBefore: 0.0% (SonarCloud; existing tests skipped)
CoverageAfter: 100.0% (1/1 instrumented line, local coverlet)
TestsAdded: 3 (LinkDetachWithModifierClickCoverageTests.cs)
Commit: test: coverage LinkDetachWithModifierClick.cs
Status: REMEDIATED

## Summary

LinkDetachWithModifierClick.cs is a `public struct` in namespace
`Alis.Extension.Graphic.Ui.Extras.Node` exposing a single executable member: the auto-property
`byte[] Modifier { get; set; }` (line 40). SonarCloud reported 0.0% because the pre-existing
`LinkDetachWithModifierClickTest.cs` class annotates every test with the custom
`[RequireCImguiSystemFact]` attribute, which skips when the native `cimgui` library cannot be
resolved by name via `NativeLibrary.TryLoad`. On this host that lookup fails, so the whole class
was skipped and the only executable line stayed uncovered.

The `Modifier` property needs no native interop — it is a pure managed `byte[]` getter/setter.
A new `LinkDetachWithModifierClickCoverageTests.cs` class uses plain `[Fact]` attributes (always
run) to exercise:
- `Modifier` set/get round-trip of a concrete byte array.
- `Modifier` overwrite semantics.
- default `Modifier == null`.

## Verification

- LinkDetachWithModifierClickCoverageTests filter (net8.0, Debug): 3 passed, 0 failed, 0 skipped.
- Coverlet cobertura: `LinkDetachWithModifierClick` class line-rate=1, branch-rate=1; `get_Modifier` line 40 hit 6 times.
