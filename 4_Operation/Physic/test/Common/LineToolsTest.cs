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
using Alis.Core.Physic.Collisions;
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
            Assert.True((intersection.X > 0) && (intersection.Y > 0));
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

            Assert.True((intersection.X > 0) && (intersection.Y > 0));
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

        /// <summary>
        ///     Tests that line intersect 2 should return false when ua is zero
        /// </summary>
        [Fact]
        public void LineIntersect2_ShouldReturnFalse_WhenUaIsZero()
        {
            Vector2F a0 = new Vector2F(0, 0);
            Vector2F a1 = new Vector2F(10, 0);
            Vector2F b0 = new Vector2F(5, 0);
            Vector2F b1 = new Vector2F(15, 5);

            bool intersects = LineTools.LineIntersect2(ref a0, ref a1, ref b0, ref b1, out Vector2F _);

            Assert.False(intersects);
        }

        /// <summary>
        ///     Tests that line intersect 2 should return false when ub is zero
        /// </summary>
        [Fact]
        public void LineIntersect2_ShouldReturnFalse_WhenUbIsZero()
        {
            Vector2F a0 = new Vector2F(0, 0);
            Vector2F a1 = new Vector2F(10, 0);
            Vector2F b0 = new Vector2F(5, 0);
            Vector2F b1 = new Vector2F(5, -2);

            bool intersects = LineTools.LineIntersect2(ref a0, ref a1, ref b0, ref b1, out Vector2F _);

            Assert.False(intersects);
        }

        /// <summary>
        ///     Tests that line intersect 2 should return false when ub is greater than one
        /// </summary>
        [Fact]
        public void LineIntersect2_ShouldReturnFalse_WhenUbIsGreaterThanOne()
        {
            Vector2F a0 = new Vector2F(0, 0);
            Vector2F a1 = new Vector2F(10, 0);
            Vector2F b0 = new Vector2F(5, 2);
            Vector2F b1 = new Vector2F(5, 1);

            bool intersects = LineTools.LineIntersect2(ref a0, ref a1, ref b0, ref b1, out Vector2F _);

            Assert.False(intersects);
        }

        /// <summary>
        ///     Tests that line intersect 2 should return true when intersection is at the middle of both segments
        /// </summary>
        [Fact]
        public void LineIntersect2_ShouldReturnTrue_WhenInternalIntersection()
        {
            Vector2F a0 = new Vector2F(0, 0);
            Vector2F a1 = new Vector2F(10, 0);
            Vector2F b0 = new Vector2F(5, -1);
            Vector2F b1 = new Vector2F(5, 1);

            bool intersects = LineTools.LineIntersect2(ref a0, ref a1, ref b0, ref b1, out Vector2F intersection);

            Assert.True(intersects);
            Assert.Equal(5f, intersection.X);
            Assert.Equal(0f, intersection.Y);
        }

        /// <summary>
        ///     Tests that line intersect 2 should return false with aabb x early exit
        /// </summary>
        [Fact]
        public void LineIntersect2_ShouldReturnFalse_WhenAabbXEarlyExit()
        {
            Vector2F a0 = new Vector2F(0, 0);
            Vector2F a1 = new Vector2F(2, 0);
            Vector2F b0 = new Vector2F(5, -1);
            Vector2F b1 = new Vector2F(5, 1);

            bool intersects = LineTools.LineIntersect2(ref a0, ref a1, ref b0, ref b1, out Vector2F _);

            Assert.False(intersects);
        }

        /// <summary>
        ///     Tests that line intersect 2 should return false with aabb y early exit
        /// </summary>
        [Fact]
        public void LineIntersect2_ShouldReturnFalse_WhenAabbYEarlyExit()
        {
            Vector2F a0 = new Vector2F(0, 2);
            Vector2F a1 = new Vector2F(5, 2);
            Vector2F b0 = new Vector2F(0, 0);
            Vector2F b1 = new Vector2F(5, 0);

            bool intersects = LineTools.LineIntersect2(ref a0, ref a1, ref b0, ref b1, out Vector2F _);

            Assert.False(intersects);
        }

        /// <summary>
        ///     Tests that line intersect with segments should return false when ua is less than zero
        /// </summary>
        [Fact]
        public void LineIntersect_WithSegments_ShouldReturnFalse_WhenUaLessThanZero()
        {
            Vector2F p1 = new Vector2F(5, 0);
            Vector2F p2 = new Vector2F(15, 0);
            Vector2F p3 = new Vector2F(0, 0);
            Vector2F p4 = new Vector2F(10, 10);

            bool intersects = LineTools.LineIntersect(ref p1, ref p2, ref p3, ref p4, true, true, out Vector2F _);

            Assert.False(intersects);
        }

        /// <summary>
        ///     Tests that line intersect with segments should return false when ua is greater than one
        /// </summary>
        [Fact]
        public void LineIntersect_WithSegments_ShouldReturnFalse_WhenUaGreaterThanOne()
        {
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(5, 0);
            Vector2F p3 = new Vector2F(10, 0);
            Vector2F p4 = new Vector2F(0, 10);

            bool intersects = LineTools.LineIntersect(ref p1, ref p2, ref p3, ref p4, true, true, out Vector2F _);

            Assert.False(intersects);
        }

        /// <summary>
        ///     Tests that line intersect with segments should return false when ub is less than zero
        /// </summary>
        [Fact]
        public void LineIntersect_WithSegments_ShouldReturnFalse_WhenUbLessThanZero()
        {
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(10, 5);
            Vector2F p3 = new Vector2F(5, 1);
            Vector2F p4 = new Vector2F(5, 0.5f);

            bool intersects = LineTools.LineIntersect(ref p1, ref p2, ref p3, ref p4, true, true, out Vector2F _);

            Assert.False(intersects);
        }

        /// <summary>
        ///     Tests that line intersect with segments should return false when ub is greater than one
        /// </summary>
        [Fact]
        public void LineIntersect_WithSegments_ShouldReturnFalse_WhenUbGreaterThanOne()
        {
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(10, 5);
            Vector2F p3 = new Vector2F(5, -1);
            Vector2F p4 = new Vector2F(5, 1);

            bool intersects = LineTools.LineIntersect(ref p1, ref p2, ref p3, ref p4, true, true, out Vector2F _);

            Assert.False(intersects);
        }

        /// <summary>
        ///     Tests that line intersect with segments should return false when denom is near zero
        /// </summary>
        [Fact]
        public void LineIntersect_WithSegments_ShouldReturnFalse_WhenDenomNearZero()
        {
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(10, 0);
            Vector2F p3 = new Vector2F(0, 5);
            Vector2F p4 = new Vector2F(10, 5);

            bool intersects = LineTools.LineIntersect(ref p1, ref p2, ref p3, ref p4, true, true, out Vector2F _);

            Assert.False(intersects);
        }

        /// <summary>
        ///     Tests that line intersect without segment checks should detect intersection
        /// </summary>
        [Fact]
        public void LineIntersect_WithoutSegmentChecks_ShouldDetectIntersection()
        {
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(10, 0);
            Vector2F p3 = new Vector2F(5, -1);
            Vector2F p4 = new Vector2F(5, 1);

            bool intersects = LineTools.LineIntersect(ref p1, ref p2, ref p3, ref p4, false, false, out Vector2F intersection);

            Assert.True(intersects);
        }

        /// <summary>
        ///     Tests that line intersect by value should detect intersection
        /// </summary>
        [Fact]
        public void LineIntersect_ByValue_ShouldDetectIntersection()
        {
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(10, 10);
            Vector2F p3 = new Vector2F(0, 10);
            Vector2F p4 = new Vector2F(10, 0);

            bool intersects = LineTools.LineIntersect(p1, p2, p3, p4, true, true, out Vector2F point);

            Assert.True(intersects);
        }

        /// <summary>
        ///     Tests that line intersect segments by value should detect intersection
        /// </summary>
        [Fact]
        public void LineIntersect_SegmentsByRef_ShouldDetectIntersection()
        {
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(10, 10);
            Vector2F p3 = new Vector2F(0, 10);
            Vector2F p4 = new Vector2F(10, 0);

            bool intersects = LineTools.LineIntersect(ref p1, ref p2, ref p3, ref p4, out Vector2F point);

            Assert.True(intersects);
        }

        /// <summary>
        ///     Tests that line intersect 2 should return false when denom is near zero
        /// </summary>
        [Fact]
        public void LineIntersect2_ShouldReturnFalse_WhenDenomNearZero()
        {
            Vector2F a0 = new Vector2F(0, 0);
            Vector2F a1 = new Vector2F(10, 1f);
            Vector2F b0 = new Vector2F(0, 0.5f);
            Vector2F b1 = new Vector2F(10, 1.5f);

            bool intersects = LineTools.LineIntersect2(ref a0, ref a1, ref b0, ref b1, out _);

            Assert.False(intersects);
        }

        /// <summary>
        ///     Tests that line intersect should return false when intersection is at segment endpoint
        /// </summary>
        [Fact]
        public void LineIntersect_WithSegments_ShouldReturnFalse_WhenCoincidentEndpoint()
        {
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(10, 10);
            Vector2F p3 = new Vector2F(0, 0);
            Vector2F p4 = new Vector2F(10, 0);

            bool intersects = LineTools.LineIntersect(ref p1, ref p2, ref p3, ref p4, true, true, out Vector2F _);

            Assert.False(intersects);
        }

        /// <summary>
        ///     Tests that line intersect segments by value should detect intersection
        /// </summary>
        [Fact]
        public void LineIntersect_SegmentsByValue_ShouldDetectIntersection()
        {
            Vector2F p1 = new Vector2F(0, 0);
            Vector2F p2 = new Vector2F(10, 10);
            Vector2F p3 = new Vector2F(0, 10);
            Vector2F p4 = new Vector2F(10, 0);

            bool intersects = LineTools.LineIntersect(p1, p2, p3, p4, out Vector2F point);

            Assert.True(intersects);
        }

        /// <summary>
        ///     Tests that line segment vertices intersect should return intersection points
        /// </summary>
        [Fact]
        public void LineSegmentVerticesIntersect_WithTriangle_ShouldReturnIntersectionPoints()
        {
            Vector2F p1 = new Vector2F(-1, 0);
            Vector2F p2 = new Vector2F(3, 0);
            Vertices triangle = new Vertices(new[]
            {
                new Vector2F(0, -1),
                new Vector2F(1, 1),
                new Vector2F(-1, 1)
            });

            Vertices intersections = LineTools.LineSegmentVerticesIntersect(ref p1, ref p2, triangle);

            Assert.NotEmpty(intersections);
        }

        /// <summary>
        ///     Tests that line segment aabb intersect should return intersection points
        /// </summary>
        [Fact]
        public void LineSegmentAabbIntersect_WithAabb_ShouldReturnIntersectionPoints()
        {
            Vector2F p1 = new Vector2F(-1, 0.5f);
            Vector2F p2 = new Vector2F(3, 0.5f);
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(2, 1));

            Vertices intersections = LineTools.LineSegmentAabbIntersect(ref p1, ref p2, aabb);

            Assert.NotEmpty(intersections);
        }
    }
}