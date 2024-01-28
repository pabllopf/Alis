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
    ///     The random utils class
    /// </summary>
    public static class RandomUtils
    {
        /// <summary>
        ///     The create
        /// </summary>
        private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

        /// <summary>
        ///     Gets the int 32 using the specified min value
        /// </summary>
        /// <param name="minValue">The min value</param>
        /// <param name="maxValue">The max value</param>
        /// <exception cref="ArgumentException">minValue must be less than or equal to maxValue.</exception>
        /// <returns>The int</returns>
        public static int GetInt32(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("minValue must be less than or equal to maxValue.");
            }

            byte[] buffer = new byte[4];
            Rng.GetBytes(buffer);
            int randomValue = BitConverter.ToInt32(buffer, 0);

            return (int) (MathF.Abs(randomValue % (maxValue - minValue + 1)) + minValue);
        }

        /// <summary>
        ///     Gets the int 32 using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <exception cref="ArgumentException">value must be greater than or equal to 0.</exception>
        /// <returns>The int</returns>
        public static int GetInt32(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("value must be greater than or equal to 0.");
            }

            byte[] buffer = new byte[4];
            Rng.GetBytes(buffer);
            int randomValue = BitConverter.ToInt32(buffer, 0);

            return (int) MathF.Abs(randomValue % (value + 1));
        }
    }
}