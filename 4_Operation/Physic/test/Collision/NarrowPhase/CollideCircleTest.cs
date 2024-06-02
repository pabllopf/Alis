// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CollideCircleTest.cs
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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.NarrowPhase;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Test.Collision.BroadPhase.Sample;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.NarrowPhase
{
    /// <summary>
    ///     The collide circle test class
    /// </summary>
    public class CollideCircleTest
    {
        /// <summary>
        ///     Tests that test collide circles method
        /// </summary>
        [Fact]
        public void Test_CollideCirclesMethod()
        {
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            // Arrange
            Manifold manifold = new Manifold();
            CircleShape circleA = new CircleShape(1);
            Transform transformA = new Transform();
            CircleShape circleB = new CircleShape(1);
            Transform transformB = new Transform();
            
            // Act
            Assert.Throws<NullReferenceException>(() => CollideCircle.CollideCircles(ref manifold, circleA, ref transformA, circleB, ref transformB));
            
            // Assert
        }
        
        /// <summary>
        ///     Tests that test collide polygon and circle method
        /// </summary>
        [Fact]
        public void Test_CollidePolygonAndCircleMethod()
        {
            // Arrange
            Manifold manifold = new Manifold();
            PolygonShape polygonA = new PolygonShape(1);
            Transform transformA = new Transform();
            CircleShape circleB = new CircleShape(1);
            Transform transformB = new Transform();
            
            // Act
            Assert.Throws<NullReferenceException>(() => CollideCircle.CollidePolygonAndCircle(ref manifold, polygonA, ref transformA, circleB, ref transformB));
            
            // Assert
        }
        
        /// <summary>
        /// Tests that is center inside polygon should return correct value
        /// </summary>
        [Fact]
        public void IsCenterInsidePolygon_ShouldReturnCorrectValue()
        {
            // Arrange
            float separation = 0.0f;
            Vector2 v1 = new Vector2();
            Vector2 v2 = new Vector2();
            Vertices normals = new Vertices();
            int normalIndex = 0;
            Vector2 circleBPosition = new Vector2();
            Manifold manifold = new Manifold();
            
            // Act
            Assert.Throws<ArgumentOutOfRangeException>(() => CollideCircle.IsCenterInsidePolygon(separation, v1, v2, normals, normalIndex, circleBPosition, ref manifold));
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that compute barycentric coordinates should compute correctly
        /// </summary>
        [Fact]
        public void ComputeBarycentricCoordinates_ShouldComputeCorrectly()
        {
            // Arrange
            Vector2 cLocal = new Vector2();
            Vector2 v1 = new Vector2();
            Vector2 v2 = new Vector2();
            float radius = 0.0f;
            Vector2 circleBPosition = new Vector2();
            Manifold manifold = new Manifold();
            Vertices normals = new Vertices();
            int vertIndex1 = 0;
            
            // Act
            Assert.Throws<NullReferenceException>(() => CollideCircle.ComputeBarycentricCoordinates(cLocal, v1, v2, radius, circleBPosition, ref manifold, normals, vertIndex1));
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that set manifold for vertex should set correctly
        /// </summary>
        [Fact]
        public void SetManifoldForVertex_ShouldSetCorrectly()
        {
            // Arrange
            Manifold manifold = new Manifold();
            Vector2 cLocal = new Vector2();
            Vector2 vertex = new Vector2();
            Vector2 circleBPosition = new Vector2();
            
            // Act
            Assert.Throws<NullReferenceException>(() => CollideCircle.SetManifoldForVertex(ref manifold, cLocal, vertex, circleBPosition));
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that find min separating edge should return correct value
        /// </summary>
        [Fact]
        public void FindMinSeparatingEdge_ShouldReturnCorrectValue()
        {
            // Arrange
            Vector2 cLocal = new Vector2();
            float radius = 0.0f;
            int vertexCount = 0;
            Vertices vertices = new Vertices();
            Vertices normals = new Vertices();
            int expectedValue = 0; // Replace with actual expected value
            
            // Act
            int result = CollideCircle.FindMinSeparatingEdge(cLocal, radius, vertexCount, vertices, normals);
            
            // Assert
            Assert.Equal(expectedValue, result);
        }
    }
}