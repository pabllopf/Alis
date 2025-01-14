// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Transform.cs
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

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     A transform contains translation and rotation. It is used to represent
    ///     the position and orientation of rigid frames.
    /// </summary>
    public struct Transform
    {
        /// <summary>
        ///     The
        /// </summary>
        public Complex Q;

        /// <summary>
        ///     The
        /// </summary>
        public Vector2F P;

        /// <summary>
        ///     Gets the value of the identity
        /// </summary>
        public static Transform Identity { get; } = new Transform(Vector2F.Zero, Complex.One);

        /// <summary>
        ///     Initialize using a position vector and a Complex rotation.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation</param>
        public Transform(Vector2F position, Complex rotation)
        {
            Q = rotation;
            P = position;
        }

        /// <summary>
        ///     Initialize using a position vector and a rotation.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="angle">The rotation angle</param>
        public Transform(Vector2F position, float angle)
            : this(position, Complex.FromAngle(angle))
        {
        }

        /// <summary>
        ///     Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The vector</returns>
        public static Vector2F Multiply(Vector2F left, ref Transform right) => Multiply(ref left, ref right);

        /// <summary>
        ///     Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The vector</returns>
        public static Vector2F Multiply(ref Vector2F left, ref Transform right) =>
            // Opt: var result = Complex.Multiply(left, right.q) + right.p;
            new Vector2F(
                left.X * right.Q.R - left.Y * right.Q.I + right.P.X,
                left.Y * right.Q.R + left.X * right.Q.I + right.P.Y);

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The vector</returns>
        public static Vector2F Divide(Vector2F left, ref Transform right) => Divide(ref left, ref right);

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The vector</returns>
        public static Vector2F Divide(ref Vector2F left, ref Transform right)
        {
            // Opt: var result = Complex.Divide(left - right.p, right);
            float px = left.X - right.P.X;
            float py = left.Y - right.P.Y;
            return new Vector2F(
                px * right.Q.R + py * right.Q.I,
                py * right.Q.R - px * right.Q.I);
        }

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Divide(Vector2F left, ref Transform right, out Vector2F result)
        {
            // Opt: var result = Complex.Divide(left - right.p, right);
            float px = left.X - right.P.X;
            float py = left.Y - right.P.Y;
            result = new Vector2F(
                px * right.Q.R + py * right.Q.I,
                py * right.Q.R - px * right.Q.I);
        }

        /// <summary>
        ///     Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The transform</returns>
        public static Transform Multiply(ref Transform left, ref Transform right) => new Transform(
            Complex.Multiply(ref left.P, ref right.Q) + right.P,
            Complex.Multiply(ref left.Q, ref right.Q));

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The transform</returns>
        public static Transform Divide(ref Transform left, ref Transform right) => new Transform(
            Complex.Divide(left.P - right.P, ref right.Q),
            Complex.Divide(ref left.Q, ref right.Q));

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Divide(ref Transform left, ref Transform right, out Transform result)
        {
            Complex.Divide(left.P - right.P, ref right.Q, out result.P);
            Complex.Divide(ref left.Q, ref right.Q, out result.Q);
        }

        /// <summary>
        ///     Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Multiply(ref Transform left, Complex right, out Transform result)
        {
            result.P = Complex.Multiply(ref left.P, ref right);
            result.Q = Complex.Multiply(ref left.Q, ref right);
        }

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Divide(ref Transform left, Complex right, out Transform result)
        {
            result.P = Complex.Divide(ref left.P, ref right);
            result.Q = Complex.Divide(ref left.Q, ref right);
        }
    }
}