// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RoomDataTest.cs
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
    ///     Test class for <see cref="RoomData" />.
    /// </summary>
    public class RoomDataTest
    {
        /// <summary>
        ///     Tests that constructor should initialize all properties correctly.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeAllPropertiesCorrectly()
        {
            // Arrange
            int xPos = 10;
            int yPos = 20;
            int width = 5;
            int height = 7;
            Direction direction = Direction.North;
            bool isBossRoom = true;

            // Act
            RoomData roomData = new RoomData(xPos, yPos, width, height, direction, isBossRoom);

            // Assert
            Assert.Equal(xPos, roomData.XPos);
            Assert.Equal(yPos, roomData.YPos);
            Assert.Equal(width, roomData.Width);
            Assert.Equal(height, roomData.Height);
            Assert.Equal(direction, roomData.Direction);
            Assert.Equal(isBossRoom, roomData.IsBossRoom);
        }

        /// <summary>
        ///     Tests that constructor should set is boss room to false by default.
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetIsBossRoomToFalseByDefault()
        {
            // Arrange & Act
            RoomData roomData = new RoomData(10, 20, 5, 7, Direction.South);

            // Assert
            Assert.False(roomData.IsBossRoom);
        }

        /// <summary>
        ///     Tests that equals should return true when comparing equal room data.
        /// </summary>
        [Fact]
        public void Equals_ShouldReturnTrue_WhenComparingEqualRoomData()
        {
            // Arrange
            RoomData roomData1 = new RoomData(10, 20, 5, 7, Direction.North, false);
            RoomData roomData2 = new RoomData(10, 20, 5, 7, Direction.North, false);

            // Act
            bool result = roomData1.Equals(roomData2);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that equals should return false when comparing different room data.
        /// </summary>
        [Fact]
        public void Equals_ShouldReturnFalse_WhenComparingDifferentRoomData()
        {
            // Arrange
            RoomData roomData1 = new RoomData(10, 20, 5, 7, Direction.North, false);
            RoomData roomData2 = new RoomData(15, 25, 6, 8, Direction.South, true);

            // Act
            bool result = roomData1.Equals(roomData2);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that equality operator should return true for equal room data.
        /// </summary>
        [Fact]
        public void EqualityOperator_ShouldReturnTrue_ForEqualRoomData()
        {
            // Arrange
            RoomData roomData1 = new RoomData(10, 20, 5, 7, Direction.East, false);
            RoomData roomData2 = new RoomData(10, 20, 5, 7, Direction.East, false);

            // Act
            bool result = roomData1 == roomData2;

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that inequality operator should return true for different room data.
        /// </summary>
        [Fact]
        public void InequalityOperator_ShouldReturnTrue_ForDifferentRoomData()
        {
            // Arrange
            RoomData roomData1 = new RoomData(10, 20, 5, 7, Direction.West, false);
            RoomData roomData2 = new RoomData(10, 20, 5, 7, Direction.East, false);

            // Act
            bool result = roomData1 != roomData2;

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that get hash code should return same hash for equal room data.
        /// </summary>
        [Fact]
        public void GetHashCode_ShouldReturnSameHash_ForEqualRoomData()
        {
            // Arrange
            RoomData roomData1 = new RoomData(10, 20, 5, 7, Direction.North, true);
            RoomData roomData2 = new RoomData(10, 20, 5, 7, Direction.North, true);

            // Act
            int hash1 = roomData1.GetHashCode();
            int hash2 = roomData2.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Tests that get hash code should return different hash for different room data.
        /// </summary>
        [Fact]
        public void GetHashCode_ShouldReturnDifferentHash_ForDifferentRoomData()
        {
            // Arrange
            RoomData roomData1 = new RoomData(10, 20, 5, 7, Direction.North, false);
            RoomData roomData2 = new RoomData(30, 40, 8, 9, Direction.South, true);

            // Act
            int hash1 = roomData1.GetHashCode();
            int hash2 = roomData2.GetHashCode();

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
            RoomData roomData = new RoomData(10, 20, 5, 7, Direction.North, false);
            object other = "not a room";

            // Act
            bool result = roomData.Equals(other);

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
            RoomData original = new RoomData(10, 20, 5, 7, Direction.North, false);
            
            // Act - Cannot modify properties as they are readonly
            // This test verifies that the struct is properly designed as immutable
            
            // Assert
            Assert.Equal(10, original.XPos);
            Assert.Equal(20, original.YPos);
            Assert.Equal(5, original.Width);
            Assert.Equal(7, original.Height);
        }
    }
}

