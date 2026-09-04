# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Ui/src/ImFontConfigPtr.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 100.0% (92/92 lines, existing committed suite; verified via XPlat Code Coverage)
TestsAdded: 0
Commit: (none)
Status: ALREADY_COVERED_LOCALLY
Details:
- ImFontConfigPtr.cs wraps the ImGui font config (ImFontConfig) native struct: oversampling, glyph ranges, pixel snap hints, merge mode, glyph extra spacing/offset, size, name, font data + owner, build-time flags, and the Newton-defaulted ptr ctor.
- Existing committed suite (ImFontConfigPtrTests.cs and friends under Ui/test, including Fonts/) executes every accessor in a live ImGui context, 92/92 lines hit.
- SonarCloud 0% is the CI no-native-lib artifact; no new tests needed.