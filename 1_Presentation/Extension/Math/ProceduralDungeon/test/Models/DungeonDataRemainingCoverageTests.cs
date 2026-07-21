// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DungeonDataRemainingCoverageTests.cs
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
    ///     Tests the remaining uncovered validation branches of the <see cref="DungeonData" /> class.
    /// </summary>
    public class DungeonDataRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that Validate throws when a room has a negative x position.
        /// </summary>
        [Fact]
        public void ValidateRooms_WithNegativeXPos_ThrowsInvalidOperationException()
        {
            DungeonData data = new DungeonData();
            data.Board = new BoardSquare[10, 10];
            data.Corridors = new List<CorridorData>();
            data.Rooms = new List<RoomData> { new RoomData(-1, 0, 5, 5, Direction.North) };

            Assert.Throws<InvalidOperationException>(() => data.Validate());
        }

        /// <summary>
        ///     Tests that Validate throws when a room has a zero width.
        /// </summary>
        [Fact]
        public void ValidateRooms_WithZeroWidth_ThrowsInvalidOperationException()
        {
            DungeonData data = new DungeonData();
            data.Board = new BoardSquare[10, 10];
            data.Corridors = new List<CorridorData>();
            data.Rooms = new List<RoomData> { new RoomData(0, 0, 0, 5, Direction.North) };

            Assert.Throws<InvalidOperationException>(() => data.Validate());
        }

        /// <summary>
        ///     Tests that Validate throws when a corridor has a negative y position.
        /// </summary>
        [Fact]
        public void ValidateCorridors_WithNegativeYPos_ThrowsInvalidOperationException()
        {
            DungeonData data = new DungeonData();
            data.Board = new BoardSquare[10, 10];
            data.Rooms = new List<RoomData>();
            data.Corridors = new List<CorridorData> { new CorridorData(0, -1, 3, 3, Direction.North) };

            Assert.Throws<InvalidOperationException>(() => data.Validate());
        }

        /// <summary>
        ///     Tests that Validate throws when a corridor has a zero height.
        /// </summary>
        [Fact]
        public void ValidateCorridors_WithZeroHeight_ThrowsInvalidOperationException()
        {
            DungeonData data = new DungeonData();
            data.Board = new BoardSquare[10, 10];
            data.Rooms = new List<RoomData>();
            data.Corridors = new List<CorridorData> { new CorridorData(0, 0, 3, 0, Direction.North) };

            Assert.Throws<InvalidOperationException>(() => data.Validate());
        }

        /// <summary>
        ///     Tests that Validate throws when a room has a negative y position.
        /// </summary>
        [Fact]
        public void ValidateRooms_WithNegativeYPos_ThrowsInvalidOperationException()
        {
            DungeonData data = new DungeonData();
            data.Board = new BoardSquare[10, 10];
            data.Corridors = new List<CorridorData>();
            data.Rooms = new List<RoomData> { new RoomData(0, -1, 5, 5, Direction.North) };

            Assert.Throws<InvalidOperationException>(() => data.Validate());
        }

        /// <summary>
        ///     Tests that Validate throws when a room has a zero height.
        /// </summary>
        [Fact]
        public void ValidateRooms_WithZeroHeight_ThrowsInvalidOperationException()
        {
            DungeonData data = new DungeonData();
            data.Board = new BoardSquare[10, 10];
            data.Corridors = new List<CorridorData>();
            data.Rooms = new List<RoomData> { new RoomData(0, 0, 5, 0, Direction.North) };

            Assert.Throws<InvalidOperationException>(() => data.Validate());
        }

        /// <summary>
        ///     Tests that Validate throws when a corridor has a negative x position.
        /// </summary>
        [Fact]
        public void ValidateCorridors_WithNegativeXPos_ThrowsInvalidOperationException()
        {
            DungeonData data = new DungeonData();
            data.Board = new BoardSquare[10, 10];
            data.Rooms = new List<RoomData>();
            data.Corridors = new List<CorridorData> { new CorridorData(-1, 0, 3, 3, Direction.North) };

            Assert.Throws<InvalidOperationException>(() => data.Validate());
        }

        /// <summary>
        ///     Tests that Validate throws when a corridor has a zero width.
        /// </summary>
        [Fact]
        public void ValidateCorridors_WithZeroWidth_ThrowsInvalidOperationException()
        {
            DungeonData data = new DungeonData();
            data.Board = new BoardSquare[10, 10];
            data.Rooms = new List<RoomData>();
            data.Corridors = new List<CorridorData> { new CorridorData(0, 0, 0, 3, Direction.North) };

            Assert.Throws<InvalidOperationException>(() => data.Validate());
        }
    }
}