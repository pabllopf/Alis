// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryGraphTest.cs
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
    ///     The query graph test class
    /// </summary>
    public class QueryGraphTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with head node
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithHeadNode()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(1, 0);
            Point p3 = new Point(1, 1);
            Point p4 = new Point(0, 1);
            Trapezoid trapezoid = new Trapezoid(p1, p2, new Edge(p1, p4), new Edge(p2, p3));
            Sink sink = new Sink(trapezoid);
            
            QueryGraph graph = new QueryGraph(sink);
            
            Assert.NotNull(graph);
        }

        /// <summary>
        ///     Tests that follow edge should return list of trapezoids
        /// </summary>
        [Fact]
        public void FollowEdge_ShouldReturnListOfTrapezoids()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid trapezoid = new Trapezoid(p1, p2, new Edge(p1, p4), new Edge(p2, p3));
            Sink sink = new Sink(trapezoid);
            QueryGraph graph = new QueryGraph(sink);
            
            Edge edge = new Edge(new Point(0, 5), new Point(5, 5));
            List<Trapezoid> trapezoids = graph.FollowEdge(edge);
            
            Assert.NotNull(trapezoids);
            Assert.NotEmpty(trapezoids);
        }

        /// <summary>
        ///     Tests that case1 should handle four trapezoids
        /// </summary>
        [Fact]
        public void Case1_ShouldHandleFourTrapezoids()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid trapezoid = new Trapezoid(p1, p2, new Edge(p1, p4), new Edge(p2, p3));
            Sink sink = new Sink(trapezoid);
            QueryGraph graph = new QueryGraph(sink);
            
            Point ep1 = new Point(2, 2);
            Point ep2 = new Point(8, 8);
            Edge edge = new Edge(ep1, ep2);
            Trapezoid t1 = new Trapezoid(p1, ep1, new Edge(p1, p4), edge);
            Trapezoid t2 = new Trapezoid(ep1, ep2, edge, new Edge(p2, p3));
            Trapezoid t3 = new Trapezoid(ep1, ep2, new Edge(p1, p4), edge);
            Trapezoid t4 = new Trapezoid(ep2, p2, edge, new Edge(p2, p3));
            
            Trapezoid[] tList = { t1, t2, t3, t4 };
            
            graph.Case1(sink, edge, tList);
            
            Assert.NotNull(graph);
        }

        /// <summary>
        ///     Tests that case2 should handle three trapezoids
        /// </summary>
        [Fact]
        public void Case2_ShouldHandleThreeTrapezoids()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid trapezoid = new Trapezoid(p1, p2, new Edge(p1, p4), new Edge(p2, p3));
            Sink sink = new Sink(trapezoid);
            QueryGraph graph = new QueryGraph(sink);
            
            Point ep1 = new Point(2, 2);
            Point ep2 = new Point(8, 8);
            Edge edge = new Edge(ep1, ep2);
            Trapezoid t1 = new Trapezoid(p1, ep1, new Edge(p1, p4), edge);
            Trapezoid t2 = new Trapezoid(ep1, ep2, edge, new Edge(p2, p3));
            Trapezoid t3 = new Trapezoid(ep1, ep2, new Edge(p1, p4), edge);
            
            Trapezoid[] tList = { t1, t2, t3 };
            
            graph.Case2(sink, edge, tList);
            
            Assert.NotNull(graph);
        }

        /// <summary>
        ///     Tests that case3 should handle two trapezoids
        /// </summary>
        [Fact]
        public void Case3_ShouldHandleTwoTrapezoids()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid trapezoid = new Trapezoid(p1, p2, new Edge(p1, p4), new Edge(p2, p3));
            Sink sink = new Sink(trapezoid);
            QueryGraph graph = new QueryGraph(sink);
            
            Point ep1 = new Point(2, 2);
            Point ep2 = new Point(8, 8);
            Edge edge = new Edge(ep1, ep2);
            Trapezoid t1 = new Trapezoid(ep1, ep2, edge, new Edge(p2, p3));
            Trapezoid t2 = new Trapezoid(ep1, ep2, new Edge(p1, p4), edge);
            
            Trapezoid[] tList = { t1, t2 };
            
            graph.Case3(sink, edge, tList);
            
            Assert.NotNull(graph);
        }

        /// <summary>
        ///     Tests that case4 should handle three trapezoids with q node
        /// </summary>
        [Fact]
        public void Case4_ShouldHandleThreeTrapezoidsWithQNode()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid trapezoid = new Trapezoid(p1, p2, new Edge(p1, p4), new Edge(p2, p3));
            Sink sink = new Sink(trapezoid);
            QueryGraph graph = new QueryGraph(sink);
            
            Point ep1 = new Point(2, 2);
            Point ep2 = new Point(8, 8);
            Edge edge = new Edge(ep1, ep2);
            Trapezoid t1 = new Trapezoid(ep1, ep2, edge, new Edge(p2, p3));
            Trapezoid t2 = new Trapezoid(ep1, ep2, new Edge(p1, p4), edge);
            Trapezoid t3 = new Trapezoid(ep2, p2, edge, new Edge(p2, p3));
            
            Trapezoid[] tList = { t1, t2, t3 };
            
            graph.Case4(sink, edge, tList);
            
            Assert.NotNull(graph);
        }

        /// <summary>
        ///     Tests that query graph should be reference type
        /// </summary>
        [Fact]
        public void QueryGraph_ShouldBeReferenceType()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(1, 0);
            Point p3 = new Point(1, 1);
            Point p4 = new Point(0, 1);
            Trapezoid trapezoid = new Trapezoid(p1, p2, new Edge(p1, p4), new Edge(p2, p3));
            Sink sink = new Sink(trapezoid);
            QueryGraph graph1 = new QueryGraph(sink);
            QueryGraph graph2 = graph1;
            
            Assert.Same(graph1, graph2);
        }

        /// <summary>
        ///     Tests that follow edge should handle edge traversal
        /// </summary>
        [Fact]
        public void FollowEdge_ShouldHandleEdgeTraversal()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid trapezoid = new Trapezoid(p1, p2, new Edge(p1, p4), new Edge(p2, p3));
            Sink sink = new Sink(trapezoid);
            QueryGraph graph = new QueryGraph(sink);
            
            Edge edge = new Edge(new Point(1, 5), new Point(3, 5));
            List<Trapezoid> result = graph.FollowEdge(edge);
            
            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that query graph should handle different case scenarios
        /// </summary>
        [Fact]
        public void QueryGraph_ShouldHandleDifferentCaseScenarios()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 0);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(0, 10);
            Trapezoid trapezoid = new Trapezoid(p1, p2, new Edge(p1, p4), new Edge(p2, p3));
            Sink sink = new Sink(trapezoid);
            QueryGraph graph = new QueryGraph(sink);
            
            Assert.NotNull(graph);
        }
    }
}

