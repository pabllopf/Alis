// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector2i.cs
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

namespace Alis.Core.Aspect.Math.SFML
{
    /// <summary>
    ///     Vector2i is an utility class for manipulating 2 dimensional
    ///     vectors with integer components
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2I : IEquatable<Vector2I>
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the vector from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        ////////////////////////////////////////////////////////////
        public Vector2I(int x, int y)
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
        public static Vector2I operator -(Vector2I v) => new Vector2I(-v.X, -v.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator - overload ; subtracts two vectors
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 - v2</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2I operator -(Vector2I v1, Vector2I v2) => new Vector2I(v1.X - v2.X, v1.Y - v2.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator + overload ; add two vectors
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 + v2</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2I operator +(Vector2I v1, Vector2I v2) => new Vector2I(v1.X + v2.X, v1.Y + v2.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator * overload ; multiply a vector by a scalar value
        /// </summary>
        /// <param name="v">Vector</param>
        /// <param name="x">Scalar value</param>
        /// <returns>v * x</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2I operator *(Vector2I v, int x) => new Vector2I(v.X * x, v.Y * x);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator * overload ; multiply a scalar value by a vector
        /// </summary>
        /// <param name="x">Scalar value</param>
        /// <param name="v">Vector</param>
        /// <returns>x * v</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2I operator *(int x, Vector2I v) => new Vector2I(v.X * x, v.Y * x);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator / overload ; divide a vector by a scalar value
        /// </summary>
        /// <param name="v">Vector</param>
        /// <param name="x">Scalar value</param>
        /// <returns>v / x</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2I operator /(Vector2I v, int x) => new Vector2I(v.X / x, v.Y / x);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator == overload ; check vector equality
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 == v2</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator ==(Vector2I v1, Vector2I v2) => v1.Equals(v2);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Operator != overload ; check vector inequality
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 != v2</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator !=(Vector2I v1, Vector2I v2) => !v1.Equals(v2);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => $"[Vector2i] X({X}) Y({Y})";

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Compare vector and object and checks if they are equal
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>Object and vector are equal</returns>
        ////////////////////////////////////////////////////////////
        public override bool Equals(object obj) => obj is Vector2I && Equals((Vector2I) obj);

        ///////////////////////////////////////////////////////////
        /// <summary>
        ///     Compare two vectors and checks if they are equal
        /// </summary>
        /// <param name="other">Vector to check</param>
        /// <returns>Vectors are equal</returns>
        ////////////////////////////////////////////////////////////
        public bool Equals(Vector2I other) => X == other.X && Y == other.Y;

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a integer describing the object
        /// </summary>
        /// <returns>Integer description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Explicit casting to another vector type
        /// </summary>
        /// <param name="v">Vector being casted</param>
        /// <returns>Casting result</returns>
        ////////////////////////////////////////////////////////////
        public static explicit operator Vector2F(Vector2I v) => new Vector2F(v.X, v.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Explicit casting to another vector type
        /// </summary>
        /// <param name="v">Vector being casted</param>
        /// <returns>Casting result</returns>
        ////////////////////////////////////////////////////////////
        public static explicit operator Vector2U(Vector2I v) => new Vector2U((uint) v.X, (uint) v.Y);

        /// <summary>X (horizontal) component of the vector</summary>
        public int X;

        /// <summary>Y (vertical) component of the vector</summary>
        public int Y;
    }
}