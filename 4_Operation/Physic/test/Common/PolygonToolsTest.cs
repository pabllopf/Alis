// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonToolsTest.cs
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
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Common
{
    /// <summary>
    ///     The polygon tools test class
    /// </summary>
    public class PolygonToolsTest
    {
        /// <summary>
        ///     Tests that create rectangle should create four vertices
        /// </summary>
        [Fact]
        public void CreateRectangle_ShouldCreateFourVertices()
        {
            Vertices vertices = PolygonTools.CreateRectangle(5.0f, 3.0f);
            
            Assert.Equal(4, vertices.Count);
        }

        /// <summary>
        ///     Tests that create rectangle should have correct dimensions
        /// </summary>
        [Fact]
        public void CreateRectangle_ShouldHaveCorrectDimensions()
        {
            float hx = 5.0f;
            float hy = 3.0f;
            
            Vertices vertices = PolygonTools.CreateRectangle(hx, hy);
            
            Assert.Equal(new Vector2F(-hx, -hy), vertices[0]);
            Assert.Equal(new Vector2F(hx, -hy), vertices[1]);
            Assert.Equal(new Vector2F(hx, hy), vertices[2]);
            Assert.Equal(new Vector2F(-hx, hy), vertices[3]);
        }

        /// <summary>
        ///     Tests that create rectangle with transform should create rotated rectangle
        /// </summary>
        [Fact]
        public void CreateRectangleWithTransform_ShouldCreateRotatedRectangle()
        {
            Vector2F center = new Vector2F(10, 10);
            float angle = (float)Math.PI / 4; // 45 degrees
            
            Vertices vertices = PolygonTools.CreateRectangle(5.0f, 3.0f, center, angle);
            
            Assert.Equal(4, vertices.Count);
        }

        /// <summary>
        ///     Tests that create line should create two vertices
        /// </summary>
        [Fact]
        public void CreateLine_ShouldCreateTwoVertices()
        {
            Vector2F start = new Vector2F(0, 0);
            Vector2F end = new Vector2F(10, 0);
            
            Vertices vertices = PolygonTools.CreateLine(start, end);
            
            Assert.Equal(2, vertices.Count);
            Assert.Equal(start, vertices[0]);
            Assert.Equal(end, vertices[1]);
        }

        /// <summary>
        ///     Tests that create circle should create vertices with specified edges
        /// </summary>
        [Fact]
        public void CreateCircle_ShouldCreateVerticesWithSpecifiedEdges()
        {
            float radius = 5.0f;
            int edges = 16;
            
            Vertices vertices = PolygonTools.CreateCircle(radius, edges);
            
            Assert.Equal(edges, vertices.Count);
        }

        /// <summary>
        ///     Tests that create circle should have vertices at correct radius
        /// </summary>
        [Fact]
        public void CreateCircle_ShouldHaveVerticesAtCorrectRadius()
        {
            float radius = 5.0f;
            int edges = 8;
            
            Vertices vertices = PolygonTools.CreateCircle(radius, edges);
            
            foreach (Vector2F vertex in vertices)
            {
                float distance = vertex.Length();
                Assert.True(Math.Abs(distance - radius) < 0.01f);
            }
        }

        /// <summary>
        ///     Tests that create ellipse should create vertices with specified edges
        /// </summary>
        [Fact]
        public void CreateEllipse_ShouldCreateVerticesWithSpecifiedEdges()
        {
            float xRadius = 5.0f;
            float yRadius = 3.0f;
            int edges = 16;
            
            Vertices vertices = PolygonTools.CreateEllipse(xRadius, yRadius, edges);
            
            Assert.Equal(edges, vertices.Count);
        }

        /// <summary>
        ///     Tests that create rounded rectangle should create vertices
        /// </summary>
        [Fact]
        public void CreateRoundedRectangle_ShouldCreateVertices()
        {
            float width = 10.0f;
            float height = 6.0f;
            float xRadius = 1.0f;
            float yRadius = 1.0f;
            int segments = 2;
            
            Vertices vertices = PolygonTools.CreateRoundedRectangle(width, height, xRadius, yRadius, segments);
            
            Assert.NotEmpty(vertices);
        }

        /// <summary>
        ///     Tests that create rounded rectangle should throw exception when radius too large
        /// </summary>
        [Fact]
        public void CreateRoundedRectangle_ShouldThrowException_WhenRadiusTooLarge()
        {
            float width = 10.0f;
            float height = 6.0f;
            float xRadius = 10.0f; // Too large
            float yRadius = 1.0f;
            
            Assert.Throws<Exception>(() => PolygonTools.CreateRoundedRectangle(width, height, xRadius, yRadius, 2));
        }

        /// <summary>
        ///     Tests that create rounded rectangle should throw exception when negative segments
        /// </summary>
        [Fact]
        public void CreateRoundedRectangle_ShouldThrowException_WhenNegativeSegments()
        {
            Assert.Throws<Exception>(() => PolygonTools.CreateRoundedRectangle(10.0f, 6.0f, 1.0f, 1.0f, -1));
        }

        /// <summary>
        ///     Tests that create rounded rectangle with zero segments should create basic shape
        /// </summary>
        [Fact]
        public void CreateRoundedRectangle_WithZeroSegments_ShouldCreateBasicShape()
        {
            Vertices vertices = PolygonTools.CreateRoundedRectangle(10.0f, 6.0f, 1.0f, 1.0f, 0);
            
            Assert.Equal(8, vertices.Count);
        }

        /// <summary>
        ///     Tests that create rectangle should handle zero dimensions
        /// </summary>
        [Fact]
        public void CreateRectangle_ShouldHandleZeroDimensions()
        {
            Vertices vertices = PolygonTools.CreateRectangle(0.0f, 0.0f);
            
            Assert.Equal(4, vertices.Count);
            Assert.All(vertices, v => Assert.Equal(Vector2F.Zero, v));
        }

        /// <summary>
        ///     Tests that create circle should handle minimum edges
        /// </summary>
        [Fact]
        public void CreateCircle_ShouldHandleMinimumEdges()
        {
            Vertices vertices = PolygonTools.CreateCircle(5.0f, 3);
            
            Assert.Equal(3, vertices.Count);
        }

        /// <summary>
        ///     Tests that create ellipse should handle different radii
        /// </summary>
        [Fact]
        public void CreateEllipse_ShouldHandleDifferentRadii()
        {
            Vertices vertices = PolygonTools.CreateEllipse(10.0f, 5.0f, 16);
            
            Assert.Equal(16, vertices.Count);
        }

        /// <summary>
        ///     Tests that create rectangle with negative dimensions should work
        /// </summary>
        [Fact]
        public void CreateRectangle_WithNegativeDimensions_ShouldWork()
        {
            Vertices vertices = PolygonTools.CreateRectangle(-5.0f, -3.0f);
            
            Assert.Equal(4, vertices.Count);
        }
    }
}

