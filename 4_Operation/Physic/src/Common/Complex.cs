// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Complex.cs
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

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     The complex
    /// </summary>
    public struct Complex
    {
        /// <summary>
        ///     The
        /// </summary>
        public float R;

        /// <summary>
        ///     The
        /// </summary>
        public float i;

        /// <summary>
        ///     Gets the value of the one
        /// </summary>
        public static Complex One { get; } = new Complex(1, 0);

        /// <summary>
        ///     Gets the value of the imaginary one
        /// </summary>
        public static Complex ImaginaryOne { get; } = new Complex(0, 1);

        /// <summary>
        ///     Gets or sets the value of the phase
        /// </summary>
        public float Phase
        {
            get => (float) Math.Atan2(i, R);
            set
            {
                if (Math.Abs(value) < float.Epsilon)
                {
                    this = One;
                    return;
                }

                R = (float) Math.Cos(value);
                i = (float) Math.Sin(value);
            }
        }

        /// <summary>
        ///     Gets the value of the magnitude
        /// </summary>
        public float Magnitude => (float) Math.Sqrt(MagnitudeSquared());


        /// <summary>
        ///     Initializes a new instance of the <see cref="Complex" /> class
        /// </summary>
        /// <param name="real">The real</param>
        /// <param name="imaginary">The imaginary</param>
        public Complex(float real, float imaginary)
        {
            R = real;
            i = imaginary;
        }

        /// <summary>
        ///     Creates the angle using the specified angle
        /// </summary>
        /// <param name="angle">The angle</param>
        /// <returns>The complex</returns>
        public static Complex FromAngle(float angle)
        {
            if (Math.Abs(angle) < float.Epsilon)
            {
                return One;
            }

            return new Complex(
                (float) Math.Cos(angle),
                (float) Math.Sin(angle));
        }

        /// <summary>
        ///     Conjugates this instance
        /// </summary>
        public void Conjugate()
        {
            i = -i;
        }

        /// <summary>
        ///     Negates this instance
        /// </summary>
        public void Negate()
        {
            R = -R;
            i = -i;
        }

        /// <summary>
        ///     Magnitudes the squared
        /// </summary>
        /// <returns>The float</returns>
        public float MagnitudeSquared() => R * R + i * i;

        /// <summary>
        ///     Normalizes this instance
        /// </summary>
        public void Normalize()
        {
            float mag = Magnitude;
            R = R / mag;
            i = i / mag;
        }

        /// <summary>
        ///     Returns the vector 2
        /// </summary>
        /// <returns>The vector</returns>
        public Vector2F ToVector2() => new Vector2F(R, i);

        /// <summary>
        ///     Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The complex</returns>
        public static Complex Multiply(ref Complex left, ref Complex right) => new Complex(left.R * right.R - left.i * right.i,
            left.i * right.R + left.R * right.i);

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The complex</returns>
        public static Complex Divide(ref Complex left, ref Complex right) => new Complex(right.R * left.R + right.i * left.i,
            right.R * left.i - right.i * left.R);

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Divide(ref Complex left, ref Complex right, out Complex result)
        {
            result = new Complex(right.R * left.R + right.i * left.i,
                right.R * left.i - right.i * left.R);
        }

        /// <summary>
        ///     Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The vector</returns>
        public static Vector2F Multiply(ref Vector2F left, ref Complex right) => new Vector2F(left.X * right.R - left.Y * right.i,
            left.Y * right.R + left.X * right.i);

        /// <summary>
        ///     Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Multiply(ref Vector2F left, ref Complex right, out Vector2F result)
        {
            result = new Vector2F(left.X * right.R - left.Y * right.i,
                left.Y * right.R + left.X * right.i);
        }

        /// <summary>
        ///     Multiplies the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The vector</returns>
        public static Vector2F Multiply(Vector2F left, ref Complex right) => new Vector2F(left.X * right.R - left.Y * right.i,
            left.Y * right.R + left.X * right.i);

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The vector</returns>
        public static Vector2F Divide(ref Vector2F left, ref Complex right) => new Vector2F(left.X * right.R + left.Y * right.i,
            left.Y * right.R - left.X * right.i);

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <returns>The vector</returns>
        public static Vector2F Divide(Vector2F left, ref Complex right) => new Vector2F(left.X * right.R + left.Y * right.i,
            left.Y * right.R - left.X * right.i);

        /// <summary>
        ///     Divides the left
        /// </summary>
        /// <param name="left">The left</param>
        /// <param name="right">The right</param>
        /// <param name="result">The result</param>
        public static void Divide(Vector2F left, ref Complex right, out Vector2F result)
        {
            result = new Vector2F(left.X * right.R + left.Y * right.i,
                left.Y * right.R - left.X * right.i);
        }

        /// <summary>
        ///     Conjugates the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The complex</returns>
        public static Complex Conjugate(ref Complex value) => new Complex(value.R, -value.i);

        /// <summary>
        ///     Negates the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The complex</returns>
        public static Complex Negate(ref Complex value) => new Complex(-value.R, -value.i);

        /// <summary>
        ///     Normalizes the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The complex</returns>
        public static Complex Normalize(ref Complex value)
        {
            float mag = value.Magnitude;
            return new Complex(value.R / mag, -value.i / mag);
        }

        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => string.Format("{{R: {0} i: {1} Phase: {2} Magnitude: {3}}}", R, i, Phase, Magnitude);
    }
}