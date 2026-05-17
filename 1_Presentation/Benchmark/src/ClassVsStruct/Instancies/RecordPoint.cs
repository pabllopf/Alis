// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RecordPoint.cs
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
    ///     Represents a point as an immutable record type with X and Y coordinates.
    /// </summary>
    public record RecordPoint
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="RecordPoint" /> record.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public RecordPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Gets the X coordinate.
        /// </summary>
        public int X { get; init; }

        /// <summary>
        ///     Gets the Y coordinate.
        /// </summary>
        public int Y { get; init; }
    }
}