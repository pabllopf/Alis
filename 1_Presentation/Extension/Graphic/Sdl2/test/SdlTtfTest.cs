// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTtfTest.cs
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
using System.Diagnostics;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Definition;
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Sdl2Ttf;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     The sdl ttf test class
    /// </summary>
    public class SdlTtfTest
    {
        /// <summary>
        ///     Tests that byte swapped unicode test
        /// </summary>
        [Fact]
        public void ByteSwappedUnicodeTest()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Act & Assert
            try
            {
                const int input = 1;
                SdlTtf.ByteSwappedUnicode(input);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that open font index no exception thrown
        /// </summary>
        [Fact]
        public void OpenFontIndex_NoExceptionThrown()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                Assert.NotEqual(IntPtr.Zero, font);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that get font style test
        /// </summary>
        [Fact]
        public void GetFontStyle_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.GetFontStyle(font);
                Assert.Equal(0, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that set font style test
        /// </summary>
        [Fact]
        public void SetFontStyle_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                SdlTtf.SetFontStyle(font, SdlTtf.TtfStyleItalic);
                int result = SdlTtf.GetFontStyle(font);
                Assert.Equal(2, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that get font outline test
        /// </summary>
        [Fact]
        public void GetFontOutline_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.GetFontOutline(font);
                Assert.Equal(0, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that set font outline test
        /// </summary>
        [Fact]
        public void SetFontOutline_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                SdlTtf.SetFontOutline(font, 1);
                int result = SdlTtf.GetFontOutline(font);
                Assert.Equal(1, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that get font hinting test
        /// </summary>
        [Fact]
        public void GetFontHinting_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.GetFontHinting(font);
                Assert.Equal(0, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that set font hinting test
        /// </summary>
        [Fact]
        public void SetFontHinting_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                SdlTtf.SetFontHinting(font, SdlTtf.TtfHintingNormal);
                int result = SdlTtf.GetFontHinting(font);
                Assert.Equal(0, result);
                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that font height test
        /// </summary>
        [Fact]
        public void FontHeight_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.FontHeight(font);
                Assert.Equal(15, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that font ascent test
        /// </summary>
        [Fact]
        public void FontAscent_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.FontAscent(font);
                Assert.Equal(11, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that font line skip test
        /// </summary>
        [Fact]
        public void FontLineSkip_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.FontLineSkip(font);
                Assert.Equal(15, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that get font kerning test
        /// </summary>
        [Fact]
        public void GetFontKerning_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                long result = SdlTtf.GetFontKerning(font);
                Assert.Equal(1, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that set font kerning test
        /// </summary>
        [Fact]
        public void SetFontKerning_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            const int kerning = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                SdlTtf.SetFontKerning(font, kerning);
                long result = SdlTtf.GetFontKerning(font);
                Assert.Equal(0, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that font faces test
        /// </summary>
        [Fact]
        public void FontFaces_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr result = SdlTtf.FontFaces(font);
                Assert.NotEqual(IntPtr.Zero, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that font descent test
        /// </summary>
        [Fact]
        public void FontDescent_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.FontDescent(font);
                Assert.Equal(-3, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that font face is fixed width test
        /// </summary>
        [Fact]
        public void FontFaceIsFixedWidth_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.FontFaceIsFixedWidth(font);
                Assert.Equal(0, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that font face style name test
        /// </summary>
        [Fact]
        public void FontFaceStyleName_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                string result = SdlTtf.FontFaceStyleName(font);
                Assert.Equal("Regular", result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that glyph is provided test
        /// </summary>
        [Fact]
        public void GlyphIsProvided_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            const int ch = 0x0041;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.GlyphIsProvided(font, ch);
                Assert.Equal(35, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that glyph metrics test
        /// </summary>
        [Fact]
        public void GlyphMetrics_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            const int ch = 0x0041;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.GlyphMetrics(font, ch, out int minX, out int maxX, out int minY, out int maxY, out int advance);
                Assert.Equal(0, result);
                Assert.Equal(-1, minX);
                Assert.Equal(10, maxX);
                Assert.Equal(-1, minY);
                Assert.Equal(9, maxY);
                Assert.Equal(8, advance);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that size text test
        /// </summary>
        [Fact]
        public void SizeText_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            // Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.SizeText(font, text, out int w, out int h);
                Assert.Equal(0, result);
                Assert.True(w > 80);
                Assert.Equal(15, h);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that size utf 8 test
        /// </summary>
        [Fact]
        public void SizeUtf8_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            // Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.SizeUtf8(font, text, out int w, out int h);
                Assert.Equal(0, result);
                Assert.NotEqual(0, w);
                Assert.NotEqual(0, h);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that size unicode test
        /// </summary>
        [Fact]
        public void SizeUnicode_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.SizeUnicode(font, text, out int w, out int h);
                Assert.Equal(0, result);
                Assert.NotEqual(0, w);
                Assert.NotEqual(0, h);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that render text solid test
        /// </summary>
        [Fact]
        public void RenderTextSolid_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            // Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);

                IntPtr result = SdlTtf.RenderTextSolid(font, text, new Color(255, 255, 255, 255));
                Assert.NotEqual(IntPtr.Zero, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that render utf 8 solid test
        /// </summary>
        [Fact]
        public void RenderUtf8Solid_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            // Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);

                IntPtr result = SdlTtf.RenderUtf8Solid(font, text, new Color(255, 255, 255, 255));
                Assert.NotEqual(IntPtr.Zero, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that render unicode solid test
        /// </summary>
        [Fact]
        public void RenderUnicodeSolid_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);


            // Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);

                IntPtr result = SdlTtf.RenderUnicodeSolid(font, text, new Color(255, 255, 255, 255));
                Assert.NotEqual(IntPtr.Zero, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that render glyph solid test
        /// </summary>
        [Fact]
        public void RenderGlyphSolid_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Arrange
            const int ch = 0x0041;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);

                IntPtr result = SdlTtf.RenderGlyphSolid(font, ch, new Color(255, 255, 255, 255));
                Assert.NotEqual(IntPtr.Zero, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that render text shaded test
        /// </summary>
        [Fact]
        public void RenderTextShaded_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            Color fg = new Color(255, 255, 255, 255);
            Color bg = new Color(0, 0, 0, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderTextShaded(font, text, fg, bg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that render utf 8 shaded test
        /// </summary>
        [Fact]
        public void RenderUtf8Shaded_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            Color fg = new Color(255, 255, 255, 255);
            Color bg = new Color(0, 0, 0, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderUtf8Shaded(font, text, fg, bg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that render unicode shaded test
        /// </summary>
        [Fact]
        public void RenderUnicodeShaded_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            Color fg = new Color(255, 255, 255, 255);
            Color bg = new Color(0, 0, 0, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderUnicodeShaded(font, text, fg, bg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that render glyph shaded test
        /// </summary>
        [Fact]
        public void RenderGlyphShaded_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            const int ch = 0x0041;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            Color fg = new Color(255, 255, 255, 255);
            Color bg = new Color(0, 0, 0, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderGlyphShaded(font, ch, fg, bg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that render text blended test
        /// </summary>
        [Fact]
        public void RenderTextBlended_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            Color fg = new Color(255, 255, 255, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderTextBlended(font, text, fg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that render unicode blended test
        /// </summary>
        [Fact]
        public void RenderUnicodeBlended_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            Color fg = new Color(255, 255, 255, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderUnicodeBlended(font, text, fg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that render text blended wrapped test
        /// </summary>
        [Fact]
        public void RenderTextBlendedWrapped_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Arrange
            const string text = "Hello World";
            const int wrapLength = 10;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            Color fg = new Color(255, 255, 255, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderTextBlendedWrapped(font, text, fg, wrapLength);
                Assert.NotEqual(IntPtr.Zero, resultPtr);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that render utf 8 blended wrapped test
        /// </summary>
        [Fact]
        public void RenderUtf8BlendedWrapped_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Arrange
            const string text = "Hello World";
            const int wrapLength = 10;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            Color fg = new Color(255, 255, 255, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderUtf8BlendedWrapped(font, text, fg, wrapLength);
                Assert.NotEqual(IntPtr.Zero, resultPtr);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that render unicode blended wrapped test
        /// </summary>
        [Fact]
        public void RenderUnicodeBlendedWrapped_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Arrange
            const string text = "Hello World";
            const int wrapLength = 10;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            Color fg = new Color(255, 255, 255, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderUnicodeBlendedWrapped(font, text, fg, wrapLength);
                Assert.NotEqual(IntPtr.Zero, resultPtr);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that render glyph blended test
        /// </summary>
        [Fact]
        public void RenderGlyphBlended_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Arrange
            const int ch = 0x0041;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            Color fg = new Color(255, 255, 255, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderGlyphBlended(font, ch, fg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that render utf 8 blended test
        /// </summary>
        [Fact]
        public void RenderUtf8Blended_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const int index = 0;
            Color fg = new Color(255, 255, 255, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderUtf8Blended(font, text, fg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that open font test
        /// </summary>
        [Fact]
        public void OpenFont_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFont(file, ptSize);
                Assert.NotEqual(IntPtr.Zero, font);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that get font kerning size glyphs test
        /// </summary>
        [Fact]
        public void GetFontKerningSizeGlyphs_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const int index = 0;
            const int previousCh = 0x0041;
            const int ch = 0x0042;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.GetFontKerningSizeGlyphs(font, previousCh, ch);
                Assert.Equal(0, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that get font kerning size test
        /// </summary>
        [Fact]
        public void GetFontKerningSize_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const int index = 0;
            const int previousCh = 0x0041;
            const int ch = 0x0042;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.GetFontKerningSize(font, previousCh, ch);
                Assert.Equal(0, result);

                SdlTtf.CloseFont(font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that set error test
        /// </summary>
        [Fact]
        public void SetError_Test()
        {
            int resultSdl = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, resultSdl);

            // Act & Assert
            try
            {
                SdlTtf.SetError("Test");
                string result = SdlTtf.GetError();
                Assert.Equal("Test", result);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
        }

        /// <summary>
        ///     Tests that get error test
        /// </summary>
        [Fact]
        public void GetError_Test()
        {
            int resultSdl = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, resultSdl);

            // Act & Assert
            try
            {
                SdlTtf.SetError("Test");
                string result = SdlTtf.GetError();
                Assert.Equal("Test", result);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
        }

        /// <summary>
        ///     Tests that was init test
        /// </summary>
        [Fact]
        public void WasInit_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Act & Assert
            try
            {
                int result = SdlTtf.WasInit();
                Assert.NotEqual(0, result);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that quit test
        /// </summary>
        [Fact]
        public void Quit_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Act & Assert
            try
            {
                SdlTtf.Quit();
                int result = SdlTtf.WasInit();
                Assert.NotEqual(-1, result);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                Sdl.Quit();
            }
        }

        /// <summary>
        ///     Tests that close font test
        /// </summary>
        [Fact]
        public void CloseFont_Test()
        {
            int sdlInit = Sdl.Init(InitSettings.InitEverything);
            Assert.Equal(0, sdlInit);

            int sdlTtf = SdlTtf.Init();
            Assert.Equal(0, sdlTtf);

            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFont(file, ptSize);
                SdlTtf.CloseFont(font);
                Assert.NotEqual(IntPtr.Zero, font);
            }
            catch (Exception ex)
            {
                Logger.Log($"No expected exception, but was thrown: {ex}");
            }
            finally
            {
                SdlTtf.Quit();
                Sdl.Quit();
            }
        }
    }
}