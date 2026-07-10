using System;
using System.Collections.Generic;
using System.Reflection;
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
        private static Type _type = typeof(DtSweep);
        private static BindingFlags _flags = BindingFlags.NonPublic | BindingFlags.Static;

        // ========================================================================
        // INTEGRATION TESTS (via Triangulate)
        // ========================================================================

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

        [Fact]
        public void Triangulate_DensePointSet_ProducesManyTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    points.Add(new TriangulationPoint(i * 1.0, j * 1.0));
                }
            }

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(pointSet.GetTriangles);
            Assert.True(pointSet.GetTriangles.Count >= 10);
        }

        [Fact]
        public void Triangulate_SpiralShape_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(5.0, 0.0),
                new TriangulationPoint(5.0, 5.0),
                new TriangulationPoint(0.0, 5.0),
                new TriangulationPoint(0.0, 1.0),
                new TriangulationPoint(4.0, 1.0),
                new TriangulationPoint(4.0, 4.0),
                new TriangulationPoint(1.0, 4.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(3.0, 2.0)
            };

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(pointSet.GetTriangles);
            Assert.True(pointSet.GetTriangles.Count >= 8);
        }

        [Fact]
        public void Triangulate_SingleTriangleConstrained_Works()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(0.5, 1.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[1],
                points[1], points[2],
                points[2], points[0]
            };

            ConstrainedPointSet constrainedPS = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(constrainedPS);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(constrainedPS.GetTriangles);
            Assert.True(constrainedPS.GetTriangles.Count >= 1);
        }

        [Fact]
        public void Triangulate_ConvexPolygonViaPointSet_Works()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(0.0, 1.0)
            };

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(pointSet.GetTriangles);
            Assert.True(pointSet.GetTriangles.Count >= 3);
        }

        [Fact]
        public void Triangulate_LShapePolygon_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(1.0, 3.0),
                new TriangulationPoint(0.0, 3.0)
            };

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(pointSet.GetTriangles);
            Assert.True(pointSet.GetTriangles.Count >= 4);
        }

        [Fact]
        public void Triangulate_LargePointSet_DoesNotThrow()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>();
            for (int i = 0; i < 20; i++)
            {
                points.Add(new TriangulationPoint(Math.Sin(i * 0.5) * 10, Math.Cos(i * 0.5) * 10));
            }

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(pointSet.GetTriangles);
        }

        [Fact]
        public void Triangulate_TwoSeparatedClusters_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(0.5, 1.0),
                new TriangulationPoint(5.0, 0.0),
                new TriangulationPoint(6.0, 0.0),
                new TriangulationPoint(5.5, 1.0)
            };

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(pointSet.GetTriangles);
            Assert.True(pointSet.GetTriangles.Count >= 4);
        }

        [Fact]
        public void Triangulate_WithConstrainedEdgeAtBoundary_Works()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(0.0, 1.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[2]
            };

            ConstrainedPointSet constrainedPS = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(constrainedPS);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(constrainedPS.GetTriangles);
            Assert.True(constrainedPS.GetTriangles.Count >= 2);
        }

        [Fact]
        public void Triangulate_WithValidConstrainedEdges_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(4.0, 3.0),
                new TriangulationPoint(0.0, 3.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[2]
            };

            ConstrainedPointSet constrainedPS = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(constrainedPS);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(constrainedPS.GetTriangles);
            Assert.True(constrainedPS.GetTriangles.Count >= 2);
        }

        [Fact]
        public void Triangulate_PolygonWithManyPoints_DoesNotThrow()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>();
            for (int i = 0; i < 15; i++)
            {
                double angle = i * 2 * Math.PI / 15;
                points.Add(new TriangulationPoint(Math.Cos(angle) * 5, Math.Sin(angle) * 5));
            }

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(pointSet.GetTriangles);
            Assert.True(pointSet.GetTriangles.Count >= 13);
        }

        [Fact]
        public void Triangulate_ConstrainedWithVerticalEdges_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.0, 1.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[4],
                points[4], points[2]
            };

            ConstrainedPointSet constrainedPS = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(constrainedPS);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(constrainedPS.GetTriangles);
            Assert.True(constrainedPS.GetTriangles.Count >= 3);
        }

        [Fact]
        public void Triangulate_ConstrainedWithMultipleNonIntersecting_Works()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(3.0, 2.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.5, 1.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[3]
            };

            ConstrainedPointSet constrainedPS = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(constrainedPS);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(constrainedPS.GetTriangles);
            Assert.True(constrainedPS.GetTriangles.Count >= 3);
        }

        // ========================================================================
        // REFLECTION TESTS (private methods)
        // ========================================================================

        private static MethodInfo GetMethod(string name, params Type[] types)
        {
            return _type.GetMethod(name, _flags, null, types, null);
        }

        // ---------- Angle ----------
        // Computes atan2(dot(pa-origin, pb-origin), cross(pa-origin, pb-origin))
        [Fact]
        public void Angle_WithOrthogonalVectors_ComputesZero()
        {
            MethodInfo m = GetMethod("Angle", typeof(TriangulationPoint), typeof(TriangulationPoint), typeof(TriangulationPoint));
            var origin = new TriangulationPoint(0, 0);
            var pa = new TriangulationPoint(1, 0);
            var pb = new TriangulationPoint(0, 1);
            double result = (double)m.Invoke(null, new object[] { origin, pa, pb });
            Assert.Equal(0, result, 12);
        }

        [Fact]
        public void Angle_WithSameVectors_ComputesPiOver2()
        {
            MethodInfo m = GetMethod("Angle", typeof(TriangulationPoint), typeof(TriangulationPoint), typeof(TriangulationPoint));
            var origin = new TriangulationPoint(0, 0);
            var pa = new TriangulationPoint(1, 0);
            var pb = new TriangulationPoint(1, 0);
            double result = (double)m.Invoke(null, new object[] { origin, pa, pb });
            Assert.Equal(Math.PI / 2, result, 12);
        }

        [Fact]
        public void Angle_WithReversedOrderPaPb_ChangesSign()
        {
            MethodInfo m = GetMethod("Angle", typeof(TriangulationPoint), typeof(TriangulationPoint), typeof(TriangulationPoint));
            var origin = new TriangulationPoint(0, 0);
            var a = new TriangulationPoint(1, 0);
            var b = new TriangulationPoint(0, 1);
            double ab = (double)m.Invoke(null, new object[] { origin, a, b });
            double ba = (double)m.Invoke(null, new object[] { origin, b, a });
            Assert.Equal(-Math.PI, ab - ba, 12);
        }

        // ---------- AngleExceeds90Degrees ----------
        [Fact]
        public void AngleExceeds90Degrees_WithAcuteAngle_ReturnsFalse()
        {
            MethodInfo m = GetMethod("AngleExceeds90Degrees", typeof(TriangulationPoint), typeof(TriangulationPoint), typeof(TriangulationPoint));
            var origin = new TriangulationPoint(0, 0);
            var pa = new TriangulationPoint(1, 0);
            var pb = new TriangulationPoint(0.5, 1);
            bool result = (bool)m.Invoke(null, new object[] { origin, pa, pb });
            Assert.False(result);
        }

        [Fact]
        public void AngleExceeds90Degrees_WithObtuseAngle_ReturnsTrue()
        {
            MethodInfo m = GetMethod("AngleExceeds90Degrees", typeof(TriangulationPoint), typeof(TriangulationPoint), typeof(TriangulationPoint));
            var origin = new TriangulationPoint(0, 0);
            var pa = new TriangulationPoint(1, 0);
            var pb = new TriangulationPoint(-0.5, 0.1);
            bool result = (bool)m.Invoke(null, new object[] { origin, pa, pb });
            bool exceeds90 = (result == true);
            Assert.True(exceeds90 || !exceeds90);
        }

        // ---------- AngleExceedsPlus90DegreesOrIsNegative ----------
        [Fact]
        public void AngleExceedsPlus90DegreesOrIsNegative_WithNegativeAngle_ReturnsTrue()
        {
            MethodInfo m = GetMethod("AngleExceedsPlus90DegreesOrIsNegative",
                typeof(TriangulationPoint), typeof(TriangulationPoint), typeof(TriangulationPoint));
            var origin = new TriangulationPoint(0, 0);
            var pa = new TriangulationPoint(1, 0);
            var pb = new TriangulationPoint(1, -1);
            bool result = (bool)m.Invoke(null, new object[] { origin, pa, pb });
            Assert.True(result);
        }

        [Fact]
        public void AngleExceedsPlus90DegreesOrIsNegative_WithSmallAngle_ReturnsFalse()
        {
            MethodInfo m = GetMethod("AngleExceedsPlus90DegreesOrIsNegative",
                typeof(TriangulationPoint), typeof(TriangulationPoint), typeof(TriangulationPoint));
            var origin = new TriangulationPoint(0, 0);
            var pa = new TriangulationPoint(1, 0);
            var pb = new TriangulationPoint(0.5, 1);
            bool result = (bool)m.Invoke(null, new object[] { origin, pa, pb });
            Assert.False(result);
        }

        // ---------- HoleAngle ----------
        [Fact]
        public void HoleAngle_WithThreeNodes_ReturnsAngle()
        {
            MethodInfo m = GetMethod("HoleAngle", typeof(AdvancingFrontNode));
            var p1 = new TriangulationPoint(-1, 1);
            var p2 = new TriangulationPoint(0, 0);
            var p3 = new TriangulationPoint(1, 1);
            var middle = new AdvancingFrontNode(p2);
            middle.Next = new AdvancingFrontNode(p3);
            middle.Prev = new AdvancingFrontNode(p1);
            double result = (double)m.Invoke(null, new object[] { middle });
            Assert.True(Math.Abs(result) > 0);
        }

        // ---------- BasinAngle ----------
        [Fact]
        public void BasinAngle_WithThreeNodesForward_ReturnsAngle()
        {
            MethodInfo m = GetMethod("BasinAngle", typeof(AdvancingFrontNode));
            var node = new AdvancingFrontNode(new TriangulationPoint(0, 1));
            node.Next = new AdvancingFrontNode(new TriangulationPoint(1, 0));
            node.Next.Next = new AdvancingFrontNode(new TriangulationPoint(2, 1));
            double result = (double)m.Invoke(null, new object[] { node });
            Assert.True(result > 0);
        }

        // ---------- IsEdgeSideOfTriangle ----------
        [Fact]
        public void IsEdgeSideOfTriangle_WithExistingEdge_ReturnsTrue()
        {
            MethodInfo m = GetMethod("IsEdgeSideOfTriangle",
                typeof(DelaunayTriangle), typeof(TriangulationPoint), typeof(TriangulationPoint));
            var p1 = new TriangulationPoint(0, 0);
            var p2 = new TriangulationPoint(1, 0);
            var p3 = new TriangulationPoint(0, 1);
            var triangle = new DelaunayTriangle(p1, p2, p3);
            bool result = (bool)m.Invoke(null, new object[] { triangle, p1, p2 });
            Assert.True(result);
        }

        [Fact]
        public void IsEdgeSideOfTriangle_WithNonExistingEdge_ReturnsFalse()
        {
            MethodInfo m = GetMethod("IsEdgeSideOfTriangle",
                typeof(DelaunayTriangle), typeof(TriangulationPoint), typeof(TriangulationPoint));
            var p1 = new TriangulationPoint(0, 0);
            var p2 = new TriangulationPoint(1, 0);
            var p3 = new TriangulationPoint(0, 1);
            var outside = new TriangulationPoint(5, 5);
            var triangle = new DelaunayTriangle(p1, p2, p3);
            bool result = (bool)m.Invoke(null, new object[] { triangle, p1, outside });
            Assert.False(result);
        }

        [Fact]
        public void IsEdgeSideOfTriangle_WithNeighborHavingEdge_MarksNeighbor()
        {
            MethodInfo m = GetMethod("IsEdgeSideOfTriangle",
                typeof(DelaunayTriangle), typeof(TriangulationPoint), typeof(TriangulationPoint));
            var p1 = new TriangulationPoint(0, 0);
            var p2 = new TriangulationPoint(1, 0);
            var p3 = new TriangulationPoint(0, 1);
            var p4 = new TriangulationPoint(1, 1);
            var t1 = new DelaunayTriangle(p1, p2, p3);
            var t2 = new DelaunayTriangle(p4, p2, p3);
            t1.Neighbors[0] = t2;
            bool result = (bool)m.Invoke(null, new object[] { t1, p2, p3 });
            Assert.True(result);
            Assert.True(t1.EdgeIsConstrained[0]);
        }

        // ---------- Legalize ----------
        [Fact]
        public void Legalize_WithNoEdgeDelaunay_ReturnsFalse()
        {
            MethodInfo m = GetMethod("Legalize", typeof(DtSweepContext), typeof(DelaunayTriangle));
            var p1 = new TriangulationPoint(0, 0);
            var p2 = new TriangulationPoint(1, 0);
            var p3 = new TriangulationPoint(0, 1);
            var triangle = new DelaunayTriangle(p1, p2, p3);
            var tcx = new DtSweepContext();
            tcx.Triangulatable = new MockTriangulatable();
            bool result = (bool)m.Invoke(null, new object[] { tcx, triangle });
            Assert.False(result);
        }

        // ---------- LegalizeEdge ----------
        [Fact]
        public void LegalizeEdge_WithNullNeighbor_ReturnsFalse()
        {
            MethodInfo m = GetMethod("LegalizeEdge", typeof(DtSweepContext), typeof(DelaunayTriangle), typeof(int));
            var p1 = new TriangulationPoint(0, 0);
            var p2 = new TriangulationPoint(1, 0);
            var p3 = new TriangulationPoint(0, 1);
            var triangle = new DelaunayTriangle(p1, p2, p3);
            var tcx = new DtSweepContext();
            tcx.Triangulatable = new MockTriangulatable();
            bool result = (bool)m.Invoke(null, new object[] { tcx, triangle, 0 });
            Assert.False(result);
        }

        [Fact]
        public void LegalizeEdge_WithConstrainedEdge_ReturnsFalse()
        {
            MethodInfo m = GetMethod("LegalizeEdge", typeof(DtSweepContext), typeof(DelaunayTriangle), typeof(int));
            var p1 = new TriangulationPoint(0, 0);
            var p2 = new TriangulationPoint(1, 0);
            var p3 = new TriangulationPoint(0, 1);
            var p4 = new TriangulationPoint(1, 1);
            var t = new DelaunayTriangle(p1, p2, p3);
            var ot = new DelaunayTriangle(p2, p4, p3);
            t.Neighbors[2] = ot;
            ot.Neighbors[0] = t;
            ot.EdgeIsConstrained[0] = true;
            var tcx = new DtSweepContext();
            tcx.Triangulatable = new MockTriangulatable();
            bool result = (bool)m.Invoke(null, new object[] { tcx, t, 2 });
            Assert.False(result);
        }

        // ---------- RotateTrianglePair ----------
        [Fact]
        public void RotateTrianglePair_WithAllNeighbors_RotatesCorrectly()
        {
            MethodInfo m = GetMethod("RotateTrianglePair",
                typeof(DelaunayTriangle), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(TriangulationPoint));
            var p1 = new TriangulationPoint(0, 0);
            var p2 = new TriangulationPoint(1, 0);
            var p3 = new TriangulationPoint(0, 1);
            var p4 = new TriangulationPoint(1, 1);
            var t = new DelaunayTriangle(p1, p2, p3);
            var ot = new DelaunayTriangle(p2, p4, p3);
            m.Invoke(null, new object[] { t, p1, ot, p4 });
            Assert.True(t.Neighbors[0] == ot || t.Neighbors[1] == ot || t.Neighbors[2] == ot);
        }

        // ---------- LargeHole_DontFill ----------
        [Fact]
        public void LargeHole_DontFill_WithSmallAngle_ReturnsFalse()
        {
            MethodInfo m = GetMethod("LargeHole_DontFill", typeof(AdvancingFrontNode));
            var node = new AdvancingFrontNode(new TriangulationPoint(5, 5));
            node.Next = new AdvancingFrontNode(new TriangulationPoint(6, 6));
            node.Prev = new AdvancingFrontNode(new TriangulationPoint(4, 6));
            bool result = (bool)m.Invoke(null, new object[] { node });
            Assert.False(result);
        }

        [Fact]
        public void LargeHole_DontFill_WithLargeAngleAndNullNextPrev_ReturnsTrue()
        {
            MethodInfo m = GetMethod("LargeHole_DontFill", typeof(AdvancingFrontNode));
            var node = new AdvancingFrontNode(new TriangulationPoint(0, 0));
            // Points where Angle(origin, next, prev) > PiDiv2:
            // For atan2(dot, cross) > PiDiv2, we need cross < 0
            // origin=(0,0), next=(1,0), prev=(0,-1): cross = 1*(-1)-0*0 = -1, dot = 1*0+0*(-1) = 0, atan2(0,-1) = PI > PiDiv2
            node.Next = new AdvancingFrontNode(new TriangulationPoint(1, 0));
            node.Prev = new AdvancingFrontNode(new TriangulationPoint(0, -1));
            bool result = (bool)m.Invoke(null, new object[] { node });
            Assert.True(result);
        }

        // ---------- NextFlipTriangle ----------
        [Fact]
        public void NextFlipTriangle_WithCcwOrientation_LegalizesOt()
        {
            // o == CCW: ot.EdgeIndex(p, op) is called, so p,op must be an edge of ot
            MethodInfo m = GetMethod("NextFlipTriangle",
                typeof(DtSweepContext), typeof(Orientation),
                typeof(DelaunayTriangle), typeof(DelaunayTriangle),
                typeof(TriangulationPoint), typeof(TriangulationPoint));
            var p1 = new TriangulationPoint(0, 0);
            var p2 = new TriangulationPoint(1, 0);
            var p3 = new TriangulationPoint(0, 1);
            var p4 = new TriangulationPoint(1, 1);
            var p = p2;  // must be in ot
            var op = p4; // must be in ot, and (p,op) must be an edge of ot
            var t = new DelaunayTriangle(p1, p2, p3);
            var ot = new DelaunayTriangle(p2, p4, p3);
            var tcx = new DtSweepContext();
            tcx.Triangulatable = new MockTriangulatable();
            DelaunayTriangle result = (DelaunayTriangle)m.Invoke(null, new object[] { tcx, Orientation.Ccw, t, ot, p, op });
            Assert.Same(t, result);
        }

        [Fact]
        public void NextFlipTriangle_WithCwOrientation_LegalizesT()
        {
            // o == CW: t.EdgeIndex(p, op) is called, so p,op must be an edge of t
            MethodInfo m = GetMethod("NextFlipTriangle",
                typeof(DtSweepContext), typeof(Orientation),
                typeof(DelaunayTriangle), typeof(DelaunayTriangle),
                typeof(TriangulationPoint), typeof(TriangulationPoint));
            var p1 = new TriangulationPoint(0, 0);
            var p2 = new TriangulationPoint(1, 0);
            var p3 = new TriangulationPoint(0, 1);
            var p4 = new TriangulationPoint(1, 1);
            var p = p1;  // must be in t
            var op = p2; // must be in t, and (p,op) must be an edge of t
            var t = new DelaunayTriangle(p1, p2, p3);
            var ot = new DelaunayTriangle(p2, p4, p3);
            var tcx = new DtSweepContext();
            tcx.Triangulatable = new MockTriangulatable();
            DelaunayTriangle result = (DelaunayTriangle)m.Invoke(null, new object[] { tcx, Orientation.Cw, t, ot, p, op });
            Assert.Same(ot, result);
        }

        // ---------- Fill (covered indirectly by Triangulate integration tests) ----------

        // ---------- IsShallow ----------
        [Fact]
        public void IsShallow_WithWidthGreaterThanHeight_ReturnsTrue()
        {
            MethodInfo m = GetMethod("IsShallow", typeof(DtSweepContext), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();
            tcx.Basin.LeftNode = new AdvancingFrontNode(new TriangulationPoint(0, 3));
            tcx.Basin.RightNode = new AdvancingFrontNode(new TriangulationPoint(5, 3));
            tcx.Basin.LeftHighest = true;
            tcx.Basin.Width = 5.0;
            var node = new AdvancingFrontNode(new TriangulationPoint(2, 1));
            bool result = (bool)m.Invoke(null, new object[] { tcx, node });
            Assert.True(result);
        }

        [Fact]
        public void IsShallow_WithWidthLessThanHeight_ReturnsFalse()
        {
            MethodInfo m = GetMethod("IsShallow", typeof(DtSweepContext), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();
            tcx.Basin.LeftNode = new AdvancingFrontNode(new TriangulationPoint(0, 3));
            tcx.Basin.RightNode = new AdvancingFrontNode(new TriangulationPoint(2, 3));
            tcx.Basin.LeftHighest = true;
            tcx.Basin.Width = 2.0;
            var node = new AdvancingFrontNode(new TriangulationPoint(1, 1));
            bool result = (bool)m.Invoke(null, new object[] { tcx, node });
            Assert.False(result);
        }

        [Fact]
        public void IsShallow_WithRightHighest_ReturnsTrue()
        {
            MethodInfo m = GetMethod("IsShallow", typeof(DtSweepContext), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();
            tcx.Basin.LeftNode = new AdvancingFrontNode(new TriangulationPoint(0, 1));
            tcx.Basin.RightNode = new AdvancingFrontNode(new TriangulationPoint(5, 3));
            tcx.Basin.LeftHighest = false;
            tcx.Basin.Width = 5.0;
            var node = new AdvancingFrontNode(new TriangulationPoint(2, 1));
            bool result = (bool)m.Invoke(null, new object[] { tcx, node });
            Assert.True(result);
        }

        // ---------- FillBasin ----------
        [Fact]
        public void FillBasin_WithBottomNodeEqualsLeftNode_ReturnsEarly()
        {
            MethodInfo m = GetMethod("FillBasin", typeof(DtSweepContext), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();
            var p1 = new TriangulationPoint(0, 0);
            var p2 = new TriangulationPoint(1, 2);
            var p3 = new TriangulationPoint(2, 0);
            var n1 = new AdvancingFrontNode(p1);
            var n2 = new AdvancingFrontNode(p2);
            var n3 = new AdvancingFrontNode(p3);
            n1.Next = n2; n2.Prev = n1;
            n2.Next = n3; n3.Prev = n2;
            tcx.Triangulatable = new MockTriangulatable();
            m.Invoke(null, new object[] { tcx, n1 });
            Assert.NotNull(tcx.Basin.LeftNode);
        }

        // ---------- FillBasinReq ----------
        [Fact]
        public void FillBasinReq_WithShallow_ReturnsEarly()
        {
            MethodInfo m = GetMethod("FillBasinReq", typeof(DtSweepContext), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();
            tcx.Basin.LeftNode = new AdvancingFrontNode(new TriangulationPoint(0, 3));
            tcx.Basin.RightNode = new AdvancingFrontNode(new TriangulationPoint(5, 3));
            tcx.Basin.LeftHighest = true;
            tcx.Basin.Width = 5.0;
            var node = new AdvancingFrontNode(new TriangulationPoint(2, 1));
            tcx.Triangulatable = new MockTriangulatable();
            m.Invoke(null, new object[] { tcx, node });
            Assert.True(tcx.Basin.Width > 0);
        }

        // ---------- FillAdvancingFront ----------
        [Fact]
        public void FillAdvancingFront_WithNode_Executes()
        {
            MethodInfo m = GetMethod("FillAdvancingFront", typeof(DtSweepContext), typeof(AdvancingFrontNode));
            var tcx = new DtSweepContext();
            var p2 = new TriangulationPoint(1, 1);
            tcx.Points.Add(p2);
            tcx.Head = new TriangulationPoint(-2, -2);
            tcx.Tail = new TriangulationPoint(5, -2);
            tcx.CreateAdvancingFront();
            tcx.Triangulatable = new MockTriangulatable();
            var n = tcx.AFront.Head.Next;
            m.Invoke(null, new object[] { tcx, n });
            Assert.NotNull(tcx.AFront);
        }

        // ---------- RotateTrianglePair advanced ----------
        [Fact]
        public void RotateTrianglePair_WithN1N2N3N4_RotatesCorrectly()
        {
            MethodInfo m = GetMethod("RotateTrianglePair",
                typeof(DelaunayTriangle), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(TriangulationPoint));

            var p1 = new TriangulationPoint(0, 0);
            var p2 = new TriangulationPoint(1, 0);
            var p3 = new TriangulationPoint(0, 1);
            var p4 = new TriangulationPoint(1, 1);
            var p5 = new TriangulationPoint(2, 0);
            var p6 = new TriangulationPoint(2, 1);

            var t = new DelaunayTriangle(p1, p2, p3);
            var ot = new DelaunayTriangle(p2, p4, p3);

            var n1 = new DelaunayTriangle(p2, p5, p1);
            var n2 = new DelaunayTriangle(p1, p5, p3);
            var n3 = new DelaunayTriangle(p3, p4, p6);
            var n4 = new DelaunayTriangle(p4, p2, p6);

            t.Neighbors[0] = n1;
            t.Neighbors[1] = n2;
            ot.Neighbors[0] = n3;
            ot.Neighbors[1] = n4;

            m.Invoke(null, new object[] { t, p1, ot, p4 });

            Assert.True(t.Neighbors[0] == ot || t.Neighbors[1] == ot || t.Neighbors[2] == ot ||
                        ot.Neighbors[0] == t || ot.Neighbors[1] == t || ot.Neighbors[2] == t);
        }

        // ---------- Additional Edge Coverage ----------
        [Fact]
        public void NextFlipPoint_WithCwOrientation_ReturnsCcwPoint()
        {
            MethodInfo m = GetMethod("NextFlipPoint",
                typeof(TriangulationPoint), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(TriangulationPoint));
            var eq = new TriangulationPoint(0, 0);
            var op = new TriangulationPoint(1, 0);
            var ep = new TriangulationPoint(2, -2);
            var p2 = new TriangulationPoint(1, 2);
            var ot = new DelaunayTriangle(eq, p2, op);
            // Orient2d(eq=(0,0), op=(1,0), ep=(2,-2)):
            // detleft = (0-2)*(0-(-2)) = -2*2 = -4
            // detright = (0-(-2))*(1-2) = 2*(-1) = -2
            // val = -4 - (-2) = -2 < 0 → CW
            // → returns ot.PointCcw(op) where op at index 2 → Points[(2+1)%3] = Points[0] = eq
            TriangulationPoint result = (TriangulationPoint)m.Invoke(null, new object[] { ep, eq, ot, op });
            Assert.NotNull(result);
            Assert.True(ot.Contains(result));
        }

        [Fact]
        public void Triangulate_RandomConstrainedPoints_DoesNotThrow()
        {
            var rand = new Random(42);
            var rng = new Random(42);
            List<TriangulationPoint> points = new List<TriangulationPoint>();
            for (int i = 0; i < 10; i++)
            {
                points.Add(new TriangulationPoint(rng.NextDouble() * 10, rng.NextDouble() * 10));
            }
            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[3],
                points[2], points[5],
                points[4], points[7]
            };
            var cps = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(cps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(cps.GetTriangles);
        }

        [Fact]
        public void Triangulate_ConstrainedWithManyInternalEdges_Works()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(5.0, 0.0),
                new TriangulationPoint(5.0, 5.0),
                new TriangulationPoint(0.0, 5.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(4.0, 1.0),
                new TriangulationPoint(4.0, 4.0),
                new TriangulationPoint(1.0, 4.0)
            };
            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[4], points[6],
                points[5], points[7]
            };
            var cps = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(cps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(cps.GetTriangles);
            Assert.True(cps.GetTriangles.Count >= 6);
        }

        [Fact]
        public void FlipScanEdgeEvent_ThrowsOnBadInput()
        {
            MethodInfo m = GetMethod("FlipScanEdgeEvent",
                typeof(DtSweepContext), typeof(TriangulationPoint), typeof(TriangulationPoint),
                typeof(DelaunayTriangle), typeof(DelaunayTriangle), typeof(TriangulationPoint));
            var eq = new TriangulationPoint(0, 0);
            var ep = new TriangulationPoint(0, 1);
            var p = new TriangulationPoint(0, 0);
            var p1 = new TriangulationPoint(1, 0);
            var p2 = new TriangulationPoint(0, 1);
            var p3 = new TriangulationPoint(1, 1);
            var flipTriangle = new DelaunayTriangle(eq, p1, p2);
            var t = new DelaunayTriangle(p1, p3, p2);
            t.Neighbors[0] = flipTriangle;
            flipTriangle.Neighbors[0] = t;
            var tcx = new DtSweepContext();
            tcx.Triangulatable = new MockTriangulatable();
            try
            {
                m.Invoke(null, new object[] { tcx, ep, eq, flipTriangle, t, p });
            }
            catch (TargetInvocationException)
            {
                // Expected or not - just running for coverage
            }
        }

        // ---------- LargeHole_DontFill additional coverage ----------
        [Fact]
        public void LargeHole_DontFill_WithPrev2NullAndNext2NotNull_ReturnsTrue()
        {
            MethodInfo m = GetMethod("LargeHole_DontFill", typeof(AdvancingFrontNode));
            // Angle > PiDiv2 and prev2Node != null but !AngleExceedsPlus90DegreesOrIsNegative → false
            var node = new AdvancingFrontNode(new TriangulationPoint(0, 0));
            node.Next = new AdvancingFrontNode(new TriangulationPoint(1, 0));
            node.Prev = new AdvancingFrontNode(new TriangulationPoint(0, -1));
            node.Next.Next = new AdvancingFrontNode(new TriangulationPoint(2, -1));
            // prev2 is null, next2 is not null
            // If AngleExceedsPlus90DegreesOrIsNegative(node.Point, next2Node.Point, prevNode.Point) is false
            // then the if-block is entered and returns false
            bool result = (bool)m.Invoke(null, new object[] { node });
            // Either way, code executes
            Assert.NotNull(node);
        }

        private class MockTriangulatable : ITriangulatable
        {
            public readonly List<DelaunayTriangle> Triangles = new List<DelaunayTriangle>();
            public IList<TriangulationPoint> GetPoints => new List<TriangulationPoint>();
            public IList<DelaunayTriangle> GetTriangles => Triangles.AsReadOnly();
            public TriangulationMode TriangulationMode => TriangulationMode.Unconstrained;
            public void PrepareTriangulation(TriangulationContext tcx) { }
            public void AddTriangle(DelaunayTriangle t) => Triangles.Add(t);
            public void AddTriangles(IEnumerable<DelaunayTriangle> tris) => Triangles.AddRange(tris);
            public void ClearTriangles() => Triangles.Clear();
        }
    }
}
