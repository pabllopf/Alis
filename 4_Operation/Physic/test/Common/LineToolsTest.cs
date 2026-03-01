// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LineToolsTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Common
{
    /// <summary>
    ///     The line tools test class
    /// </summary>
    public class LineToolsTest
    {
        /// <summary>
        ///     Tests that distance between point and line segment should return zero when point on line
        /// </summary>
        [Fact]
        public void DistanceBetweenPointAndLineSegment_ShouldReturnZero_WhenPointOnLine()
        {
            Vector2F point = new Vector2F(5, 5);
            Vector2F start = new Vector2F(0, 0);
            Vector2F end = new Vector2F(10, 10);
            
            float distance = LineTools.DistanceBetweenPointAndLineSegment(ref point, ref start, ref end);
            
            Assert.True(distance < 0.01f);
        }

        /// <summary>
        ///     Tests that distance between point and line segment should return distance to start when before segment
        /// </summary>
        [Fact]
        public void DistanceBetweenPointAndLineSegment_ShouldReturnDistanceToStart_WhenBeforeSegment()
        {
            Vector2F point = new Vector2F(-5, 0);
            Vector2F start = new Vector2F(0, 0);
            Vector2F end = new Vector2F(10, 0);
            
            float distance = LineTools.DistanceBetweenPointAndLineSegment(ref point, ref start, ref end);
            
            Assert.Equal(5.0f, distance);
        }

        /// <summary>
        ///     Tests that distance between point and line segment should return distance to end when after segment
        /// </summary>
        [Fact]
        public void DistanceBetweenPointAndLineSegment_ShouldReturnDistanceToEnd_WhenAfterSegment()
        {
            Vector2F point = new Vector2F(15, 0);
            Vector2F start = new Vector2F(0, 0);
            Vector2F end = new Vector2F(10, 0);
            
            float distance = LineTools.DistanceBetweenPointAndLineSegment(ref point, ref start, ref end);
            
            Assert.Equal(5.0f, distance);
        }

        /// <summary>
        ///     Tests that distance between point and line segment should handle same start and end
        /// </summary>
        [Fact]
        public void DistanceBetweenPointAndLineSegment_ShouldHandleSameStartAndEnd()
        {
            Vector2F point = new Vector2F(5, 5);
            Vector2F start = new Vector2F(0, 0);
            Vector2F end = new Vector2F(0, 0);
            
            float distance = LineTools.DistanceBetweenPointAndLineSegment(ref point, ref start, ref end);
            
            Assert.True(distance > 0);
        }

        /// <summary>
        ///     Tests that line intersect 2 should return true when lines cross
        /// </summary>
        [Fact]
        public void LineIntersect2_ShouldReturnTrue_WhenLinesCross()
        {
            Vector2F a0 = new Vector2F(0, 0);
            Vector2F a1 = new Vector2F(10, 10);
            Vector2F b0 = new Vector2F(0, 10);
            Vector2F b1 = new Vector2F(10, 0);
            
            bool intersects = LineTools.LineIntersect2(ref a0, ref a1, ref b0, ref b1, out Vector2F intersection);
            
            Assert.True(intersects);
            Assert.True(intersection.X > 0 && intersection.Y > 0);
        }

        /// <summary>
        ///     Tests that line intersect 2 should return false when lines dont cross
        /// </summary>
        [Fact]
        public void LineIntersect2_ShouldReturnFalse_WhenLinesDontCross()
        {
            Vector2F a0 = new Vector2F(0, 0);
            Vector2F a1 = new Vector2F(5, 0);
            Vector2F b0 = new Vector2F(0, 10);
            Vector2F b1 = new Vector2F(5, 10);
            
            bool intersects = LineTools.LineIntersect2(ref a0, ref a1, ref b0, ref b1, out Vector2F intersection);
            
            Assert.False(intersects);
        }

        /// <summary>
        ///     Tests that line intersect 2 should return false when lines share endpoint
        /// </summary>
        [Fact]
        public void LineIntersect2_ShouldReturnFalse_WhenLinesShareEndpoint()
        {
            Vector2F a0 = new Vector2F(0, 0);
            Vector2F a1 = new Vector2F(10, 10);
            Vector2F b0 = new Vector2F(0, 0);
            Vector2F b1 = new Vector2F(10, 0);
            
            bool intersects = LineTools.LineIntersect2(ref a0, ref a1, ref b0, ref b1, out Vector2F intersection);
            
            Assert.False(intersects);
        }

        /// <summary>
        ///     Tests that line intersect with vectors should return intersection point
        /// </summary>
        [Fact]
        public void LineIntersect_WithVectors_ShouldReturnIntersectionPoint()
        {
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(10, 10);
            Vector2F q1 = new Vector2F(0, 10);
            Vector2F q2 = new Vector2F(10, 0);
            
            Vector2F intersection = LineTools.LineIntersect(p1, p2, q1, q2);
            
            Assert.True(intersection.X > 0 && intersection.Y > 0);
        }

        /// <summary>
        ///     Tests that line intersect should return zero for parallel lines
        /// </summary>
        [Fact]
        public void LineIntersect_ShouldReturnZero_ForParallelLines()
        {
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(10, 0);
            Vector2F q1 = new Vector2F(0, 5);
            Vector2F q2 = new Vector2F(10, 5);
            
            Vector2F intersection = LineTools.LineIntersect(p1, p2, q1, q2);
            
            Assert.Equal(Vector2F.Zero, intersection);
        }

        /// <summary>
        ///     Tests that line intersect with segments should detect intersection
        /// </summary>
        [Fact]
        public void LineIntersect_WithSegments_ShouldDetectIntersection()
        {
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(10, 10);
            Vector2F p3 = new Vector2F(0, 10);
            Vector2F p4 = new Vector2F(10, 0);
            
            bool intersects = LineTools.LineIntersect(ref p1, ref p2, ref p3, ref p4, true, true, out Vector2F point);
            
            Assert.True(intersects);
        }

        /// <summary>
        ///     Tests that line intersect should handle vertical lines
        /// </summary>
        [Fact]
        public void LineIntersect_ShouldHandleVerticalLines()
        {
            Vector2F p1 = new Vector2F(5, 0);
            Vector2F p2 = new Vector2F(5, 10);
            Vector2F q1 = new Vector2F(0, 5);
            Vector2F q2 = new Vector2F(10, 5);
            
            bool intersects = LineTools.LineIntersect(ref p1, ref p2, ref q1, ref q2, true, true, out Vector2F point);
            
            Assert.True(intersects);
        }

        /// <summary>
        ///     Tests that line intersect should handle horizontal lines
        /// </summary>
        [Fact]
        public void LineIntersect_ShouldHandleHorizontalLines()
        {
            Vector2F p1 = new Vector2F(0, 5);
            Vector2F p2 = new Vector2F(10, 5);
            Vector2F q1 = new Vector2F(5, 0);
            Vector2F q2 = new Vector2F(5, 10);
            
            bool intersects = LineTools.LineIntersect(ref p1, ref p2, ref q1, ref q2, true, true, out Vector2F point);
            
            Assert.True(intersects);
        }
    }
}

