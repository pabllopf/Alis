// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlas.cs
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

namespace Alis.Extension.Graphic.ImGui
{
    /// <summary>
    ///     The im font atlas
    /// </summary>
    public struct ImFontAtlas
    {
        /// <summary>
        ///     The flags
        /// </summary>
        public ImFontAtlasFlags Flags;
        
        /// <summary>
        ///     The tex id
        /// </summary>
        public IntPtr TexId;
        
        /// <summary>
        ///     The tex desired width
        /// </summary>
        public int TexDesiredWidth;
        
        /// <summary>
        ///     The tex glyph padding
        /// </summary>
        public int TexGlyphPadding;
        
        /// <summary>
        ///     The locked
        /// </summary>
        public byte Locked;
        
        /// <summary>
        ///     The tex ready
        /// </summary>
        public byte TexReady;
        
        /// <summary>
        ///     The tex pixels use colors
        /// </summary>
        public byte TexPixelsUseColors;
        
        /// <summary>
        ///     The tex pixels alpha
        /// </summary>
        public byte[] TexPixelsAlpha8;
        
        /// <summary>
        ///     The tex pixels rgba 32
        /// </summary>
        public uint[] TexPixelsRgba32;
        
        /// <summary>
        ///     The tex width
        /// </summary>
        public int TexWidth;
        
        /// <summary>
        ///     The tex height
        /// </summary>
        public int TexHeight;
        
        /// <summary>
        ///     The tex uv scale
        /// </summary>
        public Vector2 TexUvScale;
        
        /// <summary>
        ///     The tex uv white pixel
        /// </summary>
        public Vector2 TexUvWhitePixel;
        
        /// <summary>
        ///     The fonts
        /// </summary>
        public ImVectorG<ImFont> Fonts;
        
        /// <summary>
        ///     The custom rects
        /// </summary>
        public ImVectorG<ImFontAtlasCustomRect> CustomRects;
        
        /// <summary>
        ///     The config data
        /// </summary>
        public ImVectorG<ImFontConfig> ConfigData;
        
        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines0;
        
        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines1;
        
        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines2;
        
        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines3;
        
        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines4;
        
        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines5;
        
        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines6;
        
        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines7;
        
        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines8;
        
        /// <summary>
        ///     The texuvlines
        /// </summary>
        public Vector4 TexUvLines9;
        
        /// <summary>
        ///     The texuvlines 10
        /// </summary>
        public Vector4 TexUvLines10;
        
        /// <summary>
        ///     The texuvlines 11
        /// </summary>
        public Vector4 TexUvLines11;
        
        /// <summary>
        ///     The texuvlines 12
        /// </summary>
        public Vector4 TexUvLines12;
        
        /// <summary>
        ///     The texuvlines 13
        /// </summary>
        public Vector4 TexUvLines13;
        
        /// <summary>
        ///     The texuvlines 14
        /// </summary>
        public Vector4 TexUvLines14;
        
        /// <summary>
        ///     The texuvlines 15
        /// </summary>
        public Vector4 TexUvLines15;
        
        /// <summary>
        ///     The texuvlines 16
        /// </summary>
        public Vector4 TexUvLines16;
        
        /// <summary>
        ///     The texuvlines 17
        /// </summary>
        public Vector4 TexUvLines17;
        
        /// <summary>
        ///     The texuvlines 18
        /// </summary>
        public Vector4 TexUvLines18;
        
        /// <summary>
        ///     The texuvlines 19
        /// </summary>
        public Vector4 TexUvLines19;
        
        /// <summary>
        ///     The texuvlines 20
        /// </summary>
        public Vector4 TexUvLines20;
        
        /// <summary>
        ///     The texuvlines 21
        /// </summary>
        public Vector4 TexUvLines21;
        
        /// <summary>
        ///     The texuvlines 22
        /// </summary>
        public Vector4 TexUvLines22;
        
        /// <summary>
        ///     The texuvlines 23
        /// </summary>
        public Vector4 TexUvLines23;
        
        /// <summary>
        ///     The texuvlines 24
        /// </summary>
        public Vector4 TexUvLines24;
        
        /// <summary>
        ///     The texuvlines 25
        /// </summary>
        public Vector4 TexUvLines25;
        
