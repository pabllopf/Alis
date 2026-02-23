// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CryptoRandomNumberGenerator.cs
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
using Alis.Extension.Math.ProceduralDungeon.Interfaces;

namespace Alis.Extension.Math.ProceduralDungeon.Services
{
    /// <summary>
    ///     Implementation of <see cref="IRandomNumberGenerator" /> using cryptographic random number generation.
    ///     Provides secure random number generation for dungeon creation.
    /// </summary>
    public class CryptoRandomNumberGenerator : IRandomNumberGenerator, IDisposable
    {
        /// <summary>
        ///     The random number generator instance.
        /// </summary>
        private readonly RandomNumberGenerator _rng;

        /// <summary>
        ///     Indicates whether this instance has been disposed.
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CryptoRandomNumberGenerator" /> class.
        /// </summary>
        public CryptoRandomNumberGenerator()
        {
            _rng = RandomNumberGenerator.Create();
        }

        /// <summary>
        ///     Generates a random integer within the specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned.</param>
        /// <returns>A random integer between minValue (inclusive) and maxValue (exclusive).</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when minValue is greater than or equal to maxValue.</exception>
        public int Next(int minValue, int maxValue)
        {
            if (minValue >= maxValue)
                throw new ArgumentOutOfRangeException(nameof(minValue), "minValue must be less than maxValue.");

            long range = (long)maxValue - minValue;
            byte[] randomBytes = new byte[4];
            _rng.GetBytes(randomBytes);
            uint randomValue = BitConverter.ToUInt32(randomBytes, 0);
            return (int)(minValue + (randomValue % range));
        }

        /// <summary>
        ///     Generates a random integer between 0 and maxValue.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number returned.</param>
        /// <returns>A random integer between 0 (inclusive) and maxValue (exclusive).</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when maxValue is less than or equal to 0.</exception>
        public int Next(int maxValue)
        {
            if (maxValue <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxValue), "maxValue must be greater than 0.");

            return Next(0, maxValue);
        }

        /// <summary>
        ///     Generates a random byte value.
        /// </summary>
        /// <returns>A random byte value between 0 and 255.</returns>
        public byte NextByte()
        {
            byte[] randomByte = new byte[1];
            _rng.GetBytes(randomByte);
            return randomByte[0];
        }

        /// <summary>
        ///     Releases all resources used by this instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Releases the unmanaged resources used by this instance and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _rng?.Dispose();
                }

                _disposed = true;
            }
        }
    }
}

