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

namespace Alis.Core.Aspect.Security
{
    /// <summary>
    ///     The secure random class
    /// </summary>
    internal static class SecureRandom
    {
        /// <summary>
        ///     Nexts the int
        /// </summary>
        /// <returns>The int</returns>
        public static int NextInt()
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            byte[] bytes = new byte[sizeof(int)]; // 4 bytes
            random.GetNonZeroBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        ///     Nexts the char
        /// </summary>
        /// <returns>The char</returns>
        public static char NextChar()
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            byte[] bytes = new byte[sizeof(char)]; // 2 bytes
            random.GetNonZeroBytes(bytes);
            return BitConverter.ToChar(bytes, 0);
        }

        /// <summary>
        ///     Nexts the long
        /// </summary>
        /// <returns>The long</returns>
        public static long NextLong()
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            byte[] bytes = new byte[sizeof(long)]; // 8 bytes
            random.GetNonZeroBytes(bytes);
            return BitConverter.ToInt64(bytes, 0);
        }

        /// <summary>
        ///     Nexts the double using the specified i
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="i1">The </param>
        /// <returns>The random double</returns>
        public static double NextDouble(int i, int i1)
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            byte[] bytes = new byte[sizeof(long)]; // 8 bytes
            random.GetNonZeroBytes(bytes);
            long randomLong = BitConverter.ToInt64(bytes, 0);
            double range = i1 - i;
            double randomDouble = i + Abs(randomLong) / (double) long.MaxValue * range;
            return randomDouble;
        }

        /// <summary>
        ///     Abs the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The float</returns>
        public static float Abs(float value) => value < 0f ? -value : value;


        /// <summary>
        ///     Nexts the decimal using the specified i
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="i1">The </param>
        /// <returns>The random decimal</returns>
        public static decimal NextDecimal(int i, int i1)
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            byte[] bytes = new byte[sizeof(int)]; // 4 bytes
            random.GetNonZeroBytes(bytes);
            int randomInt = BitConverter.ToInt32(bytes, 0);
            decimal range = i1 - i;
            decimal randomDecimal = (decimal) (i + Abs(randomInt) / (double) int.MaxValue * (double) range);
            return randomDecimal;
        }

        /// <summary>
        ///     Nexts the byte
        /// </summary>
        /// <returns>The byte</returns>
        public static byte NextByte()
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            byte[] bytes = new byte[sizeof(byte)]; // 1 byte
            random.GetNonZeroBytes(bytes);
            return bytes[0];
        }

        /// <summary>
        ///     Nexts the float using the specified i
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="i1">The </param>
        /// <returns>The random float</returns>
        public static float NextFloat(int i, int i1)
        {
            RandomNumberGenerator random = RandomNumberGenerator.Create();
            byte[] bytes = new byte[sizeof(int)]; // 4 bytes
            random.GetNonZeroBytes(bytes);
            int randomInt = BitConverter.ToInt32(bytes, 0);
            float range = i1 - i;
            float randomFloat = i + Abs(randomInt) / int.MaxValue * range;
            return randomFloat;
        }
    }
}