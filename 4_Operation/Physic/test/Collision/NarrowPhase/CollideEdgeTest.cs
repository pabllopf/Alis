// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CollideEdgeTest.cs
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
using Alis.Core.Physic.Collision.NarrowPhase;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.NarrowPhase
{
    /// <summary>
    ///     The collide edge test class
    /// </summary>
    public class CollideEdgeTest
    {
        /// <summary>
        /// Tests that collide edge and circle should collide correctly
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_ShouldCollideCorrectly()
        {
            // Arrange
            Manifold manifold = new Manifold();
            EdgeShape edgeA = new EdgeShape();
            Transform transformA = new Transform();
            CircleShape circleB = new CircleShape(
                1, 1);
            Transform transformB = new Transform();
            
            // Act
            Assert.Throws<NullReferenceException>(() => CollideEdge.CollideEdgeAndCircle(ref manifold, edgeA, ref transformA, circleB, ref transformB));
            
            // Assert
            
        }
        
        /// <summary>
        /// Tests that collide edge and polygon should collide correctly
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_ShouldCollideCorrectly()
        {
            // Arrange
            Manifold manifold = new Manifold();
            EdgeShape edgeA = new EdgeShape();
            Transform transformA = new Transform();
            PolygonShape polygonB = new PolygonShape(
                new Vertices()
                {
                    new Vector2(0, 0),
                    new Vector2(1, 0),
                    new Vector2(1, 1),
                    new Vector2(0, 1)
                }, 4);
            Transform transformB = new Transform();
            
            // Act
            CollideEdge.CollideEdgeAndPolygon(ref manifold, edgeA, ref transformA, polygonB, ref transformB);
            
            // Assert
            
        }
        
        /// <summary>
        /// Tests that collide edge and polygon should collide correctly v 2
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_ShouldCollideCorrectly_v2()
        {
            // Arrange
            Manifold manifold = new Manifold();
            EdgeShape edgeA = new EdgeShape();
            Transform transformA = new Transform();
            PolygonShape polygonB = new PolygonShape(
                new Vertices()
                {
                    new Vector2(0, 0),
                    new Vector2(1, 0),
                    new Vector2(1, 1),
                    new Vector2(0, 1)
                }, 4);
            Transform transformB = new Transform();
            
            // Act
            CollideEdge.CollideEdgeAndPolygon(ref manifold, edgeA, ref transformA, polygonB, ref transformB);
            
            // Assert
            // Replace this with actual assertions
        }
    }
}