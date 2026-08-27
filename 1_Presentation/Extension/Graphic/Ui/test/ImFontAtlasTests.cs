// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlasTests.cs
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
    ///     The im font atlas tests class
    /// </summary>
    public class ImFontAtlasTests
    {
        /// <summary>
        ///     Tests that default instance has default values
        /// </summary>
        [Fact]
        public void DefaultInstance_HasDefaultValues()
        {
            ImFontAtlas atlas = new ImFontAtlas();

            Assert.Equal(ImFontAtlasFlags.None, atlas.Flags);
            Assert.Equal(IntPtr.Zero, atlas.TexId);
            Assert.Equal(0, atlas.TexDesiredWidth);
            Assert.Equal(0, atlas.TexGlyphPadding);
            Assert.Equal(0, atlas.Locked);
            Assert.Equal(0, atlas.TexReady);
            Assert.Equal(0, atlas.TexPixelsUseColors);
            Assert.Equal(IntPtr.Zero, atlas.TexPixelsAlpha8);
            Assert.Equal(IntPtr.Zero, atlas.TexPixelsRgba32);
            Assert.Equal(0, atlas.TexWidth);
            Assert.Equal(0, atlas.TexHeight);
            Assert.Equal(0.0f, atlas.TexUvScale.X);
            Assert.Equal(0.0f, atlas.TexUvScale.Y);
            Assert.Equal(0.0f, atlas.TexUvWhitePixel.X);
            Assert.Equal(0.0f, atlas.TexUvWhitePixel.Y);
            Assert.Equal(0, atlas.Fonts.Size);
            Assert.Equal(0, atlas.CustomRects.Size);
            Assert.Equal(0, atlas.ConfigData.Size);
            Assert.Equal(IntPtr.Zero, atlas.FontBuilderIo);
            Assert.Equal(0u, atlas.FontBuilderFlags);
            Assert.Equal(0, atlas.PackIdMouseCursors);
            Assert.Equal(0, atlas.PackIdLines);
        }

        /// <summary>
        ///     Tests that flags set and get returns correct value
        /// </summary>
        [Fact]
        public void Flags_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasFlags expected = ImFontAtlasFlags.NoBakedLines | ImFontAtlasFlags.NoMouseCursors;

            atlas.Flags = expected;

            Assert.Equal(expected, atlas.Flags);
        }

        /// <summary>
        ///     Tests that tex id set and get returns correct value
        /// </summary>
        [Fact]
        public void TexId_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            IntPtr expected = new IntPtr(1234);

            atlas.TexId = expected;

            Assert.Equal(expected, atlas.TexId);
        }

        /// <summary>
        ///     Tests that tex desired width set and get returns correct value
        /// </summary>
        [Fact]
        public void TexDesiredWidth_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            const int expected = 512;

            atlas.TexDesiredWidth = expected;

            Assert.Equal(expected, atlas.TexDesiredWidth);
        }

        /// <summary>
        ///     Tests that tex glyph padding set and get returns correct value
        /// </summary>
        [Fact]
        public void TexGlyphPadding_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            const int expected = 1;

            atlas.TexGlyphPadding = expected;

            Assert.Equal(expected, atlas.TexGlyphPadding);
        }

        /// <summary>
        ///     Tests that locked set and get returns correct value
        /// </summary>
        [Fact]
        public void Locked_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            const byte expected = 1;

            atlas.Locked = expected;

            Assert.Equal(expected, atlas.Locked);
        }

        /// <summary>
        ///     Tests that tex ready set and get returns correct value
        /// </summary>
        [Fact]
        public void TexReady_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            const byte expected = 1;

            atlas.TexReady = expected;

            Assert.Equal(expected, atlas.TexReady);
        }

        /// <summary>
        ///     Tests that tex pixels use colors set and get returns correct value
        /// </summary>
        [Fact]
        public void TexPixelsUseColors_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            const byte expected = 1;

            atlas.TexPixelsUseColors = expected;

            Assert.Equal(expected, atlas.TexPixelsUseColors);
        }

        /// <summary>
        ///     Tests that tex pixels alpha 8 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexPixelsAlpha8_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            IntPtr expected = new IntPtr(5678);

            atlas.TexPixelsAlpha8 = expected;

            Assert.Equal(expected, atlas.TexPixelsAlpha8);
        }

        /// <summary>
        ///     Tests that tex pixels rgba 32 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexPixelsRgba32_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            IntPtr expected = new IntPtr(9012);

            atlas.TexPixelsRgba32 = expected;

            Assert.Equal(expected, atlas.TexPixelsRgba32);
        }

        /// <summary>
        ///     Tests that tex width set and get returns correct value
        /// </summary>
        [Fact]
        public void TexWidth_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            const int expected = 1024;

            atlas.TexWidth = expected;

            Assert.Equal(expected, atlas.TexWidth);
        }

        /// <summary>
        ///     Tests that tex height set and get returns correct value
        /// </summary>
        [Fact]
        public void TexHeight_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            const int expected = 1024;

            atlas.TexHeight = expected;

            Assert.Equal(expected, atlas.TexHeight);
        }

        /// <summary>
        ///     Tests that tex uv scale set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvScale_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector2F expected = new Vector2F(0.5f, 0.25f);

            atlas.TexUvScale = expected;

            Assert.Equal(expected, atlas.TexUvScale);
            Assert.Equal(0.5f, atlas.TexUvScale.X);
            Assert.Equal(0.25f, atlas.TexUvScale.Y);
        }

        /// <summary>
        ///     Tests that tex uv white pixel set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvWhitePixel_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector2F expected = new Vector2F(0.75f, 0.125f);

            atlas.TexUvWhitePixel = expected;

            Assert.Equal(expected, atlas.TexUvWhitePixel);
            Assert.Equal(0.75f, atlas.TexUvWhitePixel.X);
            Assert.Equal(0.125f, atlas.TexUvWhitePixel.Y);
        }

        /// <summary>
        ///     Tests that fonts set and get returns correct value
        /// </summary>
        [Fact]
        public void Fonts_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImVector expected = new ImVector(3, 8, new IntPtr(111));

            atlas.Fonts = expected;

            Assert.Equal(expected, atlas.Fonts);
            Assert.Equal(3, atlas.Fonts.Size);
            Assert.Equal(8, atlas.Fonts.Capacity);
            Assert.Equal(new IntPtr(111), atlas.Fonts.Data);
        }

        /// <summary>
        ///     Tests that custom rects set and get returns correct value
        /// </summary>
        [Fact]
        public void CustomRects_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImVector expected = new ImVector(2, 4, new IntPtr(222));

            atlas.CustomRects = expected;

            Assert.Equal(expected, atlas.CustomRects);
            Assert.Equal(2, atlas.CustomRects.Size);
            Assert.Equal(4, atlas.CustomRects.Capacity);
            Assert.Equal(new IntPtr(222), atlas.CustomRects.Data);
        }

        /// <summary>
        ///     Tests that config data set and get returns correct value
        /// </summary>
        [Fact]
        public void ConfigData_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImVector expected = new ImVector(5, 16, new IntPtr(333));

            atlas.ConfigData = expected;

            Assert.Equal(expected, atlas.ConfigData);
            Assert.Equal(5, atlas.ConfigData.Size);
            Assert.Equal(16, atlas.ConfigData.Capacity);
            Assert.Equal(new IntPtr(333), atlas.ConfigData.Data);
        }

        /// <summary>
        ///     Tests that tex uv lines 0 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines0_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.01f, 0.02f, 0.03f, 0.04f);

            atlas.TexUvLines0 = expected;

            Assert.Equal(expected, atlas.TexUvLines0);
        }

        /// <summary>
        ///     Tests that tex uv lines 1 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines1_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.05f, 0.06f, 0.07f, 0.08f);

            atlas.TexUvLines1 = expected;

            Assert.Equal(expected, atlas.TexUvLines1);
        }

        /// <summary>
        ///     Tests that tex uv lines 2 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines2_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.09f, 0.10f, 0.11f, 0.12f);

            atlas.TexUvLines2 = expected;

            Assert.Equal(expected, atlas.TexUvLines2);
        }

        /// <summary>
        ///     Tests that tex uv lines 3 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines3_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.13f, 0.14f, 0.15f, 0.16f);

            atlas.TexUvLines3 = expected;

            Assert.Equal(expected, atlas.TexUvLines3);
        }

        /// <summary>
        ///     Tests that tex uv lines 4 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines4_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.17f, 0.18f, 0.19f, 0.20f);

            atlas.TexUvLines4 = expected;

            Assert.Equal(expected, atlas.TexUvLines4);
        }

        /// <summary>
        ///     Tests that tex uv lines 5 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines5_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.21f, 0.22f, 0.23f, 0.24f);

            atlas.TexUvLines5 = expected;

            Assert.Equal(expected, atlas.TexUvLines5);
        }

        /// <summary>
        ///     Tests that tex uv lines 6 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines6_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.25f, 0.26f, 0.27f, 0.28f);

            atlas.TexUvLines6 = expected;

            Assert.Equal(expected, atlas.TexUvLines6);
        }

        /// <summary>
        ///     Tests that tex uv lines 7 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines7_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.29f, 0.30f, 0.31f, 0.32f);

            atlas.TexUvLines7 = expected;

            Assert.Equal(expected, atlas.TexUvLines7);
        }

        /// <summary>
        ///     Tests that tex uv lines 8 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines8_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.33f, 0.34f, 0.35f, 0.36f);

            atlas.TexUvLines8 = expected;

            Assert.Equal(expected, atlas.TexUvLines8);
        }

        /// <summary>
        ///     Tests that tex uv lines 9 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines9_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.37f, 0.38f, 0.39f, 0.40f);

            atlas.TexUvLines9 = expected;

            Assert.Equal(expected, atlas.TexUvLines9);
        }

        /// <summary>
        ///     Tests that tex uv lines 10 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines10_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.41f, 0.42f, 0.43f, 0.44f);

            atlas.TexUvLines10 = expected;

            Assert.Equal(expected, atlas.TexUvLines10);
        }

        /// <summary>
        ///     Tests that tex uv lines 11 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines11_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.45f, 0.46f, 0.47f, 0.48f);

            atlas.TexUvLines11 = expected;

            Assert.Equal(expected, atlas.TexUvLines11);
        }

        /// <summary>
        ///     Tests that tex uv lines 12 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines12_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.49f, 0.50f, 0.51f, 0.52f);

            atlas.TexUvLines12 = expected;

            Assert.Equal(expected, atlas.TexUvLines12);
        }

        /// <summary>
        ///     Tests that tex uv lines 13 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines13_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.53f, 0.54f, 0.55f, 0.56f);

            atlas.TexUvLines13 = expected;

            Assert.Equal(expected, atlas.TexUvLines13);
        }

        /// <summary>
        ///     Tests that tex uv lines 14 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines14_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.57f, 0.58f, 0.59f, 0.60f);

            atlas.TexUvLines14 = expected;

            Assert.Equal(expected, atlas.TexUvLines14);
        }

        /// <summary>
        ///     Tests that tex uv lines 15 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines15_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.61f, 0.62f, 0.63f, 0.64f);

            atlas.TexUvLines15 = expected;

            Assert.Equal(expected, atlas.TexUvLines15);
        }

        /// <summary>
        ///     Tests that tex uv lines 16 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines16_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.65f, 0.66f, 0.67f, 0.68f);

            atlas.TexUvLines16 = expected;

            Assert.Equal(expected, atlas.TexUvLines16);
        }

        /// <summary>
        ///     Tests that tex uv lines 17 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines17_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.69f, 0.70f, 0.71f, 0.72f);

            atlas.TexUvLines17 = expected;

            Assert.Equal(expected, atlas.TexUvLines17);
        }

        /// <summary>
        ///     Tests that tex uv lines 18 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines18_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.73f, 0.74f, 0.75f, 0.76f);

            atlas.TexUvLines18 = expected;

            Assert.Equal(expected, atlas.TexUvLines18);
        }

        /// <summary>
        ///     Tests that tex uv lines 19 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines19_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.77f, 0.78f, 0.79f, 0.80f);

            atlas.TexUvLines19 = expected;

            Assert.Equal(expected, atlas.TexUvLines19);
        }

        /// <summary>
        ///     Tests that tex uv lines 20 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines20_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.81f, 0.82f, 0.83f, 0.84f);

            atlas.TexUvLines20 = expected;

            Assert.Equal(expected, atlas.TexUvLines20);
        }

        /// <summary>
        ///     Tests that tex uv lines 21 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines21_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.85f, 0.86f, 0.87f, 0.88f);

            atlas.TexUvLines21 = expected;

            Assert.Equal(expected, atlas.TexUvLines21);
        }

        /// <summary>
        ///     Tests that tex uv lines 22 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines22_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.89f, 0.90f, 0.91f, 0.92f);

            atlas.TexUvLines22 = expected;

            Assert.Equal(expected, atlas.TexUvLines22);
        }

        /// <summary>
        ///     Tests that tex uv lines 23 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines23_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(0.93f, 0.94f, 0.95f, 0.96f);

            atlas.TexUvLines23 = expected;

            Assert.Equal(expected, atlas.TexUvLines23);
        }

        /// <summary>
        ///     Tests that tex uv lines 24 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines24_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.01f, 1.02f, 1.03f, 1.04f);

            atlas.TexUvLines24 = expected;

            Assert.Equal(expected, atlas.TexUvLines24);
        }

        /// <summary>
        ///     Tests that tex uv lines 25 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines25_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.05f, 1.06f, 1.07f, 1.08f);

            atlas.TexUvLines25 = expected;

            Assert.Equal(expected, atlas.TexUvLines25);
        }

        /// <summary>
        ///     Tests that tex uv lines 26 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines26_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.09f, 1.10f, 1.11f, 1.12f);

            atlas.TexUvLines26 = expected;

            Assert.Equal(expected, atlas.TexUvLines26);
        }

        /// <summary>
        ///     Tests that tex uv lines 27 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines27_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.13f, 1.14f, 1.15f, 1.16f);

            atlas.TexUvLines27 = expected;

            Assert.Equal(expected, atlas.TexUvLines27);
        }

        /// <summary>
        ///     Tests that tex uv lines 28 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines28_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.17f, 1.18f, 1.19f, 1.20f);

            atlas.TexUvLines28 = expected;

            Assert.Equal(expected, atlas.TexUvLines28);
        }

        /// <summary>
        ///     Tests that tex uv lines 29 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines29_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.21f, 1.22f, 1.23f, 1.24f);

            atlas.TexUvLines29 = expected;

            Assert.Equal(expected, atlas.TexUvLines29);
        }

        /// <summary>
        ///     Tests that tex uv lines 30 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines30_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.25f, 1.26f, 1.27f, 1.28f);

            atlas.TexUvLines30 = expected;

            Assert.Equal(expected, atlas.TexUvLines30);
        }

        /// <summary>
        ///     Tests that tex uv lines 31 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines31_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.29f, 1.30f, 1.31f, 1.32f);

            atlas.TexUvLines31 = expected;

            Assert.Equal(expected, atlas.TexUvLines31);
        }

        /// <summary>
        ///     Tests that tex uv lines 32 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines32_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.33f, 1.34f, 1.35f, 1.36f);

            atlas.TexUvLines32 = expected;

            Assert.Equal(expected, atlas.TexUvLines32);
        }

        /// <summary>
        ///     Tests that tex uv lines 33 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines33_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.37f, 1.38f, 1.39f, 1.40f);

            atlas.TexUvLines33 = expected;

            Assert.Equal(expected, atlas.TexUvLines33);
        }

        /// <summary>
        ///     Tests that tex uv lines 34 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines34_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.41f, 1.42f, 1.43f, 1.44f);

            atlas.TexUvLines34 = expected;

            Assert.Equal(expected, atlas.TexUvLines34);
        }

        /// <summary>
        ///     Tests that tex uv lines 35 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines35_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.45f, 1.46f, 1.47f, 1.48f);

            atlas.TexUvLines35 = expected;

            Assert.Equal(expected, atlas.TexUvLines35);
        }

        /// <summary>
        ///     Tests that tex uv lines 36 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines36_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.49f, 1.50f, 1.51f, 1.52f);

            atlas.TexUvLines36 = expected;

            Assert.Equal(expected, atlas.TexUvLines36);
        }

        /// <summary>
        ///     Tests that tex uv lines 37 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines37_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.53f, 1.54f, 1.55f, 1.56f);

            atlas.TexUvLines37 = expected;

            Assert.Equal(expected, atlas.TexUvLines37);
        }

        /// <summary>
        ///     Tests that tex uv lines 38 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines38_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.57f, 1.58f, 1.59f, 1.60f);

            atlas.TexUvLines38 = expected;

            Assert.Equal(expected, atlas.TexUvLines38);
        }

        /// <summary>
        ///     Tests that tex uv lines 39 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines39_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.61f, 1.62f, 1.63f, 1.64f);

            atlas.TexUvLines39 = expected;

            Assert.Equal(expected, atlas.TexUvLines39);
        }

        /// <summary>
        ///     Tests that tex uv lines 40 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines40_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.65f, 1.66f, 1.67f, 1.68f);

            atlas.TexUvLines40 = expected;

            Assert.Equal(expected, atlas.TexUvLines40);
        }

        /// <summary>
        ///     Tests that tex uv lines 41 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines41_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.69f, 1.70f, 1.71f, 1.72f);

            atlas.TexUvLines41 = expected;

            Assert.Equal(expected, atlas.TexUvLines41);
        }

        /// <summary>
        ///     Tests that tex uv lines 42 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines42_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.73f, 1.74f, 1.75f, 1.76f);

            atlas.TexUvLines42 = expected;

            Assert.Equal(expected, atlas.TexUvLines42);
        }

        /// <summary>
        ///     Tests that tex uv lines 43 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines43_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.77f, 1.78f, 1.79f, 1.80f);

            atlas.TexUvLines43 = expected;

            Assert.Equal(expected, atlas.TexUvLines43);
        }

        /// <summary>
        ///     Tests that tex uv lines 44 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines44_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.81f, 1.82f, 1.83f, 1.84f);

            atlas.TexUvLines44 = expected;

            Assert.Equal(expected, atlas.TexUvLines44);
        }

        /// <summary>
        ///     Tests that tex uv lines 45 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines45_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.85f, 1.86f, 1.87f, 1.88f);

            atlas.TexUvLines45 = expected;

            Assert.Equal(expected, atlas.TexUvLines45);
        }

        /// <summary>
        ///     Tests that tex uv lines 46 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines46_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.89f, 1.90f, 1.91f, 1.92f);

            atlas.TexUvLines46 = expected;

            Assert.Equal(expected, atlas.TexUvLines46);
        }

        /// <summary>
        ///     Tests that tex uv lines 47 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines47_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(1.93f, 1.94f, 1.95f, 1.96f);

            atlas.TexUvLines47 = expected;

            Assert.Equal(expected, atlas.TexUvLines47);
        }

        /// <summary>
        ///     Tests that tex uv lines 48 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines48_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(2.01f, 2.02f, 2.03f, 2.04f);

            atlas.TexUvLines48 = expected;

            Assert.Equal(expected, atlas.TexUvLines48);
        }

        /// <summary>
        ///     Tests that tex uv lines 49 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines49_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(2.05f, 2.06f, 2.07f, 2.08f);

            atlas.TexUvLines49 = expected;

            Assert.Equal(expected, atlas.TexUvLines49);
        }

        /// <summary>
        ///     Tests that tex uv lines 50 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines50_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(2.09f, 2.10f, 2.11f, 2.12f);

            atlas.TexUvLines50 = expected;

            Assert.Equal(expected, atlas.TexUvLines50);
        }

        /// <summary>
        ///     Tests that tex uv lines 51 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines51_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(2.13f, 2.14f, 2.15f, 2.16f);

            atlas.TexUvLines51 = expected;

            Assert.Equal(expected, atlas.TexUvLines51);
        }

        /// <summary>
        ///     Tests that tex uv lines 52 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines52_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(2.17f, 2.18f, 2.19f, 2.20f);

            atlas.TexUvLines52 = expected;

            Assert.Equal(expected, atlas.TexUvLines52);
        }

        /// <summary>
        ///     Tests that tex uv lines 53 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines53_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(2.21f, 2.22f, 2.23f, 2.24f);

            atlas.TexUvLines53 = expected;

            Assert.Equal(expected, atlas.TexUvLines53);
        }

        /// <summary>
        ///     Tests that tex uv lines 54 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines54_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(2.25f, 2.26f, 2.27f, 2.28f);

            atlas.TexUvLines54 = expected;

            Assert.Equal(expected, atlas.TexUvLines54);
        }

        /// <summary>
        ///     Tests that tex uv lines 55 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines55_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(2.29f, 2.30f, 2.31f, 2.32f);

            atlas.TexUvLines55 = expected;

            Assert.Equal(expected, atlas.TexUvLines55);
        }

        /// <summary>
        ///     Tests that tex uv lines 56 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines56_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(2.33f, 2.34f, 2.35f, 2.36f);

            atlas.TexUvLines56 = expected;

            Assert.Equal(expected, atlas.TexUvLines56);
        }

        /// <summary>
        ///     Tests that tex uv lines 57 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines57_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(2.37f, 2.38f, 2.39f, 2.40f);

            atlas.TexUvLines57 = expected;

            Assert.Equal(expected, atlas.TexUvLines57);
        }

        /// <summary>
        ///     Tests that tex uv lines 58 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines58_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(2.41f, 2.42f, 2.43f, 2.44f);

            atlas.TexUvLines58 = expected;

            Assert.Equal(expected, atlas.TexUvLines58);
        }

        /// <summary>
        ///     Tests that tex uv lines 59 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines59_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(2.45f, 2.46f, 2.47f, 2.48f);

            atlas.TexUvLines59 = expected;

            Assert.Equal(expected, atlas.TexUvLines59);
        }

        /// <summary>
        ///     Tests that tex uv lines 60 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines60_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(2.49f, 2.50f, 2.51f, 2.52f);

            atlas.TexUvLines60 = expected;

            Assert.Equal(expected, atlas.TexUvLines60);
        }

        /// <summary>
        ///     Tests that tex uv lines 61 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines61_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(2.53f, 2.54f, 2.55f, 2.56f);

            atlas.TexUvLines61 = expected;

            Assert.Equal(expected, atlas.TexUvLines61);
        }

        /// <summary>
        ///     Tests that tex uv lines 62 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines62_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(2.57f, 2.58f, 2.59f, 2.60f);

            atlas.TexUvLines62 = expected;

            Assert.Equal(expected, atlas.TexUvLines62);
        }

        /// <summary>
        ///     Tests that tex uv lines 63 set and get returns correct value
        /// </summary>
        [Fact]
        public void TexUvLines63_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            Vector4F expected = new Vector4F(2.61f, 2.62f, 2.63f, 2.64f);

            atlas.TexUvLines63 = expected;

            Assert.Equal(expected, atlas.TexUvLines63);
        }

        /// <summary>
        ///     Tests that font builder io set and get returns correct value
        /// </summary>
        [Fact]
        public void FontBuilderIo_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            IntPtr expected = new IntPtr(3456);

            atlas.FontBuilderIo = expected;

            Assert.Equal(expected, atlas.FontBuilderIo);
        }

        /// <summary>
        ///     Tests that font builder flags set and get returns correct value
        /// </summary>
        [Fact]
        public void FontBuilderFlags_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            const uint expected = 7u;

            atlas.FontBuilderFlags = expected;

            Assert.Equal(expected, atlas.FontBuilderFlags);
        }

        /// <summary>
        ///     Tests that pack id mouse cursors set and get returns correct value
        /// </summary>
        [Fact]
        public void PackIdMouseCursors_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            const int expected = 42;

            atlas.PackIdMouseCursors = expected;

            Assert.Equal(expected, atlas.PackIdMouseCursors);
        }

        /// <summary>
        ///     Tests that pack id lines set and get returns correct value
        /// </summary>
        [Fact]
        public void PackIdLines_SetAndGet_ReturnsCorrectValue()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            const int expected = 43;

            atlas.PackIdLines = expected;

            Assert.Equal(expected, atlas.PackIdLines);
        }
    }
}
