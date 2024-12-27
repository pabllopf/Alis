// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlasPtrTest.cs
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
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im font atlas ptr test class
    /// </summary>
    	 [ExcludeFromCodeCoverage] 
	 public class ImFontAtlasPtrTest 
    {
        /// <summary>
        ///     Tests that native ptr should be initialized
        /// </summary>
        [Fact]
        public void NativePtr_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);
            Assert.NotEqual(IntPtr.Zero, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that flags should be initialized
        /// </summary>
        [Fact]
        public void Flags_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);
            Assert.Equal(atlas.Flags, ptr.Flags);
        }

        /// <summary>
        ///     Tests that tex id should be initialized
        /// </summary>
        [Fact]
        public void TexId_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);
            Assert.Equal(atlas.TexId, ptr.TexId);
        }

        /// <summary>
        ///     Tests that tex desired width should be initialized
        /// </summary>
        [Fact]
        public void TexDesiredWidth_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);
            Assert.Equal(atlas.TexDesiredWidth, ptr.TexDesiredWidth);
        }

        /// <summary>
        ///     Tests that tex glyph padding should be initialized
        /// </summary>
        [Fact]
        public void TexGlyphPadding_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);
            Assert.Equal(atlas.TexGlyphPadding, ptr.TexGlyphPadding);
        }

        /// <summary>
        ///     Tests that locked should be initialized
        /// </summary>
        [Fact]
        public void Locked_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.Locked != 0, ptr.Locked);
        }

        /// <summary>
        ///     Tests that tex ready should be initialized
        /// </summary>
        [Fact]
        public void TexReady_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.TexReady != 0, ptr.TexReady);
        }

        /// <summary>
        ///     Tests that tex pixels use colors should be initialized
        /// </summary>
        [Fact]
        public void TexPixelsUseColors_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.TexPixelsUseColors != 0, ptr.TexPixelsUseColors);
        }

        /// <summary>
        ///     Tests that tex pixels alpha 8 should be initialized
        /// </summary>
        [Fact]
        public void TexPixelsAlpha8_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.TexPixelsAlpha8, ptr.TexPixelsAlpha8);
        }

        /// <summary>
        ///     Tests that tex pixels rgba 32 should be initialized
        /// </summary>
        [Fact]
        public void TexPixelsRgba32_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.TexPixelsRgba32, ptr.TexPixelsRgba32);
        }

        /// <summary>
        ///     Tests that tex width should be initialized
        /// </summary>
        [Fact]
        public void TexWidth_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.TexWidth, ptr.TexWidth);
        }

        /// <summary>
        ///     Tests that tex height should be initialized
        /// </summary>
        [Fact]
        public void TexHeight_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.TexHeight, ptr.TexHeight);
        }

        /// <summary>
        ///     Tests that tex uv scale should be initialized
        /// </summary>
        [Fact]
        public void TexUvScale_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.TexUvScale, ptr.TexUvScale);
        }

        /// <summary>
        ///     Tests that tex uv white pixel should be initialized
        /// </summary>
        [Fact]
        public void TexUvWhitePixel_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.TexUvWhitePixel, ptr.TexUvWhitePixel);
        }

        /// <summary>
        ///     Tests that fonts should be initialized
        /// </summary>
        [Fact]
        public void Fonts_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.Fonts.Data, ptr.Fonts.Data);
        }

        /// <summary>
        ///     Tests that custom rects should be initialized
        /// </summary>
        [Fact]
        public void CustomRects_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.CustomRects.Data, ptr.CustomRects.Data);
        }

        /// <summary>
        ///     Tests that config data should be initialized
        /// </summary>
        [Fact]
        public void ConfigData_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.ConfigData.Data, ptr.ConfigData.Data);
        }

        /// <summary>
        ///     Tests that font builder io should be initialized
        /// </summary>
        [Fact]
        public void FontBuilderIo_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.FontBuilderIo, ptr.FontBuilderIo);
        }

        /// <summary>
        ///     Tests that font builder flags should be initialized
        /// </summary>
        [Fact]
        public void FontBuilderFlags_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.FontBuilderFlags, ptr.FontBuilderFlags);
        }

        /// <summary>
        ///     Tests that pack id mouse cursors should be initialized
        /// </summary>
        [Fact]
        public void PackIdMouseCursors_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.PackIdMouseCursors, ptr.PackIdMouseCursors);
        }

        /// <summary>
        ///     Tests that pack id lines should be initialized
        /// </summary>
        [Fact]
        public void PackIdLines_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.PackIdLines, ptr.PackIdLines);
        }

        /// <summary>
        ///     Tests that flags should set and get correctly
        /// </summary>
        [Fact]
        public void Flags_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            atlas.Flags = ImFontAtlasFlags.NoPowerOfTwoHeight;
            Assert.Equal(ImFontAtlasFlags.NoPowerOfTwoHeight, atlas.Flags);
        }

        /// <summary>
        ///     Tests that tex id should set and get correctly
        /// </summary>
        [Fact]
        public void TexId_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            IntPtr texId = new IntPtr(123);
            atlas.TexId = texId;
            Assert.Equal(texId, atlas.TexId);
        }

        /// <summary>
        ///     Tests that tex desired width should set and get correctly
        /// </summary>
        [Fact]
        public void TexDesiredWidth_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            atlas.TexDesiredWidth = 512;
            Assert.Equal(512, atlas.TexDesiredWidth);
        }

        /// <summary>
        ///     Tests that tex glyph padding should set and get correctly
        /// </summary>
        [Fact]
        public void TexGlyphPadding_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            atlas.TexGlyphPadding = 1;
            Assert.Equal(1, atlas.TexGlyphPadding);
        }

        /// <summary>
        ///     Tests that locked should set and get correctly
        /// </summary>
        [Fact]
        public void Locked_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            atlas.Locked = 1;
            Assert.Equal((byte) 1, atlas.Locked);
        }

        /// <summary>
        ///     Tests that tex ready should set and get correctly
        /// </summary>
        [Fact]
        public void TexReady_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            atlas.TexReady = 1;
            Assert.Equal((byte) 1, atlas.TexReady);
        }

        /// <summary>
        ///     Tests that tex pixels use colors should set and get correctly
        /// </summary>
        [Fact]
        public void TexPixelsUseColors_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            atlas.TexPixelsUseColors = 1;
            Assert.Equal((byte) 1, atlas.TexPixelsUseColors);
        }

        /// <summary>
        ///     Tests that tex pixels alpha 8 should set and get correctly
        /// </summary>
        [Fact]
        public void TexPixelsAlpha8_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            IntPtr ptr = new IntPtr(123);
            atlas.TexPixelsAlpha8 = ptr;
            Assert.Equal(ptr, atlas.TexPixelsAlpha8);
        }

        /// <summary>
        ///     Tests that tex pixels rgba 32 should set and get correctly
        /// </summary>
        [Fact]
        public void TexPixelsRgba32_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            IntPtr ptr = new IntPtr(123);
            atlas.TexPixelsRgba32 = ptr;
            Assert.Equal(ptr, atlas.TexPixelsRgba32);
        }

        /// <summary>
        ///     Tests that tex width should set and get correctly
        /// </summary>
        [Fact]
        public void TexWidth_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            atlas.TexWidth = 1024;
            Assert.Equal(1024, atlas.TexWidth);
        }

        /// <summary>
        ///     Tests that tex height should set and get correctly
        /// </summary>
        [Fact]
        public void TexHeight_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            atlas.TexHeight = 1024;
            Assert.Equal(1024, atlas.TexHeight);
        }

        /// <summary>
        ///     Tests that tex uv scale should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvScale_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector2F scale = new Vector2F(1.0f, 1.0f);
            atlas.TexUvScale = scale;
            Assert.Equal(scale, atlas.TexUvScale);
        }

        /// <summary>
        ///     Tests that tex uv white pixel should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvWhitePixel_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector2F whitePixel = new Vector2F(0.5f, 0.5f);
            atlas.TexUvWhitePixel = whitePixel;
            Assert.Equal(whitePixel, atlas.TexUvWhitePixel);
        }

        /// <summary>
        ///     Tests that fonts should set and get correctly
        /// </summary>
        [Fact]
        public void Fonts_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImVector fonts = new ImVector();
            atlas.Fonts = fonts;
            Assert.Equal(fonts, atlas.Fonts);
        }

        /// <summary>
        ///     Tests that custom rects should set and get correctly
        /// </summary>
        [Fact]
        public void CustomRects_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImVector rects = new ImVector();
            atlas.CustomRects = rects;
            Assert.Equal(rects, atlas.CustomRects);
        }

        /// <summary>
        ///     Tests that config data should set and get correctly
        /// </summary>
        [Fact]
        public void ConfigData_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImVector configData = new ImVector();
            atlas.ConfigData = configData;
            Assert.Equal(configData, atlas.ConfigData);
        }

        /// <summary>
        ///     Tests that tex uv lines should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines0 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines0);
        }

        /// <summary>
        ///     Tests that font builder io should set and get correctly
        /// </summary>
        [Fact]
        public void FontBuilderIo_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            IntPtr ptr = new IntPtr(123);
            atlas.FontBuilderIo = ptr;
            Assert.Equal(ptr, atlas.FontBuilderIo);
        }

        /// <summary>
        ///     Tests that font builder flags should set and get correctly
        /// </summary>
        [Fact]
        public void FontBuilderFlags_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            atlas.FontBuilderFlags = 1;
            Assert.Equal((uint) 1, atlas.FontBuilderFlags);
        }

        /// <summary>
        ///     Tests that pack id mouse cursors should set and get correctly
        /// </summary>
        [Fact]
        public void PackIdMouseCursors_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            atlas.PackIdMouseCursors = 1;
            Assert.Equal(1, atlas.PackIdMouseCursors);
        }

        /// <summary>
        ///     Tests that pack id lines should set and get correctly
        /// </summary>
        [Fact]
        public void PackIdLines_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            atlas.PackIdLines = 1;
            Assert.Equal(1, atlas.PackIdLines);
        }

        /// <summary>
        ///     Tests that tex uv lines 30 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines30_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines30 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines30);
        }

        /// <summary>
        ///     Tests that tex uv lines 31 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines31_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines31 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines31);
        }

        /// <summary>
        ///     Tests that tex uv lines 32 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines32_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines32 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines32);
        }

        /// <summary>
        ///     Tests that tex uv lines 33 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines33_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines33 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines33);
        }

        /// <summary>
        ///     Tests that tex uv lines 34 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines34_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines34 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines34);
        }

        /// <summary>
        ///     Tests that tex uv lines 35 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines35_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines35 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines35);
        }

        /// <summary>
        ///     Tests that tex uv lines 36 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines36_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines36 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines36);
        }

        /// <summary>
        ///     Tests that tex uv lines 37 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines37_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines37 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines37);
        }

        /// <summary>
        ///     Tests that tex uv lines 38 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines38_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines38 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines38);
        }

        /// <summary>
        ///     Tests that tex uv lines 39 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines39_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines39 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines39);
        }

        /// <summary>
        ///     Tests that tex uv lines 40 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines40_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines40 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines40);
        }

        /// <summary>
        ///     Tests that tex uv lines 41 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines41_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines41 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines41);
        }

        /// <summary>
        ///     Tests that tex uv lines 42 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines42_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines42 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines42);
        }

        /// <summary>
        ///     Tests that tex uv lines 43 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines43_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines43 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines43);
        }

        /// <summary>
        ///     Tests that tex uv lines 44 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines44_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines44 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines44);
        }

        /// <summary>
        ///     Tests that tex uv lines 45 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines45_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines45 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines45);
        }

        /// <summary>
        ///     Tests that tex uv lines 46 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines46_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines46 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines46);
        }

        /// <summary>
        ///     Tests that tex uv lines 47 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines47_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines47 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines47);
        }

        /// <summary>
        ///     Tests that tex uv lines 48 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines48_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines48 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines48);
        }

        /// <summary>
        ///     Tests that tex uv lines 49 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines49_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines49 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines49);
        }

        /// <summary>
        ///     Tests that tex uv lines 50 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines50_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines50 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines50);
        }

        /// <summary>
        ///     Tests that tex uv lines 51 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines51_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines51 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines51);
        }

        /// <summary>
        ///     Tests that tex uv lines 52 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines52_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines52 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines52);
        }

        /// <summary>
        ///     Tests that tex uv lines 53 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines53_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines53 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines53);
        }

        /// <summary>
        ///     Tests that tex uv lines 54 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines54_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines54 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines54);
        }

        /// <summary>
        ///     Tests that tex uv lines 55 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines55_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines55 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines55);
        }

        /// <summary>
        ///     Tests that tex uv lines 56 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines56_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines56 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines56);
        }

        /// <summary>
        ///     Tests that tex uv lines 57 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines57_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines57 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines57);
        }

        /// <summary>
        ///     Tests that tex uv lines 58 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines58_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines58 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines58);
        }

        /// <summary>
        ///     Tests that tex uv lines 59 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines59_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines59 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines59);
        }

        /// <summary>
        ///     Tests that tex uv lines 60 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines60_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines60 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines60);
        }

        /// <summary>
        ///     Tests that tex uv lines 61 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines61_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines61 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines61);
        }

        /// <summary>
        ///     Tests that tex uv lines 62 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines62_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines62 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines62);
        }

        /// <summary>
        ///     Tests that tex uv lines 63 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines63_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines63 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines63);
        }

        /// <summary>
        ///     Tests that tex uv lines 1 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines1_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines1 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines1);
        }

        /// <summary>
        ///     Tests that tex uv lines 2 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines2_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines2 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines2);
        }

        /// <summary>
        ///     Tests that tex uv lines 3 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines3_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines3 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines3);
        }

        /// <summary>
        ///     Tests that tex uv lines 4 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines4_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines4 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines4);
        }

        /// <summary>
        ///     Tests that tex uv lines 5 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines5_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines5 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines5);
        }

        /// <summary>
        ///     Tests that tex uv lines 6 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines6_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines6 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines6);
        }

        /// <summary>
        ///     Tests that tex uv lines 7 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines7_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines7 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines7);
        }

        /// <summary>
        ///     Tests that tex uv lines 8 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines8_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines8 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines8);
        }

        /// <summary>
        ///     Tests that tex uv lines 9 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines9_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines9 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines9);
        }

        /// <summary>
        ///     Tests that tex uv lines 10 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines10_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines10 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines10);
        }

        /// <summary>
        ///     Tests that tex uv lines 11 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines11_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines11 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines11);
        }

        /// <summary>
        ///     Tests that tex uv lines 12 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines12_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines12 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines12);
        }

        /// <summary>
        ///     Tests that tex uv lines 13 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines13_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines13 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines13);
        }

        /// <summary>
        ///     Tests that tex uv lines 14 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines14_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines14 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines14);
        }

        /// <summary>
        ///     Tests that tex uv lines 15 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines15_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines15 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines15);
        }

        /// <summary>
        ///     Tests that tex uv lines 16 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines16_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines16 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines16);
        }

        /// <summary>
        ///     Tests that tex uv lines 17 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines17_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines17 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines17);
        }

        /// <summary>
        ///     Tests that tex uv lines 18 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines18_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines18 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines18);
        }

        /// <summary>
        ///     Tests that tex uv lines 19 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines19_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines19 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines19);
        }

        /// <summary>
        ///     Tests that tex uv lines 20 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines20_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines20 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines20);
        }

        /// <summary>
        ///     Tests that tex uv lines 21 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines21_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines21 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines21);
        }

        /// <summary>
        ///     Tests that tex uv lines 22 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines22_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines22 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines22);
        }

        /// <summary>
        ///     Tests that tex uv lines 23 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines23_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines23 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines23);
        }

        /// <summary>
        ///     Tests that tex uv lines 24 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines24_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines24 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines24);
        }

        /// <summary>
        ///     Tests that tex uv lines 25 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines25_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines25 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines25);
        }

        /// <summary>
        ///     Tests that tex uv lines 26 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines26_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines26 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines26);
        }

        /// <summary>
        ///     Tests that tex uv lines 27 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines27_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines27 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines27);
        }

        /// <summary>
        ///     Tests that tex uv lines 28 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines28_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines28 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines28);
        }

        /// <summary>
        ///     Tests that tex uv lines 29 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines29_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F uvLine = new Vector4F(1, 2, 3, 4);
            atlas.TexUvLines29 = uvLine;
            Assert.Equal(uvLine, atlas.TexUvLines29);
        }

        /// <summary>
        ///     Tests that add font default returns im font ptr
        /// </summary>
        [Fact]
        public void AddFontDefault_ReturnsImFontPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.AddFontDefault());
        }

        /// <summary>
        ///     Tests that add font default with font cfg returns im font ptr
        /// </summary>
        [Fact]
        public void AddFontDefault_WithFontCfg_ReturnsImFontPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontConfigPtr fontCfg = new ImFontConfigPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.AddFontDefault(fontCfg));
        }

        /// <summary>
        ///     Tests that add font from file ttf returns im font ptr
        /// </summary>
        [Fact]
        public void AddFontFromFileTtf_ReturnsImFontPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.AddFontFromFileTtf("test.ttf", 16.0f));
        }

        /// <summary>
        ///     Tests that add font from file ttf with font cfg returns im font ptr
        /// </summary>
        [Fact]
        public void AddFontFromFileTtf_WithFontCfg_ReturnsImFontPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontConfigPtr fontCfg = new ImFontConfigPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.AddFontFromFileTtf("test.ttf", 16.0f, fontCfg));
        }

        /// <summary>
        ///     Tests that add font from file ttf with font cfg and glyph ranges returns im font ptr
        /// </summary>
        [Fact]
        public void AddFontFromFileTtf_WithFontCfgAndGlyphRanges_ReturnsImFontPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontConfigPtr fontCfg = new ImFontConfigPtr();
            IntPtr glyphRanges = new IntPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.AddFontFromFileTtf("test.ttf", 16.0f, fontCfg, glyphRanges));
        }

        /// <summary>
        ///     Tests that add font from memory compressed base 85 ttf returns im font ptr
        /// </summary>
        [Fact]
        public void AddFontFromMemoryCompressedBase85Ttf_ReturnsImFontPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.AddFontFromMemoryCompressedBase85Ttf("compressedData", 16.0f));
        }

        /// <summary>
        ///     Tests that add font from memory compressed base 85 ttf with font cfg returns im font ptr
        /// </summary>
        [Fact]
        public void AddFontFromMemoryCompressedBase85Ttf_WithFontCfg_ReturnsImFontPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontConfigPtr fontCfg = new ImFontConfigPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.AddFontFromMemoryCompressedBase85Ttf("compressedData", 16.0f, fontCfg));
        }

        /// <summary>
        ///     Tests that add font from memory compressed base 85 ttf with font cfg and glyph ranges returns im font ptr
        /// </summary>
        [Fact]
        public void AddFontFromMemoryCompressedBase85Ttf_WithFontCfgAndGlyphRanges_ReturnsImFontPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontConfigPtr fontCfg = new ImFontConfigPtr();
            IntPtr glyphRanges = new IntPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.AddFontFromMemoryCompressedBase85Ttf("compressedData", 16.0f, fontCfg, glyphRanges));
        }

        /// <summary>
        ///     Tests that add font from memory compressed ttf returns im font ptr
        /// </summary>
        [Fact]
        public void AddFontFromMemoryCompressedTtf_ReturnsImFontPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            IntPtr compressedFontData = new IntPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.AddFontFromMemoryCompressedTtf(compressedFontData, 100, 16.0f));
        }

        /// <summary>
        ///     Tests that add font from memory compressed ttf with font cfg returns im font ptr
        /// </summary>
        [Fact]
        public void AddFontFromMemoryCompressedTtf_WithFontCfg_ReturnsImFontPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            IntPtr compressedFontData = new IntPtr();
            ImFontConfigPtr fontCfg = new ImFontConfigPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.AddFontFromMemoryCompressedTtf(compressedFontData, 100, 16.0f, fontCfg));
        }

        /// <summary>
        ///     Tests that add font from memory compressed ttf with font cfg and glyph ranges returns im font ptr
        /// </summary>
        [Fact]
        public void AddFontFromMemoryCompressedTtf_WithFontCfgAndGlyphRanges_ReturnsImFontPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            IntPtr compressedFontData = new IntPtr();
            ImFontConfigPtr fontCfg = new ImFontConfigPtr();
            IntPtr glyphRanges = new IntPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.AddFontFromMemoryCompressedTtf(compressedFontData, 100, 16.0f, fontCfg, glyphRanges));
        }

        /// <summary>
        ///     Tests that add font from memory ttf returns im font ptr
        /// </summary>
        [Fact]
        public void AddFontFromMemoryTtf_ReturnsImFontPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            IntPtr fontData = new IntPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.AddFontFromMemoryTtf(fontData, 100, 16.0f));
        }

        /// <summary>
        ///     Tests that add font from memory ttf with font cfg returns im font ptr
        /// </summary>
        [Fact]
        public void AddFontFromMemoryTtf_WithFontCfg_ReturnsImFontPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            IntPtr fontData = new IntPtr();
            ImFontConfigPtr fontCfg = new ImFontConfigPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.AddFontFromMemoryTtf(fontData, 100, 16.0f, fontCfg));
        }

        /// <summary>
        ///     Tests that add font from memory ttf with font cfg and glyph ranges returns im font ptr
        /// </summary>
        [Fact]
        public void AddFontFromMemoryTtf_WithFontCfgAndGlyphRanges_ReturnsImFontPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            IntPtr fontData = new IntPtr();
            ImFontConfigPtr fontCfg = new ImFontConfigPtr();
            IntPtr glyphRanges = new IntPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.AddFontFromMemoryTtf(fontData, 100, 16.0f, fontCfg, glyphRanges));
        }

        /// <summary>
        ///     Tests that build returns true
        /// </summary>
        [Fact]
        public void Build_ReturnsTrue()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.Build());
        }

        /// <summary>
        ///     Tests that calc custom rect uv sets out parameters
        /// </summary>
        [Fact]
        public void CalcCustomRectUv_SetsOutParameters()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            ImFontAtlasCustomRect rect = new ImFontAtlasCustomRect();
            Assert.Throws<DllNotFoundException>(() => atlas.CalcCustomRectUv(rect, out Vector2F _, out Vector2F _));
        }

        /// <summary>
        ///     Tests that clear clears instance
        /// </summary>
        [Fact]
        public void Clear_ClearsInstance()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.Clear());
            // Assuming some way to verify the instance is cleared
        }

        /// <summary>
        ///     Tests that clear fonts clears fonts
        /// </summary>
        [Fact]
        public void ClearFonts_ClearsFonts()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.ClearFonts());
            // Assuming some way to verify the fonts are cleared
        }

        /// <summary>
        ///     Tests that clear input data clears input data
        /// </summary>
        [Fact]
        public void ClearInputData_ClearsInputData()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.ClearInputData());
            // Assuming some way to verify the input data is cleared
        }

        /// <summary>
        ///     Tests that clear tex data clears tex data
        /// </summary>
        [Fact]
        public void ClearTexData_ClearsTexData()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.ClearTexData());
            // Assuming some way to verify the tex data is cleared
        }

        /// <summary>
        ///     Tests that get custom rect by index returns custom rect
        /// </summary>
        [Fact]
        public void GetCustomRectByIndex_ReturnsCustomRect()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetCustomRectByIndex(0));
        }

        /// <summary>
        ///     Tests that get glyph ranges chinese full returns int ptr
        /// </summary>
        [Fact]
        public void GetGlyphRangesChineseFull_ReturnsIntPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetGlyphRangesChineseFull());
        }

        /// <summary>
        ///     Tests that get glyph ranges chinese simplified common returns int ptr
        /// </summary>
        [Fact]
        public void GetGlyphRangesChineseSimplifiedCommon_ReturnsIntPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetGlyphRangesChineseSimplifiedCommon());
        }

        /// <summary>
        ///     Tests that get glyph ranges cyrillic returns int ptr
        /// </summary>
        [Fact]
        public void GetGlyphRangesCyrillic_ReturnsIntPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetGlyphRangesCyrillic());
        }

        /// <summary>
        ///     Tests that get glyph ranges default returns int ptr
        /// </summary>
        [Fact]
        public void GetGlyphRangesDefault_ReturnsIntPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetGlyphRangesDefault());
        }

        /// <summary>
        ///     Tests that get glyph ranges greek returns int ptr
        /// </summary>
        [Fact]
        public void GetGlyphRangesGreek_ReturnsIntPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetGlyphRangesGreek());
        }

        /// <summary>
        ///     Tests that get glyph ranges japanese returns int ptr
        /// </summary>
        [Fact]
        public void GetGlyphRangesJapanese_ReturnsIntPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetGlyphRangesJapanese());
        }

        /// <summary>
        ///     Tests that get glyph ranges korean returns int ptr
        /// </summary>
        [Fact]
        public void GetGlyphRangesKorean_ReturnsIntPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetGlyphRangesKorean());
        }

        /// <summary>
        ///     Tests that get glyph ranges thai returns int ptr
        /// </summary>
        [Fact]
        public void GetGlyphRangesThai_ReturnsIntPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetGlyphRangesThai());
        }

        /// <summary>
        ///     Tests that get glyph ranges vietnamese returns int ptr
        /// </summary>
        [Fact]
        public void GetGlyphRangesVietnamese_ReturnsIntPtr()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetGlyphRangesVietnamese());
        }

        /// <summary>
        ///     Tests that get mouse cursor tex data returns true
        /// </summary>
        [Fact]
        public void GetMouseCursorTexData_ReturnsTrue()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetMouseCursorTexData(ImGuiMouseCursor.Arrow, out Vector2F _, out Vector2F _, out Vector2F _, out Vector2F _));
        }

        /// <summary>
        ///     Tests that get tex data as alpha 8 returns data
        /// </summary>
        [Fact]
        public void GetTexDataAsAlpha8_ReturnsData()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetTexDataAsAlpha8(out byte[] _, out int _, out int _));
        }

        /// <summary>
        ///     Tests that get tex data as alpha 8 with bytes per pixel returns data
        /// </summary>
        [Fact]
        public void GetTexDataAsAlpha8_WithBytesPerPixel_ReturnsData()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetTexDataAsAlpha8(out byte[] _, out int _, out int _, out int _));
        }

        /// <summary>
        ///     Tests that get tex data as alpha 8 with int ptr returns data
        /// </summary>
        [Fact]
        public void GetTexDataAsAlpha8_WithIntPtr_ReturnsData()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetTexDataAsAlpha8(out IntPtr _, out int _, out int _));
        }

        /// <summary>
        ///     Tests that get tex data as alpha 8 with int ptr and bytes per pixel returns data
        /// </summary>
        [Fact]
        public void GetTexDataAsAlpha8_WithIntPtrAndBytesPerPixel_ReturnsData()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetTexDataAsAlpha8(out IntPtr _, out int _, out int _, out int _));
        }

        /// <summary>
        ///     Tests that get tex data as rgba 32 returns data
        /// </summary>
        [Fact]
        public void GetTexDataAsRgba32_ReturnsData()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetTexDataAsRgba32(out byte[] _, out int _, out int _, out int _));
        }

        /// <summary>
        ///     Tests that get tex data as rgba 32 with int ptr returns data
        /// </summary>
        [Fact]
        public void GetTexDataAsRgba32_WithIntPtr_ReturnsData()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetTexDataAsRgba32(out IntPtr _, out int _, out int _));
        }

        /// <summary>
        ///     Tests that get tex data as rgba 32 with int ptr and bytes per pixel returns data
        /// </summary>
        [Fact]
        public void GetTexDataAsRgba32_WithIntPtrAndBytesPerPixel_ReturnsData()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.GetTexDataAsRgba32(out IntPtr _, out int _, out int _, out int _));
        }

        /// <summary>
        ///     Tests that is built returns true
        /// </summary>
        [Fact]
        public void IsBuilt_ReturnsTrue()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            Assert.Throws<DllNotFoundException>(() => atlas.IsBuilt());
        }

        /// <summary>
        ///     Tests that set tex id sets id
        /// </summary>
        [Fact]
        public void SetTexId_SetsId()
        {
            ImFontAtlasPtr atlas = new ImFontAtlasPtr();
            IntPtr id = new IntPtr(123);
            Assert.Throws<DllNotFoundException>(() => atlas.SetTexId(id));
            // Assuming some way to verify the tex id is set
        }
    }
}