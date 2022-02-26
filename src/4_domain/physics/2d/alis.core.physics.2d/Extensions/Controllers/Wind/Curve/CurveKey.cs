// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   CurveKey.cs
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
using System.Runtime.Serialization;

// ReSharper disable once CheckNamespace
namespace Alis.Core.Systems.Physics2D.Config.Extensions.Controllers.Wind.Curve
{
    /// <summary>Key point on the <see cref="Curve" />.</summary>
    [DataContract]
    public class CurveKey : IEquatable<CurveKey>, IComparable<CurveKey>
    {
        /// <summary>Creates a new instance of <see cref="CurveKey" /> class with position: 0 and value: 0.</summary>
        public CurveKey() : this(0, 0)
        {
            // This parameterless constructor is needed for correct serialization of CurveKeyCollection and CurveKey.
        }

        /// <summary>Creates a new instance of <see cref="CurveKey" /> class.</summary>
        /// <param name="position">Position on the curve.</param>
        /// <param name="value">Value of the control point.</param>
        public CurveKey(float position, float value)
            : this(position, value, 0, 0, CurveContinuity.Smooth)
        {
        }

        /// <summary>Creates a new instance of <see cref="CurveKey" /> class.</summary>
        /// <param name="position">Position on the curve.</param>
        /// <param name="value">Value of the control point.</param>
        /// <param name="tangentIn">Tangent approaching point from the previous point on the curve.</param>
        /// <param name="tangentOut">Tangent leaving point toward next point on the curve.</param>
        public CurveKey(float position, float value, float tangentIn, float tangentOut)
            : this(position, value, tangentIn, tangentOut, CurveContinuity.Smooth)
        {
        }

        /// <summary>Creates a new instance of <see cref="CurveKey" /> class.</summary>
        /// <param name="position">Position on the curve.</param>
        /// <param name="value">Value of the control point.</param>
        /// <param name="tangentIn">Tangent approaching point from the previous point on the curve.</param>
        /// <param name="tangentOut">Tangent leaving point toward next point on the curve.</param>
        /// <param name="continuity">Indicates whether the curve is discrete or continuous.</param>
        public CurveKey(float position, float value, float tangentIn, float tangentOut, CurveContinuity continuity)
        {
            Position = position;
            Value = value;
            TangentIn = tangentIn;
            TangentOut = tangentOut;
            Continuity = continuity;
        }

        /// <summary>
        ///     Gets or sets the indicator whether the segment between this point and the next point on the curve is discrete
        ///     or continuous.
        /// </summary>
        [DataMember]
        public CurveContinuity Continuity { get; set; }

        /// <summary>Gets a position of the key on the curve.</summary>
        [DataMember]
        public float Position { get; }

        /// <summary>Gets or sets a tangent when approaching this point from the previous point on the curve.</summary>
        [DataMember]
        public float TangentIn { get; set; }

        /// <summary>Gets or sets a tangent when leaving this point to the next point on the curve.</summary>
        [DataMember]
        public float TangentOut { get; set; }

        /// <summary>Gets a value of this point.</summary>
        [DataMember]
        public float Value { get; set; }

        /// <summary>
        ///     Compares the to using the specified other
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The int</returns>
        public int CompareTo(CurveKey other) => Position.CompareTo(other.Position);

        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        public bool Equals(CurveKey other) => this == other;

        /// <summary>Compares whether two <see cref="CurveKey" /> instances are not equal.</summary>
        /// <param name="value1"><see cref="CurveKey" /> instance on the left of the not equal sign.</param>
        /// <param name="value2"><see cref="CurveKey" /> instance on the right of the not equal sign.</param>
        /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>
        public static bool operator !=(CurveKey value1, CurveKey value2) => !(value1 == value2);

        /// <summary>Compares whether two <see cref="CurveKey" /> instances are equal.</summary>
        /// <param name="value1"><see cref="CurveKey" /> instance on the left of the equal sign.</param>
        /// <param name="value2"><see cref="CurveKey" /> instance on the right of the equal sign.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(CurveKey value1, CurveKey value2)
        {
            if (Equals(value1, null))
            {
                return Equals(value2, null);
            }

            if (Equals(value2, null))
            {
                return Equals(value1, null);
            }

            return value1.Position == value2.Position
                   && value1.Value == value2.Value
                   && value1.TangentIn == value2.TangentIn
                   && value1.TangentOut == value2.TangentOut
                   && value1.Continuity == value2.Continuity;
        }

        /// <summary>Creates a copy of this key.</summary>
        /// <returns>A copy of this key.</returns>
        public CurveKey Clone() => new CurveKey(Position, Value, TangentIn, TangentOut, Continuity);

        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        public override bool Equals(object obj) => obj is CurveKey key && Equals(key);

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode() =>
            Position.GetHashCode() ^ Value.GetHashCode() ^ TangentIn.GetHashCode() ^
            TangentOut.GetHashCode() ^ Continuity.GetHashCode();
    }
}