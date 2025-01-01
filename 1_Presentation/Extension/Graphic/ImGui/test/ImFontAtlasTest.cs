// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlasTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    ///     The im font atlas test class
    /// </summary>
    public class ImFontAtlasTest
    {
        /// <summary>
        ///     Tests that flags should set and get correctly
        /// </summary>
        [Fact]
        public void Flags_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            fontAtlas.Flags = ImFontAtlasFlags.NoPowerOfTwoHeight;
            Assert.Equal(ImFontAtlasFlags.NoPowerOfTwoHeight, fontAtlas.Flags);
        }

        /// <summary>
        ///     Tests that tex id should set and get correctly
        /// </summary>
        [Fact]
        public void TexId_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            IntPtr texId = new IntPtr(123);
            fontAtlas.TexId = texId;
            Assert.Equal(texId, fontAtlas.TexId);
        }

        /// <summary>
        ///     Tests that tex desired width should set and get correctly
        /// </summary>
        [Fact]
        public void TexDesiredWidth_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            fontAtlas.TexDesiredWidth = 512;
            Assert.Equal(512, fontAtlas.TexDesiredWidth);
        }

        /// <summary>
        ///     Tests that tex glyph padding should set and get correctly
        /// </summary>
        [Fact]
        public void TexGlyphPadding_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            fontAtlas.TexGlyphPadding = 1;
            Assert.Equal(1, fontAtlas.TexGlyphPadding);
        }

        /// <summary>
        ///     Tests that locked should set and get correctly
        /// </summary>
        [Fact]
        public void Locked_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            fontAtlas.Locked = 1;
            Assert.Equal(1, fontAtlas.Locked);
        }

        /// <summary>
        ///     Tests that tex ready should set and get correctly
        /// </summary>
        [Fact]
        public void TexReady_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            fontAtlas.TexReady = 1;
            Assert.Equal(1, fontAtlas.TexReady);
        }

        /// <summary>
        ///     Tests that tex pixels use colors should set and get correctly
        /// </summary>
        [Fact]
        public void TexPixelsUseColors_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            fontAtlas.TexPixelsUseColors = 1;
            Assert.Equal(1, fontAtlas.TexPixelsUseColors);
        }

        /// <summary>
        ///     Tests that tex pixels alpha 8 should set and get correctly
        /// </summary>
        [Fact]
        public void TexPixelsAlpha8_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            IntPtr texPixelsAlpha8 = new IntPtr(123);
            fontAtlas.TexPixelsAlpha8 = texPixelsAlpha8;
            Assert.Equal(texPixelsAlpha8, fontAtlas.TexPixelsAlpha8);
        }

        /// <summary>
        ///     Tests that tex pixels rgba 32 should set and get correctly
        /// </summary>
        [Fact]
        public void TexPixelsRgba32_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            IntPtr texPixelsRgba32 = new IntPtr(123);
            fontAtlas.TexPixelsRgba32 = texPixelsRgba32;
            Assert.Equal(texPixelsRgba32, fontAtlas.TexPixelsRgba32);
        }

        /// <summary>
        ///     Tests that tex width should set and get correctly
        /// </summary>
        [Fact]
        public void TexWidth_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            fontAtlas.TexWidth = 1024;
            Assert.Equal(1024, fontAtlas.TexWidth);
        }

        /// <summary>
        ///     Tests that tex height should set and get correctly
        /// </summary>
        [Fact]
        public void TexHeight_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            fontAtlas.TexHeight = 1024;
            Assert.Equal(1024, fontAtlas.TexHeight);
        }

        /// <summary>
        ///     Tests that tex uv scale should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvScale_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            Vector2F texUvScale = new Vector2F(1.0f, 1.0f);
            fontAtlas.TexUvScale = texUvScale;
            Assert.Equal(texUvScale, fontAtlas.TexUvScale);
        }

        /// <summary>
        ///     Tests that tex uv white pixel should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvWhitePixel_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            Vector2F texUvWhitePixel = new Vector2F(1.0f, 1.0f);
            fontAtlas.TexUvWhitePixel = texUvWhitePixel;
            Assert.Equal(texUvWhitePixel, fontAtlas.TexUvWhitePixel);
        }

        /// <summary>
        ///     Tests that fonts should set and get correctly
        /// </summary>
        [Fact]
        public void Fonts_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            ImVector fonts = new ImVector();
            fontAtlas.Fonts = fonts;
            Assert.Equal(fonts, fontAtlas.Fonts);
        }

        /// <summary>
        ///     Tests that custom rects should set and get correctly
        /// </summary>
        [Fact]
        public void CustomRects_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            ImVector customRects = new ImVector();
            fontAtlas.CustomRects = customRects;
            Assert.Equal(customRects, fontAtlas.CustomRects);
        }

        /// <summary>
        ///     Tests that config data should set and get correctly
        /// </summary>
        [Fact]
        public void ConfigData_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            ImVector configData = new ImVector();
            fontAtlas.ConfigData = configData;
            Assert.Equal(configData, fontAtlas.ConfigData);
        }

        /// <summary>
        ///     Tests that tex uv lines should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            Vector4F texUvLines = new Vector4F(1.0f, 1.0f, 1.0f, 1.0f);
            fontAtlas.TexUvLines0 = texUvLines;
            Assert.Equal(texUvLines, fontAtlas.TexUvLines0);
        }

        /// <summary>
        ///     Tests that font builder io should set and get correctly
        /// </summary>
        [Fact]
        public void FontBuilderIo_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            IntPtr fontBuilderIo = new IntPtr(123);
            fontAtlas.FontBuilderIo = fontBuilderIo;
            Assert.Equal(fontBuilderIo, fontAtlas.FontBuilderIo);
        }

        /// <summary>
        ///     Tests that font builder flags should set and get correctly
        /// </summary>
        [Fact]
        public void FontBuilderFlags_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            fontAtlas.FontBuilderFlags = 1;
            Assert.Equal(1u, fontAtlas.FontBuilderFlags);
        }

        /// <summary>
        ///     Tests that pack id mouse cursors should set and get correctly
        /// </summary>
        [Fact]
        public void PackIdMouseCursors_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            fontAtlas.PackIdMouseCursors = 1;
            Assert.Equal(1, fontAtlas.PackIdMouseCursors);
        }

        /// <summary>
        ///     Tests that pack id lines should set and get correctly
        /// </summary>
        [Fact]
        public void PackIdLines_Should_SetAndGetCorrectly()
        {
            ImFontAtlas fontAtlas = new ImFontAtlas();
            fontAtlas.PackIdLines = 1;
            Assert.Equal(1, fontAtlas.PackIdLines);
        }
    }
}