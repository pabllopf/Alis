using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Alis.Core.Physic.Common.Decomposition.CDT.Sets;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    public class DTSweepFinalBranchCoverageTests
    {
        private static AdvancingFront CreateFront(params AdvancingFrontNode[] nodes)
        {
            AdvancingFront front = new AdvancingFront(nodes[0], nodes[nodes.Length - 1]);
            for (int i = 0; i < nodes.Length - 1; i++)
            {
                nodes[i].Next = nodes[i + 1];
                nodes[i + 1].Prev = nodes[i];
            }

            return front;
        }

        private static DelaunayTriangle CreateDecoyTriangle(double offset)
        {
            return new DelaunayTriangle(
                new TriangulationPoint(100 + offset, 0),
                new TriangulationPoint(101 + offset, 0),
                new TriangulationPoint(100 + offset, 1));
        }

        [Fact]
        public void EdgeEvent_FirstCollinearPointOutsideTriangle_Throws()
        {
            TriangulationPoint a = new TriangulationPoint(0, 0);
            TriangulationPoint b = new TriangulationPoint(1, 0);
            TriangulationPoint c = new TriangulationPoint(0, 1);
            DelaunayTriangle triangle = new DelaunayTriangle(a, b, c);
            DtSweepContext context = new DtSweepContext();

            Assert.Throws<PointOnEdgeException>(() =>
                DtSweep.EdgeEvent(context, new TriangulationPoint(2, 0), new TriangulationPoint(3, 0), triangle, a));
        }

        [Fact]
        public void EdgeEvent_SecondCollinearPointOutsideTriangle_Throws()
        {
            TriangulationPoint a = new TriangulationPoint(0, 0);
            TriangulationPoint b = new TriangulationPoint(1, 1);
            TriangulationPoint c = new TriangulationPoint(0, 1);
            DelaunayTriangle triangle = new DelaunayTriangle(a, b, c);
            DtSweepContext context = new DtSweepContext();

            Assert.Throws<PointOnEdgeException>(() =>
                DtSweep.EdgeEvent(context, new TriangulationPoint(0, 2), new TriangulationPoint(0, 3), triangle, a));
        }

        [Fact]
        public void AngleExceeds90Degrees_ClockwiseTurn_ReturnsTrue()
        {
            bool result = DtSweep.AngleExceeds90Degrees(
                new TriangulationPoint(0, 0),
                new TriangulationPoint(1, 0),
                new TriangulationPoint(1, -1));

            Assert.True(result);
        }

        [Fact]
        public void LargeHole_DontFill_NextSecondNodeFormsValidAngle_ReturnsFalse()
        {
            AdvancingFrontNode prev2 = new AdvancingFrontNode(new TriangulationPoint(-2, -2));
            AdvancingFrontNode prev = new AdvancingFrontNode(new TriangulationPoint(0, -1));
            AdvancingFrontNode node = new AdvancingFrontNode(new TriangulationPoint(0, 0));
            AdvancingFrontNode next = new AdvancingFrontNode(new TriangulationPoint(1, 0));
            AdvancingFrontNode next2 = new AdvancingFrontNode(new TriangulationPoint(-1, 0));

            prev.Prev = prev2;
            node.Prev = prev;
            node.Next = next;
            next.Next = next2;

            Assert.False(DtSweep.LargeHole_DontFill(node));
        }

        [Fact]
        public void LargeHole_DontFill_PrevSecondNodeFormsValidAngle_ReturnsFalse()
        {
            AdvancingFrontNode prev2 = new AdvancingFrontNode(new TriangulationPoint(0, 1));
            AdvancingFrontNode prev = new AdvancingFrontNode(new TriangulationPoint(0, -1));
            AdvancingFrontNode node = new AdvancingFrontNode(new TriangulationPoint(0, 0));
            AdvancingFrontNode next = new AdvancingFrontNode(new TriangulationPoint(1, 0));

            prev.Prev = prev2;
            node.Prev = prev;
            node.Next = next;

            Assert.False(DtSweep.LargeHole_DontFill(node));
        }

        [Fact]
        public void FillAdvancingFront_NextNodeIsLeaf_SkipsBasinFill()
        {
            AdvancingFrontNode prev = new AdvancingFrontNode(new TriangulationPoint(-1, 0));
            AdvancingFrontNode node = new AdvancingFrontNode(new TriangulationPoint(0, 0));
            AdvancingFrontNode next = new AdvancingFrontNode(new TriangulationPoint(1, 0));

            node.Prev = prev;
            node.Next = next;

            DtSweep.FillAdvancingFront(new DtSweepContext(), node);

            Assert.Same(next, node.Next);
            Assert.Null(next.Next);
        }

        [Fact]
        public void FillAdvancingFront_NextIsClearedWhileFillingPrev_SkipsBasinFill()
        {
            AdvancingFrontNode prevPrev = new AdvancingFrontNode(new TriangulationPoint(0, -1));
            AdvancingFrontNode prev = new AdvancingFrontNode(new TriangulationPoint(0, 0));
            AdvancingFrontNode node = new AdvancingFrontNode(new TriangulationPoint(1, 0));
            AdvancingFrontNode next = new AdvancingFrontNode(new TriangulationPoint(-1, 0));

            node.Prev = prev;
            node.Next = next;
            prev.Next = node;
            prev.Prev = prevPrev;
            prevPrev.Next = prev;
            prev.Triangle = CreateDecoyTriangle(10);
            prevPrev.Triangle = CreateDecoyTriangle(20);

            DtSweepContext context = new DtSweepContext
            {
                AFront = CreateFront(
                    new AdvancingFrontNode(next.Point),
                    new AdvancingFrontNode(prevPrev.Point),
                    new AdvancingFrontNode(prev.Point),
                    new AdvancingFrontNode(node.Point),
                    new AdvancingFrontNode(new TriangulationPoint(1000000, 0)))
            };

            MutatingLogger logger = new MutatingLogger(() => node.Next = null);
            Logger.SetDefaultLogger(logger);
            try
            {
                DtSweep.FillAdvancingFront(context, node);
            }
            finally
            {
                Logger.SetDefaultLogger(null);
            }

            Assert.Null(node.Next);
            Assert.Same(prevPrev, node.Prev);
        }

        [Fact]
        public void FillBasin_LeftNodeIsCcwAndBottom_ReturnsWithoutRightNode()
        {
            AdvancingFrontNode node = new AdvancingFrontNode(new TriangulationPoint(0, 0));
            AdvancingFrontNode next = new AdvancingFrontNode(new TriangulationPoint(0, 1));
            AdvancingFrontNode next2 = new AdvancingFrontNode(new TriangulationPoint(-1, 0));
            node.Next = next;
            next.Next = next2;

            DtSweepContext context = new DtSweepContext();
            context.AFront = new AdvancingFront(node, next2);

            DtSweep.FillBasin(context, node);

            Assert.Same(node, context.Basin.LeftNode);
            Assert.Same(node, context.Basin.BottomNode);
            Assert.Null(context.Basin.RightNode);
        }

        [Fact]
        public void FinalizationConvexHull_TailTriangleMissesNeighbors_FinalizesMesh()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(2, 0),
                new TriangulationPoint(1, 2)
            };
            PointSet pointSet = new PointSet(points);
            DtSweepContext context = new DtSweepContext();
            context.PrepareTriangulation(pointSet);
            context.CreateAdvancingFront();

            AdvancingFrontNode middle = context.AFront.Head.Next;
            middle.Triangle = new DelaunayTriangle(
                middle.Point,
                context.AFront.Head.Point,
                new TriangulationPoint(9, 9));

            DtSweep.FinalizationConvexHull(context);

            Assert.Single(pointSet.GetTriangles);
        }

        [Fact]
        public void FlipEdgeEvent_WhenPointDoesNotMatchEndPoint_RecursesUntilConstrainedEdge()
        {
            TriangulationPoint a = new TriangulationPoint(0, 0);
            TriangulationPoint b = new TriangulationPoint(3, 0);
            TriangulationPoint c = new TriangulationPoint(1, 2);
            TriangulationPoint d = new TriangulationPoint(2, 3);
            TriangulationPoint sentinel = new TriangulationPoint(4, 4);

            DelaunayTriangle triangle = new DelaunayTriangle(a, b, c);
            DelaunayTriangle opposite = new DelaunayTriangle(c, b, d);
            DelaunayTriangle rotatedNeighbor = new DelaunayTriangle(c, d, new TriangulationPoint(6, 6));
            triangle.Neighbors[0] = opposite;
            triangle.Neighbors[1] = rotatedNeighbor;
            opposite.EdgeIsConstrained[1] = true;

            DtSweepContext context = new DtSweepContext();
            context.AFront = CreateFront(
                new AdvancingFrontNode(a),
                new AdvancingFrontNode(c),
                new AdvancingFrontNode(d),
                new AdvancingFrontNode(b),
                new AdvancingFrontNode(sentinel));

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                DtSweep.FlipEdgeEvent(context, a, new TriangulationPoint(5, 0), triangle, a));

            Assert.Equal("Intersecting Constraints", exception.Message);
        }

        [Fact]
        public void FillBasinReq_NextIsRightNodeAndOrientationCcw_Returns()
        {
            AdvancingFrontNode prevPrev = new AdvancingFrontNode(new TriangulationPoint(-1, 2));
            AdvancingFrontNode prev = new AdvancingFrontNode(new TriangulationPoint(0, 1));
            AdvancingFrontNode node = new AdvancingFrontNode(new TriangulationPoint(0.5, 0));
            AdvancingFrontNode right = new AdvancingFrontNode(new TriangulationPoint(2, 10));
            AdvancingFrontNode sentinel = new AdvancingFrontNode(new TriangulationPoint(3, 20));
            AdvancingFrontNode left = new AdvancingFrontNode(new TriangulationPoint(4, 4));

            prev.Prev = prevPrev;
            prev.Triangle = CreateDecoyTriangle(10);
            node.Triangle = CreateDecoyTriangle(20);

            DtSweepContext context = new DtSweepContext
            {
                AFront = CreateFront(prevPrev, prev, node, right, sentinel)
            };
            context.Basin.LeftNode = left;
            context.Basin.RightNode = right;
            context.Basin.Width = 1;

            DtSweep.FillBasinReq(context, node);

            Assert.Same(right, node.Next);
        }

        [Fact]
        public void FillBasinReq_NextIsRightNodeAndOrientationNotCcw_MovesToPrev()
        {
            AdvancingFrontNode prevPrev = new AdvancingFrontNode(new TriangulationPoint(-1, 17));
            AdvancingFrontNode prev = new AdvancingFrontNode(new TriangulationPoint(0, 8));
            AdvancingFrontNode node = new AdvancingFrontNode(new TriangulationPoint(1, 0));
            AdvancingFrontNode right = new AdvancingFrontNode(new TriangulationPoint(2, 10));
            AdvancingFrontNode sentinel = new AdvancingFrontNode(new TriangulationPoint(3, 20));
            AdvancingFrontNode left = new AdvancingFrontNode(new TriangulationPoint(4, 4));

            prev.Prev = prevPrev;
            prev.Triangle = CreateDecoyTriangle(10);
            node.Triangle = CreateDecoyTriangle(20);

            DtSweepContext context = new DtSweepContext
            {
                AFront = CreateFront(prevPrev, prev, node, right, sentinel)
            };
            context.Basin.LeftNode = left;
            context.Basin.RightNode = right;
            context.Basin.Width = 3;

            DtSweep.FillBasinReq(context, node);

            Assert.Same(right, prev.Next);
            Assert.Same(prevPrev, prev.Prev);
        }

        [Fact]
        public void FillBasinReq_NodeOutsideBoundariesAndPrevNotLower_MovesToNext()
        {
            AdvancingFrontNode prev = new AdvancingFrontNode(new TriangulationPoint(-1, 9));
            AdvancingFrontNode node = new AdvancingFrontNode(new TriangulationPoint(0, 0));
            AdvancingFrontNode next = new AdvancingFrontNode(new TriangulationPoint(1, 8));
            AdvancingFrontNode right = new AdvancingFrontNode(new TriangulationPoint(2, 10));
            AdvancingFrontNode sentinel = new AdvancingFrontNode(new TriangulationPoint(3, 20));
            AdvancingFrontNode left = new AdvancingFrontNode(new TriangulationPoint(4, 4));

            prev.Triangle = CreateDecoyTriangle(10);
            node.Triangle = CreateDecoyTriangle(20);

            DtSweepContext context = new DtSweepContext
            {
                AFront = CreateFront(prev, node, next, right, sentinel)
            };
            context.Basin.LeftNode = left;
            context.Basin.RightNode = right;
            context.Basin.Width = 3;

            DtSweep.FillBasinReq(context, node);

            Assert.Same(next, prev.Next);
            Assert.Same(prev, next.Prev);
        }

        private sealed class MutatingLogger : ILogger
        {
            private readonly Action _onLog;

            public MutatingLogger(Action onLog) => _onLog = onLog;

            public string Name => nameof(MutatingLogger);

            public void LogTrace(string message)
            {
            }

            public void LogDebug(string message)
            {
            }

            public void LogInfo(string message) => _onLog();

            public void LogWarning(string message)
            {
            }

            public void LogError(string message)
            {
            }

            public void LogError(string message, Exception exception)
            {
            }

            public void LogCritical(string message)
            {
            }

            public void LogCritical(string message, Exception exception)
            {
            }

            public void Log(LogLevel level, string message)
            {
            }

            public void Log(LogLevel level, string message, Exception exception)
            {
            }

            public void LogStructured(LogLevel level, string message, IReadOnlyDictionary<string, object> properties)
            {
            }

            public void SetCorrelationId(string correlationId)
            {
            }

            public string GetCorrelationId() => null;

            public IDisposable BeginScope(object scope) => new NoOpScope();

            public bool IsEnabled(LogLevel level) => true;

            private sealed class NoOpScope : IDisposable
            {
                public void Dispose()
                {
                }
            }
        }
    }
}
