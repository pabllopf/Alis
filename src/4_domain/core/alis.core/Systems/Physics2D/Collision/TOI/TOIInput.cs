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

using Alis.Core.Systems.Physics2D.Collision.Distance;

namespace Alis.Core.Systems.Physics2D.Collision.TOI
{
    /// <summary>Input parameters for CalculateTimeOfImpact</summary>
    public struct ToiInput
    {
        /// <summary>
        ///     The proxy
        /// </summary>
        public DistanceProxy ProxyA;

        /// <summary>
        ///     The proxy
        /// </summary>
        public DistanceProxy ProxyB;

        /// <summary>
        ///     The sweep
        /// </summary>
        public Sweep SweepA;

        /// <summary>
        ///     The sweep
        /// </summary>
        public Sweep SweepB;

        /// <summary>
        ///     The max
        /// </summary>
        public float Max; // defines sweep interval [0, tMax]
    }
}