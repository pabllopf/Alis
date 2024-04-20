// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EdgeShapeTest.cs
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
    /// The edge shape test class
    /// </summary>
    public class EdgeShapeTest
    {
        /// <summary>
        /// Tests that test child count property
        /// </summary>
        [Fact]
        public void Test_ChildCountProperty()
        {
            // Arrange
            EdgeShape edgeShape = new EdgeShape(new Vector2(1, 1), new Vector2(2, 2));
            
            // Act
            int result = edgeShape.ChildCount;
            
            // Assert
            Assert.Equal(1, result);
        }
        
        /// <summary>
        /// Tests that test one sided property
        /// </summary>
        [Fact]
        public void Test_OneSidedProperty()
        {
            // Arrange
            EdgeShape edgeShape = new EdgeShape(new Vector2(1, 1), new Vector2(2, 2));
            
            // Act
            edgeShape.OneSided = true;
            
            // Assert
            Assert.True(edgeShape.OneSided);
        }
        
        /// <summary>
        /// Tests that test vertex 1 property
        /// </summary>
        [Fact]
        public void Test_Vertex1Property()
        {
            // Arrange
            EdgeShape edgeShape = new EdgeShape(new Vector2(1, 1), new Vector2(2, 2));
            Vector2 expectedValue = new Vector2(3, 3);
            
            // Act
            edgeShape.Vertex1 = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, edgeShape.Vertex1);
        }
        
        /// <summary>
        /// Tests that test vertex 2 property
        /// </summary>
        [Fact]
        public void Test_Vertex2Property()
        {
            // Arrange
            EdgeShape edgeShape = new EdgeShape(new Vector2(1, 1), new Vector2(2, 2));
            Vector2 expectedValue = new Vector2(4, 4);
            
            // Act
            edgeShape.Vertex2 = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, edgeShape.Vertex2);
        }
        
        /// <summary>
        /// Tests that test set one sided method
        /// </summary>
        [Fact]
        public void Test_SetOneSidedMethod()
        {
            // Arrange
            EdgeShape edgeShape = new EdgeShape(new Vector2(1, 1), new Vector2(2, 2));
            Vector2 v0 = new Vector2(0, 0);
            Vector2 v1 = new Vector2(1, 1);
            Vector2 v2 = new Vector2(2, 2);
            Vector2 v3 = new Vector2(3, 3);
            
            // Act
            edgeShape.SetOneSided(v0, v1, v2, v3);
            
            // Assert
            Assert.True(edgeShape.OneSided);
            Assert.Equal(v0, edgeShape.Vertex0);
            Assert.Equal(v1, edgeShape.Vertex1);
            Assert.Equal(v2, edgeShape.Vertex2);
            Assert.Equal(v3, edgeShape.Vertex3);
        }
        
        /// <summary>
        /// Tests that test set two sided method
        /// </summary>
        [Fact]
        public void Test_SetTwoSidedMethod()
        {
            // Arrange
            EdgeShape edgeShape = new EdgeShape(new Vector2(1, 1), new Vector2(2, 2));
            Vector2 start = new Vector2(0, 0);
            Vector2 end = new Vector2(3, 3);
            
            // Act
            edgeShape.SetTwoSided(start, end);
            
            // Assert
            Assert.False(edgeShape.OneSided);
            Assert.Equal(start, edgeShape.Vertex1);
            Assert.Equal(end, edgeShape.Vertex2);
        }
        
        /// <summary>
        /// Tests that test test point method
        /// </summary>
        [Fact]
        public void Test_TestPointMethod()
        {
            // Arrange
            EdgeShape edgeShape = new EdgeShape(new Vector2(1, 1), new Vector2(2, 2));
            Transform transform = new Transform();
            Vector2 point = new Vector2(1, 1);
            
            // Act
            bool result = edgeShape.TestPoint(ref transform, ref point);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that test ray cast method
        /// </summary>
        [Fact]
        public void Test_RayCastMethod()
        {
            // Arrange
            EdgeShape edgeShape = new EdgeShape(new Vector2(1, 1), new Vector2(2, 2));
            RayCastInput input = new RayCastInput();
            Transform transform = new Transform();
            RayCastOutput output;
            
            // Act
            bool result = edgeShape.RayCast(ref input, ref transform, 0, out output);
            
            // Assert
            // Add your assertions here based on what you expect from RayCast
        }
        
        /// <summary>
        /// Tests that test compute aabb method
        /// </summary>
        [Fact]
        public void Test_ComputeAabbMethod()
        {
            // Arrange
            EdgeShape edgeShape = new EdgeShape(new Vector2(1, 1), new Vector2(2, 2));
            Transform transform = new Transform();
            Aabb aabb;
            
            // Act
            edgeShape.ComputeAabb(ref transform, 0, out aabb);
            
            // Assert
            // Add your assertions here based on what you expect from ComputeAabb
        }
        
        /// <summary>
        /// Tests that test clone method
        /// </summary>
        [Fact]
        public void Test_CloneMethod()
        {
            // Arrange
            EdgeShape edgeShape = new EdgeShape(new Vector2(1, 1), new Vector2(2, 2));
            
            // Act
            Shape result = edgeShape.Clone();
            
            // Assert
            Assert.NotNull(result);
            Assert.IsType<EdgeShape>(result);
        }
    }
}