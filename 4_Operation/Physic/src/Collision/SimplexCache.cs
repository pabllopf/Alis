// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimplexCache.cs
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

using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     Used to warm start ComputeDistance.
    ///     Set count to zero on first call.
    /// </summary>
    public struct SimplexCache
    {
        /// <summary>
        ///     Length or area
        /// </summary>
        public ushort Count;

        /// <summary>
        ///     Vertices on shape A
        /// </summary>
        public FixedArray3<byte> IndexA;

        /// <summary>
        ///     Vertices on shape B
        /// </summary>
        public FixedArray3<byte> IndexB;

        /// <summary>
        ///     The metric
        /// </summary>
        public float Metric;
    }
}