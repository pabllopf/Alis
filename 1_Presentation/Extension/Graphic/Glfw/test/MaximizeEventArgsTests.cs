// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MaximizeEventArgsTests.cs
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

using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for MaximizeEventArgs class
    /// </summary>
    public class MaximizeEventArgsTests
    {
        /// <summary>
        /// Tests that constructor with true value sets is maximized to true
        /// </summary>
        [Fact]
        public void Constructor_WithTrueValue_SetsIsMaximizedToTrue()
        {
            // Arrange & Act
            MaximizeEventArgs args = new MaximizeEventArgs(true);

            // Assert
            Assert.True(args.IsMaximized);
        }

        /// <summary>
        /// Tests that constructor with false value sets is maximized to false
        /// </summary>
        [Fact]
        public void Constructor_WithFalseValue_SetsIsMaximizedToFalse()
        {
            // Arrange & Act
            MaximizeEventArgs args = new MaximizeEventArgs(false);

            // Assert
            Assert.False(args.IsMaximized);
        }

        /// <summary>
        /// Tests that is maximized property returns correct value
        /// </summary>
        [Fact]
        public void IsMaximized_Property_ReturnsCorrectValue()
        {
            // Arrange
            bool expectedValue = true;
            MaximizeEventArgs args = new MaximizeEventArgs(expectedValue);

            // Act
            bool result = args.IsMaximized;

            // Assert
            Assert.Equal(expectedValue, result);
        }

        /// <summary>
        /// Tests that constructor with false value returns correct state
        /// </summary>
        [Fact]
        public void Constructor_WithFalseValue_ReturnsCorrectState()
        {
            // Arrange
            bool expectedValue = false;
            MaximizeEventArgs args = new MaximizeEventArgs(expectedValue);

            // Act
            bool result = args.IsMaximized;

            // Assert
            Assert.Equal(expectedValue, result);
        }
    }
}

