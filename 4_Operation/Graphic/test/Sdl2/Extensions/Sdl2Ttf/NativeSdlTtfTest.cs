// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: DefaultTest.cs
// 
//  Author: Pablo Perdomo Falcón
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
using System.Reflection;
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Graphic.Properties;
using Alis.Core.Graphic.Sdl2.Extensions.Sdl2Ttf;
using Alis.Core.Graphic.Sdl2.Structs;
using Moq;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2.Extensions.Sdl2Ttf
{
    /// <summary>
    /// The native sdl ttf test class
    /// </summary>
    public class NativeSdlTtfTest
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
        /// Tests that internal get ttf version returns correct version
        /// </summary>
        [Fact]
        public void InternalGetTtfVersion_ReturnsCorrectVersion()
        {
            // Act
            SdlVersion result = NativeSdlTtf.InternalGetTtfVersion();

            // Assert
            Assert.Equal(2, result.major);
            Assert.Equal(0, result.minor);
            Assert.Equal(16, result.patch);
        }
        
        /// <summary>
        /// Tests that native sdl ttf initialization calls extract embedded dlls
        /// </summary>
        [Fact]
        public void NativeSdlTtf_Initialization_CallsExtractEmbeddedDlls()
        {
            // Arrange
            Mock<IEmbeddedDllClass> mockEmbeddedDllClass = new Mock<IEmbeddedDllClass>();

            // Act
            NativeSdlTtf.Initialize(mockEmbeddedDllClass.Object);

            // Assert
            mockEmbeddedDllClass.Verify(
                x => x
                    .ExtractEmbeddedDlls(
                        "sdl2_ttf", 
                        Sdl2Dlls.GlSdlTtfDllBytes, 
                        Assembly.GetAssembly(typeof(Sdl2Dlls))),
                Times.Once
            );
        }
        
        /// <summary>
        /// Tests that initialize sets embedded dll
        /// </summary>
        [Fact]
        public void Initialize_SetsEmbeddedDllClass()
        {
            // Arrange
            Mock<IEmbeddedDllClass> mockEmbeddedDllClass = new Mock<IEmbeddedDllClass>();

            // Act
            NativeSdlTtf.Initialize(mockEmbeddedDllClass.Object);

            // Assert
            Assert.Equal(mockEmbeddedDllClass.Object, NativeSdlTtf.GetEmbeddedDllClass());
        }

        /// <summary>
        /// Tests that initialize calls extract embedded dlls
        /// </summary>
        [Fact]
        public void Initialize_CallsExtractEmbeddedDlls()
        {
            // Arrange
            Mock<IEmbeddedDllClass> mockEmbeddedDllClass = new Mock<IEmbeddedDllClass>();

            // Act
            NativeSdlTtf.Initialize(mockEmbeddedDllClass.Object);

            // Assert
            mockEmbeddedDllClass.Verify(
                x => x.ExtractEmbeddedDlls("sdl2_ttf", Sdl2Dlls.GlSdlTtfDllBytes, Assembly.GetAssembly(typeof(Sdl2Dlls))),
                Times.Once
            );
        }

        /// <summary>
        /// Tests that initialize with null embedded dll class throws argument null exception
        /// </summary>
        [Fact]
        public void Initialize_WithNullEmbeddedDllClass_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => NativeSdlTtf.Initialize(null));
        }
    }
}