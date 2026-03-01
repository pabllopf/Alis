// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonShapeTest.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    ///     The polygon shape test class
    /// </summary>
    public class PolygonShapeTest
    {
        /// <summary>
        ///     Tests that constructor with vertices should initialize correctly
        /// </summary>
        [Fact]
        public void ConstructorWithVertices_ShouldInitializeCorrectly()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(0, 1)
            };
            float density = 1.0f;
            
            PolygonShape polygon = new PolygonShape(vertices, density);
            
            Assert.Equal(ShapeType.Polygon, polygon.ShapeType);
            Assert.NotNull(polygon.Vertices);
        }

        /// <summary>
        ///     Tests that constructor with density should initialize correctly
        /// </summary>
        [Fact]
        public void ConstructorWithDensity_ShouldInitializeCorrectly()
        {
            float density = 1.5f;
            
            PolygonShape polygon = new PolygonShape(density);
            
            Assert.Equal(ShapeType.Polygon, polygon.ShapeType);
            Assert.NotNull(polygon.Vertices);
            Assert.NotNull(polygon.Normals);
        }

        /// <summary>
        ///     Tests that vertices property should set and get correctly
        /// </summary>
        [Fact]
        public void VerticesProperty_ShouldSetAndGetCorrectly()
        {
            PolygonShape polygon = new PolygonShape(1.0f);
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(2, 0),
                new Vector2F(1, 2)
            };
            
            polygon.Vertices = vertices;
            
            Assert.NotNull(polygon.Vertices);
            Assert.Equal(3, polygon.Vertices.Count);
        }

        /// <summary>
        ///     Tests that normals should be computed when vertices set
        /// </summary>
        [Fact]
        public void Normals_ShouldBeComputed_WhenVerticesSet()
        {
            PolygonShape polygon = new PolygonShape(1.0f);
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(0, 1)
            };
            
            polygon.Vertices = vertices;
            
            Assert.NotNull(polygon.Normals);
            Assert.Equal(3, polygon.Normals.Count);
        }

        /// <summary>
        ///     Tests that child count should return one
        /// </summary>
        [Fact]
        public void ChildCount_ShouldReturnOne()
        {
            PolygonShape polygon = new PolygonShape(1.0f);
            
            Assert.Equal(1, polygon.ChildCount);
        }

        /// <summary>
        ///     Tests that polygon shape should handle square vertices
        /// </summary>
        [Fact]
        public void PolygonShape_ShouldHandleSquareVertices()
        {
            Vertices square = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(1, 1),
                new Vector2F(0, 1)
            };
            
            PolygonShape polygon = new PolygonShape(square, 1.0f);
            
            Assert.NotNull(polygon.Vertices);
        }

        /// <summary>
        ///     Tests that polygon shape should handle triangle vertices
        /// </summary>
        [Fact]
        public void PolygonShape_ShouldHandleTriangleVertices()
        {
            Vertices triangle = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(0.5f, 1)
            };
            
            PolygonShape polygon = new PolygonShape(triangle, 1.0f);
            
            Assert.Equal(3, polygon.Vertices.Count);
        }

        /// <summary>
        ///     Tests that polygon shape should compute mass data with positive density
        /// </summary>
        [Fact]
        public void PolygonShape_ShouldComputeMassData_WithPositiveDensity()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(0, 1)
            };
            
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            
            Assert.True(polygon.MassData.Mass > 0);
        }

        /// <summary>
        ///     Tests that polygon shape should not compute mass data with zero density
        /// </summary>
        [Fact]
        public void PolygonShape_ShouldNotComputeMassData_WithZeroDensity()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(0, 1)
            };
            
            PolygonShape polygon = new PolygonShape(vertices, 0.0f);
            
            Assert.Equal(0, polygon.MassData.Mass);
        }

        /// <summary>
        ///     Tests that test point should return true for point inside polygon
        /// </summary>
        [Fact]
        public void TestPoint_ShouldReturnTrue_ForPointInsidePolygon()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0),
                new Vector2F(10, 10),
                new Vector2F(0, 10)
            };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            Vector2F point = new Vector2F(5, 5);
            
            bool inside = polygon.TestPoint(ref transform, ref point);
            
            Assert.True(inside);
        }

        /// <summary>
        ///     Tests that test point should return false for point outside polygon
        /// </summary>
        [Fact]
        public void TestPoint_ShouldReturnFalse_ForPointOutsidePolygon()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0),
                new Vector2F(10, 10),
                new Vector2F(0, 10)
            };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            Vector2F point = new Vector2F(15, 15);
            
            bool inside = polygon.TestPoint(ref transform, ref point);
            
            Assert.False(inside);
        }

        /// <summary>
        ///     Tests that polygon shape should inherit from shape
        /// </summary>
        [Fact]
        public void PolygonShape_ShouldInheritFromShape()
        {
            PolygonShape polygon = new PolygonShape(1.0f);
            
            Assert.IsAssignableFrom<Shape>(polygon);
        }

        /// <summary>
        ///     Tests that polygon shape should support complex polygons
        /// </summary>
        [Fact]
        public void PolygonShape_ShouldSupportComplexPolygons()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(2, 0),
                new Vector2F(2, 1),
                new Vector2F(1, 1),
                new Vector2F(1, 2),
                new Vector2F(0, 2)
            };
            
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            
            Assert.NotNull(polygon.Vertices);
        }
    }
}

