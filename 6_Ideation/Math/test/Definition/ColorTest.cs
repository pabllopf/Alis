// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ColorTest.cs
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

using Alis.Core.Aspect.Math.Definition;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Definition
{
    /// <summary>
    ///     The color tests class
    /// </summary>
    public class ColorTests
    {
        /// <summary>
        ///     Tests that constructor sets properties correctly when given bytes
        /// </summary>
        [Fact]
        public void Constructor_SetsPropertiesCorrectly_WhenGivenBytes()
        {
            // Arrange
            const byte r = 255;
            const byte g = 128;
            const byte b = 64;
            const byte a = 32;

            // Act
            Color color = new Color(r, g, b, a);

            // Assert
            Assert.Equal(r, color.R);
            Assert.Equal(g, color.G);
            Assert.Equal(b, color.B);
            Assert.Equal(a, color.A);
        }

        /// <summary>
        ///     Tests that constructor sets properties correctly when given ints
        /// </summary>
        [Fact]
        public void Constructor_SetsPropertiesCorrectly_WhenGivenInts()
        {
            // Arrange
            const int r = 255;
            const int g = 128;
            const int b = 64;
            const int a = 32;

            // Act
            Color color = new Color(r, g, b, a);

            // Assert
            Assert.Equal(r, color.R);
            Assert.Equal(g, color.G);
            Assert.Equal(b, color.B);
            Assert.Equal(a, color.A);
        }

        /// <summary>
        ///     Tests that black returns correct color
        /// </summary>
        [Fact]
        public void Black_ReturnsCorrectColor()
        {
            // Arrange
            Color expected = new Color(0, 0, 0, 255);

            // Act
            Color actual = Color.Black;

            // Assert
            Assert.Equal(expected.R, actual.R);
            Assert.Equal(expected.G, actual.G);
            Assert.Equal(expected.B, actual.B);
            Assert.Equal(expected.A, actual.A);
        }

        /// <summary>
        ///     Tests that red returns correct color
        /// </summary>
        [Fact]
        public void Red_ReturnsCorrectColor()
        {
            // Arrange
            Color expected = new Color(255, 0, 0, 255);

            // Act
            Color actual = Color.Red;

            // Assert
            Assert.Equal(expected.R, actual.R);
            Assert.Equal(expected.G, actual.G);
            Assert.Equal(expected.B, actual.B);
            Assert.Equal(expected.A, actual.A);
        }

        /// <summary>
        ///     Tests that red returns correct color
        /// </summary>
        [Fact]
        public void Green_ReturnsCorrectColor()
        {
            // Arrange
            Color expected = new Color(0, 255, 0, 255);

            // Act
            Color actual = Color.Green;

            // Assert
            Assert.Equal(expected.R, actual.R);
            Assert.Equal(expected.G, actual.G);
            Assert.Equal(expected.B, actual.B);
            Assert.Equal(expected.A, actual.A);
        }

        /// <summary>
        ///     Tests that red returns correct color
        /// </summary>
        [Fact]
        public void Brown_ReturnsCorrectColor()
        {
            // Arrange
            Color expected = new Color(165, 42, 42, 255);

            // Act
            Color actual = Color.Brown;

            // Assert
            Assert.Equal(expected.R, actual.R);
            Assert.Equal(expected.G, actual.G);
            Assert.Equal(expected.B, actual.B);
            Assert.Equal(expected.A, actual.A);
        }

        /// <summary>
        /// Tests that dark green returns correct color
        /// </summary>
        [Fact]
        public void DarkGreen_ReturnsCorrectColor()
        {
            // Arrange
            Color expected = new Color(0, 100, 0, 255);

            // Act
            Color actual = Color.DarkGreen;

            // Assert
            Assert.Equal(expected.R, actual.R);
            Assert.Equal(expected.G, actual.G);
            Assert.Equal(expected.B, actual.B);
            Assert.Equal(expected.A, actual.A);
        }

    }
}