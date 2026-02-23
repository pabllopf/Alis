// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DungeonGenerator.cs
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
using Alis.Extension.Math.ProceduralDungeon.Interfaces;
using Alis.Extension.Math.ProceduralDungeon.Models;

namespace Alis.Extension.Math.ProceduralDungeon.Services
{
    /// <summary>
    ///     Main dungeon generator class that orchestrates the dungeon creation process.
    ///     Implements the Facade pattern to provide a simple interface for dungeon generation.
    /// </summary>
    public class DungeonGenerator : IDungeonGenerator
    {
        /// <summary>
        ///     The dungeon configuration.
        /// </summary>
        private readonly DungeonConfiguration _configuration;

        /// <summary>
        ///     The room factory for creating rooms.
        /// </summary>
        private readonly IRoomFactory _roomFactory;

        /// <summary>
        ///     The corridor factory for creating corridors.
        /// </summary>
        private readonly ICorridorFactory _corridorFactory;

        /// <summary>
        ///     The board builder for constructing the board.
        /// </summary>
        private readonly IBoardBuilder _boardBuilder;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DungeonGenerator" /> class.
        /// </summary>
        /// <param name="configuration">The dungeon configuration.</param>
        /// <param name="roomFactory">The room factory.</param>
        /// <param name="corridorFactory">The corridor factory.</param>
        /// <param name="boardBuilder">The board builder.</param>
        /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
        public DungeonGenerator(
            DungeonConfiguration configuration,
            IRoomFactory roomFactory,
            ICorridorFactory corridorFactory,
            IBoardBuilder boardBuilder)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _roomFactory = roomFactory ?? throw new ArgumentNullException(nameof(roomFactory));
            _corridorFactory = corridorFactory ?? throw new ArgumentNullException(nameof(corridorFactory));
            _boardBuilder = boardBuilder ?? throw new ArgumentNullException(nameof(boardBuilder));

            _configuration.Validate();
        }

        /// <summary>
        ///     Generates a complete dungeon with rooms, corridors, and board layout.
        /// </summary>
        /// <returns>A fully generated dungeon instance.</returns>
        public DungeonData Generate()
        {
            // Step 1: Generate rooms and corridors
            (List<RoomData> rooms, List<CorridorData> corridors) = GenerateRoomsAndCorridors();

            // Step 2: Create the board
            BoardSquare[,] board = _boardBuilder.CreateEmptyBoard(_configuration.BoardWidth, _configuration.BoardHeight);

            // Step 3: Place rooms and corridors on the board
            _boardBuilder.PlaceRooms(board, rooms);
            _boardBuilder.PlaceCorridors(board, corridors);

            // Step 4: Generate walls and corners
            _boardBuilder.GenerateWallsAndCorners(board);

            // Step 5: Return the complete dungeon data
            return new DungeonData(board, rooms, corridors);
        }

        /// <summary>
        ///     Generates all rooms and corridors for the dungeon.
        /// </summary>
        /// <returns>A tuple containing lists of rooms and corridors.</returns>
        private (List<RoomData> rooms, List<CorridorData> corridors) GenerateRoomsAndCorridors()
        {
            List<RoomData> rooms = new List<RoomData>(_configuration.NumberOfRooms);
            List<CorridorData> corridors = new List<CorridorData>(_configuration.NumberOfRooms - 1);

            // Create the first room at the center of the board
            RoomData firstRoom = _roomFactory.CreateFirstRoom(
                _configuration.BoardWidth / 2,
                _configuration.BoardHeight / 2,
                _configuration.FirstRoomWidth,
                _configuration.FirstRoomHeight);
            rooms.Add(firstRoom);

            // Create the first corridor
            CorridorData firstCorridor = _corridorFactory.CreateFirstCorridor(
                _configuration.CorridorWidth,
                _configuration.CorridorHeight,
                firstRoom);
            corridors.Add(firstCorridor);

            // Generate intermediate rooms and corridors
            for (int i = 1; i < _configuration.NumberOfRooms - 1; i++)
            {
                RoomData room = _roomFactory.CreateRoom(
                    _configuration.RoomWidth,
                    _configuration.RoomHeight,
                    corridors[i - 1]);
                rooms.Add(room);

                CorridorData corridor = _corridorFactory.CreateCorridor(
                    _configuration.CorridorWidth,
                    _configuration.CorridorHeight,
                    room);
                corridors.Add(corridor);
            }

            // Create the final corridor before the boss room
            CorridorData finalCorridor = _corridorFactory.CreateCorridor(
                _configuration.CorridorWidth,
                _configuration.CorridorHeight,
                rooms[rooms.Count - 1]);
            corridors.Add(finalCorridor);

            // Create the boss room
            RoomData bossRoom = _roomFactory.CreateBossRoom(
                _configuration.BossRoomWidth,
                _configuration.BossRoomHeight,
                finalCorridor);
            rooms.Add(bossRoom);

            return (rooms, corridors);
        }
    }
}

