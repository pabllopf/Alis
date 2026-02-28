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
        /// <summary>
        ///     Tests the Version constructor with valid parameters.
        /// </summary>
        [Fact]
        public void VersionConstructor_WithValidParameters_InitializesCorrectly()
        {
            // Arrange
            int major = 2;
            int minor = 0;
            int patch = 18;

            // Act
            Version version = new Version(major, minor, patch);

            // Assert
            Assert.Equal((byte)major, version.major);
            Assert.Equal((byte)minor, version.minor);
            Assert.Equal((byte)patch, version.patch);
        }

        /// <summary>
        ///     Tests the Version constructor with zero values.
        /// </summary>
        [Fact]
        public void VersionConstructor_WithZeroValues_InitializesZeroVersion()
        {
            // Arrange & Act
            Version version = new Version(0, 0, 0);

            // Assert
            Assert.Equal(0, version.major);
            Assert.Equal(0, version.minor);
            Assert.Equal(0, version.patch);
        }

        /// <summary>
        ///     Tests the Version constructor with maximum byte values.
        /// </summary>
        [Fact]
        public void VersionConstructor_WithMaxByteValues_InitializesMaxVersion()
        {
            // Arrange
            int major = 255;
            int minor = 255;
            int patch = 255;

            // Act
            Version version = new Version(major, minor, patch);

            // Assert
            Assert.Equal(255, version.major);
            Assert.Equal(255, version.minor);
            Assert.Equal(255, version.patch);
        }

        /// <summary>
        ///     Tests the Version constructor with different values.
        /// </summary>
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(5, 10, 15)]
        [InlineData(100, 50, 25)]
        public void VersionConstructor_WithDifferentValues_InitializesProperly(int major, int minor, int patch)
        {
            // Act
            Version version = new Version(major, minor, patch);

            // Assert
            Assert.Equal((byte)major, version.major);
            Assert.Equal((byte)minor, version.minor);
            Assert.Equal((byte)patch, version.patch);
        }
    }
}