        /// <summary>
        ///     The texuvlines 26
        /// </summary>
        public Vector4 TexUvLines26;
        
        /// <summary>
        ///     The texuvlines 27
        /// </summary>
        public Vector4 TexUvLines27;
        
        /// <summary>
        ///     The texuvlines 28
        /// </summary>
        public Vector4 TexUvLines28;
        
        /// <summary>
        ///     The texuvlines 29
        /// </summary>
        public Vector4 TexUvLines29;
        
        /// <summary>
        ///     The texuvlines 30
        /// </summary>
        public Vector4 TexUvLines30;
        
        /// <summary>
        ///     The texuvlines 31
        /// </summary>
        public Vector4 TexUvLines31;
        
        /// <summary>
        ///     The texuvlines 32
        /// </summary>
        public Vector4 TexUvLines32;
        
        /// <summary>
        ///     The texuvlines 33
        /// </summary>
        public Vector4 TexUvLines33;
        
        /// <summary>
        ///     The texuvlines 34
        /// </summary>
        public Vector4 TexUvLines34;
        
        /// <summary>
        ///     The texuvlines 35
        /// </summary>
        public Vector4 TexUvLines35;
        
        /// <summary>
        ///     The texuvlines 36
        /// </summary>
        public Vector4 TexUvLines36;
        
        /// <summary>
        ///     The texuvlines 37
        /// </summary>
        public Vector4 TexUvLines37;
        
        /// <summary>
        ///     The texuvlines 38
        /// </summary>
        public Vector4 TexUvLines38;
        
        /// <summary>
        ///     The texuvlines 39
        /// </summary>
        public Vector4 TexUvLines39;
        
        /// <summary>
        ///     The texuvlines 40
        /// </summary>
        public Vector4 TexUvLines40;
        
        /// <summary>
        ///     The texuvlines 41
        /// </summary>
        public Vector4 TexUvLines41;
        
        /// <summary>
        ///     The texuvlines 42
        /// </summary>
        public Vector4 TexUvLines42;
        
        /// <summary>
        ///     The texuvlines 43
        /// </summary>
        public Vector4 TexUvLines43;
        
        /// <summary>
        ///     The texuvlines 44
        /// </summary>
        public Vector4 TexUvLines44;
        
        /// <summary>
        ///     The texuvlines 45
        /// </summary>
        public Vector4 TexUvLines45;
        
        /// <summary>
        ///     The texuvlines 46
        /// </summary>
        public Vector4 TexUvLines46;
        
        /// <summary>
        ///     The texuvlines 47
        /// </summary>
        public Vector4 TexUvLines47;
        
        /// <summary>
        ///     The texuvlines 48
        /// </summary>
        public Vector4 TexUvLines48;
        
        /// <summary>
        ///     The texuvlines 49
        /// </summary>
        public Vector4 TexUvLines49;
        
        /// <summary>
        ///     The texuvlines 50
        /// </summary>
        public Vector4 TexUvLines50;
        
        /// <summary>
        ///     The texuvlines 51
        /// </summary>
        public Vector4 TexUvLines51;
        
        /// <summary>
        ///     The texuvlines 52
        /// </summary>
        public Vector4 TexUvLines52;
        
        /// <summary>
        ///     The texuvlines 53
        /// </summary>
        public Vector4 TexUvLines53;
        
        /// <summary>
        ///     The texuvlines 54
        /// </summary>
        public Vector4 TexUvLines54;
        
        /// <summary>
        ///     The texuvlines 55
        /// </summary>
        public Vector4 TexUvLines55;
        
        /// <summary>
        ///     The texuvlines 56
        /// </summary>
        public Vector4 TexUvLines56;
        
        /// <summary>
        ///     The texuvlines 57
        /// </summary>
        public Vector4 TexUvLines57;
        
        /// <summary>
        ///     The texuvlines 58
        /// </summary>
        public Vector4 TexUvLines58;
        
        /// <summary>
        ///     The texuvlines 59
        /// </summary>
        public Vector4 TexUvLines59;
        
        /// <summary>
        ///     The texuvlines 60
        /// </summary>
        public Vector4 TexUvLines60;
        
        /// <summary>
        ///     The texuvlines 61
        /// </summary>
        public Vector4 TexUvLines61;
        
