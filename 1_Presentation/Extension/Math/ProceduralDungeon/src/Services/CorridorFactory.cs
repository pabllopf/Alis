// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CorridorFactory.cs
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
using Alis.Extension.Math.ProceduralDungeon.Helpers;
using Alis.Extension.Math.ProceduralDungeon.Interfaces;
using Alis.Extension.Math.ProceduralDungeon.Models;
using Alis.Extension.Math.ProceduralDungeon.Validators;

namespace Alis.Extension.Math.ProceduralDungeon.Services
{
    /// <summary>
    ///     Factory class for creating corridors in a dungeon.
    ///     Implements the Factory pattern to encapsulate corridor creation logic.
    /// </summary>
    public class CorridorFactory : ICorridorFactory
    {
        /// <summary>
        ///     The random number generator for selecting corridor directions.
        /// </summary>
        private readonly IRandomNumberGenerator _randomNumberGenerator;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CorridorFactory" /> class.
        /// </summary>
        /// <param name="randomNumberGenerator">The random number generator to use.</param>
        /// <exception cref="ArgumentNullException">Thrown when randomNumberGenerator is null.</exception>
        public CorridorFactory(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator ?? throw new ArgumentNullException(nameof(randomNumberGenerator));
        }

        /// <summary>
        ///     Creates the first corridor connected to the starting room.
        /// </summary>
        /// <param name="width">The width of the corridor.</param>
        /// <param name="height">The height of the corridor.</param>
        /// <param name="room">The room to connect the corridor to.</param>
        /// <returns>A corridor data instance.</returns>
        /// <exception cref="ArgumentException">Thrown when dimensions are invalid.</exception>
        public CorridorData CreateFirstCorridor(int width, int height, RoomData room)
        {
            DimensionsValidator.ValidateDimensions(width, height, nameof(width), nameof(height));
            
            Direction direction = GetRandomDirection();
            
            return CreateCorridorFromRoom(width, height, room, direction);
        }

        /// <summary>
        ///     Creates a standard corridor connected to a room.
        /// </summary>
        /// <param name="width">The width of the corridor.</param>
        /// <param name="height">The height of the corridor.</param>
        /// <param name="room">The room to connect the corridor to.</param>
        /// <returns>A corridor data instance.</returns>
        /// <exception cref="ArgumentException">Thrown when dimensions are invalid.</exception>
        public CorridorData CreateCorridor(int width, int height, RoomData room)
        {
            DimensionsValidator.ValidateDimensions(width, height, nameof(width), nameof(height));
            
            Direction direction = GetRandomDirectionAvoidingOpposite(room.Direction);
            
            return CreateCorridorFromRoom(width, height, room, direction);
        }

        /// <summary>
        ///     Creates a corridor from a room in the specified direction.
        /// </summary>
        /// <param name="width">The width of the corridor.</param>
        /// <param name="height">The height of the corridor.</param>
        /// <param name="room">The room to connect the corridor to.</param>
        /// <param name="direction">The direction of the corridor.</param>
        /// <returns>A corridor data instance.</returns>
        private CorridorData CreateCorridorFromRoom(int width, int height, RoomData room, Direction direction)
        {
            int xPos, yPos, corridorWidth, corridorHeight;

            switch (direction)
            {
                case Direction.North:
                    xPos = room.XPos + room.Width / 2 - width / 2;
                    yPos = room.YPos + room.Height;
                    corridorWidth = width;
                    corridorHeight = height;
                    break;

                case Direction.South:
                    xPos = room.XPos + room.Width / 2 - width / 2;
                    yPos = room.YPos - height;
                    corridorWidth = width;
                    corridorHeight = height;
                    break;

                case Direction.East:
                    xPos = room.XPos - height;
                    yPos = room.YPos + room.Height / 2 - height / 2;
                    corridorWidth = height;
                    corridorHeight = width;
                    break;

                case Direction.West:
                    xPos = room.XPos + room.Width;
                    yPos = room.YPos + room.Height / 2 - height / 2;
                    corridorWidth = height;
                    corridorHeight = width;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, "Invalid direction.");
            }

            return new CorridorData(xPos, yPos, corridorWidth, corridorHeight, direction);
        }

        /// <summary>
        ///     Gets a random direction.
        /// </summary>
        /// <returns>A random direction.</returns>
        private Direction GetRandomDirection()
        {
            int directionValue = _randomNumberGenerator.Next(1, 5);
            return (Direction)directionValue;
        }

        /// <summary>
        ///     Gets a random direction while avoiding the opposite of the given direction.
        /// </summary>
        /// <param name="previousDirection">The previous direction to avoid the opposite of.</param>
        /// <returns>A random direction that is not opposite to the previous direction.</returns>
        private Direction GetRandomDirectionAvoidingOpposite(Direction previousDirection)
        {
            Direction oppositeDirection = DirectionHelper.GetOpposite(previousDirection);
            Direction newDirection;

            do
            {
                newDirection = GetRandomDirection();
            } while (newDirection == oppositeDirection);

            return newDirection;
            return newDirection;
        }
    }
}

