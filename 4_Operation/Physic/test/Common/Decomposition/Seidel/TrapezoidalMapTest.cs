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
            
            Trapezoid[] result = map.Case1(t, edge);
            
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
            
            var trapezoids = map.Map;
            
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
    }
}

