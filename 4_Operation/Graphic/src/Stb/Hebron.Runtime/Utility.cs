// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Utility.cs
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

namespace Alis.Core.Graphic.Stb.Hebron.Runtime
{
    /// <summary>
    ///     The utility class
    /// </summary>
    internal class Utility
    {
        /// <summary>
        ///     Creates the array using the specified d 1
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="d1">The </param>
        /// <param name="d2">The </param>
        /// <returns>The result</returns>
        public static T[][] CreateArray<T>(int d1, int d2)
        {
            T[][] result = new T[d1][];
            for (int i = 0; i < d1; i++)
            {
                result[i] = new T[d2];
            }

            return result;
        }
    }
}