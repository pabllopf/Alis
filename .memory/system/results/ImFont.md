# Result: ImFont.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImFont.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: All observable public API exercised via ImFontTests — default zero-initialized scalar/pointer/pages-map values and round-trips of float, integer, ushort, byte, pointer, ImVector and byte[] members; 10/10 ImFontTests pass
TestsAdded: 10 (ImFontTests.cs)
Commit: bacda52aaf4daad67fd49ae1ce5ebfc87d7281ed
Status: COMPLETED

## Summary
ImFont is a plain struct exposing auto-property scalars (FallbackAdvanceX, FontSize, Scale, Ascent, Descent, ConfigDataCount, FallbackChar, EllipsisChar, DotChar, DirtyLookupTables, MetricsTotalSurface), pointer properties (FallbackGlyph, ContainerAtlas, ConfigData), ImVector properties (IndexAdvanceX, IndexLookup, Glyphs) and a public Used4KPagesMap field. New ImFontTests.cs exercises the default zero-initialized state and reference/value round-trips through the public setters using only plain [Fact] tests (no cimgui/native calls), ensuring genuine execution on net8.0.

## Verification
- `dotnet build Alis.Extension.Graphic.Ui.Test.csproj -c Debug` → build succeeded (0 errors, 0 warnings)
- `dotnet test Alis.Extension.Graphic.Ui.Test.csproj --filter "FullyQualifiedName~ImFontTests" -c Debug -f net8.0` → Passed: 10, Failed: 0, Skipped: 0
