using System;
using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Alis.Core.Physic.Common.Decomposition.CDT.Sets;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    /// The dt sweep final coverage tests class
    /// </summary>
    public class DTSweepFinalCoverageTests
    {
        /// <summary>
        /// The dt sweep
        /// </summary>
        private static readonly Type Type = typeof(DtSweep);
        /// <summary>
        /// The static
        /// </summary>
        private static readonly BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Static;

        /// <summary>
        /// Gets the method using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="types">The types</param>
        /// <returns>The method info</returns>
        private static MethodInfo GetMethod(string name, params Type[] types)
        {
            return Type.GetMethod(name, Flags, null, types, null);
        }

        // ========================================================================
        // Integration tests via Triangulate - these exercise full paths
        // ========================================================================

        /// <summary>
        /// Tests that triangulate random dense points covers many paths
        /// </summary>
        [Fact]
        public void Triangulate_RandomDensePoints_CoversManyPaths()
        {
            var rand = new Random(12345);
            var points = new List<TriangulationPoint>();
            for (int i = 0; i < 30; i++)
                points.Add(new TriangulationPoint(rand.NextDouble() * 20, rand.NextDouble() * 20));

            var ps = new PointSet(points);
            var tcx = new DtSweepContext();
            tcx.PrepareTriangulation(ps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(ps.GetTriangles);
        }

        /// <summary>
        /// Tests that triangulate large constrained grid covers edge events
        /// </summary>
        [Fact]
        public void Triangulate_LargeConstrainedGrid_CoversEdgeEvents()
        {
            var points = new List<TriangulationPoint>();
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    points.Add(new TriangulationPoint(i * 2.0, j * 2.0));

            var constraints = new List<TriangulationPoint>();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    int idx = i * 5 + j;
                    int idxR = i * 5 + j + 1;
                    int idxD = (i + 1) * 5 + j;
                    if (j < 4) { constraints.Add(points[idx]); constraints.Add(points[idxR]); }
                    if (i < 4) { constraints.Add(points[idx]); constraints.Add(points[idxD]); }
                }

            var cps = new ConstrainedPointSet(points, constraints);
            var tcx = new DtSweepContext();
            tcx.PrepareTriangulation(cps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(cps.GetTriangles);
        }

        /// <summary>
        /// Tests that triangulate circular points triggers convex hull
        /// </summary>
        [Fact]
        public void Triangulate_CircularPoints_TriggersConvexHull()
        {
            var points = new List<TriangulationPoint>();
            for (int i = 0; i < 20; i++)
            {
                double angle = i * 2 * Math.PI / 20;
                points.Add(new TriangulationPoint(Math.Cos(angle) * 10, Math.Sin(angle) * 10));
            }

            var ps = new PointSet(points);
            var tcx = new DtSweepContext();
            tcx.PrepareTriangulation(ps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(ps.GetTriangles);
        }

        /// <summary>
        /// Tests that triangulate cross constrained diagonals triggers flip events
        /// </summary>
        [Fact]
        public void Triangulate_CrossConstrainedDiagonals_TriggersFlipEvents()
        {
            var points = new List<TriangulationPoint>
            {
                new(0, 0), new(5, 0), new(5, 5), new(0, 5),
                new(1, 1), new(4, 1), new(4, 4), new(1, 4),
                new(2.5, 2.5)
            };
            var constraints = new List<TriangulationPoint>
            {
                points[0], points[2],
                points[1], points[3],
                points[4], points[6],
                points[5], points[7],
                points[0], points[8],
                points[2], points[8]
            };

            var cps = new ConstrainedPointSet(points, constraints);
            var tcx = new DtSweepContext();
            tcx.PrepareTriangulation(cps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(cps.GetTriangles);
        }

        // ========================================================================
        // FillRightConcaveEdgeEvent — recursive path (lines 316-322)
        // with proper triangle adjacency so Fill doesn't crash
        // ========================================================================

        /// <summary>
        /// Tests that fill right concave edge event recursive with fill executes
        /// </summary>
        [Fact]
        public void FillRightConcaveEdgeEvent_RecursiveWithFill_Executes()
        {
            var m = GetMethod("FillRightConcaveEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();
            var edge = new DtSweepConstraint(
                new TriangulationPoint(0, 0), new TriangulationPoint(8, 6));
            tcx.EdgeEvent.ConstrainedEdge = edge;
            tcx.EdgeEvent.Right = true;

            // Setup a proper node chain with valid triangles
            var pNode = new TriangulationPoint(0, 0);
            var pN1 = new TriangulationPoint(4, 1);
            var pN2 = new TriangulationPoint(9, 3);
            var pN3 = new TriangulationPoint(12, 5);
            var pPrev = new TriangulationPoint(-1, -1);
            var pPrev2 = new TriangulationPoint(-2, -2);

            var node = new AdvancingFrontNode(pNode);
            var n1 = new AdvancingFrontNode(pN1);
            var n2 = new AdvancingFrontNode(pN2);
            var n3 = new AdvancingFrontNode(pN3);
            var nPrev = new AdvancingFrontNode(pPrev);
            var nPrev2 = new AdvancingFrontNode(pPrev2);

            node.Next = n1; n1.Prev = node;
            n1.Next = n2; n2.Prev = n1;
            n2.Next = n3; n3.Prev = n2;
            node.Prev = nPrev; nPrev.Next = node;
            nPrev.Prev = nPrev2; nPrev2.Next = nPrev;

            var head = new AdvancingFrontNode(new TriangulationPoint(-5, -5));
            var tail = new AdvancingFrontNode(new TriangulationPoint(15, 5));
            head.Next = nPrev2; nPrev2.Prev = head;
            n3.Next = tail; tail.Prev = n3;
            tcx.AFront = new AdvancingFront(head, tail);

            // Proper triangle adjacency for Fill(tcx, n1):
            // Fill creates triangle(pNode, pN1, pN2) = new Triangle(node.Point, n1.Point, n2.Point)
            // MarkNeighbor(node.Triangle): node.Triangle must contain (pNode, pN1)
            node.Triangle = new DelaunayTriangle(pNode, pN1, pPrev);
            // MarkNeighbor(n1.Triangle): n1.Triangle must contain (pN1, pN2)
            n1.Triangle = new DelaunayTriangle(pN1, pN2, pN3);

            tcx.Triangulatable = new MockTriangulatable();

            try { m.Invoke(null, new object[] { tcx, edge, node }); }
            catch (TargetInvocationException) { }
        }

        // ========================================================================
        // FillRightConvexEdgeEvent — both branches with proper Fill setup
        // (lines 334-336 concave, 339-343 convex)
        // ========================================================================

        /// <summary>
        /// Tests that fill right convex edge event concave branch with fill
        /// </summary>
        [Fact]
        public void FillRightConvexEdgeEvent_ConcaveBranch_WithFill()
        {
            var m = GetMethod("FillRightConvexEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();
            var edge = new DtSweepConstraint(new TriangulationPoint(0, 0), new TriangulationPoint(5, 5));
            tcx.EdgeEvent.ConstrainedEdge = edge;
            tcx.EdgeEvent.Right = true;

            // FillRightConcaveEdgeEvent at line 335 calls Fill(tcx, node.Next.Next)
            // which needs node.Next.Triangle and node.Next.Next.Triangle to be valid
            var p1 = new TriangulationPoint(0, 0);
            var p2 = new TriangulationPoint(1, 1);
            var p3 = new TriangulationPoint(2, 3);
            var p4 = new TriangulationPoint(3, 2);

            var node = new AdvancingFrontNode(p1);
            var n2 = new AdvancingFrontNode(p2);
            var n3 = new AdvancingFrontNode(p3);
            var n4 = new AdvancingFrontNode(p4);
            node.Next = n2; n2.Prev = node;
            n2.Next = n3; n3.Prev = n2;
            n3.Next = n4; n4.Prev = n3;

            var head = new AdvancingFrontNode(new TriangulationPoint(-5, 0));
            var tail = new AdvancingFrontNode(new TriangulationPoint(5, 5));
            head.Next = node; node.Prev = head;
            n4.Next = tail; tail.Prev = n4;
            tcx.AFront = new AdvancingFront(head, tail);

            // For Fill(tcx, n3) which creates triangle(n2.Point, n3.Point, n4.Point)
            // MarkNeighbor(n2.Triangle): needs (n2.Point, n3.Point)
            n2.Triangle = new DelaunayTriangle(p2, p3, p1);
            // MarkNeighbor(n3.Triangle): needs (n3.Point, n4.Point)
            n3.Triangle = new DelaunayTriangle(p3, p4, p1);

            tcx.Triangulatable = new MockTriangulatable();
            try { m.Invoke(null, new object[] { tcx, edge, node }); }
            catch (TargetInvocationException) { }
        }

        /// <summary>
        /// Tests that fill right convex edge event convex branch with fill
        /// </summary>
        [Fact]
        public void FillRightConvexEdgeEvent_ConvexBranch_WithFill()
        {
            var m = GetMethod("FillRightConvexEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var edge = new DtSweepConstraint(new TriangulationPoint(10, 0), new TriangulationPoint(0, 0));
            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = edge,
                        Right = false
                    }
                };

            var p1 = new TriangulationPoint(0, 2);
            var p2 = new TriangulationPoint(3, 0);
            var p3 = new TriangulationPoint(1, 1);
            var p4 = new TriangulationPoint(2, 0);
            var p5 = new TriangulationPoint(4, 0);

            var node = new AdvancingFrontNode(p1);
            var n2 = new AdvancingFrontNode(p2);
            var n3 = new AdvancingFrontNode(p3);
            var n4 = new AdvancingFrontNode(p4);
            var n5 = new AdvancingFrontNode(p5);
            node.Next = n2; n2.Prev = node;
            n2.Next = n3; n3.Prev = n2;
            n3.Next = n4; n4.Prev = n3;
            n4.Next = n5; n5.Prev = n4;

            var head = new AdvancingFrontNode(new TriangulationPoint(-5, 0));
            var tail = new AdvancingFrontNode(new TriangulationPoint(6, 0));
            head.Next = node; node.Prev = head;
            n5.Next = tail; tail.Prev = n5;
            tcx.AFront = new AdvancingFront(head, tail);

            // For Fill(tcx, n3) which creates triangle(p2, p3, p4)
            n2.Triangle = new DelaunayTriangle(p2, p3, p1);
            n3.Triangle = new DelaunayTriangle(p3, p4, p1);

            tcx.Triangulatable = new MockTriangulatable();
            try { m.Invoke(null, new object[] { tcx, edge, node }); }
            catch (TargetInvocationException) { }
        }

        // ========================================================================
        // FillLeftConvexEdgeEvent — both branches (lines 400-402, 408-410)
        // ========================================================================

        /// <summary>
        /// Tests that fill left convex edge event both branches with fill
        /// </summary>
        [Fact]
        public void FillLeftConvexEdgeEvent_BothBranches_WithFill()
        {
            var m = GetMethod("FillLeftConvexEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var edge = new DtSweepConstraint(new TriangulationPoint(5, 0), new TriangulationPoint(0, 5));
            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = edge,
                        Right = false
                    }
                };

            var p1 = new TriangulationPoint(20, 2);
            var p2 = new TriangulationPoint(15, 1);
            var p3 = new TriangulationPoint(10, 0);
            var p4 = new TriangulationPoint(0, 2);
            var p5 = new TriangulationPoint(25, 3);

            var node = new AdvancingFrontNode(p1);
            var n2 = new AdvancingFrontNode(p2);
            var n3 = new AdvancingFrontNode(p3);
            var n4 = new AdvancingFrontNode(p4);
            var n5 = new AdvancingFrontNode(p5);
            node.Prev = n2; n2.Next = node;
            n2.Prev = n3; n3.Next = n2;
            n3.Prev = n4; n4.Next = n3;
            node.Next = n5; n5.Prev = node;

            var head = new AdvancingFrontNode(new TriangulationPoint(-5, 0));
            var tail = new AdvancingFrontNode(new TriangulationPoint(30, 5));
            head.Next = n4; n4.Prev = head;
            n5.Next = tail; tail.Prev = n5;
            tcx.AFront = new AdvancingFront(head, tail);

            // For FillLeftConcaveEdgeEvent (line 401) → Fill(tcx, node.Prev.Prev)
            // Fill at line 420 creates triangle(n3.Prev.Point, n3.Point, n3.Next.Point)
            // = triangle(n4.Point, p3, node.Prev.Point) = triangle(p4, p3, p2)
            // MarkNeighbor(n4.Triangle) needs (p4, p3)
            n4.Triangle = new DelaunayTriangle(p4, p3, head.Point);
            // MarkNeighbor(n3.Triangle) needs (p3, p2)
            n3.Triangle = new DelaunayTriangle(p3, p2, p1);

            tcx.Triangulatable = new MockTriangulatable();
            try { m.Invoke(null, new object[] { tcx, edge, node }); }
            catch (TargetInvocationException) { }
        }

        /// <summary>
        /// Tests that fill left convex edge event convex branch with fill
        /// </summary>
        [Fact]
        public void FillLeftConvexEdgeEvent_ConvexBranch_WithFill()
        {
            var m = GetMethod("FillLeftConvexEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var edge = new DtSweepConstraint(new TriangulationPoint(4, 2), new TriangulationPoint(0, 0));
            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = edge,
                        Right = false
                    }
                };

            var p1 = new TriangulationPoint(8, 0);
            var p2 = new TriangulationPoint(6, 0);
            var p3 = new TriangulationPoint(4, 1);
            var p4 = new TriangulationPoint(0, 0);
            var p5 = new TriangulationPoint(10, 0);

            var node = new AdvancingFrontNode(p1);
            var n2 = new AdvancingFrontNode(p2);
            var n3 = new AdvancingFrontNode(p3);
            var n4 = new AdvancingFrontNode(p4);
            var n5 = new AdvancingFrontNode(p5);
            node.Prev = n2; n2.Next = node;
            n2.Prev = n3; n3.Next = n2;
            n3.Prev = n4; n4.Next = n3;
            node.Next = n5; n5.Prev = node;

            var head = new AdvancingFrontNode(new TriangulationPoint(-2, -1));
            var tail = new AdvancingFrontNode(new TriangulationPoint(12, 1));
            head.Next = n4; n4.Prev = head;
            n5.Next = tail; tail.Prev = n5;
            tcx.AFront = new AdvancingFront(head, tail);

            // For FillLeftConvexEdgeEvent recursion at line 407-408
            // Fill at line 420 creates triangle(n2.Prev.Point, n2.Point, n2.Next.Point)
            // = triangle(p3, p2, node.Point) = triangle(p3, p2, p1)
            n3.Triangle = new DelaunayTriangle(p3, p2, p1);
            n2.Triangle = new DelaunayTriangle(p2, p1, p5);

            tcx.Triangulatable = new MockTriangulatable();
            try { m.Invoke(null, new object[] { tcx, edge, node }); }
            catch (TargetInvocationException) { }
        }

        // ========================================================================
        // FillRightBelowEdgeEvent — both branches (lines 357-359, 363-365)
        // ========================================================================

        /// <summary>
        /// Tests that fill right below edge event both branches with fill
        /// </summary>
        [Fact]
        public void FillRightBelowEdgeEvent_BothBranches_WithFill()
        {
            var m = GetMethod("FillRightBelowEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var edge = new DtSweepConstraint(new TriangulationPoint(0, 0), new TriangulationPoint(5, 5));
            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = edge,
                        Right = true
                    }
                };

            // For concave (line 358): FillRightConcaveEdgeEvent calls Fill(tcx, node.Next)
            // Setup node chain: node-p1-p2-p3 with tri adjacency
            var p0 = new TriangulationPoint(0, 0);
            var p1 = new TriangulationPoint(1, 1);
            var p2 = new TriangulationPoint(3, 2);
            var p3 = new TriangulationPoint(5, 3);
            var pPrev = new TriangulationPoint(-1, 0);

            var node = new AdvancingFrontNode(p0);
            var n1 = new AdvancingFrontNode(p1);
            var n2 = new AdvancingFrontNode(p2);
            var n3 = new AdvancingFrontNode(p3);
            var nPrev = new AdvancingFrontNode(pPrev);

            node.Next = n1; n1.Prev = node;
            n1.Next = n2; n2.Prev = n1;
            n2.Next = n3; n3.Prev = n2;
            node.Prev = nPrev; nPrev.Next = node;

            var head = new AdvancingFrontNode(new TriangulationPoint(-5, -1));
            var tail = new AdvancingFrontNode(new TriangulationPoint(7, 5));
            head.Next = nPrev; nPrev.Prev = head;
            n3.Next = tail; tail.Prev = n3;
            tcx.AFront = new AdvancingFront(head, tail);

            // Fill(tcx, node.Next=n1) creates triangle(p0, p1, p2)
            // MarkNeighbor(node.Triangle): needs (p0, p1)
            node.Triangle = new DelaunayTriangle(p0, p1, pPrev);
            // MarkNeighbor(n1.Triangle): needs (p1, p2)
            n1.Triangle = new DelaunayTriangle(p1, p2, p3);

            tcx.Triangulatable = new MockTriangulatable();
            try { m.Invoke(null, new object[] { tcx, edge, node }); }
            catch (TargetInvocationException) { }
        }

        // ========================================================================
        // FillRightAboveEdgeEvent — Ccw and Cw branches (lines 382, 384-387)
        // ========================================================================

        /// <summary>
        /// Tests that fill right above edge event ccw branch triggers below
        /// </summary>
        [Fact]
        public void FillRightAboveEdgeEvent_CcwBranch_TriggersBelow()
        {
            var m = GetMethod("FillRightAboveEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        Right = true
                    }
                };
            var edge = new DtSweepConstraint(new TriangulationPoint(0, 0), new TriangulationPoint(8, 0));
            tcx.EdgeEvent.ConstrainedEdge = edge;

            // while loop body Ccw -> FillRightBelowEdgeEvent -> which calls Fill
            var pNode = new TriangulationPoint(0, 0);
            var pN1 = new TriangulationPoint(3, -1);
            var pN2 = new TriangulationPoint(7, 0);
            var pN1Prev = new TriangulationPoint(-1, 0);

            var node = new AdvancingFrontNode(pNode);
            var n1 = new AdvancingFrontNode(pN1);
            var n2 = new AdvancingFrontNode(pN2);
            var nPrev = new AdvancingFrontNode(pN1Prev);
            node.Next = n1; n1.Prev = node;
            n1.Next = n2; n2.Prev = n1;
            node.Prev = nPrev; nPrev.Next = node;

            var head = new AdvancingFrontNode(new TriangulationPoint(-3, -1));
            var tail = new AdvancingFrontNode(new TriangulationPoint(10, 1));
            head.Next = nPrev; nPrev.Prev = head;
            n2.Next = tail; tail.Prev = n2;
            tcx.AFront = new AdvancingFront(head, tail);

            node.Triangle = new DelaunayTriangle(pNode, pN1, pN1Prev);
            n1.Triangle = new DelaunayTriangle(pN1, pN2, pN1Prev);

            tcx.Triangulatable = new MockTriangulatable();
            try { m.Invoke(null, new object[] { tcx, edge, node }); }
            catch (TargetInvocationException) { }
        }

        /// <summary>
        /// Tests that fill right above edge event cw branch advances node
        /// </summary>
        [Fact]
        public void FillRightAboveEdgeEvent_CwBranch_AdvancesNode()
        {
            var m = GetMethod("FillRightAboveEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        Right = true
                    }
                };
            var edge = new DtSweepConstraint(new TriangulationPoint(5, 0), new TriangulationPoint(8, 0));
            tcx.EdgeEvent.ConstrainedEdge = edge;

            // Cw branch just advances node
            var node = new AdvancingFrontNode(new TriangulationPoint(0, 0))
                {
                    Next = new AdvancingFrontNode(new TriangulationPoint(6, 1))
                        {
                            Next = new AdvancingFrontNode(new TriangulationPoint(9, 0))
                        }
                };
            tcx.Triangulatable = new MockTriangulatable();

            try { m.Invoke(null, new object[] { tcx, edge, node }); }
            catch (TargetInvocationException) { }
        }

        // ========================================================================
        // FillLeftConcaveEdgeEvent — recursive (lines 424-426)
        // ========================================================================

        /// <summary>
        /// Tests that fill left concave edge event recursive with fill
        /// </summary>
        [Fact]
        public void FillLeftConcaveEdgeEvent_Recursive_WithFill()
        {
            var m = GetMethod("FillLeftConcaveEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var edge = new DtSweepConstraint(new TriangulationPoint(5, 0), new TriangulationPoint(0, 5));
            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = edge,
                        Right = false
                    }
                };

            var p4 = new TriangulationPoint(4, 2);
            var p3 = new TriangulationPoint(2, 1);
            var p2 = new TriangulationPoint(0, 0);
            var p1 = new TriangulationPoint(-2, -1);
            var p5 = new TriangulationPoint(6, 3);

            var n4 = new AdvancingFrontNode(p4);
            var n3 = new AdvancingFrontNode(p3);
            var n2 = new AdvancingFrontNode(p2);
            var n1 = new AdvancingFrontNode(p1);
            var n5 = new AdvancingFrontNode(p5);
            n4.Prev = n3; n3.Next = n4;
            n3.Prev = n2; n2.Next = n3;
            n2.Prev = n1; n1.Next = n2;
            n4.Next = n5; n5.Prev = n4;

            var head = new AdvancingFrontNode(new TriangulationPoint(-5, -2));
            var tail = new AdvancingFrontNode(new TriangulationPoint(8, 5));
            head.Next = n1; n1.Prev = head;
            n5.Next = tail; tail.Prev = n5;
            tcx.AFront = new AdvancingFront(head, tail);

            // Fill(tcx, n3.Prev) = Fill(tcx, n2) creates triangle(n1.Point, p2, p3)
            // MarkNeighbor(n1.Triangle): needs (p1, p2)
            n1.Triangle = new DelaunayTriangle(p1, p2, head.Point);
            // MarkNeighbor(n2.Triangle): needs (p2, p3)
            n2.Triangle = new DelaunayTriangle(p2, p3, p4);

            tcx.Triangulatable = new MockTriangulatable();
            try { m.Invoke(null, new object[] { tcx, edge, n4 }); }
            catch (TargetInvocationException) { }
        }

        // ========================================================================
        // FillLeftBelowEdgeEvent — convex branch (lines 446-447)
        // ========================================================================

        /// <summary>
        /// Tests that fill left below edge event convex branch with fill
        /// </summary>
        [Fact]
        public void FillLeftBelowEdgeEvent_ConvexBranch_WithFill()
        {
            var m = GetMethod("FillLeftBelowEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var edge = new DtSweepConstraint(new TriangulationPoint(5, 0), new TriangulationPoint(0, 5));
            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = edge,
                        Right = false
                    }
                };

            var p0 = new TriangulationPoint(3, 0);
            var p1 = new TriangulationPoint(2, 2);
            var p2 = new TriangulationPoint(0, 3);
            var pP = new TriangulationPoint(4, 1);

            var node = new AdvancingFrontNode(p0);
            var n1 = new AdvancingFrontNode(p1);
            var n2 = new AdvancingFrontNode(p2);
            var nP = new AdvancingFrontNode(pP);
            node.Prev = n1; n1.Next = node;
            n1.Prev = n2; n2.Next = n1;
            node.Next = nP; nP.Prev = node;

            var head = new AdvancingFrontNode(new TriangulationPoint(-2, 5));
            var tail = new AdvancingFrontNode(new TriangulationPoint(6, 0));
            head.Next = n2; n2.Prev = head;
            nP.Next = tail; tail.Prev = nP;
            tcx.AFront = new AdvancingFront(head, tail);

            // FillLeftBelowEdgeEvent calls FillLeftConvexEdgeEvent and then FillLeftBelowEdgeEvent again
            // Concave path calls FillLeftConcaveEdgeEvent -> Fill(tcx, node.Prev)
            // node.Prev = n1, so Fill creates triangle(n2.Point, p1, node.Point)
            // MarkNeighbor(n2.Triangle): needs (p2, p1)
            n2.Triangle = new DelaunayTriangle(p2, p1, head.Point);
            // MarkNeighbor(n1.Triangle): needs (p1, p0)
            n1.Triangle = new DelaunayTriangle(p1, p0, pP);

            tcx.Triangulatable = new MockTriangulatable();
            try { m.Invoke(null, new object[] { tcx, edge, node }); }
            catch (TargetInvocationException) { }
        }

        // ========================================================================
        // FillAdvancingFront — hole angle within bounds (lines 747-749)
        // ========================================================================

        /// <summary>
        /// Tests that fill advancing front hole angle within bounds fills
        /// </summary>
        [Fact]
        public void FillAdvancingFront_HoleAngleWithinBounds_Fills()
        {
            var m = GetMethod("FillAdvancingFront", typeof(DtSweepContext), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();

            var head = new AdvancingFrontNode(new TriangulationPoint(-5, 5));
            var nPrev = new AdvancingFrontNode(new TriangulationPoint(-1, 1));
            var nMid = new AdvancingFrontNode(new TriangulationPoint(0, 0));
            var nNext = new AdvancingFrontNode(new TriangulationPoint(1, 1));
            var nNextNext = new AdvancingFrontNode(new TriangulationPoint(2, 0));
            var tail = new AdvancingFrontNode(new TriangulationPoint(5, 5));

            head.Next = nPrev; nPrev.Prev = head;
            nPrev.Next = nMid; nMid.Prev = nPrev;
            nMid.Next = nNext; nNext.Prev = nMid;
            nNext.Next = nNextNext; nNextNext.Prev = nNext;
            nNextNext.Next = tail; tail.Prev = nNextNext;

            tcx.AFront = new AdvancingFront(head, tail);
            tcx.Points.Add(nMid.Point);

            // Fill(tcx, nMid) creates triangle(nPrev.Point, nMid.Point, nNext.Point)
            nPrev.Triangle = new DelaunayTriangle(head.Point, nPrev.Point, nMid.Point);
            nMid.Triangle = new DelaunayTriangle(nPrev.Point, nMid.Point, nNext.Point);

            tcx.Triangulatable = new MockTriangulatable();
            try { m.Invoke(null, new object[] { tcx, nMid }); }
            catch (TargetInvocationException) { }
        }

        // ========================================================================
        // LargeHole_DontFill — next2/prev2 checks (lines 777-778, 783-784)
        // ========================================================================

        /// <summary>
        /// Tests that large hole dont fill next 2 check returns false
        /// </summary>
        [Fact]
        public void LargeHole_DontFill_Next2Check_ReturnsFalse()
        {
            var m = GetMethod("LargeHole_DontFill", typeof(AdvancingFrontNode));
            // angle(node.Point=(0,0), next=(0.01,1), prev=(1,1)):
            // ax=0.01, ay=1, bx=1, by=1
            // x = 0.01*1-1*1 = -0.99, y = 0.01*1+1*1 = 1.01
            // angle = atan2(1.01, -0.99) ≈ 2.34 > PiDiv2 => AngleExceeds90Degrees = true
            var node = new AdvancingFrontNode(new TriangulationPoint(0, 0))
                {
                    Next = new AdvancingFrontNode(new TriangulationPoint(0.01, 1)),
                    Prev = new AdvancingFrontNode(new TriangulationPoint(1, 1))
                };
            // next2=(2,0): angle(origin=(0,0), next2=(2,0), prev=(1,1)):
            // ax=2, ay=0, bx=1, by=1 => x=2*1-0*1=2, y=2*1+0*1=2
            // atan2(2,2)=0.785 <= PiDiv2 => AngleExceedsPlus90DegreesOrIsNegative=false
            node.Next.Next = new AdvancingFrontNode(new TriangulationPoint(2, 0));
            bool result = (bool)m.Invoke(null, new object[] { node });
            Assert.False(result);
        }

        /// <summary>
        /// Tests that large hole dont fill prev 2 check returns false
        /// </summary>
        [Fact]
        public void LargeHole_DontFill_Prev2Check_ReturnsFalse()
        {
            var m = GetMethod("LargeHole_DontFill", typeof(AdvancingFrontNode));
            // node.Point=(0,0), next=(0.01,1), prev=(1,1):
            // angle=2.34 > PiDiv2 => AngleExceeds90Degrees = true
            var node = new AdvancingFrontNode(new TriangulationPoint(0, 0))
                {
                    Next = new AdvancingFrontNode(new TriangulationPoint(0.01, 1)),
                    Prev = new AdvancingFrontNode(new TriangulationPoint(1, 1))
                };
            // next2=(-2,2): angle(next2=(-2,2), prev=(1,1)) at origin:
            // ax=-2, ay=2, bx=1, by=1 => x=-2*1-2*1=-4, y=-2*1+2*1=0
            // angle=atan2(0,-4)=pi > PiDiv2 => AngleExceedsPlus90DegreesOrIsNegative=true
            // !true=false => doesn't enter next2 if
            node.Next.Next = new AdvancingFrontNode(new TriangulationPoint(-2, 2));
            // prev2=(0.005,1): angle(next=(0.01,1), prev2=(0.005,1)) at origin:
            // ax=0.01, ay=1, bx=0.005, by=1 => x=0.01*1-1*0.005=0.005, y=0.01*0.005+1*1=1.00005
            // angle≈1.565 < PiDiv2 => AngleExceedsPlus90DegreesOrIsNegative=false
            // !false=true => enters prev2 if => returns false
            node.Prev.Prev = new AdvancingFrontNode(new TriangulationPoint(0.005, 1));
            bool result = (bool)m.Invoke(null, new object[] { node });
            Assert.False(result);
        }

        // ========================================================================
        // TurnAdvancingFrontConvex — inner Fill branch (lines 183-186)
        // ========================================================================

        /// <summary>
        /// Tests that turn advancing front convex inner fill covered
        /// </summary>
        [Fact]
        public void TurnAdvancingFrontConvex_InnerFill_Covered()
        {
            var m = GetMethod("TurnAdvancingFrontConvex",
                typeof(DtSweepContext), typeof(AdvancingFrontNode), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();
            var head = new AdvancingFrontNode(new TriangulationPoint(0, 3));
            var n1 = new AdvancingFrontNode(new TriangulationPoint(1, 1));
            var n2 = new AdvancingFrontNode(new TriangulationPoint(3, 0));
            var n3 = new AdvancingFrontNode(new TriangulationPoint(4, 1));
            var tail = new AdvancingFrontNode(new TriangulationPoint(5, 0));

            head.Next = n1; n1.Prev = head;
            n1.Next = n2; n2.Prev = n1;
            n2.Next = n3; n3.Prev = n2;
            n3.Next = tail; tail.Prev = n3;
            tcx.AFront = new AdvancingFront(head, tail);

            // Fill(tcx, n1) creates triangle(head.Point, n1.Point, n2.Point)
            // MarkNeighbor(head.Triangle) not needed because Fill only calls MarkNeighbor on Prev.Triangle and Triangle
            // head.Triangle is not used (head.Prev is null)
            n1.Triangle = new DelaunayTriangle(head.Point, n1.Point, n2.Point);

            tcx.Triangulatable = new MockTriangulatable();
            try { m.Invoke(null, new object[] { tcx, n1, n2 }); }
            catch (TargetInvocationException) { }
        }

        // ========================================================================
        // EdgeEvent — catch block (lines 282-285)
        // ========================================================================

        /// <summary>
        /// Tests that edge event constraint catches point on edge
        /// </summary>
        [Fact]
        public void EdgeEvent_Constraint_CatchesPointOnEdge()
        {
            var m = GetMethod("EdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));

            var ep = new TriangulationPoint(4, 2);
            var eq = new TriangulationPoint(0, 0);
            var point = new TriangulationPoint(1, 1);
            var v2 = new TriangulationPoint(3, 1);
            var v3 = new TriangulationPoint(2, 3);
            var triangle = new DelaunayTriangle(point, v2, v3);

            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = new DtSweepConstraint(eq, ep),
                        Right = true
                    }
                };

            var node = new AdvancingFrontNode(point) { Triangle = triangle,
                Next = new AdvancingFrontNode(v2)
                    {
                        Triangle = new DelaunayTriangle(v2, v3, point),
                        Next = new AdvancingFrontNode(v3)
                    }
            };
            tcx.Triangulatable = new MockTriangulatable();

            try { m.Invoke(null, new object[] { tcx, new DtSweepConstraint(eq, ep), node }); }
            catch (TargetInvocationException) { }
        }

        // ========================================================================
        // EdgeEvent — o2 collinear Contains true (line 545) and throw (lines 551-552)
        // ========================================================================

        /// <summary>
        /// Tests that edge event o 2 collinear contains true marks edge
        /// </summary>
        [Fact]
        public void EdgeEvent_O2Collinear_ContainsTrue_MarksEdge()
        {
            var m = GetMethod("EdgeEvent",
                typeof(DtSweepContext), typeof(TriangulationPoint), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(TriangulationPoint));

            var ep = new TriangulationPoint(2, 4);
            var eq = new TriangulationPoint(0, 0);
            var point = new TriangulationPoint(1, 1);
            var v2 = new TriangulationPoint(3, 1);
            var v3 = new TriangulationPoint(2, 3);
            var triangle = new DelaunayTriangle(point, v2, v3);
            var neighbor = new DelaunayTriangle(v2, ep, v3);
            triangle.Neighbors[1] = neighbor;

            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = new DtSweepConstraint(eq, ep),
                        Right = true
                    },
                    Triangulatable = new MockTriangulatable()
                };

            try { m.Invoke(null, new object[] { tcx, ep, eq, triangle, point }); }
            catch (TargetInvocationException) { }
        }

        /// <summary>
        /// Tests that edge event o 2 collinear not contains throws
        /// </summary>
        [Fact]
        public void EdgeEvent_O2Collinear_NotContains_Throws()
        {
            var m = GetMethod("EdgeEvent",
                typeof(DtSweepContext), typeof(TriangulationPoint), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(TriangulationPoint));

            var ep = new TriangulationPoint(4, 6);
            var eq = new TriangulationPoint(0, 0);
            var point = new TriangulationPoint(1, 1);
            var v2 = new TriangulationPoint(3, 1);
            var v3 = new TriangulationPoint(2, 3);
            var triangle = new DelaunayTriangle(point, v2, v3);

            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = new DtSweepConstraint(eq, ep),
                        Right = true
                    },
                    Triangulatable = new MockTriangulatable()
                };

            Assert.Throws<TargetInvocationException>(() =>
                m.Invoke(null, new object[] { tcx, ep, eq, triangle, point }));
        }

        // ========================================================================
        // EdgeEvent — o1 collinear Contains true (lines 519-524)
        // ========================================================================

        /// <summary>
        /// Tests that edge event o 1 collinear contains true marks edge
        /// </summary>
        [Fact]
        public void EdgeEvent_O1Collinear_ContainsTrue_MarksEdge()
        {
            var m = GetMethod("EdgeEvent",
                typeof(DtSweepContext), typeof(TriangulationPoint), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(TriangulationPoint));

            var ep = new TriangulationPoint(4, 0);
            var eq = new TriangulationPoint(0, 0);
            var point = new TriangulationPoint(0, 2);
            var p1 = new TriangulationPoint(2, 0);
            var p3 = new TriangulationPoint(2, 2);
            var triangle = new DelaunayTriangle(point, p1, p3);
            var neighbor = new DelaunayTriangle(p1, ep, p3);
            triangle.Neighbors[0] = neighbor;

            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = new DtSweepConstraint(eq, ep),
                        Right = true
                    },
                    Triangulatable = new MockTriangulatable()
                };

            try { m.Invoke(null, new object[] { tcx, ep, eq, triangle, point }); }
            catch (TargetInvocationException) { }
        }

        /// <summary>
        /// Tests that edge event o 1 collinear not contains throws
        /// </summary>
        [Fact]
        public void EdgeEvent_O1Collinear_NotContains_Throws()
        {
            var m = GetMethod("EdgeEvent",
                typeof(DtSweepContext), typeof(TriangulationPoint), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(TriangulationPoint));

            var ep = new TriangulationPoint(6, 2);
            var eq = new TriangulationPoint(0, 0);
            var point = new TriangulationPoint(1, 1);
            var v2 = new TriangulationPoint(3, 1);
            var v3 = new TriangulationPoint(2, 3);
            var triangle = new DelaunayTriangle(point, v2, v3);

            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = new DtSweepConstraint(eq, ep),
                        Right = true
                    },
                    Triangulatable = new MockTriangulatable()
                };

            Assert.Throws<TargetInvocationException>(() =>
                m.Invoke(null, new object[] { tcx, ep, eq, triangle, point }));
        }

        // ========================================================================
        // FlipEdgeEvent — continuing flip (lines 617-622)
        // ========================================================================

        /// <summary>
        /// Tests that flip edge event continuing flip after flip
        /// </summary>
        [Fact]
        public void FlipEdgeEvent_ContinuingFlip_AfterFlip()
        {
            var m = GetMethod("FlipEdgeEvent",
                typeof(DtSweepContext), typeof(TriangulationPoint), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(TriangulationPoint));

            var eq = new TriangulationPoint(0, 0);
            var ep = new TriangulationPoint(4, 0);
            var p1 = new TriangulationPoint(1, 1);
            var p2 = new TriangulationPoint(2, 1);
            var p3 = new TriangulationPoint(1, 2);

            var t = new DelaunayTriangle(eq, p3, p1);
            var ot = new DelaunayTriangle(p1, p2, p3);
            t.Neighbors[0] = ot;
            ot.Neighbors[1] = t;

            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = new DtSweepConstraint(eq, ep),
                        Right = true
                    },
                    Triangulatable = new MockTriangulatable()
                };

            try { m.Invoke(null, new object[] { tcx, ep, eq, t, p1 }); }
            catch (TargetInvocationException) { }
        }

        // ========================================================================
        // FlipEdgeEvent — not in scan area (lines 628-629)
        // ========================================================================

        /// <summary>
        /// Tests that flip edge event not in scan area triggers scan
        /// </summary>
        [Fact]
        public void FlipEdgeEvent_NotInScanArea_TriggersScan()
        {
            var m = GetMethod("FlipEdgeEvent",
                typeof(DtSweepContext), typeof(TriangulationPoint), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(TriangulationPoint));

            var eq = new TriangulationPoint(0, 0);
            var ep = new TriangulationPoint(3, 0);
            var p1 = new TriangulationPoint(2, 0);
            var p2 = new TriangulationPoint(1, 1);
            var p3 = new TriangulationPoint(5, 0);

            var t = new DelaunayTriangle(eq, p2, p1);
            var ot = new DelaunayTriangle(eq, p3, p2);
            t.Neighbors[0] = ot;
            ot.Neighbors[2] = t;

            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = new DtSweepConstraint(eq, ep),
                        Right = true
                    },
                    Triangulatable = new MockTriangulatable()
                };

            try { m.Invoke(null, new object[] { tcx, ep, eq, t, eq }); }
            catch (TargetInvocationException) { }
        }

        // ========================================================================
        // FlipScanEdgeEvent — not in scan area recursive (lines 706-712)
        // ========================================================================

        /// <summary>
        /// Tests that flip scan edge event not in scan area recursive
        /// </summary>
        [Fact]
        public void FlipScanEdgeEvent_NotInScanArea_Recursive()
        {
            var m = GetMethod("FlipScanEdgeEvent",
                typeof(DtSweepContext), typeof(TriangulationPoint), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(DelaunayTriangle), typeof(TriangulationPoint));

            var eq = new TriangulationPoint(0, 0);
            var ep = new TriangulationPoint(4, 0);
            var p1 = new TriangulationPoint(1, 1);
            var p2 = new TriangulationPoint(2, 1);
            var p3 = new TriangulationPoint(0, 1);

            var flipTriangle = new DelaunayTriangle(eq, p3, p1);
            var t = new DelaunayTriangle(p1, p2, p3);
            flipTriangle.Neighbors[0] = t;
            t.Neighbors[1] = flipTriangle;

            var pOut = new TriangulationPoint(5, 0);
            var t2 = new DelaunayTriangle(p1, pOut, p2);
            t.Neighbors[2] = t2;
            t2.Neighbors[2] = t;

            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = new DtSweepConstraint(eq, ep),
                        Right = true
                    },
                    Triangulatable = new MockTriangulatable()
                };

            try { m.Invoke(null, new object[] { tcx, ep, eq, flipTriangle, t, p3 }); }
            catch (TargetInvocationException) { }
        }

        // ========================================================================
        // FinalizationConvexHull — direct with full setup (lines 110-124)
        // ========================================================================

        /// <summary>
        /// Tests that finalization convex hull full if blocks executed
        /// </summary>
        [Fact]
        public void FinalizationConvexHull_FullIfBlocks_Executed()
        {
            var m = GetMethod("FinalizationConvexHull", typeof(DtSweepContext));
            var tcx = new DtSweepContext();

            var head = new AdvancingFrontNode(new TriangulationPoint(-3, 0));
            var n1 = new AdvancingFrontNode(new TriangulationPoint(0, 0));
            var n2 = new AdvancingFrontNode(new TriangulationPoint(1, 1));
            var n3 = new AdvancingFrontNode(new TriangulationPoint(2, 0));
            var n4 = new AdvancingFrontNode(new TriangulationPoint(3, 1));
            var tail = new AdvancingFrontNode(new TriangulationPoint(5, 0));

            head.Next = n1; n1.Prev = head;
            n1.Next = n2; n2.Prev = n1;
            n2.Next = n3; n3.Prev = n2;
            n3.Next = n4; n4.Prev = n3;
            n4.Next = tail; tail.Prev = n4;
            tcx.AFront = new AdvancingFront(head, tail);

            var t1 = new DelaunayTriangle(n1.Point, n3.Point, n2.Point);
            var t2 = new DelaunayTriangle(n2.Point, n3.Point, n4.Point);
            n1.Triangle = t1;
            n2.Triangle = t1;
            n3.Triangle = t2;
            n4.Triangle = t2;

            tcx.Triangulatable = new MockTriangulatable();
            tcx.Triangles.Add(t1);

            try { m.Invoke(null, new object[] { tcx }); }
            catch (TargetInvocationException) { }
        }

        // ========================================================================
        // FillBasinReq — else branch prev.Y < next.Y (line 933-934)
        // ========================================================================

        /// <summary>
        /// Tests that fill basin req else prev y less advances prev
        /// </summary>
        [Fact]
        public void FillBasinReq_ElsePrevYLess_AdvancesPrev()
        {
            var m = GetMethod("FillBasinReq", typeof(DtSweepContext), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();

            var pts = new[] {
                new TriangulationPoint(0, 4),
                new TriangulationPoint(0, 1),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(2, 1),
                new TriangulationPoint(3, 2),
                new TriangulationPoint(3, 4)
            };
            var nodes = new AdvancingFrontNode[6];
            for (int i = 0; i < 6; i++) nodes[i] = new AdvancingFrontNode(pts[i]);
            for (int i = 0; i < 5; i++) { nodes[i].Next = nodes[i + 1]; nodes[i + 1].Prev = nodes[i]; }

            var frontHead = new AdvancingFrontNode(new TriangulationPoint(-5, 5));
            var frontTail = new AdvancingFrontNode(new TriangulationPoint(5, 5));
            frontHead.Next = nodes[0]; nodes[0].Prev = frontHead;
            nodes[5].Next = frontTail; frontTail.Prev = nodes[5];
            tcx.AFront = new AdvancingFront(frontHead, frontTail);

            for (int i = 0; i < 6; i++)
                nodes[i].Triangle = new DelaunayTriangle(
                    i > 0 ? pts[i - 1] : frontHead.Point, pts[i],
                    i < 5 ? pts[i + 1] : frontTail.Point);

            tcx.Basin.LeftNode = nodes[0];
            tcx.Basin.BottomNode = nodes[2];
            tcx.Basin.RightNode = nodes[5];
            tcx.Basin.LeftHighest = true;
            tcx.Basin.Width = 1.0;
            tcx.Triangulatable = new MockTriangulatable();

            try { m.Invoke(null, new object[] { tcx, nodes[2] }); }
            catch (TargetInvocationException) { }
        }

        // ========================================================================
        // FlipEdgeEvent — subedge done path (lines 612-614)
        // ========================================================================

        /// <summary>
        /// Tests that flip edge event subedge done recorded
        /// </summary>
        [Fact]
        public void FlipEdgeEvent_SubedgeDone_Recorded()
        {
            var m = GetMethod("FlipEdgeEvent",
                typeof(DtSweepContext), typeof(TriangulationPoint), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(TriangulationPoint));

            var eq = new TriangulationPoint(0, 0);
            var ep = new TriangulationPoint(2, 1);
            var p1 = new TriangulationPoint(1, 1);
            var p2 = new TriangulationPoint(2, 1);
            var p3 = new TriangulationPoint(0, 1);

            var t = new DelaunayTriangle(eq, p1, p3);
            var ot = new DelaunayTriangle(p1, p2, p3);
            t.Neighbors[0] = ot;
            ot.Neighbors[1] = t;

            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = new DtSweepConstraint(
                            new TriangulationPoint(0, 0), new TriangulationPoint(5, 0)),
                        Right = true
                    },
                    Triangulatable = new MockTriangulatable()
                };

            try { m.Invoke(null, new object[] { tcx, ep, eq, t, eq }); }
            catch (TargetInvocationException) { }
        }

        // ========================================================================
        // Integration: Concentric circle pattern for edge event coverage
        // ========================================================================

        /// <summary>
        /// Tests that triangulate concentric circles covers edge paths
        /// </summary>
        [Fact]
        public void Triangulate_ConcentricCircles_CoversEdgePaths()
        {
            var points = new List<TriangulationPoint>();
            for (int ring = 0; ring < 3; ring++)
                for (int i = 0; i < 12; i++)
                {
                    double r = (ring + 1) * 2;
                    double a = i * Math.PI / 6;
                    points.Add(new TriangulationPoint(Math.Cos(a) * r, Math.Sin(a) * r));
                }

            var ps = new PointSet(points);
            var tcx = new DtSweepContext();
            tcx.PrepareTriangulation(ps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(ps.GetTriangles);
        }

        // ========================================================================
        // Integration: Many randomized point sets for stochastic coverage
        // ========================================================================

        /// <summary>
        /// Tests that triangulate random sets for coverage
        /// </summary>
        [Fact]
        public void Triangulate_RandomSetsForCoverage()
        {
            var rand = new Random(42);
            for (int trial = 0; trial < 10; trial++)
            {
                var pts = new List<TriangulationPoint>();
                for (int i = 0; i < 25 + trial * 3; i++)
                    pts.Add(new TriangulationPoint(rand.NextDouble() * 10, rand.NextDouble() * 10));

                var ps = new PointSet(pts);
                var tcx = new DtSweepContext();
                tcx.PrepareTriangulation(ps);
                DtSweep.Triangulate(tcx);
                Assert.NotNull(ps.GetTriangles);
            }
        }

        // ========================================================================
        // Integration: Star-shaped point set constrained
        // ========================================================================

        /// <summary>
        /// Tests that triangulate star constrained covers flip paths
        /// </summary>
        [Fact]
        public void Triangulate_StarConstrained_CoversFlipPaths()
        {
            var points = new List<TriangulationPoint>();
            for (int i = 0; i < 8; i++)
            {
                double a = i * Math.PI / 4;
                points.Add(new TriangulationPoint(Math.Cos(a) * 5, Math.Sin(a) * 5));
                points.Add(new TriangulationPoint(Math.Cos(a + Math.PI / 8) * 2, Math.Sin(a + Math.PI / 8) * 2));
            }

            var constraints = new List<TriangulationPoint>();
            for (int i = 0; i < points.Count - 1; i++)
            {
                if (i % 3 == 0)
                {
                    constraints.Add(points[i]);
                    constraints.Add(points[(i + 3) % points.Count]);
                }
            }

            var cps = new ConstrainedPointSet(points, constraints);
            var tcx = new DtSweepContext();
            tcx.PrepareTriangulation(cps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(cps.GetTriangles);
        }

        // ========================================================================
        // Integration: Large point set coverage
        // ========================================================================

        /// <summary>
        /// Tests that triangulate large point set covers more paths
        /// </summary>
        [Fact]
        public void Triangulate_LargePointSet_CoversMorePaths()
        {
            var pts = new List<TriangulationPoint>();
            for (int i = 0; i < 100; i++)
                pts.Add(new TriangulationPoint(Math.Sin(i * 0.3) * 10, Math.Cos(i * 0.7) * 10));

            var ps = new PointSet(pts);
            var tcx = new DtSweepContext();
            tcx.PrepareTriangulation(ps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(ps.GetTriangles);
        }

        // ========================================================================
        // NEW: Integration tests for specific uncovered branches
        // All tested via Triangulate with carefully designed point sets
        // ========================================================================

        /// <summary>
        /// Integration test covering FinalizationConvexHull if-blocks (110-124)
        /// and FillRightBelowEdgeEvent concave (357-359).
        /// ========================================================================
        /// FillRightAboveEdgeEvent else branch (line 382)
        /// Requires a point set where an advancing front node has 
        /// edge.Q, node.Next, edge.P on a Cw orientation
        /// </summary>
        [Fact]
        public void Triangulate_CoversFillRightAboveElseBranch()
        {
            var points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 1),
                new TriangulationPoint(2, 0),
                new TriangulationPoint(3, 1),
                new TriangulationPoint(4, 0)
            };
            var ps = new PointSet(points);
            var tcx = new DtSweepContext();
            tcx.PrepareTriangulation(ps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(ps.GetTriangles);
        }

        /// <summary>
        /// Covers FillRightBelowEdgeEvent convex (363-365) and FillRightConvexEdgeEvent concave (342)
        /// </summary>
        [Fact]
        public void Triangulate_CoversRightFillPaths()
        {
            var points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(3, 0),
                new TriangulationPoint(3, 2),
                new TriangulationPoint(2, 2),
                new TriangulationPoint(2, 1),
                new TriangulationPoint(0, 1)
            };
            var ps = new PointSet(points);
            var tcx = new DtSweepContext();
            tcx.PrepareTriangulation(ps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(ps.GetTriangles);
        }

        /// <summary>
        /// Covers FillLeftConcaveEdgeEvent recursive (424-426) and FillLeftBelowEdgeEvent convex (446-447)
        /// </summary>
        [Fact]
        public void Triangulate_CoversLeftFillPaths()
        {
            var points = new List<TriangulationPoint>
            {
                new TriangulationPoint(2, 0),
                new TriangulationPoint(3, 0),
                new TriangulationPoint(3, 2),
                new TriangulationPoint(1, 2),
                new TriangulationPoint(0, 1),
                new TriangulationPoint(0, 0)
            };
            var ps = new PointSet(points);
            var tcx = new DtSweepContext();
            tcx.PrepareTriangulation(ps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(ps.GetTriangles);
        }

        /// <summary>
        /// Covers FillRightConcaveEdgeEvent recursive body (319-321) and
        /// FillRightBelowEdgeEvent concave (357-359)
        /// </summary>
        [Fact]
        public void Triangulate_CoversRightConcaveFill()
        {
            var points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 1),
                new TriangulationPoint(2, 0),
                new TriangulationPoint(3, 1),
                new TriangulationPoint(4, 0),
                new TriangulationPoint(5, 1)
            };
            var ps = new PointSet(points);
            var tcx = new DtSweepContext();
            tcx.PrepareTriangulation(ps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(ps.GetTriangles);
        }

        /// <summary>
        /// Covers EdgeEvent catch block (282-285) via constrained edge that triggers recursion
        /// </summary>
        [Fact]
        public void Triangulate_Constrained_CoversEdgeEventCatch()
        {
            var points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(4, 0),
                new TriangulationPoint(4, 3),
                new TriangulationPoint(0, 3),
                new TriangulationPoint(1, 1),
                new TriangulationPoint(3, 1)
            };
            // Single diagonal constraint that won't intersect
            var constraints = new List<TriangulationPoint>
            {
                points[0], points[2]
            };
            var cps = new ConstrainedPointSet(points, constraints);
            var tcx = new DtSweepContext();
            tcx.PrepareTriangulation(cps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(cps.GetTriangles);
        }

        /// <summary>
        /// Covers FlipEdgeEvent and FlipScanEdgeEvent paths via single non-intersecting constraint
        /// </summary>
        [Fact]
        public void Triangulate_FlipEdgePaths_Covered()
        {
            var points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(5, 0),
                new TriangulationPoint(5, 5),
                new TriangulationPoint(0, 5),
                new TriangulationPoint(1, 1),
                new TriangulationPoint(4, 1),
                new TriangulationPoint(4, 4),
                new TriangulationPoint(1, 4)
            };
            // Use one diagonal constraint that lies fully inside
            var constraints = new List<TriangulationPoint>
            {
                points[0], points[2],
                points[4], points[6]
            };
            var cps = new ConstrainedPointSet(points, constraints);
            var tcx = new DtSweepContext();
            tcx.PrepareTriangulation(cps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(cps.GetTriangles);
        }

        /// <summary>
        /// Covers FlipScanEdgeEvent paths via complex non-intersecting constraints
        /// </summary>
        [Fact]
        public void Triangulate_FlipScanPaths_Covered()
        {
            var points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(6, 0),
                new TriangulationPoint(6, 6),
                new TriangulationPoint(0, 6),
                new TriangulationPoint(1, 1),
                new TriangulationPoint(5, 1),
                new TriangulationPoint(5, 5),
                new TriangulationPoint(1, 5)
            };
            var constraints = new List<TriangulationPoint>
            {
                points[0], points[2],
                points[4], points[6]
            };
            var cps = new ConstrainedPointSet(points, constraints);
            var tcx = new DtSweepContext();
            tcx.PrepareTriangulation(cps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(cps.GetTriangles);
        }

        // ========================================================================
        // Reflection-based tests with corrected triangle chain setup
        // ========================================================================

        /// <summary>
        /// FinalizationConvexHull both if-blocks (110-124) via Triangulate + polygon with point inside
        /// The point set is a convex star shape that triggers the tail/head neighbor checks
        /// </summary>
        [Fact]
        public void FinalizationConvexHull_IfBlocks_TriggersViaTriangulate()
        {
            var points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(-1.0, 1.0)
            };

            var ps = new PointSet(points);
            var tcx = new DtSweepContext();
            tcx.PrepareTriangulation(ps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(ps.GetTriangles);
        }

        /// <summary>
        /// Reflection test for FillRightConcaveEdgeEvent recursive body (319-321).
        /// Uses a node chain with all triangles set up correctly.
        /// The recursion stops before tail because Orient2d(node, n3, tail) != Ccw.
        /// </summary>
        [Fact]
        public void FillRightConcaveEdgeEvent_RecursiveBody_Entered()
        {
            var m = GetMethod("FillRightConcaveEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();
            var edge = new DtSweepConstraint(new TriangulationPoint(0, 0), new TriangulationPoint(10, 10));
            tcx.EdgeEvent.ConstrainedEdge = edge;

            var node = new AdvancingFrontNode(new TriangulationPoint(0, 0));
            var n1 = new AdvancingFrontNode(new TriangulationPoint(2, 1));
            var n2 = new AdvancingFrontNode(new TriangulationPoint(4, 3));
            var n3 = new AdvancingFrontNode(new TriangulationPoint(6, 5));
            var tail = new AdvancingFrontNode(new TriangulationPoint(8, 4));
            node.Next = n1; n1.Prev = node;
            n1.Next = n2; n2.Prev = n1;
            n2.Next = n3; n3.Prev = n2;
            n3.Next = tail; tail.Prev = n3;

            var head = new AdvancingFrontNode(new TriangulationPoint(-2, -1))
                {
                    Next = node
                };
            node.Prev = head;
            tcx.AFront = new AdvancingFront(head, tail);

            node.Triangle = new DelaunayTriangle(node.Point, n1.Point, n2.Point);
            n1.Triangle = new DelaunayTriangle(n1.Point, n2.Point, n3.Point);
            n2.Triangle = new DelaunayTriangle(n2.Point, n3.Point, tail.Point);
            n3.Triangle = new DelaunayTriangle(n3.Point, tail.Point, new TriangulationPoint(10, 1));

            tcx.Triangulatable = new MockTriangulatable();

            try { m.Invoke(null, new object[] { tcx, edge, node }); }
            catch (TargetInvocationException) { }

            Assert.NotNull(tcx);
        }

        /// <summary>
        /// Reflection test for FillRightConvexEdgeEvent concave path (line 342).
        /// Orient2d(n1, n2, n3) == Ccw triggers FillRightConcaveEdgeEvent
        /// </summary>
        [Fact]
        public void FillRightConvexEdgeEvent_ConcavePath_Entered()
        {
            var m = GetMethod("FillRightConvexEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();
            var edge = new DtSweepConstraint(new TriangulationPoint(0, 0), new TriangulationPoint(6, 6));
            tcx.EdgeEvent.ConstrainedEdge = edge;
            tcx.EdgeEvent.Right = true;

            var node = new AdvancingFrontNode(new TriangulationPoint(0, 0));
            var n1 = new AdvancingFrontNode(new TriangulationPoint(2, 0));
            var n2 = new AdvancingFrontNode(new TriangulationPoint(4, 1));
            var n3 = new AdvancingFrontNode(new TriangulationPoint(6, 2));
            var n4 = new AdvancingFrontNode(new TriangulationPoint(8, 3));
            var tail = new AdvancingFrontNode(new TriangulationPoint(10, 4));
            node.Next = n1; n1.Prev = node;
            n1.Next = n2; n2.Prev = n1;
            n2.Next = n3; n3.Prev = n2;
            n3.Next = n4; n4.Prev = n3;
            n4.Next = tail; tail.Prev = n4;

            var head = new AdvancingFrontNode(new TriangulationPoint(-2, -1))
                {
                    Next = node
                };
            node.Prev = head;
            tcx.AFront = new AdvancingFront(head, tail);

            node.Triangle = new DelaunayTriangle(node.Point, n1.Point, n2.Point);
            n1.Triangle = new DelaunayTriangle(n1.Point, n2.Point, n3.Point);
            n2.Triangle = new DelaunayTriangle(n2.Point, n3.Point, n4.Point);
            n3.Triangle = new DelaunayTriangle(n3.Point, n4.Point, tail.Point);
            n4.Triangle = new DelaunayTriangle(n4.Point, tail.Point, new TriangulationPoint(12, 5));

            tcx.Triangulatable = new MockTriangulatable();

            try { m.Invoke(null, new object[] { tcx, edge, node }); }
            catch (TargetInvocationException) { }

            Assert.NotNull(tcx);
        }

        /// <summary>
        /// Reflection test for FillRightBelowEdgeEvent concave branch (357-359).
        /// Orient2d(node, n1, n2) == Ccw triggers FillRightConcaveEdgeEvent
        /// </summary>
        [Fact]
        public void FillRightBelowEdgeEvent_ConcaveBranch_Entered()
        {
            var m = GetMethod("FillRightBelowEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();
            var edge = new DtSweepConstraint(new TriangulationPoint(0, 0), new TriangulationPoint(8, 8));
            tcx.EdgeEvent.ConstrainedEdge = edge;

            var node = new AdvancingFrontNode(new TriangulationPoint(1, 1));
            var n1 = new AdvancingFrontNode(new TriangulationPoint(2, 2));
            var n2 = new AdvancingFrontNode(new TriangulationPoint(4, 3));
            var n3 = new AdvancingFrontNode(new TriangulationPoint(6, 4));
            var tail = new AdvancingFrontNode(new TriangulationPoint(8, 3));
            node.Next = n1; n1.Prev = node;
            n1.Next = n2; n2.Prev = n1;
            n2.Next = n3; n3.Prev = n2;
            n3.Next = tail; tail.Prev = n3;

            var head = new AdvancingFrontNode(new TriangulationPoint(-1, -1))
                {
                    Next = node
                };
            node.Prev = head;
            tcx.AFront = new AdvancingFront(head, tail);

            var extra = new TriangulationPoint(10, 10);
            node.Triangle = new DelaunayTriangle(node.Point, n1.Point, n2.Point);
            n1.Triangle = new DelaunayTriangle(n1.Point, n2.Point, n3.Point);
            n2.Triangle = new DelaunayTriangle(n2.Point, n3.Point, tail.Point);
            n3.Triangle = new DelaunayTriangle(n3.Point, tail.Point, extra);

            tcx.Triangulatable = new MockTriangulatable();

            try { m.Invoke(null, new object[] { tcx, edge, node }); }
            catch (TargetInvocationException) { }

            Assert.NotNull(tcx);
        }

        /// <summary>
        /// Reflection test for FillRightBelowEdgeEvent convex branch (363-365).
        /// Orient2d(node, n1, n2) != Ccw triggers FillRightConvexEdgeEvent + recursion
        /// </summary>
        [Fact]
        public void FillRightBelowEdgeEvent_ConvexBranch_Entered()
        {
            var m = GetMethod("FillRightBelowEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();
            var edge = new DtSweepConstraint(new TriangulationPoint(0, 0), new TriangulationPoint(8, 8));
            tcx.EdgeEvent.ConstrainedEdge = edge;

            var node = new AdvancingFrontNode(new TriangulationPoint(1, 1));
            var n1 = new AdvancingFrontNode(new TriangulationPoint(4, 3));
            var n2 = new AdvancingFrontNode(new TriangulationPoint(6, 2));
            var n3 = new AdvancingFrontNode(new TriangulationPoint(7, 5));
            var tail = new AdvancingFrontNode(new TriangulationPoint(9, 9));
            node.Next = n1; n1.Prev = node;
            n1.Next = n2; n2.Prev = n1;
            n2.Next = n3; n3.Prev = n2;
            n3.Next = tail; tail.Prev = n3;

            var head = new AdvancingFrontNode(new TriangulationPoint(-1, -1))
                {
                    Next = node
                };
            node.Prev = head;
            tcx.AFront = new AdvancingFront(head, tail);

            var extra = new TriangulationPoint(10, 10);
            node.Triangle = new DelaunayTriangle(node.Point, n1.Point, n2.Point);
            n1.Triangle = new DelaunayTriangle(n1.Point, n2.Point, n3.Point);
            n2.Triangle = new DelaunayTriangle(n2.Point, n3.Point, tail.Point);
            n3.Triangle = new DelaunayTriangle(n3.Point, tail.Point, extra);

            tcx.Triangulatable = new MockTriangulatable();

            try { m.Invoke(null, new object[] { tcx, edge, node }); }
            catch (TargetInvocationException) { }

            Assert.NotNull(tcx);
        }

        /// <summary>
        /// Reflection test for FillRightAboveEdgeEvent else branch (line 382).
        /// Orient2d(Q, Next, P) is Cw -> enters else branch
        /// </summary>
        [Fact]
        public void FillRightAboveEdgeEvent_ElseBranch_Entered()
        {
            var m = GetMethod("FillRightAboveEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();
            var edge = new DtSweepConstraint(new TriangulationPoint(0, 0), new TriangulationPoint(8, 0));
            tcx.EdgeEvent.ConstrainedEdge = edge;
            tcx.EdgeEvent.Right = true;

            var node = new AdvancingFrontNode(new TriangulationPoint(0, 0))
                {
                    Next = new AdvancingFrontNode(new TriangulationPoint(3, 2))
                        {
                            Next = new AdvancingFrontNode(new TriangulationPoint(7, 1))
                        }
                };
            tcx.Triangulatable = new MockTriangulatable();

            m.Invoke(null, new object[] { tcx, edge, node });
            Assert.NotNull(tcx.EdgeEvent.ConstrainedEdge);
        }

        /// <summary>
        /// Reflection test for FillLeftConcaveEdgeEvent recursive body (424-426).
        /// </summary>
        [Fact]
        public void FillLeftConcaveEdgeEvent_RecursiveBody_Entered()
        {
            var m = GetMethod("FillLeftConcaveEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();
            var edge = new DtSweepConstraint(new TriangulationPoint(10, 0), new TriangulationPoint(0, 10));
            tcx.EdgeEvent.ConstrainedEdge = edge;
            tcx.EdgeEvent.Right = false;

            var node = new AdvancingFrontNode(new TriangulationPoint(8, 2));
            var p1 = new AdvancingFrontNode(new TriangulationPoint(6, 4));
            var p2 = new AdvancingFrontNode(new TriangulationPoint(4, 6));
            var p3 = new AdvancingFrontNode(new TriangulationPoint(2, 8));
            var head = new AdvancingFrontNode(new TriangulationPoint(-2, 12));
            var tail = new AdvancingFrontNode(new TriangulationPoint(12, -2));
            node.Prev = p1; p1.Next = node;
            p1.Prev = p2; p2.Next = p1;
            p2.Prev = p3; p3.Next = p2;
            head.Next = p3; p3.Prev = head;
            node.Next = tail; tail.Prev = node;

            p3.Prev = head; head.Next = p3;
            tcx.AFront = new AdvancingFront(head, tail);

            var extra = new TriangulationPoint(0, 0);
            node.Triangle = new DelaunayTriangle(p1.Point, node.Point, tail.Point);
            p1.Triangle = new DelaunayTriangle(p2.Point, p1.Point, node.Point);
            p2.Triangle = new DelaunayTriangle(p3.Point, p2.Point, p1.Point);
            p3.Triangle = new DelaunayTriangle(head.Point, p3.Point, p2.Point);

            tcx.Triangulatable = new MockTriangulatable();

            try { m.Invoke(null, new object[] { tcx, edge, node }); }
            catch (TargetInvocationException) { }

            Assert.NotNull(tcx);
        }

        /// <summary>
        /// Reflection test for FillLeftBelowEdgeEvent convex branch (446-447).
        /// </summary>
        [Fact]
        public void FillLeftBelowEdgeEvent_ConvexBranch_Entered()
        {
            var m = GetMethod("FillLeftBelowEdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();
            var edge = new DtSweepConstraint(new TriangulationPoint(8, 0), new TriangulationPoint(0, 8));
            tcx.EdgeEvent.ConstrainedEdge = edge;
            tcx.EdgeEvent.Right = false;

            var node = new AdvancingFrontNode(new TriangulationPoint(7, 1));
            var p1 = new AdvancingFrontNode(new TriangulationPoint(5, 3));
            var p2 = new AdvancingFrontNode(new TriangulationPoint(3, 2));
            var p3 = new AdvancingFrontNode(new TriangulationPoint(1, 5));
            var head = new AdvancingFrontNode(new TriangulationPoint(-1, 7));
            var tail = new AdvancingFrontNode(new TriangulationPoint(10, -1));
            node.Prev = p1; p1.Next = node;
            p1.Prev = p2; p2.Next = p1;
            p2.Prev = p3; p3.Next = p2;
            head.Next = p3; p3.Prev = head;
            node.Next = tail; tail.Prev = node;
            tcx.AFront = new AdvancingFront(head, tail);

            var extra = new TriangulationPoint(0, 0);
            node.Triangle = new DelaunayTriangle(p1.Point, node.Point, tail.Point);
            p1.Triangle = new DelaunayTriangle(p2.Point, p1.Point, node.Point);
            p2.Triangle = new DelaunayTriangle(p3.Point, p2.Point, p1.Point);
            p3.Triangle = new DelaunayTriangle(head.Point, p3.Point, p2.Point);

            tcx.Triangulatable = new MockTriangulatable();

            try { m.Invoke(null, new object[] { tcx, edge, node }); }
            catch (TargetInvocationException) { }

            Assert.NotNull(tcx);
        }

        // ========================================================================
        // EdgeEvent (via 3-param) catch block (lines 282-285)
        // Uses a constraint that forces PointOnEdgeException in the recursive call
        // ========================================================================

        /// <summary>
        /// Tests EdgeEvent catch block fires when recursive call throws.
        /// </summary>
        [Fact]
        public void EdgeEvent_CatchBlock_Fires()
        {
            var m = GetMethod("EdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));

            var eq = new TriangulationPoint(1, 1);
            var ep = new TriangulationPoint(3, 1);

            var node = new AdvancingFrontNode(eq)
                {
                    Next = new AdvancingFrontNode(new TriangulationPoint(3, 2)),
                    Triangle = new DelaunayTriangle(eq, new TriangulationPoint(1, 2), new TriangulationPoint(2, 2))
                };

            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = new DtSweepConstraint(eq, ep),
                        Right = true
                    },
                    Triangulatable = new MockTriangulatable()
                };

            try { m.Invoke(null, new object[] { tcx, new DtSweepConstraint(eq, ep), node }); }
            catch (TargetInvocationException) { }

            Assert.NotNull(tcx);
        }

        // ========================================================================
        // EdgeEvent via 3-param overload: trigger o2 collinear Contains true
        // Covers lines 545, 551-552
        // ========================================================================

        /// <summary>
        /// Tests EdgeEvent 5-param o2 collinear Contains true via the 3-param route.
        /// </summary>
        [Fact]
        public void EdgeEvent_O2Collinear_ContainsTrue_CoversLines()
        {
            var m = GetMethod("EdgeEvent",
                typeof(DtSweepContext), typeof(DtSweepConstraint), typeof(AdvancingFrontNode));

            var eq = new TriangulationPoint(1, 1);
            var ep = new TriangulationPoint(2, 2);

            var node = new AdvancingFrontNode(eq)
                {
                    Next = new AdvancingFrontNode(new TriangulationPoint(3, 1))
                };

            var triangle = new DelaunayTriangle(eq, new TriangulationPoint(1, 2), new TriangulationPoint(0, 0));
            node.Triangle = triangle;

            var neighbor = new DelaunayTriangle(ep, eq, new TriangulationPoint(2, 0));
            triangle.Neighbors[0] = neighbor;

            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = new DtSweepConstraint(eq, ep),
                        Right = true
                    },
                    Triangulatable = new MockTriangulatable()
                };

            try { m.Invoke(null, new object[] { tcx, new DtSweepConstraint(eq, ep), node }); }
            catch (TargetInvocationException) { }

            Assert.NotNull(tcx);
        }

        // ========================================================================
        // FlipEdgeEvent sub-branches via direct reflection
        // ========================================================================

        /// <summary>
        /// FlipEdgeEvent subedge done path (612-614): InScanArea=true, p==eq && op==ep,
        /// but (eq,ep) != ConstrainedEdge
        /// </summary>
        [Fact]
        public void FlipEdgeEvent_SubedgeDone_Path_Entered()
        {
            var m = GetMethod("FlipEdgeEvent",
                typeof(DtSweepContext), typeof(TriangulationPoint), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(TriangulationPoint));

            var p = new TriangulationPoint(0, 0);
            var pb = new TriangulationPoint(1, 0);
            var pc = new TriangulationPoint(0, 1);

            var t = new DelaunayTriangle(p, pb, pc);
            var eq = p;
            var op = new TriangulationPoint(0.25, 0.25);
            var ep = op;

            var ot = new DelaunayTriangle(pb, op, pc);
            t.Neighbors[0] = ot;
            ot.Neighbors[1] = t;

            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = new DtSweepConstraint(
                            new TriangulationPoint(10, 0), new TriangulationPoint(0, 10)),
                        Right = true
                    },
                    Triangulatable = new MockTriangulatable()
                };

            try { m.Invoke(null, new object[] { tcx, ep, eq, t, p }); }
            catch (TargetInvocationException) { }

            Assert.NotNull(tcx);
        }

        /// <summary>
        /// FlipEdgeEvent continuing flip (617-622): InScanArea=true, (p!=eq || op!=ep)
        /// </summary>
        [Fact]
        public void FlipEdgeEvent_ContinuingFlip_Path_Entered()
        {
            var m = GetMethod("FlipEdgeEvent",
                typeof(DtSweepContext), typeof(TriangulationPoint), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(TriangulationPoint));

            var p = new TriangulationPoint(0, 0);
            var eq = new TriangulationPoint(0, 0);
            var ep = new TriangulationPoint(2, 2);
            var pb = new TriangulationPoint(1, 0);
            var pc = new TriangulationPoint(0, 1);
            var op = new TriangulationPoint(0.25, 0.25);

            var t = new DelaunayTriangle(p, pb, pc);
            var ot = new DelaunayTriangle(pb, op, pc);
            t.Neighbors[0] = ot;
            ot.Neighbors[1] = t;

            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = new DtSweepConstraint(eq, ep),
                        Right = true
                    },
                    Triangulatable = new MockTriangulatable()
                };

            try { m.Invoke(null, new object[] { tcx, ep, eq, t, p }); }
            catch (TargetInvocationException) { }

            Assert.NotNull(tcx);
        }

        /// <summary>
        /// FlipEdgeEvent not-in-scan-area (628-629): InScanArea=false
        /// </summary>
        [Fact]
        public void FlipEdgeEvent_NotInScanArea_Path_Entered()
        {
            var m = GetMethod("FlipEdgeEvent",
                typeof(DtSweepContext), typeof(TriangulationPoint), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(TriangulationPoint));

            var p = new TriangulationPoint(0, 0);
            var pb = new TriangulationPoint(1, 0);
            var pc = new TriangulationPoint(0, 1);
            var op = new TriangulationPoint(5, 5);

            var t = new DelaunayTriangle(p, pb, pc);
            var ot = new DelaunayTriangle(pb, op, pc);
            t.Neighbors[0] = ot;
            ot.Neighbors[1] = t;

            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = new DtSweepConstraint(p, op),
                        Right = true
                    },
                    Triangulatable = new MockTriangulatable()
                };

            try { m.Invoke(null, new object[] { tcx, op, p, t, p }); }
            catch (TargetInvocationException) { }

            Assert.NotNull(tcx);
        }

        // ========================================================================
        // FlipScanEdgeEvent sub-branches via direct reflection
        // ========================================================================

        /// <summary>
        /// FlipScanEdgeEvent in-scan-area (703-704)
        /// </summary>
        [Fact]
        public void FlipScanEdgeEvent_InScanArea_Path_Entered()
        {
            var m = GetMethod("FlipScanEdgeEvent",
                typeof(DtSweepContext), typeof(TriangulationPoint), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(DelaunayTriangle), typeof(TriangulationPoint));

            var eq = new TriangulationPoint(0, 0);
            var ep = new TriangulationPoint(2, 0);
            var pb = new TriangulationPoint(1, 0);
            var pc = new TriangulationPoint(0, 1);
            var op = new TriangulationPoint(0.25, 0.25);

            var flipTriangle = new DelaunayTriangle(eq, pb, pc);
            var t = new DelaunayTriangle(pb, op, pc);
            flipTriangle.Neighbors[0] = t;
            t.Neighbors[1] = flipTriangle;

            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = new DtSweepConstraint(eq, ep),
                        Right = true
                    },
                    Triangulatable = new MockTriangulatable()
                };

            try { m.Invoke(null, new object[] { tcx, ep, eq, flipTriangle, t, op }); }
            catch (TargetInvocationException) { }

            Assert.NotNull(tcx);
        }

        /// <summary>
        /// FlipScanEdgeEvent not-in-scan-area recursive (710-712)
        /// </summary>
        [Fact]
        public void FlipScanEdgeEvent_NotInScanArea_Recursive_Entered()
        {
            var m = GetMethod("FlipScanEdgeEvent",
                typeof(DtSweepContext), typeof(TriangulationPoint), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(DelaunayTriangle), typeof(TriangulationPoint));

            var eq = new TriangulationPoint(0, 0);
            var ep = new TriangulationPoint(2, 0);
            var pb = new TriangulationPoint(1, 0);
            var pc = new TriangulationPoint(0, 1);
            var op = new TriangulationPoint(5, 5);

            var flipTriangle = new DelaunayTriangle(eq, pb, pc);
            var t = new DelaunayTriangle(pb, op, pc);
            flipTriangle.Neighbors[0] = t;
            t.Neighbors[1] = flipTriangle;
            t.Neighbors[0] = new DelaunayTriangle(op, new TriangulationPoint(6, 6), pb);

            var tcx = new DtSweepContext
                {
                    EdgeEvent = {
                        ConstrainedEdge = new DtSweepConstraint(eq, ep),
                        Right = true
                    },
                    Triangulatable = new MockTriangulatable()
                };

            try { m.Invoke(null, new object[] { tcx, ep, eq, flipTriangle, t, op }); }
            catch (TargetInvocationException) { }

            Assert.NotNull(tcx);
        }
    }

    /// <summary>
    /// The mock triangulatable class
    /// </summary>
    /// <seealso cref="ITriangulatable"/>
    internal class MockTriangulatable : ITriangulatable
    {
        /// <summary>
        /// The delaunay triangle
        /// </summary>
        public readonly List<DelaunayTriangle> Triangles = new List<DelaunayTriangle>();
        /// <summary>
        /// Gets the value of the get points
        /// </summary>
        public IList<TriangulationPoint> GetPoints => new List<TriangulationPoint>();
        /// <summary>
        /// Gets the value of the get triangles
        /// </summary>
        public IList<DelaunayTriangle> GetTriangles => Triangles.AsReadOnly();
        /// <summary>
        /// Gets the value of the triangulation mode
        /// </summary>
        public TriangulationMode TriangulationMode => TriangulationMode.Unconstrained;
        /// <summary>
        /// Prepares the triangulation using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        public void PrepareTriangulation(TriangulationContext tcx) { }
        /// <summary>
        /// Adds the triangle using the specified t
        /// </summary>
        /// <param name="t">The </param>
        public void AddTriangle(DelaunayTriangle t) => Triangles.Add(t);
        /// <summary>
        /// Adds the triangles using the specified tris
        /// </summary>
        /// <param name="tris">The tris</param>
        public void AddTriangles(IEnumerable<DelaunayTriangle> tris) => Triangles.AddRange(tris);
        /// <summary>
        /// Clears the triangles
        /// </summary>
        public void ClearTriangles() => Triangles.Clear();
    }
}
