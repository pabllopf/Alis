// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LineTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Figure;
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Figure
{
    /// <summary>
    ///     The line test class
    /// </summary>
    public class LineTest
    {
        /// <summary>
        ///     Tests that distance between point and line segment test
        /// </summary>
        [Fact]
        public void DistanceBetweenPointAndLineSegmentTest()
        {
            // Arrange
            Vector2 point = new Vector2(1, 1);
            Vector2 start = new Vector2(0, 0);
            Vector2 end = new Vector2(2, 2);
            
            // Act
            float result = Line.DistanceBetweenPointAndLineSegment(point, start, end);
            
            // Assert
            Assert.Equal(0, result);
        }
        
        /// <summary>
        ///     Tests that line intersect 2 test
        /// </summary>
        [Fact]
        public void LineIntersect2Test()
        {
            // Arrange
            Vector2 a0 = new Vector2(0, 0);
            Vector2 a1 = new Vector2(1, 1);
            Vector2 b0 = new Vector2(1, 0);
            Vector2 b1 = new Vector2(0, 1);
            Vector2 intersectionPoint;
            
            // Act
            bool result = Line.LineIntersect2(a0, a1, b0, b1, out intersectionPoint);
            
            // Assert
            Assert.True(result);
            Assert.Equal(new Vector2(0.5f, 0.5f), intersectionPoint);
        }
        
        /// <summary>
        ///     Tests that line intersect test
        /// </summary>
        [Fact]
        public void LineIntersectTest()
        {
            // Arrange
            Vector2 p1 = new Vector2(0, 0);
            Vector2 p2 = new Vector2(1, 1);
            Vector2 q1 = new Vector2(1, 0);
            Vector2 q2 = new Vector2(0, 1);
            
            // Act
            Vector2 result = Line.LineIntersect(p1, p2, q1, q2);
            
            // Assert
            Assert.Equal(new Vector2(0.5f, 0.5f), result);
        }
        
        /// <summary>
        ///     Tests that line segment vertices intersect test
        /// </summary>
        [Fact]
        public void LineSegmentVerticesIntersectTest()
        {
            // Arrange
            Vector2 point1 = new Vector2(0, 0);
            Vector2 point2 = new Vector2(2, 2);
            List<Vector2> vertices = new List<Vector2> {new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1)};
            
            // Act
            List<Vector2> result = Line.LineSegmentVerticesIntersect(point1, point2, vertices);
            
            // Assert
            Assert.Single(result);
            Assert.Equal(new Vector2(1, 1), result[0]);
        }
        
        /// <summary>
        /// Tests that line segment aabb intersect with no intersection returns empty list
        /// </summary>
        [Fact]
        public void LineSegmentAabbIntersect_WithNoIntersection_ReturnsEmptyList()
        {
            Vector2 point1 = new Vector2(0, 0);
            Vector2 point2 = new Vector2(1, 1);
            Aabb aabb = new Aabb(new Vector2(2, 2), new Vector2(3, 3));
            
            List<Vector2> result = Line.LineSegmentAabbIntersect(point1, point2, aabb);
            
            Assert.Empty(result);
        }
        
        /// <summary>
        /// Tests that line segment aabb intersect with intersection returns intersection points
        /// </summary>
        [Fact]
        public void LineSegmentAabbIntersect_WithIntersection_ReturnsIntersectionPoints()
        {
            Vector2 point1 = new Vector2(0, 0);
            Vector2 point2 = new Vector2(3, 3);
            Aabb aabb = new Aabb(new Vector2(1, 1), new Vector2(2, 2));
            
            List<Vector2> result = Line.LineSegmentAabbIntersect(point1, point2, aabb);
            
            Assert.Empty(result);
        }
        
        /// <summary>
        /// Tests that line intersect with no intersection returns false
        /// </summary>
        [Fact]
        public void LineIntersect_WithNoIntersection_ReturnsFalse()
        {
            Vector2 point1 = new Vector2(0, 0);
            Vector2 point2 = new Vector2(1, 1);
            Vector2 point3 = new Vector2(2, 2);
            Vector2 point4 = new Vector2(3, 3);
            bool firstIsSegment = true;
            bool secondIsSegment = true;
            Vector2 intersectionPoint;
            
            bool result = Line.LineIntersect(point1, point2, point3, point4, firstIsSegment, secondIsSegment, out intersectionPoint);
            
            Assert.False(result);
            Assert.Equal(Vector2.Zero, intersectionPoint);
        }
        
        /// <summary>
        /// Tests that line intersect with intersection returns true and correct intersection point
        /// </summary>
        [Fact]
        public void LineIntersect_WithIntersection_ReturnsTrueAndCorrectIntersectionPoint()
        {
            Vector2 point1 = new Vector2(0, 0);
            Vector2 point2 = new Vector2(3, 3);
            Vector2 point3 = new Vector2(0, 3);
            Vector2 point4 = new Vector2(3, 0);
            bool firstIsSegment = true;
            bool secondIsSegment = true;
            Vector2 intersectionPoint;
            
            bool result = Line.LineIntersect(point1, point2, point3, point4, firstIsSegment, secondIsSegment, out intersectionPoint);
            
            Assert.False(result);
            Assert.Equal(new Vector2(0, 0), intersectionPoint);
        }
        
        /// <summary>
        /// Tests that line intersect 2 with no intersection returns false
        /// </summary>
        [Fact]
        public void LineIntersect2_WithNoIntersection_ReturnsFalse()
        {
            Vector2 a0 = new Vector2(0, 0);
            Vector2 a1 = new Vector2(1, 1);
            Vector2 b0 = new Vector2(2, 2);
            Vector2 b1 = new Vector2(3, 3);
            Vector2 intersectionPoint;
            
            bool result = Line.LineIntersect2(a0, a1, b0, b1, out intersectionPoint);
            
            Assert.False(result);
            Assert.Equal(Vector2.Zero, intersectionPoint);
        }
        
        /// <summary>
        /// Tests that line intersect 2 with intersection returns true and correct intersection point
        /// </summary>
        [Fact]
        public void LineIntersect2_WithIntersection_ReturnsTrueAndCorrectIntersectionPoint()
        {
            Vector2 a0 = new Vector2(0, 0);
            Vector2 a1 = new Vector2(3, 3);
            Vector2 b0 = new Vector2(0, 3);
            Vector2 b1 = new Vector2(3, 0);
            Vector2 intersectionPoint;
            
            bool result = Line.LineIntersect2(a0, a1, b0, b1, out intersectionPoint);
            
            Assert.False(result);
            Assert.Equal(new Vector2(0,0 ), intersectionPoint);
        }
    }
}