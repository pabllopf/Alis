// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VersionTest.cs
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

using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the Version struct.
    /// </summary>
    public class VersionTest
    {
        [Fact]
        public void ShouldSetFieldsThroughConstructor()
        {
            // Arrange
            Version version = new Version(3, 2, 1);
            // Assert
            Assert.Equal(3, version.major);
            Assert.Equal(2, version.minor);
            Assert.Equal(1, version.patch);
        }

        [Fact]
        public void ShouldDefaultToZero()
        {
            // Arrange
            Version version = new Version();
            // Assert
            Assert.Equal(0, version.major);
            Assert.Equal(0, version.minor);
            Assert.Equal(0, version.patch);
        }

        [Fact]
        public void ShouldTruncateValuesExceedingByte()
        {
            // Arrange: values > 255 will be truncated to byte
            Version version = new Version(256, 512, 1024);
            // Assert
            Assert.Equal(0, version.major);   // 256 & 0xFF = 0
            Assert.Equal(0, version.minor);   // 512 & 0xFF = 0
            Assert.Equal(0, version.patch);   // 1024 & 0xFF = 0
        }
    }
}
