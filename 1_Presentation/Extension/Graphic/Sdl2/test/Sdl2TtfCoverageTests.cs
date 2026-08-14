// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl2TtfCoverageTests.cs
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
    ///     Coverage tests for the sdl ttf font library
    /// </summary>
    public class Sdl2TtfCoverageTests
    {
        /// <summary>
        ///     Tests that ttf can be initialized and queried
        /// </summary>
        [RequireSdl2TtfFact]
        public void Init_AndQuery_Work()
        {
            int initResult = SdlTtf.Init();
            Assert.Equal(0, initResult);
            int wasInit = SdlTtf.WasInit();
            Assert.NotEqual(0, wasInit);
            SdlTtf.ByteSwappedUnicode(0);
            SdlTtf.SetError("coverage ttf");
            string error = SdlTtf.GetError();
            Assert.Contains("coverage ttf", error);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that a font can be opened and measured from the assets folder
        /// </summary>
        [RequireSdl2TtfFact]
        public void FontMetrics_Work()
        {
            string file = Sdl2TestAssets.Find("FontSample.otf");
            if (file == null)
            {
                return;
            }
            Assert.Equal(0, SdlTtf.Init());
            IntPtr font = SdlTtf.OpenFont(file, 28);
            Assert.NotEqual(IntPtr.Zero, font);
            SdlTtf.FontHeight(font);
            SdlTtf.FontAscent(font);
            SdlTtf.FontDescent(font);
            SdlTtf.FontLineSkip(font);
            SdlTtf.FontFaces(font);
            SdlTtf.FontFaceIsFixedWidth(font);
            SdlTtf.FontFaceStyleName(font);
            SdlTtf.GlyphIsProvided(font, (ushort) 'A');
            int minx;
            int max;
            int miny;
            int maxy;
            int advance;
            SdlTtf.GlyphMetrics(font, (ushort) 'A', out minx, out max, out miny, out maxy, out advance);
            int w;
            int h;
            SdlTtf.SizeText(font, "Alis", out w, out h);
            SdlTtf.SizeUtf8(font, "Alis", out w, out h);
            SdlTtf.SizeUnicode(font, "Alis", out w, out h);
            SdlTtf.GetFontKerningSize(font, 0, 1);
            SdlTtf.GetFontKerningSizeGlyphs(font, 0, 1);
            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that font style, outline, hinting and kerning setters work
        /// </summary>
        [RequireSdl2TtfFact]
        public void FontAttributes_Work()
        {
            string file = Sdl2TestAssets.Find("FontSample.otf");
            if (file == null)
            {
                return;
            }
            Assert.Equal(0, SdlTtf.Init());
            IntPtr font = SdlTtf.OpenFont(file, 28);
            Assert.NotEqual(IntPtr.Zero, font);
            SdlTtf.GetFontStyle(font);
            SdlTtf.SetFontStyle(font, SdlTtf.TtfStyleBold | SdlTtf.TtfStyleItalic);
            SdlTtf.GetFontOutline(font);
            SdlTtf.SetFontOutline(font, 1);
            SdlTtf.GetFontHinting(font);
            SdlTtf.SetFontHinting(font, SdlTtf.TtfHintingNormal);
            SdlTtf.GetFontKerning(font);
            SdlTtf.SetFontKerning(font, 1);
            SdlTtf.OpenFontIndex(file, 28, 0);
            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }

        /// <summary>
        ///     Tests that text can be rendered to surfaces in every mode
        /// </summary>
        [RequireSdl2TtfFact]
        public void RenderText_AllModes_Work()
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
            SdlTtf.RenderTextSolid(font, "Alis", fg);
            SdlTtf.RenderUtf8Solid(font, "Alis", fg);
            SdlTtf.RenderUnicodeSolid(font, "Alis", fg);
            SdlTtf.RenderGlyphSolid(font, (ushort) 'A', fg);
            SdlTtf.RenderTextShaded(font, "Alis", fg, bg);
            SdlTtf.RenderUtf8Shaded(font, "Alis", fg, bg);
            SdlTtf.RenderUnicodeShaded(font, "Alis", fg, bg);
            SdlTtf.RenderGlyphShaded(font, (ushort) 'A', fg, bg);
            SdlTtf.RenderTextBlended(font, "Alis", fg);
            SdlTtf.RenderUtf8Blended(font, "Alis", fg);
            SdlTtf.RenderUnicodeBlended(font, "Alis", fg);
            SdlTtf.RenderTextBlendedWrapped(font, "Alis", fg, 100);
            SdlTtf.RenderUtf8BlendedWrapped(font, "Alis", fg, 100);
            SdlTtf.RenderUnicodeBlendedWrapped(font, "Alis", fg, 100);
            SdlTtf.RenderGlyphBlended(font, (ushort) 'A', fg);
            SdlTtf.CloseFont(font);
            SdlTtf.Quit();
        }
    }
}
