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

using System.Collections.Generic;
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
            AShape result = chainShape.Clone();
            
            // Assert
            Assert.NotNull(result);
            Assert.IsType<ChainShape>(result);
        }
        
        /// <summary>
        /// Tests that ray cast returns false when ray does not intersect edge
        /// </summary>
        [Fact]
        public void RayCast_ReturnsFalse_WhenRayDoesNotIntersectEdge()
        {
            ChainShape chainShape = new ChainShape(new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)}));
            RayCastInput input = new RayCastInput {Point1 = new Vector2(-1, -1), Point2 = new Vector2(-2, -2)};
            Transform transform = new Transform();
            int childIndex = 0;
            RayCastOutput output;
            
            bool result = chainShape.RayCast(ref input, ref transform, childIndex, out output);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that ray cast returns true when ray intersects edge
        /// </summary>
        [Fact]
        public void RayCast_ReturnsTrue_WhenRayIntersectsEdge()
        {
            ChainShape chainShape = new ChainShape(new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)}));
            RayCastInput input = new RayCastInput {Point1 = new Vector2(0, 0), Point2 = new Vector2(1, 1)};
            Transform transform = new Transform();
            int childIndex = 0;
            RayCastOutput output;
            
            bool result = chainShape.RayCast(ref input, ref transform, childIndex, out output);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that ray cast sets output correctly when ray intersects edge
        /// </summary>
        [Fact]
        public void RayCast_SetsOutputCorrectly_WhenRayIntersectsEdge()
        {
            ChainShape chainShape = new ChainShape(new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)}));
            RayCastInput input = new RayCastInput {Point1 = new Vector2(0, 0), Point2 = new Vector2(1, 1)};
            Transform transform = new Transform();
            int childIndex = 0;
            RayCastOutput output;
            
            bool result = chainShape.RayCast(ref input, ref transform, childIndex, out output);
            
            Assert.Equal(0, output.Fraction);
            Assert.Equal(new Vector2(0, 0), output.Normal);
        }
        
        /// <summary>
        /// Tests that chain shape constructor sets vertices correctly
        /// </summary>
        [Fact]
        public void ChainShape_Constructor_SetsVerticesCorrectly()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            ChainShape chainShape = new ChainShape(vertices);
            
            Assert.Equal(vertices, chainShape.Vertices);
        }
        
        /// <summary>
        /// Tests that chain shape constructor sets prev and next vertices correctly when create loop is true
        /// </summary>
        [Fact]
        public void ChainShape_Constructor_SetsPrevAndNextVerticesCorrectly_WhenCreateLoopIsTrue()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            ChainShape chainShape = new ChainShape(vertices, true);
            
            Assert.Equal(new Vector2(0, 1), chainShape.PrevVertex);
        }
        
        /// <summary>
        /// Tests that chain shape constructor does not set prev and next vertices when create loop is false
        /// </summary>
        [Fact]
        public void ChainShape_Constructor_DoesNotSetPrevAndNextVertices_WhenCreateLoopIsFalse()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            ChainShape chainShape = new ChainShape(vertices, false);
            
            Assert.Equal(Vector2.Zero, chainShape.PrevVertex);
            Assert.Equal(Vector2.Zero, chainShape.NextVertex);
        }
        
        /// <summary>
        /// Tests that chain shape constructor calls compute properties
        /// </summary>
        [Fact]
        public void ChainShape_Constructor_CallsComputeProperties()
        {
            Vertices vertices = new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)});
            ChainShape chainShape = new ChainShape(vertices);
            
            // Here you would assert that the properties of chainShape have been set correctly.
            // For example, if ComputeProperties sets a property called Area, you could do:
            // Assert.Equal(expectedArea, chainShape.Area);
        }
        
        /// <summary>
        /// Tests that compute aabb sets aabb correctly when child index is less than vertices count minus one
        /// </summary>
        [Fact]
        public void ComputeAabb_SetsAabbCorrectly_WhenChildIndexIsLessThanVerticesCountMinusOne()
        {
            ChainShape chainShape = new ChainShape(new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)}));
            Transform transform = new Transform();
            int childIndex = 0;
            Aabb aabb;
            
            chainShape.ComputeAabb(ref transform, childIndex, out aabb);
            
            Assert.Equal(new Vector2(-0.01F, -0.01F), aabb.LowerBound);
            Assert.Equal(new Vector2(0.01F, 0.01F), aabb.UpperBound);
        }
        
        /// <summary>
        /// Tests that compute aabb sets aabb correctly when child index is vertices count minus one
        /// </summary>
        [Fact]
        public void ComputeAabb_SetsAabbCorrectly_WhenChildIndexIsVerticesCountMinusOne()
        {
            ChainShape chainShape = new ChainShape(new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)}));
            Transform transform = new Transform();
            int childIndex = chainShape.Vertices.Count - 1;
            Aabb aabb;
            
            chainShape.ComputeAabb(ref transform, childIndex, out aabb);
            
            Assert.Equal(new Vector2(-0.01F, -0.01F), aabb.LowerBound);
            Assert.Equal(new Vector2(0.01F, 0.01F), aabb.UpperBound);
        }
        
        /// <summary>
        /// Tests that ray cast returns false when ray does not intersect edge v 3
        /// </summary>
        [Fact]
        public void RayCast_ReturnsFalse_WhenRayDoesNotIntersectEdge_V3()
        {
            ChainShape chainShape = new ChainShape(new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)}));
            RayCastInput input = new RayCastInput {Point1 = new Vector2(-1, -1), Point2 = new Vector2(-2, -2)};
            Transform transform = new Transform();
            int childIndex = 0;
            RayCastOutput output;
            
            bool result = chainShape.RayCast(ref input, ref transform, childIndex, out output);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that ray cast returns true when ray intersects edge v 3
        /// </summary>
        [Fact]
        public void RayCast_ReturnsTrue_WhenRayIntersectsEdge_V3()
        {
            ChainShape chainShape = new ChainShape(new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)}));
            RayCastInput input = new RayCastInput {Point1 = new Vector2(0, 0), Point2 = new Vector2(1, 1)};
            Transform transform = new Transform();
            int childIndex = 0;
            RayCastOutput output;
            
            bool result = chainShape.RayCast(ref input, ref transform, childIndex, out output);
            
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that ray cast sets output correctly when ray intersects edge v 2
        /// </summary>
        [Fact]
        public void RayCast_SetsOutputCorrectly_WhenRayIntersectsEdge_V2()
        {
            ChainShape chainShape = new ChainShape(new Vertices(new List<Vector2> {new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1)}));
            RayCastInput input = new RayCastInput {Point1 = new Vector2(0, 0), Point2 = new Vector2(1, 1)};
            Transform transform = new Transform();
            int childIndex = 0;
            RayCastOutput output;
            
            bool result = chainShape.RayCast(ref input, ref transform, childIndex, out output);
            
            Assert.Equal(0f, output.Fraction);
            Assert.Equal(new Vector2(0, 0), output.Normal);
        }
    }
}