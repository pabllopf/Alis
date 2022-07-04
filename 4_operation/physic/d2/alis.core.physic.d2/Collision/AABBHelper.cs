// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   AABBHelper.cs
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

using System.Numerics;
using Alis.Core.Physic.D2.Config;
using Alis.Core.Physic.D2.Shared;
using Alis.Core.Physic.D2.Utilities;

namespace Alis.Core.Physic.D2.Collision
{
    /// <summary>
    ///     The aabb helper class
    /// </summary>
    public static class AabbHelper
    {
        /// <summary>
        ///     Computes the edge aabb using the specified start
        /// </summary>
        /// <param name="start">The start</param>
        /// <param name="end">The end</param>
        /// <param name="transform">The transform</param>
        /// <param name="aabb">The aabb</param>
        public static void ComputeEdgeAabb(ref Vector2 start, ref Vector2 end, ref Transform transform, out Aabb aabb)
        {
            Vector2 v1 = MathUtils.Mul(ref transform, ref start);
            Vector2 v2 = MathUtils.Mul(ref transform, ref end);

            aabb.LowerBound = Vector2.Min(v1, v2);
            aabb.UpperBound = Vector2.Max(v1, v2);

            Vector2 r = new Vector2(Settings.PolygonRadius, Settings.PolygonRadius);
            aabb.LowerBound -= r;
            aabb.UpperBound += r;
        }

        /// <summary>
        ///     Computes the circle aabb using the specified pos
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="radius">The radius</param>
        /// <param name="transform">The transform</param>
        /// <param name="aabb">The aabb</param>
        public static void ComputeCircleAabb(ref Vector2 pos, float radius, ref Transform transform, out Aabb aabb)
        {
            Vector2 p = transform.P + MathUtils.Mul(transform.Q, pos);
            aabb.LowerBound = new Vector2(p.X - radius, p.Y - radius);
            aabb.UpperBound = new Vector2(p.X + radius, p.Y + radius);
        }

        /// <summary>
        ///     Computes the polygon aabb using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="transform">The transform</param>
        /// <param name="aabb">The aabb</param>
        public static void ComputePolygonAabb(Vertices vertices, ref Transform transform, out Aabb aabb)
        {
            Vector2 lower = MathUtils.Mul(ref transform, vertices[0]);
            Vector2 upper = lower;

            for (int i = 1; i < vertices.Count; ++i)
            {
                Vector2 v = MathUtils.Mul(ref transform, vertices[i]);
                lower = Vector2.Min(lower, v);
                upper = Vector2.Max(upper, v);
            }

            Vector2 r = new Vector2(Settings.PolygonRadius, Settings.PolygonRadius);
            aabb.LowerBound = lower - r;
            aabb.UpperBound = upper + r;
        }
    }
}