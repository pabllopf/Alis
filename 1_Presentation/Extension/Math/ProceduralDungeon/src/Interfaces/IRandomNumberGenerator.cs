// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IRandomNumberGenerator.cs
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

namespace Alis.Extension.Math.ProceduralDungeon.Interfaces
{
    /// <summary>
    ///     Interface for random number generation.
    ///     Provides abstraction for generating random numbers to improve testability.
    /// </summary>
    public interface IRandomNumberGenerator
    {
        /// <summary>
        ///     Generates a random integer within the specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned.</param>
        /// <returns>A random integer between minValue (inclusive) and maxValue (exclusive).</returns>
        int Next(int minValue, int maxValue);
        
        /// <summary>
        ///     Generates a random integer between 0 and maxValue.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number returned.</param>
        /// <returns>A random integer between 0 (inclusive) and maxValue (exclusive).</returns>
        int Next(int maxValue);
        
        /// <summary>
        ///     Generates a random byte value.
        /// </summary>
        /// <returns>A random byte value.</returns>
        byte NextByte();
    }
}

