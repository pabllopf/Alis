// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTtfCoverageTests.cs
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
    ///     Coverage tests for the sdl ttf wrapper class
    /// </summary>
    public class SdlTtfCoverageTests
    {
        /// <summary>
        ///     Opens the sample font and asserts it is valid
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
        ///     Tests that the font index open overload returns a valid handle
        /// </summary>
        [RequireSdl2TtfFact]
        public void OpenFontIndex_ReturnsValidHandle()
        {
            string fontFile = Sdl2TestAssets.Find("FontSample.otf");
            Assert.NotNull(fontFile);

            int initResult = SdlTtf.Init();
            Assert.Equal(0, initResult);

            IntPtr font = SdlTtf.OpenFontIndex(fontFile, 24, 0);
            Assert.NotEqual(IntPtr.Zero, font);

            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that font style can be set and read back
        /// </summary>
        [RequireSdl2TtfFact]
        public void SetFontStyle_ThenGetFontStyle_ReturnsSameValue()
        {
            IntPtr font = OpenSampleFont();

            SdlTtf.SetFontStyle(font, SdlTtf.TtfStyleBold);
            Assert.Equal(SdlTtf.TtfStyleBold, SdlTtf.GetFontStyle(font));

            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that font outline can be set and read back
        /// </summary>
        [RequireSdl2TtfFact]
        public void SetFontOutline_ThenGetFontOutline_ReturnsSameValue()
        {
            IntPtr font = OpenSampleFont();

            SdlTtf.SetFontOutline(font, 2);
            Assert.Equal(2, SdlTtf.GetFontOutline(font));

            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that font hinting can be set and read back
        /// </summary>
        [RequireSdl2TtfFact]
        public void SetFontHinting_ThenGetFontHinting_ReturnsSameValue()
        {
            IntPtr font = OpenSampleFont();

            SdlTtf.SetFontHinting(font, SdlTtf.TtfHintingLight);
            Assert.Equal(SdlTtf.TtfHintingLight, SdlTtf.GetFontHinting(font));

            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that the font metrics return positive values
        /// </summary>
        [RequireSdl2TtfFact]
        public void FontMetrics_ReturnPositiveValues()
        {
            IntPtr font = OpenSampleFont();

            Assert.True(SdlTtf.FontHeight(font) > 0);
            Assert.True(SdlTtf.FontAscent(font) > 0);
            Assert.True(SdlTtf.FontDescent(font) <= 0);
            Assert.True(SdlTtf.FontLineSkip(font) > 0);

            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that the font faces and face properties are valid
        /// </summary>
        [RequireSdl2TtfFact]
        public void FontFacesAndProperties_AreValid()
        {
            IntPtr font = OpenSampleFont();

            Assert.True(SdlTtf.FontFaces(font).ToInt64() > 0);
            Assert.True(SdlTtf.FontFaceIsFixedWidth(font) == 0 || SdlTtf.FontFaceIsFixedWidth(font) == 1);
            Assert.NotNull(SdlTtf.FontFaceStyleName(font));

            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that kerning can be set and queried
        /// </summary>
        [RequireSdl2TtfFact]
        public void SetFontKerning_ThenGetFontKerning_ReturnsValidFlag()
        {
            IntPtr font = OpenSampleFont();

            SdlTtf.SetFontKerning(font, 1);
            int kerning = SdlTtf.GetFontKerning(font);
            Assert.True(kerning == 0 || kerning == 1);
            Assert.True(SdlTtf.GetFontKerningSize(font, 65, 86) >= 0);
            Assert.True(SdlTtf.GetFontKerningSizeGlyphs(font, 65, 86) >= 0);

            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that the glyph queries return valid results
        /// </summary>
        [RequireSdl2TtfFact]
        public void GlyphQueries_ReturnValidResults()
        {
            IntPtr font = OpenSampleFont();

            Assert.True(SdlTtf.GlyphIsProvided(font, 65) >= 0);

            int minx;
            int max;
            int miny;
            int maxy;
            int advance;
            int result = SdlTtf.GlyphMetrics(font, 65, out minx, out max, out miny, out maxy, out advance);
            Assert.Equal(0, result);
            Assert.True(max >= minx);
            Assert.True(maxy >= miny);

            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that the size queries return positive dimensions
        /// </summary>
        [RequireSdl2TtfFact]
        public void SizeQueries_ReturnPositiveDimensions()
        {
            IntPtr font = OpenSampleFont();

            int w;
            int h;
            Assert.Equal(0, SdlTtf.SizeText(font, "Hi", out w, out h));
            Assert.True(w > 0);
            Assert.True(h > 0);

            Assert.Equal(0, SdlTtf.SizeUtf8(font, "Hi", out w, out h));
            Assert.True(w > 0);

            Assert.Equal(0, SdlTtf.SizeUnicode(font, "Hi", out w, out h));
            Assert.True(w > 0);

            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that the solid render functions return a surface
        /// </summary>
        [RequireSdl2TtfFact]
        public void SolidRenderFunctions_ReturnSurface()
        {
            IntPtr font = OpenSampleFont();

            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderTextSolid(font, "Hi", Color.White));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderUtf8Solid(font, "Hi", Color.White));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderUnicodeSolid(font, "Hi", Color.White));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderGlyphSolid(font, 65, Color.White));

            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that the shaded render functions return a surface
        /// </summary>
        [RequireSdl2TtfFact]
        public void ShadedRenderFunctions_ReturnSurface()
        {
            IntPtr font = OpenSampleFont();

            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderTextShaded(font, "Hi", Color.White, Color.Black));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderUtf8Shaded(font, "Hi", Color.White, Color.Black));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderUnicodeShaded(font, "Hi", Color.White, Color.Black));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderGlyphShaded(font, 65, Color.White, Color.Black));

            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that the blended render functions return a surface
        /// </summary>
        [RequireSdl2TtfFact]
        public void BlendedRenderFunctions_ReturnSurface()
        {
            IntPtr font = OpenSampleFont();

            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderTextBlended(font, "Hi", Color.White));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderUnicodeBlended(font, "Hi", Color.White));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderGlyphBlended(font, 65, Color.White));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderUtf8Blended(font, "Hi", Color.White));

            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that the blended wrapped render functions return a surface
        /// </summary>
        [RequireSdl2TtfFact]
        public void BlendedWrappedRenderFunctions_ReturnSurface()
        {
            IntPtr font = OpenSampleFont();

            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderTextBlendedWrapped(font, "Hi", Color.White, 100));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderUtf8BlendedWrapped(font, "Hi", Color.White, 100));
            Assert.NotEqual(IntPtr.Zero, SdlTtf.RenderUnicodeBlendedWrapped(font, "Hi", Color.White, 100));

            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that the byte swapped unicode operation does not throw
        /// </summary>
        [RequireSdl2TtfFact]
        public void ByteSwappedUnicode_DoesNotThrow()
        {
            int initResult = SdlTtf.Init();
            Assert.Equal(0, initResult);

            SdlTtf.ByteSwappedUnicode(1);

            Assert.True(SdlTtf.WasInit() >= 0);

            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that the error functions round trip a message
        /// </summary>
        [RequireSdl2TtfFact]
        public void SetError_ThenGetError_ContainsMessage()
        {
            int initResult = SdlTtf.Init();
            Assert.Equal(0, initResult);

            SdlTtf.SetError("coverage ttf message");
            Assert.Contains("coverage ttf message", SdlTtf.GetError());

            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that the compiled version is returned
        /// </summary>
        [RequireSdl2TtfFact]
        public void GetVersion_ReturnsCompiledVersion()
        {
            Alis.Extension.Graphic.Sdl2.Structs.Version version = SdlTtf.GetVersion();
            Assert.Equal(2, version.major);
            Assert.Equal(0, version.minor);
            Assert.Equal(16, version.patch);
        }
    }
}