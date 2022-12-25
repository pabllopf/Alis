// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TestPointHelper.cs
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
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     The test point helper class
    /// </summary>
    public static class TestPointHelper
    {
        /// <summary>
        ///     Describes whether test point circle
        /// </summary>
        /// <param name="pos">The pos</param>
        /// <param name="radius">The radius</param>
        /// <param name="point">The point</param>
        /// <param name="transform">The transform</param>
        /// <returns>The bool</returns>
        public static bool TestPointCircle(ref Vector2 pos, float radius, ref Vector2 point, ref Transform transform)
        {
            Vector2 center = transform.P + MathUtils.Mul(transform.Q, pos);
            Vector2 d = point - center;
            return Vector2.Dot(d, d) <= radius * radius;
        }

        /// <summary>
        ///     Describes whether test point polygon
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="normals">The normals</param>
        /// <param name="point">The point</param>
        /// <param name="transform">The transform</param>
        /// <returns>The bool</returns>
        public static bool TestPointPolygon(Vertices vertices, Vertices normals, ref Vector2 point,
            ref Transform transform)
        {
            Vector2 pLocal = MathUtils.MulT(transform.Q, point - transform.P);

            for (int i = 0; i < vertices.Count; ++i)
            {
                float dot = Vector2.Dot(normals[i], pLocal - vertices[i]);
                if (dot > 0.0f)
                {
                    return false;
                }
            }

            return true;
        }
    }
}