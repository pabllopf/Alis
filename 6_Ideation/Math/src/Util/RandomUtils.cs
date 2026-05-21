// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RandomUtils.cs
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
using System.Security.Cryptography;

namespace Alis.Core.Aspect.Math.Util
{
    /// <summary>
    ///     Provides cryptographically secure random number generation for 32-bit signed integers.
    /// </summary>
    public static class RandomUtils
    {
        /// <summary>
        ///     The cryptographic random number generator instance used for all operations.
        /// </summary>
        private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

        /// <summary>
        ///     Generates a cryptographically random 32-bit signed integer within the specified inclusive range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The inclusive upper bound of the random number returned. Must be greater than or equal to <paramref name="minValue" />.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="minValue" /> is greater than <paramref name="maxValue" />.</exception>
        /// <returns>A random 32-bit signed integer between <paramref name="minValue" /> and <paramref name="maxValue" />, inclusive.</returns>
        public static int GetInt32(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("minValue must be less than or equal to maxValue.");
            }

            byte[] buffer = new byte[4];
            Rng.GetBytes(buffer);
            int randomValue = BitConverter.ToInt32(buffer, 0);

            return System.Math.Abs(randomValue % (maxValue - minValue + 1)) + minValue;
        }

        /// <summary>
        ///     Generates a cryptographically random 32-bit signed integer between 0 (inclusive) and the specified upper bound (inclusive).
        /// </summary>
        /// <param name="value">The inclusive upper bound. Must be greater than or equal to 0.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="value" /> is less than 0.</exception>
        /// <returns>A random 32-bit signed integer between 0 and <paramref name="value" />, inclusive.</returns>
        public static int GetInt32(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("value must be greater than or equal to 0.");
            }

            byte[] buffer = new byte[4];
            Rng.GetBytes(buffer);
            int randomValue = BitConverter.ToInt32(buffer, 0);

            return System.Math.Abs(randomValue % (value + 1));
        }
    }
}
