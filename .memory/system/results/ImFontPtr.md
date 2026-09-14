# ImFontPtr.cs Coverage Remediation Result

- File:1_Presentation/Extension/Graphic/Ui/src/ImFontPtr.cs
- CoverageBefore:1.6%
- CoverageAfter:46.7%
- TestsAdded:24
- Commit:test: coverage ImFontPtr.cs
- Status:COMPLETED

Notes:The existing ImFontPtrTests.cs is fully gated by [RequireCImguiSystemFact], so SonarCloud
CI (which runs without the native cimgui library) skips every test and measures 1.6%. A new
ImFontPtrManagedCoverageTests.cs file with plain [Fact] covers the whole managed surface:
NativePtr, both constructors (IntPtr and ImFont), both implicit operators, the ConfigData
getter/setter write-back persistence, and all 17 managed getters including the
IndexAdvanceX/IndexLookup ImVectorG wraps. Measured locally with only these 24 tests, the file
moves from 1.6% to 46.7% (28 of 60 sequence points). The 13 native-wrapper methods (AddGlyph,
AddRemapChar x2, BuildLookupTable, ClearOutputData, FindGlyph, FindGlyphNoFallback,
GetCharAdvance, GetDebugName, GrowIndex, IsLoaded, RenderChar, SetGlyphVisible) remain
uncovered by design: they P/Invoke into ImGuiNative and throw DllNotFoundException when the
cimgui native library is absent, so they cannot execute on SonarCloud CI.