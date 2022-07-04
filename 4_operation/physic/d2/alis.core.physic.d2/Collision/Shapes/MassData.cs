// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   MassData.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;

namespace Alis.Core.Physic.D2.Collision.Shapes
{
    /// <summary>This holds the mass data computed for a shape.</summary>
    public struct MassData : IEquatable<MassData>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MassData" /> class
        /// </summary>
        /// <param name="area">The area</param>
        /// <param name="inertia">The inertia</param>
        /// <param name="mass">The mass</param>
        [JsonConstructor]
        public MassData(float area, float inertia, float mass)
        {
            Area = area;
            Inertia = inertia;
            Mass = mass;
            Centroid = new Vector2(0.0f, 0.0f);
        }

        /// <summary>The area of the shape</summary>
        [JsonPropertyName("_Area")]
        public float Area { get; set; }

        /// <summary>The position of the shape's centroid relative to the shape's origin.</summary>
        [JsonPropertyName("_Centroid")]
        public Vector2 Centroid { get; set; }

        /// <summary>The rotational inertia of the shape about the local origin.</summary>
        [JsonPropertyName("_Inertia")]
        public float Inertia { get; set; }

        /// <summary>The mass of the shape, usually in kilograms.</summary>
        [JsonPropertyName("_Mass")]
        public float Mass { get; set; }

        /// <summary>The equal operator</summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static bool operator ==(MassData left, MassData right)
        {
            return Math.Abs(left.Area - right.Area) < 0.1f &&
                   Math.Abs(left.Mass - right.Mass) < 0.1f &&
                   left.Centroid == right.Centroid &&
                   Math.Abs(left.Inertia - right.Inertia) < 0.1f;
        }

        /// <summary>The not equal operator</summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static bool operator !=(MassData left, MassData right)
        {
            return !(left == right);
        }

        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        public bool Equals(MassData other)
        {
            return this == other;
        }

        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is MassData data && Equals(data);
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode()
        {
            int result = Area.GetHashCode();
            result = (result * 397) ^ Centroid.GetHashCode();
            result = (result * 397) ^ Inertia.GetHashCode();
            result = (result * 397) ^ Mass.GetHashCode();
            return result;
        }
    }
}