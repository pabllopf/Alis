// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RoomData.cs
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
using HashCode = Alis.Core.Aspect.Math.HashCode;

namespace Alis.Extension.Math.ProceduralDungeon.Models
{
    /// <summary>
    ///     Represents the data structure for a room in the dungeon.
    ///     This is an immutable data structure that holds room information.
    /// </summary>
    [Serializable]
    public readonly partial struct RoomData : IEquatable<RoomData>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RoomData" /> struct.
        /// </summary>
        /// <param name="xPos">The x position of the room on the board.</param>
        /// <param name="yPos">The y position of the room on the board.</param>
        /// <param name="width">The width of the room.</param>
        /// <param name="height">The height of the room.</param>
        /// <param name="direction">The direction the room is facing.</param>
        /// <param name="isBossRoom">Indicates whether this is a boss room.</param>
        public RoomData(int xPos, int yPos, int width, int height, Direction direction, bool isBossRoom = false)
        {
            XPos = xPos;
            YPos = yPos;
            Width = width;
            Height = height;
            Direction = direction;
            IsBossRoom = isBossRoom;
        }

        /// <summary>
        ///     Gets the x position of the room on the board.
        /// </summary>
        [JsonNativePropertyName("xPos")]
        public int XPos { get; }

        /// <summary>
        ///     Gets the y position of the room on the board.
        /// </summary>
        [JsonNativePropertyName("yPos")]
        public int YPos { get; }

        /// <summary>
        ///     Gets the width of the room.
        /// </summary>
        [JsonNativePropertyName("width")]
        public int Width { get; }

        /// <summary>
        ///     Gets the height of the room.
        /// </summary>
        [JsonNativePropertyName("height")]
        public int Height { get; }

        /// <summary>
        ///     Gets the direction the room is facing.
        ///     This indicates from which direction the room was entered.
        /// </summary>
        [JsonNativePropertyName("direction")]
        public Direction Direction { get; }

        /// <summary>
        ///     Gets a value indicating whether this is a boss room.
        /// </summary>
        [JsonNativePropertyName("isBossRoom")]
        public bool IsBossRoom { get; }

        /// <summary>
        ///     Determines whether the specified <see cref="RoomData" /> is equal to this instance.
        /// </summary>
        /// <param name="other">The other room data to compare with this instance.</param>
        /// <returns>True if the specified room data is equal to this instance; otherwise, false.</returns>
        public bool Equals(RoomData other)
        {
            return XPos == other.XPos && 
                   YPos == other.YPos && 
                   Width == other.Width && 
                   Height == other.Height && 
                   Direction == other.Direction && 
                   IsBossRoom == other.IsBossRoom;
        }

        /// <summary>
        ///     Determines whether the specified object is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>True if the specified object is equal to this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is RoomData other && Equals(other);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(XPos, YPos, Width, Height, Direction, IsBossRoom);
        }

        /// <summary>
        ///     Equality operator for comparing two room data instances.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>True if both instances are equal; otherwise, false.</returns>
        public static bool operator ==(RoomData left, RoomData right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Inequality operator for comparing two room data instances.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>True if both instances are not equal; otherwise, false.</returns>
        public static bool operator !=(RoomData left, RoomData right)
        {
            return !left.Equals(right);
        }
    }
}

