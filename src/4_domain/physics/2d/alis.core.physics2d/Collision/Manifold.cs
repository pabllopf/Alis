// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Manifold.cs
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

using System.Diagnostics;
using System.Numerics;
using Alis.Core.Physics2D.Common;

namespace Alis.Core.Physics2D.Collision
{
    /// <summary>
    ///     A manifold for two touching convex shapes.
    /// </summary>
    [DebuggerDisplay("localNormal = {" + nameof(localNormal) + "}")]
    public class Manifold
    {
        /// <summary>
        /// The local normal
        /// </summary>
        internal Vector2 localNormal;

        /// <summary>
        ///     Usage depends on manifold type.
        /// </summary>
        internal Vector2 localPoint;

        /// <summary>
        ///     The number of manifold points.
        /// </summary>
        internal int pointCount;

        /// <summary>
        ///     The points of contact.
        /// </summary>
        internal ManifoldPoint[ /*Settings.MaxManifoldPoints*/] points = new ManifoldPoint[Settings.MaxManifoldPoints];

        /// <summary>
        /// The type
        /// </summary>
        internal ManifoldType type;

        /// <summary>
        /// Initializes a new instance of the <see cref="Manifold"/> class
        /// </summary>
        internal Manifold()
        {
            // for (int i = 0; i < Settings.MaxManifoldPoints; i++)
            //   points[i] = new ManifoldPoint();
        }
    }
}