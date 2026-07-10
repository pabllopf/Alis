// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TrapezoidalMapTest.cs
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
using Alis.Core.Physic.Common.Decomposition.Seidel;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The trapezoidal map test class
    /// </summary>
    public class TrapezoidalMapTest
    {
        /// <summary>
        ///     Tests that constructor should initialize empty map
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeEmptyMap()
        {
            TrapezoidalMap map = new TrapezoidalMap();

            Assert.NotNull(map);
            Assert.NotNull(map.Map);
            Assert.Empty(map.Map);
        }

        /// <summary>
        ///     Tests that clear should reset internal state
        /// </summary>
        [Fact]
        public void Clear_ShouldResetInternalState()
        {
            TrapezoidalMap map = new TrapezoidalMap();

            map.Clear();

            Assert.NotNull(map);
        }

        /// <summary>
        ///     Tests that case1 should create four trapezoids
        /// </summary>
        [Fact]
        public void Case1_ShouldCreateFourTrapezoids()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid t = new Trapezoid(p1, p2, new Edge(p4, p3), new Edge(p1, p2));

            Point ep1 = new Point(2, 5);
            Point ep2 = new Point(8, 5);
            Edge edge = new Edge(ep1, ep2);

            Trapezoid[] result = TrapezoidalMap.Case1(t, edge);

            Assert.Equal(4, result.Length);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
            Assert.NotNull(result[2]);
            Assert.NotNull(result[3]);
        }

        /// <summary>
        ///     Tests that case2 should create three trapezoids
        /// </summary>
        [Fact]
        public void Case2_ShouldCreateThreeTrapezoids()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid t = new Trapezoid(p1, p2, new Edge(p4, p3), new Edge(p1, p2));

            Point ep1 = new Point(2, 5);
            Point ep2 = new Point(15, 5);
            Edge edge = new Edge(ep1, ep2);

            Trapezoid[] result = map.Case2(t, edge);

            Assert.Equal(3, result.Length);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
            Assert.NotNull(result[2]);
        }

        /// <summary>
        ///     Tests that case3 should create two trapezoids
        /// </summary>
        [Fact]
        public void Case3_ShouldCreateTwoTrapezoids()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid t = new Trapezoid(p1, p2, new Edge(p4, p3), new Edge(p1, p2));

            Edge edge = new Edge(new Point(0, 5), new Point(10, 5));

            Trapezoid[] result = map.Case3(t, edge);

            Assert.Equal(2, result.Length);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
        }

        /// <summary>
        ///     Tests that case4 should create three trapezoids
        /// </summary>
        [Fact]
        public void Case4_ShouldCreateThreeTrapezoids()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid t = new Trapezoid(p1, p2, new Edge(p4, p3), new Edge(p1, p2));

            Point ep1 = new Point(-5, 5);
            Point ep2 = new Point(8, 5);
            Edge edge = new Edge(ep1, ep2);

            Trapezoid[] result = map.Case4(t, edge);

            Assert.Equal(3, result.Length);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
            Assert.NotNull(result[2]);
        }

        /// <summary>
        ///     Tests that trapezoidal map should be reference type
        /// </summary>
        [Fact]
        public void TrapezoidalMap_ShouldBeReferenceType()
        {
            TrapezoidalMap map1 = new TrapezoidalMap();
            TrapezoidalMap map2 = map1;

            Assert.Same(map1, map2);
        }

        /// <summary>
        ///     Tests that map property should be accessible
        /// </summary>
        [Fact]
        public void MapProperty_ShouldBeAccessible()
        {
            TrapezoidalMap map = new TrapezoidalMap();

            HashSet<Trapezoid> trapezoids = map.Map;

            Assert.NotNull(trapezoids);
        }

        /// <summary>
        ///     Tests that multiple maps should be independent
        /// </summary>
        [Fact]
        public void MultipleMaps_ShouldBeIndependent()
        {
            TrapezoidalMap map1 = new TrapezoidalMap();
            TrapezoidalMap map2 = new TrapezoidalMap();

            Assert.NotSame(map1, map2);
            Assert.NotSame(map1.Map, map2.Map);
        }

        /// <summary>
        ///     Tests that clear should be callable multiple times
        /// </summary>
        [Fact]
        public void Clear_ShouldBeCallableMultipleTimes()
        {
            TrapezoidalMap map = new TrapezoidalMap();

            map.Clear();
            map.Clear();
            map.Clear();

            Assert.NotNull(map);
        }

        // ========================================================================
        // Additional coverage — epsilon branches, chained Case3/Case4, BoundingBox
        // ========================================================================

        /// <summary>
        ///     Tests Case2 when e.Q.X matches t.RightPoint.X (epsilon branch true).
        /// </summary>
        [Fact]
        public void Case2_WhenQEqualsRightPoint_ShouldUseQAsRightPoint()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid t = new Trapezoid(p1, p2, new Edge(p4, p3), new Edge(p1, p2));

            // e.Q.X == t.RightPoint.X (both 10) -> epsilon branch true
            Point ep1 = new Point(2, 5);
            Point ep2 = new Point(10, 5);
            Edge edge = new Edge(ep1, ep2);

            Trapezoid[] result = map.Case2(t, edge);

            Assert.Equal(3, result.Length);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
            Assert.NotNull(result[2]);
        }

        /// <summary>
        ///     Tests Case3 when _cross and _bCross are set (chained from Case2),
        ///     exercising both the _cross == t.Top and _bCross == t.Bottom true branches.
        /// </summary>
        [Fact]
        public void Case3_WhenChainedFromCase2_ShouldUseExistingCross()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid t = new Trapezoid(p1, p2, new Edge(p4, p3), new Edge(p1, p2));

            // First call Case2 to set _cross and _bCross
            Edge edge1 = new Edge(new Point(2, 5), new Point(15, 5));
            Trapezoid[] case2Result = map.Case2(t, edge1);
            // trapezoids[0] has the same Top and Bottom as original t
            // _cross = t.Top, _bCross = t.Bottom

            // Now call Case3 on trapezoids[0] from Case2
            // This should have _cross == trapezoids[0].Top (TRUE) and _bCross == trapezoids[0].Bottom (TRUE)
            Edge edge2 = new Edge(new Point(3, 6), new Point(7, 6));
            Trapezoid[] result = map.Case3(case2Result[0], edge2);

            Assert.Equal(2, result.Length);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
        }

        /// <summary>
        ///     Tests Case3 when epsilon comparisons for left/right points are false
        ///     (edge endpoints don't align with trapezoid left/right boundaries).
        /// </summary>
        [Fact]
        public void Case3_WhenEdgeInsideTrapezoid_ShouldUseTrapezoidPoints()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid t = new Trapezoid(p1, p2, new Edge(p4, p3), new Edge(p1, p2));

            // Edge entirely inside trapezoid: P.X != LeftPoint.X and Q.X != RightPoint.X
            Edge edge = new Edge(new Point(3, 5), new Point(7, 5));

            Trapezoid[] result = map.Case3(t, edge);

            Assert.Equal(2, result.Length);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
        }

        /// <summary>
        ///     Tests Case4 when _cross == t.Top is true (chained from Case2).
        /// </summary>
        [Fact]
        public void Case4_WhenChainedFromCase2_CrossMatch_ShouldUseExistingCross()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid t = new Trapezoid(p1, p2, new Edge(p4, p3), new Edge(p1, p2));

            // First call Case2 to set _cross and _bCross
            Edge edge1 = new Edge(new Point(2, 5), new Point(15, 5));
            Trapezoid[] case2Result = map.Case2(t, edge1);

            // Call Case4 on trapezoids[0] from Case2
            // _cross == trapezoids[0].Top (TRUE), _bCross == trapezoids[0].Bottom (TRUE)
            Edge edge2 = new Edge(new Point(-5, 6), new Point(7, 6));
            Trapezoid[] result = map.Case4(case2Result[0], edge2);

            Assert.Equal(3, result.Length);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
            Assert.NotNull(result[2]);
        }

        /// <summary>
        ///     Tests Case4 when e.P.X == t.LeftPoint.X (epsilon branch true).
        /// </summary>
        [Fact]
        public void Case4_WhenPEqualsLeftPoint_ShouldUsePAsLeftPoint()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid t = new Trapezoid(p1, p2, new Edge(p4, p3), new Edge(p1, p2));

            // e.P.X == t.LeftPoint.X (both 0) -> epsilon branch true
            Point ep1 = new Point(0, 5);
            Point ep2 = new Point(8, 5);
            Edge edge = new Edge(ep1, ep2);

            Trapezoid[] result = map.Case4(t, edge);

            Assert.Equal(3, result.Length);
            Assert.NotNull(result[0]);
            Assert.NotNull(result[1]);
            Assert.NotNull(result[2]);
        }

        /// <summary>
        ///     Tests that BoundingBox creates a trapezoid from multiple edges,
        ///     exercising UpdateMax and UpdateMin branches.
        /// </summary>
        [Fact]
        public void BoundingBox_WithMultipleEdges_ShouldCreateTrapezoid()
        {
            TrapezoidalMap map = new TrapezoidalMap();
            List<Edge> edges = new List<Edge>
            {
                new Edge(new Point(2, 3), new Point(8, 5)),
                new Edge(new Point(1, 6), new Point(9, 2)),
                new Edge(new Point(4, 4), new Point(6, 7))
            };

            Trapezoid result = map.BoundingBox(edges);

            Assert.NotNull(result);
            Assert.NotNull(result.LeftPoint);
            Assert.NotNull(result.RightPoint);
            Assert.NotNull(result.Top);
            Assert.NotNull(result.Bottom);

            // The bounding box should encompass all edge points
            Assert.True(result.LeftPoint.X <= 1.0f); // min X minus margin
            Assert.True(result.RightPoint.X >= 9.0f); // max X plus margin
            Assert.True(result.Bottom.P.Y <= 2.0f); // min Y minus margin
            Assert.True(result.Top.P.Y >= 7.0f); // max Y plus margin
        }
    }
}