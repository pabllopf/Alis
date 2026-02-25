// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Position.cs
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
    ///     Represents a 2D position with integer coordinates.
    ///     This immutable value type encapsulates X and Y coordinates.
    /// </summary>
    /// <remarks>
    ///     Position is implemented as a readonly struct for performance and immutability.
    ///     It's particularly useful in scenarios where coordinates are passed around frequently.
    /// </remarks>
    [Serializable]
    public readonly partial struct Position : IEquatable<Position>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Position" /> struct.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Gets the X coordinate.
        /// </summary>
        [JsonNativePropertyName("x")]
        public int X { get; }

        /// <summary>
        ///     Gets the Y coordinate.
        /// </summary>
        [JsonNativePropertyName("y")]
        public int Y { get; }

        /// <summary>
        ///     Gets a position representing the origin (0, 0).
        /// </summary>
        [JsonNativeIgnore]
        public static Position Zero => new Position(0, 0);

        /// <summary>
        ///     Adds two positions together.
        /// </summary>
        /// <param name="left">The first position.</param>
        /// <param name="right">The second position.</param>
        /// <returns>A new position with the sum of coordinates.</returns>
        public static Position operator +(Position left, Position right)
        {
            return new Position(left.X + right.X, left.Y + right.Y);
        }

        /// <summary>
        ///     Subtracts one position from another.
        /// </summary>
        /// <param name="left">The first position.</param>
        /// <param name="right">The second position.</param>
        /// <returns>A new position with the difference of coordinates.</returns>
        public static Position operator -(Position left, Position right)
        {
            return new Position(left.X - right.X, left.Y - right.Y);
        }

        /// <summary>
        ///     Determines whether two positions are equal.
        /// </summary>
        /// <param name="left">The first position.</param>
        /// <param name="right">The second position.</param>
        /// <returns>True if both positions are equal; otherwise, false.</returns>
        public static bool operator ==(Position left, Position right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Determines whether two positions are not equal.
        /// </summary>
        /// <param name="left">The first position.</param>
        /// <param name="right">The second position.</param>
        /// <returns>True if positions are not equal; otherwise, false.</returns>
        public static bool operator !=(Position left, Position right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     Determines whether the specified position is equal to this instance.
        /// </summary>
        /// <param name="other">The other position to compare with this instance.</param>
        /// <returns>True if the specified position is equal to this instance; otherwise, false.</returns>
        public bool Equals(Position other)
        {
            return X == other.X && Y == other.Y;
        }

        /// <summary>
        ///     Determines whether the specified object is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>True if the specified object is equal to this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Position other && Equals(other);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        /// <summary>
        ///     Returns a string representation of this position.
        /// </summary>
        /// <returns>A string in the format "(X, Y)".</returns>
        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        /// <summary>
        ///     Calculates the Manhattan distance to another position.
        /// </summary>
        /// <param name="other">The other position.</param>
        /// <returns>The Manhattan distance between the two positions.</returns>
        /// <remarks>
        ///     Manhattan distance is the sum of the absolute differences of the coordinates.
        ///     It represents the distance between two points if you can only move horizontally or vertically.
        /// </remarks>
        public int ManhattanDistanceTo(Position other)
        {
            return System.Math.Abs(X - other.X) + System.Math.Abs(Y - other.Y);
        }
    }
}

