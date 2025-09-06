// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Corridor.cs
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
using System.Security.Cryptography;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Math.ProceduralDungeon
{
    /// <summary>
    ///     The corridor class
    /// </summary>
    [Serializable]
    public partial class Corridor
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Corridor" /> class
        /// </summary>
        public Corridor()
        {
            XPos = 0;
            YPos = 0;
            Width = 0;
            Height = 0;
            Direction = Direction.None;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Corridor" /> class
        /// </summary>
        /// <param name="xPos">The pos</param>
        /// <param name="yPos">The pos</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="direction">The direction</param>
        internal Corridor(int xPos, int yPos, int width, int height, Direction direction)
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
        public int YPos { get; set; }

        /// <summary>
        ///     Gets the value of the width
        /// </summary>
        [JsonNativePropertyName("width")]
        public int Width { get; set; }

        /// <summary>
        ///     Gets the value of the height
        /// </summary>
        [JsonNativePropertyName("height")]
        public int Height { get; set; }

        /// <summary>
        ///     Gets the value of the direction
        /// </summary>
        [JsonNativePropertyName("direction")]
        public Direction Direction { get; set; }

        /// <summary>
        ///     Sets the up first corridor using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="room">The room</param>
        /// <returns>The corridor</returns>
        public static Corridor SetUpFirstCorridor(int width, int height, Room room)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            byte[] randomNumber = new byte[1];
            rng.GetBytes(randomNumber);
            Direction direction = (Direction) (randomNumber[0] % 4 + 1);

            int xPos = 0;
            int yPos = 0;

            int xWidth = 0;
            int yHeight = 0;

            switch (direction)
            {
                case Direction.North:
                    xPos = room.XPos + room.Width / 2 - width / 2;
                    yPos = room.YPos + room.Height;

                    xWidth = width;
                    yHeight = height;
                    break;
                case Direction.South:
                    xPos = room.XPos + room.Width / 2 - width / 2;
                    yPos = room.YPos - height;

                    xWidth = width;
                    yHeight = height;
                    break;
                case Direction.East:
                    xPos = room.XPos - height;
                    yPos = room.YPos + room.Height / 2 - height / 2;

                    xWidth = height;
                    yHeight = width;
                    break;
                case Direction.West:
                    xPos = room.XPos + room.Width;
                    yPos = room.YPos + room.Height / 2 - height / 2;

                    xWidth = height;
                    yHeight = width;
                    break;
            }

            return new Corridor(xPos, yPos, xWidth, yHeight, direction);
        }

        /// <summary>
        ///     Sets the up using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="room">The room</param>
        /// <returns>The corridor</returns>
        public static Corridor SetUp(int width, int height, Room room)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            byte[] randomNumber = new byte[1];
            rng.GetBytes(randomNumber);
            Direction direction = (Direction) (randomNumber[0] % 4 + 1);

            Direction oppositeDirection = (Direction) (((int) room.Direction + 2) % 4);

            direction = direction == oppositeDirection ? (Direction) ((int) direction++ % 4) : direction;

            int xPos = 0;
            int yPos = 0;

            int xWidth = 0;
            int yHeight = 0;

            switch (direction)
            {
                case Direction.North:
                    xPos = room.XPos + room.Width / 2 - width / 2;
                    yPos = room.YPos + room.Height;

                    xWidth = width;
                    yHeight = height;
                    break;
                case Direction.South:
                    xPos = room.XPos + room.Width / 2 - width / 2;
                    yPos = room.YPos - height;

                    xWidth = width;
                    yHeight = height;
                    break;
                case Direction.East:
                    xPos = room.XPos - height;
                    yPos = room.YPos + room.Height / 2 - height / 2;

                    xWidth = height;
                    yHeight = width;
                    break;
                case Direction.West:
                    xPos = room.XPos + room.Width;
                    yPos = room.YPos + room.Height / 2 - height / 2;

                    xWidth = height;
                    yHeight = width;
                    break;
            }


            return new Corridor(xPos, yPos, xWidth, yHeight, direction);
        }
    }
}