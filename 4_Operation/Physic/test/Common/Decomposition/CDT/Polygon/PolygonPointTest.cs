// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonPointTest.cs
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

using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Polygon;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Polygon
{
    /// <summary>
    ///     The polygon point test class
    /// </summary>
    public class PolygonPointTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with coordinates
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithCoordinates()
        {
            double x = 5.0;
            double y = 10.0;
            
            PolygonPoint point = new PolygonPoint(x, y);
            
            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
            Assert.Null(point.Next);
            Assert.Null(point.Previous);
        }

        /// <summary>
        ///     Tests that polygon point should inherit from triangulation point
        /// </summary>
        [Fact]
        public void PolygonPoint_ShouldInheritFromTriangulationPoint()
        {
            PolygonPoint point = new PolygonPoint(0, 0);
            
            Assert.IsAssignableFrom<TriangulationPoint>(point);
        }

        /// <summary>
        ///     Tests that next property should set and get correctly
        /// </summary>
        [Fact]
        public void NextProperty_ShouldSetAndGetCorrectly()
        {
            PolygonPoint point1 = new PolygonPoint(0, 0);
            PolygonPoint point2 = new PolygonPoint(5, 5);
            
            point1.Next = point2;
            
            Assert.Equal(point2, point1.Next);
        }

        /// <summary>
        ///     Tests that previous property should set and get correctly
        /// </summary>
        [Fact]
        public void PreviousProperty_ShouldSetAndGetCorrectly()
        {
            PolygonPoint point1 = new PolygonPoint(0, 0);
            PolygonPoint point2 = new PolygonPoint(5, 5);
            
            point2.Previous = point1;
            
            Assert.Equal(point1, point2.Previous);
        }

        /// <summary>
        ///     Tests that polygon point should support doubly linked list structure
        /// </summary>
        [Fact]
        public void PolygonPoint_ShouldSupportDoublyLinkedListStructure()
        {
            PolygonPoint point1 = new PolygonPoint(0, 0);
            PolygonPoint point2 = new PolygonPoint(5, 5);
            PolygonPoint point3 = new PolygonPoint(10, 10);
            
            point1.Next = point2;
            point2.Previous = point1;
            point2.Next = point3;
            point3.Previous = point2;
            
            Assert.Equal(point2, point1.Next);
            Assert.Equal(point1, point2.Previous);
            Assert.Equal(point3, point2.Next);
            Assert.Equal(point2, point3.Previous);
        }

        /// <summary>
        ///     Tests that polygon point should handle negative coordinates
        /// </summary>
        [Fact]
        public void PolygonPoint_ShouldHandleNegativeCoordinates()
        {
            PolygonPoint point = new PolygonPoint(-10.5, -20.5);
            
            Assert.Equal(-10.5, point.X);
            Assert.Equal(-20.5, point.Y);
        }

        /// <summary>
        ///     Tests that polygon point should handle zero coordinates
        /// </summary>
        [Fact]
        public void PolygonPoint_ShouldHandleZeroCoordinates()
        {
            PolygonPoint point = new PolygonPoint(0, 0);
            
            Assert.Equal(0, point.X);
            Assert.Equal(0, point.Y);
        }

        /// <summary>
        ///     Tests that polygon point should support circular references
        /// </summary>
        [Fact]
        public void PolygonPoint_ShouldSupportCircularReferences()
        {
            PolygonPoint point1 = new PolygonPoint(0, 0);
            PolygonPoint point2 = new PolygonPoint(5, 5);
            
            point1.Next = point2;
            point2.Next = point1;
            point1.Previous = point2;
            point2.Previous = point1;
            
            Assert.Equal(point2, point1.Next);
            Assert.Equal(point1, point2.Next);
        }

        /// <summary>
        ///     Tests that polygon point should allow null next
        /// </summary>
        [Fact]
        public void PolygonPoint_ShouldAllowNullNext()
        {
            PolygonPoint point = new PolygonPoint(5, 5);
            point.Next = new PolygonPoint(10, 10);
            
            point.Next = null;
            
            Assert.Null(point.Next);
        }

        /// <summary>
        ///     Tests that polygon point should allow null previous
        /// </summary>
        [Fact]
        public void PolygonPoint_ShouldAllowNullPrevious()
        {
            PolygonPoint point = new PolygonPoint(5, 5);
            point.Previous = new PolygonPoint(0, 0);
            
            point.Previous = null;
            
            Assert.Null(point.Previous);
        }

        /// <summary>
        ///     Tests that polygon point should support large coordinate values
        /// </summary>
        [Fact]
        public void PolygonPoint_ShouldSupportLargeCoordinateValues()
        {
            PolygonPoint point = new PolygonPoint(100000.0, 200000.0);
            
            Assert.Equal(100000.0, point.X);
            Assert.Equal(200000.0, point.Y);
        }
    }
}

