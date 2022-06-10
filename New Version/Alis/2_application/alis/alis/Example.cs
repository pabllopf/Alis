// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Example.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis
{

    /// <summary>
    /// The example class
    /// </summary>
    public static class Example
    {

        /// <summary>
        /// Sums the arg 1
        /// </summary>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <returns>The int</returns>
        public static int Sum(int arg1, int arg2)
        {
            return arg1 + arg2;
        }

        /// <summary>
        /// Sums the 63 using the specified arg 1
        /// </summary>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="other">The other</param>
        /// <returns>The int</returns>
        public static int Sum63(int arg1, int arg2, string other)
        {

            return arg1 + arg2;
        }
    }
}