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
        ///     Tests that constructor should initialize all properties correctly.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeAllPropertiesCorrectly()
        {
            // Arrange
            BoardSquare[,] board = new BoardSquare[10, 10];
            List<RoomData> rooms = new List<RoomData>
            {
                new RoomData(5, 5, 3, 3, Direction.North, false)
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
            BoardSquare[,] board = null;
            List<RoomData> rooms = new List<RoomData>();
            List<CorridorData> corridors = new List<CorridorData>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new DungeonData(board, rooms, corridors));
        }

        /// <summary>
        ///     Tests that constructor should throw argument null exception when rooms is null.
        /// </summary>
        [Fact]
        public void Constructor_ShouldThrowArgumentNullException_WhenRoomsIsNull()
        {
            // Arrange
            BoardSquare[,] board = new BoardSquare[10, 10];
            List<RoomData> rooms = null;
            List<CorridorData> corridors = new List<CorridorData>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new DungeonData(board, rooms, corridors));
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
            List<CorridorData> corridors = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new DungeonData(board, rooms, corridors));
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
                new RoomData(5, 5, 3, 3, Direction.North, false),
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
    }
}

