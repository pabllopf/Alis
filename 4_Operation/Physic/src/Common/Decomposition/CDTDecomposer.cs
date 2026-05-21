

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Alis.Core.Physic.Common.Decomposition.CDT.Polygon;

namespace Alis.Core.Physic.Common.Decomposition
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
        /// <summary>
        ///     Decompose the polygon into several smaller non-concave polygon.
        /// </summary>
        public static List<Vertices> ConvexPartition(Vertices vertices)
        {
            Polygon poly = new Polygon();

            foreach (Vector2F vertex in vertices)
            {
                poly.GetPoints.Add(new TriangulationPoint(vertex.X, vertex.Y));
            }

            if (vertices.Holes != null)
            {
                foreach (Vertices holeVertices in vertices.Holes)
                {
                    Polygon hole = new Polygon();

                    foreach (Vector2F vertex in holeVertices)
                    {
                        hole.GetPoints.Add(new TriangulationPoint(vertex.X, vertex.Y));
                    }

                    poly.AddHole(hole);
                }
            }

            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(poly);
            DtSweep.Triangulate(tcx);

            List<Vertices> results = new List<Vertices>();

            foreach (DelaunayTriangle triangle in poly.GetTriangles)
            {
                Vertices v = new Vertices();
                foreach (TriangulationPoint p in triangle.Points)
                {
                    v.Add(new Vector2F((float) p.X, (float) p.Y));
                }

                results.Add(v);
            }

            return results;
        }
    }
}