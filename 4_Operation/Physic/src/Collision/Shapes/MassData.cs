// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MassData.cs
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
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Collision.Shapes
{
    /// <summary>
    ///     This holds the mass data computed for a shape.
    /// </summary>
    public struct MassData : IEquatable<MassData>
    {
        /// <summary>
        ///     The area of the shape
        /// </summary>
        public float Area { get; internal set; }

        /// <summary>
        ///     The position of the shape's centroid relative to the shape's origin.
        /// </summary>
        public Vector2F Centroid { get; internal set; }

        /// <summary>
        ///     The rotational inertia of the shape about the local origin.
        /// </summary>
        public float Inertia { get; internal set; }

        /// <summary>
        ///     The mass of the shape, usually in kilograms.
        /// </summary>
        public float Mass { get; internal set; }

        /// <summary>
        ///     The equal operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(MassData left, MassData right) => (Math.Abs(left.Area - right.Area) < SettingEnv.Epsilon) && (Math.Abs(left.Mass - right.Mass) < SettingEnv.Epsilon) && (left.Centroid == right.Centroid) && (Math.Abs(left.Inertia - right.Inertia) < SettingEnv.Epsilon);

        /// <summary>
        ///     The not equal operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(MassData left, MassData right) => !(left == right);

        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        public bool Equals(MassData other) => this == other;

        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            
            return Equals((MassData) obj);
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = Area.GetHashCode();
                result = (result * 397) ^ Centroid.GetHashCode();
                result = (result * 397) ^ Inertia.GetHashCode();
                result = (result * 397) ^ Mass.GetHashCode();
                return result;
            }
        }
    }
}