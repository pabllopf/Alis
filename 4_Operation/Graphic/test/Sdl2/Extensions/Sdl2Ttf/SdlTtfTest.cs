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
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2.Extensions.Sdl2Ttf
{
    /// <summary>
    /// The sdl ttf test class
    /// </summary>
    public class SdlTtfTest
    {
        /// <summary>
        /// Tests that test
        /// </summary>
        [Fact]
        public void Test_Default() => Assert.True(true);

        /// <summary>
        /// Tests that ttf linked version returns non null int ptr
        /// </summary>
        [Fact]
        public void TtfLinkedVersion_Integration_ReturnsNonNullIntPtr()
        {
            int resultSdl = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, resultSdl);
            
            int resultTft = SdlTtf.Init();
            Assert.Equal(0, resultTft);
            
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
            int resultSdl = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, resultSdl);

            int resultTft = SdlTtf.Init();
            Assert.Equal(0, resultTft);
            
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
            int resultSdl = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, resultSdl);

            int resultTft = SdlTtf.Init();
            Assert.Equal(0, resultTft);
            
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
            int resultSdl = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, resultSdl);

            int resultTft = SdlTtf.Init();
            Assert.Equal(0, resultTft);
            
            string file = AssetManager.Find("FontSample.otf");
            const int ptSize = 12; 
            const int newPtSize = 16; 
            const long index = 0;

                // Act & Assert
                try
                {
                    IntPtr font = SdlTtf.OpenFontIndex(file, ptSize, index);
                    int result = SdlTtf.SetFontSize(font, newPtSize);
                    if (result == -1)
                    {
                        throw new Exception("Error setting font size");
                    }
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
            int resultSdl = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, resultSdl);

            int resultTft = SdlTtf.Init();
            Assert.Equal(0, resultTft);
            
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
            int resultSdl = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, resultSdl);

            int resultTft = SdlTtf.Init();
            Assert.Equal(0, resultTft);
            
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
            int resultSdl = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, resultSdl);

            int resultTft = SdlTtf.Init();
            Assert.Equal(0, resultTft);
            
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
            int resultSdl = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, resultSdl);

            int resultTft = SdlTtf.Init();
            Assert.Equal(0, resultTft);
            
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
            int resultSdl = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, resultSdl);

            int resultTft = SdlTtf.Init();
            Assert.Equal(0, resultTft);
            
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
            int resultSdl = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, resultSdl);

            int resultTft = SdlTtf.Init();
            Assert.Equal(0, resultTft);
            
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
            int resultSdl = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, resultSdl);

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
            int resultSdl = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, resultSdl);

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
                int result = SdlTtf.FontAscent(font);
                Assert.Equal(11, result);
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
            int resultSdl = Sdl.Init(Sdl.InitEverything);
            Assert.Equal(0, resultSdl);

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
                int result = SdlTtf.FontAscent(font);
                Assert.Equal(11, result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"No expected exception, but was thrown: {ex} ");
            }
        }
        
        [Fact]
        public void FontLineSkip_Test()
        {
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
        
        [Fact]
        public void GetFontKerning_Test()
        {
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
        
        [Fact]
        public void SetFontKerning_Test()
        {
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
        
        [Fact]
        public void FontFaces_Test()
        {
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
    }
}