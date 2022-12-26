// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector2.cs
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
using System.Runtime.InteropServices;

namespace Alis.Core.Aspect.Math
{
    /// <summary>
    /// The vector
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2 : IEquatable<Vector2>
    {
        /// <summary>
        /// The 
        /// </summary>
        public readonly float X;

        /// <summary>
        /// The 
        /// </summary>
        public readonly float Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2"/> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }
        
        
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator - overload ; returns the opposite of a vector
        /// </summary>
        /// <param name="v">Vector to negate</param>
        /// <returns>-v</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2 operator -(Vector2 v) => new Vector2(-v.X, -v.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator - overload ; subtracts two vectors
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 - v2</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1.X - v2.X, v1.Y - v2.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator + overload ; add two vectors
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 + v2</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2 operator +(Vector2 v1, Vector2 v2) => new Vector2(v1.X + v2.X, v1.Y + v2.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator * overload ; multiply a vector by a scalar value
        /// </summary>
        /// <param name="v">Vector</param>
        /// <param name="x">Scalar value</param>
        /// <returns>v * x</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2 operator *(Vector2 v, float x) => new Vector2(v.X * x, v.Y * x);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator * overload ; multiply a scalar value by a vector
        /// </summary>
        /// <param name="x">Scalar value</param>
        /// <param name="v">Vector</param>
        /// <returns>x * v</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2 operator *(float x, Vector2 v) => new Vector2(v.X * x, v.Y * x);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator / overload ; divide a vector by a scalar value
        /// </summary>
        /// <param name="v">Vector</param>
        /// <param name="x">Scalar value</param>
        /// <returns>v / x</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2 operator /(Vector2 v, float x) => new Vector2(v.X / x, v.Y / x);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator == overload ; check vector equality
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 == v2</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator ==(Vector2 v1, Vector2 v2) => v1.Equals(v2);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator != overload ; check vector inequality
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 != v2</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator !=(Vector2 v1, Vector2 v2) => !v1.Equals(v2);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => $"[Vector2f] X({X}) Y({Y})";

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Compare vector and object and checks if they are equal
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>Object and vector are equal</returns>
        ////////////////////////////////////////////////////////////
        public override bool Equals(object obj) => obj is Vector2 && Equals((Vector2) obj);

        ///////////////////////////////////////////////////////////
        /// <summary>
        ///     Compare two vectors and checks if they are equal
        /// </summary>
        /// <param name="other">Vector to check</param>
        /// <returns>Vectors are equal</returns>
        ////////////////////////////////////////////////////////////
        public bool Equals(Vector2 other) => (System.Math.Abs(X - other.X) < 0.001f) && (System.Math.Abs(Y - other.Y) < 0.001f);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a integer describing the object
        /// </summary>
        /// <returns>Integer description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();
        
        /// <summary>
        /// Gets the value of the zero
        /// </summary>
        public static readonly Vector2 Zero = new Vector2(0.0f, 0.0f);
    }
}