// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlasRemainingCoverageTests.cs
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

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im font atlas remaining coverage tests class
    /// </summary>
    public class ImFontAtlasRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that default im font atlas has representative zero values
        /// </summary>
        [Fact]
        public void Default_Should_HaveZeroValues()
        {
            ImFontAtlas atlas = new ImFontAtlas();

            Assert.Equal(IntPtr.Zero, atlas.TexId);
            Assert.Equal(0, atlas.TexWidth);
            Assert.Equal(0, atlas.Locked);
            Assert.Equal(default(ImFontAtlasFlags), atlas.Flags);
            Assert.Equal(default(Vector2F), atlas.TexUvScale);
            Assert.Equal(default(Vector4F), atlas.TexUvLines0);
        }

        /// <summary>
        ///     Tests that flags should set and get correctly
        /// </summary>
        [Fact]
        public void Flags_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasFlags flags = ImFontAtlasFlags.NoPowerOfTwoHeight;

            atlas.Flags = flags;

            Assert.Equal(flags, atlas.Flags);
        }

        /// <summary>
        ///     Tests that tex id should set and get correctly
        /// </summary>
        [Fact]
        public void TexId_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            IntPtr value = new IntPtr(789);

            atlas.TexId = value;

            Assert.Equal(value, atlas.TexId);
        }

        /// <summary>
        ///     Tests that tex pixels alpha 8 should set and get correctly
        /// </summary>
        [Fact]
        public void TexPixelsAlpha8_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            IntPtr value = new IntPtr(789);

            atlas.TexPixelsAlpha8 = value;

            Assert.Equal(value, atlas.TexPixelsAlpha8);
        }

        /// <summary>
        ///     Tests that tex pixels rgba 32 should set and get correctly
        /// </summary>
        [Fact]
        public void TexPixelsRgba32_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            IntPtr value = new IntPtr(789);

            atlas.TexPixelsRgba32 = value;

            Assert.Equal(value, atlas.TexPixelsRgba32);
        }

        /// <summary>
        ///     Tests that tex desired width should set and get correctly
        /// </summary>
        [Fact]
        public void TexDesiredWidth_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            int value = 512;

            atlas.TexDesiredWidth = value;

            Assert.Equal(value, atlas.TexDesiredWidth);
        }

        /// <summary>
        ///     Tests that tex glyph padding should set and get correctly
        /// </summary>
        [Fact]
        public void TexGlyphPadding_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            int value = 3;

            atlas.TexGlyphPadding = value;

            Assert.Equal(value, atlas.TexGlyphPadding);
        }

        /// <summary>
        ///     Tests that tex width should set and get correctly
        /// </summary>
        [Fact]
        public void TexWidth_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            int value = 1024;

            atlas.TexWidth = value;

            Assert.Equal(value, atlas.TexWidth);
        }

        /// <summary>
        ///     Tests that tex height should set and get correctly
        /// </summary>
        [Fact]
        public void TexHeight_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            int value = 768;

            atlas.TexHeight = value;

            Assert.Equal(value, atlas.TexHeight);
        }

        /// <summary>
        ///     Tests that locked should set and get correctly
        /// </summary>
        [Fact]
        public void Locked_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            byte value = 1;

            atlas.Locked = value;

            Assert.Equal(value, atlas.Locked);
        }

        /// <summary>
        ///     Tests that tex ready should set and get correctly
        /// </summary>
        [Fact]
        public void TexReady_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            byte value = 1;

            atlas.TexReady = value;

            Assert.Equal(value, atlas.TexReady);
        }

        /// <summary>
        ///     Tests that tex pixels use colors should set and get correctly
        /// </summary>
        [Fact]
        public void TexPixelsUseColors_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            byte value = 1;

            atlas.TexPixelsUseColors = value;

            Assert.Equal(value, atlas.TexPixelsUseColors);
        }

        /// <summary>
        ///     Tests that tex uv scale should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvScale_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector2F value = new Vector2F(0.5f, 0.25f);

            atlas.TexUvScale = value;

            Assert.Equal(value, atlas.TexUvScale);
        }

        /// <summary>
        ///     Tests that tex uv white pixel should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvWhitePixel_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector2F value = new Vector2F(0.5f, 0.25f);

            atlas.TexUvWhitePixel = value;

            Assert.Equal(value, atlas.TexUvWhitePixel);
        }

        /// <summary>
        ///     Tests that fonts should set and get correctly
        /// </summary>
        [Fact]
        public void Fonts_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImVector value = new ImVector(1, 2, new IntPtr(123));

            atlas.Fonts = value;

            Assert.Equal(value, atlas.Fonts);
        }

        /// <summary>
        ///     Tests that custom rects should set and get correctly
        /// </summary>
        [Fact]
        public void CustomRects_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImVector value = new ImVector(1, 2, new IntPtr(456));

            atlas.CustomRects = value;

            Assert.Equal(value, atlas.CustomRects);
        }

        /// <summary>
        ///     Tests that config data should set and get correctly
        /// </summary>
        [Fact]
        public void ConfigData_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImVector value = new ImVector(1, 2, new IntPtr(789));

            atlas.ConfigData = value;

            Assert.Equal(value, atlas.ConfigData);
        }

        /// <summary>
        ///     Tests that tex uv lines 0 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines0_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            atlas.TexUvLines0 = v;

            Assert.Equal(v, atlas.TexUvLines0);
        }

        /// <summary>
        ///     Tests that tex uv lines 5 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines5_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            atlas.TexUvLines5 = v;

            Assert.Equal(v, atlas.TexUvLines5);
        }

        /// <summary>
        ///     Tests that tex uv lines 10 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines10_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            atlas.TexUvLines10 = v;

            Assert.Equal(v, atlas.TexUvLines10);
        }

        /// <summary>
        ///     Tests that tex uv lines 20 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines20_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            atlas.TexUvLines20 = v;

            Assert.Equal(v, atlas.TexUvLines20);
        }

        /// <summary>
        ///     Tests that tex uv lines 30 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines30_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            atlas.TexUvLines30 = v;

            Assert.Equal(v, atlas.TexUvLines30);
        }

        /// <summary>
        ///     Tests that tex uv lines 39 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines39_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            atlas.TexUvLines39 = v;

            Assert.Equal(v, atlas.TexUvLines39);
        }

        /// <summary>
        ///     Tests that tex uv lines 50 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines50_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            atlas.TexUvLines50 = v;

            Assert.Equal(v, atlas.TexUvLines50);
        }

        /// <summary>
        ///     Tests that tex uv lines 63 should set and get correctly
        /// </summary>
        [Fact]
        public void TexUvLines63_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            atlas.TexUvLines63 = v;

            Assert.Equal(v, atlas.TexUvLines63);
        }

        /// <summary>
        ///     Tests that font builder io should set and get correctly
        /// </summary>
        [Fact]
        public void FontBuilderIo_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            IntPtr value = new IntPtr(4242);

            atlas.FontBuilderIo = value;

            Assert.Equal(value, atlas.FontBuilderIo);
        }

        /// <summary>
        ///     Tests that font builder flags should set and get correctly
        /// </summary>
        [Fact]
        public void FontBuilderFlags_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            uint value = 7u;

            atlas.FontBuilderFlags = value;

            Assert.Equal(value, atlas.FontBuilderFlags);
        }

        /// <summary>
        ///     Tests that pack id mouse cursors should set and get correctly
        /// </summary>
        [Fact]
        public void PackIdMouseCursors_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            int value = 42;

            atlas.PackIdMouseCursors = value;

            Assert.Equal(value, atlas.PackIdMouseCursors);
        }

        /// <summary>
        ///     Tests that pack id lines should set and get correctly
        /// </summary>
        [Fact]
        public void PackIdLines_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            int value = 99;

            atlas.PackIdLines = value;

            Assert.Equal(value, atlas.PackIdLines);
        }
    }
}