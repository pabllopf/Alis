# Result: ImFontConfigPtr.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImFontConfigPtr.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 100% (92/92 lines, 100% branches; local coverlet, ImFontConfigPtr filter)
TestsAdded: 25 (ImFontConfigPtrTests.cs)
Commit: ebda147415d2a26b7e952729da491ca2d8d606e6
Status: COMPLETED

## Summary

ImFontConfigPtr.cs is a cimgui `ImFontConfig*` wrapper (readonly struct, 27 complexity / 72 LOC per SonarCloud). It was safely testable without a live native context because every member is pure managed marshaling over an allocated `ImFontConfig` block: the IntPtr and ImFontConfig constructors, the `NativePtr` property, both implicit IntPtr conversions, and every getter/setter (FontData, FontDataSize, FontDataOwnedByAtlas, FontNo, SizePixels, OversampleH/V, SnapH, GlyphExtraSpacing, GlyphOffset, GlyphRanges, GlyphMinAdvanceX, GlyphMaxAdvanceX, MergeMode, FontBuilderFlags, RasterizerMultiply, EllipsisChar, DstFont). None of these dereference native cimgui entry points, so they never crash on a valid allocated block; the zero-pointer path for the dereferencing getters is exercised via a NullReferenceException assertion. Added 25 new tests; all 151 ImFontConfigPtr-filter tests pass (25 new + 126 pre-existing).

## Verification

- dotnet build 1_Presentation/Extension/Graphic/Ui/test/Alis.Extension.Graphic.Ui.Test.csproj -c Debug -> PASS (0 warnings, 0 errors)
- dotnet test 1_Presentation/Extension/Graphic/Ui/test/Alis.Extension.Graphic.Ui.Test.csproj --filter FullyQualifiedName~ImFontConfigPtr -c Debug -f net8.0 -> PASS (151 passed, 0 failed, 0 skipped)
- dotnet test ... --collect "XPlat Code Coverage" -> ImFontConfigPtr 92/92 lines (100%), branch-rate 1
