// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CustomMathF.cs
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

using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Aspect.Math
{
    /// <summary>
    ///     Provides custom single-precision floating-point mathematical operations including square root,
    ///     trigonometric functions (sin, cos, tan, acos), absolute value, min/max, and clamping.
    ///     Uses Taylor series approximations where applicable with a fixed iteration count.
    /// </summary>
    public static class CustomMathF
    {
        /// <summary>Represents the natural logarithmic base, specified by the constant, <see langword="e" />.</summary>
        public const float E = 2.7182817f;

        /// <summary>Represents the ratio of the circumference of a circle to its diameter, specified by the constant, p.</summary>
        public const float Pi = 3.1415927f;

        /// <summary>Represents the number of radians in one turn, specified by the constant, τ.</summary>
        public const float Tau = 6.2831855f;

        /// <summary>
        ///     The max iterations
        /// </summary>
        private const int MaxIterations = 10;

        /// <summary>
        ///     Computes the square root of a single-precision floating-point number using Newton's method.
        /// </summary>
        /// <param name="x">The non-negative value whose square root is to be computed.</param>
        /// <returns>
        ///     The positive square root of <paramref name="x" />. Returns <see cref="float.NaN" /> if <paramref name="x" /> is negative.
        /// </returns>
        public static float Sqrt(float x)
        {
            if (x < 0f)
            {
                return float.NaN;
            }

            if ((Abs(x) < float.Epsilon) && (Abs(x) > -float.Epsilon))
            {
                return 0f;
            }

            float current = x;
            float previous;

            do
            {
                previous = current;
                current = (previous + x / previous) * 0.5f;
            } while (Abs(current - previous) > 0.0001f);

            return current;
        }

        /// <summary>
        ///     Returns the absolute value of a single-precision floating-point number.
        /// </summary>
        /// <param name="value">The value to compute the absolute value of.</param>
        /// <returns>The absolute value of <paramref name="value" />.</returns>
        public static float Abs(float value) => value < 0f ? -value : value;

        /// <summary>
        ///     Computes the cosine of a single-precision floating-point angle using a Taylor series approximation.
        /// </summary>
        /// <param name="x">The angle in radians.</param>
        /// <returns>
        ///     The cosine of <paramref name="x" />. Returns <see cref="float.NaN" /> if <paramref name="x" /> is
        ///     <see cref="float.NaN" /> or <see cref="float.PositiveInfinity" /> or <see cref="float.NegativeInfinity" />.
        /// </returns>
        public static float Cos(float x)
        {
            if (float.IsNaN(x) || float.IsInfinity(x))
            {
                return float.NaN;
            }

            // Normalize the angle to the range [0, 2π]
            x %= 2 * Pi;

            float result = 1.0f;
            float term = 1.0f;

            for (int i = 1; i <= MaxIterations; i++)
            {
                term *= -x * x / (2 * i * (2 * i - 1));
                result += term;
            }

            return result;
        }

        /// <summary>
        ///     Computes the sine of a single-precision floating-point angle using a Taylor series approximation.
        /// </summary>
        /// <param name="x">The angle in radians.</param>
        /// <returns>
        ///     The sine of <paramref name="x" />. Returns <see cref="float.NaN" /> if <paramref name="x" /> is
        ///     <see cref="float.NaN" /> or <see cref="float.PositiveInfinity" /> or <see cref="float.NegativeInfinity" />.
        /// </returns>
        [ExcludeFromCodeCoverage]
        public static float Sin(float x)
        {
            if (float.IsNaN(x) || float.IsInfinity(x))
            {
                return float.NaN;
            }

            // Normalize the angle to the range [-π, π]
            x %= 2 * Pi;

            // Reduce the angle to the range [-π/2, π/2] by using sin(x) = sin(π - x) for x > π/2
            if (x > Pi / 2)
            {
                x = Pi - x;
            }
            else if (x < -Pi / 2)
            {
                x = -Pi - x;
            }

            float result = x;
            float term = x;

            for (int i = 1; i <= MaxIterations; i++)
            {
                term *= -x * x / (2 * i * (2 * i + 1));
                result += term;
            }

            return result;
        }

        /// <summary>
        ///     Computes the arccosine (inverse cosine) of a single-precision floating-point number.
        /// </summary>
        /// <param name="x">A value between -1 and 1 representing the cosine of an angle.</param>
        /// <returns>
        ///     The arccosine of <paramref name="x" /> in radians. Returns <see cref="float.NaN" /> if <paramref name="x" />
        ///     is outside the interval [-1, 1] or is <see cref="float.NaN" />.
        /// </returns>
        [ExcludeFromCodeCoverage]
        public static float Acos(float x)
        {
            if (x < -1f || x > 1f || float.IsNaN(x))
            {
                return float.NaN;
            }

            float angle = Pi / 2; // Initial guess of pi/2
            float term = x;
            float squared = x * x;

            for (int i = 1; i <= MaxIterations; i++)
            {
                term *= squared * (2 * i - 1) / (2 * i * i * 4);
                float currentTerm = term / (2 * i + 1);
                angle -= currentTerm;

                if (Abs(currentTerm) < float.Epsilon)
                {
                    break;
                }
            }

            return angle;
        }

        /// <summary>
        ///     Returns the larger of two 32-bit signed integers.
        /// </summary>
        /// <param name="val1">The first value to compare.</param>
        /// <param name="val2">The second value to compare.</param>
        /// <returns>The larger of <paramref name="val1" /> and <paramref name="val2" />.</returns>
        public static int Max(int val1, int val2) => val1 >= val2 ? val1 : val2;

        /// <summary>
        ///     Returns the smaller of two 32-bit signed integers.
        /// </summary>
        /// <param name="y3">The first value to compare.</param>
        /// <param name="y4">The second value to compare.</param>
        /// <returns>The smaller of <paramref name="y3" /> and <paramref name="y4" />.</returns>
        public static int Min(int y3, int y4) => y3 <= y4 ? y3 : y4;

        /// <summary>
        ///     Returns the larger of two single-precision floating-point numbers.
        /// </summary>
        /// <param name="val1">The first value to compare.</param>
        /// <param name="val2">The second value to compare.</param>
        /// <returns>The larger of <paramref name="val1" /> and <paramref name="val2" />.</returns>
        public static float Max(float val1, float val2) => val1 >= val2 ? val1 : val2;

        /// <summary>
        ///     Returns the smaller of two single-precision floating-point numbers.
        /// </summary>
        /// <param name="y3">The first value to compare.</param>
        /// <param name="y4">The second value to compare.</param>
        /// <returns>The smaller of <paramref name="y3" /> and <paramref name="y4" />.</returns>
        public static float Min(float y3, float y4) => y3 <= y4 ? y3 : y4;

        /// <summary>
        ///     Clamps the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        /// <returns>The float</returns>
        public static float Clamp(float value, float min, float max)
        {
            if (value < min)
            {
                return min;
            }

            if (value > max)
            {
                return max;
            }

            return value;
        }

        /// <summary>
        ///     Tans the pi
        /// </summary>
        /// <param name="pi">The pi</param>
        /// <returns>The float</returns>
        public static float Tan(float pi)
        {
            if (float.IsNaN(pi) || float.IsInfinity(pi))
            {
                return float.NaN;
            }

            // Normalize the angle to the range [-π/2, π/2]
            pi %= Pi;

            // Handle the case where pi is close to ±π/2
            if (System.Math.Abs(pi - Pi / 2) < 0.01f || System.Math.Abs(pi - -Pi / 2) < 0.01f)
            {
                return float.PositiveInfinity; // or float.NaN, depending on your preference
            }

            return Sin(pi) / Cos(pi);
        }
    }
}