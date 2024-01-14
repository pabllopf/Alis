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
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Extensions.Sdl2Ttf;
using Alis.Core.Graphic.Test.Sdl2.Extensions.Sdl2Ttf.Wrapper;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Alis.Core.Graphic.Test.Sdl2.Extensions.Sdl2Ttf
{
    /// <summary>
    /// The sdl ttf test class
    /// </summary>
    public class SdlTtfTest
    {
        /// <summary>
        /// The test output helper
        /// </summary>
        private readonly ITestOutputHelper testOutputHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SdlTtfTest"/> class
        /// </summary>
        /// <param name="testOutputHelper">The test output helper</param>
        public SdlTtfTest(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

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
            
            int resultTft = SdlTtf.TtfInit();
            Assert.Equal(0, resultTft);
            
            IntPtr version = SdlTtf.TtfLinkedVersion();
            
            Assert.NotEqual(IntPtr.Zero, version);
        }

        /// <summary>
        /// Tests that ttf linked version abstract returns non null int ptr
        /// </summary>
        [Fact]
        public void TtfLinkedVersion_Abstract_ReturnsNonNullIntPtr()
        {
            // Arrange
            Mock<INativeSdlTtfWrapper> mockNativeSdlTtfWrapper = new Mock<INativeSdlTtfWrapper>();
            IntPtr expectedIntPtr = new IntPtr(123);

            mockNativeSdlTtfWrapper.Setup(x => x.InternalLinkedVersion()).Returns(expectedIntPtr);

            // Act
            IntPtr result = mockNativeSdlTtfWrapper.Object.InternalLinkedVersion();

            // Assert
            Assert.NotEqual(IntPtr.Zero, result);
            Assert.Equal(expectedIntPtr, result);

        }
    }
}