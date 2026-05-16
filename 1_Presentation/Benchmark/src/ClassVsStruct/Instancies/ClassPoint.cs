// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ClassPoint.cs
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

namespace Alis.Benchmark.ClassVsStruct.Instancies
{
    /// <summary>
    ///     The class point class
    /// </summary>
    public class ClassPoint
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ClassPoint" /> class
        /// </summary>
        /// <param name="x">The X coordinate value</param>
        /// <param name="y">The Y coordinate value</param>
        public ClassPoint(int x, int y) => (X, Y) = (x, y);

        /// <summary>
        ///     Gets the value of the x
        /// </summary>
        public int X { get; }

        /// <summary>
        ///     Gets the value of the y
        /// </summary>
        public int Y { get; }
    }
}