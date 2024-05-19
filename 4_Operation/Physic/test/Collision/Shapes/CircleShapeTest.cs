// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CircleShapeTest.cs
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

using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Shapes
{
    /// <summary>
    ///     The circle shape test class
    /// </summary>
    public class CircleShapeTest
    {
        /// <summary>
        ///     Tests that test child count property
        /// </summary>
        [Fact]
        public void Test_ChildCountProperty()
        {
            // Arrange
            CircleShape circleShape = new CircleShape(1.0f, 1.0f, new Vector2(1, 1));
            
            // Act
            int result = circleShape.ChildCount;
            
            // Assert
            Assert.Equal(1, result);
        }
        
        /// <summary>
        ///     Tests that test position property
        /// </summary>
        [Fact]
        public void Test_PositionProperty()
        {
            // Arrange
            CircleShape circleShape = new CircleShape(1.0f, 1.0f, new Vector2(1, 1));
            Vector2 expectedValue = new Vector2(2, 2);
            
            // Act
            circleShape.Position = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, circleShape.Position);
        }
        
        /// <summary>
        ///     Tests that test test point method
        /// </summary>
        [Fact]
        public void Test_TestPointMethod()
        {
            // Arrange
            CircleShape circleShape = new CircleShape(1.0f, 1.0f, new Vector2(1, 1));
            Transform transform = new Transform();
            Vector2 point = new Vector2(1, 1);
            
            // Act
            bool result = circleShape.TestPoint(ref transform, ref point);
            
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
            CircleShape circleShape = new CircleShape(1.0f, 1.0f, new Vector2(1, 1));
            RayCastInput input = new RayCastInput();
            Transform transform = new Transform();
            RayCastOutput output;
            
            // Act
            bool result = circleShape.RayCast(ref input, ref transform, 0, out output);
            
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
            CircleShape circleShape = new CircleShape(1.0f, 1.0f, new Vector2(1, 1));
            Transform transform = new Transform();
            Aabb aabb;
            
            // Act
            circleShape.ComputeAabb(ref transform, 0, out aabb);
            
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
            CircleShape circleShape = new CircleShape(1.0f, 1.0f, new Vector2(1, 1));
            
            // Act
            AShape result = circleShape.Clone();
            
            // Assert
            Assert.NotNull(result);
            Assert.IsType<CircleShape>(result);
        }
    }
}