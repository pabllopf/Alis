// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DungeonDataTest.cs
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
using System.Collections.Generic;
using Alis.Extension.Math.ProceduralDungeon.Models;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test.Models
{
    /// <summary>
    ///     Test class for <see cref="DungeonData" />.
    /// </summary>
    public class DungeonDataTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize with empty values.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithEmptyValues()
        {
            // Act
            DungeonData dungeonData = new DungeonData();

            // Assert
            Assert.NotNull(dungeonData.Board);
            Assert.Equal(0, dungeonData.Width);
            Assert.Equal(0, dungeonData.Height);
            Assert.NotNull(dungeonData.Rooms);
            Assert.Empty(dungeonData.Rooms);
            Assert.NotNull(dungeonData.Corridors);
            Assert.Empty(dungeonData.Corridors);
        }

        /// <summary>
        ///     Tests that constructor should initialize all properties correctly.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeAllPropertiesCorrectly()
        {
            // Arrange
            BoardSquare[,] board = new BoardSquare[10, 10];
            List<RoomData> rooms = new List<RoomData>
            {
                new RoomData(5, 5, 3, 3, Direction.North)
            };
            List<CorridorData> corridors = new List<CorridorData>
            {
                new CorridorData(6, 6, 2, 2, Direction.South)
            };

            // Act
            DungeonData dungeonData = new DungeonData(board, rooms, corridors);

            // Assert
            Assert.NotNull(dungeonData.Board);
            Assert.Equal(rooms, dungeonData.Rooms);
            Assert.Equal(corridors, dungeonData.Corridors);
            Assert.Equal(10, dungeonData.Width);
            Assert.Equal(10, dungeonData.Height);
        }

        /// <summary>
        ///     Tests that constructor should throw argument null exception when board is null.
        /// </summary>
        [Fact]
        public void Constructor_ShouldThrowArgumentNullException_WhenBoardIsNull()
        {
            // Arrange
            List<RoomData> rooms = new List<RoomData>();
            List<CorridorData> corridors = new List<CorridorData>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new DungeonData(null, rooms, corridors));
        }

        /// <summary>
        ///     Tests that constructor should throw argument null exception when rooms is null.
        /// </summary>
        [Fact]
        public void Constructor_ShouldThrowArgumentNullException_WhenRoomsIsNull()
        {
            // Arrange
            BoardSquare[,] board = new BoardSquare[10, 10];
            List<CorridorData> corridors = new List<CorridorData>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new DungeonData(board, null, corridors));
        }

        /// <summary>
        ///     Tests that constructor should throw argument null exception when corridors is null.
        /// </summary>
        [Fact]
        public void Constructor_ShouldThrowArgumentNullException_WhenCorridorsIsNull()
        {
            // Arrange
            BoardSquare[,] board = new BoardSquare[10, 10];
            List<RoomData> rooms = new List<RoomData>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new DungeonData(board, rooms, null));
        }

        /// <summary>
        ///     Tests that width property should return correct board width.
        /// </summary>
        [Fact]
        public void Width_ShouldReturnCorrectBoardWidth()
        {
            // Arrange
            BoardSquare[,] board = new BoardSquare[15, 20];
            List<RoomData> rooms = new List<RoomData>();
            List<CorridorData> corridors = new List<CorridorData>();
            DungeonData dungeonData = new DungeonData(board, rooms, corridors);

            // Act
            int width = dungeonData.Width;

            // Assert
            Assert.Equal(15, width);
        }

        /// <summary>
        ///     Tests that height property should return correct board height.
        /// </summary>
        [Fact]
        public void Height_ShouldReturnCorrectBoardHeight()
        {
            // Arrange
            BoardSquare[,] board = new BoardSquare[15, 20];
            List<RoomData> rooms = new List<RoomData>();
            List<CorridorData> corridors = new List<CorridorData>();
            DungeonData dungeonData = new DungeonData(board, rooms, corridors);

            // Act
            int height = dungeonData.Height;

            // Assert
            Assert.Equal(20, height);
        }

        /// <summary>
        ///     Tests that rooms property should return read only list.
        /// </summary>
        [Fact]
        public void Rooms_ShouldReturnReadOnlyList()
        {
            // Arrange
            BoardSquare[,] board = new BoardSquare[10, 10];
            List<RoomData> rooms = new List<RoomData>
            {
                new RoomData(5, 5, 3, 3, Direction.North),
                new RoomData(8, 8, 4, 4, Direction.South, true)
            };
            List<CorridorData> corridors = new List<CorridorData>();
            DungeonData dungeonData = new DungeonData(board, rooms, corridors);

            // Act
            List<RoomData> result = dungeonData.Rooms;

            // Assert
            Assert.Equal(2, result.Count);
            Assert.IsAssignableFrom<IReadOnlyList<RoomData>>(result);
        }

        /// <summary>
        ///     Tests that corridors property should return read only list.
        /// </summary>
        [Fact]
        public void Corridors_ShouldReturnReadOnlyList()
        {
            // Arrange
            BoardSquare[,] board = new BoardSquare[10, 10];
            List<RoomData> rooms = new List<RoomData>();
            List<CorridorData> corridors = new List<CorridorData>
            {
                new CorridorData(5, 5, 2, 2, Direction.East),
                new CorridorData(7, 7, 3, 3, Direction.West)
            };
            DungeonData dungeonData = new DungeonData(board, rooms, corridors);

            // Act
            List<CorridorData> result = dungeonData.Corridors;

            // Assert
            Assert.Equal(2, result.Count);
            Assert.IsAssignableFrom<IReadOnlyList<CorridorData>>(result);
        }

        /// <summary>
        ///     Tests that constructor should accept empty lists.
        /// </summary>
        [Fact]
        public void Constructor_ShouldAcceptEmptyLists()
        {
            // Arrange
            BoardSquare[,] board = new BoardSquare[5, 5];
            List<RoomData> rooms = new List<RoomData>();
            List<CorridorData> corridors = new List<CorridorData>();

            // Act
            DungeonData dungeonData = new DungeonData(board, rooms, corridors);

            // Assert
            Assert.Empty(dungeonData.Rooms);
            Assert.Empty(dungeonData.Corridors);
        }

        /// <summary>
        ///     Tests that Board property should be mutable.
        /// </summary>
        [Fact]
        public void Board_ShouldBeMutable()
        {
            // Arrange
            DungeonData dungeonData = new DungeonData();
            BoardSquare[,] newBoard = new BoardSquare[20, 30];

            // Act
            dungeonData.Board = newBoard;

            // Assert
            Assert.Equal(newBoard, dungeonData.Board);
            Assert.Equal(20, dungeonData.Width);
            Assert.Equal(30, dungeonData.Height);
        }

        /// <summary>
        ///     Tests that Rooms property should be mutable.
        /// </summary>
        [Fact]
        public void Rooms_ShouldBeMutable()
        {
            // Arrange
            DungeonData dungeonData = new DungeonData();
            List<RoomData> newRooms = new List<RoomData>
            {
                new RoomData(1, 1, 3, 3, Direction.North),
                new RoomData(10, 10, 5, 5, Direction.South, true)
            };

            // Act
            dungeonData.Rooms = newRooms;

            // Assert
            Assert.Equal(newRooms, dungeonData.Rooms);
            Assert.Equal(2, dungeonData.Rooms.Count);
        }

        /// <summary>
        ///     Tests that Corridors property should be mutable.
        /// </summary>
        [Fact]
        public void Corridors_ShouldBeMutable()
        {
            // Arrange
            DungeonData dungeonData = new DungeonData();
            List<CorridorData> newCorridors = new List<CorridorData>
            {
                new CorridorData(5, 5, 2, 2, Direction.East),
                new CorridorData(15, 15, 3, 3, Direction.West)
            };

            // Act
            dungeonData.Corridors = newCorridors;

            // Assert
            Assert.Equal(newCorridors, dungeonData.Corridors);
            Assert.Equal(2, dungeonData.Corridors.Count);
        }

        /// <summary>
        ///     Tests that Width and Height properties work correctly with various board sizes.
        /// </summary>
        [Theory]
        [InlineData(1, 1)]
        [InlineData(100, 100)]
        [InlineData(50, 75)]
        [InlineData(1, 1000)]
        [InlineData(1000, 1)]
        public void Dimensions_ShouldReturnCorrectValuesForVariousBoardSizes(int boardWidth, int boardHeight)
        {
            // Arrange
            BoardSquare[,] board = new BoardSquare[boardWidth, boardHeight];
            DungeonData dungeonData = new DungeonData(board, new List<RoomData>(), new List<CorridorData>());

            // Act
            int width = dungeonData.Width;
            int height = dungeonData.Height;

            // Assert
            Assert.Equal(boardWidth, width);
            Assert.Equal(boardHeight, height);
        }

        /// <summary>
        ///     Tests that constructor preserves list references correctly.
        /// </summary>
        [Fact]
        public void Constructor_ShouldPreserveListReferences()
        {
            // Arrange
            BoardSquare[,] board = new BoardSquare[10, 10];
            List<RoomData> rooms = new List<RoomData> { new RoomData(0, 0, 1, 1, Direction.North) };
            List<CorridorData> corridors = new List<CorridorData> { new CorridorData(5, 5, 1, 1, Direction.East) };

            // Act
            DungeonData dungeonData = new DungeonData(board, rooms, corridors);

            // Assert - Verify that the same list objects are preserved
            Assert.Same(rooms, dungeonData.Rooms);
            Assert.Same(corridors, dungeonData.Corridors);
        }

        /// <summary>
        ///     Tests that properties can be modified after construction.
        /// </summary>
        [Fact]
        public void Properties_ShouldAllBeModifiableAfterConstruction()
        {
            // Arrange
            BoardSquare[,] originalBoard = new BoardSquare[10, 10];
            List<RoomData> originalRooms = new List<RoomData>();
            List<CorridorData> originalCorridors = new List<CorridorData>();
            DungeonData dungeonData = new DungeonData(originalBoard, originalRooms, originalCorridors);

            BoardSquare[,] newBoard = new BoardSquare[20, 20];
            List<RoomData> newRooms = new List<RoomData> { new RoomData(0, 0, 1, 1, Direction.North) };
            List<CorridorData> newCorridors = new List<CorridorData> { new CorridorData(0, 0, 1, 1, Direction.South) };

            // Act
            dungeonData.Board = newBoard;
            dungeonData.Rooms = newRooms;
            dungeonData.Corridors = newCorridors;

            // Assert
            Assert.Equal(newBoard, dungeonData.Board);
            Assert.Equal(newRooms, dungeonData.Rooms);
            Assert.Equal(newCorridors, dungeonData.Corridors);
            Assert.Equal(20, dungeonData.Width);
            Assert.Equal(20, dungeonData.Height);
        }
    }
}