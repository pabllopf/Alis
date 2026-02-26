// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SizeChangeEventArgsTests.cs
// 
//  Author:GitHub Copilot
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

using System.Drawing;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for SizeChangeEventArgs class
    /// </summary>
    public class SizeChangeEventArgsTests
    {
        /// <summary>
        /// Tests that constructor with width and height sets size
        /// </summary>
        [Fact]
        public void Constructor_WithWidthAndHeight_SetsSize()
        {
            // Arrange
            int width = 800;
            int height = 600;

            // Act
            SizeChangeEventArgs args = new SizeChangeEventArgs(width, height);

            // Assert
            Assert.Equal(width, args.Size.Width);
            Assert.Equal(height, args.Size.Height);
        }

        /// <summary>
        /// Tests that constructor with size object sets size
        /// </summary>
        [Fact]
        public void Constructor_WithSizeObject_SetsSize()
        {
            // Arrange
            Size size = new Size(1024, 768);

            // Act
            SizeChangeEventArgs args = new SizeChangeEventArgs(size);

            // Assert
            Assert.Equal(size, args.Size);
        }

        /// <summary>
        /// Tests that size property returns correct value
        /// </summary>
        [Fact]
        public void Size_Property_ReturnsCorrectValue()
        {
            // Arrange
            Size expectedSize = new Size(1920, 1080);
            SizeChangeEventArgs args = new SizeChangeEventArgs(expectedSize);

            // Act
            Size result = args.Size;

            // Assert
            Assert.Equal(expectedSize, result);
        }

        /// <summary>
        /// Tests that constructor with zero size sets size
        /// </summary>
        [Fact]
        public void Constructor_WithZeroSize_SetsSize()
        {
            // Arrange
            int width = 0;
            int height = 0;

            // Act
            SizeChangeEventArgs args = new SizeChangeEventArgs(width, height);

            // Assert
            Assert.Equal(0, args.Size.Width);
            Assert.Equal(0, args.Size.Height);
        }

        /// <summary>
        /// Tests that constructor with large size sets size
        /// </summary>
        [Fact]
        public void Constructor_WithLargeSize_SetsSize()
        {
            // Arrange
            int width = 3840;
            int height = 2160;

            // Act
            SizeChangeEventArgs args = new SizeChangeEventArgs(width, height);

            // Assert
            Assert.Equal(width, args.Size.Width);
            Assert.Equal(height, args.Size.Height);
        }

        /// <summary>
        /// Tests that constructor with different values creates distinct objects
        /// </summary>
        [Fact]
        public void Constructor_WithDifferentValues_CreatesDistinctObjects()
        {
            // Arrange & Act
            SizeChangeEventArgs args1 = new SizeChangeEventArgs(800, 600);
            SizeChangeEventArgs args2 = new SizeChangeEventArgs(1024, 768);

            // Assert
            Assert.NotEqual(args1.Size, args2.Size);
        }
    }
}

