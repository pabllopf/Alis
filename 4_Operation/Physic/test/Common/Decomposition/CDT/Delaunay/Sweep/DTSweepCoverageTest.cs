using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Decomposition;
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Alis.Core.Physic.Common.Decomposition.CDT.Sets;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    public class DTSweepCoverageTest
    {
        [Fact]
        public void Triangulate_StarShape_ProducesTriangles()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0.0f, 0.0f),
                new Vector2F(2.0f, 0.0f),
                new Vector2F(2.0f, 2.0f),
                new Vector2F(0.0f, 2.0f),
                new Vector2F(1.0f, 3.0f)
            };

            List<Vertices> triangles = CdtDecomposer.ConvexPartition(vertices);

            Assert.NotNull(triangles);
            Assert.True(triangles.Count >= 3);
        }

        [Fact]
        public void Triangulate_ComplexConcave_WithHole()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0.0f, 0.0f),
                new Vector2F(4.0f, 0.0f),
                new Vector2F(4.0f, 4.0f),
                new Vector2F(3.0f, 4.0f),
                new Vector2F(3.0f, 1.0f),
                new Vector2F(1.0f, 1.0f),
                new Vector2F(1.0f, 4.0f),
                new Vector2F(0.0f, 4.0f)
            };

            List<Vertices> triangles = CdtDecomposer.ConvexPartition(vertices);

            Assert.NotNull(triangles);
            Assert.True(triangles.Count >= 4);
        }

        [Fact]
        public void Triangulate_WithManyConstrainedEdges()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(4.0, 3.0),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(2.0, 3.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(0.0, 3.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[2],
                points[1], points[3],
                points[2], points[4],
                points[3], points[5],
                points[4], points[6]
            };

            ConstrainedPointSet constrainedPS = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(constrainedPS);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(constrainedPS.GetTriangles);
            Assert.True(constrainedPS.GetTriangles.Count >= 5);
        }

        [Fact]
        public void Triangulate_WithColinearPoints_DoesNotThrow()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(0.0, 1.0)
            };

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(pointSet.GetTriangles);
        }

        [Fact]
        public void Triangulate_NonConvexPointSet_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(3.0, 2.0),
                new TriangulationPoint(2.0, 0.5),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(0.0, 1.0)
            };

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(pointSet.GetTriangles);
            Assert.True(pointSet.GetTriangles.Count >= 4);
        }
    }
}
