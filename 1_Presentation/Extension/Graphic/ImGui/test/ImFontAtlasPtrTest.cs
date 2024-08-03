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
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test
{
    /// <summary>
    /// The im font atlas ptr test class
    /// </summary>
    public class ImFontAtlasPtrTest
    {
         /// <summary>
        /// Tests that native ptr should be initialized
        /// </summary>
        [Fact]
        public void NativePtr_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);
            Assert.NotEqual(IntPtr.Zero, ptr.NativePtr);
        }

        /// <summary>
        /// Tests that flags should be initialized
        /// </summary>
        [Fact]
        public void Flags_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);
            Assert.Equal(atlas.Flags, ptr.Flags);
        }

        /// <summary>
        /// Tests that tex id should be initialized
        /// </summary>
        [Fact]
        public void TexId_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);
            Assert.Equal(atlas.TexId, ptr.TexId);
        }

        /// <summary>
        /// Tests that tex desired width should be initialized
        /// </summary>
        [Fact]
        public void TexDesiredWidth_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);
            Assert.Equal(atlas.TexDesiredWidth, ptr.TexDesiredWidth);
        }

        /// <summary>
        /// Tests that tex glyph padding should be initialized
        /// </summary>
        [Fact]
        public void TexGlyphPadding_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);
            Assert.Equal(atlas.TexGlyphPadding, ptr.TexGlyphPadding);
        }

        /// <summary>
        /// Tests that locked should be initialized
        /// </summary>
        [Fact]
        public void Locked_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.Locked != 0, ptr.Locked);
        }

        /// <summary>
        /// Tests that tex ready should be initialized
        /// </summary>
        [Fact]
        public void TexReady_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.TexReady != 0, ptr.TexReady);
        }

        /// <summary>
        /// Tests that tex pixels use colors should be initialized
        /// </summary>
        [Fact]
        public void TexPixelsUseColors_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.TexPixelsUseColors != 0, ptr.TexPixelsUseColors);
        }

        /// <summary>
        /// Tests that tex pixels alpha 8 should be initialized
        /// </summary>
        [Fact]
        public void TexPixelsAlpha8_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.TexPixelsAlpha8, ptr.TexPixelsAlpha8);
        }

        /// <summary>
        /// Tests that tex pixels rgba 32 should be initialized
        /// </summary>
        [Fact]
        public void TexPixelsRgba32_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.TexPixelsRgba32, ptr.TexPixelsRgba32);
        }

        /// <summary>
        /// Tests that tex width should be initialized
        /// </summary>
        [Fact]
        public void TexWidth_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.TexWidth, ptr.TexWidth);
        }

        /// <summary>
        /// Tests that tex height should be initialized
        /// </summary>
        [Fact]
        public void TexHeight_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.TexHeight, ptr.TexHeight);
        }

        /// <summary>
        /// Tests that tex uv scale should be initialized
        /// </summary>
        [Fact]
        public void TexUvScale_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.TexUvScale, ptr.TexUvScale);
        }

        /// <summary>
        /// Tests that tex uv white pixel should be initialized
        /// </summary>
        [Fact]
        public void TexUvWhitePixel_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.TexUvWhitePixel, ptr.TexUvWhitePixel);
        }

        /// <summary>
        /// Tests that fonts should be initialized
        /// </summary>
        [Fact]
        public void Fonts_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.Fonts.Data, ptr.Fonts.Data);
        }

        /// <summary>
        /// Tests that custom rects should be initialized
        /// </summary>
        [Fact]
        public void CustomRects_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.CustomRects.Data, ptr.CustomRects.Data);
        }

        /// <summary>
        /// Tests that config data should be initialized
        /// </summary>
        [Fact]
        public void ConfigData_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.ConfigData.Data, ptr.ConfigData.Data);
        }

        /// <summary>
        /// Tests that font builder io should be initialized
        /// </summary>
        [Fact]
        public void FontBuilderIo_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.FontBuilderIo, ptr.FontBuilderIo);
        }

        /// <summary>
        /// Tests that font builder flags should be initialized
        /// </summary>
        [Fact]
        public void FontBuilderFlags_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.FontBuilderFlags, ptr.FontBuilderFlags);
        }

        /// <summary>
        /// Tests that pack id mouse cursors should be initialized
        /// </summary>
        [Fact]
        public void PackIdMouseCursors_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.PackIdMouseCursors, ptr.PackIdMouseCursors);
        }

        /// <summary>
        /// Tests that pack id lines should be initialized
        /// </summary>
        [Fact]
        public void PackIdLines_ShouldBeInitialized()
        {
            ImFontAtlas atlas = new ImFontAtlas();
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(atlas);

            Assert.Equal(atlas.PackIdLines, ptr.PackIdLines);
        }
    }
}