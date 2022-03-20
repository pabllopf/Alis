// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TOIInput.cs
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

using Alis.Core.Physics2D.Common;

namespace Alis.Core.Physics2D.Collision
{
    /// <summary>
    ///     Inpute parameters for TimeOfImpact
    /// </summary>
    internal struct TOIInput
    {
        /// <summary>
        /// The sweep
        /// </summary>
        internal Sweep sweepA;

        /// <summary>
        /// The sweep
        /// </summary>
        internal Sweep sweepB;

        // internal float         sweepRadiusA;
        // internal float         sweepRadiusB;
        // internal float         tolerance;
        /// <summary>
        /// The proxy
        /// </summary>
        internal DistanceProxy proxyA;
        /// <summary>
        /// The proxy
        /// </summary>
        internal DistanceProxy proxyB;
        /// <summary>
        /// The max
        /// </summary>
        internal float tMax;
    }
}