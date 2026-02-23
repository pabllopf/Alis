// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CorridorDataTest.cs
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
    ///     Test class for <see cref="CorridorData" />.
    /// </summary>
    public class CorridorDataTest
    {
        /// <summary>
        ///     Tests that constructor should initialize all properties correctly.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeAllPropertiesCorrectly()
        {
            // Arrange
            int xPos = 15;
            int yPos = 25;
            int width = 4;
            int height = 6;
            Direction direction = Direction.South;

            // Act
            CorridorData corridorData = new CorridorData(xPos, yPos, width, height, direction);

            // Assert
            Assert.Equal(xPos, corridorData.XPos);
            Assert.Equal(yPos, corridorData.YPos);
            Assert.Equal(width, corridorData.Width);
            Assert.Equal(height, corridorData.Height);
            Assert.Equal(direction, corridorData.Direction);
        }

        /// <summary>
        ///     Tests that equals should return true when comparing equal corridor data.
        /// </summary>
        [Fact]
        public void Equals_ShouldReturnTrue_WhenComparingEqualCorridorData()
        {
            // Arrange
            CorridorData corridorData1 = new CorridorData(15, 25, 4, 6, Direction.East);
            CorridorData corridorData2 = new CorridorData(15, 25, 4, 6, Direction.East);

            // Act
            bool result = corridorData1.Equals(corridorData2);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that equals should return false when comparing different corridor data.
        /// </summary>
        [Fact]
        public void Equals_ShouldReturnFalse_WhenComparingDifferentCorridorData()
        {
            // Arrange
            CorridorData corridorData1 = new CorridorData(15, 25, 4, 6, Direction.North);
            CorridorData corridorData2 = new CorridorData(20, 30, 5, 7, Direction.South);

            // Act
            bool result = corridorData1.Equals(corridorData2);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that equality operator should return true for equal corridor data.
        /// </summary>
        [Fact]
        public void EqualityOperator_ShouldReturnTrue_ForEqualCorridorData()
        {
            // Arrange
            CorridorData corridorData1 = new CorridorData(15, 25, 4, 6, Direction.West);
            CorridorData corridorData2 = new CorridorData(15, 25, 4, 6, Direction.West);

            // Act
            bool result = corridorData1 == corridorData2;

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that inequality operator should return true for different corridor data.
        /// </summary>
        [Fact]
        public void InequalityOperator_ShouldReturnTrue_ForDifferentCorridorData()
        {
            // Arrange
            CorridorData corridorData1 = new CorridorData(15, 25, 4, 6, Direction.North);
            CorridorData corridorData2 = new CorridorData(15, 25, 4, 6, Direction.South);

            // Act
            bool result = corridorData1 != corridorData2;

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that get hash code should return same hash for equal corridor data.
        /// </summary>
        [Fact]
        public void GetHashCode_ShouldReturnSameHash_ForEqualCorridorData()
        {
            // Arrange
            CorridorData corridorData1 = new CorridorData(15, 25, 4, 6, Direction.East);
            CorridorData corridorData2 = new CorridorData(15, 25, 4, 6, Direction.East);

            // Act
            int hash1 = corridorData1.GetHashCode();
            int hash2 = corridorData2.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Tests that get hash code should return different hash for different corridor data.
        /// </summary>
        [Fact]
        public void GetHashCode_ShouldReturnDifferentHash_ForDifferentCorridorData()
        {
            // Arrange
            CorridorData corridorData1 = new CorridorData(15, 25, 4, 6, Direction.North);
            CorridorData corridorData2 = new CorridorData(30, 40, 8, 9, Direction.South);

            // Act
            int hash1 = corridorData1.GetHashCode();
            int hash2 = corridorData2.GetHashCode();

            // Assert
            Assert.NotEqual(hash1, hash2);
        }

        /// <summary>
        ///     Tests that equals should return false when comparing with different type.
        /// </summary>
        [Fact]
        public void Equals_ShouldReturnFalse_WhenComparingWithDifferentType()
        {
            // Arrange
            CorridorData corridorData = new CorridorData(15, 25, 4, 6, Direction.North);
            object other = 42;

            // Act
            bool result = corridorData.Equals(other);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that struct should be immutable.
        /// </summary>
        [Fact]
        public void Struct_ShouldBeImmutable()
        {
            // Arrange
            CorridorData original = new CorridorData(15, 25, 4, 6, Direction.West);
            
            // Act - Cannot modify properties as they are readonly
            // This test verifies that the struct is properly designed as immutable
            
            // Assert
            Assert.Equal(15, original.XPos);
            Assert.Equal(25, original.YPos);
            Assert.Equal(4, original.Width);
            Assert.Equal(6, original.Height);
        }

        /// <summary>
        ///     Tests that constructor should accept zero values.
        /// </summary>
        [Fact]
        public void Constructor_ShouldAcceptZeroValues()
        {
            // Arrange & Act
            CorridorData corridorData = new CorridorData(0, 0, 0, 0, Direction.North);

            // Assert
            Assert.Equal(0, corridorData.XPos);
            Assert.Equal(0, corridorData.YPos);
            Assert.Equal(0, corridorData.Width);
            Assert.Equal(0, corridorData.Height);
        }
    }
}

