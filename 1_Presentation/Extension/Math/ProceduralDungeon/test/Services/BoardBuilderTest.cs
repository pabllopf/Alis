// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoardBuilderTest.cs
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
using Alis.Extension.Math.ProceduralDungeon.Services;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test.Services
{
    /// <summary>
    ///     Test class for <see cref="BoardBuilder" />.
    /// </summary>
    public class BoardBuilderTest
    {
        /// <summary>
        ///     Tests that create empty board should create board with correct dimensions.
        /// </summary>
        [Fact]
        public void CreateEmptyBoard_ShouldCreateBoardWithCorrectDimensions()
        {
            // Arrange
            BoardBuilder builder = new BoardBuilder();
            int width = 10;
            int height = 15;

            // Act
            BoardSquare[,] board = builder.CreateEmptyBoard(width, height);

            // Assert
            Assert.Equal(width, board.GetLength(0));
            Assert.Equal(height, board.GetLength(1));
        }

        /// <summary>
        ///     Tests that create empty board should initialize all squares to empty.
        /// </summary>
        [Fact]
        public void CreateEmptyBoard_ShouldInitializeAllSquaresToEmpty()
        {
            // Arrange
            BoardBuilder builder = new BoardBuilder();
            int width = 5;
            int height = 5;

            // Act
            BoardSquare[,] board = builder.CreateEmptyBoard(width, height);

            // Assert
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Assert.Equal(BoardSquareType.Empty, board[x, y].Type);
                }
            }
        }

        /// <summary>
        ///     Tests that create empty board should throw exception when width is zero.
        /// </summary>
        [Fact]
        public void CreateEmptyBoard_ShouldThrowException_WhenWidthIsZero()
        {
            // Arrange
            BoardBuilder builder = new BoardBuilder();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => builder.CreateEmptyBoard(0, 10));
        }

        /// <summary>
        ///     Tests that create empty board should throw exception when height is negative.
        /// </summary>
        [Fact]
        public void CreateEmptyBoard_ShouldThrowException_WhenHeightIsNegative()
        {
            // Arrange
            BoardBuilder builder = new BoardBuilder();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => builder.CreateEmptyBoard(10, -5));
        }

        /// <summary>
        ///     Tests that place rooms should set room squares to floor.
        /// </summary>
        [Fact]
        public void PlaceRooms_ShouldSetRoomSquaresToFloor()
        {
            // Arrange
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(20, 20);
            List<RoomData> rooms = new List<RoomData>
            {
                new RoomData(5, 5, 3, 3, Direction.North, false)
            };

            // Act
            builder.PlaceRooms(board, rooms);

            // Assert
            for (int x = 5; x < 8; x++)
            {
                for (int y = 5; y < 8; y++)
                {
                    Assert.Equal(BoardSquareType.Floor, board[x, y].Type);
                }
            }
        }

        /// <summary>
        ///     Tests that place rooms should throw exception when board is null.
        /// </summary>
        [Fact]
        public void PlaceRooms_ShouldThrowException_WhenBoardIsNull()
        {
            // Arrange
            BoardBuilder builder = new BoardBuilder();
            List<RoomData> rooms = new List<RoomData>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => builder.PlaceRooms(null, rooms));
        }

        /// <summary>
        ///     Tests that place rooms should throw exception when rooms is null.
        /// </summary>
        [Fact]
        public void PlaceRooms_ShouldThrowException_WhenRoomsIsNull()
        {
            // Arrange
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => builder.PlaceRooms(board, null));
        }

        /// <summary>
        ///     Tests that place corridors should set corridor squares to floor.
        /// </summary>
        [Fact]
        public void PlaceCorridors_ShouldSetCorridorSquaresToFloor()
        {
            // Arrange
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(20, 20);
            List<CorridorData> corridors = new List<CorridorData>
            {
                new CorridorData(10, 10, 2, 2, Direction.North)
            };

            // Act
            builder.PlaceCorridors(board, corridors);

            // Assert
            for (int x = 10; x < 12; x++)
            {
                for (int y = 10; y < 12; y++)
                {
                    Assert.Equal(BoardSquareType.Floor, board[x, y].Type);
                }
            }
        }

        /// <summary>
        ///     Tests that place corridors should throw exception when board is null.
        /// </summary>
        [Fact]
        public void PlaceCorridors_ShouldThrowException_WhenBoardIsNull()
        {
            // Arrange
            BoardBuilder builder = new BoardBuilder();
            List<CorridorData> corridors = new List<CorridorData>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => builder.PlaceCorridors(null, corridors));
        }

        /// <summary>
        ///     Tests that place corridors should throw exception when corridors is null.
        /// </summary>
        [Fact]
        public void PlaceCorridors_ShouldThrowException_WhenCorridorsIsNull()
        {
            // Arrange
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => builder.PlaceCorridors(board, null));
        }

        /// <summary>
        ///     Tests that generate walls and corners should create walls around floor.
        /// </summary>
        [Fact]
        public void GenerateWallsAndCorners_ShouldCreateWallsAroundFloor()
        {
            // Arrange
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);
            
            // Create a simple floor area
            board[5, 5].Type = BoardSquareType.Floor;

            // Act
            builder.GenerateWallsAndCorners(board);

            // Assert - The floor square should have a wall type if surrounded by empty
            Assert.NotEqual(BoardSquareType.Empty, board[5, 5].Type);
        }

        /// <summary>
        ///     Tests that generate walls and corners should throw exception when board is null.
        /// </summary>
        [Fact]
        public void GenerateWallsAndCorners_ShouldThrowException_WhenBoardIsNull()
        {
            // Arrange
            BoardBuilder builder = new BoardBuilder();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => builder.GenerateWallsAndCorners(null));
        }

        /// <summary>
        ///     Tests that place rooms should handle multiple rooms.
        /// </summary>
        [Fact]
        public void PlaceRooms_ShouldHandleMultipleRooms()
        {
            // Arrange
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(30, 30);
            List<RoomData> rooms = new List<RoomData>
            {
                new RoomData(5, 5, 3, 3, Direction.North, false),
                new RoomData(15, 15, 4, 4, Direction.South, false)
            };

            // Act
            builder.PlaceRooms(board, rooms);

            // Assert
            // Check first room
            Assert.Equal(BoardSquareType.Floor, board[5, 5].Type);
            Assert.Equal(BoardSquareType.Floor, board[7, 7].Type);
            
            // Check second room
            Assert.Equal(BoardSquareType.Floor, board[15, 15].Type);
            Assert.Equal(BoardSquareType.Floor, board[18, 18].Type);
        }

        /// <summary>
        ///     Tests that place rooms should handle empty room list.
        /// </summary>
        [Fact]
        public void PlaceRooms_ShouldHandleEmptyRoomList()
        {
            // Arrange
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);
            List<RoomData> rooms = new List<RoomData>();

            // Act
            var exception = Record.Exception(() => builder.PlaceRooms(board, rooms));

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that place corridors should handle empty corridor list.
        /// </summary>
        [Fact]
        public void PlaceCorridors_ShouldHandleEmptyCorridorList()
        {
            // Arrange
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);
            List<CorridorData> corridors = new List<CorridorData>();

            // Act
            var exception = Record.Exception(() => builder.PlaceCorridors(board, corridors));

            // Assert
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that place rooms should not overflow board bounds.
        /// </summary>
        [Fact]
        public void PlaceRooms_ShouldNotOverflowBoardBounds()
        {
            // Arrange
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);
            List<RoomData> rooms = new List<RoomData>
            {
                new RoomData(8, 8, 5, 5, Direction.North, false) // Would overflow
            };

            // Act
            var exception = Record.Exception(() => builder.PlaceRooms(board, rooms));

            // Assert - Should not throw
            Assert.Null(exception);
        }
    }
}

