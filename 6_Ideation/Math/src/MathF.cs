// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: MathF.cs
// 
//  Author: Pablo Perdomo Falcón
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

namespace Alis.Core.Aspect.Math
{
    /// <summary>
    ///     The math class
    /// </summary>
    public static class MathF
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
        ///     Sqrts the x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The float</returns>
        public static float Sqrt(float x)
        {
            if (x < 0f)
            {
                return float.NaN;
            }

            if (x == 0f)
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
        ///     Abses the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The float</returns>
        public static float Abs(float value) => value < 0f ? -value : value;

        /// <summary>
        ///     Coses the x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The result</returns>
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
        ///     Sins the x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The result</returns>
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
        ///     Acoses the x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The angle</returns>
        public static float Acos(float x)
        {
            if (x < -1f || x > 1f || float.IsNaN(x))
            {
                return float.NaN;
            }

            float angle = Pi / 2; // Initial guess of pi/2
            float term = x;
            float factor = x;
            float squared = x * x;

            for (int i = 1; i <= MaxIterations; i++)
            {
                term *= squared * (2 * i - 1) / (2 * i * i * 4);
                factor *= squared;
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
        /// Maxes the val 1
        /// </summary>
        /// <param name="val1">The val</param>
        /// <param name="val2">The val</param>
        /// <returns>The int</returns>
        public static int Max(int val1, int val2)
        {
            return (val1 >= val2) ? val1 : val2;
        }
    }
}