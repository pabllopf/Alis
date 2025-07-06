// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CircleAbstract.cs
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

namespace Alis.Benchmark.InterfaceVsAbstract.Instancies
{
    /// <summary>
    ///     The circle abstract class
    /// </summary>
    /// <seealso cref="Shape" />
    public class CircleAbstract : Shape
    {
        /// <summary>
        ///     The radius
        /// </summary>
        private readonly float radius;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CircleAbstract" /> class
        /// </summary>
        /// <param name="r">The </param>
        public CircleAbstract(float r) => radius = r;

        /// <summary>
        ///     Gets the area
        /// </summary>
        /// <returns>The float</returns>
        public override float GetArea() => MathF.PI * radius * radius;
    }
}