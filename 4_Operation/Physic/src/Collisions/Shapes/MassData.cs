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

namespace Alis.Core.Physic.Collisions.Shapes
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
        ///     Compares two MassData instances for equality within floating-point tolerance.
        /// </summary>
        /// <param name="left">The first MassData to compare.</param>
        /// <param name="right">The second MassData to compare.</param>
        /// <returns><c>true</c> if all fields are approximately equal; otherwise <c>false</c>.</returns>
        public static bool operator ==(MassData left, MassData right) => (Math.Abs(left.Area - right.Area) < SettingEnv.Epsilon) && (Math.Abs(left.Mass - right.Mass) < SettingEnv.Epsilon) && (left.Centroid == right.Centroid) && (Math.Abs(left.Inertia - right.Inertia) < SettingEnv.Epsilon);

        /// <summary>
        ///     Compares two MassData instances for inequality.
        /// </summary>
        /// <param name="left">The first MassData to compare.</param>
        /// <param name="right">The second MassData to compare.</param>
        /// <returns><c>true</c> if any field differs beyond tolerance; otherwise <c>false</c>.</returns>
        public static bool operator !=(MassData left, MassData right) => !(left == right);

        /// <summary>
        ///     Indicates whether the current MassData equals another MassData.
        /// </summary>
        /// <param name="other">The MassData to compare with this instance.</param>
        /// <returns><c>true</c> if equal within tolerance; otherwise <c>false</c>.</returns>
        public bool Equals(MassData other) => this == other;

        /// <summary>
        ///     Indicates whether the current MassData equals another object.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns><c>true</c> if obj is a MassData and equals this instance; otherwise <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return Equals((MassData) obj);
        }

        /// <summary>
        ///     Computes a hash code for this MassData instance.
        /// </summary>
        /// <returns>A hash code value derived from all fields.</returns>
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