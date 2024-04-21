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
using Alis.Core.Physic.Collision.NarrowPhase;
using Alis.Core.Physic.Collision.Shapes;
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
            // Arrange
            Manifold manifold = new Manifold();
            CircleShape circleA = new CircleShape(1);
            Transform transformA = new Transform();
            CircleShape circleB = new CircleShape(1);
            Transform transformB = new Transform();
            
            // Act
            CollideCircle.CollideCircles(ref manifold, circleA, ref transformA, circleB, ref transformB);
            
            // Assert
            // Add your assertions here based on what you expect after calling CollideCircles
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
            // Add your assertions here based on what you expect after calling CollidePolygonAndCircle
        }
    }
}