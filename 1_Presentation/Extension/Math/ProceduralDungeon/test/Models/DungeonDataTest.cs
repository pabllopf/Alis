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
    ///     Tests the <see cref="DungeonData" /> class.
    /// </summary>
    public class DungeonDataTest
    {
        /// <summary>
        ///     Tests that default constructor initializes empty collections.
        /// </summary>
        [Fact]
        public void DefaultConstructor_InitializesEmptyCollections()
        {
            DungeonData data = new DungeonData();

            Assert.NotNull(data.Board);
            Assert.NotNull(data.Rooms);
            Assert.NotNull(data.Corridors);
            Assert.Equal(0, data.Width);
            Assert.Equal(0, data.Height);
            Assert.Empty(data.Rooms);
            Assert.Empty(data.Corridors);
        }

        /// <summary>
        ///     Tests that internal constructor with valid parameters creates a valid instance.
        /// </summary>
        [Fact]
        public void InternalConstructor_WithValidParameters_CreatesInstance()
        {
            BoardSquare[,] board = new BoardSquare[10, 10];
            List<RoomData> rooms = new List<RoomData> { new RoomData(0, 0, 5, 5, Direction.North) };
            List<CorridorData> corridors = new List<CorridorData> { new CorridorData(0, 0, 3, 3, Direction.North) };

            DungeonData data = new DungeonData(board, rooms, corridors);

            Assert.Same(board, data.Board);
            Assert.Same(rooms, data.Rooms);
            Assert.Same(corridors, data.Corridors);
            Assert.Equal(10, data.Width);
            Assert.Equal(10, data.Height);
        }

        /// <summary>
        ///     Tests that internal constructor throws when board is null.
        /// </summary>
        [Fact]
        public void InternalConstructor_WithNullBoard_ThrowsArgumentNullException()
        {
            List<RoomData> rooms = new List<RoomData>();
            List<CorridorData> corridors = new List<CorridorData>();

            Assert.Throws<ArgumentNullException>(() => new DungeonData(null, rooms, corridors));
        }

        /// <summary>
        ///     Tests that internal constructor throws when rooms is null.
        /// </summary>
        [Fact]
        public void InternalConstructor_WithNullRooms_ThrowsArgumentNullException()
        {
            BoardSquare[,] board = new BoardSquare[10, 10];
            List<CorridorData> corridors = new List<CorridorData>();

            Assert.Throws<ArgumentNullException>(() => new DungeonData(board, null, corridors));
        }

        /// <summary>
        ///     Tests that internal constructor throws when corridors is null.
        /// </summary>
        [Fact]
        public void InternalConstructor_WithNullCorridors_ThrowsArgumentNullException()
        {
            BoardSquare[,] board = new BoardSquare[10, 10];
            List<RoomData> rooms = new List<RoomData>();

            Assert.Throws<ArgumentNullException>(() => new DungeonData(board, rooms, null));
        }

        /// <summary>
        ///     Tests that Board setter accepts valid board.
        /// </summary>
        [Fact]
        public void Board_SetValid_StoresValue()
        {
            DungeonData data = new DungeonData();
            BoardSquare[,] board = new BoardSquare[5, 5];

            data.Board = board;

            Assert.Same(board, data.Board);
        }

        /// <summary>
        ///     Tests that Board setter throws when value is null.
        /// </summary>
        [Fact]
        public void Board_SetNull_ThrowsArgumentNullException()
        {
            DungeonData data = new DungeonData();

            Assert.Throws<ArgumentNullException>(() => data.Board = null);
        }

        /// <summary>
        ///     Tests that Board setter throws when width is zero.
        /// </summary>
        [Fact]
        public void Board_SetZeroWidth_ThrowsArgumentException()
        {
            DungeonData data = new DungeonData();

            Assert.Throws<ArgumentException>(() => data.Board = new BoardSquare[0, 5]);
        }

        /// <summary>
        ///     Tests that Board setter throws when height is zero.
        /// </summary>
        [Fact]
        public void Board_SetZeroHeight_ThrowsArgumentException()
        {
            DungeonData data = new DungeonData();

            Assert.Throws<ArgumentException>(() => data.Board = new BoardSquare[5, 0]);
        }

        /// <summary>
        ///     Tests that Rooms setter accepts valid list.
        /// </summary>
        [Fact]
        public void Rooms_SetValid_StoresValue()
        {
            DungeonData data = new DungeonData();
            List<RoomData> rooms = new List<RoomData>();

            data.Rooms = rooms;

            Assert.Same(rooms, data.Rooms);
        }

        /// <summary>
        ///     Tests that Rooms setter throws when value is null.
        /// </summary>
        [Fact]
        public void Rooms_SetNull_ThrowsArgumentNullException()
        {
            DungeonData data = new DungeonData();

            Assert.Throws<ArgumentNullException>(() => data.Rooms = null);
        }

        /// <summary>
        ///     Tests that Corridors setter accepts valid list.
        /// </summary>
        [Fact]
        public void Corridors_SetValid_StoresValue()
        {
            DungeonData data = new DungeonData();
            List<CorridorData> corridors = new List<CorridorData>();

            data.Corridors = corridors;

            Assert.Same(corridors, data.Corridors);
        }

        /// <summary>
        ///     Tests that Corridors setter throws when value is null.
        /// </summary>
        [Fact]
        public void Corridors_SetNull_ThrowsArgumentNullException()
        {
            DungeonData data = new DungeonData();

            Assert.Throws<ArgumentNullException>(() => data.Corridors = null);
        }

        /// <summary>
        ///     Tests that Width returns the correct board width.
        /// </summary>
        [Fact]
        public void Width_ReturnsCorrectValue()
        {
            DungeonData data = new DungeonData();
            data.Board = new BoardSquare[15, 20];

            Assert.Equal(15, data.Width);
        }

        /// <summary>
        ///     Tests that Height returns the correct board height.
        /// </summary>
        [Fact]
        public void Height_ReturnsCorrectValue()
        {
            DungeonData data = new DungeonData();
            data.Board = new BoardSquare[15, 20];

            Assert.Equal(20, data.Height);
        }

        /// <summary>
        ///     Tests that Validate passes with valid data.
        /// </summary>
        [Fact]
        public void Validate_WithValidData_DoesNotThrow()
        {
            DungeonData data = new DungeonData();
            data.Board = new BoardSquare[10, 10];
            data.Rooms = new List<RoomData>();
            data.Corridors = new List<CorridorData>();

            data.Validate();
        }

        /// <summary>
        ///     Tests that Validate throws when board dimensions are invalid (default constructor gives 0x0).
        /// </summary>
        [Fact]
        public void Validate_WithDefaultZeroBoard_ThrowsArgumentException()
        {
            DungeonData data = new DungeonData();
            data.Rooms = new List<RoomData>();
            data.Corridors = new List<CorridorData>();

            Assert.Throws<ArgumentException>(() => data.Validate());
        }


    }
}
