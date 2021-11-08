// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   DebugViewFlags.cs
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

using System;

namespace Alis.Core.Systems.Physics2D.Extensions.DebugView
{
    /// <summary>
    ///     The debug view flags enum
    /// </summary>
    [Flags]
    public enum DebugViewFlags
    {
        /// <summary>Do not draw anything</summary>
        None = 0,

        /// <summary>Draw shapes.</summary>
        Shape = 1 << 0,

        /// <summary>Draw joint connections.</summary>
        Joint = 1 << 1,

        /// <summary>Draw axis aligned bounding boxes.</summary>
        AABB = 1 << 2,

        /// <summary>Draw broad-phase pairs.</summary>
        Pair = 1 << 3,

        /// <summary>Draw center of mass frame.</summary>
        CenterOfMass = 1 << 4,

        /// <summary>Draw useful debug data such as timings and number of bodies, joints, contacts and more.</summary>
        DebugPanel = 1 << 5,

        /// <summary>Draw contact points between colliding bodies.</summary>
        ContactPoints = 1 << 6,

        /// <summary>Draw contact normals. Need ContactPoints to be enabled first.</summary>
        ContactNormals = 1 << 7,

        /// <summary>Draws the vertices of polygons.</summary>
        PolygonPoints = 1 << 8,

        /// <summary>Draws the performance graph.</summary>
        PerformanceGraph = 1 << 9,

        /// <summary>Draws controllers.</summary>
        Controllers = 1 << 10
    }
}