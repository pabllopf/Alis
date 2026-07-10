using System;
using System.Collections.Generic;
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
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

        [Fact]
        public void Contains_WithDtSweepConstraint_ReturnsTrueForContainedEdge()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            DtSweepConstraint edge = new DtSweepConstraint(p1, p2);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.True(triangle.Contains(edge));
        }

        [Fact]
        public void Contains_WithDtSweepConstraint_ReturnsFalseForNonContainedEdge()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(5.0, 5.0);
            DtSweepConstraint edge = new DtSweepConstraint(p1, p4);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.False(triangle.Contains(edge));
        }

        [Fact]
        public void Contains_WithTwoPoints_ReturnsTrueWhenBothContained()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.True(triangle.Contains(p1, p2));
        }

        [Fact]
        public void Contains_WithTwoPoints_ReturnsFalseWhenOneNotContained()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(5.0, 5.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.False(triangle.Contains(p1, p4));
        }

        [Fact]
        public void IndexOf_WithUnknownPoint_ThrowsArgumentException()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(5.0, 5.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.Throws<ArgumentException>(() => triangle.IndexOf(p4));
        }

        [Fact]
        public void IndexCw_ReturnsCorrectIndex()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.Equal(2, triangle.IndexCw(p1));
            Assert.Equal(0, triangle.IndexCw(p2));
            Assert.Equal(1, triangle.IndexCw(p3));
        }

        [Fact]
        public void IndexCcw_ReturnsCorrectIndex()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.Equal(1, triangle.IndexCcw(p1));
            Assert.Equal(2, triangle.IndexCcw(p2));
            Assert.Equal(0, triangle.IndexCcw(p3));
        }

        [Fact]
        public void MarkNeighbor_WithPoints_SetsNeighborAtCorrectIndex()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);

            t1.MarkNeighbor(p2, p3, t2);

            Assert.Equal(t2, t1.Neighbors[0]);
        }

        [Fact]
        public void MarkNeighbor_WithPoints_SetsNeighborAtCorrectIndex_Edge1()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p1, p4, p3);

            t1.MarkNeighbor(p1, p3, t2);

            Assert.Equal(t2, t1.Neighbors[1]);
        }

        [Fact]
        public void MarkNeighbor_WithPoints_SetsNeighborAtCorrectIndex_Edge2()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p1);

            t1.MarkNeighbor(p1, p2, t2);

            Assert.Equal(t2, t1.Neighbors[2]);
        }

        [Fact]
        public void MarkNeighbor_WithTriangle_SetsMutualNeighbor()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);

            t1.MarkNeighbor(t2);

            Assert.Equal(t2, t1.Neighbors[0]);
            Assert.Equal(t1, t2.Neighbors[0]);
        }

        [Fact]
        public void ClearNeighbors_SetsAllToNull()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);
            t1.MarkNeighbor(p2, p3, t2);

            t1.ClearNeighbors();

            Assert.Null(t1.Neighbors[0]);
            Assert.Null(t1.Neighbors[1]);
            Assert.Null(t1.Neighbors[2]);
        }

        [Fact]
        public void ClearNeighbor_RemovesCorrectNeighbor_Index0()
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
        public void ClearNeighbor_RemovesCorrectNeighbor_Index2()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);
            t1.Neighbors[2] = t2;

            t1.ClearNeighbor(t2);

            Assert.Null(t1.Neighbors[2]);
        }

        [Fact]
        public void OppositePoint_ReturnsCorrectPoint()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);

            TriangulationPoint opposite = t1.OppositePoint(t2, p2);

            Assert.NotNull(opposite);
        }

        [Fact]
        public void NeighborCw_ReturnsCorrectNeighbor()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);
            t1.Neighbors[0] = t2;

            Assert.Equal(t2, t1.NeighborCw(p1));
        }

        [Fact]
        public void NeighborCcw_ReturnsCorrectNeighbor()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);
            t1.Neighbors[1] = t2;

            Assert.Equal(t2, t1.NeighborCcw(p1));
        }

        [Fact]
        public void NeighborAcross_ReturnsCorrectNeighbor()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);
            t1.Neighbors[0] = t2;

            Assert.Equal(t2, t1.NeighborAcross(p1));
        }

        [Fact]
        public void PointCcw_ReturnsCorrectPoint()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.Equal(p2, triangle.PointCcw(p1));
            Assert.Equal(p3, triangle.PointCcw(p2));
            Assert.Equal(p1, triangle.PointCcw(p3));
        }

        [Fact]
        public void PointCw_ReturnsCorrectPoint()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.Equal(p3, triangle.PointCw(p1));
            Assert.Equal(p1, triangle.PointCw(p2));
            Assert.Equal(p2, triangle.PointCw(p3));
        }

        [Fact]
        public void ToString_ReturnsFormattedString()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            string result = triangle.ToString();

            Assert.Contains("0", result);
            Assert.Contains("1", result);
        }

        [Fact]
        public void MarkEdge_WithTriangle_MarksConstrainedEdges()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);
            t1.EdgeIsConstrained[0] = true;

            t1.MarkEdge(t2);

            Assert.True(t2.EdgeIsConstrained[1]);
        }

        [Fact]
        public void MarkEdge_WithTriangleList_MarksConstrainedEdges()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);
            t1.EdgeIsConstrained[0] = true;
            List<DelaunayTriangle> list = new List<DelaunayTriangle> { t1 };

            t2.MarkEdge(list);

            Assert.True(t2.EdgeIsConstrained[1]);
        }

        [Fact]
        public void MarkConstrainedEdge_WithIndex_SetsFlag()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            triangle.MarkConstrainedEdge(1);

            Assert.True(triangle.EdgeIsConstrained[1]);
        }

        [Fact]
        public void MarkConstrainedEdge_WithDtSweepConstraint_SetsFlag()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            DtSweepConstraint edge = new DtSweepConstraint(p2, p3);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            triangle.MarkConstrainedEdge(edge);

            Assert.True(triangle.EdgeIsConstrained[0]);
        }

        [Fact]
        public void Area_WithDegenerateTriangle_ReturnsZero()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(2.0, 0.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            double area = triangle.Area();

            Assert.Equal(0.0, area);
        }

        [Fact]
        public void MarkNeighborEdges_WithNoNeighbor_DoesNotThrow()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            triangle.EdgeIsConstrained[0] = true;

            triangle.MarkNeighborEdges();
        }

        [Fact]
        public void ClearWithNeighbors_DisconnectsMutually()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);
            t1.MarkNeighbor(p2, p3, t2);
            t1.Clear();

            Assert.Null(t1.Neighbors[0]);
            Assert.Null(t1.Neighbors[1]);
            Assert.Null(t1.Neighbors[2]);
            Assert.Null(t2.Neighbors[0]);
        }
    }
}
