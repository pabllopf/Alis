// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PositionTest.cs
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

using Alis.Extension.Math.ProceduralDungeon.Models;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test.Models
{
    /// <summary>
    ///     Test class for <see cref="Position" />.
    ///     Verifies position struct operations and properties.
    /// </summary>
    public class PositionTest
    {
        /// <summary>
        ///     Tests that constructor sets properties correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithValidValues_SetsProperties()
        {
            // Arrange
            int x = 10;
            int y = 20;

            // Act
            Position position = new Position(x, y);

            // Assert
            Assert.Equal(x, position.X);
            Assert.Equal(y, position.Y);
        }

        /// <summary>
        ///     Tests that Zero returns origin position.
        /// </summary>
        [Fact]
        public void Zero_ReturnsOriginPosition()
        {
            // Act
            Position zero = Position.Zero;

            // Assert
            Assert.Equal(0, zero.X);
            Assert.Equal(0, zero.Y);
        }

        /// <summary>
        ///     Tests addition operator.
        /// </summary>
        [Fact]
        public void AdditionOperator_WithTwoPositions_ReturnsSum()
        {
            // Arrange
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(3, 7);

            // Act
            Position result = pos1 + pos2;

            // Assert
            Assert.Equal(8, result.X);
            Assert.Equal(17, result.Y);
        }

        /// <summary>
        ///     Tests subtraction operator.
        /// </summary>
        [Fact]
        public void SubtractionOperator_WithTwoPositions_ReturnsDifference()
        {
            // Arrange
            Position pos1 = new Position(10, 20);
            Position pos2 = new Position(3, 7);

            // Act
            Position result = pos1 - pos2;

            // Assert
            Assert.Equal(7, result.X);
            Assert.Equal(13, result.Y);
        }

        /// <summary>
        ///     Tests equality operator with equal positions.
        /// </summary>
        [Fact]
        public void EqualityOperator_WithEqualPositions_ReturnsTrue()
        {
            // Arrange
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(5, 10);

            // Act
            bool result = pos1 == pos2;

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests equality operator with different positions.
        /// </summary>
        [Fact]
        public void EqualityOperator_WithDifferentPositions_ReturnsFalse()
        {
            // Arrange
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(3, 7);

            // Act
            bool result = pos1 == pos2;

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests inequality operator with different positions.
        /// </summary>
        [Fact]
        public void InequalityOperator_WithDifferentPositions_ReturnsTrue()
        {
            // Arrange
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(3, 7);

            // Act
            bool result = pos1 != pos2;

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests inequality operator with equal positions.
        /// </summary>
        [Fact]
        public void InequalityOperator_WithEqualPositions_ReturnsFalse()
        {
            // Arrange
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(5, 10);

            // Act
            bool result = pos1 != pos2;

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests Equals method with equal position.
        /// </summary>
        [Fact]
        public void Equals_WithEqualPosition_ReturnsTrue()
        {
            // Arrange
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(5, 10);

            // Act
            bool result = pos1.Equals(pos2);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests Equals method with different position.
        /// </summary>
        [Fact]
        public void Equals_WithDifferentPosition_ReturnsFalse()
        {
            // Arrange
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(3, 7);

            // Act
            bool result = pos1.Equals(pos2);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests Equals method with object parameter.
        /// </summary>
        [Fact]
        public void Equals_WithObjectParameter_ReturnsCorrectResult()
        {
            // Arrange
            Position pos1 = new Position(5, 10);
            object pos2 = new Position(5, 10);
            object notPosition = "not a position";

            // Act
            bool equalResult = pos1.Equals(pos2);
            bool notEqualResult = pos1.Equals(notPosition);

            // Assert
            Assert.True(equalResult);
            Assert.False(notEqualResult);
        }

        /// <summary>
        ///     Tests GetHashCode returns consistent values.
        /// </summary>
        [Fact]
        public void GetHashCode_WithEqualPositions_ReturnsSameValue()
        {
            // Arrange
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(5, 10);

            // Act
            int hash1 = pos1.GetHashCode();
            int hash2 = pos2.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Tests ToString returns formatted string.
        /// </summary>
        [Fact]
        public void ToString_ReturnsFormattedString()
        {
            // Arrange
            Position position = new Position(5, 10);

            // Act
            string result = position.ToString();

            // Assert
            Assert.Equal("(5, 10)", result);
        }

        /// <summary>
        ///     Tests ManhattanDistanceTo calculates correct distance.
        /// </summary>
        [Fact]
        public void ManhattanDistanceTo_WithAnotherPosition_ReturnsCorrectDistance()
        {
            // Arrange
            Position pos1 = new Position(0, 0);
            Position pos2 = new Position(3, 4);

            // Act
            int distance = pos1.ManhattanDistanceTo(pos2);

            // Assert
            Assert.Equal(7, distance);
        }

        /// <summary>
        ///     Tests ManhattanDistanceTo with negative coordinates.
        /// </summary>
        [Fact]
        public void ManhattanDistanceTo_WithNegativeCoordinates_ReturnsCorrectDistance()
        {
            // Arrange
            Position pos1 = new Position(-5, -5);
            Position pos2 = new Position(3, 4);

            // Act
            int distance = pos1.ManhattanDistanceTo(pos2);

            // Assert
            Assert.Equal(17, distance); // |3-(-5)| + |4-(-5)| = 8 + 9 = 17
        }

        /// <summary>
        ///     Tests ManhattanDistanceTo with same position.
        /// </summary>
        [Fact]
        public void ManhattanDistanceTo_WithSamePosition_ReturnsZero()
        {
            // Arrange
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(5, 10);

            // Act
            int distance = pos1.ManhattanDistanceTo(pos2);

            // Assert
            Assert.Equal(0, distance);
        }
    }
}

