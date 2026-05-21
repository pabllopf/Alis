// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LineF.cs
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

using System.Runtime.InteropServices;

namespace Alis.Core.Aspect.Math.Shapes.Line
{
    /// <summary>
    ///     Represents a line segment defined by two endpoints with single-precision floating-point coordinates. Implements <see cref="IShape" />.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LineF : IShape
    {
        /// <summary>
        ///     Gets or sets the X coordinate of the first endpoint.
        /// </summary>
        public float X1 { get; set; }

        /// <summary>
        ///     Gets or sets the Y coordinate of the first endpoint.
        /// </summary>
        public float Y1 { get; set; }

        /// <summary>
        ///     Gets or sets the X coordinate of the second endpoint.
        /// </summary>
        public float X2 { get; set; }

        /// <summary>
        ///     Gets or sets the Y coordinate of the second endpoint.
        /// </summary>
        public float Y2 { get; set; }
    }
}
