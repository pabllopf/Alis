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
        public void Test()
        {
            Assert.True(true);
        }
        
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

    }
}