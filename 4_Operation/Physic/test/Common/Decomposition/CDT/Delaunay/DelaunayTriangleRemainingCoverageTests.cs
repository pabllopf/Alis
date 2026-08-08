using System.Collections.Generic;
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay
{
    /// <summary>
    /// The delaunay triangle remaining coverage tests class
    /// </summary>
    public class DelaunayTriangleRemainingCoverageTests
    {
        /// <summary>
        /// Tests that clear neighbor removes correct neighbor index 1
        /// </summary>
        [Fact]
        public void ClearNeighbor_RemovesCorrectNeighbor_Index1()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);
            t1.Neighbors[1] = t2;

            t1.ClearNeighbor(t2);

            Assert.Null(t1.Neighbors[1]);
        }

        /// <summary>
        /// Tests that mark neighbor with points reverse order index 0
        /// </summary>
        [Fact]
        public void MarkNeighbor_WithPoints_ReverseOrder_Index0()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);

            t1.MarkNeighbor(p3, p2, t2);

            Assert.Equal(t2, t1.Neighbors[0]);
        }

        /// <summary>
        /// Tests that mark neighbor with points reverse order index 1
        /// </summary>
        [Fact]
        public void MarkNeighbor_WithPoints_ReverseOrder_Index1()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p1, p4, p3);

            t1.MarkNeighbor(p3, p1, t2);

            Assert.Equal(t2, t1.Neighbors[1]);
        }

        /// <summary>
        /// Tests that mark neighbor with points reverse order index 2
        /// </summary>
        [Fact]
        public void MarkNeighbor_WithPoints_ReverseOrder_Index2()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p1);

            t1.MarkNeighbor(p2, p1, t2);

            Assert.Equal(t2, t1.Neighbors[2]);
        }

        /// <summary>
        /// Tests that mark neighbor with triangle sets index 0
        /// </summary>
        [Fact]
        public void MarkNeighbor_WithTriangle_SetsIndex0()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);

            t1.MarkNeighbor(t2);

            Assert.Equal(t2, t1.Neighbors[0]);
            Assert.Equal(t1, t2.Neighbors[1]);
        }

        /// <summary>
        /// Tests that mark neighbor with triangle sets index 2
        /// </summary>
        [Fact]
        public void MarkNeighbor_WithTriangle_SetsIndex2()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p1);

            t1.MarkNeighbor(t2);

            Assert.Equal(t2, t1.Neighbors[2]);
            Assert.Equal(t1, t2.Neighbors[1]);
        }

        /// <summary>
        /// Tests that mark neighbor edges propagates to neighbor index 1
        /// </summary>
        [Fact]
        public void MarkNeighborEdges_PropagatesToNeighbor_Index1()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p1, p4, p3);

            t1.Neighbors[1] = t2;
            t1.EdgeIsConstrained[1] = true;

            t1.MarkNeighborEdges();

            Assert.True(t2.EdgeIsConstrained[1]);
        }

        /// <summary>
        /// Tests that mark neighbor edges propagates to neighbor index 2
        /// </summary>
        [Fact]
        public void MarkNeighborEdges_PropagatesToNeighbor_Index2()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p1);

            t1.Neighbors[2] = t2;
            t1.EdgeIsConstrained[2] = true;

            t1.MarkNeighborEdges();

            Assert.True(t2.EdgeIsConstrained[1]);
        }

        /// <summary>
        /// Tests that mark edge with triangle marks constrained edge index 1
        /// </summary>
        [Fact]
        public void MarkEdge_WithTriangle_MarksConstrainedEdge_Index1()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p1, p4, p3);
            t1.EdgeIsConstrained[1] = true;

            t1.MarkEdge(t2);

            Assert.True(t2.EdgeIsConstrained[1]);
        }

        /// <summary>
        /// Tests that mark edge with triangle marks constrained edge index 2
        /// </summary>
        [Fact]
        public void MarkEdge_WithTriangle_MarksConstrainedEdge_Index2()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p1);
            t1.EdgeIsConstrained[2] = true;

            t1.MarkEdge(t2);

            Assert.True(t2.EdgeIsConstrained[1]);
        }

        /// <summary>
        /// Tests that mark edge with triangle list marks constrained edge index 1
        /// </summary>
        [Fact]
        public void MarkEdge_WithTriangleList_MarksConstrainedEdge_Index1()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p1, p4, p3);
            t1.EdgeIsConstrained[1] = true;
            List<DelaunayTriangle> list = new List<DelaunayTriangle> { t1 };

            t2.MarkEdge(list);

            Assert.True(t2.EdgeIsConstrained[1]);
        }

        /// <summary>
        /// Tests that mark edge with triangle list marks constrained edge index 2
        /// </summary>
        [Fact]
        public void MarkEdge_WithTriangleList_MarksConstrainedEdge_Index2()
        {
            TriangulationPoint p1 = new TriangulationPoint(0.0, 0.0);
            TriangulationPoint p2 = new TriangulationPoint(1.0, 0.0);
            TriangulationPoint p3 = new TriangulationPoint(0.0, 1.0);
            TriangulationPoint p4 = new TriangulationPoint(1.0, 1.0);

            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p1);
            t1.EdgeIsConstrained[2] = true;
            List<DelaunayTriangle> list = new List<DelaunayTriangle> { t1 };

            t2.MarkEdge(list);

            Assert.True(t2.EdgeIsConstrained[1]);
        }
    }
}
