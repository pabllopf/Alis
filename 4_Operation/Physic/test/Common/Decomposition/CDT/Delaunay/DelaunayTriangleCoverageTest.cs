using System;
using System.Collections.Generic;
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay
{
    /// <summary>
    /// The delaunay triangle coverage test class
    /// </summary>
    public class DelaunayTriangleCoverageTest
    {
        /// <summary>
        /// Tests that edge index returns minus one for non adjacent points
        /// </summary>
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

        /// <summary>
        /// Tests that edge index returns correct index
        /// </summary>
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

        /// <summary>
        /// Tests that mark constrained edge with non existent edge does not throw
        /// </summary>
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

        /// <summary>
        /// Tests that mark constrained edge with valid edge sets flag
        /// </summary>
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

        /// <summary>
        /// Tests that area returns positive for counter clockwise triangle
        /// </summary>
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

        /// <summary>
        /// Tests that centroid returns center point
        /// </summary>
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

        /// <summary>
        /// Tests that legalize rotates and replaces point
        /// </summary>
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

        /// <summary>
        /// Tests that mark neighbor edges propagates to neighbor
        /// </summary>
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
        
        /// <summary>
        /// Tests that clear disconnects all neighbors
        /// </summary>
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

        /// <summary>
        /// Tests that is interior set and get
        /// </summary>
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

        /// <summary>
        /// Tests that constrained edge flags set and get
        /// </summary>
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

        /// <summary>
        /// Tests that delaunay edge flags set and get
        /// </summary>
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

        /// <summary>
        /// Tests that contains with dt sweep constraint returns true for contained edge
        /// </summary>
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

        /// <summary>
        /// Tests that contains with dt sweep constraint returns false for non contained edge
        /// </summary>
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

        /// <summary>
        /// Tests that contains with two points returns true when both contained
        /// </summary>
        [Fact]
        public void Contains_WithTwoPoints_ReturnsTrueWhenBothContained()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            Assert.True(triangle.Contains(p1, p2));
        }

        /// <summary>
        /// Tests that contains with two points returns false when one not contained
        /// </summary>
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

        /// <summary>
        /// Tests that index of with unknown point throws argument exception
        /// </summary>
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

        /// <summary>
        /// Tests that index cw returns correct index
        /// </summary>
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

        /// <summary>
        /// Tests that index ccw returns correct index
        /// </summary>
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

        /// <summary>
        /// Tests that mark neighbor with points sets neighbor at correct index
        /// </summary>
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

        /// <summary>
        /// Tests that mark neighbor with points sets neighbor at correct index edge 1
        /// </summary>
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

        /// <summary>
        /// Tests that mark neighbor with points sets neighbor at correct index edge 2
        /// </summary>
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

        /// <summary>
        /// Tests that mark neighbor with triangle sets mutual neighbor
        /// </summary>
        [Fact]
        public void MarkNeighbor_WithTriangle_SetsMutualNeighbor()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p1, p4, p3);

            t1.MarkNeighbor(t2);

            Assert.Equal(t2, t1.Neighbors[1]);
            Assert.Equal(t1, t2.Neighbors[1]);
        }

        /// <summary>
        /// Tests that clear neighbors sets all to null
        /// </summary>
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

        /// <summary>
        /// Tests that clear neighbor removes correct neighbor index 0
        /// </summary>
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

            t1.ClearNeighbor(t2);

            Assert.Null(t1.Neighbors[0]);
        }

        /// <summary>
        /// Tests that clear neighbor removes correct neighbor index 2
        /// </summary>
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

        /// <summary>
        /// Tests that opposite point returns correct point
        /// </summary>
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

        /// <summary>
        /// Tests that neighbor cw returns correct neighbor
        /// </summary>
        [Fact]
        public void NeighborCw_ReturnsCorrectNeighbor()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);
            t1.Neighbors[1] = t2;

            Assert.Equal(t2, t1.NeighborCw(p1));
        }

        /// <summary>
        /// Tests that neighbor ccw returns correct neighbor
        /// </summary>
        [Fact]
        public void NeighborCcw_ReturnsCorrectNeighbor()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);
            t1.Neighbors[2] = t2;

            Assert.Equal(t2, t1.NeighborCcw(p1));
        }

        /// <summary>
        /// Tests that neighbor across returns correct neighbor
        /// </summary>
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

        /// <summary>
        /// Tests that point ccw returns correct point
        /// </summary>
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

        /// <summary>
        /// Tests that point cw returns correct point
        /// </summary>
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

        /// <summary>
        /// Tests that to string returns formatted string
        /// </summary>
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

        /// <summary>
        /// Tests that mark edge with triangle marks constrained edges
        /// </summary>
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

        /// <summary>
        /// Tests that mark edge with triangle list marks constrained edges
        /// </summary>
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

        /// <summary>
        /// Tests that mark constrained edge with index sets flag
        /// </summary>
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

        /// <summary>
        /// Tests that mark constrained edge with dt sweep constraint sets flag
        /// </summary>
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

        /// <summary>
        /// Tests that area with degenerate triangle returns zero
        /// </summary>
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

        /// <summary>
        /// Tests that mark neighbor edges with no neighbor does not throw
        /// </summary>
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

        /// <summary>
        /// Tests that clear with neighbors disconnects mutually
        /// </summary>
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

        /// <summary>
        /// Tests that mark neighbor with non existent edge logs error
        /// </summary>
        [Fact]
        public void MarkNeighbor_WithNonExistentEdge_LogsError()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(5.0, 5.0);
            TriangulationPoint p5 = new TriangulationPoint(6.0, 6.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p4, p5, new TriangulationPoint(7.0, 7.0));

            t1.MarkNeighbor(p4, p5, t2);
        }

        /// <summary>
        /// Tests that mark neighbor with no shared edge logs error
        /// </summary>
        [Fact]
        public void MarkNeighbor_WithNoSharedEdge_LogsError()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(5.0, 0.0);
            TriangulationPoint p5 = new TriangulationPoint(6.0, 0.0);
            TriangulationPoint p6 = new TriangulationPoint(5.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p4, p5, p6);

            t1.MarkNeighbor(t2);
        }

        /// <summary>
        /// Tests that rotate cw rotates points clockwise
        /// </summary>
        [Fact]
        public void RotateCw_RotatesPointsClockwise()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);

            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);
            triangle.RotateCw();

            Assert.Equal(p3, triangle.Points[0]);
            Assert.Equal(p1, triangle.Points[1]);
            Assert.Equal(p2, triangle.Points[2]);
        }
    }
}
