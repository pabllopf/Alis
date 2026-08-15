// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl2TtfBehaviorTests.cs
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
using Alis.Core.Aspect.Math.Definition;
using Alis.Extension.Graphic.Sdl2.Sdl2Ttf;
using Alis.Extension.Graphic.Sdl2.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Behavior tests for the sdl ttf wrapper asserting observable return values
    /// </summary>
    public class Sdl2TtfBehaviorTests
    {
        /// <summary>
        ///     Tests that init is idempotent and was init reflects the counter state
        /// </summary>
        [RequireSdl2TtfFact]
        public void Init_IsIdempotent_AndWasInitReflectsState()
        {
            Assert.Equal(0, SdlTtf.Init());
            Assert.Equal(0, SdlTtf.Init());
            Assert.NotEqual(0, SdlTtf.WasInit());
            SdlTtf.Quit();
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that opening a missing font file returns zero and sets the error string
        /// </summary>
        [RequireSdl2TtfFact]
        public void OpenFont_MissingFile_ReturnsZeroAndSetsError()
        {
            Assert.Equal(0, SdlTtf.Init());
            IntPtr font = SdlTtf.OpenFont("/nonexistent/font.ttf", 28);
            Assert.Equal(IntPtr.Zero, font);
            Assert.False(string.IsNullOrEmpty(SdlTtf.GetError()));
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that opening a valid font file returns a usable font with positive metrics
        /// </summary>
        [RequireSdl2TtfFact]
        public void OpenFont_ValidFile_ReturnsUsableFont()
        {
            string file = Sdl2TestAssets.Find("FontSample.otf");
            if (file == null)
            {
                return;
            }
            Assert.Equal(0, SdlTtf.Init());
            IntPtr font = SdlTtf.OpenFont(file, 28);
            Assert.NotEqual(IntPtr.Zero, font);
            Assert.True(SdlTtf.FontHeight(font) > 0);
            Assert.True(SdlTtf.FontAscent(font) > 0);
            Assert.True(SdlTtf.FontDescent(font) <= 0);
            Assert.True(SdlTtf.FontLineSkip(font) > 0);
            Assert.True(SdlTtf.FontFaces(font).ToInt64() >= 1);
            int fixedWidth = SdlTtf.FontFaceIsFixedWidth(font);
            Assert.True(fixedWidth == 0 || fixedWidth == 1);
            string styleName = SdlTtf.FontFaceStyleName(font);
            Assert.False(string.IsNullOrEmpty(styleName));
            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that glyph and text measurement return positive dimensions
        /// </summary>
        [RequireSdl2TtfFact]
        public void SizeAndGlyphMetrics_ReturnPositiveDimensions()
        {
            string file = Sdl2TestAssets.Find("FontSample.otf");
            if (file == null)
            {
                return;
            }
            Assert.Equal(0, SdlTtf.Init());
            IntPtr font = SdlTtf.OpenFont(file, 28);
            Assert.NotEqual(IntPtr.Zero, font);
            Assert.NotEqual(0, SdlTtf.GlyphIsProvided(font, (ushort) 'A'));
            int minx;
            int max;
            int miny;
            int maxy;
            int advance;
            Assert.Equal(0, SdlTtf.GlyphMetrics(font, (ushort) 'A', out minx, out max, out miny, out maxy, out advance));
            Assert.True(advance > 0);
            int w;
            int h;
            Assert.Equal(0, SdlTtf.SizeText(font, "Alis", out w, out h));
            Assert.True(w > 0);
            Assert.True(h > 0);
            Assert.Equal(0, SdlTtf.SizeUtf8(font, "Alis", out w, out h));
            Assert.True(w > 0);
            Assert.True(h > 0);
            Assert.Equal(0, SdlTtf.SizeUnicode(font, "Alis", out w, out h));
            Assert.True(w > 0);
            Assert.True(h > 0);
            SdlTtf.GetFontKerningSize(font, (int) 'A', (int) 'V');
            SdlTtf.GetFontKerningSizeGlyphs(font, (ushort) 'A', (ushort) 'V');
            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that font style, outline, hinting and kerning round trip through the wrappers
        /// </summary>
        [RequireSdl2TtfFact]
        public void FontAttributes_RoundTrip()
        {
            string file = Sdl2TestAssets.Find("FontSample.otf");
            if (file == null)
            {
                return;
            }
            Assert.Equal(0, SdlTtf.Init());
            IntPtr font = SdlTtf.OpenFont(file, 28);
            Assert.NotEqual(IntPtr.Zero, font);
            Assert.Equal(SdlTtf.TtfStyleNormal, SdlTtf.GetFontStyle(font));
            SdlTtf.SetFontStyle(font, SdlTtf.TtfStyleBold | SdlTtf.TtfStyleItalic);
            int style = SdlTtf.GetFontStyle(font);
            Assert.Equal(0, style & ~(SdlTtf.TtfStyleBold | SdlTtf.TtfStyleItalic));
            Assert.NotEqual(0, style & SdlTtf.TtfStyleBold);
            Assert.NotEqual(0, style & SdlTtf.TtfStyleItalic);
            SdlTtf.SetFontOutline(font, 2);
            Assert.Equal(2, SdlTtf.GetFontOutline(font));
            SdlTtf.SetFontHinting(font, SdlTtf.TtfHintingMono);
            Assert.Equal(SdlTtf.TtfHintingMono, SdlTtf.GetFontHinting(font));
            SdlTtf.SetFontKerning(font, 0);
            Assert.Equal(0, SdlTtf.GetFontKerning(font));
            SdlTtf.SetFontKerning(font, 1);
            Assert.Equal(1, SdlTtf.GetFontKerning(font));
            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that opening a font by index returns a usable font
        /// </summary>
        [RequireSdl2TtfFact]
        public void OpenFontIndex_ValidIndex_ReturnsNonNull()
        {
            string file = Sdl2TestAssets.Find("FontSample.otf");
            if (file == null)
            {
                return;
            }
            Assert.Equal(0, SdlTtf.Init());
            IntPtr font = SdlTtf.OpenFontIndex(file, 28, 0);
            Assert.NotEqual(IntPtr.Zero, font);
            Assert.True(SdlTtf.FontHeight(font) > 0);
            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that every render mode produces a non null surface pointer
        /// </summary>
        [RequireSdl2TtfFact]
        public void RenderModes_ReturnNonNullSurfaces()
        {
            string file = Sdl2TestAssets.Find("FontSample.otf");
            if (file == null)
            {
                return;
            }
            Assert.Equal(0, SdlTtf.Init());
            IntPtr font = SdlTtf.OpenFont(file, 28);
            Assert.NotEqual(IntPtr.Zero, font);
            Color fg = new Color(255, 255, 255, 255);
            Color bg = new Color(0, 0, 0, 255);
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderTextSolid(font, "Alis", fg));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderUtf8Solid(font, "Alis", fg));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderUnicodeSolid(font, "Alis", fg));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderGlyphSolid(font, (ushort) 'A', fg));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderTextShaded(font, "Alis", fg, bg));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderUtf8Shaded(font, "Alis", fg, bg));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderUnicodeShaded(font, "Alis", fg, bg));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderGlyphShaded(font, (ushort) 'A', fg, bg));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderTextBlended(font, "Alis", fg));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderUtf8Blended(font, "Alis", fg));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderUnicodeBlended(font, "Alis", fg));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderTextBlendedWrapped(font, "Alis", fg, 100));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderUtf8BlendedWrapped(font, "Alis", fg, 100));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderUnicodeBlendedWrapped(font, "Alis", fg, 100));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderGlyphBlended(font, (ushort) 'A', fg));
            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }
    }
}
