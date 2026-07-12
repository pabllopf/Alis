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
        ///     The backing field for <see cref="Board" />.
        /// </summary>
        private BoardSquare[,] _board;

        /// <summary>
        ///     The backing field for <see cref="Rooms" />.
        /// </summary>
        private List<RoomData> _rooms;

        /// <summary>
        ///     The backing field for <see cref="Corridors" />.
        /// </summary>
        private List<CorridorData> _corridors;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DungeonData" /> class.
        ///     Default constructor for serialization support.
        /// </summary>
        public DungeonData()
        {
            _board = new BoardSquare[0, 0];
            _rooms = new List<RoomData>();
            _corridors = new List<CorridorData>();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DungeonData" /> class.
        /// </summary>
        /// <param name="Board">The 2D array representing the dungeon board.</param>
        /// <param name="Rooms">The list of rooms in the dungeon.</param>
        /// <param name="Corridors">The list of corridors connecting the rooms.</param>
        internal DungeonData(BoardSquare[,] Board, List<RoomData> Rooms, List<CorridorData> Corridors)
        {
            _board = Board ?? throw new ArgumentNullException(nameof(Board));
            _rooms = Rooms ?? throw new ArgumentNullException(nameof(Rooms));
            _corridors = Corridors ?? throw new ArgumentNullException(nameof(Corridors));
            Validate();
        }
        
        /// <summary>
        ///     Gets or sets the 2D array representing the dungeon board.
        ///     Each element represents a square on the board with its type (floor, wall, corner, etc.).
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when the assigned value is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the board dimensions are not positive.</exception>
        [JsonNativePropertyName("board")]
        public BoardSquare[,] Board
        {
            get => _board;
            set
            {
                _board = value ?? throw new ArgumentNullException(nameof(Board));
                if (_board.GetLength(0) <= 0 || _board.GetLength(1) <= 0)
                {
                    throw new ArgumentException("Board dimensions must be greater than zero.", nameof(Board));
                }
            }
        }

        /// <summary>
        ///     Gets or sets the list of rooms in the dungeon.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when the assigned value is null.</exception>
        [JsonNativePropertyName("rooms")]
        public List<RoomData> Rooms
        {
            get => _rooms;
            set => _rooms = value ?? throw new ArgumentNullException(nameof(Rooms));
        }

        /// <summary>
        ///     Gets or sets the list of corridors connecting the rooms.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when the assigned value is null.</exception>
        [JsonNativePropertyName("corridors")]
        public List<CorridorData> Corridors
        {
            get => _corridors;
            set => _corridors = value ?? throw new ArgumentNullException(nameof(Corridors));
        }

        /// <summary>
        ///     Gets the width of the dungeon board.
        /// </summary>
        public int Width => Board.GetLength(0);

        /// <summary>
        ///     Gets the height of the dungeon board.
        /// </summary>
        public int Height => Board.GetLength(1);

        /// <summary>
        ///     Validates that all properties contain valid data.
        ///     Should be called after deserialization to ensure data integrity.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when any required property is null or invalid.</exception>
        /// <seealso cref="JsonNativeAot" />
        public void Validate()
        {
            ValidateBoard();
            ValidateRooms();
            ValidateCorridors();
        }

        /// <summary>
        ///     Validates that the board is not null and has positive dimensions.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the board is null or has non-positive dimensions.</exception>
        private void ValidateBoard()
        {
            if (_board == null)
            {
                throw new InvalidOperationException("_board cannot be null.");
            }

            if (_board.GetLength(0) <= 0 || _board.GetLength(1) <= 0)
            {
                throw new InvalidOperationException("Board dimensions must be greater than zero.");
            }
        }

        /// <summary>
        ///     Validates that the rooms list is not null and each room has valid position and dimensions.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when rooms list is null or a room has invalid data.</exception>
        private void ValidateRooms()
        {
            if (_rooms == null)
            {
                throw new InvalidOperationException("_rooms cannot be null.");
            }

            for (int i = 0; i < _rooms.Count; i++)
            {
                RoomData room = _rooms[i];
                if (room.XPos < 0 || room.YPos < 0)
                {
                    throw new InvalidOperationException($"Room at index {i} has negative position ({room.XPos},{room.YPos}).");
                }

                if (room.Width <= 0 || room.Height <= 0)
                {
                    throw new InvalidOperationException($"Room at index {i} has invalid dimensions ({room.Width},{room.Height}).");
                }
            }
        }

        /// <summary>
        ///     Validates that the corridors list is not null and each corridor has valid position and dimensions.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when corridors list is null or a corridor has invalid data.</exception>
        private void ValidateCorridors()
        {
            if (_corridors == null)
            {
                throw new InvalidOperationException("_corridors cannot be null.");
            }

            for (int i = 0; i < _corridors.Count; i++)
            {
                CorridorData corridor = _corridors[i];
                if (corridor.XPos < 0 || corridor.YPos < 0)
                {
                    throw new InvalidOperationException($"Corridor at index {i} has negative position ({corridor.XPos},{corridor.YPos}).");
                }

                if (corridor.Width <= 0 || corridor.Height <= 0)
                {
                    throw new InvalidOperationException($"Corridor at index {i} has invalid dimensions ({corridor.Width},{corridor.Height}).");
                }
            }
        }
    }
}
