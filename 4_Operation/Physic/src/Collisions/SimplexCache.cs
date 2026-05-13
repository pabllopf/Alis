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

using System.Runtime.InteropServices;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Caches the simplex state from a GJK distance computation for warm starting subsequent calls.
    ///     Storing the vertex indices and metric allows the GJK algorithm to resume from a good
    ///     initial simplex rather than starting from scratch, significantly improving performance
    ///     for temporally coherent simulations. Set <see cref="Count"/> to zero on first call.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SimplexCache
    {
        /// <summary>
        ///     The number of vertices in the cached simplex (0-3). Set to 0 to force a fresh computation.
        /// </summary>
        public ushort Count;

        /// <summary>
        ///     The cached vertex indices on shape A that define the simplex in Minkowski space.
        /// </summary>
        public FixedArray3<byte> IndexA;

        /// <summary>
        ///     The cached vertex indices on shape B that define the simplex in Minkowski space.
        /// </summary>
        public FixedArray3<byte> IndexB;

        /// <summary>
        ///     The cached metric value (edge length or area) used to detect significant configuration changes.
        ///     If the new metric differs by more than a factor of 2, the cache is discarded.
        /// </summary>
        public float Metric;
    }
}