# Result: ImFontAtlasPtr.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImFontAtlasPtr.cs`
CoverageBefore: 0.0% (SonarCloud)
CoverageAfter: 11.5% (42/364 instrumented lines, local coverlet, ImFontAtlasPtrNullLabelCoverageTests run)
TestsAdded: 27 (ImFontAtlasPtrNullLabelCoverageTests.cs, plain [Fact])
Commit: test: coverage ImFontAtlasPtr.cs
Status: PARTIAL_BLOCKED_BY_PRODUCTION_CODE

## Summary

ImFontAtlasPtr.cs is a `public partial class ImFontAtlasPtr`. Two deterministic-coverable surfaces:

1. Marshal-backed read/write properties and ctors (managed, built-in Marshal, no external native lib):
   the `ImFontAtlasPtr(ImFontAtlas)` ctor uses `Marshal.AllocHGlobal` + `StructureToPtr`; the
   read-properties (Flags, TexId, TexDesiredWidth, TexGlyphPadding, Locked, TexReady,
   TexPixelsUseColors, TexWidth, TexHeight, TexUvScale, TexUvWhitePixel, Fonts, CustomRects,
   ConfigData, FontBuilderFlags, PackIdMouseCursors, PackIdLines) use `Marshal.PtrToStructure<ImFontAtlas>`.
   ImVectorG<T> ctor just copies fields (no dereference) so Fonts/CustomRects/ConfigData are safe.

2. Six GetBytes string methods (AddFontFromFileTtf x3, AddFontFromMemoryCompressedBase85Ttf x3):
   one-line bodies `ImGuiNative.ImFontAtlas_*TTF(NativePtr, Encoding.UTF8.GetBytes(filename), ...)`.
   Null string throws ArgumentNullException at the call site before any native call.

Added `ImFontAtlasPtrNullLabelCoverageTests.cs` (27 plain [Fact]): IntPtr ctor, struct ctor, both
implicit operators, 16 Marshal property tests (incl. TexId setter round-trip and Vector2F/Uint types),
and 6 null-string probes.

## Remaining uncovered (BLOCKED_BY_PRODUCTION_CODE)

The `ImGuiNative.ImFontAtlas_*` P/Invoke call lines and the ~30+ other native methods (AddFontDefault,
AddFontFromMemoryTtf/Compressed, Build, Clear/ClearFonts/ClearInputData/ClearTexData,
CalcCustomRectUv, GetCustomRectByIndex, GetGlyphRanges*, GetMouseCursorTexData, GetTexDataAs*,
IsBuilt, SetTexId). Require native cimgui at runtime or rely on the pointer's unmanaged source.

## Verification

- ImFontAtlasPtrNullLabelCoverageTests-filtered run: 27 passed / 0 failed (net8.0).
- Full project build (Debug): 0 errors.
- Local coverlet: ImFontAtlasPtr.cs 11.5% (42/364 instrumented lines).