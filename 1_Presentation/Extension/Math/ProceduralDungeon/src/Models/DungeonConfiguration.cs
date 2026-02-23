// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DungeonConfiguration.cs
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

namespace Alis.Extension.Math.ProceduralDungeon.Models
{
    /// <summary>
    ///     Configuration class for dungeon generation parameters.
    ///     Contains all the settings needed to generate a dungeon.
    /// </summary>
    public class DungeonConfiguration
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DungeonConfiguration" /> class with default values.
        /// </summary>
        public DungeonConfiguration()
        {
            BoardWidth = 150;
            BoardHeight = 150;
            NumberOfRooms = 4;
            FirstRoomWidth = 8;
            FirstRoomHeight = 8;
            RoomWidth = 5;
            RoomHeight = 5;
            BossRoomWidth = 7;
            BossRoomHeight = 7;
            CorridorWidth = 4;
            CorridorHeight = 4;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DungeonConfiguration" /> class with custom values.
        /// </summary>
        /// <param name="boardWidth">The width of the dungeon board.</param>
        /// <param name="boardHeight">The height of the dungeon board.</param>
        /// <param name="numberOfRooms">The number of rooms in the dungeon.</param>
        /// <param name="firstRoomWidth">The width of the first room.</param>
        /// <param name="firstRoomHeight">The height of the first room.</param>
        /// <param name="roomWidth">The width of standard rooms.</param>
        /// <param name="roomHeight">The height of standard rooms.</param>
        /// <param name="bossRoomWidth">The width of the boss room.</param>
        /// <param name="bossRoomHeight">The height of the boss room.</param>
        /// <param name="corridorWidth">The width of corridors.</param>
        /// <param name="corridorHeight">The height of corridors.</param>
        public DungeonConfiguration(
            int boardWidth,
            int boardHeight,
            int numberOfRooms,
            int firstRoomWidth,
            int firstRoomHeight,
            int roomWidth,
            int roomHeight,
            int bossRoomWidth,
            int bossRoomHeight,
            int corridorWidth,
            int corridorHeight)
        {
            BoardWidth = boardWidth;
            BoardHeight = boardHeight;
            NumberOfRooms = numberOfRooms;
            FirstRoomWidth = firstRoomWidth;
            FirstRoomHeight = firstRoomHeight;
            RoomWidth = roomWidth;
            RoomHeight = roomHeight;
            BossRoomWidth = bossRoomWidth;
            BossRoomHeight = bossRoomHeight;
            CorridorWidth = corridorWidth;
            CorridorHeight = corridorHeight;
            
            Validate();
        }

        /// <summary>
        ///     Gets or sets the width of the dungeon board.
        /// </summary>
        public int BoardWidth { get; set; }

        /// <summary>
        ///     Gets or sets the height of the dungeon board.
        /// </summary>
        public int BoardHeight { get; set; }

        /// <summary>
        ///     Gets or sets the number of rooms in the dungeon.
        /// </summary>
        public int NumberOfRooms { get; set; }

        /// <summary>
        ///     Gets or sets the width of the first room.
        /// </summary>
        public int FirstRoomWidth { get; set; }

        /// <summary>
        ///     Gets or sets the height of the first room.
        /// </summary>
        public int FirstRoomHeight { get; set; }

        /// <summary>
        ///     Gets or sets the width of standard rooms.
        /// </summary>
        public int RoomWidth { get; set; }

        /// <summary>
        ///     Gets or sets the height of standard rooms.
        /// </summary>
        public int RoomHeight { get; set; }

        /// <summary>
        ///     Gets or sets the width of the boss room.
        /// </summary>
        public int BossRoomWidth { get; set; }

        /// <summary>
        ///     Gets or sets the height of the boss room.
        /// </summary>
        public int BossRoomHeight { get; set; }

        /// <summary>
        ///     Gets or sets the width of corridors.
        /// </summary>
        public int CorridorWidth { get; set; }

        /// <summary>
        ///     Gets or sets the height of corridors.
        /// </summary>
        public int CorridorHeight { get; set; }

        /// <summary>
        ///     Validates the configuration to ensure all values are within acceptable ranges.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when configuration values are invalid.</exception>
        public void Validate()
        {
            if (BoardWidth <= 0)
                throw new ArgumentException("Board width must be greater than 0.", nameof(BoardWidth));
            
            if (BoardHeight <= 0)
                throw new ArgumentException("Board height must be greater than 0.", nameof(BoardHeight));
            
            if (NumberOfRooms < 2)
                throw new ArgumentException("Number of rooms must be at least 2.", nameof(NumberOfRooms));
            
            if (FirstRoomWidth <= 0 || FirstRoomHeight <= 0)
                throw new ArgumentException("First room dimensions must be greater than 0.");
            
            if (RoomWidth <= 0 || RoomHeight <= 0)
                throw new ArgumentException("Room dimensions must be greater than 0.");
            
            if (BossRoomWidth <= 0 || BossRoomHeight <= 0)
                throw new ArgumentException("Boss room dimensions must be greater than 0.");
            
            if (CorridorWidth <= 0 || CorridorHeight <= 0)
                throw new ArgumentException("Corridor dimensions must be greater than 0.");
        }
    }
}

