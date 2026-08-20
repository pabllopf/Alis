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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
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
         [RequireCImguiSystemFact]
        public void PackIdLines_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            int value = 99;

            atlas.PackIdLines = value;

            Assert.Equal(value, atlas.PackIdLines);
        }

        /// <summary>
        ///     Tests that tex uv lines 1 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines1_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines1 = v;
            Assert.Equal(v, atlas.TexUvLines1);
        }

        /// <summary>
        ///     Tests that tex uv lines 2 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines2_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines2 = v;
            Assert.Equal(v, atlas.TexUvLines2);
        }

        /// <summary>
        ///     Tests that tex uv lines 3 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines3_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines3 = v;
            Assert.Equal(v, atlas.TexUvLines3);
        }

        /// <summary>
        ///     Tests that tex uv lines 4 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines4_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines4 = v;
            Assert.Equal(v, atlas.TexUvLines4);
        }

        /// <summary>
        ///     Tests that tex uv lines 6 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines6_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines6 = v;
            Assert.Equal(v, atlas.TexUvLines6);
        }

        /// <summary>
        ///     Tests that tex uv lines 7 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines7_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines7 = v;
            Assert.Equal(v, atlas.TexUvLines7);
        }

        /// <summary>
        ///     Tests that tex uv lines 8 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines8_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines8 = v;
            Assert.Equal(v, atlas.TexUvLines8);
        }

        /// <summary>
        ///     Tests that tex uv lines 9 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines9_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines9 = v;
            Assert.Equal(v, atlas.TexUvLines9);
        }

        /// <summary>
        ///     Tests that tex uv lines 11 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines11_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines11 = v;
            Assert.Equal(v, atlas.TexUvLines11);
        }

        /// <summary>
        ///     Tests that tex uv lines 12 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines12_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines12 = v;
            Assert.Equal(v, atlas.TexUvLines12);
        }

        /// <summary>
        ///     Tests that tex uv lines 13 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines13_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines13 = v;
            Assert.Equal(v, atlas.TexUvLines13);
        }

        /// <summary>
        ///     Tests that tex uv lines 14 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines14_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines14 = v;
            Assert.Equal(v, atlas.TexUvLines14);
        }

        /// <summary>
        ///     Tests that tex uv lines 15 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines15_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines15 = v;
            Assert.Equal(v, atlas.TexUvLines15);
        }

        /// <summary>
        ///     Tests that tex uv lines 16 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines16_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines16 = v;
            Assert.Equal(v, atlas.TexUvLines16);
        }

        /// <summary>
        ///     Tests that tex uv lines 17 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines17_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines17 = v;
            Assert.Equal(v, atlas.TexUvLines17);
        }

        /// <summary>
        ///     Tests that tex uv lines 18 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines18_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines18 = v;
            Assert.Equal(v, atlas.TexUvLines18);
        }

        /// <summary>
        ///     Tests that tex uv lines 19 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines19_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines19 = v;
            Assert.Equal(v, atlas.TexUvLines19);
        }

        /// <summary>
        ///     Tests that tex uv lines 21 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines21_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines21 = v;
            Assert.Equal(v, atlas.TexUvLines21);
        }

        /// <summary>
        ///     Tests that tex uv lines 22 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines22_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines22 = v;
            Assert.Equal(v, atlas.TexUvLines22);
        }

        /// <summary>
        ///     Tests that tex uv lines 23 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines23_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines23 = v;
            Assert.Equal(v, atlas.TexUvLines23);
        }

        /// <summary>
        ///     Tests that tex uv lines 24 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines24_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines24 = v;
            Assert.Equal(v, atlas.TexUvLines24);
        }

        /// <summary>
        ///     Tests that tex uv lines 25 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines25_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines25 = v;
            Assert.Equal(v, atlas.TexUvLines25);
        }

        /// <summary>
        ///     Tests that tex uv lines 26 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines26_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines26 = v;
            Assert.Equal(v, atlas.TexUvLines26);
        }

        /// <summary>
        ///     Tests that tex uv lines 27 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines27_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines27 = v;
            Assert.Equal(v, atlas.TexUvLines27);
        }

        /// <summary>
        ///     Tests that tex uv lines 28 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines28_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines28 = v;
            Assert.Equal(v, atlas.TexUvLines28);
        }

        /// <summary>
        ///     Tests that tex uv lines 29 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines29_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines29 = v;
            Assert.Equal(v, atlas.TexUvLines29);
        }

        /// <summary>
        ///     Tests that tex uv lines 31 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines31_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines31 = v;
            Assert.Equal(v, atlas.TexUvLines31);
        }

        /// <summary>
        ///     Tests that tex uv lines 32 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines32_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines32 = v;
            Assert.Equal(v, atlas.TexUvLines32);
        }

        /// <summary>
        ///     Tests that tex uv lines 33 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines33_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines33 = v;
            Assert.Equal(v, atlas.TexUvLines33);
        }

        /// <summary>
        ///     Tests that tex uv lines 34 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines34_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines34 = v;
            Assert.Equal(v, atlas.TexUvLines34);
        }

        /// <summary>
        ///     Tests that tex uv lines 35 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines35_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines35 = v;
            Assert.Equal(v, atlas.TexUvLines35);
        }

        /// <summary>
        ///     Tests that tex uv lines 36 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines36_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines36 = v;
            Assert.Equal(v, atlas.TexUvLines36);
        }

        /// <summary>
        ///     Tests that tex uv lines 37 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines37_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines37 = v;
            Assert.Equal(v, atlas.TexUvLines37);
        }

        /// <summary>
        ///     Tests that tex uv lines 38 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines38_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines38 = v;
            Assert.Equal(v, atlas.TexUvLines38);
        }

        /// <summary>
        ///     Tests that tex uv lines 40 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines40_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines40 = v;
            Assert.Equal(v, atlas.TexUvLines40);
        }

        /// <summary>
        ///     Tests that tex uv lines 41 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines41_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines41 = v;
            Assert.Equal(v, atlas.TexUvLines41);
        }

        /// <summary>
        ///     Tests that tex uv lines 42 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines42_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines42 = v;
            Assert.Equal(v, atlas.TexUvLines42);
        }

        /// <summary>
        ///     Tests that tex uv lines 43 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines43_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines43 = v;
            Assert.Equal(v, atlas.TexUvLines43);
        }

        /// <summary>
        ///     Tests that tex uv lines 44 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines44_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines44 = v;
            Assert.Equal(v, atlas.TexUvLines44);
        }

        /// <summary>
        ///     Tests that tex uv lines 45 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines45_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines45 = v;
            Assert.Equal(v, atlas.TexUvLines45);
        }

        /// <summary>
        ///     Tests that tex uv lines 46 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines46_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines46 = v;
            Assert.Equal(v, atlas.TexUvLines46);
        }

        /// <summary>
        ///     Tests that tex uv lines 47 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines47_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines47 = v;
            Assert.Equal(v, atlas.TexUvLines47);
        }

        /// <summary>
        ///     Tests that tex uv lines 48 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines48_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines48 = v;
            Assert.Equal(v, atlas.TexUvLines48);
        }

        /// <summary>
        ///     Tests that tex uv lines 49 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines49_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines49 = v;
            Assert.Equal(v, atlas.TexUvLines49);
        }

        /// <summary>
        ///     Tests that tex uv lines 51 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines51_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines51 = v;
            Assert.Equal(v, atlas.TexUvLines51);
        }

        /// <summary>
        ///     Tests that tex uv lines 52 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines52_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines52 = v;
            Assert.Equal(v, atlas.TexUvLines52);
        }

        /// <summary>
        ///     Tests that tex uv lines 53 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines53_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines53 = v;
            Assert.Equal(v, atlas.TexUvLines53);
        }

        /// <summary>
        ///     Tests that tex uv lines 54 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines54_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines54 = v;
            Assert.Equal(v, atlas.TexUvLines54);
        }

        /// <summary>
        ///     Tests that tex uv lines 55 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines55_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines55 = v;
            Assert.Equal(v, atlas.TexUvLines55);
        }

        /// <summary>
        ///     Tests that tex uv lines 56 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines56_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines56 = v;
            Assert.Equal(v, atlas.TexUvLines56);
        }

        /// <summary>
        ///     Tests that tex uv lines 57 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines57_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines57 = v;
            Assert.Equal(v, atlas.TexUvLines57);
        }

        /// <summary>
        ///     Tests that tex uv lines 58 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines58_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines58 = v;
            Assert.Equal(v, atlas.TexUvLines58);
        }

        /// <summary>
        ///     Tests that tex uv lines 59 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines59_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines59 = v;
            Assert.Equal(v, atlas.TexUvLines59);
        }

        /// <summary>
        ///     Tests that tex uv lines 60 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines60_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines60 = v;
            Assert.Equal(v, atlas.TexUvLines60);
        }

        /// <summary>
        ///     Tests that tex uv lines 61 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines61_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines61 = v;
            Assert.Equal(v, atlas.TexUvLines61);
        }

        /// <summary>
        ///     Tests that tex uv lines 62 should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void TexUvLines62_Should_SetAndGetCorrectly()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            atlas.TexUvLines62 = v;
            Assert.Equal(v, atlas.TexUvLines62);
        }
    }
}