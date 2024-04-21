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
    }
}