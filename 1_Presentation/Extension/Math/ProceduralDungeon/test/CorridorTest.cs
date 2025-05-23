// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CorridorTest.cs
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

using System;
using Alis.Core.Aspect.Math;
using Xunit;

namespace Alis.Extension.Math.DungeonGenerator.Test
{
    /// <summary>
    ///     The corridor test class
    /// </summary>
    public class CorridorTest
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
            Assert.True(room.XPos >= 0);
            Assert.True(room.YPos >= 0);
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

        /// <summary>
        ///     Tests that set up first room should initialize room with given parameters v 2
        /// </summary>
        [Fact]
        public void SetUpFirstRoom_ShouldInitializeRoomWithGivenParameters_v2()
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
        ///     Tests that set up should initialize room with correct parameters when direction is north v 2
        /// </summary>
        [Fact]
        public void SetUp_ShouldInitializeRoomWithCorrectParameters_WhenDirectionIsNorth_v2()
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
        ///     Tests that set up should initialize room with correct parameters when direction is south v 2
        /// </summary>
        [Fact]
        public void SetUp_ShouldInitializeRoomWithCorrectParameters_WhenDirectionIsSouth_v2()
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
        ///     Tests that set up should initialize room with correct parameters when direction is east v 2
        /// </summary>
        [Fact]
        public void SetUp_ShouldInitializeRoomWithCorrectParameters_WhenDirectionIsEast_v2()
        {
            // Arrange
            int width = 10;
            int height = 5;
            Corridor corridor = new Corridor(5, 5, 2, 10, Direction.East);

            // Act
            Room room = Room.SetUp(width, height, corridor);

            // Assert
            Assert.True(room.XPos >= 0);
            Assert.True(room.YPos >= 0);
            Assert.Equal(height, room.Width);
            Assert.Equal(width, room.Height);
            Assert.Equal(Direction.East, room.Direction);
        }

        /// <summary>
        ///     Tests that set up should initialize room with correct parameters when direction is west v 2
        /// </summary>
        [Fact]
        public void SetUp_ShouldInitializeRoomWithCorrectParameters_WhenDirectionIsWest_v2()
        {
            // Arrange
            int width = 10;
            int height = 5;
            Corridor corridor = new Corridor(5, 5, 2, 10, Direction.West);

            // Act
            Room room = Room.SetUp(width, height, corridor);

            // Assert
            Assert.True(room.XPos >= 0);
            Assert.True(room.YPos >= 0);
            Assert.Equal(height, room.Width);
            Assert.Equal(width, room.Height);
            Assert.Equal(Direction.West, room.Direction);
        }

        /// <summary>
        ///     Tests that set up should initialize room with correct parameters when direction is none
        /// </summary>
        [Fact]
        public void SetUp_ShouldInitializeRoomWithCorrectParameters_WhenDirectionIsNone()
        {
            // Arrange
            int width = 10;
            int height = 5;
            Corridor corridor = new Corridor(5, 5, 2, 10, Direction.None);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Room.SetUp(width, height, corridor));
        }

        /// <summary>
        ///     Tests that set up first corridor should initialize corridor with correct parameters when direction is north
        /// </summary>
        [Fact]
        public void SetUpFirstCorridor_ShouldInitializeCorridorWithCorrectParameters_WhenDirectionIsNorth()
        {
            // Arrange
            int width = 10;
            int height = 5;
            Room room = new Room(5, 5, 10, 10, Direction.North);

            // Act
            Corridor corridor = Corridor.SetUpFirstCorridor(width, height, room);

            // Assert
            Assert.True(room.XPos >= 0);
            Assert.True(room.YPos >= 0);
            Assert.True(corridor.Width >= 5);
            Assert.True(corridor.Height >= 5);
            Assert.NotEqual(Direction.None, corridor.Direction);
        }

        /// <summary>
        ///     Tests that set up first corridor should initialize corridor with correct parameters when direction is south
        /// </summary>
        [Fact]
        public void SetUpFirstCorridor_ShouldInitializeCorridorWithCorrectParameters_WhenDirectionIsSouth()
        {
            // Arrange
            int width = 10;
            int height = 5;
            Room room = new Room(5, 5, 10, 10, Direction.South);

            // Act
            Corridor corridor = Corridor.SetUpFirstCorridor(width, height, room);

            // Assert
            Assert.True(room.XPos >= 0);
            Assert.True(room.YPos >= 0);
            Assert.True(corridor.Width >= 5);
            Assert.True(corridor.Height >= 5);
            Assert.NotEqual(Direction.None, corridor.Direction);
        }

        /// <summary>
        ///     Tests that set up first corridor should initialize corridor with correct parameters when direction is east
        /// </summary>
        [Fact]
        public void SetUpFirstCorridor_ShouldInitializeCorridorWithCorrectParameters_WhenDirectionIsEast()
        {
            // Arrange
            int width = 10;
            int height = 5;
            Room room = new Room(5, 5, width, height, Direction.East);

            // Act
            Corridor corridor = Corridor.SetUpFirstCorridor(width, height, room);

            // Assert
            Assert.True(room.XPos >= 0);
            Assert.True(room.YPos >= 0);
            Assert.True(corridor.Width >= 5);
            Assert.True(corridor.Height >= 5);
            Assert.NotEqual(Direction.None, corridor.Direction);
        }

        /// <summary>
        ///     Tests that set up first corridor should initialize corridor with correct parameters when direction is west
        /// </summary>
        [Fact]
        public void SetUpFirstCorridor_ShouldInitializeCorridorWithCorrectParameters_WhenDirectionIsWest()
        {
            // Arrange
            int width = 10;
            int height = 5;
            Room room = new Room(5, 5, width, height, Direction.West);

            // Act
            Corridor corridor = Corridor.SetUpFirstCorridor(width, height, room);

            // Assert
            Assert.True(room.XPos >= 0);
            Assert.True(room.YPos >= 0);
            Assert.True(corridor.Width >= 5);
            Assert.True(corridor.Height >= 5);
            Assert.NotEqual(Direction.None, corridor.Direction);
        }
    }
}