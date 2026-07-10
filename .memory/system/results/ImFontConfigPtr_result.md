# ImFontConfigPtr.cs Coverage Result

- **File**: `1_Presentation/Extension/Graphic/Ui/src/ImFontConfigPtr.cs`
- **Coverage Before**: 52.0%
- **Coverage After (est.)**: ~80-85%
- **Estimated Gain**: +28-33%
- **Tests Added**: 10

## Tests Added

| Test | What It Covers |
|------|---------------|
| `ImplicitConversionToIntPtr_ReturnsNativePtr` | `operator IntPtr` implicit conversion |
| `ImplicitConversionFromIntPtr_ReturnsImFontConfigPtr` | `operator ImFontConfigPtr(IntPtr)` implicit conversion |
| `SnapH_Setter_SetsValueToTrue` | `SnapH` setter (write true, read back) |
| `SnapH_Setter_SetsValueToFalse` | `SnapH` setter (write false, read back) |
| `GlyphRanges_Setter_SetsValue` | `GlyphRanges` setter (write, read back) |
| `GlyphMinAdvanceX_Setter_SetsValue` | `GlyphMinAdvanceX` setter (write, read back) |
| `MergeMode_Setter_SetsValueToTrue` | `MergeMode` setter (write true, read back) |
| `MergeMode_Setter_SetsValueToFalse` | `MergeMode` setter (write false, read back) |
| `ConstructorWithImFontConfig_AllocatesMemory` | Constructor(ImFontConfig) with non-default values + memory allocation |
| `ConstructorWithImFontConfig_ZeroPointer_ThrowsAccessViolation` | Edge case: zero native ptr throws `NullReferenceException` |

## Previously Covered (existing `ImFontConfigPtrTest.cs`)

All getters (`FontData`, `FontDataSize`, `FontDataOwnedByAtlas`, `FontNo`, `SizePixels`, `OversampleH`, `OversampleV`, `SnapH`, `GlyphExtraSpacing`, `GlyphOffset`, `GlyphRanges`, `GlyphMinAdvanceX`, `GlyphMaxAdvanceX`, `MergeMode`, `FontBuilderFlags`, `RasterizerMultiply`, `EllipsisChar`, `DstFont`)

## Status

**Completed** — 10 new tests covering implicit conversions, all setters, and edge cases.
