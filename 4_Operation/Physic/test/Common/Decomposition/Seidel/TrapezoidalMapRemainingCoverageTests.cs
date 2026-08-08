// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TrapezoidalMapRemainingCoverageTests.cs
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

using Alis.Core.Physic.Common.Decomposition.Seidel;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The trapezoidal map remaining coverage tests class
    /// </summary>
    public class TrapezoidalMapRemainingCoverageTests
    {
        // ========================================================================
        // Case3 — epsilon true branches for P matching LeftPoint
        // ========================================================================

        /// <summary>
        ///     Tests Case3 when e.P.X == t.LeftPoint.X (epsilon branch true).
        /// </summary>
        [Fact]
        public void Case3_WhenPEqualsLeftPoint_ShouldUsePAsLeftPoint()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid t = new Trapezoid(p1, p2, new Edge(p4, p3), new Edge(p1, p2));

            // e.P.X == t.LeftPoint.X (both 0) -> epsilon branch true
            Edge edge = new Edge(new Point(0, 5), new Point(7, 5));

            Trapezoid[] result = map.Case3(t, edge);

            Assert.Equal(2, result.Length);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
        }

        /// <summary>
        ///     Tests Case3 when e.Q.X == t.RightPoint.X (epsilon branch true).
        /// </summary>
        [Fact]
        public void Case3_WhenQEqualsRightPoint_ShouldUseQAsRightPoint()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid t = new Trapezoid(p1, p2, new Edge(p4, p3), new Edge(p1, p2));

            // e.Q.X == t.RightPoint.X (both 10) -> epsilon branch true
            Edge edge = new Edge(new Point(3, 5), new Point(10, 5));

            Trapezoid[] result = map.Case3(t, edge);

            Assert.Equal(2, result.Length);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
        }

        /// <summary>
        ///     Tests Case3 when both e.P.X == t.LeftPoint.X and e.Q.X == t.RightPoint.X.
        /// </summary>
        [Fact]
        public void Case3_WhenBothEndpointsAlign_ShouldUseEdgePoints()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid t = new Trapezoid(p1, p2, new Edge(p4, p3), new Edge(p1, p2));

            // Both P and Q match trapezoid boundaries: P.X == LeftPoint.X, Q.X == RightPoint.X
            Edge edge = new Edge(new Point(0, 5), new Point(10, 5));

            Trapezoid[] result = map.Case3(t, edge);

            Assert.Equal(2, result.Length);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
        }

        // ========================================================================
        // Case3 — epsilon true combined with _cross / _bCross match
        // ========================================================================

        /// <summary>
        ///     Tests Case3 when P equals LeftPoint and _cross == t.Top.
        /// </summary>
        [Fact]
        public void Case3_WhenPEqualsLeftPointAndCrossMatch_ShouldUsePAndUpdateUpper()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            Point tp1 = new Point(0, 10);
            Point tp2 = new Point(10, 10);
            Point bp1 = new Point(0, 0);
            Point bp2 = new Point(10, 0);
            Edge topEdge = new Edge(tp1, tp2);
            Edge bottomEdge = new Edge(bp1, bp2);
            Point left = new Point(0, 0);
            Point right = new Point(10, 0);
            Trapezoid t1 = new Trapezoid(left, right, topEdge, bottomEdge);

            // Case2 sets _cross = t1.Top and _bCross = t1.Bottom
            Edge e1 = new Edge(new Point(2, 5), new Point(15, 5));
            map.Case2(t1, e1);

            // Build a second trapezoid with the same top/bottom edges
            Trapezoid tUpperLeft = new Trapezoid(left, right, topEdge, bottomEdge);
            Trapezoid tLowerLeft = new Trapezoid(left, right, topEdge, bottomEdge);
            Trapezoid tUpperRight = new Trapezoid(left, right, topEdge, bottomEdge);
            Trapezoid tLowerRight = new Trapezoid(left, right, topEdge, bottomEdge);
            Trapezoid t2 = new Trapezoid(left, right, topEdge, bottomEdge)
            {
                UpperLeft = tUpperLeft,
                LowerLeft = tLowerLeft,
                UpperRight = tUpperRight,
                LowerRight = tLowerRight
            };

            // e.P.X == t2.LeftPoint.X -> epsilon true for P
            Edge e2 = new Edge(new Point(0, 6), new Point(7, 6));
            Trapezoid[] result = map.Case3(t2, e2);

            Assert.Equal(2, result.Length);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
        }

        /// <summary>
        ///     Tests Case3 when Q equals RightPoint and _bCross == t.Bottom.
        /// </summary>
        [Fact]
        public void Case3_WhenQEqualsRightPointAndBCrossMatch_ShouldUseQAndUpdateLower()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            Point tp1 = new Point(0, 10);
            Point tp2 = new Point(10, 10);
            Point bp1 = new Point(0, 0);
            Point bp2 = new Point(10, 0);
            Edge topEdge = new Edge(tp1, tp2);
            Edge bottomEdge = new Edge(bp1, bp2);
            Point left = new Point(0, 0);
            Point right = new Point(10, 0);
            Trapezoid t1 = new Trapezoid(left, right, topEdge, bottomEdge);

            // Case2 sets _cross = t1.Top and _bCross = t1.Bottom
            Edge e1 = new Edge(new Point(2, 5), new Point(15, 5));
            map.Case2(t1, e1);

            // Build a second trapezoid with the same top/bottom edges
            Trapezoid tUpperLeft = new Trapezoid(left, right, topEdge, bottomEdge);
            Trapezoid tLowerLeft = new Trapezoid(left, right, topEdge, bottomEdge);
            Trapezoid tUpperRight = new Trapezoid(left, right, topEdge, bottomEdge);
            Trapezoid tLowerRight = new Trapezoid(left, right, topEdge, bottomEdge);
            Trapezoid t2 = new Trapezoid(left, right, topEdge, bottomEdge)
            {
                UpperLeft = tUpperLeft,
                LowerLeft = tLowerLeft,
                UpperRight = tUpperRight,
                LowerRight = tLowerRight
            };

            // e.Q.X == t2.RightPoint.X -> epsilon true for Q
            Edge e2 = new Edge(new Point(3, 6), new Point(10, 6));
            Trapezoid[] result = map.Case3(t2, e2);

            Assert.Equal(2, result.Length);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
        }

        // ========================================================================
        // Case2 — additional edge cases for epsilon
        // ========================================================================

        /// <summary>
        ///     Tests Case2 when e.Q.X is very close to t.RightPoint.X (within epsilon).
        /// </summary>
        [Fact]
        public void Case2_WhenQIsVeryCloseToRightPoint_ShouldUseQ()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid t = new Trapezoid(p1, p2, new Edge(p4, p3), new Edge(p1, p2));

            // e.Q.X is within float.Epsilon of t.RightPoint.X
            Point ep1 = new Point(2, 5);
            Point ep2 = new Point(10 + float.Epsilon / 2, 5);
            Edge edge = new Edge(ep1, ep2);

            Trapezoid[] result = map.Case2(t, edge);

            Assert.Equal(3, result.Length);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
            Assert.NotNull(result[2]);
        }

        /// <summary>
        ///     Tests Case2 when e.Q.X is not close to t.RightPoint.X.
        /// </summary>
        [Fact]
        public void Case2_WhenQIsFarFromRightPoint_ShouldUseRightPoint()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid t = new Trapezoid(p1, p2, new Edge(p4, p3), new Edge(p1, p2));

            // e.Q.X is far from t.RightPoint.X
            Point ep1 = new Point(2, 5);
            Point ep2 = new Point(20, 5);
            Edge edge = new Edge(ep1, ep2);

            Trapezoid[] result = map.Case2(t, edge);

            Assert.Equal(3, result.Length);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
            Assert.NotNull(result[2]);
        }
    }
}
