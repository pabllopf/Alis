# Result: ImFontAtlasCustomRect.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImFontAtlasCustomRect.cs`
CoverageBefore: 0.0% (SonarCloud, stale artifact)
CoverageAfter: 100.0% (8/8, local coverlet, ImFontAtlasCustomRect-filtered run)
TestsAdded: 0 (already covered by committed ImFontAtlasCustomRectTest.cs + ImFontAtlasCustomRectRemainingCoverageTests.cs)
Commit: test: coverage ImFontAtlasCustomRect.cs
Status: ALREADY_REMEDIATED

## Summary

ImFontAtlasCustomRect.cs is a plain struct (8 auto-properties only: `Width`, `Height`,
`X`, `Y`, `GlyphId`, `GlyphAdvanceX`, `GlyphOffset`, `Font`; no logic).

The committed `ImFontAtlasCustomRectTest.cs` (16 tests, `[RequireCImguiSystemFact]`) tests
every property's default value and its set/get round trip, and
`ImFontAtlasCustomRectRemainingCoverageTests.cs` (5 tests) covers default zero values and
round trips. Local coverlet on the ImFontAtlasCustomRect-filtered run reports 100.0% (8/8
instrumented lines). The SonarCloud 0.0% is a stale artifact (tests not yet uploaded).

## Verification

- ImFontAtlasCustomRect-filtered run: 21 passed / 0 failed (net8.0).
- Local coverlet: ImFontAtlasCustomRect.cs 100.0% (8/8 lines).
