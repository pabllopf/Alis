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
        public Complex q;

        /// <summary>
        ///     The
        /// </summary>
        public Vector2F p;

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
            q = rotation;
            p = position;
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
                left.X * right.q.R - left.Y * right.q.I + right.p.X,
                left.Y * right.q.R + left.X * right.q.I + right.p.Y);

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
            float px = left.X - right.p.X;
            float py = left.Y - right.p.Y;
            return new Vector2F(
                px * right.q.R + py * right.q.I,
                py * right.q.R - px * right.q.I);
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
            float px = left.X - right.p.X;
            float py = left.Y - right.p.Y;
            result = new Vector2F(
                px * right.q.R + py * right.q.I,
                py * right.q.R - px * right.q.I);
        }

        /// <summary>
        ///     Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The transform</returns>
        public static Transform Multiply(ref Transform left, ref Transform right) => new Transform(
            Complex.Multiply(ref left.p, ref right.q) + right.p,
            Complex.Multiply(ref left.q, ref right.q));

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The transform</returns>
        public static Transform Divide(ref Transform left, ref Transform right) => new Transform(
            Complex.Divide(left.p - right.p, ref right.q),
            Complex.Divide(ref left.q, ref right.q));

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Divide(ref Transform left, ref Transform right, out Transform result)
        {
            Complex.Divide(left.p - right.p, ref right.q, out result.p);
            Complex.Divide(ref left.q, ref right.q, out result.q);
        }

        /// <summary>
        ///     Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Multiply(ref Transform left, Complex right, out Transform result)
        {
            result.p = Complex.Multiply(ref left.p, ref right);
            result.q = Complex.Multiply(ref left.q, ref right);
        }

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Divide(ref Transform left, Complex right, out Transform result)
        {
            result.p = Complex.Divide(ref left.p, ref right);
            result.q = Complex.Divide(ref left.q, ref right);
        }
    }
}