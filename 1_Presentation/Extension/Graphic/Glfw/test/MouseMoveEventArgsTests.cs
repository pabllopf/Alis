// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseMoveEventArgsTests.cs
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
    ///     Tests for MouseMoveEventArgs class
    /// </summary>
    public class MouseMoveEventArgsTests
    {
        /// <summary>
        /// Tests that constructor with valid coordinates sets properties
        /// </summary>
        [Fact]
        public void Constructor_WithValidCoordinates_SetsProperties()
        {
            // Arrange
            double x = 100.5;
            double y = 200.7;

            // Act
            MouseMoveEventArgs args = new MouseMoveEventArgs(x, y);

            // Assert
            Assert.Equal(x, args.X);
            Assert.Equal(y, args.Y);
        }

        /// <summary>
        /// Tests that x property returns correct value
        /// </summary>
        [Fact]
        public void X_Property_ReturnsCorrectValue()
        {
            // Arrange
            double expectedX = 150.25;
            MouseMoveEventArgs args = new MouseMoveEventArgs(expectedX, 100);

            // Act
            double result = args.X;

            // Assert
            Assert.Equal(expectedX, result);
        }

        /// <summary>
        /// Tests that y property returns correct value
        /// </summary>
        [Fact]
        public void Y_Property_ReturnsCorrectValue()
        {
            // Arrange
            double expectedY = 250.75;
            MouseMoveEventArgs args = new MouseMoveEventArgs(100, expectedY);

            // Act
            double result = args.Y;

            // Assert
            Assert.Equal(expectedY, result);
        }

        /// <summary>
        /// Tests that position property returns correct point
        /// </summary>
        [Fact]
        public void Position_Property_ReturnsCorrectPoint()
        {
            // Arrange
            double x = 123.9;
            double y = 456.1;
            MouseMoveEventArgs args = new MouseMoveEventArgs(x, y);

            // Act
            Point result = args.Position;

            // Assert
            Assert.Equal(124, result.X);
            Assert.Equal(456, result.Y);
        }

        /// <summary>
        /// Tests that constructor with negative coordinates sets properties
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeCoordinates_SetsProperties()
        {
            // Arrange
            double x = -50.5;
            double y = -100.3;

            // Act
            MouseMoveEventArgs args = new MouseMoveEventArgs(x, y);

            // Assert
            Assert.Equal(x, args.X);
            Assert.Equal(y, args.Y);
        }

        /// <summary>
        /// Tests that constructor with zero coordinates sets properties
        /// </summary>
        [Fact]
        public void Constructor_WithZeroCoordinates_SetsProperties()
        {
            // Arrange
            double x = 0.0;
            double y = 0.0;

            // Act
            MouseMoveEventArgs args = new MouseMoveEventArgs(x, y);

            // Assert
            Assert.Equal(x, args.X);
            Assert.Equal(y, args.Y);
        }

        /// <summary>
        /// Tests that position with large values converts correctly
        /// </summary>
        [Fact]
        public void Position_WithLargeValues_ConvertsCorrectly()
        {
            // Arrange
            double x = 1920.0;
            double y = 1080.0;
            MouseMoveEventArgs args = new MouseMoveEventArgs(x, y);

            // Act
            Point result = args.Position;

            // Assert
            Assert.Equal(1920, result.X);
            Assert.Equal(1080, result.Y);
        }
    }
}

