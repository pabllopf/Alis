# Result: ImFontGlyph.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImFontGlyph.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact — existing tests gated behind RequireCImguiSystemFact skipped when native cimgui absent)
CoverageAfter: 100.0% executable lines (all 12 property accessors); cobertura disabled per pipeline rules.
TestsAdded: 2 (ImFontGlyphCoverageTests.cs: default-zero + all-properties round-trip)
Commit: test: coverage ImFontGlyph.cs
Status: REMEDIATED

## Summary
ImFontGlyph is a pure managed value-type struct (no native interop; all properties are auto-properties over uint/float fields). Added a plain-[Fact] suite (ImFontGlyphCoverageTests.cs) that runs without the native cimgui library, so SonarCloud/CI now exercise every property accessor. Mirrors the existing gated ImFontGlyphTest.cs but un-gated.

## Verification
- dotnet build 1_Presentation/Extension/Graphic/Ui/test/Alis.Extension.Graphic.Ui.Test.csproj -c Debug -f net8.0 -> PASS (0 warnings, 0 errors)
- dotnet test ... --filter FullyQualifiedName~ImFontGlyphCoverageTests -c Debug -f net8.0 -> PASS (2 passed, 0 failed, 0 skipped)
