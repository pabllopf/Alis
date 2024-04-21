// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ChainShapeTest.cs
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
    ///     The chain shape test class
    /// </summary>
    public class ChainShapeTest
    {
        /// <summary>
        ///     Tests that test vertices property
        /// </summary>
        [Fact]
        public void Test_VerticesProperty()
        {
            // Arrange
            ChainShape chainShape = new ChainShape(new Vertices());
            Vertices expectedValue = new Vertices {new Vector2(1, 1), new Vector2(2, 2)};
            
            // Act
            chainShape.Vertices = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, chainShape.Vertices);
        }
        
        /// <summary>
        ///     Tests that test child count property
        /// </summary>
        [Fact]
        public void Test_ChildCountProperty()
        {
            // Arrange
            ChainShape chainShape = new ChainShape(new Vertices {new Vector2(1, 1), new Vector2(2, 2)});
            
            // Act
            int result = chainShape.ChildCount;
            
            // Assert
            Assert.Equal(1, result);
        }
        
        /// <summary>
        ///     Tests that test get child edge method
        /// </summary>
        [Fact]
        public void Test_GetChildEdgeMethod()
        {
            // Arrange
            ChainShape chainShape = new ChainShape(new Vertices {new Vector2(1, 1), new Vector2(2, 2)});
            
            // Act
            EdgeShape result = chainShape.GetChildEdge(0);
            
            // Assert
            Assert.NotNull(result);
        }
        
        /// <summary>
        ///     Tests that test test point method
        /// </summary>
        [Fact]
        public void Test_TestPointMethod()
        {
            // Arrange
            ChainShape chainShape = new ChainShape(new Vertices {new Vector2(1, 1), new Vector2(2, 2)});
            Transform transform = new Transform();
            Vector2 point = new Vector2(1, 1);
            
            // Act
            bool result = chainShape.TestPoint(ref transform, ref point);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        ///     Tests that test ray cast method
        /// </summary>
        [Fact]
        public void Test_RayCastMethod()
        {
            // Arrange
            ChainShape chainShape = new ChainShape(new Vertices {new Vector2(1, 1), new Vector2(2, 2)});
            RayCastInput input = new RayCastInput();
            Transform transform = new Transform();
            RayCastOutput output;
            
            // Act
            bool result = chainShape.RayCast(ref input, ref transform, 0, out output);
            
            // Assert
            Assert.False(result);
        }
        
        /// <summary>
        ///     Tests that test compute aabb method
        /// </summary>
        [Fact]
        public void Test_ComputeAabbMethod()
        {
            // Arrange
            ChainShape chainShape = new ChainShape(new Vertices {new Vector2(1, 1), new Vector2(2, 2)});
            Transform transform = new Transform();
            Aabb aabb;
            
            // Act
            chainShape.ComputeAabb(ref transform, 0, out aabb);
            
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
            ChainShape chainShape = new ChainShape(new Vertices {new Vector2(1, 1), new Vector2(2, 2)});
            
            // Act
            Shape result = chainShape.Clone();
            
            // Assert
            Assert.NotNull(result);
            Assert.IsType<ChainShape>(result);
        }
    }
}