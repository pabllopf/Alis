// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CollidePolygonTest.cs
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
using Alis.Core.Physic.Collision.NarrowPhase;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.NarrowPhase
{
    /// <summary>
    ///     The collide polygon test class
    /// </summary>
    public class CollidePolygonTest
    {
        /// <summary>
        /// Tests that collide polygons should collide correctly
        /// </summary>
        [Fact]
        public void CollidePolygons_ShouldCollideCorrectly()
        {
            // Arrange
            Manifold manifold = new Manifold();
            PolygonShape polyA = new PolygonShape(
                new Vertices()
                {
                    new Vector2(0, 0),
                    new Vector2(0, 1),
                    new Vector2(1, 1),
                    new Vector2(1, 0)
                }, 4);
            Transform xfA = new Transform();
            PolygonShape polyB = new PolygonShape(
                new Vertices()
                {
                    new Vector2(0, 0),
                    new Vector2(0, 1),
                    new Vector2(1, 1),
                    new Vector2(1, 0)
                }, 4);
            Transform xfB = new Transform();
            
            // Act
            Assert.Throws<NullReferenceException>(() => CollidePolygon.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB));
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that find max separation should find correctly
        /// </summary>
        [Fact]
        public void FindMaxSeparation_ShouldFindCorrectly()
        {
            // Arrange
            PolygonShape poly1 = new PolygonShape(
                new Vertices()
                {
                    new Vector2(0, 0),
                    new Vector2(0, 1),
                    new Vector2(1, 1),
                    new Vector2(1, 0)
                }, 4);
            Transform xf1 = new Transform();
            PolygonShape poly2 = new PolygonShape(
                new Vertices()
                {
                    new Vector2(0, 0),
                    new Vector2(0, 1),
                    new Vector2(1, 1),
                    new Vector2(1, 0)
                }, 4);
            Transform xf2 = new Transform();
            
            // Act
            float result = CollidePolygon.FindMaxSeparation(out int edgeIndex, poly1, ref xf1, poly2, ref xf2);
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that find incident edge should find correctly
        /// </summary>
        [Fact]
        public void FindIncidentEdge_ShouldFindCorrectly()
        {
            // Arrange
            PolygonShape poly1 = new PolygonShape(
                new Vertices()
                {
                    new Vector2(0, 0),
                    new Vector2(0, 1),
                    new Vector2(1, 1),
                    new Vector2(1, 0)
                }, 4);
            Transform xf1 = new Transform();
            int edge1 = 0;
            PolygonShape poly2 = new PolygonShape(
                new Vertices()
                {
                    new Vector2(0, 0),
                    new Vector2(0, 1),
                    new Vector2(1, 1),
                    new Vector2(1, 0)
                }, 4);
            Transform xf2 = new Transform();
            
            // Act
            CollidePolygon.FindIncidentEdge(out ClipVertex[] c, poly1, ref xf1, edge1, poly2, ref xf2);
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
    }
}