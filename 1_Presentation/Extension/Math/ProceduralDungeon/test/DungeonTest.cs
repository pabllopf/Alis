// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DungeonTest.cs
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

using System.Collections.Generic;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test
{
    /// <summary>
    ///     The dungeon test class
    /// </summary>
    public class DungeonTest
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
            Assert.True(room.XPos >= 0);
            Assert.True(room.YPos >= 0);
            Assert.Equal(height, room.Width);
            Assert.Equal(width, room.Height);
            Assert.Equal(Direction.West, room.Direction);
        }

        /// <summary>
        ///     Tests that start should initialize rooms and corridors
        /// </summary>
        [Fact]
        public void Start_ShouldInitializeRoomsAndCorridors()
        {
            // Arrange
            Dungeon dungeon = new Dungeon();

            // Act
            dungeon.Start();

            // Assert
            Assert.NotNull(dungeon.Rooms);
            Assert.NotNull(dungeon.Corridors);
        }

        /// <summary>
        ///     Tests that set up rooms and corridors should set up rooms and corridors correctly
        /// </summary>
        [Fact]
        public void SetUpRoomsAndCorridors_ShouldSetUpRoomsAndCorridorsCorrectly()
        {
            // Arrange
            Dungeon dungeon = new Dungeon();

            // Act
            dungeon.SetUpRoomsAndCorridors();
            dungeon.ConfigRoomsAndCorridors();
            dungeon.CreateBoard();

            // Assert
            Assert.NotNull(dungeon.Rooms);
            Assert.NotNull(dungeon.Corridors);
            Assert.Equal(Dungeon.NumOfRooms, dungeon.Rooms.Count);
            Assert.Equal(Dungeon.NumOfRooms - 1, dungeon.Corridors.Count);
            Assert.Equal(Dungeon.FirstRoomWidth, dungeon.Rooms[0].Width);
            Assert.Equal(Dungeon.FirstRoomHeight, dungeon.Rooms[0].Height);
        }

        /// <summary>
        ///     Tests that config rooms and corridors should configure board correctly
        /// </summary>
        [Fact]
        public void ConfigRoomsAndCorridors_ShouldConfigureBoardCorrectly()
        {
            // Arrange
            Dungeon dungeon = new Dungeon();
            dungeon.SetUpRoomsAndCorridors();

            // Act
            dungeon.ConfigRoomsAndCorridors();

            // Assert
            foreach (Room room in dungeon.Rooms)
            {
                for (int x = room.XPos; x < room.XPos + room.Width; x++)
                {
                    for (int y = room.YPos; y < room.YPos + room.Height; y++)
                    {
                        Assert.Equal(BoardSquareType.Floor, dungeon.Board[x, y].Type);
                    }
                }
            }

            foreach (Corridor corridor in dungeon.Corridors)
            {
                for (int x = corridor.XPos; x < corridor.XPos + corridor.Width; x++)
                {
                    for (int y = corridor.YPos; y < corridor.YPos + corridor.Height; y++)
                    {
                        Assert.Equal(BoardSquareType.Floor, dungeon.Board[x, y].Type);
                    }
                }
            }
        }

        /// <summary>
        ///     Tests that board should be initialized with correct dimensions
        /// </summary>
        [Fact]
        public void Board_ShouldBeInitializedWithCorrectDimensions()
        {
            // Arrange
            Dungeon dungeon = new Dungeon();

            // Act
            BoardSquare[,] board = dungeon.Board;

            // Assert
            Assert.Equal(Dungeon.BoardWidth, board.GetLength(0));
            Assert.Equal(Dungeon.BoardHeight, board.GetLength(1));
        }

        /// <summary>
        ///     Tests that rooms should be initialized as empty list
        /// </summary>
        [Fact]
        public void Rooms_ShouldBeInitializedAsEmptyList()
        {
            // Arrange
            Dungeon dungeon = new Dungeon();

            // Act
            List<Room> rooms = dungeon.Rooms;

            // Assert
            Assert.NotNull(rooms);
            Assert.Empty(rooms);
        }

        /// <summary>
        ///     Tests that corridors should be initialized as empty list
        /// </summary>
        [Fact]
        public void Corridors_ShouldBeInitializedAsEmptyList()
        {
            // Arrange
            Dungeon dungeon = new Dungeon();

            // Act
            List<Corridor> corridors = dungeon.Corridors;

            // Assert
            Assert.NotNull(corridors);
            Assert.Empty(corridors);
        }

        /// <summary>
        ///     Tests that create board should create board with correct walls and corners
        /// </summary>
        [Fact]
        public void CreateBoard_ShouldCreateBoardWithCorrectWallsAndCorners()
        {
            // Arrange
            Dungeon dungeon = new Dungeon();
            dungeon.SetUpRoomsAndCorridors();
            dungeon.ConfigRoomsAndCorridors();

            // Act
            dungeon.CreateBoard();

            // Assert
            for (int x = 0; x < Dungeon.BoardWidth; x++)
            {
                for (int y = 0; y < Dungeon.BoardHeight; y++)
                {
                    if (dungeon.Board[x, y].Type == BoardSquareType.Floor)
                    {
                        if (dungeon.Board[x, y - 1].Type == BoardSquareType.Empty)
                        {
                            Assert.Equal(BoardSquareType.WallDown, dungeon.Board[x, y].Type);
                        }

                        if (dungeon.Board[x - 1, y].Type == BoardSquareType.Empty)
                        {
                            Assert.Equal(BoardSquareType.WallLeft, dungeon.Board[x, y].Type);
                        }

                        if (dungeon.Board[x + 1, y].Type == BoardSquareType.Empty)
                        {
                            Assert.Equal(BoardSquareType.WallRight, dungeon.Board[x, y].Type);
                        }

                        if (dungeon.Board[x, y + 1].Type == BoardSquareType.Empty)
                        {
                            Assert.Equal(BoardSquareType.WallTop, dungeon.Board[x, y].Type);
                        }
                    }
                }
            }
        }
    }
}