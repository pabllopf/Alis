// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EdgeTest.cs
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
    ///     The edge test class
    /// </summary>
    public class EdgeTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with two points
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithTwoPoints()
        {
            Point p = new Point(0, 0);
            Point q = new Point(10, 10);
            
            Edge edge = new Edge(p, q);
            
            Assert.Equal(p, edge.P);
            Assert.Equal(q, edge.Q);
            Assert.NotNull(edge.MPoints);
            Assert.Null(edge.Above);
            Assert.Null(edge.Below);
        }

        /// <summary>
        ///     Tests that constructor should calculate slope correctly
        /// </summary>
        [Fact]
        public void Constructor_ShouldCalculateSlopeCorrectly()
        {
            Point p = new Point(0, 0);
            Point q = new Point(10, 5);
            
            Edge edge = new Edge(p, q);
            
            Assert.Equal(0.5f, edge.Slope);
        }

        /// <summary>
        ///     Tests that constructor should handle vertical edge
        /// </summary>
        [Fact]
        public void Constructor_ShouldHandleVerticalEdge()
        {
            Point p = new Point(5, 0);
            Point q = new Point(5, 10);
            
            Edge edge = new Edge(p, q);
            
            Assert.Equal(0, edge.Slope);
        }

        /// <summary>
        ///     Tests that constructor should add both points to mpoints
        /// </summary>
        [Fact]
        public void Constructor_ShouldAddBothPointsToMPoints()
        {
            Point p = new Point(0, 0);
            Point q = new Point(10, 10);
            
            Edge edge = new Edge(p, q);
            
            Assert.Contains(p, edge.MPoints);
            Assert.Contains(q, edge.MPoints);
        }

        /// <summary>
        ///     Tests that is above should return true when point below edge
        /// </summary>
        [Fact]
        public void IsAbove_ShouldReturnTrue_WhenPointBelowEdge()
        {
            Point p = new Point(0, 0);
            Point q = new Point(10, 10);
            Edge edge = new Edge(p, q);
            Point testPoint = new Point(5, 3);
            
            bool isAbove = edge.IsAbove(testPoint);
            
            Assert.True(isAbove);
        }

        /// <summary>
        ///     Tests that is below should return true when point above edge
        /// </summary>
        [Fact]
        public void IsBelow_ShouldReturnTrue_WhenPointAboveEdge()
        {
            Point p = new Point(0, 0);
            Point q = new Point(10, 10);
            Edge edge = new Edge(p, q);
            Point testPoint = new Point(5, 7);
            
            bool isBelow = edge.IsBelow(testPoint);
            
            Assert.True(isBelow);
        }

        /// <summary>
        ///     Tests that add mpoint should add new point to collection
        /// </summary>
        [Fact]
        public void AddMpoint_ShouldAddNewPointToCollection()
        {
            Point p = new Point(0, 0);
            Point q = new Point(10, 10);
            Edge edge = new Edge(p, q);
            Point newPoint = new Point(5, 5);
            
            edge.AddMpoint(newPoint);
            
            Assert.Contains(newPoint, edge.MPoints);
        }

        /// <summary>
        ///     Tests that add mpoint should not add duplicate point
        /// </summary>
        [Fact]
        public void AddMpoint_ShouldNotAddDuplicatePoint()
        {
            Point p = new Point(0, 0);
            Point q = new Point(10, 10);
            Edge edge = new Edge(p, q);
            Point duplicatePoint = new Point(0, 0);
            
            int initialCount = edge.MPoints.Count;
            edge.AddMpoint(duplicatePoint);
            
            Assert.Equal(initialCount, edge.MPoints.Count);
        }
        
        /// <summary>
        ///     Tests that edge should calculate b intercept correctly
        /// </summary>
        [Fact]
        public void Edge_ShouldCalculateBInterceptCorrectly()
        {
            Point p = new Point(0, 5);
            Point q = new Point(10, 15);
            
            Edge edge = new Edge(p, q);
            
            Assert.Equal(5.0f, edge.B);
        }

        /// <summary>
        ///     Tests that edge should handle horizontal line
        /// </summary>
        [Fact]
        public void Edge_ShouldHandleHorizontalLine()
        {
            Point p = new Point(0, 5);
            Point q = new Point(10, 5);
            
            Edge edge = new Edge(p, q);
            
            Assert.Equal(0.0f, edge.Slope);
        }

        /// <summary>
        ///     Tests that edge should handle negative slope
        /// </summary>
        [Fact]
        public void Edge_ShouldHandleNegativeSlope()
        {
            Point p = new Point(0, 10);
            Point q = new Point(10, 0);
            
            Edge edge = new Edge(p, q);
            
            Assert.True(edge.Slope < 0);
        }
    }
}

