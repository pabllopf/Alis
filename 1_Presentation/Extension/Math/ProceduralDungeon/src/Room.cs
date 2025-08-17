// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Room.cs
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
using Alis.Core.Aspect.Data.Json;


namespace Alis.Extension.Math.ProceduralDungeon
{
    /// <summary>Generate a room of the dungeon.</summary>
    [Serializable]
    public partial class Room
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class
        /// </summary>
        public Room() : this(0, 0, 0, 0)
        {
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Room" /> class
        /// </summary>
        /// <param name="xPos">The pos</param>
        /// <param name="yPos">The pos</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public Room(int xPos, int yPos, int width, int height): this (xPos, yPos, width, height, Direction.North)
        {
            XPos = xPos;
            YPos = yPos;
            Width = width;
            Height = height;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Room" /> class
        /// </summary>
        /// <param name="xPos">The pos</param>
        /// <param name="yPos">The pos</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="direction">The direction</param>
        
        public Room(int xPos, int yPos, int width, int height, Direction direction)
        {
            XPos = xPos;
            YPos = yPos;
            Width = width;
            Height = height;
            Direction = direction;
        }

        /// <summary>
        ///     Gets the value of the x pos
        /// </summary>
        [JsonNativePropertyName("xPos")]
        public int XPos { get; set; }

        /// <summary>
        ///     Gets the value of the y pos
        /// </summary>
        [JsonNativePropertyName("yPos")]
        public int YPos { get; set;}

        /// <summary>
        ///     Gets the value of the width
        /// </summary>
        [JsonNativePropertyName("width")]
        public int Width { get; set;}

        /// <summary>
        ///     Gets the value of the height
        /// </summary>
        [JsonNativePropertyName("height")]
        public int Height { get; set;}

        /// <summary>
        ///     Gets the value of the direction
        /// </summary>
        [JsonNativePropertyName("direction")]
        public Direction Direction { get; set; }

        /// <summary>
        ///     Sets the up first room using the specified x pos
        /// </summary>
        /// <param name="xPos">The pos</param>
        /// <param name="yPos">The pos</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The room</returns>
        public static Room SetUpFirstRoom(int xPos, int yPos, int width, int height) => new Room(xPos, yPos, width, height);

        /// <summary>
        ///     Sets the up using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="corridor">The corridor</param>
        /// <returns>The room</returns>
        public static Room SetUp(int width, int height, Corridor corridor)
        {
            Direction direction = corridor.Direction;

            int xPos;
            int yPos;

            int xWidth;
            int yHeight;

            switch (direction)
            {
                case Direction.North:
                    xPos = corridor.XPos + corridor.Width / 2 - width / 2;
                    yPos = corridor.YPos + corridor.Height;

                    xWidth = width;
                    yHeight = height;

                    break;

                case Direction.South:
                    xPos = corridor.XPos + corridor.Width / 2 - width / 2;
                    yPos = corridor.YPos - height;

                    xWidth = width;
                    yHeight = height;

                    break;

                case Direction.East:
                    xPos = corridor.XPos - height;
                    yPos = corridor.YPos + corridor.Height / 2 - height / 2;

                    xWidth = height;
                    yHeight = width;

                    break;

                case Direction.West:
                    xPos = corridor.XPos + corridor.Width;
                    yPos = corridor.YPos + corridor.Height / 2 - height / 2;

                    xWidth = height;
                    yHeight = width;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new Room(xPos, yPos, xWidth, yHeight, direction);
        }
    }
}