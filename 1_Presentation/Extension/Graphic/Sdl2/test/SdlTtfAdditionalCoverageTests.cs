// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTtfAdditionalCoverageTests.cs
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
    ///     Additional coverage tests exercising the public SdlTtf wrapper surface
    /// </summary>
    public class SdlTtfAdditionalCoverageTests
    {
        /// <summary>
        ///     Opens the sample font with sdl ttf initialized
        /// </summary>
        /// <returns>The font handle</returns>
        private static IntPtr OpenSampleFont()
        {
            string fontFile = Sdl2TestAssets.Find("FontSample.otf");
            Assert.NotNull(fontFile);

            int initResult = SdlTtf.Init();
            Assert.Equal(0, initResult);

            IntPtr font = SdlTtf.OpenFont(fontFile, 24);
            Assert.NotEqual(IntPtr.Zero, font);

            return font;
        }

        /// <summary>
        ///     Tests that the font lifecycle init open style query and close works
        /// </summary>
        [RequireSdl2TtfFact]
        public void Init_OpenFont_StyleQueries_AndClose_Work()
        {
            IntPtr font = OpenSampleFont();

            int style = SdlTtf.GetFontStyle(font);
            Assert.Equal(SdlTtf.TtfStyleNormal, style);

            SdlTtf.SetFontStyle(font, SdlTtf.TtfStyleBold | SdlTtf.TtfStyleItalic);
            Assert.Equal(SdlTtf.TtfStyleBold | SdlTtf.TtfStyleItalic, SdlTtf.GetFontStyle(font));

            SdlTtf.SetFontStyle(font, SdlTtf.TtfStyleNormal);
            SdlTtf.CloseFont(font);
        }

        /// <summary>
        ///     Tests that font outline is queried and mutated correctly
        /// </summary>
        [RequireSdl2TtfFact]
        public void GetAndSetFontOutline_RoundTrip()
        {
            IntPtr font = OpenSampleFont();

            int originalOutline = SdlTtf.GetFontOutline(font);
            Assert.Equal(0, originalOutline);

            SdlTtf.SetFontOutline(font, 1);
            Assert.Equal(1, SdlTtf.GetFontOutline(font));

            SdlTtf.SetFontOutline(font, 0);
            SdlTtf.CloseFont(font);
        }

        /// <summary>
        ///     Tests that font hinting is queried and mutated correctly
        /// </summary>
        [RequireSdl2TtfFact]
        public void GetAndSetFontHinting_RoundTrip()
        {
            IntPtr font = OpenSampleFont();

            int hinting = SdlTtf.GetFontHinting(font);
            Assert.Equal(SdlTtf.TtfHintingNormal, hinting);

            SdlTtf.SetFontHinting(font, SdlTtf.TtfHintingLight);
            Assert.Equal(SdlTtf.TtfHintingLight, SdlTtf.GetFontHinting(font));

            SdlTtf.SetFontHinting(font, SdlTtf.TtfHintingNormal);
            SdlTtf.CloseFont(font);
        }

        /// <summary>
        ///     Tests that font metric accessors return positive values for an open font
        /// </summary>
        [RequireSdl2TtfFact]
        public void FontMetrics_ReturnPositiveValues()
        {
            IntPtr font = OpenSampleFont();

            Assert.True(SdlTtf.FontHeight(font) > 0);
            Assert.True(SdlTtf.FontAscent(font) > 0);
            Assert.True(SdlTtf.FontDescent(font) < 0);
            Assert.True(SdlTtf.FontLineSkip(font) > 0);

            SdlTtf.CloseFont(font);
        }

        /// <summary>
        ///     Tests that kerning can be toggled and face properties are reported
        /// </summary>
        [RequireSdl2TtfFact]
        public void FontFace_AndKerning_Work()
        {
            IntPtr font = OpenSampleFont();

            SdlTtf.SetFontKerning(font, 1);
            Assert.Equal(1, SdlTtf.GetFontKerning(font));

            Assert.False(IntPtr.Zero.Equals(SdlTtf.FontFaces(font)));
            Assert.Equal(0, SdlTtf.FontFaceIsFixedWidth(font));
            Assert.False(string.IsNullOrEmpty(SdlTtf.FontFaceStyleName(font)));

            SdlTtf.CloseFont(font);
        }

        /// <summary>
        ///     Tests that glyph queries succeed for the provided glyph A
        /// </summary>
        [RequireSdl2TtfFact]
        public void GlyphIsProvided_AndGlyphMetrics_Work()
        {
            IntPtr font = OpenSampleFont();

            Assert.NotEqual(0, SdlTtf.GlyphIsProvided(font, (ushort) 'A'));

            int result = SdlTtf.GlyphMetrics(font, (ushort) 'A', out int minx, out int max, out int miny, out int maxy, out int advance);
            Assert.Equal(0, result);

            SdlTtf.CloseFont(font);
        }

        /// <summary>
        ///     Tests that text sizing reports positive dimensions
        /// </summary>
        [RequireSdl2TtfFact]
        public void SizeText_SizeUtf8_AndSizeUnicode_Work()
        {
            IntPtr font = OpenSampleFont();

            int textResult = SdlTtf.SizeText(font, "Hello", out int w, out int h);
            Assert.Equal(0, textResult);
            Assert.True(w > 0);
            Assert.True(h > 0);

            int utf8Result = SdlTtf.SizeUtf8(font, "Hello", out int w8, out int h8);
            Assert.Equal(0, utf8Result);
            Assert.True(w8 > 0);
            Assert.True(h8 > 0);

            int unicodeResult = SdlTtf.SizeUnicode(font, "Hello", out int wU, out int hU);
            Assert.Equal(0, unicodeResult);
            Assert.True(wU > 0);
            Assert.True(hU > 0);

            SdlTtf.CloseFont(font);
        }

        /// <summary>
        ///     Tests that solid rendering produces valid surfaces
        /// </summary>
        [RequireSdl2TtfFact]
        public void RenderSolid_Variants_ProduceSurfaces()
        {
            IntPtr font = OpenSampleFont();
            Color white = Color.White;

            IntPtr text = SdlTtf.RenderTextSolid(font, "Alis", white);
            Assert.NotEqual(IntPtr.Zero, text);

            IntPtr utf8 = SdlTtf.RenderUtf8Solid(font, "Alis", white);
            Assert.NotEqual(IntPtr.Zero, utf8);

            IntPtr unicode = SdlTtf.RenderUnicodeSolid(font, "Alis", white);
            Assert.NotEqual(IntPtr.Zero, unicode);

            IntPtr glyph = SdlTtf.RenderGlyphSolid(font, (ushort) 'A', white);
            Assert.NotEqual(IntPtr.Zero, glyph);

            SdlTtf.CloseFont(font);
        }

        /// <summary>
        ///     Tests that shaded rendering produces valid surfaces
        /// </summary>
        [RequireSdl2TtfFact]
        public void RenderShaded_Variants_ProduceSurfaces()
        {
            IntPtr font = OpenSampleFont();
            Color white = Color.White;
            Color black = Color.Black;

            IntPtr text = SdlTtf.RenderTextShaded(font, "Alis", white, black);
            Assert.NotEqual(IntPtr.Zero, text);

            IntPtr utf8 = SdlTtf.RenderUtf8Shaded(font, "Alis", white, black);
            Assert.NotEqual(IntPtr.Zero, utf8);

            IntPtr unicode = SdlTtf.RenderUnicodeShaded(font, "Alis", white, black);
            Assert.NotEqual(IntPtr.Zero, unicode);

            IntPtr glyph = SdlTtf.RenderGlyphShaded(font, (ushort) 'A', white, black);
            Assert.NotEqual(IntPtr.Zero, glyph);

            SdlTtf.CloseFont(font);
        }

        /// <summary>
        ///     Tests that blended rendering produces valid surfaces
        /// </summary>
        [RequireSdl2TtfFact]
        public void RenderBlended_Variants_ProduceSurfaces()
        {
            IntPtr font = OpenSampleFont();
            Color white = Color.White;

            IntPtr text = SdlTtf.RenderTextBlended(font, "Alis", white);
            Assert.NotEqual(IntPtr.Zero, text);

            IntPtr utf8 = SdlTtf.RenderUtf8Blended(font, "Alis", white);
            Assert.NotEqual(IntPtr.Zero, utf8);

            IntPtr unicode = SdlTtf.RenderUnicodeBlended(font, "Alis", white);
            Assert.NotEqual(IntPtr.Zero, unicode);

            IntPtr glyph = SdlTtf.RenderGlyphBlended(font, (ushort) 'A', white);
            Assert.NotEqual(IntPtr.Zero, glyph);

            IntPtr wrapped = SdlTtf.RenderTextBlendedWrapped(font, "Alis framework", white, 200);
            Assert.NotEqual(IntPtr.Zero, wrapped);

            IntPtr utf8Wrapped = SdlTtf.RenderUtf8BlendedWrapped(font, "Alis framework", white, 200);
            Assert.NotEqual(IntPtr.Zero, utf8Wrapped);

            IntPtr unicodeWrapped = SdlTtf.RenderUnicodeBlendedWrapped(font, "Alis framework", white, 200);
            Assert.NotEqual(IntPtr.Zero, unicodeWrapped);

            SdlTtf.CloseFont(font);
        }

        /// <summary>
        ///     Tests that kerning size queries do not throw and error helpers round trip
        /// </summary>
        [RequireSdl2TtfFact]
        public void ErrorHelpers_AndKerningSize_DoNotThrow()
        {
            SdlTtf.SetError("coverage ttf error");
            Assert.Contains("coverage ttf error", SdlTtf.GetError());

            SdlTtf.GetFontKerningSize(IntPtr.Zero, 0, 0);
            SdlTtf.GetFontKerningSizeGlyphs(IntPtr.Zero, (ushort) 'A', (ushort) 'B');
        }

        /// <summary>
        ///     Tests that byte swapped unicode was init open font index and quit lifecycle work
        /// </summary>
        [RequireSdl2TtfFact]
        public void ByteSwappedUnicode_WasInit_OpenFontIndex_AndQuit_Work()
        {
            SdlTtf.ByteSwappedUnicode(1);
            Assert.NotEqual(0, SdlTtf.WasInit());

            string fontFile = Sdl2TestAssets.Find("FontSample.otf");
            Assert.NotNull(fontFile);

            IntPtr font = SdlTtf.OpenFontIndex(fontFile, 24, 0);
            Assert.NotEqual(IntPtr.Zero, font);
            SdlTtf.CloseFont(font);

            SdlTtf.Quit();
        }
    }
}
