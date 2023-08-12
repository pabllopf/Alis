using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Graphic.Imgui
{
    /// <summary>
    /// The im font
    /// </summary>
    public unsafe partial struct ImFont
    {
        /// <summary>
        /// The index advance
        /// </summary>
        public ImVector IndexAdvanceX;
        /// <summary>
        /// The fallback advance
        /// </summary>
        public float FallbackAdvanceX;
        /// <summary>
        /// The font size
        /// </summary>
        public float FontSize;
        /// <summary>
        /// The index lookup
        /// </summary>
        public ImVector IndexLookup;
        /// <summary>
        /// The glyphs
        /// </summary>
        public ImVector Glyphs;
        /// <summary>
        /// The fallback glyph
        /// </summary>
        public ImFontGlyph* FallbackGlyph;
        /// <summary>
        /// The container atlas
        /// </summary>
        public ImFontAtlas* ContainerAtlas;
        /// <summary>
        /// The config data
        /// </summary>
        public ImFontConfig* ConfigData;
        /// <summary>
        /// The config data count
        /// </summary>
        public short ConfigDataCount;
        /// <summary>
        /// The fallback char
        /// </summary>
        public ushort FallbackChar;
        /// <summary>
        /// The ellipsis char
        /// </summary>
        public ushort EllipsisChar;
        /// <summary>
        /// The dot char
        /// </summary>
        public ushort DotChar;
        /// <summary>
        /// The dirty lookup tables
        /// </summary>
        public byte DirtyLookupTables;
        /// <summary>
        /// The scale
        /// </summary>
        public float Scale;
        /// <summary>
        /// The ascent
        /// </summary>
        public float Ascent;
        /// <summary>
        /// The descent
        /// </summary>
        public float Descent;
        /// <summary>
        /// The metrics total surface
        /// </summary>
        public int MetricsTotalSurface;
        /// <summary>
        /// The used 4k pages map
        /// </summary>
        public fixed byte Used4kPagesMap[2];
    }
    /// <summary>
    /// The im font ptr
    /// </summary>
    public unsafe partial struct ImFontPtr
    {
        /// <summary>
        /// Gets the value of the native ptr
        /// </summary>
        public ImFont* NativePtr { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ImFontPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontPtr(ImFont* nativePtr) => NativePtr = nativePtr;
        /// <summary>
        /// Initializes a new instance of the <see cref="ImFontPtr"/> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontPtr(IntPtr nativePtr) => NativePtr = (ImFont*)nativePtr;
        public static implicit operator ImFontPtr(ImFont* nativePtr) => new ImFontPtr(nativePtr);
        public static implicit operator ImFont* (ImFontPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImFontPtr(IntPtr nativePtr) => new ImFontPtr(nativePtr);
        /// <summary>
        /// Gets the value of the index advance x
        /// </summary>
        public ImVector<float> IndexAdvanceX => new ImVector<float>(NativePtr->IndexAdvanceX);
        /// <summary>
        /// Gets the value of the fallback advance x
        /// </summary>
        public ref float FallbackAdvanceX => ref Unsafe.AsRef<float>(&NativePtr->FallbackAdvanceX);
        /// <summary>
        /// Gets the value of the font size
        /// </summary>
        public ref float FontSize => ref Unsafe.AsRef<float>(&NativePtr->FontSize);
        /// <summary>
        /// Gets the value of the index lookup
        /// </summary>
        public ImVector<ushort> IndexLookup => new ImVector<ushort>(NativePtr->IndexLookup);
        /// <summary>
        /// Gets the value of the glyphs
        /// </summary>
        public ImPtrVector<ImFontGlyphPtr> Glyphs => new ImPtrVector<ImFontGlyphPtr>(NativePtr->Glyphs, Unsafe.SizeOf<ImFontGlyph>());
        /// <summary>
        /// Gets the value of the fallback glyph
        /// </summary>
        public ImFontGlyphPtr FallbackGlyph => new ImFontGlyphPtr(NativePtr->FallbackGlyph);
        /// <summary>
        /// Gets the value of the container atlas
        /// </summary>
        public ImFontAtlasPtr ContainerAtlas => new ImFontAtlasPtr(NativePtr->ContainerAtlas);
        /// <summary>
        /// Gets the value of the config data
        /// </summary>
        public ImFontConfigPtr ConfigData => new ImFontConfigPtr(NativePtr->ConfigData);
        /// <summary>
        /// Gets the value of the config data count
        /// </summary>
        public ref short ConfigDataCount => ref Unsafe.AsRef<short>(&NativePtr->ConfigDataCount);
        /// <summary>
        /// Gets the value of the fallback char
        /// </summary>
        public ref ushort FallbackChar => ref Unsafe.AsRef<ushort>(&NativePtr->FallbackChar);
        /// <summary>
        /// Gets the value of the ellipsis char
        /// </summary>
        public ref ushort EllipsisChar => ref Unsafe.AsRef<ushort>(&NativePtr->EllipsisChar);
        /// <summary>
        /// Gets the value of the dot char
        /// </summary>
        public ref ushort DotChar => ref Unsafe.AsRef<ushort>(&NativePtr->DotChar);
        /// <summary>
        /// Gets the value of the dirty lookup tables
        /// </summary>
        public ref bool DirtyLookupTables => ref Unsafe.AsRef<bool>(&NativePtr->DirtyLookupTables);
        /// <summary>
        /// Gets the value of the scale
        /// </summary>
        public ref float Scale => ref Unsafe.AsRef<float>(&NativePtr->Scale);
        /// <summary>
        /// Gets the value of the ascent
        /// </summary>
        public ref float Ascent => ref Unsafe.AsRef<float>(&NativePtr->Ascent);
        /// <summary>
        /// Gets the value of the descent
        /// </summary>
        public ref float Descent => ref Unsafe.AsRef<float>(&NativePtr->Descent);
        /// <summary>
        /// Gets the value of the metrics total surface
        /// </summary>
        public ref int MetricsTotalSurface => ref Unsafe.AsRef<int>(&NativePtr->MetricsTotalSurface);
        /// <summary>
        /// Gets the value of the used 4k pages map
        /// </summary>
        public RangeAccessor<byte> Used4kPagesMap => new RangeAccessor<byte>(NativePtr->Used4kPagesMap, 2);
        /// <summary>
        /// Adds the glyph using the specified src cfg
        /// </summary>
        /// <param name="src_cfg">The src cfg</param>
        /// <param name="c">The </param>
        /// <param name="x0">The </param>
        /// <param name="y0">The </param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="u0">The </param>
        /// <param name="v0">The </param>
        /// <param name="u1">The </param>
        /// <param name="v1">The </param>
        /// <param name="advance_x">The advance</param>
        public void AddGlyph(ImFontConfigPtr src_cfg, ushort c, float x0, float y0, float x1, float y1, float u0, float v0, float u1, float v1, float advance_x)
        {
            ImFontConfig* native_src_cfg = src_cfg.NativePtr;
            ImGuiNative.ImFont_AddGlyph((ImFont*)(NativePtr), native_src_cfg, c, x0, y0, x1, y1, u0, v0, u1, v1, advance_x);
        }
        /// <summary>
        /// Adds the remap char using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        public void AddRemapChar(ushort dst, ushort src)
        {
            byte overwrite_dst = 1;
            ImGuiNative.ImFont_AddRemapChar((ImFont*)(NativePtr), dst, src, overwrite_dst);
        }
        /// <summary>
        /// Adds the remap char using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="overwrite_dst">The overwrite dst</param>
        public void AddRemapChar(ushort dst, ushort src, bool overwrite_dst)
        {
            byte native_overwrite_dst = overwrite_dst ? (byte)1 : (byte)0;
            ImGuiNative.ImFont_AddRemapChar((ImFont*)(NativePtr), dst, src, native_overwrite_dst);
        }
        /// <summary>
        /// Builds the lookup table
        /// </summary>
        public void BuildLookupTable()
        {
            ImGuiNative.ImFont_BuildLookupTable((ImFont*)(NativePtr));
        }
        /// <summary>
        /// Clears the output data
        /// </summary>
        public void ClearOutputData()
        {
            ImGuiNative.ImFont_ClearOutputData((ImFont*)(NativePtr));
        }
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImFont_destroy((ImFont*)(NativePtr));
        }
        /// <summary>
        /// Finds the glyph using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The im font glyph ptr</returns>
        public ImFontGlyphPtr FindGlyph(ushort c)
        {
            ImFontGlyph* ret = ImGuiNative.ImFont_FindGlyph((ImFont*)(NativePtr), c);
            return new ImFontGlyphPtr(ret);
        }
        /// <summary>
        /// Finds the glyph no fallback using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The im font glyph ptr</returns>
        public ImFontGlyphPtr FindGlyphNoFallback(ushort c)
        {
            ImFontGlyph* ret = ImGuiNative.ImFont_FindGlyphNoFallback((ImFont*)(NativePtr), c);
            return new ImFontGlyphPtr(ret);
        }
        /// <summary>
        /// Gets the char advance using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The ret</returns>
        public float GetCharAdvance(ushort c)
        {
            float ret = ImGuiNative.ImFont_GetCharAdvance((ImFont*)(NativePtr), c);
            return ret;
        }
        /// <summary>
        /// Gets the debug name
        /// </summary>
        /// <returns>The string</returns>
        public string GetDebugName()
        {
            byte* ret = ImGuiNative.ImFont_GetDebugName((ImFont*)(NativePtr));
            return Util.StringFromPtr(ret);
        }
        /// <summary>
        /// Grows the index using the specified new size
        /// </summary>
        /// <param name="new_size">The new size</param>
        public void GrowIndex(int new_size)
        {
            ImGuiNative.ImFont_GrowIndex((ImFont*)(NativePtr), new_size);
        }
        /// <summary>
        /// Describes whether this instance is loaded
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsLoaded()
        {
            byte ret = ImGuiNative.ImFont_IsLoaded((ImFont*)(NativePtr));
            return ret != 0;
        }
        /// <summary>
        /// Renders the char using the specified draw list
        /// </summary>
        /// <param name="draw_list">The draw list</param>
        /// <param name="size">The size</param>
        /// <param name="pos">The pos</param>
        /// <param name="col">The col</param>
        /// <param name="c">The </param>
        public void RenderChar(ImDrawListPtr draw_list, float size, Vector2 pos, uint col, ushort c)
        {
            ImDrawList* native_draw_list = draw_list.NativePtr;
            ImGuiNative.ImFont_RenderChar((ImFont*)(NativePtr), native_draw_list, size, pos, col, c);
        }
        /// <summary>
        /// Sets the glyph visible using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <param name="visible">The visible</param>
        public void SetGlyphVisible(ushort c, bool visible)
        {
            byte native_visible = visible ? (byte)1 : (byte)0;
            ImGuiNative.ImFont_SetGlyphVisible((ImFont*)(NativePtr), c, native_visible);
        }
    }
}
