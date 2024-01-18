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
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Extensions.Sdl2Ttf;
using Alis.Core.Graphic.Sdl2.Structs;
using Xunit;
using Xunit.Abstractions;

namespace Alis.Core.Graphic.Test.Sdl2.Extensions.Sdl2Ttf
{
    /// <summary>
    /// The sdl ttf test class
    /// </summary>
    public class SdlTtfTest
    {
        private readonly ITestOutputHelper testOutputHelper;

        /// <summary>
        /// Tests that test
        /// </summary>
        [Fact]
        public void Test_Default() => Assert.True(true);
        
        public SdlTtfTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
            int resultSdl = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, resultSdl);

            int resultTft = SdlTtf.Init();

            Assert.Equal(0, resultTft);
        }

        /// <summary>
        /// Tests that ttf linked version returns non null int ptr
        /// </summary>
        [Fact]
        public void TtfLinkedVersion_Integration_ReturnsNonNullIntPtr()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
            try
            {
                IntPtr version = SdlTtf.LinkedVersion();
                Assert.NotEqual(IntPtr.Zero, version);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            }
        }


        /// <summary>
        /// Tests that byte swapped unicode test
        /// </summary>
        [Fact]
        public void ByteSwappedUnicodeTest()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
                
            // Act & Assert
            try
            {
                const int input = 1;
                SdlTtf.ByteSwappedUnicode(input);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            }
        }

        /// <summary>
        /// Tests that open font index no exception thrown
        /// </summary>
        [Fact]
        public void OpenFontIndex_NoExceptionThrown()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr result = SdlTtf.OpenFontIndex(file, ptSize, index);
                Assert.NotEqual(IntPtr.Zero, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that set font size test
        /// </summary>
        /// <exception cref="Exception">Error setting font size</exception>
        [Fact]
        public void SetFontSize_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const int newPtSize = 16;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.SetFontSize(font, newPtSize);
                Assert.Equal(0, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that get font style test
        /// </summary>
        [Fact]
        public void GetFontStyle_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.GetFontStyle(font);
                Assert.Equal(0, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that set font style test
        /// </summary>
        [Fact]
        public void SetFontStyle_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that get font outline test
        /// </summary>
        [Fact]
        public void GetFontOutline_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.GetFontOutline(font);
                Assert.Equal(0, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that set font outline test
        /// </summary>
        [Fact]
        public void SetFontOutline_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that get font hinting test
        /// </summary>
        [Fact]
        public void GetFontHinting_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.GetFontHinting(font);
                Assert.Equal(0, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that set font hinting test
        /// </summary>
        [Fact]
        public void SetFontHinting_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that font height test
        /// </summary>
        [Fact]
        public void FontHeight_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that font ascent test
        /// </summary>
        [Fact]
        public void FontAscent_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that font line skip test
        /// </summary>
        [Fact]
        public void FontLineSkip_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that get font kerning test
        /// </summary>
        [Fact]
        public void GetFontKerning_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that set font kerning test
        /// </summary>
        [Fact]
        public void SetFontKerning_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that font faces test
        /// </summary>
        [Fact]
        public void FontFaces_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that font descent test
        /// </summary>
        [Fact]
        public void FontDescent_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            int resultTft = SdlTtf.Init();

            Assert.Equal(0, resultTft);
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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that font face is fixed width test
        /// </summary>
        [Fact]
        public void FontFaceIsFixedWidth_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that font face style name test
        /// </summary>
        [Fact]
        public void FontFaceStyleName_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that glyph is provided test
        /// </summary>
        [Fact]
        public void GlyphIsProvided_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that glyph is provided 32 test
        /// </summary>
        [Fact]
        public void GlyphIsProvided32_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            const int ch = 0x0041;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.GlyphIsProvided32(font, ch);
                Assert.Equal(35, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that glyph metrics test
        /// </summary>
        [Fact]
        public void GlyphMetrics_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that glyph metrics 32 test
        /// </summary>
        [Fact]
        public void GlyphMetrics32_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            const int ch = 0x0041;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                int result = SdlTtf.GlyphMetrics32(font, ch, out int minX, out int maxX, out int minY, out int maxY, out int advance);
                Assert.Equal(0, result);
                Assert.Equal(-1, minX);
                Assert.Equal(10, maxX);
                Assert.Equal(-1, minY);
                Assert.Equal(9, maxY);
                Assert.Equal(8, advance);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that size text test
        /// </summary>
        [Fact]
        public void SizeText_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

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
                Assert.Equal(85, w);
                Assert.Equal(15, h);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that size utf 8 test
        /// </summary>
        [Fact]
        public void SizeUtf8_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

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
                Assert.Equal(13, w);
                Assert.Equal(130, h);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that size unicode test
        /// </summary>
        [Fact]
        public void SizeUnicode_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that measure text test
        /// </summary>
        [Fact]
        public void MeasureText_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            int resultTft = SdlTtf.Init();

            Assert.Equal(0, resultTft);
            // Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            const int measureWidth = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);

                int result = SdlTtf.MeasureText(font, text, measureWidth, out int extent, out int count);
                Assert.Equal(0, result);
                Assert.Equal(0, extent);
                Assert.Equal(0, count);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that measure utf 8 test
        /// </summary>
        [Fact]
        public void MeasureUtf8_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            int resultTft = SdlTtf.Init();

            Assert.Equal(0, resultTft);
            // Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            const int measureWidth = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);

                int result = SdlTtf.MeasureUtf8(font, text, measureWidth, out int extent, out int count);
                Assert.Equal(0, result);
                Assert.Equal(0, extent);
                Assert.Equal(0, count);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that measure unicode test
        /// </summary>
        [Fact]
        public void MeasureUnicode_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            int resultTft = SdlTtf.Init();

            Assert.Equal(0, resultTft);
            // Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            const int measureWidth = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);

                int result = SdlTtf.MeasureUnicode(font, text, measureWidth, out int extent, out int count);
                Assert.Equal(0, result);
                Assert.Equal(0, extent);
                Assert.Equal(0, count);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that render text solid test
        /// </summary>
        [Fact]
        public void RenderTextSolid_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            int resultTft = SdlTtf.Init();

            Assert.Equal(0, resultTft);
            // Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);

                IntPtr result = SdlTtf.RenderTextSolid(font, text, new SdlColor(255, 255, 255));
                Assert.NotEqual(IntPtr.Zero, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that render utf 8 solid test
        /// </summary>
        [Fact]
        public void RenderUtf8Solid_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            int resultTft = SdlTtf.Init();

            Assert.Equal(0, resultTft);
            // Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);

                IntPtr result = SdlTtf.RenderUtf8Solid(font, text, new SdlColor(255, 255, 255));
                Assert.NotEqual(IntPtr.Zero, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that render unicode solid test
        /// </summary>
        [Fact]
        public void RenderUnicodeSolid_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            int resultTft = SdlTtf.Init();

            Assert.Equal(0, resultTft);
            // Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);

                IntPtr result = SdlTtf.RenderUnicodeSolid(font, text, new SdlColor(255, 255, 255));
                Assert.NotEqual(IntPtr.Zero, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that render text solid wrapped test
        /// </summary>
        [Fact]
        public void RenderTextSolidWrapped_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            // Arrange
            const string text = "Hello World";
            const int wrapLength = 10;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);

                IntPtr result = SdlTtf.RenderTextSolidWrapped(font, text, new SdlColor(255, 255, 255), wrapLength);
                Assert.NotEqual(IntPtr.Zero, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that ttf render utf 8 solid wrapped test
        /// </summary>
        [Fact]
        public void TtfRenderUtf8SolidWrapped_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            int resultTft = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, resultTft);

            // Arrange
            const string text = "Hello World";
            const int wrapLength = 10;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);

                IntPtr result = SdlTtf.RenderUtf8SolidWrapped(font, text, new SdlColor(255, 255, 255), wrapLength);
                Assert.NotEqual(IntPtr.Zero, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that render unicode solid wrapped test
        /// </summary>
        [Fact]
        public void RenderUnicodeSolidWrapped_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            int resultTft = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, resultTft);

            // Arrange
            const string text = "Hello World";
            const int wrapLength = 10;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);

                IntPtr result = SdlTtf.RenderUnicodeSolidWrapped(font, text, new SdlColor(255, 255, 255), wrapLength);
                Assert.NotEqual(IntPtr.Zero, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that render glyph solid test
        /// </summary>
        [Fact]
        public void RenderGlyphSolid_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            // Arrange
            const int ch = 0x0041;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);

                IntPtr result = SdlTtf.RenderGlyphSolid(font, ch, new SdlColor(255, 255, 255));
                Assert.NotEqual(IntPtr.Zero, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that render glyph 32 solid test
        /// </summary>
        [Fact]
        public void RenderGlyph32Solid_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            // Arrange
            const int ch = 0x0041;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);

                IntPtr result = SdlTtf.RenderGlyph32Solid(font, ch, new SdlColor(255, 255, 255));
                Assert.NotEqual(IntPtr.Zero, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            } 
        }

        /// <summary>
        /// Tests that render text shaded test
        /// </summary>
        [Fact]
        public void RenderTextShaded_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");// Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            SdlColor fg = new SdlColor(255, 255, 255);
            SdlColor bg = new SdlColor(0, 0, 0);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderTextShaded(font, text, fg, bg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            } 
        }

        /// <summary>
        /// Tests that render utf 8 shaded test
        /// </summary>
        [Fact]
        public void RenderUtf8Shaded_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");// Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            SdlColor fg = new SdlColor(255, 255, 255);
            SdlColor bg = new SdlColor(0, 0, 0);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderUtf8Shaded(font, text, fg, bg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            } 
        }

        /// <summary>
        /// Tests that render unicode shaded test
        /// </summary>
        [Fact]
        public void RenderUnicodeShaded_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");// Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            SdlColor fg = new SdlColor(255, 255, 255);
            SdlColor bg = new SdlColor(0, 0, 0);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderUnicodeShaded(font, text, fg, bg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            } 
        }

        /// <summary>
        /// Tests that render text shaded wrapped test
        /// </summary>
        [Fact]
        public void RenderTextShadedWrapped_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");// Arrange
            const string text = "Hello World";
            const int wrapLength = 10;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            SdlColor fg = new SdlColor(255, 255, 255);
            SdlColor bg = new SdlColor(0, 0, 0);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderTextShadedWrapped(font, text, fg, bg, wrapLength);
                Assert.NotEqual(IntPtr.Zero, resultPtr);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            }
            
        }

        /// <summary>
        /// Tests that render utf 8 shaded wrapped test
        /// </summary>
        [Fact]
        public void RenderUtf8ShadedWrapped_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");// Arrange
            const string text = "Hello World";
            const int wrapLength = 10;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            SdlColor fg = new SdlColor(255, 255, 255);
            SdlColor bg = new SdlColor(0, 0, 0);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderUtf8ShadedWrapped(font, text, fg, bg, wrapLength);
                Assert.NotEqual(IntPtr.Zero, resultPtr);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            } 
        }

        /// <summary>
        /// Tests that render unicode shaded wrapped test
        /// </summary>
        [Fact]
        public void RenderUnicodeShadedWrapped_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");// Arrange
            const string text = "Hello World";
            const int wrapLength = 10;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            SdlColor fg = new SdlColor(255, 255, 255);
            SdlColor bg = new SdlColor(0, 0, 0);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderUnicodeShadedWrapped(font, text, fg, bg, wrapLength);
                Assert.NotEqual(IntPtr.Zero, resultPtr);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            } 
        }

        /// <summary>
        /// Tests that render glyph shaded test
        /// </summary>
        [Fact]
        public void RenderGlyphShaded_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");// Arrange
            const int ch = 0x0041;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            SdlColor fg = new SdlColor(255, 255, 255);
            SdlColor bg = new SdlColor(0, 0, 0);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderGlyphShaded(font, ch, fg, bg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            } 
        }

        /// <summary>
        /// Tests that render glyph 32 shaded test
        /// </summary>
        [Fact]
        public void RenderGlyph32Shaded_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");// Arrange
            const int ch = 0x0041;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            SdlColor fg = new SdlColor(255, 255, 255);
            SdlColor bg = new SdlColor(0, 0, 0);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderGlyph32Shaded(font, ch, fg, bg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            } 
        }

        /// <summary>
        /// Tests that render text blended test
        /// </summary>
        [Fact]
        public void RenderTextBlended_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");// Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            SdlColor fg = new SdlColor(255, 255, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderTextBlended(font, text, fg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            } 
        }

        /// <summary>
        /// Tests that render unicode blended test
        /// </summary>
        [Fact]
        public void RenderUnicodeBlended_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            // Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            SdlColor fg = new SdlColor(255, 255, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderUnicodeBlended(font, text, fg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            } 
        }

        /// <summary>
        /// Tests that render text blended wrapped test
        /// </summary>
        [Fact]
        public void RenderTextBlendedWrapped_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
            // Arrange
            const string text = "Hello World";
            const int wrapLength = 10;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            SdlColor fg = new SdlColor(255, 255, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderTextBlendedWrapped(font, text, fg, wrapLength);
                Assert.NotEqual(IntPtr.Zero, resultPtr);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            } 
        }

        /// <summary>
        /// Tests that render utf 8 blended wrapped test
        /// </summary>
        [Fact]
        public void RenderUtf8BlendedWrapped_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
            // Arrange
            const string text = "Hello World";
            const int wrapLength = 10;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            SdlColor fg = new SdlColor(255, 255, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderUtf8BlendedWrapped(font, text, fg, wrapLength);
                Assert.NotEqual(IntPtr.Zero, resultPtr);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            } 
        }

        /// <summary>
        /// Tests that render unicode blended wrapped test
        /// </summary>
        [Fact]
        public void RenderUnicodeBlendedWrapped_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
            // Arrange
            const string text = "Hello World";
            const int wrapLength = 10;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            SdlColor fg = new SdlColor(255, 255, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderUnicodeBlendedWrapped(font, text, fg, wrapLength);
                Assert.NotEqual(IntPtr.Zero, resultPtr);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            } 
        }

        /// <summary>
        /// Tests that render glyph blended test
        /// </summary>
        [Fact]
        public void RenderGlyphBlended_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            // Arrange
            const int ch = 0x0041;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            SdlColor fg = new SdlColor(255, 255, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderGlyphBlended(font, ch, fg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that render glyph 32 blended test
        /// </summary>
        [Fact]
        public void RenderGlyph32Blended_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
            // Arrange
            const int ch = 0x0041;
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const long index = 0;
            SdlColor fg = new SdlColor(255, 255, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                IntPtr resultPtr = SdlTtf.RenderGlyph32Blended(font, ch, fg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that set direction test
        /// </summary>
        [Fact]
        public void SetDirection_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
            // Arrange
            const int direction = 1;

            // Act & Assert
            try
            {
                int resultDirection = SdlTtf.SetDirection(direction);
                Assert.Equal(0, resultDirection);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that render utf 8 blended test
        /// </summary>
        [Fact]
        public void RenderUtf8Blended_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            int result = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, result);

            // Arrange
            const string text = "Hello World";
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;
            const int index = 0;
            SdlColor fg = new SdlColor(255, 255, 255);

            // Act & Assert
            try
            {
                IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);

                IntPtr resultPtr = SdlTtf.RenderUtf8Blended(font, text, fg);
                Assert.NotEqual(IntPtr.Zero, resultPtr);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex}");
            } 
        }

        /// <summary>
        /// Tests that get ttf version test
        /// </summary>
        [Fact]
        public void GetTtfVersion_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
            // Act & Assert
            try
            {
                SdlVersion version = SdlTtf.GetTtfVersion();
                Assert.Equal(2, version.major);
                Assert.Equal(0, version.minor);
                Assert.Equal(16, version.patch);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that set error test
        /// </summary>
        [Fact]
        public void SetError_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
            // Act & Assert
            try
            {
                SdlTtf.SetError("Test");
                string result = SdlTtf.GetError();
                Assert.Equal("Test", result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }
        
        /// <summary>
        /// Tests that get error test
        /// </summary>
        [Fact]
        public void GetError_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
            // Act & Assert
            try
            {
                SdlTtf.SetError("Test");
                string result = SdlTtf.GetError();
                Assert.Equal("Test", result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that open font test
        /// </summary>
        [Fact]
        public void OpenFont_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
            // Arrange
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12;

            // Act & Assert
            try
            {
                IntPtr result = SdlTtf.OpenFont(file, ptSize);
                Assert.NotEqual(IntPtr.Zero, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that get font kerning size glyphs 32 test
        /// </summary>
        [Fact]
        public void GetFontKerningSizeGlyphs32_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
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
                int result = SdlTtf.GetFontKerningSizeGlyphs32(font, previousCh, ch);
                Assert.Equal(0, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that get font kerning size glyphs test
        /// </summary>
        [Fact]
        public void GetFontKerningSizeGlyphs_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that get font kerning size test
        /// </summary>
        [Fact]
        public void GetFontKerningSize_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
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
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that was init test
        /// </summary>
        [Fact]
        public void WasInit_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
            int resultTft = SdlTtf.Init();
            Assert.Equal(0, resultTft);
            
            // Act & Assert
            try
            {
                int result = SdlTtf.WasInit();
                Assert.NotEqual(0, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            }
            
        }

        /// <summary>
        /// Tests that quit test
        /// </summary>
        [Fact]
        public void Quit_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
            // Act & Assert
            try
            {
                SdlTtf.Quit();
                int result = SdlTtf.WasInit();
                Assert.NotEqual(0, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that close font test
        /// </summary>
        [Fact]
        public void CloseFont_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            
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
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            } 
        }

        /// <summary>
        /// Tests that set script test
        /// </summary>
        [Fact]
        public void SetScript_Test()
        {
            testOutputHelper.WriteLine($"Method name {System.Reflection.MethodBase.GetCurrentMethod()?.Name}");

            // Arrange
            const int script = 1;

            // Act & Assert
            try
            {
                int result = SdlTtf.SetScript(script);
                Assert.Equal(0, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            }
            
        }
    }
}