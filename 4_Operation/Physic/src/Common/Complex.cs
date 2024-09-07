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
#if XNAAPI
using Complex = nkast.Aether.Physics2D.Common.Complex;
using Vector2 = Microsoft.Xna.Framework.Vector2;
#endif

namespace Alis.Core.Physic.Common
{
    public struct Complex
    {
        public float R;
        public float i;

        public static Complex One { get; } = new Complex(1, 0);

        public static Complex ImaginaryOne { get; } = new Complex(0, 1);

        public float Phase
        {
            get => (float) Math.Atan2(i, R);
            set
            {
                if (value == 0)
                {
                    this = One;
                    return;
                }

                R = (float) Math.Cos(value);
                i = (float) Math.Sin(value);
            }
        }

        public float Magnitude => (float) Math.Sqrt(MagnitudeSquared());


        public Complex(float real, float imaginary)
        {
            R = real;
            i = imaginary;
        }

        public static Complex FromAngle(float angle)
        {
            if (angle == 0)
                return One;

            return new Complex(
                (float) Math.Cos(angle),
                (float) Math.Sin(angle));
        }

        public void Conjugate()
        {
            i = -i;
        }

        public void Negate()
        {
            R = -R;
            i = -i;
        }

        public float MagnitudeSquared() => R * R + i * i;

        public void Normalize()
        {
            var mag = Magnitude;
            R = R / mag;
            i = i / mag;
        }

        public Vector2 ToVector2() => new Vector2(R, i);

        public static Complex Multiply(ref Complex left, ref Complex right) => new Complex(left.R * right.R - left.i * right.i,
            left.i * right.R + left.R * right.i);

        public static Complex Divide(ref Complex left, ref Complex right) => new Complex(right.R * left.R + right.i * left.i,
            right.R * left.i - right.i * left.R);

        public static void Divide(ref Complex left, ref Complex right, out Complex result)
        {
            result = new Complex(right.R * left.R + right.i * left.i,
                right.R * left.i - right.i * left.R);
        }

        public static Vector2 Multiply(ref Vector2 left, ref Complex right) => new Vector2(left.X * right.R - left.Y * right.i,
            left.Y * right.R + left.X * right.i);

        public static void Multiply(ref Vector2 left, ref Complex right, out Vector2 result)
        {
            result = new Vector2(left.X * right.R - left.Y * right.i,
                left.Y * right.R + left.X * right.i);
        }

        public static Vector2 Multiply(Vector2 left, ref Complex right) => new Vector2(left.X * right.R - left.Y * right.i,
            left.Y * right.R + left.X * right.i);

        public static Vector2 Divide(ref Vector2 left, ref Complex right) => new Vector2(left.X * right.R + left.Y * right.i,
            left.Y * right.R - left.X * right.i);

        public static Vector2 Divide(Vector2 left, ref Complex right) => new Vector2(left.X * right.R + left.Y * right.i,
            left.Y * right.R - left.X * right.i);

        public static void Divide(Vector2 left, ref Complex right, out Vector2 result)
        {
            result = new Vector2(left.X * right.R + left.Y * right.i,
                left.Y * right.R - left.X * right.i);
        }

        public static Complex Conjugate(ref Complex value) => new Complex(value.R, -value.i);

        public static Complex Negate(ref Complex value) => new Complex(-value.R, -value.i);

        public static Complex Normalize(ref Complex value)
        {
            var mag = value.Magnitude;
            return new Complex(value.R / mag, -value.i / mag);
        }

        public override string ToString() => string.Format("{{R: {0} i: {1} Phase: {2} Magnitude: {3}}}", R, i, Phase, Magnitude);
    }
}