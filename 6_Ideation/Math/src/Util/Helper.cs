// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Helper.cs
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

namespace Alis.Core.Aspect.Math.Util
{
    /// <summary>Contains commonly used precalculated values and mathematical operations for interpolation, clamping, angle conversion, and power-of-two testing.</summary>
    public static class Helper
    {
        /// <summary>
        ///     Returns the Cartesian coordinate for one axis of a point that is defined by a given triangle and two
        ///     normalized barycentric (areal) coordinates.
        /// </summary>
        /// <param name="value1">The coordinate on one axis of vertex 1 of the defining triangle.</param>
        /// <param name="value2">The coordinate on the same axis of vertex 2 of the defining triangle.</param>
        /// <param name="value3">The coordinate on the same axis of vertex 3 of the defining triangle.</param>
        /// <param name="amount1">
        ///     The normalized barycentric (areal) coordinate b2, equal to the weighting factor for vertex 2, the
        ///     coordinate of which is specified in value2.
        /// </param>
        /// <param name="amount2">
        ///     The normalized barycentric (areal) coordinate b3, equal to the weighting factor for vertex 3, the
        ///     coordinate of which is specified in value3.
        /// </param>
        /// <returns>Cartesian coordinate of the specified point with respect to the axis being used.</returns>
        public static float Barycentric(float value1, float value2, float value3, float amount1, float amount2) =>
            value1 + (value2 - value1) * amount1 + (value3 - value1) * amount2;

        /// <summary>Performs a Catmull-Rom interpolation using the specified positions.</summary>
        /// <param name="value1">The first position in the interpolation.</param>
        /// <param name="value2">The second position in the interpolation.</param>
        /// <param name="value3">The third position in the interpolation.</param>
        /// <param name="value4">The fourth position in the interpolation.</param>
        /// <param name="amount">Weighting factor.</param>
        /// <returns>A position that is the result of the Catmull-Rom interpolation.</returns>
        public static float CatmullRom(float value1, float value2, float value3, float value4, float amount)
        {
            // Using formula from http://www.mvps.org/directx/articles/catmull/
            // Internally using doubles not to lose precission
            double amountSquared = amount * amount;
            double amountCubed = amountSquared * amount;
            return (float) (0.5 * (2.0 * value2 +
                                   (value3 - value1) * amount +
                                   (2.0 * value1 - 5.0 * value2 + 4.0 * value3 - value4) * amountSquared +
                                   (3.0 * value2 - value1 - 3.0 * value3 + value4) * amountCubed));
        }

        /// <summary>Restricts a value to be within a specified range.</summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value. If <c>value</c> is less than <c>min</c>, <c>min</c> will be returned.</param>
        /// <param name="max">The maximum value. If <c>value</c> is greater than <c>max</c>, <c>max</c> will be returned.</param>
        /// <returns>The clamped value within the inclusive range [<paramref name="min" />, <paramref name="max" />].</returns>
        public static float Clamp(float value, float min, float max)
        {
            value = value > max ? max : value;
            value = value < min ? min : value;
            return value;
        }

        /// <summary>Calculates the absolute difference between two values.</summary>
        /// <param name="value1">The first source value.</param>
        /// <param name="value2">The second source value.</param>
        /// <returns>The absolute distance between the two values.</returns>
        public static float Distance(float value1, float value2) => System.Math.Abs(value1 - value2);

        /// <summary>Performs a Hermite spline interpolation.</summary>
        /// <param name="value1">The source position.</param>
        /// <param name="tangent1">The source tangent.</param>
        /// <param name="value2">The source position.</param>
        /// <param name="tangent2">The source tangent.</param>
        /// <param name="amount">Weighting factor.</param>
        /// <returns>The result of the Hermite spline interpolation.</returns>
        public static float Hermite(float value1, float tangent1, float value2, float tangent2, float amount)
        {
            double v1 = value1, v2 = value2, t1 = tangent1, t2 = tangent2, s = amount;
            double sCubed = s * s * s;
            double sSquared = s * s;

            double result = amount switch
            {
                0f => value1,
                1f => value2,
                _ => (2 * v1 - 2 * v2 + t2 + t1) * sCubed + (3 * v2 - 3 * v1 - 2 * t1 - t2) * sSquared + t1 * s + v1
            };

            return (float) result;
        }


        /// <summary>
        ///     Linearly interpolates between two values based on the given weighting.
        /// </summary>
        /// <param name="value1">The first (source) value.</param>
        /// <param name="value2">The second (destination) value.</param>
        /// <param name="amount">A value between 0 and 1 indicating the weight of <paramref name="value2" />.</param>
        /// <returns>The interpolated value.</returns>
        public static float Lerp(float value1, float value2, float amount) => value1 + (value2 - value1) * amount;

        /// <summary>Returns the greater of two values.</summary>
        /// <param name="value1">The first source value.</param>
        /// <param name="value2">The second source value.</param>
        /// <returns>The greater value.</returns>
        public static float Max(float value1, float value2) => value1 > value2 ? value1 : value2;

        /// <summary>Returns the lesser of two values.</summary>
        /// <param name="value1">The first source value.</param>
        /// <param name="value2">The second source value.</param>
        /// <returns>The lesser value.</returns>
        public static float Min(float value1, float value2) => value1 < value2 ? value1 : value2;

        /// <summary>Interpolates between two values using a cubic equation (smooth step).</summary>
        /// <param name="value1">The first source value.</param>
        /// <param name="value2">The second source value.</param>
        /// <param name="amount">Weighting value (expected between 0 and 1).</param>
        /// <returns>The smoothly interpolated value.</returns>
        public static float SmoothStep(float value1, float value2, float amount)
        {
            float result = Clamp(amount, 0f, 1f);
            result = Hermite(value1, 0f, value2, 0f, result);
            return result;
        }

        /// <summary>Converts radians to degrees.</summary>
        /// <param name="radians">The angle in radians.</param>
        /// <returns>The angle in degrees.</returns>
        /// <remarks>This method uses double precision internally, though it returns a single float. Factor = 180 / pi.</remarks>
        public static float ToDegrees(float radians) => (float) (radians * 57.295779513082320876798154814105);

        /// <summary>Converts degrees to radians.</summary>
        /// <param name="degrees">The angle in degrees.</param>
        /// <returns>The angle in radians.</returns>
        /// <remarks>This method uses double precision internally, though it returns a single float. Factor = pi / 180.</remarks>
        public static float ToRadians(float degrees) => (float) (degrees * 0.017453292519943295769236907684886);

        /// <summary>Reduces a given angle to a value between π and -π.</summary>
        /// <param name="angle">The angle to reduce, in radians.</param>
        /// <returns>The wrapped angle in radians within the range [-π, π].</returns>
        [ExcludeFromCodeCoverage]
        public static float WrapAngle(float angle)
        {
            if ((angle > -Constant.Pi) && (angle <= Constant.Pi))
            {
                return angle;
            }

            angle %= Constant.TwoPi;
            if (angle <= -Constant.Pi)
            {
                return angle + Constant.TwoPi;
            }

            if (angle > Constant.Pi)
            {
                return angle - Constant.TwoPi;
            }

            return angle;
        }

        /// <summary>Determines if a value is a power of two.</summary>
        /// <param name="value">The value to test.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is a power of two; otherwise, <c>false</c>.</returns>
        public static bool IsPowerOfTwo(int value) => (value > 0) && ((value & (value - 1)) == 0);
    }
}
