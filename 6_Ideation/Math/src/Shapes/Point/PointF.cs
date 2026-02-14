// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PointF.cs
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

namespace Alis.Core.Aspect.Math.Shapes.Point
{
    /// <summary>
    ///     The f point
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PointF : IShape
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PointF" /> class
        /// </summary>
        /// <param name="value">The value</param>
        public PointF(float value)
        {
            X = value;
            Y = value;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PointF" /> class
        /// </summary>
        /// <param name="point">The point</param>
        public PointF(PointF point)
        {
            X = point.X;
            Y = point.Y;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PointF" /> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public PointF(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     The X
        /// </summary>
        public float X { get; set; }

        /// <summary>
        ///     The Y
        /// </summary>
        public float Y { get; set; }
    }
}