        /// <summary>
        ///     The texuvlines 62
        /// </summary>
        public Vector4 TexUvLines62;
        
        /// <summary>
        ///     The texuvlines 63
        /// </summary>
        public Vector4 TexUvLines63;
        
        /// <summary>
        ///     The font builder io
        /// </summary>
        public IntPtr FontBuilderIo;
        
        /// <summary>
        ///     The font builder flags
        /// </summary>
        public uint FontBuilderFlags;
        
        /// <summary>
        ///     The pack id mouse cursors
        /// </summary>
        public int PackIdMouseCursors;
        
        /// <summary>
        ///     The pack id lines
        /// </summary>
        public int PackIdLines;
        
        /// <summary>
        ///     Adds the custom rect font glyph using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="id">The id</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="advanceX">The advance</param>
        /// <returns>The ret</returns>
        public int AddCustomRectFontGlyph(ImFont font, ushort id, int width, int height, float advanceX)
        {
            Vector2 offset = new Vector2();
            int ret = ImGuiNative.ImFontAtlas_AddCustomRectFontGlyph(ref this, ref font, id, width, height, advanceX, offset);
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
        public int AddCustomRectFontGlyph(ImFont font, ushort id, int width, int height, float advanceX, Vector2 offset)
        {
            int ret = ImGuiNative.ImFontAtlas_AddCustomRectFontGlyph(ref this, ref font, id, width, height, advanceX, offset);
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
            int ret = ImGuiNative.ImFontAtlas_AddCustomRectRegular(ref this, width, height);
            return ret;
        }
        
        /// <summary>
        ///     Adds the font using the specified font cfg
        /// </summary>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFont AddFont(ImFontConfig fontCfg)
        {
            return ImGuiNative.ImFontAtlas_AddFont(ref this, fontCfg);
        }
        
        /// <summary>
        ///     Adds the font default
        /// </summary>
        /// <returns>The im font ptr</returns>
        public ImFont AddFontDefault()
        {
            return ImGuiNative.ImFontAtlas_AddFontDefault(ref this, new ImFontConfig());
        }
        
        /// <summary>
        ///     Adds the font default using the specified font cfg
        /// </summary>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFont AddFontDefault(ImFontConfig fontCfg)
        {
            return ImGuiNative.ImFontAtlas_AddFontDefault(ref this, fontCfg);
        }
        
        /// <summary>
        ///     Adds the font from file ttf using the specified filename
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFont AddFontFromFileTtf(string filename, float sizePixels)
        {
            return ImGuiNative.ImFontAtlas_AddFontFromFileTTF(ref this, Encoding.UTF8.GetBytes(filename), sizePixels, new ImFontConfig(), 0);
        }
        
        /// <summary>
        ///     Adds the font from file ttf using the specified filename
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFont AddFontFromFileTtf(string filename, float sizePixels, ImFontConfig fontCfg)
        {
            return  ImGuiNative.ImFontAtlas_AddFontFromFileTTF(ref this, Encoding.UTF8.GetBytes(filename), sizePixels, fontCfg, 0);
        }
        
        /// <summary>
        ///     Adds the font from file ttf using the specified filename
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <param name="glyphRanges">The glyph ranges</param>
        /// <returns>The im font ptr</returns>
        public ImFont AddFontFromFileTtf(string filename, float sizePixels, ImFontConfig fontCfg, IntPtr glyphRanges)
        {
            return ImGuiNative.ImFontAtlas_AddFontFromFileTTF(ref this, Encoding.UTF8.GetBytes(filename), sizePixels, fontCfg, (ushort) glyphRanges);
        }
        
        /// <summary>
        ///     Adds the font from memory compressed base 85 ttf using the specified compressed font data base85
        /// </summary>
        /// <param name="compressedFontDataBase85">The compressed font data base85</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFont AddFontFromMemoryCompressedBase85Ttf(string compressedFontDataBase85, float sizePixels)
        {
            return  ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(ref this, Encoding.UTF8.GetBytes(compressedFontDataBase85), sizePixels, new ImFontConfig(), 0);
        }
        
        /// <summary>
        ///     Adds the font from memory compressed base 85 ttf using the specified compressed font data base85
        /// </summary>
        /// <param name="compressedFontDataBase85">The compressed font data base85</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFont AddFontFromMemoryCompressedBase85Ttf(string compressedFontDataBase85, float sizePixels, ImFontConfig fontCfg)
        {
            return ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(ref this, Encoding.UTF8.GetBytes(compressedFontDataBase85), sizePixels, fontCfg, 0);
        }
        
        /// <summary>
        ///     Adds the font from memory compressed base 85 ttf using the specified compressed font data base85
        /// </summary>
        /// <param name="compressedFontDataBase85">The compressed font data base85</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <param name="glyphRanges">The glyph ranges</param>
        /// <returns>The im font ptr</returns>
        public ImFont AddFontFromMemoryCompressedBase85Ttf(string compressedFontDataBase85, float sizePixels, ImFontConfig fontCfg, IntPtr glyphRanges)
        {
            return ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(ref this, Encoding.UTF8.GetBytes(compressedFontDataBase85), sizePixels, fontCfg, (ushort) glyphRanges);
        }
        
        /// <summary>
        ///     Adds the font from memory compressed ttf using the specified compressed font data
        /// </summary>
        /// <param name="compressedFontData">The compressed font data</param>
        /// <param name="compressedFontSize">The compressed font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFont AddFontFromMemoryCompressedTtf(IntPtr compressedFontData, int compressedFontSize, float sizePixels)
        {
            return ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF(ref this, compressedFontData, compressedFontSize, sizePixels, new ImFontConfig(), 0);
        }
        
        /// <summary>
        ///     Adds the font from memory compressed ttf using the specified compressed font data
        /// </summary>
        /// <param name="compressedFontData">The compressed font data</param>
        /// <param name="compressedFontSize">The compressed font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFont AddFontFromMemoryCompressedTtf(IntPtr compressedFontData, int compressedFontSize, float sizePixels, ImFontConfig fontCfg)
        {
           return ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF(ref this, compressedFontData, compressedFontSize, sizePixels, fontCfg, 0);
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
        public ImFont AddFontFromMemoryCompressedTtf(IntPtr compressedFontData, int compressedFontSize, float sizePixels, ImFontConfig fontCfg, IntPtr glyphRanges)
        {
            return ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF(ref this, compressedFontData, compressedFontSize, sizePixels, fontCfg, (ushort) glyphRanges);
        }
        
        /// <summary>
        ///     Adds the font from memory ttf using the specified font data
        /// </summary>
        /// <param name="fontData">The font data</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFont AddFontFromMemoryTtf(IntPtr fontData, int fontSize, float sizePixels)
        {
           return ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF(ref this, fontData, fontSize, sizePixels, new ImFontConfig(), 0);
        }
        
        /// <summary>
        ///     Adds the font from memory ttf using the specified font data
        /// </summary>
        /// <param name="fontData">The font data</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFont AddFontFromMemoryTtf(IntPtr fontData, int fontSize, float sizePixels, ImFontConfig fontCfg)
        {
           return ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF(ref this, fontData, fontSize, sizePixels, fontCfg, 0);
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
        public ImFont AddFontFromMemoryTtf(IntPtr fontData, int fontSize, float sizePixels, ImFontConfig fontCfg, IntPtr glyphRanges)
        {
           return ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF(ref this, fontData, fontSize, sizePixels, fontCfg, (ushort) glyphRanges);
        }
        
        /// <summary>
        ///     Describes whether this instance build
        /// </summary>
        /// <returns>The bool</returns>
        public bool Build()
        {
            byte ret = ImGuiNative.ImFontAtlas_Build(ref this);
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
             ImGuiNative.ImFontAtlas_CalcCustomRectUV(ref this, rect, out outUvMin, out outUvMax);
        }
        
        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImFontAtlas_Clear(ref this);
        }
        
        /// <summary>
        ///     Clears the fonts
        /// </summary>
        public void ClearFonts()
        {
            ImGuiNative.ImFontAtlas_ClearFonts(ref this);
        }
        
        /// <summary>
        ///     Clears the input data
        /// </summary>
        public void ClearInputData()
        {
            ImGuiNative.ImFontAtlas_ClearInputData(ref this);
        }
        
        /// <summary>
        ///     Clears the tex data
        /// </summary>
        public void ClearTexData()
        {
            ImGuiNative.ImFontAtlas_ClearTexData(ref this);
        }
        
        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImFontAtlas_destroy(ref this);
        }
        
        /// <summary>
        ///     Gets the custom rect by index using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The im font atlas custom rect ptr</returns>
        public ImFontAtlasCustomRect GetCustomRectByIndex(int index) => ImGuiNative.ImFontAtlas_GetCustomRectByIndex(ref this, index);
        
        /// <summary>
        ///     Gets the glyph ranges chinese full
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesChineseFull()
        {
            return (IntPtr) ImGuiNative.ImFontAtlas_GetGlyphRangesChineseFull(ref this);
        }
        
        /// <summary>
        ///     Gets the glyph ranges chinese simplified common
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesChineseSimplifiedCommon()
        {
            return (IntPtr) ImGuiNative.ImFontAtlas_GetGlyphRangesChineseSimplifiedCommon(ref this);
        }
        
        /// <summary>
        ///     Gets the glyph ranges cyrillic
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesCyrillic()
        {
            return (IntPtr) ImGuiNative.ImFontAtlas_GetGlyphRangesCyrillic(ref this);
        }
        
        /// <summary>
        ///     Gets the glyph ranges default
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesDefault()
        {
            return (IntPtr)ImGuiNative.ImFontAtlas_GetGlyphRangesDefault(ref this);
        }
        
        /// <summary>
        ///     Gets the glyph ranges greek
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesGreek()
        {
            return (IntPtr)  ImGuiNative.ImFontAtlas_GetGlyphRangesGreek(ref this);
        }
        
        /// <summary>
        ///     Gets the glyph ranges japanese
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesJapanese()
        {
            return (IntPtr) ImGuiNative.ImFontAtlas_GetGlyphRangesJapanese(ref this);
        }
        
        /// <summary>
        ///     Gets the glyph ranges korean
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesKorean()
        {
            return (IntPtr) ImGuiNative.ImFontAtlas_GetGlyphRangesKorean(ref this);
        }
        
        /// <summary>
        ///     Gets the glyph ranges thai
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesThai()
        {
            return (IntPtr) ImGuiNative.ImFontAtlas_GetGlyphRangesThai(ref this);
        }
        
        /// <summary>
        ///     Gets the glyph ranges vietnamese
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesVietnamese()
        {
            return (IntPtr) ImGuiNative.ImFontAtlas_GetGlyphRangesVietnamese(ref this);
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
            byte ret = ImGuiNative.ImFontAtlas_GetMouseCursorTexData(ref this, cursor, out outOffset, out outSize, out outUvBorder, out outUvFill);
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
            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(ref this, out outPixels, out outWidth, out outHeight, out _);
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
            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(ref this, out outPixels, out outWidth, out outHeight, out outBytesPerPixel);
        }
        
        /// <summary>
        ///     Gets the tex data as alpha 8 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        public void GetTexDataAsAlpha8(out IntPtr outPixels, out int outWidth, out int outHeight)
        {
            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(ref this, out outPixels, out outWidth, out outHeight, out _);
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
            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(ref this, out outPixels, out outWidth, out outHeight, out outBytesPerPixel);
        }
        
        /// <summary>
        ///     Gets the tex data as rgba 32 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        public void GetTexDataAsRgba32(out byte[] outPixels, out int outWidth, out int outHeight)
        {
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(ref this, out outPixels, out outWidth, out outHeight, out _);
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
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(ref this, out outPixels, out outWidth, out outHeight, out outBytesPerPixel);
        }
        
        /// <summary>
        ///     Gets the tex data as rgba 32 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        public void GetTexDataAsRgba32(out IntPtr outPixels, out int outWidth, out int outHeight)
        {
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(ref this, out outPixels, out outWidth, out outHeight, out _);
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
            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(ref this, out outPixels, out outWidth, out outHeight, out outBytesPerPixel);
        }
        
        /// <summary>
        ///     Describes whether this instance is built
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsBuilt()
        {
            byte ret = ImGuiNative.ImFontAtlas_IsBuilt(ref this);
            return ret != 0;
        }
        
        /// <summary>
        ///     Sets the tex id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public void SetTexId(IntPtr id)
        {
            ImGuiNative.ImFontAtlas_SetTexID(ref this, id);
        }
    }
}