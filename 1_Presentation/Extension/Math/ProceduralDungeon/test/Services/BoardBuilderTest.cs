

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
            BoardBuilder builder = new BoardBuilder();
            int width = 10;
            int height = 15;

            BoardSquare[,] board = builder.CreateEmptyBoard(width, height);

            Assert.Equal(width, board.GetLength(0));
            Assert.Equal(height, board.GetLength(1));
        }

        /// <summary>
        ///     Tests that create empty board should initialize all squares to empty.
        /// </summary>
        [Fact]
        public void CreateEmptyBoard_ShouldInitializeAllSquaresToEmpty()
        {
            BoardBuilder builder = new BoardBuilder();
            int width = 5;
            int height = 5;

            BoardSquare[,] board = builder.CreateEmptyBoard(width, height);

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
            BoardBuilder builder = new BoardBuilder();

            Assert.Throws<ArgumentException>(() => builder.CreateEmptyBoard(0, 10));
        }

        /// <summary>
        ///     Tests that create empty board should throw exception when height is negative.
        /// </summary>
        [Fact]
        public void CreateEmptyBoard_ShouldThrowException_WhenHeightIsNegative()
        {
            BoardBuilder builder = new BoardBuilder();

            Assert.Throws<ArgumentException>(() => builder.CreateEmptyBoard(10, -5));
        }

        /// <summary>
        ///     Tests that place rooms should set room squares to floor.
        /// </summary>
        [Fact]
        public void PlaceRooms_ShouldSetRoomSquaresToFloor()
        {
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(20, 20);
            List<RoomData> rooms = new List<RoomData>
            {
                new RoomData(5, 5, 3, 3, Direction.North)
            };

            builder.PlaceRooms(board, rooms);

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
            BoardBuilder builder = new BoardBuilder();
            List<RoomData> rooms = new List<RoomData>();

            Assert.Throws<ArgumentNullException>(() => builder.PlaceRooms(null, rooms));
        }

        /// <summary>
        ///     Tests that place rooms should throw exception when rooms is null.
        /// </summary>
        [Fact]
        public void PlaceRooms_ShouldThrowException_WhenRoomsIsNull()
        {
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);

            Assert.Throws<ArgumentNullException>(() => builder.PlaceRooms(board, null));
        }

        /// <summary>
        ///     Tests that place corridors should set corridor squares to floor.
        /// </summary>
        [Fact]
        public void PlaceCorridors_ShouldSetCorridorSquaresToFloor()
        {
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(20, 20);
            List<CorridorData> corridors = new List<CorridorData>
            {
                new CorridorData(10, 10, 2, 2, Direction.North)
            };

            builder.PlaceCorridors(board, corridors);

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
            BoardBuilder builder = new BoardBuilder();
            List<CorridorData> corridors = new List<CorridorData>();

            Assert.Throws<ArgumentNullException>(() => builder.PlaceCorridors(null, corridors));
        }

        /// <summary>
        ///     Tests that place corridors should throw exception when corridors is null.
        /// </summary>
        [Fact]
        public void PlaceCorridors_ShouldThrowException_WhenCorridorsIsNull()
        {
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);

            Assert.Throws<ArgumentNullException>(() => builder.PlaceCorridors(board, null));
        }

        /// <summary>
        ///     Tests that generate walls and corners should create walls around floor.
        /// </summary>
        [Fact]
        public void GenerateWallsAndCorners_ShouldCreateWallsAroundFloor()
        {
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);

            board[5, 5].Type = BoardSquareType.Floor;

            builder.GenerateWallsAndCorners(board);

            Assert.NotEqual(BoardSquareType.Empty, board[5, 5].Type);
        }

        /// <summary>
        ///     Tests that generate walls and corners should throw exception when board is null.
        /// </summary>
        [Fact]
        public void GenerateWallsAndCorners_ShouldThrowException_WhenBoardIsNull()
        {
            BoardBuilder builder = new BoardBuilder();

            Assert.Throws<ArgumentNullException>(() => builder.GenerateWallsAndCorners(null));
        }

        /// <summary>
        ///     Tests that place rooms should handle multiple rooms.
        /// </summary>
        [Fact]
        public void PlaceRooms_ShouldHandleMultipleRooms()
        {
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(30, 30);
            List<RoomData> rooms = new List<RoomData>
            {
                new RoomData(5, 5, 3, 3, Direction.North),
                new RoomData(15, 15, 4, 4, Direction.South)
            };

            builder.PlaceRooms(board, rooms);

            Assert.Equal(BoardSquareType.Floor, board[5, 5].Type);
            Assert.Equal(BoardSquareType.Floor, board[7, 7].Type);

            Assert.Equal(BoardSquareType.Floor, board[15, 15].Type);
            Assert.Equal(BoardSquareType.Floor, board[18, 18].Type);
        }

        /// <summary>
        ///     Tests that place rooms should handle empty room list.
        /// </summary>
        [Fact]
        public void PlaceRooms_ShouldHandleEmptyRoomList()
        {
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);
            List<RoomData> rooms = new List<RoomData>();

            Exception exception = Record.Exception(() => builder.PlaceRooms(board, rooms));

            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that place corridors should handle empty corridor list.
        /// </summary>
        [Fact]
        public void PlaceCorridors_ShouldHandleEmptyCorridorList()
        {
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);
            List<CorridorData> corridors = new List<CorridorData>();

            Exception exception = Record.Exception(() => builder.PlaceCorridors(board, corridors));

            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that place rooms should not overflow board bounds.
        /// </summary>
        [Fact]
        public void PlaceRooms_ShouldNotOverflowBoardBounds()
        {
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);
            List<RoomData> rooms = new List<RoomData>
            {
                new RoomData(8, 8, 5, 5, Direction.North) // Would overflow
            };

            Exception exception = Record.Exception(() => builder.PlaceRooms(board, rooms));

            Assert.Null(exception);
        }
    }
}