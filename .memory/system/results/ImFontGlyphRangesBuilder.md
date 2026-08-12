# ImFontGlyphRangesBuilder.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/ImFontGlyphRangesBuilder.cs`
- **Coverage Before**: 0.0% (SonarCloud)
- **Coverage After**: UsedChars property accessors + default-state lines covered; native method bodies (AddChar/Clear/GetBit/SetBit) untestable — calling them aborts the native host via cimgui `operator[]` assert even locally (struct marshaling mismatch)
- **Tests Added**: 3 (ImFontGlyphRangesBuilderRemainingCoverageTests.cs — UsedChars default/round-trip/repeat-read with plain `[Fact]`, run on CI)
- **Uncovered Lines**: Native P/Invoke method bodies requiring native cimgui with correct ImVector layout
- **Status**: COMPLETED
