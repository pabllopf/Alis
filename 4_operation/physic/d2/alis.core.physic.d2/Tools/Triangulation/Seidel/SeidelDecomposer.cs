// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SeidelDecomposer.cs
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

using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using Alis.Core.Physic.D2.Shared;

namespace Alis.Core.Physic.D2.Tools.Triangulation.Seidel
{
    /// <summary>
    ///     Convex decomposition algorithm created by Raimund Seidel
    ///     Properties:
    ///     - Decompose the polygon into trapezoids, then triangulate.
    ///     - To use the trapezoid data, use ConvexPartitionTrapezoid()
    ///     - Generate a lot of garbage due to incapsulation of the Poly2Tri library.
    ///     - Running time is O(n log n), n = number of vertices.
    ///     - Running time is almost linear for most simple polygons.
    ///     - Does not care about winding order.
    ///     For more information, see Raimund Seidel's paper "A simple and fast incremental randomized
    ///     algorithm for computing trapezoidal decompositions and for triangulating polygons"
    ///     See also: "Computational Geometry", 3rd edition, by Mark de Berg et al, Chapter 6.2
    ///     "Computational Geometry in C", 2nd edition, by Joseph O'Rourke
    ///     Original code from the Poly2Tri project by Mason Green.
    ///     http://code.google.com/p/poly2tri/source/browse?repo=archive#hg/scala/src/org/poly2tri/seidel
    ///     This implementation is from Dec 14, 2010
    /// </summary>
    internal static class SeidelDecomposer
    {
        /// <summary>Decompose the polygon into several smaller non-concave polygons.</summary>
        /// <param name="vertices">The polygon to decompose.</param>
        /// <param name="sheer">The sheer to use if you get bad results, try using a higher value.</param>
        /// <returns>A list of triangles</returns>
        public static List<Vertices> ConvexPartition(Vertices vertices, float sheer = 0.001f)
        {
            Debug.Assert(vertices.Count > 3);

            List<Point> compatList = new List<Point>(vertices.Count);

            foreach (Vector2 vertex in vertices)
            {
                compatList.Add(new Point(vertex.X, vertex.Y));
            }

            Triangulator t = new Triangulator(compatList, sheer);

            List<Vertices> list = new List<Vertices>();

            foreach (List<Point> triangle in t.Triangles)
            {
                Vertices outTriangles = new Vertices(triangle.Count);

                foreach (Point outTriangle in triangle)
                {
                    outTriangles.Add(new Vector2(outTriangle.X, outTriangle.Y));
                }

                list.Add(outTriangles);
            }

            return list;
        }

        /// <summary>Decompose the polygon into several smaller non-concave polygons.</summary>
        /// <param name="vertices">The polygon to decompose.</param>
        /// <param name="sheer">The sheer to use if you get bad results, try using a higher value.</param>
        /// <returns>A list of trapezoids</returns>
        public static List<Vertices> ConvexPartitionTrapezoid(Vertices vertices, float sheer = 0.001f)
        {
            List<Point> compatList = new List<Point>(vertices.Count);

            foreach (Vector2 vertex in vertices)
            {
                compatList.Add(new Point(vertex.X, vertex.Y));
            }

            Triangulator t = new Triangulator(compatList, sheer);

            List<Vertices> list = new List<Vertices>();

            foreach (Trapezoid trapezoid in t.Trapezoids)
            {
                Vertices verts = new Vertices();

                List<Point> points = trapezoid.GetVertices();
                foreach (Point point in points)
                {
                    verts.Add(new Vector2(point.X, point.Y));
                }

                list.Add(verts);
            }

            return list;
        }
    }
}