using System;
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay
{
    public class DelaunayTriangleCoverageTest
    {
        [Fact]
        public void EdgeIndex_ReturnsMinusOne_ForNonAdjacentPoints()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(5.0, 5.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            int index = triangle.EdgeIndex(p4, p1);
            Assert.Equal(-1, index);
        }

        [Fact]
        public void EdgeIndex_ReturnsCorrectIndex()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.Equal(0, triangle.EdgeIndex(p2, p3));
            Assert.Equal(1, triangle.EdgeIndex(p1, p3));
            Assert.Equal(2, triangle.EdgeIndex(p1, p2));
        }

        [Fact]
        public void MarkConstrainedEdge_WithNonExistentEdge_DoesNotThrow()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(5.0, 5.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            triangle.MarkConstrainedEdge(p4, p1);
            Assert.False(triangle.EdgeIsConstrained[0]);
        }

        [Fact]
        public void MarkConstrainedEdge_WithValidEdge_SetsFlag()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            triangle.MarkConstrainedEdge(p2, p3);
            Assert.True(triangle.EdgeIsConstrained[0]);
        }

        [Fact]
        public void Area_ReturnsPositive_ForCounterClockwiseTriangle()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(2.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 2.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            double area = triangle.Area();
            Assert.True(area > 0.0);
        }

        [Fact]
        public void Centroid_ReturnsCenterPoint()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(2.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 2.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            TriangulationPoint centroid = triangle.Centroid();

            Assert.True(centroid.X > 0.0);
            Assert.True(centroid.Y > 0.0);
        }

        [Fact]
        public void Legalize_RotatesAndReplacesPoint()
        {
            TriangulationPoint oPoint = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint nPoint = new TriangulationPoint(2.0, 2.0);

            DelaunayTriangle triangle = new DelaunayTriangle(oPoint, p2, p3);
            triangle.Legalize(oPoint, nPoint);

            Assert.True(triangle.Contains(nPoint));
        }

        [Fact]
        public void MarkNeighborEdges_PropagatesToNeighbor()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);

            t1.Neighbors[0] = t2;
            t1.EdgeIsConstrained[0] = true;

            t1.MarkNeighborEdges();

            Assert.True(t2.EdgeIsConstrained[1]);
        }

        [Fact]
        public void ClearNeighbor_RemovesCorrectNeighbor()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);

            t1.Neighbors[0] = t2;
            t1.Neighbors[1] = t2;

            t1.ClearNeighbor(t2);
            Assert.Null(t1.Neighbors[0]);
            Assert.Null(t1.Neighbors[1]);
        }

        [Fact]
        public void Clear_DisconnectsAllNeighbors()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            t1.Clear();

            Assert.Null(t1.Neighbors[0]);
            Assert.Null(t1.Neighbors[1]);
            Assert.Null(t1.Neighbors[2]);
        }

        [Fact]
        public void IsInterior_SetAndGet()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            triangle.IsInterior = true;
            Assert.True(triangle.IsInterior);
        }

        [Fact]
        public void ConstrainedEdgeFlags_SetAndGet()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            triangle.SetConstrainedEdgeCcw(p1, true);
            Assert.True(triangle.GetConstrainedEdgeCcw(p1));

            triangle.SetConstrainedEdgeCw(p1, true);
            Assert.True(triangle.GetConstrainedEdgeCw(p1));

            triangle.SetConstrainedEdgeAcross(p1, true);
            Assert.True(triangle.GetConstrainedEdgeAcross(p1));
        }

        [Fact]
        public void DelaunayEdgeFlags_SetAndGet()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            triangle.SetDelaunayEdgeCcw(p1, true);
            Assert.True(triangle.GetDelaunayEdgeCcw(p1));

            triangle.SetDelaunayEdgeCw(p1, true);
            Assert.True(triangle.GetDelaunayEdgeCw(p1));

            triangle.SetDelaunayEdgeAcross(p1, true);
            Assert.True(triangle.GetDelaunayEdgeAcross(p1));
        }
    }
}
