//------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Room.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//------------------------------------------------------------------------------------------

using System;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Math;

namespace Alis.Extension.Math.DungeonGenerator
{
    /// <summary>Generate a room of the dungeon.</summary>
    [Serializable]
    public class Room
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
        /// Initializes a new instance of the <see cref="Room"/> class
        /// </summary>
        /// <param name="xPos">The pos</param>
        /// <param name="yPos">The pos</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public Room(int xPos, int yPos, int width, int height)
        {
            XPos = xPos;
            YPos = yPos;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class
        /// </summary>
        /// <param name="xPos">The pos</param>
        /// <param name="yPos">The pos</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="direction">The direction</param>
        [JsonConstructor]
        public Room(int xPos, int yPos, int width, int height, Direction direction)
        {
            XPos = xPos;
            YPos = yPos;
            Width = width;
            Height = height;
            Direction = direction;
        }

        /// <summary>
        /// Sets the up first room using the specified x pos
        /// </summary>
        /// <param name="xPos">The pos</param>
        /// <param name="yPos">The pos</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The room</returns>
        public static Room SetUpFirstRoom(int xPos, int yPos, int width, int height)
        {
            return new Room(xPos, yPos, width, height);
        }

        /// <summary>
        /// Sets the up using the specified width
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
                    xPos = (corridor.XPos + (corridor.Width / 2)) - (width / 2);
                    yPos = corridor.YPos + corridor.Height;

                    xWidth = width;
                    yHeight = height;

                    break;

                case Direction.South:
                    xPos = (corridor.XPos + (corridor.Width / 2)) - (width / 2);
                    yPos = corridor.YPos - height;

                    xWidth = width;
                    yHeight = height;

                    break;

                case Direction.East:
                    xPos = corridor.XPos - height;
                    yPos = (corridor.YPos + (corridor.Height / 2)) - (height / 2);

                    xWidth = height;
                    yHeight = width;

                    break;

                case Direction.West:
                    xPos = corridor.XPos + corridor.Width;
                    yPos = (corridor.YPos + (corridor.Height / 2)) - (height / 2);

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