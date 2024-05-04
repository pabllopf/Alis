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

using System;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Shapes
{
    /// <summary>
    ///     The polygon shape test class
    /// </summary>
    public class PolygonShapeTest
    {
        /// <summary>
        ///     Tests that test vertices property
        /// </summary>
        [Fact]
        public void Test_VerticesProperty()
        {
            // Arrange
            PolygonShape polygonShape = new PolygonShape(1.0f);
            Vertices expectedValue = new Vertices {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)};
            
            // Act
            Assert.Throws<InvalidOperationException>(() => polygonShape.Vertices = expectedValue);
        }
        
        /// <summary>
        ///     Tests that test normals property
        /// </summary>
        [Fact]
        public void Test_NormalsProperty()
        {
            // Arrange
            PolygonShape polygonShape = new PolygonShape(1.0f);
            Vertices expectedValue = new Vertices {new Vector2(1, 0), new Vector2(0, 1), new Vector2(-1, 0), new Vector2(0, -1)};
            
            // Act
            // Normals are calculated based on the vertices, so we set the vertices first
            Assert.Throws<InvalidOperationException>(() => polygonShape.Vertices = new Vertices {new Vector2(1, 1), new Vector2(2, 2), new Vector2(3, 3)});
        }
        
        /// <summary>
        ///     Tests that test child count property
        /// </summary>
        [Fact]
        public void Test_ChildCountProperty()
        {
            // Arrange
            PolygonShape polygonShape = new PolygonShape(1.0f);
            
            // Act
            int result = polygonShape.ChildCount;
            
            // Assert
            Assert.Equal(1, result);
        }
        
        /// <summary>
        ///     Tests that test set as box method
        /// </summary>
        [Fact]
        public void Test_SetAsBoxMethod()
        {
            // Arrange
            PolygonShape polygonShape = new PolygonShape(1.0f);
            float hx = 1.0f, hy = 2.0f;
            Vector2 center = new Vector2(1, 1);
            float angle = CustomMathF.Pi / 4;
            
            // Act
            polygonShape.SetAsBox(hx, hy, center, angle);
            
            // Assert
            // Add your assertions here based on what you expect after calling SetAsBox
        }
        
        /// <summary>
        ///     Tests that test test point method
        /// </summary>
        [Fact]
        public void Test_TestPointMethod()
        {
            // Arrange
            PolygonShape polygonShape = new PolygonShape(1.0f);
            Transform transform = new Transform();
            Vector2 point = new Vector2(1, 1);
            
            // Act
            Assert.Throws<NullReferenceException>(() => polygonShape.TestPoint(ref transform, ref point));
            
            // Assert
            // Add your assertions here based on what you expect from TestPoint
        }
        
        /// <summary>
        ///     Tests that test ray cast method
        /// </summary>
        [Fact]
        public void Test_RayCastMethod()
        {
            // Arrange
            PolygonShape polygonShape = new PolygonShape(1.0f);
            RayCastInput input = new RayCastInput();
            Transform transform = new Transform();
            RayCastOutput output;
            
            // Act
            Assert.Throws<NullReferenceException>(() => polygonShape.RayCast(ref input, ref transform, 0, out output));
            
            // Assert
            // Add your assertions here based on what you expect from RayCast
        }
        
        /// <summary>
        ///     Tests that test compute aabb method
        /// </summary>
        [Fact]
        public void Test_ComputeAabbMethod()
        {
            // Arrange
            PolygonShape polygonShape = new PolygonShape(1.0f);
            Transform transform = new Transform();
            Aabb aabb;
            
            // Act
            Assert.Throws<NullReferenceException>(() => polygonShape.ComputeAabb(ref transform, 0, out aabb));
            
            // Assert
            // Add your assertions here based on what you expect from ComputeAabb
        }
        
        /// <summary>
        ///     Tests that test clone method
        /// </summary>
        [Fact]
        public void Test_CloneMethod()
        {
            // Arrange
            PolygonShape polygonShape = new PolygonShape(1.0f);
            
            // Act
            Assert.Throws<ArgumentNullException>(() => polygonShape.Clone());
        }
    }
}