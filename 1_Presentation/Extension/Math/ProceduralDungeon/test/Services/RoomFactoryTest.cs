// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RoomFactoryTest.cs
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
using Alis.Extension.Math.ProceduralDungeon.Models;
using Alis.Extension.Math.ProceduralDungeon.Services;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test.Services
{
    /// <summary>
    ///     Test class for <see cref="RoomFactory" />.
    /// </summary>
    public class RoomFactoryTest
    {
        /// <summary>
        ///     Tests that create first room should create room with correct properties.
        /// </summary>
        [Fact]
        public void CreateFirstRoom_ShouldCreateRoomWithCorrectProperties()
        {
            // Arrange
            RoomFactory factory = new RoomFactory();
            int xPos = 75;
            int yPos = 75;
            int width = 8;
            int height = 8;

            // Act
            RoomData room = factory.CreateFirstRoom(xPos, yPos, width, height);

            // Assert
            Assert.Equal(xPos, room.XPos);
            Assert.Equal(yPos, room.YPos);
            Assert.Equal(width, room.Width);
            Assert.Equal(height, room.Height);
            Assert.Equal(Direction.North, room.Direction);
            Assert.False(room.IsBossRoom);
        }

        /// <summary>
        ///     Tests that create first room should throw exception when width is zero.
        /// </summary>
        [Fact]
        public void CreateFirstRoom_ShouldThrowException_WhenWidthIsZero()
        {
            // Arrange
            RoomFactory factory = new RoomFactory();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateFirstRoom(10, 10, 0, 5));
        }

        /// <summary>
        ///     Tests that create first room should throw exception when height is negative.
        /// </summary>
        [Fact]
        public void CreateFirstRoom_ShouldThrowException_WhenHeightIsNegative()
        {
            // Arrange
            RoomFactory factory = new RoomFactory();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateFirstRoom(10, 10, 5, -3));
        }

        /// <summary>
        ///     Tests that create first room should throw exception when x position is negative.
        /// </summary>
        [Fact]
        public void CreateFirstRoom_ShouldThrowException_WhenXPositionIsNegative()
        {
            // Arrange
            RoomFactory factory = new RoomFactory();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateFirstRoom(-5, 10, 5, 5));
        }

        /// <summary>
        ///     Tests that create first room should throw exception when y position is negative.
        /// </summary>
        [Fact]
        public void CreateFirstRoom_ShouldThrowException_WhenYPositionIsNegative()
        {
            // Arrange
            RoomFactory factory = new RoomFactory();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateFirstRoom(10, -5, 5, 5));
        }

        /// <summary>
        ///     Tests that create room should create room connected to north corridor.
        /// </summary>
        [Fact]
        public void CreateRoom_ShouldCreateRoomConnectedToNorthCorridor()
        {
            // Arrange
            RoomFactory factory = new RoomFactory();
            CorridorData corridor = new CorridorData(10, 20, 4, 4, Direction.North);
            int width = 5;
            int height = 5;

            // Act
            RoomData room = factory.CreateRoom(width, height, corridor);

            // Assert
            Assert.Equal(10, room.XPos); // corridor.XPos + corridor.Width / 2 - width / 2
            Assert.Equal(24, room.YPos); // corridor.YPos + corridor.Height
            Assert.Equal(width, room.Width);
            Assert.Equal(height, room.Height);
            Assert.Equal(Direction.North, room.Direction);
            Assert.False(room.IsBossRoom);
        }

        /// <summary>
        ///     Tests that create room should create room connected to south corridor.
        /// </summary>
        [Fact]
        public void CreateRoom_ShouldCreateRoomConnectedToSouthCorridor()
        {
            // Arrange
            RoomFactory factory = new RoomFactory();
            CorridorData corridor = new CorridorData(10, 20, 4, 4, Direction.South);
            int width = 5;
            int height = 5;

            // Act
            RoomData room = factory.CreateRoom(width, height, corridor);

            // Assert
            Assert.Equal(10, room.XPos);
            Assert.Equal(15, room.YPos); // corridor.YPos - height
            Assert.Equal(width, room.Width);
            Assert.Equal(height, room.Height);
        }

        /// <summary>
        ///     Tests that create room should create room connected to east corridor.
        /// </summary>
        [Fact]
        public void CreateRoom_ShouldCreateRoomConnectedToEastCorridor()
        {
            // Arrange
            RoomFactory factory = new RoomFactory();
            CorridorData corridor = new CorridorData(10, 20, 4, 4, Direction.East);
            int width = 5;
            int height = 5;

            // Act
            RoomData room = factory.CreateRoom(width, height, corridor);

            // Assert
            Assert.Equal(5, room.XPos); // corridor.XPos - height
            Assert.Equal(20, room.YPos);
            Assert.Equal(height, room.Width); // Swapped for horizontal corridor
            Assert.Equal(width, room.Height);
        }

        /// <summary>
        ///     Tests that create room should create room connected to west corridor.
        /// </summary>
        [Fact]
        public void CreateRoom_ShouldCreateRoomConnectedToWestCorridor()
        {
            // Arrange
            RoomFactory factory = new RoomFactory();
            CorridorData corridor = new CorridorData(10, 20, 4, 4, Direction.West);
            int width = 5;
            int height = 5;

            // Act
            RoomData room = factory.CreateRoom(width, height, corridor);

            // Assert
            Assert.Equal(14, room.XPos); // corridor.XPos + corridor.Width
            Assert.Equal(20, room.YPos);
            Assert.Equal(height, room.Width);
            Assert.Equal(width, room.Height);
        }

        /// <summary>
        ///     Tests that create boss room should create boss room with correct flag.
        /// </summary>
        [Fact]
        public void CreateBossRoom_ShouldCreateBossRoomWithCorrectFlag()
        {
            // Arrange
            RoomFactory factory = new RoomFactory();
            CorridorData corridor = new CorridorData(10, 20, 4, 4, Direction.North);
            int width = 7;
            int height = 7;

            // Act
            RoomData room = factory.CreateBossRoom(width, height, corridor);

            // Assert
            Assert.True(room.IsBossRoom);
            Assert.Equal(width, room.Width);
            Assert.Equal(height, room.Height);
        }

        /// <summary>
        ///     Tests that create room should throw exception when width is zero.
        /// </summary>
        [Fact]
        public void CreateRoom_ShouldThrowException_WhenWidthIsZero()
        {
            // Arrange
            RoomFactory factory = new RoomFactory();
            CorridorData corridor = new CorridorData(10, 20, 4, 4, Direction.North);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateRoom(0, 5, corridor));
        }

        /// <summary>
        ///     Tests that create boss room should throw exception when height is negative.
        /// </summary>
        [Fact]
        public void CreateBossRoom_ShouldThrowException_WhenHeightIsNegative()
        {
            // Arrange
            RoomFactory factory = new RoomFactory();
            CorridorData corridor = new CorridorData(10, 20, 4, 4, Direction.North);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateBossRoom(5, -3, corridor));
        }
    }
}

