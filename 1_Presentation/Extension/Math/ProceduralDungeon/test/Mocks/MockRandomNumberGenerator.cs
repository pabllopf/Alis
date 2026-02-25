// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MockRandomNumberGenerator.cs
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

using Alis.Extension.Math.ProceduralDungeon.Interfaces;

namespace Alis.Extension.Math.ProceduralDungeon.Test.Mocks
{
    /// <summary>
    ///     Mock implementation of <see cref="IRandomNumberGenerator" /> for testing purposes.
    ///     Provides predictable random number generation for deterministic tests.
    /// </summary>
    public class MockRandomNumberGenerator : IRandomNumberGenerator
    {
        /// <summary>
        ///     The value to return from random number generation methods.
        /// </summary>
        private int _value;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MockRandomNumberGenerator" /> class.
        /// </summary>
        /// <param name="value">The initial value to return.</param>
        public MockRandomNumberGenerator(int value = 1)
        {
            _value = value;
        }

        /// <summary>
        ///     Generates a random integer within the specified range.
        ///     Returns the configured mock value.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound (ignored in mock).</param>
        /// <param name="maxValue">The exclusive upper bound (ignored in mock).</param>
        /// <returns>The configured mock value.</returns>
        public int Next(int minValue, int maxValue)
        {
            return _value;
        }

        /// <summary>
        ///     Generates a random integer between 0 and maxValue.
        ///     Returns the configured mock value.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound (ignored in mock).</param>
        /// <returns>The configured mock value.</returns>
        public int Next(int maxValue)
        {
            return _value;
        }

        /// <summary>
        ///     Generates a random byte value.
        ///     Returns the configured mock value as a byte.
        /// </summary>
        /// <returns>The configured mock value as a byte.</returns>
        public byte NextByte()
        {
            return (byte)_value;
        }

        /// <summary>
        ///     Sets the value to be returned by random number generation methods.
        /// </summary>
        /// <param name="value">The value to return.</param>
        public void SetValue(int value)
        {
            _value = value;
        }

        /// <summary>
        ///     Gets the current configured value.
        /// </summary>
        /// <returns>The current value.</returns>
        public int GetValue()
        {
            return _value;
        }
    }
}

