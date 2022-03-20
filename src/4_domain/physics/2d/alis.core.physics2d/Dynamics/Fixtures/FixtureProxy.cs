// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   FixtureProxy.cs
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

using Alis.Core.Physics2D.Collision;

namespace Alis.Core.Physics2D.Dynamics.Fixtures
{
    /// <summary>
    /// The fixture proxy class
    /// </summary>
    internal class FixtureProxy
    {
        /// <summary>
        /// The aabb
        /// </summary>
        internal AABB aabb;
        /// <summary>
        /// The child index
        /// </summary>
        internal int childIndex;
        /// <summary>
        /// The fixture
        /// </summary>
        internal Fixture fixture;
        /// <summary>
        /// The proxy id
        /// </summary>
        internal int proxyId = -1;
    }
}