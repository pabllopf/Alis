# Result: MultipleSelectModifier.cs

File: `1_Presentation/Extension/Graphic/Ui/src/Extras/Node/MultipleSelectModifier.cs`
CoverageBefore: 0.0% (SonarCloud; existing tests skipped)
CoverageAfter: 100.0% (1/1 instrumented line, local coverlet)
TestsAdded: 3 (MultipleSelectModifierCoverageTests.cs)
Commit: test: coverage MultipleSelectModifier.cs
Status: REMEDIATED

## Summary

MultipleSelectModifier.cs is a `public struct` in namespace
`Alis.Extension.Graphic.Ui.Extras.Node` exposing a single executable member: the auto-property
`byte[] Modifier { get; set; }` (line 40). SonarCloud reported 0.0% because the pre-existing
`MultipleSelectModifierTest.cs` and `MultipleSelectModifierTests.cs` classes annotate every test
with the custom `[RequireCImguiSystemFact]` attribute, which skips when the native `cimgui`
library cannot be resolved by name via `NativeLibrary.TryLoad`. On this host that lookup fails,
so the whole classes were skipped and the only executable line stayed uncovered.

The `Modifier` property needs no native interop — it is a pure managed `byte[]` getter/setter.
A new `MultipleSelectModifierCoverageTests.cs` class uses plain `[Fact]` attributes (always run)
to exercise:
- `Modifier` set/get round-trip of a concrete byte array.
- `Modifier` overwrite semantics.
- default `Modifier == null`.

## Verification

- MultipleSelectModifierCoverageTests filter (net8.0, Debug): 3 passed, 0 failed, 0 skipped.
- Coverlet cobertura: `MultipleSelectModifier` class line-rate=1, branch-rate=1; `get_Modifier` line 40 hit 6 times.
