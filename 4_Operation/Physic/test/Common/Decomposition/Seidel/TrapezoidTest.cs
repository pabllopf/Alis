// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TrapezoidTest.cs
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
    ///     The trapezoid test class
    /// </summary>
    public class TrapezoidTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with all parameters
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithAllParameters()
        {
            Point leftPoint = new Point(0, 0);
            Point rightPoint = new Point(10, 0);
            Point topP = new Point(0, 10);
            Point topQ = new Point(10, 10);
            Point bottomP = new Point(0, -10);
            Point bottomQ = new Point(10, -10);
            Edge top = new Edge(topP, topQ);
            Edge bottom = new Edge(bottomP, bottomQ);

            Trapezoid trapezoid = new Trapezoid(leftPoint, rightPoint, top, bottom);

            Assert.Equal(leftPoint, trapezoid.LeftPoint);
            Assert.Equal(rightPoint, trapezoid.RightPoint);
            Assert.Equal(top, trapezoid.Top);
            Assert.Equal(bottom, trapezoid.Bottom);
            Assert.True(trapezoid.Inside);
        }

        /// <summary>
        ///     Tests that constructor should initialize neighbors to null
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeNeighborsToNull()
        {
            Point leftPoint = new Point(0, 0);
            Point rightPoint = new Point(10, 0);
            Edge top = new Edge(new Point(0, 10), new Point(10, 10));
            Edge bottom = new Edge(new Point(0, -10), new Point(10, -10));

            Trapezoid trapezoid = new Trapezoid(leftPoint, rightPoint, top, bottom);

            Assert.Null(trapezoid.UpperLeft);
            Assert.Null(trapezoid.UpperRight);
            Assert.Null(trapezoid.LowerLeft);
            Assert.Null(trapezoid.LowerRight);
            Assert.Null(trapezoid.Sink);
        }

        /// <summary>
        ///     Tests that update left should set left neighbors correctly
        /// </summary>
        [Fact]
        public void UpdateLeft_ShouldSetLeftNeighborsCorrectly()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            Trapezoid upperLeft = CreateTestTrapezoid();
            Trapezoid lowerLeft = CreateTestTrapezoid();

            trapezoid.UpdateLeft(upperLeft, lowerLeft);

            Assert.Equal(upperLeft, trapezoid.UpperLeft);
            Assert.Equal(lowerLeft, trapezoid.LowerLeft);
            Assert.Equal(trapezoid, upperLeft.UpperRight);
            Assert.Equal(trapezoid, lowerLeft.LowerRight);
        }

        /// <summary>
        ///     Tests that update right should set right neighbors correctly
        /// </summary>
        [Fact]
        public void UpdateRight_ShouldSetRightNeighborsCorrectly()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            Trapezoid upperRight = CreateTestTrapezoid();
            Trapezoid lowerRight = CreateTestTrapezoid();

            trapezoid.UpdateRight(upperRight, lowerRight);

            Assert.Equal(upperRight, trapezoid.UpperRight);
            Assert.Equal(lowerRight, trapezoid.LowerRight);
            Assert.Equal(trapezoid, upperRight.UpperLeft);
            Assert.Equal(trapezoid, lowerRight.LowerLeft);
        }

        /// <summary>
        ///     Tests that update left with null should not throw exception
        /// </summary>
        [Fact]
        public void UpdateLeft_WithNull_ShouldNotThrowException()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();

            trapezoid.UpdateLeft(null, null);

            Assert.Null(trapezoid.UpperLeft);
            Assert.Null(trapezoid.LowerLeft);
        }

        /// <summary>
        ///     Tests that update right with null should not throw exception
        /// </summary>
        [Fact]
        public void UpdateRight_WithNull_ShouldNotThrowException()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();

            trapezoid.UpdateRight(null, null);

            Assert.Null(trapezoid.UpperRight);
            Assert.Null(trapezoid.LowerRight);
        }

        /// <summary>
        ///     Tests that inside property should default to true
        /// </summary>
        [Fact]
        public void InsideProperty_ShouldDefaultToTrue()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();

            Assert.True(trapezoid.Inside);
        }

        /// <summary>
        ///     Tests that inside property should set and get correctly
        /// </summary>
        [Fact]
        public void InsideProperty_ShouldSetAndGetCorrectly()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();

            trapezoid.Inside = false;

            Assert.False(trapezoid.Inside);
        }


        /// <summary>
        ///     Tests that right point property should set and get correctly
        /// </summary>
        [Fact]
        public void RightPointProperty_ShouldSetAndGetCorrectly()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            Point newRightPoint = new Point(20, 0);

            trapezoid.RightPoint = newRightPoint;

            Assert.Equal(newRightPoint, trapezoid.RightPoint);
        }

        /// <summary>
        ///     Creates the test trapezoid
        /// </summary>
        /// <returns>The trapezoid</returns>
        private Trapezoid CreateTestTrapezoid()
        {
            Point leftPoint = new Point(0, 0);
            Point rightPoint = new Point(10, 0);
            Edge top = new Edge(new Point(0, 10), new Point(10, 10));
            Edge bottom = new Edge(new Point(0, -10), new Point(10, -10));
            return new Trapezoid(leftPoint, rightPoint, top, bottom);
        }

        /// <summary>
        ///     Tests that update left right sets all four neighbors and their反向 pointers
        /// </summary>
        [Fact]
        public void UpdateLeftRight_ShouldSetAllFourNeighbors()
        {
            Trapezoid center = CreateTestTrapezoid();
            Trapezoid ul = CreateTestTrapezoid();
            Trapezoid ll = CreateTestTrapezoid();
            Trapezoid ur = CreateTestTrapezoid();
            Trapezoid lr = CreateTestTrapezoid();

            center.UpdateLeftRight(ul, ll, ur, lr);

            Assert.Equal(ul, center.UpperLeft);
            Assert.Equal(ll, center.LowerLeft);
            Assert.Equal(ur, center.UpperRight);
            Assert.Equal(lr, center.LowerRight);
            // Verify反向 pointers
            Assert.Equal(center, ul.UpperRight);
            Assert.Equal(center, ll.LowerRight);
            Assert.Equal(center, ur.UpperLeft);
            Assert.Equal(center, lr.LowerLeft);
        }

        /// <summary>
        ///     Tests that update left right with null neighbors handles nulls correctly
        /// </summary>
        [Fact]
        public void UpdateLeftRight_WithPartialNulls_HandlesCorrectly()
        {
            Trapezoid center = CreateTestTrapezoid();
            Trapezoid ul = CreateTestTrapezoid();
            // ur, ll, lr are null

            center.UpdateLeftRight(ul, null, null, null);

            Assert.Equal(ul, center.UpperLeft);
            Assert.Null(center.LowerLeft);
            Assert.Null(center.UpperRight);
            Assert.Null(center.LowerRight);
            // ul's UpperRight should point back to center
            Assert.Equal(center, ul.UpperRight);
        }

        /// <summary>
        ///     Tests that trim neighbors with inside=true recursively trims all neighbors
        /// </summary>
        [Fact]
        public void TrimNeighbors_WithInsideTrue_TrimsAllNeighborsRecursively()
        {
            Trapezoid center = CreateTestTrapezoid();
            Trapezoid ul = CreateTestTrapezoid();
            Trapezoid ll = CreateTestTrapezoid();
            Trapezoid ur = CreateTestTrapezoid();
            Trapezoid lr = CreateTestTrapezoid();

            // Give children their own children to test recursion
            Trapezoid ulChild = CreateTestTrapezoid();
            ul.UpdateLeft(ulChild, null);

            center.UpdateLeftRight(ul, ll, ur, lr);

            center.TrimNeighbors();

            // Center should be trimmed
            Assert.False(center.Inside);
            // Children should be trimmed (recursion)
            Assert.False(ul.Inside);
            Assert.False(ll.Inside);
            Assert.False(ur.Inside);
            Assert.False(lr.Inside);
            // Grandchild should also be trimmed
            Assert.False(ulChild.Inside);
        }

        /// <summary>
        ///     Tests that trim neighbors with inside=false does nothing
        /// </summary>
        [Fact]
        public void TrimNeighbors_WithInsideFalse_DoesNothing()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            trapezoid.Inside = false;
            Trapezoid neighbor = CreateTestTrapezoid();
            trapezoid.UpdateLeft(neighbor, null);

            trapezoid.TrimNeighbors();

            // Neither the trapezoid nor its neighbor should be trimmed (Inside stays false)
            Assert.False(trapezoid.Inside);
            Assert.True(neighbor.Inside);
        }

        /// <summary>
        ///     Tests that contains returns true for a point inside the trapezoid
        /// </summary>
        [Fact]
        public void Contains_WithPointInside_ReturnsTrue()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            Point insidePoint = new Point(5, 0); // Between x=0 and x=10, between top and bottom

            bool result = trapezoid.Contains(insidePoint);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that contains returns false for a point outside the trapezoid
        /// </summary>
        [Fact]
        public void Contains_WithPointOutside_ReturnsFalse()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();
            Point outsidePoint = new Point(15, 0); // X beyond right boundary

            bool result = trapezoid.Contains(outsidePoint);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that get vertices returns 4 points forming the trapezoid corners
        /// </summary>
        [Fact]
        public void GetVertices_ShouldReturnFourCorners()
        {
            Trapezoid trapezoid = CreateTestTrapezoid();

            List<Point> verts = trapezoid.GetVertices();

            Assert.Equal(4, verts.Count);
        }

        /// <summary>
        ///     Tests that add points when left point differs from bottom endpoints
        /// </summary>
        [Fact]
        public void AddPoints_WithDistinctEndpoints_AddsToEdges()
        {
            // Create trapezoid where LeftPoint != Bottom.P and LeftPoint != Top.P
            Point leftPoint = new Point(2, 0);
            Point rightPoint = new Point(8, 0);
            Edge top = new Edge(new Point(0, 10), new Point(10, 10));
            Edge bottom = new Edge(new Point(0, -10), new Point(10, -10));
            Trapezoid trapezoid = new Trapezoid(leftPoint, rightPoint, top, bottom);

            // Should not throw — verifies all four if-conditions in AddPoints
            trapezoid.AddPoints();
        }
    }
}