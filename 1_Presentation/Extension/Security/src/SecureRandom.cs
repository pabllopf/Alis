// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureRandom.cs
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

namespace Alis.Extension.Security
{
    /// <summary>
    ///     The secure random class
    /// </summary>
    internal static class SecureRandom
    {
        /// <summary>
        ///     Generates a cryptographically random int
        /// </summary>
        /// <returns>A random int value</returns>
        public static int NextInt()
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            byte[] bytes = new byte[sizeof(int)]; // 4 bytes
            random.GetNonZeroBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        ///     Generates a cryptographically random char
        /// </summary>
        /// <returns>A random char value</returns>
        public static char NextChar()
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            byte[] bytes = new byte[sizeof(char)]; // 2 bytes
            random.GetNonZeroBytes(bytes);
            return BitConverter.ToChar(bytes, 0);
        }

        /// <summary>
        ///     Generates a cryptographically random long
        /// </summary>
        /// <returns>A random long value</returns>
        public static long NextLong()
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            byte[] bytes = new byte[sizeof(long)]; // 8 bytes
            random.GetNonZeroBytes(bytes);
            return BitConverter.ToInt64(bytes, 0);
        }

        /// <summary>
        ///     Generates a cryptographically random double within the specified range
        /// </summary>
        /// <param name="min">The minimum value (inclusive)</param>
        /// <param name="max">The maximum value (exclusive)</param>
        /// <returns>A random double between min and max</returns>
        public static double NextDouble(int min, int max)
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            byte[] bytes = new byte[sizeof(long)]; // 8 bytes
            random.GetNonZeroBytes(bytes);
            long randomLong = BitConverter.ToInt64(bytes, 0);
            double range = max - min;
            double randomDouble = min + Abs(randomLong) / (double) long.MaxValue * range;
            return randomDouble;
        }

        /// <summary>
        ///     Computes the absolute value of a float
        /// </summary>
        /// <param name="value">The input value</param>
        /// <returns>The absolute (non-negative) value</returns>
        public static float Abs(float value) => value < 0f ? -value : value;


        /// <summary>
        ///     Generates a cryptographically random decimal within the specified range
        /// </summary>
        /// <param name="min">The minimum value (inclusive)</param>
        /// <param name="max">The maximum value (exclusive)</param>
        /// <returns>A random decimal between min and max</returns>
        public static decimal NextDecimal(int min, int max)
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            byte[] bytes = new byte[sizeof(int)]; // 4 bytes
            random.GetNonZeroBytes(bytes);
            int randomInt = BitConverter.ToInt32(bytes, 0);
            decimal range = max - min;
            decimal randomDecimal = (decimal) (min + Abs(randomInt) / (double) int.MaxValue * (double) range);
            return randomDecimal;
        }

        /// <summary>
        ///     Generates a cryptographically random byte
        /// </summary>
        /// <returns>A random byte value</returns>
        public static byte NextByte()
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            byte[] bytes = new byte[sizeof(byte)]; // 1 byte
            random.GetNonZeroBytes(bytes);
            return bytes[0];
        }

        /// <summary>
        ///     Generates a cryptographically random float within the specified range
        /// </summary>
        /// <param name="min">The minimum value (inclusive)</param>
        /// <param name="max">The maximum value (exclusive)</param>
        /// <returns>A random float between min and max</returns>
        public static float NextFloat(int min, int max)
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            byte[] bytes = new byte[sizeof(int)]; // 4 bytes
            random.GetNonZeroBytes(bytes);
            int randomInt = BitConverter.ToInt32(bytes, 0);
            float range = max - min;
            float randomFloat = min + Abs(randomInt) / int.MaxValue * range;
            return randomFloat;
        }
    }
}