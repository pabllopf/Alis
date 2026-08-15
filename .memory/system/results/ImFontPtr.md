# ImFontPtr.cs

- **File**: `1_Presentation/Extension/Graphic/Ui/src/ImFontPtr.cs`
- **Coverage Before**: 6.3% (SonarCloud)
- **Coverage After**: 95.0% (57/60 lines, local coverlet with existing tests)
- **Tests Added**: 0 (existing ImFontPtrTests/NativeCoverage/RemainingCoverage suites already cover all but RenderChar)
- **Uncovered Lines**: 290-292 (RenderChar) — native ImFont_RenderChar into the background draw list crashes this cimgui build (verified with and without an active frame); production/native constraint
- **Status**: COMPLETED
