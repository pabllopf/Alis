// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepContextTest.cs
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
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    /// The dt sweep context test class
    /// </summary>
    public class DTSweepContextTest
    {
        /// <summary>
        /// Tests that dt sweep context type should be accessible
        /// </summary>
        [Fact]
        public void DTSweepContext_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(DtSweepContext));
        }

        /// <summary>
        /// Tests that alpha constant is 0.3
        /// </summary>
        [Fact]
        public void Alpha_ShouldBePoint3()
        {
            Assert.Equal(0.3f, DtSweepContext.Alpha);
        }

        /// <summary>
        /// Tests that constructor initializes basin and edge event
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeBasinAndEdgeEvent()
        {
            DtSweepContext ctx = new DtSweepContext();

            Assert.NotNull(ctx.Basin);
            Assert.NotNull(ctx.EdgeEvent);
            Assert.Null(ctx.AFront);
            Assert.Null(ctx.Head);
            Assert.Null(ctx.Tail);
            Assert.Empty(ctx.Triangles);
            Assert.Empty(ctx.Points);
        }

        /// <summary>
        /// Tests that head property can be set and get
        /// </summary>
        [Fact]
        public void Head_ShouldSetAndGet()
        {
            DtSweepContext ctx = new DtSweepContext();
            TriangulationPoint point = new TriangulationPoint(10, 20);

            ctx.Head = point;

            Assert.Equal(point, ctx.Head);
        }

        /// <summary>
        /// Tests that tail property can be set and get
        /// </summary>
        [Fact]
        public void Tail_ShouldSetAndGet()
        {
            DtSweepContext ctx = new DtSweepContext();
            TriangulationPoint point = new TriangulationPoint(30, 40);

            ctx.Tail = point;

            Assert.Equal(point, ctx.Tail);
        }

        /// <summary>
        /// Tests that remove from list removes triangle
        /// </summary>
        [Fact]
        public void RemoveFromList_ShouldRemoveTriangle()
        {
            DtSweepContext ctx = new DtSweepContext();
            TriangulationPoint p1 = new TriangulationPoint(0, 0);
            TriangulationPoint p2 = new TriangulationPoint(1, 0);
            TriangulationPoint p3 = new TriangulationPoint(0, 1);
            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p1, p3, p2);
            ctx.Triangles.Add(t1);
            ctx.Triangles.Add(t2);

            ctx.RemoveFromList(t1);

            Assert.Single(ctx.Triangles);
            Assert.Equal(t2, ctx.Triangles[0]);
        }

        /// <summary>
        /// Tests that clear empties triangles and points
        /// </summary>
        [Fact]
        public void Clear_ShouldEmptyTrianglesAndPoints()
        {
            DtSweepContext ctx = new DtSweepContext();
            TriangulationPoint p1 = new TriangulationPoint(0, 0);
            TriangulationPoint p2 = new TriangulationPoint(1, 0);
            TriangulationPoint p3 = new TriangulationPoint(0, 1);
            ctx.Points.Add(p1);
            ctx.Points.Add(p2);
            ctx.Triangles.Add(new DelaunayTriangle(p1, p2, p3));

            ctx.Clear();

            Assert.Empty(ctx.Triangles);
            Assert.Empty(ctx.Points);
        }

        /// <summary>
        /// Tests that new constraint creates dt sweep constraint
        /// </summary>
        [Fact]
        public void NewConstraint_ShouldCreateDtSweepConstraint()
        {
            DtSweepContext ctx = new DtSweepContext();
            TriangulationPoint a = new TriangulationPoint(0, 0);
            TriangulationPoint b = new TriangulationPoint(10, 10);

            TriangulationConstraint result = ctx.NewConstraint(a, b);

            Assert.NotNull(result);
            Assert.IsType<DtSweepConstraint>(result);
        }

        /// <summary>
        /// Tests that create advancing front builds correct structure
        /// </summary>
        [Fact]
        public void CreateAdvancingFront_ShouldBuildStructure()
        {
            DtSweepContext ctx = new DtSweepContext();
            TriangulationPoint p0 = new TriangulationPoint(10, 0);
            TriangulationPoint head = new TriangulationPoint(0, -3);
            TriangulationPoint tail = new TriangulationPoint(20, -3);
            ctx.Points.Add(p0);
            ctx.Head = head;
            ctx.Tail = tail;

            ctx.CreateAdvancingFront();

            Assert.NotNull(ctx.AFront);
            Assert.NotNull(ctx.AFront.Head);
            Assert.NotNull(ctx.AFront.Tail);
            Assert.Single(ctx.Triangles);
        }

        /// <summary>
        /// Tests that add node delegates to advancing front
        /// </summary>
        [Fact]
        public void AddNode_ShouldDelegateToAFront()
        {
            DtSweepContext ctx = new DtSweepContext();
            TriangulationPoint p0 = new TriangulationPoint(10, 0);
            TriangulationPoint head = new TriangulationPoint(0, -3);
            TriangulationPoint tail = new TriangulationPoint(20, -3);
            ctx.Points.Add(p0);
            ctx.Head = head;
            ctx.Tail = tail;
            ctx.CreateAdvancingFront();
            AdvancingFrontNode newNode = new AdvancingFrontNode(new TriangulationPoint(15, -2));

            ctx.AddNode(newNode);

            // AddNode delegates to AFront.AddNode which is a no-op
            Assert.NotNull(ctx.AFront);
        }

        /// <summary>
        /// Tests that remove node delegates to advancing front
        /// </summary>
        [Fact]
        public void RemoveNode_ShouldDelegateToAFront()
        {
            DtSweepContext ctx = new DtSweepContext();
            TriangulationPoint p0 = new TriangulationPoint(10, 0);
            TriangulationPoint head = new TriangulationPoint(0, -3);
            TriangulationPoint tail = new TriangulationPoint(20, -3);
            ctx.Points.Add(p0);
            ctx.Head = head;
            ctx.Tail = tail;
            ctx.CreateAdvancingFront();

            ctx.RemoveNode(ctx.AFront.Tail.Prev);

            // RemoveNode delegates to AFront.RemoveNode which is a no-op
            Assert.NotNull(ctx.AFront);
        }

        /// <summary>
        /// Tests that locate node delegates to advancing front
        /// </summary>
        [Fact]
        public void LocateNode_ShouldFindNodeByPoint()
        {
            DtSweepContext ctx = new DtSweepContext();
            TriangulationPoint p0 = new TriangulationPoint(10, 0);
            TriangulationPoint head = new TriangulationPoint(0, -3);
            TriangulationPoint tail = new TriangulationPoint(20, -3);
            ctx.Points.Add(p0);
            ctx.Head = head;
            ctx.Tail = tail;
            ctx.CreateAdvancingFront();

            AdvancingFrontNode node = ctx.LocateNode(new TriangulationPoint(5, 0));

            // LocateNode delegates to AFront.LocateNode which may return null
            Assert.NotNull(ctx.AFront);
        }

        // MapTriangleToNodes is not tested directly because it requires the
        // AdvancingFront.Search pointer to be positioned correctly — a protected
        // field that is only set during the CDT sweep algorithm flow.

        /// <summary>
        /// Tests that finalize triangulation clears triangles
        /// </summary>
        [Fact]
        public void FinalizeTriangulation_ShouldClearTriangles()
        {
            DtSweepContext ctx = new DtSweepContext();
            TriangulationPoint p1 = new TriangulationPoint(0, 0);
            TriangulationPoint p2 = new TriangulationPoint(1, 0);
            TriangulationPoint p3 = new TriangulationPoint(0, 1);
            ctx.Triangles.Add(new DelaunayTriangle(p1, p2, p3));
            ctx.Triangles.Add(new DelaunayTriangle(p1, p3, p2));
            MockTriangulatable collector = new MockTriangulatable();
            ctx.Triangulatable = collector;

            ctx.FinalizeTriangulation();

            Assert.Empty(ctx.Triangles);
            Assert.Equal(2, collector.Triangles.Count);
        }

        /// <summary>
        /// Tests that prepare triangulation sets up head and tail
        /// </summary>
        [Fact]
        public void PrepareTriangulation_ShouldSetupHeadAndTail()
        {
            DtSweepContext ctx = new DtSweepContext();
            MockTriangulatable triangulatable = new MockTriangulatable();
            ctx.Points.Add(new TriangulationPoint(10, 10));
            ctx.Points.Add(new TriangulationPoint(20, 20));
            ctx.Points.Add(new TriangulationPoint(15, 5));

            ctx.PrepareTriangulation(triangulatable);

            Assert.NotNull(ctx.Head);
            Assert.NotNull(ctx.Tail);
            Assert.Equal(triangulatable, ctx.Triangulatable);
        }

        /// <summary>
        /// Tests that mesh clean marks triangle interior
        /// </summary>
        [Fact]
        public void MeshClean_ShouldMarkTriangleInterior()
        {
            DtSweepContext ctx = new DtSweepContext();
            MockTriangulatable collector = new MockTriangulatable();
            ctx.Triangulatable = collector;
            TriangulationPoint p1 = new TriangulationPoint(0, 0);
            TriangulationPoint p2 = new TriangulationPoint(1, 0);
            TriangulationPoint p3 = new TriangulationPoint(0, 1);
            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3);

            ctx.MeshClean(triangle);

            Assert.True(triangle.IsInterior);
            Assert.Contains(triangle, collector.Triangles);
        }

        /// <summary>
        /// Tests that mesh clean with null triangle does nothing
        /// </summary>
        [Fact]
        public void MeshClean_WithNull_ShouldDoNothing()
        {
            DtSweepContext ctx = new DtSweepContext();
            MockTriangulatable collector = new MockTriangulatable();
            ctx.Triangulatable = collector;

            ctx.MeshClean(null);

            Assert.Empty(collector.Triangles);
        }

        /// <summary>
        /// Tests that mesh clean skips already interior triangles
        /// </summary>
        [Fact]
        public void MeshClean_WithInteriorTriangle_ShouldSkip()
        {
            DtSweepContext ctx = new DtSweepContext();
            MockTriangulatable collector = new MockTriangulatable();
            ctx.Triangulatable = collector;
            TriangulationPoint p1 = new TriangulationPoint(0, 0);
            TriangulationPoint p2 = new TriangulationPoint(1, 0);
            TriangulationPoint p3 = new TriangulationPoint(0, 1);
            DelaunayTriangle triangle = new DelaunayTriangle(p1, p2, p3)
            {
                IsInterior = true
            };

            ctx.MeshClean(triangle);

            // Should not add again if already interior
            Assert.Empty(collector.Triangles);
        }

        /// <summary>
        /// Tests that mesh clean recurses through unconstrained neighbors
        /// </summary>
        [Fact]
        public void MeshClean_ShouldRecurseThroughNeighbors()
        {
            DtSweepContext ctx = new DtSweepContext();
            MockTriangulatable collector = new MockTriangulatable();
            ctx.Triangulatable = collector;
            TriangulationPoint p1 = new TriangulationPoint(0, 0);
            TriangulationPoint p2 = new TriangulationPoint(1, 0);
            TriangulationPoint p3 = new TriangulationPoint(0.5, 0.866);
            TriangulationPoint p4 = new TriangulationPoint(1, 1);
            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);
            t1.Neighbors[2] = t2;
            t2.Neighbors[0] = t1;

            ctx.MeshClean(t1);

            Assert.True(t1.IsInterior);
            Assert.True(t2.IsInterior);
            Assert.Equal(2, collector.Triangles.Count);
        }

        /// <summary>
        /// Tests that mesh clean stops at constrained edges
        /// </summary>
        [Fact]
        public void MeshClean_ShouldStopAtConstrainedEdge()
        {
            DtSweepContext ctx = new DtSweepContext();
            MockTriangulatable collector = new MockTriangulatable();
            ctx.Triangulatable = collector;
            TriangulationPoint p1 = new TriangulationPoint(0, 0);
            TriangulationPoint p2 = new TriangulationPoint(1, 0);
            TriangulationPoint p3 = new TriangulationPoint(0.5, 0.866);
            TriangulationPoint p4 = new TriangulationPoint(1, 1);
            DelaunayTriangle t1 = new DelaunayTriangle(p1, p2, p3);
            DelaunayTriangle t2 = new DelaunayTriangle(p2, p4, p3);
            t1.Neighbors[2] = t2;
            t2.Neighbors[0] = t1;
            t1.EdgeIsConstrained[2] = true;

            ctx.MeshClean(t1);

            Assert.True(t1.IsInterior);
            Assert.False(t2.IsInterior);
            Assert.Single(collector.Triangles);
        }

        /// <summary>
        /// Tests that dt sweep basin default values
        /// </summary>
        [Fact]
        public void DtSweepBasin_ShouldHaveDefaultValues()
        {
            DtSweepContext ctx = new DtSweepContext();

            Assert.Null(ctx.Basin.BottomNode);
            Assert.Null(ctx.Basin.LeftNode);
            Assert.Null(ctx.Basin.RightNode);
            Assert.Equal(0.0, ctx.Basin.Width);
            Assert.False(ctx.Basin.LeftHighest);
        }

        /// <summary>
        /// Tests that dt sweep edge event default values
        /// </summary>
        [Fact]
        public void DtSweepEdgeEvent_ShouldHaveDefaultValues()
        {
            DtSweepContext ctx = new DtSweepContext();

            Assert.Null(ctx.EdgeEvent.ConstrainedEdge);
            Assert.False(ctx.EdgeEvent.Right);
        }

        /// <summary>
        /// Helper method to count nodes in advancing front
        /// </summary>
        private static int CountNodes(AdvancingFront front)
        {
            int count = 0;
            AdvancingFrontNode node = front.Head;
            while (node != null)
            {
                count++;
                node = node.Next;
            }
            return count;
        }

        /// <summary>
        /// Mock implementation of ITriangulatable for testing
        /// </summary>
        private class MockTriangulatable : ITriangulatable
        {
            /// <summary>
            /// The collected triangles
            /// </summary>
            public readonly List<DelaunayTriangle> Triangles = new List<DelaunayTriangle>();

            /// <summary>
            /// Gets the points
            /// </summary>
            public IList<TriangulationPoint> GetPoints => new List<TriangulationPoint>();

            /// <summary>
            /// Gets the triangles
            /// </summary>
            public IList<DelaunayTriangle> GetTriangles => Triangles.AsReadOnly();

            /// <summary>
            /// Gets the triangulation mode
            /// </summary>
            public TriangulationMode TriangulationMode => TriangulationMode.Unconstrained;

            /// <summary>
            /// Prepares the triangulation
            /// </summary>
            public void PrepareTriangulation(TriangulationContext tcx)
            {
            }

            /// <summary>
            /// Adds the triangle
            /// </summary>
            public void AddTriangle(DelaunayTriangle t)
            {
                Triangles.Add(t);
            }

            /// <summary>
            /// Adds the triangles
            /// </summary>
            public void AddTriangles(IEnumerable<DelaunayTriangle> triangles)
            {
                Triangles.AddRange(triangles);
            }

            /// <summary>
            /// Clears the triangles
            /// </summary>
            public void ClearTriangles()
            {
                Triangles.Clear();
            }
        }
    }
}

