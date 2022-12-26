// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CDTDecomposer.cs
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

using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Tools.Triangulation.Delaunay.Delaunay;
using Alis.Core.Physic.Tools.Triangulation.Delaunay.Delaunay.Sweep;

namespace Alis.Core.Physic.Tools.Triangulation.Delaunay
{
    /// <summary>
    ///     2D constrained Delaunay triangulation algorithm.
    ///     Based on the paper "Sweep-line algorithm for constrained Delaunay triangulation" by V. Domiter and and B. Zalik
    ///     Properties:
    ///     - Creates triangles with a large interior angle.
    ///     - Supports holes
    ///     - Generate a lot of garbage due to incapsulation of the Poly2Tri library.
    ///     - Running time is O(n^2), n = number of vertices.
    ///     - Does not care about winding order.
    ///     Source: http://code.google.com/p/poly2tri/
    /// </summary>
    internal static class CdtDecomposer
    {
        /// <summary>Decompose the polygon into several smaller non-concave polygon.</summary>
        public static List<Vertices> ConvexPartition(Vertices vertices)
        {
            Debug.Assert(vertices.Count > 3);

            Polygon.Polygon poly = new Polygon.Polygon();

            foreach (Vector2 vertex in vertices)
            {
                poly.Points.Add(new TriangulationPoint(vertex.X, vertex.Y));
            }

            if (vertices.Holes != null)
            {
                foreach (Vertices holeVertices in vertices.Holes)
                {
                    Polygon.Polygon hole = new Polygon.Polygon();

                    foreach (Vector2 vertex in holeVertices)
                    {
                        hole.Points.Add(new TriangulationPoint(vertex.X, vertex.Y));
                    }

                    poly.AddHole(hole);
                }
            }

            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(poly);
            DtSweep.Triangulate(tcx);

            List<Vertices> results = new List<Vertices>();

            foreach (DelaunayTriangle triangle in poly.Triangles)
            {
                Vertices v = new Vertices();
                foreach (TriangulationPoint p in triangle.Points)
                {
                    v.Add(new Vector2((float) p.X, (float) p.Y));
                }

                results.Add(v);
            }

            return results;
        }
    }
}