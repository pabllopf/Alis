// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GiftWrap.cs
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

using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Shared;

namespace Alis.Extension.Math.PathGenerator.ConvexHull
{
    /// <summary>
    ///     The gift wrap class
    /// </summary>
    public static class GiftWrap
    {
        /// <summary>
        ///     Gets the convex hull using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <returns>The vertices</returns>
        public static Vertices GetConvexHull(Vertices vertices)
        {
            if (vertices.Count <= 3)
            {
                return vertices;
            }

            int i0 = FindRightmostPoint(vertices);
            int[] hull = new int[vertices.Count];
            int m = CalculateConvexHull(vertices, i0, hull);

            return CreateResultVertices(vertices, hull, m);
        }

        /// <summary>
        ///     Finds the rightmost point using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <returns>The </returns>
        private static int FindRightmostPoint(Vertices vertices)
        {
            int i0 = 0;
            float x0 = vertices[0].X;
            for (int i = 1; i < vertices.Count; ++i)
            {
                float x = vertices[i].X;
                if (x > x0 || ((x == x0) && (vertices[i].Y < vertices[i0].Y)))
                {
                    i0 = i;
                    x0 = x;
                }
            }

            return i0;
        }

        /// <summary>
        ///     Calculates the convex hull using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="i0">The </param>
        /// <param name="hull">The hull</param>
        /// <returns>The </returns>
        private static int CalculateConvexHull(Vertices vertices, int i0, int[] hull)
        {
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

                    if ((c == 0.0f) && (v.LengthSquared() > r.LengthSquared()))
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

            return m;
        }

        /// <summary>
        ///     Creates the result vertices using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="hull">The hull</param>
        /// <param name="m">The </param>
        /// <returns>The result</returns>
        private static Vertices CreateResultVertices(Vertices vertices, int[] hull, int m)
        {
            Vertices result = new Vertices(m);

            for (int i = 0; i < m; ++i)
            {
                result.Add(vertices[hull[i]]);
            }

            return result;
        }
    }
}