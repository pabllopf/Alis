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
using System.Text;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui.Utils;

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im font atlas ptr
    /// </summary>
    public readonly unsafe struct ImFontAtlasPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImFontAtlas* NativePtr { get; }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontAtlasPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontAtlasPtr(ImFontAtlas* nativePtr) => NativePtr = nativePtr;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontAtlasPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontAtlasPtr(IntPtr nativePtr) => NativePtr = (ImFontAtlas*) nativePtr;
        
        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontAtlasPtr(ImFontAtlas* nativePtr) => new ImFontAtlasPtr(nativePtr);
        
        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontAtlas*(ImFontAtlasPtr wrappedPtr) => wrappedPtr.NativePtr;
        
        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontAtlasPtr(IntPtr nativePtr) => new ImFontAtlasPtr(nativePtr);
        
        /// <summary>
        ///     Gets the value of the flags
        /// </summary>
        public ref ImFontAtlasFlags Flags => ref Unsafe.AsRef<ImFontAtlasFlags>(&NativePtr->Flags);
        
        /// <summary>
        ///     Gets the value of the tex id
        /// </summary>
        public ref IntPtr TexId => ref Unsafe.AsRef<IntPtr>(&NativePtr->TexId);
        
        /// <summary>
        ///     Gets the value of the tex desired width
        /// </summary>
        public ref int TexDesiredWidth => ref Unsafe.AsRef<int>(&NativePtr->TexDesiredWidth);
        
        /// <summary>
        ///     Gets the value of the tex glyph padding
        /// </summary>
        public ref int TexGlyphPadding => ref Unsafe.AsRef<int>(&NativePtr->TexGlyphPadding);
        
        /// <summary>
        ///     Gets the value of the locked
        /// </summary>
        public ref bool Locked => ref Unsafe.AsRef<bool>(&NativePtr->Locked);
        
        /// <summary>
        ///     Gets the value of the tex ready
        /// </summary>
        public ref bool TexReady => ref Unsafe.AsRef<bool>(&NativePtr->TexReady);
        
        /// <summary>
        ///     Gets the value of the tex pixels use colors
        /// </summary>
        public ref bool TexPixelsUseColors => ref Unsafe.AsRef<bool>(&NativePtr->TexPixelsUseColors);
        
        /// <summary>
        ///     Gets or sets the value of the tex pixels alpha 8
        /// </summary>
        public IntPtr TexPixelsAlpha8
        {
            get => (IntPtr) NativePtr->TexPixelsAlpha8;
            set => NativePtr->TexPixelsAlpha8 = (byte*) value;
        }
        
        /// <summary>
        ///     Gets or sets the value of the tex pixels rgba 32
        /// </summary>
        public IntPtr TexPixelsRgba32
        {
            get => (IntPtr) NativePtr->TexPixelsRgba32;
            set => NativePtr->TexPixelsRgba32 = (uint*) value;
        }
        
        /// <summary>
        ///     Gets the value of the tex width
        /// </summary>
        public ref int TexWidth => ref Unsafe.AsRef<int>(&NativePtr->TexWidth);
        
        /// <summary>
        ///     Gets the value of the tex height
        /// </summary>
        public ref int TexHeight => ref Unsafe.AsRef<int>(&NativePtr->TexHeight);
        
        /// <summary>
        ///     Gets the value of the tex uv scale
        /// </summary>
        public ref Vector2 TexUvScale => ref Unsafe.AsRef<Vector2>(&NativePtr->TexUvScale);
        
        /// <summary>
        ///     Gets the value of the tex uv white pixel
        /// </summary>
        public ref Vector2 TexUvWhitePixel => ref Unsafe.AsRef<Vector2>(&NativePtr->TexUvWhitePixel);
        
        /// <summary>
        ///     Gets the value of the fonts
        /// </summary>
        public ImVectorG<ImFontPtr> Fonts => new ImVectorG<ImFontPtr>(NativePtr->Fonts);
        
        /// <summary>
        ///     Gets the value of the custom rects
        /// </summary>
        public ImVectorG<ImFontAtlasCustomRect> CustomRects => new ImVectorG<ImFontAtlasCustomRect>(NativePtr->CustomRects);
        
        /// <summary>
        ///     Gets the value of the config data
        /// </summary>
        public ImVectorG<ImFontConfigPtr> ConfigData => new ImVectorG<ImFontConfigPtr>(NativePtr->ConfigData);
        
        /// <summary>
        ///     Gets the value of the tex uv lines
        /// </summary>
        public RangeAccessor<Vector4> TexUvLines => new RangeAccessor<Vector4>(&NativePtr->TexUvLines0, 64);
        
        /// <summary>
        ///     Gets or sets the value of the font builder io
        /// </summary>
        public IntPtr FontBuilderIo
        {
            get => (IntPtr) NativePtr->FontBuilderIo;
            set => NativePtr->FontBuilderIo = (IntPtr*) value;
        }
        
        /// <summary>
        ///     Gets the value of the font builder flags
        /// </summary>
        public ref uint FontBuilderFlags => ref Unsafe.AsRef<uint>(&NativePtr->FontBuilderFlags);
        
        /// <summary>
        ///     Gets the value of the pack id mouse cursors
        /// </summary>
        public ref int PackIdMouseCursors => ref Unsafe.AsRef<int>(&NativePtr->PackIdMouseCursors);
        
        /// <summary>
        ///     Gets the value of the pack id lines
        /// </summary>
        public ref int PackIdLines => ref Unsafe.AsRef<int>(&NativePtr->PackIdLines);
        
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
            Vector2 offset = new Vector2();
            int ret = ImGuiNative.ImFontAtlas_AddCustomRectFontGlyph((IntPtr)NativePtr, (IntPtr) font.NativePtr, id, width, height, advanceX, offset);
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
        public int AddCustomRectFontGlyph(ImFontPtr font, ushort id, int width, int height, float advanceX, Vector2 offset)
        {
            int ret = ImGuiNative.ImFontAtlas_AddCustomRectFontGlyph((IntPtr)NativePtr, (IntPtr) font.NativePtr, id, width, height, advanceX, offset);
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
            int ret = ImGuiNative.ImFontAtlas_AddCustomRectRegular((IntPtr)NativePtr, width, height);
            return ret;
        }
        
        /// <summary>
        ///     Adds the font using the specified font cfg
        /// </summary>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFont(ImFontConfigPtr fontCfg)
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFont((IntPtr)NativePtr, fontCfg.NativePtr);
            return new ImFontPtr(ret);
        }
        
        /// <summary>
        ///     Adds the font default
        /// </summary>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontDefault()
        {
            return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontDefault((IntPtr)NativePtr, new IntPtr(null)));
        }
        
        /// <summary>
        ///     Adds the font default using the specified font cfg
        /// </summary>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontDefault(ImFontConfigPtr fontCfg)
        {
            return new ImFontPtr( ImGuiNative.ImFontAtlas_AddFontDefault((IntPtr)NativePtr,  (IntPtr)fontCfg.NativePtr));
        }
        
        /// <summary>
        ///     Adds the font from file ttf using the specified filename
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromFileTtf(string filename, float sizePixels)
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromFileTTF((IntPtr)NativePtr, Encoding.UTF8.GetBytes(filename), sizePixels, new IntPtr(null), new IntPtr(null));
            
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
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromFileTTF((IntPtr)NativePtr, Encoding.UTF8.GetBytes(filename), sizePixels, (IntPtr)fontCfg.NativePtr, new IntPtr(null));
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
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromFileTTF((IntPtr)NativePtr, Encoding.UTF8.GetBytes(filename), sizePixels, (IntPtr)fontCfg.NativePtr, glyphRanges);
            
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
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF((IntPtr)NativePtr, Encoding.UTF8.GetBytes(compressedFontDataBase85), sizePixels, new IntPtr(null), new IntPtr(null));
            
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
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF((IntPtr)NativePtr, Encoding.UTF8.GetBytes(compressedFontDataBase85), sizePixels, (IntPtr)fontCfg.NativePtr, new IntPtr(null));
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
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF((IntPtr)NativePtr, Encoding.UTF8.GetBytes(compressedFontDataBase85), sizePixels, (IntPtr)fontCfg.NativePtr, glyphRanges);
            
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
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF((IntPtr)NativePtr, compressedFontData, compressedFontSize, sizePixels, new IntPtr(null), new IntPtr(null));
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
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF((IntPtr)NativePtr, compressedFontData, compressedFontSize, sizePixels, (IntPtr)fontCfg.NativePtr, new IntPtr(null));
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
            IntPtr nativeGlyphRanges = (IntPtr) glyphRanges;
            IntPtr ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF((IntPtr)NativePtr, nativeCompressedFontData, compressedFontSize, sizePixels, (IntPtr)fontCfg.NativePtr, nativeGlyphRanges);
            return new ImFontPtr(ret);
        }
        
        /// <summary>
        ///     Adds the font from memory ttf using the specified font data
        /// </summary>
        /// <param name="fontData">The font data</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryTtf(IntPtr fontData, int fontSize, float sizePixels)
        {
            return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF((IntPtr)NativePtr, fontData, fontSize, sizePixels, new IntPtr(null), new IntPtr(null)));
        }
        
        /// <summary>
        ///     Adds the font from memory ttf using the specified font data
        /// </summary>
        /// <param name="fontData">The font data</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryTtf(IntPtr fontData, int fontSize, float sizePixels, ImFontConfigPtr fontCfg)
        {
            return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF((IntPtr)NativePtr, fontData, fontSize, sizePixels, (IntPtr)fontCfg.NativePtr, new IntPtr(null)));
        }
        
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
            IntPtr nativeGlyphRanges = (IntPtr) glyphRanges;
            return new ImFontPtr(ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF((IntPtr)NativePtr, nativeFontData, fontSize, sizePixels, (IntPtr)fontCfg.NativePtr, nativeGlyphRanges));
        }
        
        /// <summary>
        ///     Describes whether this instance build
        /// </summary>
        /// <returns>The bool</returns>
        public bool Build()
        {
            byte ret = ImGuiNative.ImFontAtlas_Build((IntPtr)NativePtr);
            return ret != 0;
        }
        
        /// <summary>
        ///     Calcs the custom rect uv using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        /// <param name="outUvMin">The out uv min</param>
        /// <param name="outUvMax">The out uv max</param>
        public void CalcCustomRectUv(ImFontAtlasCustomRect rect, out Vector2 outUvMin, out Vector2 outUvMax)
        {
            ImGuiNative.ImFontAtlas_CalcCustomRectUV((IntPtr)NativePtr, rect, out outUvMin, out outUvMax);
        }
        
        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImFontAtlas_Clear((IntPtr)NativePtr);
        }
        
        /// <summary>
        ///     Clears the fonts
        /// </summary>
        public void ClearFonts()
        {
            ImGuiNative.ImFontAtlas_ClearFonts((IntPtr)NativePtr);
        }
        
        /// <summary>
        ///     Clears the input data
        /// </summary>
        public void ClearInputData()
        {
            ImGuiNative.ImFontAtlas_ClearInputData((IntPtr)NativePtr);
        }
        
        /// <summary>
        ///     Clears the tex data
        /// </summary>
        public void ClearTexData()
        {
            ImGuiNative.ImFontAtlas_ClearTexData((IntPtr)NativePtr);
        }
        
        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImFontAtlas_destroy((IntPtr)NativePtr);
        }
        
        /// <summary>
        ///     Gets the custom rect by index using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The im font atlas custom rect ptr</returns>
        public ImFontAtlasCustomRect GetCustomRectByIndex(int index) => ImGuiNative.ImFontAtlas_GetCustomRectByIndex((IntPtr)NativePtr, index);
        
        /// <summary>
        ///     Gets the glyph ranges chinese full
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesChineseFull()
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_GetGlyphRangesChineseFull((IntPtr)NativePtr);
            return (IntPtr) ret;
        }
        
        /// <summary>
        ///     Gets the glyph ranges chinese simplified common
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesChineseSimplifiedCommon()
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_GetGlyphRangesChineseSimplifiedCommon((IntPtr)NativePtr);
            return (IntPtr) ret;
        }
        
        /// <summary>
        ///     Gets the glyph ranges cyrillic
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesCyrillic()
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_GetGlyphRangesCyrillic((IntPtr)NativePtr);
            return (IntPtr) ret;
        }
        
        /// <summary>
        ///     Gets the glyph ranges default
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesDefault()
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_GetGlyphRangesDefault((IntPtr)NativePtr);
            return (IntPtr) ret;
        }
        
        /// <summary>
        ///     Gets the glyph ranges greek
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesGreek()
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_GetGlyphRangesGreek((IntPtr)NativePtr);
            return (IntPtr) ret;
        }
        
        /// <summary>
        ///     Gets the glyph ranges japanese
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesJapanese()
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_GetGlyphRangesJapanese((IntPtr)NativePtr);
            return (IntPtr) ret;
        }
        
        /// <summary>
        ///     Gets the glyph ranges korean
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesKorean()
        {
            IntPtr ret = ImGuiNative.ImFontAtlas_GetGlyphRangesKorean((IntPtr)NativePtr);
            return (IntPtr) ret;
        }
        
        /// <summary>
        ///     Gets the glyph ranges thai
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesThai()
        {
            return ImGuiNative.ImFontAtlas_GetGlyphRangesThai((IntPtr)NativePtr);
        }
        
        /// <summary>
        ///     Gets the glyph ranges vietnamese
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesVietnamese()
        {
            return ImGuiNative.ImFontAtlas_GetGlyphRangesVietnamese((IntPtr)NativePtr);
        }
        
        /// <summary>
        ///     Describes whether this instance get mouse cursor tex data
        /// </summary>
        /// <param name="cursor">The cursor</param>
        /// <param name="outOffset">The out offset</param>
        /// <param name="outSize">The out size</param>
        /// <param name="outUvBorder">The out uv border</param>
        /// <param name="outUvFill">The out uv fill</param>
        /// <returns>The bool</returns>
        public bool GetMouseCursorTexData(ImGuiMouseCursor cursor, out Vector2 outOffset, out Vector2 outSize, out Vector2 outUvBorder, out Vector2 outUvFill)
        {
            byte ret = ImGuiNative.ImFontAtlas_GetMouseCursorTexData((IntPtr)NativePtr, cursor, out outOffset, out outSize, out outUvBorder, out outUvFill);
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
            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8((IntPtr)NativePtr, out outPixels, out outWidth, out outHeight, out _);
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
            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8((IntPtr)NativePtr, out outPixels, out outWidth, out outHeight, out outBytesPerPixel);
        }
        
        /// <summary>
        ///     Gets the tex data as alpha 8 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        public void GetTexDataAsAlpha8(out IntPtr outPixels, out int outWidth, out int outHeight)
        {
            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8((IntPtr)NativePtr, out outPixels, out outWidth, out outHeight, out _);
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
            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8((IntPtr)NativePtr, out outPixels, out outWidth, out outHeight, out outBytesPerPixel);
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
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32((IntPtr)NativePtr, out outPixels, out outWidth, out outHeight, out outBytesPerPixel);
        }
        
        /// <summary>
        ///     Gets the tex data as rgba 32 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        public void GetTexDataAsRgba32(out IntPtr outPixels, out int outWidth, out int outHeight)
        {
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32((IntPtr)NativePtr, out outPixels, out outWidth, out outHeight, out _);
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
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32((IntPtr)NativePtr, out outPixels, out outWidth, out outHeight, out outBytesPerPixel);
        }
        
        /// <summary>
        ///     Describes whether this instance is built
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsBuilt()
        {
            byte ret = ImGuiNative.ImFontAtlas_IsBuilt((IntPtr)NativePtr);
            return ret != 0;
        }
        
        /// <summary>
        ///     Sets the tex id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public void SetTexId(IntPtr id)
        {
            ImGuiNative.ImFontAtlas_SetTexID((IntPtr)NativePtr, id);
        }
    }
}