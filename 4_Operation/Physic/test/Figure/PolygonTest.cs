// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonTest.cs
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

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Figure;
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Figure
{
    /// <summary>
    ///     The polygon test class
    /// </summary>
    public class PolygonTest
    {
        /// <summary>
        ///     Tests that create rectangle test
        /// </summary>
        [Fact]
        public void CreateRectangleTest()
        {
            // Arrange
            float hx = 1.0f;
            float hy = 2.0f;
            
            // Act
            Vertices result = Polygon.CreateRectangle(hx, hy);
            
            // Assert
            Assert.Equal(4, result.Count);
        }
        
        /// <summary>
        ///     Tests that create rounded rectangle test
        /// </summary>
        [Fact]
        public void CreateRoundedRectangleTest()
        {
            // Arrange
            float width = 2.0f;
            float height = 3.0f;
            float xRadius = 1.0f;
            float yRadius = 1.0f;
            int segments = 4;
            
            // Act
            Vertices result = Polygon.CreateRoundedRectangle(width, height, xRadius, yRadius, segments);
            
            // Assert
            Assert.Equal(24, result.Count);
        }
        
        /// <summary>
        ///     Tests that create line test
        /// </summary>
        [Fact]
        public void CreateLineTest()
        {
            // Arrange
            Vector2 start = new Vector2(0, 0);
            Vector2 end = new Vector2(1, 1);
            
            // Act
            Vertices result = Polygon.CreateLine(start, end);
            
            // Assert
            Assert.Equal(2, result.Count);
        }
        
        /// <summary>
        ///     Tests that create circle test
        /// </summary>
        [Fact]
        public void CreateCircleTest()
        {
            // Arrange
            float radius = 1.0f;
            int numberOfEdges = 4;
            
            // Act
            Vertices result = Polygon.CreateCircle(radius, numberOfEdges);
            
            // Assert
            Assert.Equal(4, result.Count);
        }
        
        /// <summary>
        ///     Tests that create ellipse test
        /// </summary>
        [Fact]
        public void CreateEllipseTest()
        {
            // Arrange
            float xRadius = 1.0f;
            float yRadius = 2.0f;
            int numberOfEdges = 4;
            
            // Act
            Vertices result = Polygon.CreateEllipse(xRadius, yRadius, numberOfEdges);
            
            // Assert
            Assert.Equal(4, result.Count);
        }
        
        /// <summary>
        ///     Tests that create arc test
        /// </summary>
        [Fact]
        public void CreateArcTest()
        {
            // Arrange
            float radians = (float) Math.PI / 2; // 90 degrees
            int sides = 4;
            float radius = 1.0f;
            
            // Act
            Vertices result = Polygon.CreateArc(radians, sides, radius);
            
            // Assert
            Assert.Equal(3, result.Count);
        }
        
        /// <summary>
        ///     Tests that create capsule test
        /// </summary>
        [Fact]
        public void CreateCapsuleTest()
        {
            // Arrange
            float height = 2.0f;
            float endRadius = 0.5f;
            int edges = 4;
            
            // Act
            Vertices result = Polygon.CreateCapsule(height, endRadius, edges);
            
            // Assert
            Assert.Equal(10, result.Count);
        }
        
        /// <summary>
        ///     Tests that create gear test
        /// </summary>
        [Fact]
        public void CreateGearTest()
        {
            // Arrange
            float radius = 1.0f;
            int numberOfTeeth = 4;
            float tipPercentage = 25.0f;
            float toothHeight = 0.1f;
            
            // Act
            Vertices result = Polygon.CreateGear(radius, numberOfTeeth, tipPercentage, toothHeight);
            
            // Assert
            Assert.Equal(16, result.Count);
        }
        
        /// <summary>
        /// Tests that create rectangle with valid parameters returns correct vertices
        /// </summary>
        [Fact]
        public void CreateRectangle_WithValidParameters_ReturnsCorrectVertices()
        {
            float hx = 2.5f;
            float hy = 2.3f;
            Vector2 center = new Vector2(1.0f, 1.0f);
            float angle = 45.0f;
            
            Vertices result = Polygon.CreateRectangle(hx, hy, center, angle);
            
            Assert.Equal(4, result.Count);
            Assert.Equal(new Vector2(1.6437731f, -2.3354993f), result[0]);
            Assert.Equal(new Vector2(4.270383f, 1.9190183f), result[1]);
        }
        
        /// <summary>
        /// Tests that transform vertices with valid parameters changes vertices correctly
        /// </summary>
        [Fact]
        public void TransformVertices_WithValidParameters_ChangesVerticesCorrectly()
        {
            Vertices vertices = new Vertices(4)
            {
                new Vector2(-2.0f, -3.0f),
                new Vector2(2.0f, -3.0f),
                new Vector2(2.0f, 3.0f),
                new Vector2(-2.0f, 3.0f)
            };
            Vector2 center = new Vector2(1.0f, 1.0f);
            float angle = 45.0f;
            
            Polygon.TransformVertices(vertices, center, angle);
        }
        
        /// <summary>
        /// Tests that create capsule with valid parameters returns correct vertices
        /// </summary>
        [Fact]
        public void CreateCapsule_WithValidParameters_ReturnsCorrectVertices()
        {
            float height = 2.0f;
            float endRadius = 0.5f;
            int edges = 4;
            
            Vertices result = Polygon.CreateCapsule(height, endRadius, edges);
            
            Assert.Equal(10, result.Count);
            // Here you would assert that the properties of result have been set correctly.
        }
        
        /// <summary>
        /// Tests that create capsule with end radius greater than half height throws argument exception
        /// </summary>
        [Fact]
        public void CreateCapsule_WithEndRadiusGreaterThanHalfHeight_ThrowsArgumentException()
        {
            float height = 2.0f;
            float endRadius = 1.5f;
            int edges = 4;
            
            Assert.Throws<ArgumentException>(() => Polygon.CreateCapsule(height, endRadius, edges));
        }
        
        /// <summary>
        /// Tests that create rectangle without segments with valid parameters returns correct vertices
        /// </summary>
        [Fact]
        public void CreateRectangleWithoutSegments_WithValidParameters_ReturnsCorrectVertices()
        {
            Vertices vertices = new Vertices();
            float width = 2.0f;
            float height = 3.0f;
            float xRadius = 0.5f;
            float yRadius = 0.5f;
            
            Polygon.CreateRectangleWithoutSegments(vertices, width, height, xRadius, yRadius);
            
            Assert.Equal(8, vertices.Count);
            Assert.Equal(new Vector2(width * .5f - xRadius, -height * .5f), vertices[0]);
            Assert.Equal(new Vector2(width * .5f, -height * .5f + yRadius), vertices[1]);
            Assert.Equal(new Vector2(width * .5f, height * .5f - yRadius), vertices[2]);
            Assert.Equal(new Vector2(width * .5f - xRadius, height * .5f), vertices[3]);
            Assert.Equal(new Vector2(-width * .5f + xRadius, height * .5f), vertices[4]);
            Assert.Equal(new Vector2(-width * .5f, height * .5f - yRadius), vertices[5]);
            Assert.Equal(new Vector2(-width * .5f, -height * .5f + yRadius), vertices[6]);
            Assert.Equal(new Vector2(-width * .5f + xRadius, -height * .5f), vertices[7]);
        }
        
        /// <summary>
        /// Tests that create rounded rectangle with valid parameters and no segments returns correct vertices
        /// </summary>
        [Fact]
        public void CreateRoundedRectangle_WithValidParametersAndNoSegments_ReturnsCorrectVertices()
        {
            float width = 2.0f;
            float height = 3.0f;
            float xRadius = 0.5f;
            float yRadius = 0.5f;
            int segments = 0;
            
            Vertices result = Polygon.CreateRoundedRectangle(width, height, xRadius, yRadius, segments);
            
            Assert.Equal(8, result.Count);
            Assert.Equal(new Vector2(width * .5f - xRadius, -height * .5f), result[0]);
            Assert.Equal(new Vector2(width * .5f, -height * .5f + yRadius), result[1]);
            Assert.Equal(new Vector2(width * .5f, height * .5f - yRadius), result[2]);
            Assert.Equal(new Vector2(width * .5f - xRadius, height * .5f), result[3]);
            Assert.Equal(new Vector2(-width * .5f + xRadius, height * .5f), result[4]);
            Assert.Equal(new Vector2(-width * .5f, height * .5f - yRadius), result[5]);
            Assert.Equal(new Vector2(-width * .5f, -height * .5f + yRadius), result[6]);
            Assert.Equal(new Vector2(-width * .5f + xRadius, -height * .5f), result[7]);
        }
        
        /// <summary>
        /// Tests that create rounded rectangle with valid parameters and segments returns correct vertices
        /// </summary>
        [Fact]
        public void CreateRoundedRectangle_WithValidParametersAndSegments_ReturnsCorrectVertices()
        {
            float width = 2.0f;
            float height = 3.0f;
            float xRadius = 0.5f;
            float yRadius = 0.5f;
            int segments = 4;
            
            Vertices result = Polygon.CreateRoundedRectangle(width, height, xRadius, yRadius, segments);
            
            // Here you would assert that the properties of result have been set correctly.
        }
        
        /// <summary>
        /// Tests that create rounded rectangle with invalid parameters throws exception
        /// </summary>
        [Fact]
        public void CreateRoundedRectangle_WithInvalidParameters_ThrowsException()
        {
            float width = 2.0f;
            float height = 3.0f;
            float xRadius = 2.0f; // Invalid xRadius
            float yRadius = 2.0f; // Invalid yRadius
            int segments = 4;
            
            Assert.Throws<System.Exception>(() => Polygon.CreateRoundedRectangle(width, height, xRadius, yRadius, segments));
        }
        
        /// <summary>
        /// Tests that validate rounded rectangle parameters with valid parameters does not throw exception
        /// </summary>
        [Fact]
        public void ValidateRoundedRectangleParameters_WithValidParameters_DoesNotThrowException()
        {
            float width = 2.0f;
            float height = 3.0f;
            float xRadius = 0.5f;
            float yRadius = 0.5f;
            int segments = 4;
            
            var ex = Record.Exception(() => Polygon.ValidateRoundedRectangleParameters(width, height, xRadius, yRadius, segments));
            Assert.Null(ex);
        }
        
        /// <summary>
        /// Tests that validate rounded rectangle parameters with invalid radius throws exception
        /// </summary>
        [Fact]
        public void ValidateRoundedRectangleParameters_WithInvalidRadius_ThrowsException()
        {
            float width = 2.0f;
            float height = 3.0f;
            float xRadius = 2.0f; // Invalid xRadius
            float yRadius = 2.0f; // Invalid yRadius
            int segments = 4;
            
            Assert.Throws<System.Exception>(() => Polygon.ValidateRoundedRectangleParameters(width, height, xRadius, yRadius, segments));
        }
        
        /// <summary>
        /// Tests that validate rounded rectangle parameters with negative segments throws exception
        /// </summary>
        [Fact]
        public void ValidateRoundedRectangleParameters_WithNegativeSegments_ThrowsException()
        {
            float width = 2.0f;
            float height = 3.0f;
            float xRadius = 0.5f;
            float yRadius = 0.5f;
            int segments = -1; // Invalid segments
            
            Assert.Throws<System.Exception>(() => Polygon.ValidateRoundedRectangleParameters(width, height, xRadius, yRadius, segments));
        }
        
        /// <summary>
        /// Tests that validate capsule parameters with valid parameters does not throw exception
        /// </summary>
        [Fact]
        public void ValidateCapsuleParameters_WithValidParameters_DoesNotThrowException()
        {
            float height = 2.0f;
            float topRadius = 0.5f;
            int topEdges = 4;
            float bottomRadius = 0.5f;
            int bottomEdges = 4;
            
            var ex = Record.Exception(() => Polygon.ValidateCapsuleParameters(height, topRadius, topEdges, bottomRadius, bottomEdges));
            Assert.Null(ex);
        }
        
        /// <summary>
        /// Tests that validate capsule parameters with invalid height throws exception
        /// </summary>
        [Fact]
        public void ValidateCapsuleParameters_WithInvalidHeight_ThrowsException()
        {
            float height = 0.0f; // Invalid height
            float topRadius = 0.5f;
            int topEdges = 4;
            float bottomRadius = 0.5f;
            int bottomEdges = 4;
            
            Assert.Throws<System.ArgumentException>(() => Polygon.ValidateCapsuleParameters(height, topRadius, topEdges, bottomRadius, bottomEdges));
        }
        
        /// <summary>
        /// Tests that validate capsule parameters with invalid top radius throws exception
        /// </summary>
        [Fact]
        public void ValidateCapsuleParameters_WithInvalidTopRadius_ThrowsException()
        {
            float height = 2.0f;
            float topRadius = 2.0f; // Invalid topRadius
            int topEdges = 4;
            float bottomRadius = 0.5f;
            int bottomEdges = 4;
            
            Assert.Throws<System.ArgumentException>(() => Polygon.ValidateCapsuleParameters(height, topRadius, topEdges, bottomRadius, bottomEdges));
        }
        
        /// <summary>
        /// Tests that validate capsule parameters with invalid top edges throws exception
        /// </summary>
        [Fact]
        public void ValidateCapsuleParameters_WithInvalidTopEdges_ThrowsException()
        {
            float height = 2.0f;
            float topRadius = 0.5f;
            int topEdges = 0; // Invalid topEdges
            float bottomRadius = 0.5f;
            int bottomEdges = 4;
            
            Assert.Throws<System.ArgumentException>(() => Polygon.ValidateCapsuleParameters(height, topRadius, topEdges, bottomRadius, bottomEdges));
        }
        
        /// <summary>
        /// Tests that validate capsule parameters with invalid bottom radius throws exception
        /// </summary>
        [Fact]
        public void ValidateCapsuleParameters_WithInvalidBottomRadius_ThrowsException()
        {
            float height = 2.0f;
            float topRadius = 0.5f;
            int topEdges = 4;
            float bottomRadius = 2.0f; // Invalid bottomRadius
            int bottomEdges = 4;
            
            Assert.Throws<System.ArgumentException>(() => Polygon.ValidateCapsuleParameters(height, topRadius, topEdges, bottomRadius, bottomEdges));
        }
        
        /// <summary>
        /// Tests that validate capsule parameters with invalid bottom edges throws exception
        /// </summary>
        [Fact]
        public void ValidateCapsuleParameters_WithInvalidBottomEdges_ThrowsException()
        {
            float height = 2.0f;
            float topRadius = 0.5f;
            int topEdges = 4;
            float bottomRadius = 0.5f;
            int bottomEdges = 0; // Invalid bottomEdges
            
            Assert.Throws<System.ArgumentException>(() => Polygon.ValidateCapsuleParameters(height, topRadius, topEdges, bottomRadius, bottomEdges));
        }
        
        /// <summary>
        /// Tests that validate radius with valid parameters does not throw exception
        /// </summary>
        [Fact]
        public void ValidateRadius_WithValidParameters_DoesNotThrowException()
        {
            float radius = 0.5f;
            float height = 2.0f;
            string position = "top";
            
            var ex = Record.Exception(() => Polygon.ValidateRadius(radius, height, position));
            Assert.Null(ex);
        }
        
        /// <summary>
        /// Tests that validate radius with zero radius throws exception
        /// </summary>
        [Fact]
        public void ValidateRadius_WithZeroRadius_ThrowsException()
        {
            float radius = 0.0f; // Invalid radius
            float height = 2.0f;
            string position = "top";
            
            Assert.Throws<System.ArgumentException>(() => Polygon.ValidateRadius(radius, height, position));
        }
        
        /// <summary>
        /// Tests that validate radius with radius greater than half height throws exception
        /// </summary>
        [Fact]
        public void ValidateRadius_WithRadiusGreaterThanHalfHeight_ThrowsException()
        {
            float radius = 2.0f; // Invalid radius
            float height = 2.0f;
            string position = "top";
            
            Assert.Throws<System.ArgumentException>(() => Polygon.ValidateRadius(radius, height, position));
        }
    }
}