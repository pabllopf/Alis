// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Check.cs
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

namespace Alis.Core.Aspect.Memory
{
    /// <summary>
    /// The check class
    /// </summary>
    public static class Check
    {
        /// <summary>
        /// Not the null using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <param name="paramName">The param name</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>The value</returns>
        public static T NotNull<T>(T value, string paramName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(paramName);
            }

            return value;
        }
        
        /// <summary>
        /// Not the null using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>The value</returns>
        public static T NotNull<T>(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return value;
        }
        
        /// <summary>
        /// Not the empty using the specified array
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="array">The array</param>
        /// <param name="paramName">The param name</param>
        /// <exception cref="ArgumentException">The array cannot be empty. </exception>
        /// <exception cref="ArgumentNullException">The array cannot be null.</exception>
        /// <returns>The array</returns>
        public static T[] NotNullAndNotEmpty<T>(T[] array, string paramName)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("The array cannot be empty.", paramName);
            }

            return array;
        }
        
        /// <summary>
        /// Not the null and not empty using the specified array
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="array">The array</param>
        /// <exception cref="ArgumentException">The array cannot be empty. </exception>
        /// <returns>The array</returns>
        public static T[] NotNullAndNotEmpty<T>(T[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("The array cannot be empty.", nameof(array));
            }

            return array;
        }
    }
}