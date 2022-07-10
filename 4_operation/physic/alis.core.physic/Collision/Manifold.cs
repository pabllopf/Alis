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

using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     A manifold for two touching convex shapes.
    /// </summary>
    public class Manifold
    {
        /// <summary>
        ///     The local plane normal
        /// </summary>
        public Vec2 LocalPlaneNormal;

        /// <summary>
        ///     Usage depends on manifold type.
        /// </summary>
        public Vec2 LocalPoint;

        /// <summary>
        ///     The number of manifold points.
        /// </summary>
        public int PointCount;

        /// <summary>
        ///     The points of contact.
        /// </summary>
        public ManifoldPoint[ /*Settings.MaxManifoldPoints*/] Points = new ManifoldPoint[Settings.MaxManifoldPoints];

        /// <summary>
        ///     The type
        /// </summary>
        public ManifoldType Type;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Manifold" /> class
        /// </summary>
        public Manifold()
        {
            for (int i = 0; i < Settings.MaxManifoldPoints; i++)
            {
                Points[i] = new ManifoldPoint();
            }
        }

        /// <summary>
        ///     Clones this instance
        /// </summary>
        /// <returns>The new manifold</returns>
        public Manifold Clone()
        {
            Manifold newManifold = new Manifold();
            newManifold.LocalPlaneNormal = LocalPlaneNormal;
            newManifold.LocalPoint = LocalPoint;
            newManifold.Type = Type;
            newManifold.PointCount = PointCount;
            int pointCount = Points.Length;
            ManifoldPoint[] tmp = new ManifoldPoint[pointCount];
            for (int i = 0; i < pointCount; i++)
            {
                tmp[i] = Points[i].Clone();
            }

            newManifold.Points = tmp;
            return newManifold;
        }
    }
}