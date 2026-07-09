// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoardBuilderCoverageTest.cs
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
using Alis.Extension.Math.ProceduralDungeon.Models;
using Alis.Extension.Math.ProceduralDungeon.Services;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test.Services
{
    /// <summary>
    ///     Coverage tests for BoardBuilder edge cases.
    /// </summary>
    public class BoardBuilderCoverageTest
    {
        /// <summary>
        ///     Tests that PlaceRooms with negative xPos does not throw.
        ///     Exercises the (x >= 0) && (y >= 0) FALSE branch in PlaceRectangularArea.
        /// </summary>
        [Fact]
        public void PlaceRooms_NegativeXPos_ShouldNotThrow()
        {
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);
            List<RoomData> rooms = new List<RoomData>
            {
                new RoomData(-3, 4, 5, 5, Direction.North)
            };

            builder.PlaceRooms(board, rooms);

            Assert.Equal(BoardSquareType.Floor, board[0, 4].Type);
        }

        /// <summary>
        ///     Tests that PlaceRooms with negative yPos does not throw.
        ///     Exercises the (x >= 0) && (y >= 0) FALSE branch in PlaceRectangularArea.
        /// </summary>
        [Fact]
        public void PlaceRooms_NegativeYPos_ShouldNotThrow()
        {
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);
            List<RoomData> rooms = new List<RoomData>
            {
                new RoomData(4, -3, 5, 5, Direction.North)
            };

            builder.PlaceRooms(board, rooms);

            Assert.Equal(BoardSquareType.Floor, board[4, 0].Type);
        }

        /// <summary>
        ///     Tests that PlaceCorridors with negative xPos does not throw.
        ///     Exercises the (x >= 0) && (y >= 0) FALSE branch in PlaceRectangularArea.
        /// </summary>
        [Fact]
        public void PlaceCorridors_NegativeXPos_ShouldNotThrow()
        {
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);
            List<CorridorData> corridors = new List<CorridorData>
            {
                new CorridorData(-2, 5, 3, 3, Direction.North)
            };

            builder.PlaceCorridors(board, corridors);

            Assert.Equal(BoardSquareType.Floor, board[0, 5].Type);
        }

        /// <summary>
        ///     Tests that PlaceRooms partially outside at negative and positive bounds.
        /// </summary>
        [Fact]
        public void PlaceRooms_NegativeXAndYPos_ShouldNotThrow()
        {
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);
            List<RoomData> rooms = new List<RoomData>
            {
                new RoomData(-5, -5, 15, 15, Direction.North)
            };

            builder.PlaceRooms(board, rooms);

            Assert.Equal(BoardSquareType.Floor, board[0, 0].Type);
        }

        /// <summary>
        ///     Tests that PlaceCorridors partially outside at negative bounds.
        /// </summary>
        [Fact]
        public void PlaceCorridors_NegativeXAndYPos_ShouldNotThrow()
        {
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(10, 10);

            List<CorridorData> corridors = new List<CorridorData>
            {
                new CorridorData(-3, -3, 6, 6, Direction.North)
            };

            builder.PlaceCorridors(board, corridors);

            Assert.Equal(BoardSquareType.Floor, board[0, 0].Type);
        }

        /// <summary>
        ///     Tests that GenerateWallsAndCorners on a 2x2 board does not throw
        ///     (for-loop bounds skip all iterations).
        /// </summary>
        [Fact]
        public void GenerateWallsAndCorners_SmallBoard_ShouldNotThrow()
        {
            BoardBuilder builder = new BoardBuilder();
            BoardSquare[,] board = builder.CreateEmptyBoard(2, 2);

            builder.GenerateWallsAndCorners(board);
        }
    }
}
