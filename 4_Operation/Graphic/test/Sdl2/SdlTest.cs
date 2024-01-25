// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTest.cs
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

using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Sdl2
{
    /// <summary>
    /// The sdl test class
    /// </summary>
    public class SdlTest
    {
        /// <summary>
        /// Tests that test init
        /// </summary>
        [Fact]
        public void TestInit()
        {
            // Arrange
            const SdlInit expected = SdlInit.InitEverything;

            // Act
            int result = Sdl.Init(expected);

            // Assert
            Assert.Equal(0, result);
        }
        
        /// <summary>
        /// Tests that test get gl compiled version
        /// </summary>
        [Fact]
        public void TestGetGlCompiledVersion()
        {
            // Arrange
            const int expectedVersion = Sdl.MajorVersion * 1000 + Sdl.MinorVersion * 100 + Sdl.PatchLevel;

            // Act
            int actualVersion = Sdl.GetGlCompiledVersion();

            // Assert
            Assert.Equal(expectedVersion, actualVersion);
        }
        
        
        
    }
}