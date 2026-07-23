// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FlipcodeDecomposer.cs
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

using System;
using System.Buffers;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.Decomposition
{
    /// <summary>
    ///     Convex decomposition algorithm created by unknown
    ///     Properties:
    ///     - No support for holes
    ///     - Very fast
    ///     - Only works on simple polygons
    ///     - Only works on counter clockwise polygons
    ///     More information: http://www.flipcode.com/archives/Efficient_Polygon_Triangulation.shtml
    /// </summary>
    internal static class FlipcodeDecomposer
    {
        /// <summary>
        ///     Decompose the polygon into triangles.
        ///     Properties:
        ///     - Only works on counter clockwise polygons
        /// </summary>
        /// <param name="vertices">The list of points describing the polygon</param>
        public static List<Vertices> ConvexPartition(Vertices vertices)
        {
            int count = vertices.Count;
            int[] polygon = count <= 256
                ? System.Buffers.ArrayPool<int>.Shared.Rent(count)
                : new int[count];

            try
            {
                for (int v = 0; v < count; v++)
                {
                    polygon[v] = v;
                }

                int nv = count;

                // Remove nv-2 Vertices, creating 1 triangle every time
                int errorCount = 2 * nv;

                List<Vertices> result = new List<Vertices>();
                Vector2F tmpA = default, tmpB = default, tmpC = default;

                for (int v = nv - 1; nv > 2;)
                {
                    if (0 >= errorCount--)
                    {
                        return new List<Vertices>();
                    }

                    int u = v % nv;
                    v = (u + 1) % nv;
                    int w = (v + 1) % nv;

                    tmpA = vertices[polygon[u]];
                    tmpB = vertices[polygon[v]];
                    tmpC = vertices[polygon[w]];

                    if (Snip(vertices, u, v, w, nv, polygon.AsSpan(0, count), ref tmpA, ref tmpB, ref tmpC))
                    {
                        Vertices triangle = new Vertices(3);
                        triangle.Add(tmpA);
                        triangle.Add(tmpB);
                        triangle.Add(tmpC);
                        result.Add(triangle);

                        for (int s = v, t = v + 1; t < nv; s++, t++)
                        {
                            polygon[s] = polygon[t];
                        }

                        nv--;
                        errorCount = 2 * nv;
                    }
                }

                return result;
            }
            finally
            {
                if (count <= 256)
                {
                    System.Buffers.ArrayPool<int>.Shared.Return(polygon);
                }
            }
        }

        /// <summary>
        ///     Check if the point P is inside the triangle defined by
        ///     the points A, B, C
        /// </summary>
        internal static bool InsideTriangle(ref Vector2F a, ref Vector2F b, ref Vector2F c, ref Vector2F p)
        {
            float abp = (c.X - b.X) * (p.Y - b.Y) - (c.Y - b.Y) * (p.X - b.X);
            float aap = (b.X - a.X) * (p.Y - a.Y) - (b.Y - a.Y) * (p.X - a.X);
            float bcp = (a.X - c.X) * (p.Y - c.Y) - (a.Y - c.Y) * (p.X - c.X);

            return (abp >= 0.0f) && (bcp >= 0.0f) && (aap >= 0.0f);
        }

        /// <summary>
        ///     Cut a the contour and add a triangle into V to describe the
        ///     location of the cut
        /// </summary>
        internal static bool Snip(Vertices contour, int u, int v, int w, int n, ReadOnlySpan<int> vertices, ref Vector2F a, ref Vector2F b, ref Vector2F c)
        {
            if (SettingEnv.Epsilon > MathUtils.Area(ref a, ref b, ref c))
            {
                return false;
            }

            for (int p = 0; p < n; p++)
            {
                if (p == u || p == v || p == w)
                {
                    continue;
                }

                Vector2F point = contour[vertices[p]];

                if (InsideTriangle(ref a, ref b, ref c, ref point))
                {
                    return false;
                }
            }

            return true;
        }
    }
}