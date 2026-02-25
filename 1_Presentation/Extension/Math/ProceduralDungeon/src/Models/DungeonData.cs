// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DungeonData.cs
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
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Math.ProceduralDungeon.Models
{
    /// <summary>
    ///     Represents the complete data structure for a generated dungeon.
    ///     Contains all the information about the dungeon including board, rooms, and corridors.
    /// </summary>
    [Serializable]
    public partial class DungeonData : IJsonSerializable, IJsonDesSerializable<DungeonData>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DungeonData" /> class.
        ///     Default constructor for serialization support.
        /// </summary>
        public DungeonData()
        {
            Board = new BoardSquare[0, 0];
            Rooms = new List<RoomData>();
            Corridors = new List<CorridorData>();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DungeonData" /> class.
        /// </summary>
        /// <param name="board">The 2D array representing the dungeon board.</param>
        /// <param name="rooms">The list of rooms in the dungeon.</param>
        /// <param name="corridors">The list of corridors connecting the rooms.</param>
        public DungeonData(BoardSquare[,] board, List<RoomData> rooms, List<CorridorData> corridors)
        {
            Board = board ?? throw new ArgumentNullException(nameof(board));
            Rooms = rooms ?? throw new ArgumentNullException(nameof(rooms));
            Corridors = corridors ?? throw new ArgumentNullException(nameof(corridors));
        }

        /// <summary>
        ///     Gets or sets the 2D array representing the dungeon board.
        ///     Each element represents a square on the board with its type (floor, wall, corner, etc.).
        /// </summary>
        [JsonNativePropertyName("board")]
        public BoardSquare[,] Board { get; set; }

        /// <summary>
        ///     Gets or sets the list of rooms in the dungeon.
        /// </summary>
        [JsonNativePropertyName("rooms")]
        public List<RoomData> Rooms { get; set; }

        /// <summary>
        ///     Gets or sets the list of corridors connecting the rooms.
        /// </summary>
        [JsonNativePropertyName("corridors")]
        public List<CorridorData> Corridors { get; set; }

        /// <summary>
        ///     Gets the width of the dungeon board.
        /// </summary>
        public int Width => Board.GetLength(0);

        /// <summary>
        ///     Gets the height of the dungeon board.
        /// </summary>
        public int Height => Board.GetLength(1);
    }
}

