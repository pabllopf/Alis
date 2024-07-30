//------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Corridor.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------

using System;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Math;

namespace Alis.Extension.Math.DungeonGenerator
{
    /// <summary>Generate a corridor of the dungeon.</summary>
    public class Corridor
    {
        /// <summary>
        /// Gets the value of the x pos
        /// </summary>
        [JsonPropertyName("XPos:")]
        public int XPos { get; }
        
        /// <summary>
        /// Gets the value of the y pos
        /// </summary>
        [JsonPropertyName("YPos:")]
        public int YPos { get; }
        
        /// <summary>
        /// Gets the value of the width
        /// </summary>
        [JsonPropertyName("Width:")]
        public int Width { get; }
        
        /// <summary>
        /// Gets the value of the height
        /// </summary>
        [JsonPropertyName("Height:")]
        public int Height { get; }
        
        /// <summary>
        /// Gets the value of the direction
        /// </summary>
        [JsonPropertyName("Direction:")]
        public Direction Direction { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Corridor"/> class
        /// </summary>
        /// <param name="xPos">The pos</param>
        /// <param name="yPos">The pos</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="direction">The direction</param>
        [JsonConstructor]
        private Corridor(int xPos, int yPos, int width, int height, Direction direction)
        {
            XPos = xPos;
            YPos = yPos;
            Width = width;
            Height = height;
            Direction = direction;
        }

        /// <summary>
        /// Sets the up first corridor using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="room">The room</param>
        /// <returns>The corridor</returns>
        public static Corridor SetUpFirstCorridor(int width, int height, Room room)
        {
            Direction direction = (Direction)new Random().Next(0, 4);

            int xPos = 0;
            int yPos = 0;

            int xWidth = 0;
            int yHeight = 0;

            switch (direction)
            {
                case Direction.North:
                    xPos = (room.XPos + (room.Width / 2)) - (width / 2);
                    yPos = room.YPos + room.Height;

                    xWidth = width;
                    yHeight = height;
                    break;
                case Direction.South:
                    xPos = (room.XPos + (room.Width / 2)) - (width / 2);
                    yPos = room.YPos - height;

                    xWidth = width;
                    yHeight = height;
                    break;
                case Direction.East:
                    xPos = room.XPos - height;
                    yPos = (room.YPos + (room.Height / 2)) - (height / 2);

                    xWidth = height;
                    yHeight = width;
                    break;
                case Direction.West:
                    xPos = room.XPos + room.Width;
                    yPos = (room.YPos + (room.Height / 2)) - (height / 2);

                    xWidth = height;
                    yHeight = width;
                    break;
            }

            return new Corridor(xPos, yPos, xWidth, yHeight, direction);
        }

        /// <summary>
        /// Sets the up using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="room">The room</param>
        /// <returns>The corridor</returns>
        public static Corridor SetUp(int width, int height, Room room)
        {
            Direction direction = (Direction)new Random().Next(0, 4);
            Direction oppositeDirection = (Direction)(((int)room.Direction + 2) % 4);

            direction = (direction == oppositeDirection) ? (Direction)((int)direction++ % 4) : direction;

            int xPos = 0;
            int yPos = 0;

            int xWidth = 0;
            int yHeight = 0;

            switch (direction)
            {
                case Direction.North:
                    xPos = (room.XPos + (room.Width / 2)) - (width / 2);
                    yPos = room.YPos + room.Height;

                    xWidth = width;
                    yHeight = height;
                    break;
                case Direction.South:
                    xPos = (room.XPos + (room.Width / 2)) - (width / 2);
                    yPos = room.YPos - height;

                    xWidth = width;
                    yHeight = height;
                    break;
                case Direction.East:
                    xPos = room.XPos - height;
                    yPos = (room.YPos + (room.Height / 2)) - (height / 2);

                    xWidth = height;
                    yHeight = width;
                    break;
                case Direction.West:
                    xPos = room.XPos + room.Width;
                    yPos = (room.YPos + (room.Height / 2)) - (height / 2);

                    xWidth = height;
                    yHeight = width;
                    break;
            }


            return new Corridor(xPos, yPos, xWidth, yHeight, direction);
        }
    }
}