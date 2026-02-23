// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RoomFactory.cs
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
using Alis.Extension.Math.ProceduralDungeon.Interfaces;
using Alis.Extension.Math.ProceduralDungeon.Models;
using Alis.Extension.Math.ProceduralDungeon.Validators;

namespace Alis.Extension.Math.ProceduralDungeon.Services
{
    /// <summary>
    ///     Factory class for creating rooms in a dungeon.
    ///     Implements the Factory pattern to encapsulate room creation logic.
    /// </summary>
    public class RoomFactory : IRoomFactory
    {
        /// <summary>
        ///     Creates the first room of the dungeon at a central position.
        /// </summary>
        /// <param name="xPos">The x position of the room.</param>
        /// <param name="yPos">The y position of the room.</param>
        /// <param name="width">The width of the room.</param>
        /// <param name="height">The height of the room.</param>
        /// <returns>A room data instance.</returns>
        /// <exception cref="ArgumentException">Thrown when dimensions are invalid.</exception>
        public RoomData CreateFirstRoom(int xPos, int yPos, int width, int height)
        {
            DimensionsValidator.ValidateDimensions(width, height, nameof(width), nameof(height));
            DimensionsValidator.ValidatePosition(xPos, yPos, nameof(xPos), nameof(yPos));
            
            return new RoomData(xPos, yPos, width, height, Direction.North, false);
        }

        /// <summary>
        ///     Creates a standard room connected to a corridor.
        /// </summary>
        /// <param name="width">The width of the room.</param>
        /// <param name="height">The height of the room.</param>
        /// <param name="corridor">The corridor to connect the room to.</param>
        /// <returns>A room data instance.</returns>
        /// <exception cref="ArgumentException">Thrown when dimensions are invalid.</exception>
        public RoomData CreateRoom(int width, int height, CorridorData corridor)
        {
            DimensionsValidator.ValidateDimensions(width, height, nameof(width), nameof(height));
            
            return CreateRoomFromCorridor(width, height, corridor, false);
        }

        /// <summary>
        ///     Creates a boss room connected to a corridor.
        /// </summary>
        /// <param name="width">The width of the boss room.</param>
        /// <param name="height">The height of the boss room.</param>
        /// <param name="corridor">The corridor to connect the boss room to.</param>
        /// <returns>A room data instance.</returns>
        /// <exception cref="ArgumentException">Thrown when dimensions are invalid.</exception>
        public RoomData CreateBossRoom(int width, int height, CorridorData corridor)
        {
            DimensionsValidator.ValidateDimensions(width, height, nameof(width), nameof(height));
            
            return CreateRoomFromCorridor(width, height, corridor, true);
        }

        /// <summary>
        ///     Creates a room connected to a corridor based on the corridor's direction.
        /// </summary>
        /// <param name="width">The width of the room.</param>
        /// <param name="height">The height of the room.</param>
        /// <param name="corridor">The corridor to connect the room to.</param>
        /// <param name="isBossRoom">Indicates whether this is a boss room.</param>
        /// <returns>A room data instance.</returns>
        private RoomData CreateRoomFromCorridor(int width, int height, CorridorData corridor, bool isBossRoom)
        {
            int xPos, yPos, roomWidth, roomHeight;
            Direction direction = corridor.Direction;

            switch (direction)
            {
                case Direction.North:
                    xPos = corridor.XPos + corridor.Width / 2 - width / 2;
                    yPos = corridor.YPos + corridor.Height;
                    roomWidth = width;
                    roomHeight = height;
                    break;

                case Direction.South:
                    xPos = corridor.XPos + corridor.Width / 2 - width / 2;
                    yPos = corridor.YPos - height;
                    roomWidth = width;
                    roomHeight = height;
                    break;

                case Direction.East:
                    xPos = corridor.XPos - height;
                    yPos = corridor.YPos + corridor.Height / 2 - height / 2;
                    roomWidth = height;
                    roomHeight = width;
                    break;

                case Direction.West:
                    xPos = corridor.XPos + corridor.Width;
                    yPos = corridor.YPos + corridor.Height / 2 - height / 2;
                    roomWidth = height;
                    roomHeight = width;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, "Invalid direction.");
            }

            return new RoomData(xPos, yPos, roomWidth, roomHeight, direction, isBossRoom);
        }
    }
}

