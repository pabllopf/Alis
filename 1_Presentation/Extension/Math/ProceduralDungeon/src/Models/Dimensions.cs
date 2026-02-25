// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Dimensions.cs
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
    ///     Represents 2D dimensions with width and height.
    ///     This immutable value type encapsulates size information.
    /// </summary>
    /// <remarks>
    ///     Dimensions is implemented as a readonly struct for performance and immutability.
    ///     It ensures that width and height are always positive values.
    /// </remarks>
    [Serializable]
    public readonly partial struct Dimensions : IEquatable<Dimensions>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Dimensions" /> struct.
        /// </summary>
        /// <param name="width">The width value.</param>
        /// <param name="height">The height value.</param>
        /// <exception cref="ArgumentException">Thrown when width or height is not positive.</exception>
        public Dimensions(int width, int height)
        {
            if (width <= 0)
                throw new ArgumentException("Width must be greater than 0.", nameof(width));
            if (height <= 0)
                throw new ArgumentException("Height must be greater than 0.", nameof(height));

            Width = width;
            Height = height;
        }

        /// <summary>
        ///     Gets the width.
        /// </summary>
        [JsonNativePropertyName("width")]
        public int Width { get; }

        /// <summary>
        ///     Gets the height.
        /// </summary>
        [JsonNativePropertyName("height")]
        public int Height { get; }

        /// <summary>
        ///     Gets the area (width * height).
        /// </summary>
        public int Area => Width * Height;

        /// <summary>
        ///     Determines whether two dimensions are equal.
        /// </summary>
        /// <param name="left">The first dimensions.</param>
        /// <param name="right">The second dimensions.</param>
        /// <returns>True if both dimensions are equal; otherwise, false.</returns>
        public static bool operator ==(Dimensions left, Dimensions right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Determines whether two dimensions are not equal.
        /// </summary>
        /// <param name="left">The first dimensions.</param>
        /// <param name="right">The second dimensions.</param>
        /// <returns>True if dimensions are not equal; otherwise, false.</returns>
        public static bool operator !=(Dimensions left, Dimensions right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     Determines whether the specified dimensions are equal to this instance.
        /// </summary>
        /// <param name="other">The other dimensions to compare with this instance.</param>
        /// <returns>True if the specified dimensions are equal to this instance; otherwise, false.</returns>
        public bool Equals(Dimensions other)
        {
            return Width == other.Width && Height == other.Height;
        }

        /// <summary>
        ///     Determines whether the specified object is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>True if the specified object is equal to this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Dimensions other && Equals(other);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Width, Height);
        }

        /// <summary>
        ///     Returns a string representation of these dimensions.
        /// </summary>
        /// <returns>A string in the format "Width x Height".</returns>
        public override string ToString()
        {
            return $"{Width} x {Height}";
        }

        /// <summary>
        ///     Determines whether these dimensions can contain the other dimensions.
        /// </summary>
        /// <param name="other">The other dimensions to check.</param>
        /// <returns>True if these dimensions can contain the other; otherwise, false.</returns>
        public bool CanContain(Dimensions other)
        {
            return Width >= other.Width && Height >= other.Height;
        }
    }
}

