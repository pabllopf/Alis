// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   GiftWrap.cs
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

using Alis.Core.Aspect.Math;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Utilities;
using Vector2 = System.Numerics.Vector2;

namespace Alis.Core.Physic.Tools.ConvexHull
{
    /// <summary>
    ///     Giftwrap convex hull algorithm. O(n * h) time complexity, where n is the number of points and h is the number
    ///     of points on the convex hull. See http://en.wikipedia.org/wiki/Gift_wrapping_algorithm for more details.
    /// </summary>
    public static class GiftWrap
    {
        //Extracted from Box2D

        /// <summary>Returns the convex hull from the given vertices.</summary>
        /// <param name="vertices">The vertices.</param>
        public static Vertices GetConvexHull(Vertices vertices)
        {
            if (vertices.Count <= 3)
            {
                return vertices;
            }

            // Find the right most point on the hull
            int i0 = 0;
            float x0 = vertices[0].X;
            for (int i = 1; i < vertices.Count; ++i)
            {
                float x = vertices[i].X;
                if (x > x0 || x == x0 && vertices[i].Y < vertices[i0].Y)
                {
                    i0 = i;
                    x0 = x;
                }
            }

            int[] hull = new int[vertices.Count];
            int m = 0;
            int ih = i0;

            for (;;)
            {
                hull[m] = ih;

                int ie = 0;
                for (int j = 1; j < vertices.Count; ++j)
                {
                    if (ie == ih)
                    {
                        ie = j;
                        continue;
                    }

                    Vector2 r = vertices[ie] - vertices[hull[m]];
                    Vector2 v = vertices[j] - vertices[hull[m]];
                    float c = MathUtils.Cross(ref r, ref v);
                    if (c < 0.0f)
                    {
                        ie = j;
                    }

                    // Collinearity check
                    if (c == 0.0f && v.LengthSquared() > r.LengthSquared())
                    {
                        ie = j;
                    }
                }

                ++m;
                ih = ie;

                if (ie == i0)
                {
                    break;
                }
            }

            Vertices result = new Vertices(m);

            // Copy vertices.
            for (int i = 0; i < m; ++i)
            {
                result.Add(vertices[hull[i]]);
            }

            return result;
        }
    }
}