// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoardSquareTest.cs
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

using Alis.Core.Aspect.Math;
using Xunit;

namespace Alis.Extension.Math.DungeonGenerator.Test
{
    /// <summary>
    ///     The board square test class
    /// </summary>
    public class BoardSquareTest
    {
        /// <summary>
        ///     Tests that set up first room should initialize room with given parameters
        /// </summary>
        [Fact]
        public void SetUpFirstRoom_ShouldInitializeRoomWithGivenParameters()
        {
            // Arrange
            int xPos = 5;
            int yPos = 10;
            int width = 15;
            int height = 20;

            // Act
            Room room = Room.SetUpFirstRoom(xPos, yPos, width, height);

            // Assert
            Assert.Equal(xPos, room.XPos);
            Assert.Equal(yPos, room.YPos);
            Assert.Equal(width, room.Width);
            Assert.Equal(height, room.Height);
        }

        /// <summary>
        ///     Tests that set up should initialize room with correct parameters when direction is north
        /// </summary>
        [Fact]
        public void SetUp_ShouldInitializeRoomWithCorrectParameters_WhenDirectionIsNorth()
        {
            // Arrange
            int width = 10;
            int height = 5;
            Corridor corridor = new Corridor(5, 5, 10, 2, Direction.North);

            // Act
            Room room = Room.SetUp(width, height, corridor);

            // Assert
            Assert.Equal(5, room.XPos);
            Assert.Equal(7, room.YPos);
            Assert.Equal(width, room.Width);
            Assert.Equal(height, room.Height);
            Assert.Equal(Direction.North, room.Direction);
        }

        /// <summary>
        ///     Tests that set up should initialize room with correct parameters when direction is south
        /// </summary>
        [Fact]
        public void SetUp_ShouldInitializeRoomWithCorrectParameters_WhenDirectionIsSouth()
        {
            // Arrange
            int width = 10;
            int height = 5;
            Corridor corridor = new Corridor(5, 5, 10, 2, Direction.South);

            // Act
            Room room = Room.SetUp(width, height, corridor);

            // Assert
            Assert.Equal(5, room.XPos);
            Assert.Equal(0, room.YPos);
            Assert.Equal(width, room.Width);
            Assert.Equal(height, room.Height);
            Assert.Equal(Direction.South, room.Direction);
        }

        /// <summary>
        ///     Tests that set up should initialize room with correct parameters when direction is east
        /// </summary>
        [Fact]
        public void SetUp_ShouldInitializeRoomWithCorrectParameters_WhenDirectionIsEast()
        {
            // Arrange
            int width = 10;
            int height = 5;
            Corridor corridor = new Corridor(5, 5, 2, 10, Direction.East);

            // Act
            Room room = Room.SetUp(width, height, corridor);

            // Assert
            Assert.Equal(0, room.XPos);
            Assert.Equal(8, room.YPos);
            Assert.Equal(height, room.Width);
            Assert.Equal(width, room.Height);
            Assert.Equal(Direction.East, room.Direction);
        }

        /// <summary>
        ///     Tests that set up should initialize room with correct parameters when direction is west
        /// </summary>
        [Fact]
        public void SetUp_ShouldInitializeRoomWithCorrectParameters_WhenDirectionIsWest()
        {
            // Arrange
            int width = 10;
            int height = 5;
            Corridor corridor = new Corridor(5, 5, 2, 10, Direction.West);

            // Act
            Room room = Room.SetUp(width, height, corridor);

            // Assert
            Assert.True(room.XPos > 0);
            Assert.True(room.YPos > 0);
            Assert.Equal(height, room.Width);
            Assert.Equal(width, room.Height);
            Assert.Equal(Direction.West, room.Direction);
        }
    }
}