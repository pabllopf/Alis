// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlasPtr.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im font atlas ptr
    /// </summary>
    public readonly struct ImFontAtlasPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public IntPtr NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontAtlasPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontAtlasPtr(IntPtr nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontAtlasPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontAtlasPtr(ImFontAtlas nativePtr)
        {
            NativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontAtlas>());
            Marshal.StructureToPtr(nativePtr, NativePtr, false);
        }

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator IntPtr(ImFontAtlasPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontAtlasPtr(IntPtr nativePtr) => new ImFontAtlasPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the flags
        /// </summary>
        public ImFontAtlasFlags Flags => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).Flags;

        /// <summary>
        ///     Gets the value of the tex id
        /// </summary>
        public IntPtr TexId
        {
            get => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).TexId;
            set
            {
                // Write x and y values to the DisplaySize field
                ImFontAtlas io = Marshal.PtrToStructure<ImFontAtlas>(NativePtr);
                io.TexId = value;
                Marshal.StructureToPtr(io, NativePtr, false);
            }
        }

        /// <summary>
        ///     Gets the value of the tex desired width
        /// </summary>
        public int TexDesiredWidth => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).TexDesiredWidth;

        /// <summary>
        ///     Gets the value of the tex glyph padding
        /// </summary>
        public int TexGlyphPadding => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).TexGlyphPadding;

        /// <summary>
        ///     Gets the value of the locked
        /// </summary>
        public bool Locked => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).Locked != 0;

        /// <summary>
        ///     Gets the value of the tex ready
        /// </summary>
        public bool TexReady => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).TexReady != 0;

        /// <summary>
        ///     Gets the value of the tex pixels use colors
        /// </summary>
        public bool TexPixelsUseColors => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).TexPixelsUseColors != 0;

        /// <summary>
        ///     Gets or sets the value of the tex pixels alpha 8
        /// </summary>
        public IntPtr TexPixelsAlpha8
        {
            get => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).TexPixelsAlpha8;
            set => Marshal.WriteIntPtr(NativePtr, Marshal.OffsetOf<ImFontAtlas>("TexPixelsAlpha8").ToInt32(), value);
        }

        /// <summary>
        ///     Gets or sets the value of the tex pixels rgba 32
        /// </summary>
        public IntPtr TexPixelsRgba32
        {
            get => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).TexPixelsRgba32;
            set => Marshal.WriteIntPtr(NativePtr, Marshal.OffsetOf<ImFontAtlas>("TexPixelsRgba32").ToInt32(), value);
        }

        /// <summary>
        ///     Gets the value of the tex width
        /// </summary>
        public int TexWidth => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).TexWidth;

        /// <summary>
        ///     Gets the value of the tex height
        /// </summary>
        public int TexHeight => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).TexHeight;

        /// <summary>
        ///     Gets the value of the tex uv scale
        /// </summary>
        public Vector2F TexUvScale => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).TexUvScale;

        /// <summary>
        ///     Gets the value of the tex uv white pixel
        /// </summary>
        public Vector2F TexUvWhitePixel => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).TexUvWhitePixel;

        /// <summary>
        ///     Gets the value of the fonts
        /// </summary>
        public ImVectorG<ImFontPtr> Fonts => new ImVectorG<ImFontPtr>(Marshal.PtrToStructure<ImFontAtlas>(NativePtr).Fonts);

        /// <summary>
        ///     Gets the value of the custom rects
        /// </summary>
        public ImVectorG<ImFontAtlasCustomRect> CustomRects => new ImVectorG<ImFontAtlasCustomRect>(Marshal.PtrToStructure<ImFontAtlas>(NativePtr).CustomRects);

        /// <summary>
        ///     Gets the value of the config data
        /// </summary>
        public ImVectorG<ImFontConfigPtr> ConfigData => new ImVectorG<ImFontConfigPtr>(Marshal.PtrToStructure<ImFontAtlas>(NativePtr).ConfigData);

        /// <summary>
        ///     Gets or sets the value of the font builder io
        /// </summary>
        public IntPtr FontBuilderIo
        {
            get => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).FontBuilderIo;
            set => Marshal.WriteIntPtr(NativePtr, Marshal.OffsetOf<ImFontAtlas>("FontBuilderIO").ToInt32(), value);
        }

        /// <summary>
        ///     Gets the value of the font builder flags
        /// </summary>
        public uint FontBuilderFlags => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).FontBuilderFlags;

        /// <summary>
        ///     Gets the value of the pack id mouse cursors
        /// </summary>
        public int PackIdMouseCursors => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).PackIdMouseCursors;

        /// <summary>
        ///     Gets the value of the pack id lines
        /// </summary>
        public int PackIdLines => Marshal.PtrToStructure<ImFontAtlas>(NativePtr).PackIdLines;

        /// <summary>
        ///     Adds the custom rect font glyph using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="id">The id</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="advanceX">The advance</param>
        /// <returns>The ret</returns>
        public int AddCustomRectFontGlyph(ImFontPtr font, ushort id, int width, int height, float advanceX)
        {
            Vector2F offset = new Vector2F();
            int ret = ImGuiNative.ImFontAtlas_AddCustomRectFontGlyph(NativePtr, font.NativePtr, id, width, height, advanceX, offset);
            return ret;
        }

        /// <summary>
        ///     Adds the custom rect font glyph using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="id">The id</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="advanceX">The advance</param>
        /// <param name="offset">The offset</param>
        /// <returns>The ret</returns>
        public int AddCustomRectFontGlyph(ImFontPtr font, ushort id, int width, int height, float advanceX, Vector2F offset)
        {
            int ret = ImGuiNative.ImFontAtlas_AddCustomRectFontGlyph(NativePtr, font.NativePtr, id, width, height, advanceX, offset);
            return ret;
        }

        /// <summary>
        ///     Adds the custom rect regular using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The ret</returns>
        public int AddCustomRectRegular(int width, int height)
        {
            int ret = ImGuiNative.ImFontAtlas_AddCustomRectRegular(NativePtr, width, height);
            return ret;
        }

        /// <summary>
        ///     Adds the font using the specified font cfg
        /// </summary>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFont(ImFontConfigPtr fontCfg)
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFont(NativePtr, fontCfg.NativePtr);
            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font default
        /// </summary>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontDefault() => new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontDefault(NativePtr, new IntPtr()));

        /// <summary>
        ///     Adds the font default using the specified font cfg
        /// </summary>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontDefault(ImFontConfigPtr fontCfg) => new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontDefault(NativePtr, fontCfg.NativePtr));

        /// <summary>
        ///     Adds the font from file ttf using the specified filename
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromFileTtf(string filename, float sizePixels)
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromFileTTF(NativePtr, Encoding.UTF8.GetBytes(filename), sizePixels, new IntPtr(), new IntPtr());

            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from file ttf using the specified filename
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromFileTtf(string filename, float sizePixels, ImFontConfigPtr fontCfg)
        {
            ushort[] glyphRanges = new ushort[0];
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromFileTTF(NativePtr, Encoding.UTF8.GetBytes(filename), sizePixels, fontCfg.NativePtr, new IntPtr());
            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from file ttf using the specified filename
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <param name="glyphRanges">The glyph ranges</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromFileTtf(string filename, float sizePixels, ImFontConfigPtr fontCfg, IntPtr glyphRanges)
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromFileTTF(NativePtr, Encoding.UTF8.GetBytes(filename), sizePixels, fontCfg.NativePtr, glyphRanges);

            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from memory compressed base 85 ttf using the specified compressed font data base85
        /// </summary>
        /// <param name="compressedFontDataBase85">The compressed font data base85</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedBase85Ttf(string compressedFontDataBase85, float sizePixels)
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(NativePtr, Encoding.UTF8.GetBytes(compressedFontDataBase85), sizePixels, new IntPtr(), new IntPtr());

            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from memory compressed base 85 ttf using the specified compressed font data base85
        /// </summary>
        /// <param name="compressedFontDataBase85">The compressed font data base85</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedBase85Ttf(string compressedFontDataBase85, float sizePixels, ImFontConfigPtr fontCfg)
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(NativePtr, Encoding.UTF8.GetBytes(compressedFontDataBase85), sizePixels, fontCfg.NativePtr, new IntPtr());
            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from memory compressed base 85 ttf using the specified compressed font data base85
        /// </summary>
        /// <param name="compressedFontDataBase85">The compressed font data base85</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <param name="glyphRanges">The glyph ranges</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedBase85Ttf(string compressedFontDataBase85, float sizePixels, ImFontConfigPtr fontCfg, IntPtr glyphRanges)
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(NativePtr, Encoding.UTF8.GetBytes(compressedFontDataBase85), sizePixels, fontCfg.NativePtr, glyphRanges);

            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from memory compressed ttf using the specified compressed font data
        /// </summary>
        /// <param name="compressedFontData">The compressed font data</param>
        /// <param name="compressedFontSize">The compressed font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedTtf(IntPtr compressedFontData, int compressedFontSize, float sizePixels)
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF(NativePtr, compressedFontData, compressedFontSize, sizePixels, new IntPtr(), new IntPtr());
            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from memory compressed ttf using the specified compressed font data
        /// </summary>
        /// <param name="compressedFontData">The compressed font data</param>
        /// <param name="compressedFontSize">The compressed font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedTtf(IntPtr compressedFontData, int compressedFontSize, float sizePixels, ImFontConfigPtr fontCfg)
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF(NativePtr, compressedFontData, compressedFontSize, sizePixels, fontCfg.NativePtr, new IntPtr());
            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from memory compressed ttf using the specified compressed font data
        /// </summary>
        /// <param name="compressedFontData">The compressed font data</param>
        /// <param name="compressedFontSize">The compressed font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <param name="glyphRanges">The glyph ranges</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedTtf(IntPtr compressedFontData, int compressedFontSize, float sizePixels, ImFontConfigPtr fontCfg, IntPtr glyphRanges)
        {
            IntPtr nativeCompressedFontData = compressedFontData;
            IntPtr nativeGlyphRanges = glyphRanges;
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF(NativePtr, nativeCompressedFontData, compressedFontSize, sizePixels, fontCfg.NativePtr, nativeGlyphRanges);
            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from memory ttf using the specified font data
        /// </summary>
        /// <param name="fontData">The font data</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryTtf(IntPtr fontData, int fontSize, float sizePixels) => new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF(NativePtr, fontData, fontSize, sizePixels, new IntPtr(), new IntPtr()));

        /// <summary>
        ///     Adds the font from memory ttf using the specified font data
        /// </summary>
        /// <param name="fontData">The font data</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryTtf(IntPtr fontData, int fontSize, float sizePixels, ImFontConfigPtr fontCfg) => new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF(NativePtr, fontData, fontSize, sizePixels, fontCfg.NativePtr, new IntPtr()));

        /// <summary>
        ///     Adds the font from memory ttf using the specified font data
        /// </summary>
        /// <param name="fontData">The font data</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <param name="glyphRanges">The glyph ranges</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryTtf(IntPtr fontData, int fontSize, float sizePixels, ImFontConfigPtr fontCfg, IntPtr glyphRanges)
        {
            IntPtr nativeFontData = fontData;
            IntPtr nativeGlyphRanges = glyphRanges;
            return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF(NativePtr, nativeFontData, fontSize, sizePixels, fontCfg.NativePtr, nativeGlyphRanges));
        }

        /// <summary>
        ///     Describes whether this instance build
        /// </summary>
        /// <returns>The bool</returns>
        public bool Build()
        {
            byte ret = ImGuiNative.ImFontAtlas_Build(NativePtr);
            return ret != 0;
        }

        /// <summary>
        ///     Calcs the custom rect uv using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        /// <param name="outUvMin">The out uv min</param>
        /// <param name="outUvMax">The out uv max</param>
        public void CalcCustomRectUv(ImFontAtlasCustomRect rect, out Vector2F outUvMin, out Vector2F outUvMax)
        {
            ImGuiNative.ImFontAtlas_CalcCustomRectUV(NativePtr, rect, out outUvMin, out outUvMax);
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImFontAtlas_Clear(NativePtr);
        }

        /// <summary>
        ///     Clears the fonts
        /// </summary>
        public void ClearFonts()
        {
            ImGuiNative.ImFontAtlas_ClearFonts(NativePtr);
        }

        /// <summary>
        ///     Clears the input data
        /// </summary>
        public void ClearInputData()
        {
            ImGuiNative.ImFontAtlas_ClearInputData(NativePtr);
        }

        /// <summary>
        ///     Clears the tex data
        /// </summary>
        public void ClearTexData()
        {
            ImGuiNative.ImFontAtlas_ClearTexData(NativePtr);
        }

        /// <summary>
        ///     Gets the custom rect by index using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The im font atlas custom rect ptr</returns>
        public ImFontAtlasCustomRect GetCustomRectByIndex(int index) => ImGuiNative.ImFontAtlas_GetCustomRectByIndex(NativePtr, index);

        /// <summary>
        ///     Gets the glyph ranges chinese full
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesChineseFull()
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_GetGlyphRangesChineseFull(NativePtr);
            return ret;
        }

        /// <summary>
        ///     Gets the glyph ranges chinese simplified common
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesChineseSimplifiedCommon()
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_GetGlyphRangesChineseSimplifiedCommon(NativePtr);
            return ret;
        }

        /// <summary>
        ///     Gets the glyph ranges cyrillic
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesCyrillic()
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_GetGlyphRangesCyrillic(NativePtr);
            return ret;
        }

        /// <summary>
        ///     Gets the glyph ranges default
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesDefault()
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_GetGlyphRangesDefault(NativePtr);
            return ret;
        }

        /// <summary>
        ///     Gets the glyph ranges greek
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesGreek()
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_GetGlyphRangesGreek(NativePtr);
            return ret;
        }

        /// <summary>
        ///     Gets the glyph ranges japanese
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesJapanese()
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_GetGlyphRangesJapanese(NativePtr);
            return ret;
        }

        /// <summary>
        ///     Gets the glyph ranges korean
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesKorean()
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_GetGlyphRangesKorean(NativePtr);
            return ret;
        }

        /// <summary>
        ///     Gets the glyph ranges thai
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesThai() => ImGuiNative.ImFontAtlas_GetGlyphRangesThai(NativePtr);

        /// <summary>
        ///     Gets the glyph ranges vietnamese
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesVietnamese() => ImGuiNative.ImFontAtlas_GetGlyphRangesVietnamese(NativePtr);

        /// <summary>
        ///     Describes whether this instance get mouse cursor tex data
        /// </summary>
        /// <param name="cursor">The cursor</param>
        /// <param name="outOffset">The out offset</param>
        /// <param name="outSize">The out size</param>
        /// <param name="outUvBorder">The out uv border</param>
        /// <param name="outUvFill">The out uv fill</param>
        /// <returns>The bool</returns>
        public bool GetMouseCursorTexData(ImGuiMouseCursor cursor, out Vector2F outOffset, out Vector2F outSize, out Vector2F outUvBorder, out Vector2F outUvFill)
        {
            byte ret = ImGuiNative.ImFontAtlas_GetMouseCursorTexData(NativePtr, cursor, out outOffset, out outSize, out outUvBorder, out outUvFill);
            return ret != 0;
        }

        /// <summary>
        ///     Gets the tex data as alpha 8 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        public void GetTexDataAsAlpha8(out byte[] outPixels, out int outWidth, out int outHeight)
        {
            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(NativePtr, out outPixels, out outWidth, out outHeight, out _);
        }

        /// <summary>
        ///     Gets the tex data as alpha 8 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        /// <param name="outBytesPerPixel">The out bytes per pixel</param>
        public void GetTexDataAsAlpha8(out byte[] outPixels, out int outWidth, out int outHeight, out int outBytesPerPixel)
        {
            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(NativePtr, out outPixels, out outWidth, out outHeight, out outBytesPerPixel);
        }

        /// <summary>
        ///     Gets the tex data as alpha 8 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        public void GetTexDataAsAlpha8(out IntPtr outPixels, out int outWidth, out int outHeight)
        {
            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(NativePtr, out outPixels, out outWidth, out outHeight, out _);
        }

        /// <summary>
        ///     Gets the tex data as alpha 8 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        /// <param name="outBytesPerPixel">The out bytes per pixel</param>
        public void GetTexDataAsAlpha8(out IntPtr outPixels, out int outWidth, out int outHeight, out int outBytesPerPixel)
        {
            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(NativePtr, out outPixels, out outWidth, out outHeight, out outBytesPerPixel);
        }

        /// <summary>
        ///     Gets the tex data as rgba 32 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        /// <param name="outBytesPerPixel">The out bytes per pixel</param>
        public void GetTexDataAsRgba32(out byte[] outPixels, out int outWidth, out int outHeight, out int outBytesPerPixel)
        {
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(NativePtr, out outPixels, out outWidth, out outHeight, out outBytesPerPixel);
        }

        /// <summary>
        ///     Gets the tex data as rgba 32 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        public void GetTexDataAsRgba32(out IntPtr outPixels, out int outWidth, out int outHeight)
        {
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(NativePtr, out outPixels, out outWidth, out outHeight, out _);
        }

        /// <summary>
        ///     Gets the tex data as rgba 32 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        /// <param name="outBytesPerPixel">The out bytes per pixel</param>
        public void GetTexDataAsRgba32(out IntPtr outPixels, out int outWidth, out int outHeight, out int outBytesPerPixel)
        {
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(NativePtr, out outPixels, out outWidth, out outHeight, out outBytesPerPixel);
        }

        /// <summary>
        ///     Describes whether this instance is built
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsBuilt()
        {
            byte ret = ImGuiNative.ImFontAtlas_IsBuilt(NativePtr);
            return ret != 0;
        }

        /// <summary>
        ///     Sets the tex id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public void SetTexId(IntPtr id)
        {
            ImGuiNative.ImFontAtlas_SetTexID(NativePtr, id);
        }
    }
}