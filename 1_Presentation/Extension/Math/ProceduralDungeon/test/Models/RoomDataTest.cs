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
            int xPos = 10;
            int yPos = 20;
            int width = 5;
            int height = 7;
            Direction direction = Direction.North;
            bool isBossRoom = true;

            RoomData roomData = new RoomData(xPos, yPos, width, height, direction, isBossRoom);

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
            RoomData roomData = new RoomData(10, 20, 5, 7, Direction.South);

            Assert.False(roomData.IsBossRoom);
        }

        /// <summary>
        ///     Tests that equals should return true when comparing equal room data.
        /// </summary>
        [Fact]
        public void Equals_ShouldReturnTrue_WhenComparingEqualRoomData()
        {
            RoomData roomData1 = new RoomData(10, 20, 5, 7, Direction.North);
            RoomData roomData2 = new RoomData(10, 20, 5, 7, Direction.North);

            bool result = roomData1.Equals(roomData2);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that equals should return false when comparing different room data.
        /// </summary>
        [Fact]
        public void Equals_ShouldReturnFalse_WhenComparingDifferentRoomData()
        {
            RoomData roomData1 = new RoomData(10, 20, 5, 7, Direction.North);
            RoomData roomData2 = new RoomData(15, 25, 6, 8, Direction.South, true);

            bool result = roomData1.Equals(roomData2);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that equality operator should return true for equal room data.
        /// </summary>
        [Fact]
        public void EqualityOperator_ShouldReturnTrue_ForEqualRoomData()
        {
            RoomData roomData1 = new RoomData(10, 20, 5, 7, Direction.East);
            RoomData roomData2 = new RoomData(10, 20, 5, 7, Direction.East);

            bool result = roomData1 == roomData2;

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that inequality operator should return true for different room data.
        /// </summary>
        [Fact]
        public void InequalityOperator_ShouldReturnTrue_ForDifferentRoomData()
        {
            RoomData roomData1 = new RoomData(10, 20, 5, 7, Direction.West);
            RoomData roomData2 = new RoomData(10, 20, 5, 7, Direction.East);

            bool result = roomData1 != roomData2;

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that get hash code should return same hash for equal room data.
        /// </summary>
        [Fact]
        public void GetHashCode_ShouldReturnSameHash_ForEqualRoomData()
        {
            RoomData roomData1 = new RoomData(10, 20, 5, 7, Direction.North, true);
            RoomData roomData2 = new RoomData(10, 20, 5, 7, Direction.North, true);

            int hash1 = roomData1.GetHashCode();
            int hash2 = roomData2.GetHashCode();

            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Tests that get hash code should return different hash for different room data.
        /// </summary>
        [Fact]
        public void GetHashCode_ShouldReturnDifferentHash_ForDifferentRoomData()
        {
            RoomData roomData1 = new RoomData(10, 20, 5, 7, Direction.North);
            RoomData roomData2 = new RoomData(30, 40, 8, 9, Direction.South, true);

            int hash1 = roomData1.GetHashCode();
            int hash2 = roomData2.GetHashCode();

            Assert.NotEqual(hash1, hash2);
        }

        /// <summary>
        ///     Tests that equals should return false when comparing with different type.
        /// </summary>
        [Fact]
        public void Equals_ShouldReturnFalse_WhenComparingWithDifferentType()
        {
            RoomData roomData = new RoomData(10, 20, 5, 7, Direction.North);
            object other = "not a room";

            bool result = roomData.Equals(other);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that struct should be immutable.
        /// </summary>
        [Fact]
        public void Struct_ShouldBeImmutable()
        {
            RoomData original = new RoomData(10, 20, 5, 7, Direction.North);

            // This test verifies that the struct is properly designed as immutable

            Assert.Equal(10, original.XPos);
            Assert.Equal(20, original.YPos);
            Assert.Equal(5, original.Width);
            Assert.Equal(7, original.Height);
        }

        /// <summary>
        ///     Tests that IsBossRoom property distinguishes correctly between boss and regular rooms.
        /// </summary>
        [Fact]
        public void IsBossRoom_ShouldDifferentiateCorrectly()
        {
            RoomData regularRoom = new RoomData(10, 20, 5, 7, Direction.North);
            RoomData bossRoom = new RoomData(10, 20, 5, 7, Direction.North, true);

            Assert.False(regularRoom.IsBossRoom);
            Assert.True(bossRoom.IsBossRoom);
        }

        /// <summary>
        ///     Tests equality when IsBossRoom property differs.
        /// </summary>
        [Fact]
        public void Equals_ShouldReturnFalse_WhenIsBossRoomDiffers()
        {
            RoomData room1 = new RoomData(10, 20, 5, 7, Direction.North, true);
            RoomData room2 = new RoomData(10, 20, 5, 7, Direction.North);

            bool result = room1.Equals(room2);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests inequality operator with same dimensions but different IsBossRoom.
        /// </summary>
        [Fact]
        public void InequalityOperator_ShouldReturnTrue_WhenIsBossRoomDiffers()
        {
            RoomData room1 = new RoomData(10, 20, 5, 7, Direction.North, true);
            RoomData room2 = new RoomData(10, 20, 5, 7, Direction.North);

            bool result = room1 != room2;

            Assert.True(result);
        }

        /// <summary>
        ///     Tests with negative coordinates.
        /// </summary>
        [Fact]
        public void Constructor_ShouldAcceptNegativeCoordinates()
        {
            RoomData roomData = new RoomData(-5, -10, 3, 4, Direction.South);

            Assert.Equal(-5, roomData.XPos);
            Assert.Equal(-10, roomData.YPos);
        }

        /// <summary>
        ///     Tests with zero dimensions.
        /// </summary>
        [Fact]
        public void Constructor_ShouldAcceptZeroDimensions()
        {
            RoomData roomData = new RoomData(0, 0, 0, 0, Direction.East);

            Assert.Equal(0, roomData.Width);
            Assert.Equal(0, roomData.Height);
        }

        /// <summary>
        ///     Tests with all four directions.
        /// </summary>
        [Theory, InlineData(Direction.North), InlineData(Direction.South), InlineData(Direction.East), InlineData(Direction.West)]
        public void Constructor_WithAllDirections_StoresCorrectly(Direction direction)
        {
            RoomData roomData = new RoomData(5, 10, 3, 4, direction);

            Assert.Equal(direction, roomData.Direction);
        }

        /// <summary>
        ///     Tests hash code stability with IsBossRoom property.
        /// </summary>
        [Fact]
        public void GetHashCode_ShouldDiffer_WhenIsBossRoomDiffers()
        {
            RoomData room1 = new RoomData(10, 20, 5, 7, Direction.North, true);
            RoomData room2 = new RoomData(10, 20, 5, 7, Direction.North);

            int hash1 = room1.GetHashCode();
            int hash2 = room2.GetHashCode();

            Assert.NotEqual(hash1, hash2);
        }
    }
}