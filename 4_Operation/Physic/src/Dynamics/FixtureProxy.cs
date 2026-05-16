// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixtureProxy.cs
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
using Alis.Core.Physic.Collisions;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     This proxy is used internally to connect fixtures to the broad-phase.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FixtureProxy
    {
        /// <summary>
        ///     The axis-aligned bounding box for this proxy, used for broad-phase collision detection.
        /// </summary>
        public Aabb Aabb;

        /// <summary>
        ///     The child index of the shape associated with this proxy.
        /// </summary>
        public int ChildIndex;

        /// <summary>
        ///     The fixture that owns this proxy.
        /// </summary>
        public Fixture Fixture;

        /// <summary>
        ///     The proxy ID in the broad-phase tree.
        /// </summary>
        public int ProxyId;
    }
}