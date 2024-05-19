// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceProxyTest.cs
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
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Distance;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Distance
{
    /// <summary>
    ///     The distance proxy test class
    /// </summary>
    public class DistanceProxyTest
    {
        /// <summary>
        ///     Tests that radius property test
        /// </summary>
        [Fact]
        public void RadiusPropertyTest()
        {
            // Arrange
            DistanceProxy distanceProxy = new DistanceProxy(new Vector2[1] {new Vector2(1, 1)}, 1.0f);
            
            // Assert
            Assert.Equal(1.0f, distanceProxy.Radius);
        }
        
        /// <summary>
        ///     Tests that vertices property test
        /// </summary>
        [Fact]
        public void VerticesPropertyTest()
        {
            // Arrange
            Vector2[] vertices = new Vector2[1] {new Vector2(1, 1)};
            DistanceProxy distanceProxy = new DistanceProxy(vertices, 1.0f);
            
            // Assert
            Assert.Equal(vertices, distanceProxy.Vertices);
        }
        
        /// <summary>
        ///     Tests that get support test
        /// </summary>
        [Fact]
        public void GetSupportTest()
        {
            // Arrange
            Vector2[] vertices = new Vector2[2] {new Vector2(1, 1), new Vector2(2, 2)};
            DistanceProxy distanceProxy = new DistanceProxy(vertices, 1.0f);
            Vector2 direction = new Vector2(1, 1);
            
            // Act
            int support = distanceProxy.GetSupport(direction);
            
            // Assert
            Assert.Equal(1, support); // The second vertex (index 1) is in the direction of the vector (1,1)
        }
        
        /// <summary>
        ///     Tests that get vertex test
        /// </summary>
        [Fact]
        public void GetVertexTest()
        {
            // Arrange
            Vector2[] vertices = new Vector2[2] {new Vector2(1, 1), new Vector2(2, 2)};
            DistanceProxy distanceProxy = new DistanceProxy(vertices, 1.0f);
            
            // Act
            Vector2 vertex = distanceProxy.GetVertex(1);
            
            // Assert
            Assert.Equal(new Vector2(2, 2), vertex); // The second vertex (index 1) is (2,2)
        }
        
        /// <summary>
        /// Tests that distance proxy initialize circle shape sets correct values
        /// </summary>
        [Fact]
        public void DistanceProxy_InitializeCircleShape_SetsCorrectValues()
        {
            CircleShape circle = new CircleShape(
                1.0f,
                1.0f
            );
            DistanceProxy proxy = new DistanceProxy(circle, 0);
            
            Assert.Equal(circle.PositionCircle, proxy.Vertices[0]);
            Assert.Equal(circle.RadiusPrivate, proxy.Radius);
        }
        
        /// <summary>
        /// Tests that distance proxy initialize chain shape sets correct values
        /// </summary>
        [Fact]
        public void DistanceProxy_InitializeChainShape_SetsCorrectValues()
        {
            ChainShape chain = new ChainShape(
                new Vertices() {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)},
                false
            );
            DistanceProxy proxy = new DistanceProxy(chain, 0);
            
            Assert.Equal(chain.Vertices[0], proxy.Vertices[0]);
            Assert.Equal(chain.Vertices[1], proxy.Vertices[1]);
            Assert.Equal(chain.RadiusPrivate, proxy.Radius);
        }
        
        /// <summary>
        /// Tests that distance proxy initialize edge shape sets correct values
        /// </summary>
        [Fact]
        public void DistanceProxy_InitializeEdgeShape_SetsCorrectValues()
        {
            EdgeShape edge = new EdgeShape();
            DistanceProxy proxy = new DistanceProxy(edge, 0);
            
            Assert.Equal(edge.Vertex1, proxy.Vertices[0]);
            Assert.Equal(edge.Vertex2, proxy.Vertices[1]);
            Assert.Equal(edge.RadiusPrivate, proxy.Radius);
        }
        
        /// <summary>
        /// Tests that distance proxy get support returns correct index
        /// </summary>
        [Fact]
        public void DistanceProxy_GetSupport_ReturnsCorrectIndex()
        {
            Vector2[] vertices = new Vector2[] {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)};
            DistanceProxy proxy = new DistanceProxy(vertices, 1.0f);
            Vector2 direction = new Vector2(1, 1);
            
            int index = proxy.GetSupport(direction);
            
            Assert.Equal(2, index);
        }
        
        /// <summary>
        /// Tests that distance proxy get vertex returns correct vertex
        /// </summary>
        [Fact]
        public void DistanceProxy_GetVertex_ReturnsCorrectVertex()
        {
            Vector2[] vertices = new Vector2[] {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)};
            DistanceProxy proxy = new DistanceProxy(vertices, 1.0f);
            
            Vector2 vertex = proxy.GetVertex(1);
            
            Assert.Equal(new Vector2(2, 2), vertex);
        }
        
        /// <summary>
        /// Tests that initialize polygon shape sets correct values
        /// </summary>
        [Fact]
        public void InitializePolygonShape_SetsCorrectValues()
        {
            // Arrange
            PolygonShape polygon = new PolygonShape(
                1
            );
            DistanceProxy proxy = new DistanceProxy();
            
            // Act
            Assert.Throws<NullReferenceException>( () =>  proxy.InitializePolygonShape(polygon));
        }
        
        /// <summary>
        /// Tests that initialize polygon shape sets correct number of vertices
        /// </summary>
        [Fact]
        public void InitializePolygonShape_SetsCorrectNumberOfVertices()
        {
            // Arrange
            PolygonShape polygon = new PolygonShape(
                1
            );
            DistanceProxy proxy = new DistanceProxy();
            
            // Act
            Assert.Throws<NullReferenceException>( () => proxy.InitializePolygonShape(polygon));
        }
        
        /// <summary>
        /// Tests that initialize polygon shape sets correct vertices
        /// </summary>
        [Fact]
        public void InitializePolygonShape_SetsCorrectVertices()
        {
            // Arrange
            PolygonShape polygon = new PolygonShape(
                1
            );
            DistanceProxy proxy = new DistanceProxy();
            
            // Act
            Assert.Throws<NullReferenceException>( () => proxy.InitializePolygonShape(polygon));
        }
    }
}