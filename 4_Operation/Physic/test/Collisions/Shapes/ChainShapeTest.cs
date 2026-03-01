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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    ///     The chain shape test class
    /// </summary>
    public class ChainShapeTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize correctly
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeCorrectly()
        {
            ChainShape chain = new ChainShape();
            
            Assert.Equal(ShapeType.Chain, chain.ShapeType);
        }

        /// <summary>
        ///     Tests that constructor with vertices should initialize correctly
        /// </summary>
        [Fact]
        public void ConstructorWithVertices_ShouldInitializeCorrectly()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(2, 0)
            };
            
            ChainShape chain = new ChainShape(vertices);
            
            Assert.NotNull(chain.Vertices);
            Assert.Equal(3, chain.Vertices.Count);
        }

        /// <summary>
        ///     Tests that constructor with loop should create closed chain
        /// </summary>
        [Fact]
        public void ConstructorWithLoop_ShouldCreateClosedChain()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(1, 1),
                new Vector2F(0, 1)
            };
            
            ChainShape chain = new ChainShape(vertices, true);
            
            Assert.Equal(5, chain.Vertices.Count); // Should have added first vertex at end
        }

        /// <summary>
        ///     Tests that child count should return vertex count minus one
        /// </summary>
        [Fact]
        public void ChildCount_ShouldReturnVertexCountMinusOne()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(2, 0)
            };
            ChainShape chain = new ChainShape(vertices);
            
            int childCount = chain.ChildCount;
            
            Assert.Equal(2, childCount);
        }

        /// <summary>
        ///     Tests that prev vertex property should set and get correctly
        /// </summary>
        [Fact]
        public void PrevVertexProperty_ShouldSetAndGetCorrectly()
        {
            ChainShape chain = new ChainShape();
            Vector2F prevVertex = new Vector2F(-1, 0);
            
            chain.PrevVertex = prevVertex;
            
            Assert.Equal(prevVertex, chain.PrevVertex);
        }

        /// <summary>
        ///     Tests that next vertex property should set and get correctly
        /// </summary>
        [Fact]
        public void NextVertexProperty_ShouldSetAndGetCorrectly()
        {
            ChainShape chain = new ChainShape();
            Vector2F nextVertex = new Vector2F(10, 0);
            
            chain.NextVertex = nextVertex;
            
            Assert.Equal(nextVertex, chain.NextVertex);
        }

        /// <summary>
        ///     Tests that get child edge should return valid edge shape
        /// </summary>
        [Fact]
        public void GetChildEdge_ShouldReturnValidEdgeShape()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(2, 0)
            };
            ChainShape chain = new ChainShape(vertices);
            
            EdgeShape edge = chain.GetChildEdge(0);
            
            Assert.NotNull(edge);
            Assert.Equal(ShapeType.Edge, edge.ShapeType);
        }

        /// <summary>
        ///     Tests that get child edge should have correct vertices
        /// </summary>
        [Fact]
        public void GetChildEdge_ShouldHaveCorrectVertices()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(2, 0)
            };
            ChainShape chain = new ChainShape(vertices);
            
            EdgeShape edge = chain.GetChildEdge(0);
            
            Assert.Equal(vertices[0], edge.Vertex1);
            Assert.Equal(vertices[1], edge.Vertex2);
        }

        /// <summary>
        ///     Tests that chain shape should handle straight line
        /// </summary>
        [Fact]
        public void ChainShape_ShouldHandleStraightLine()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0)
            };
            
            ChainShape chain = new ChainShape(vertices);
            
            Assert.Equal(1, chain.ChildCount);
        }

        /// <summary>
        ///     Tests that chain shape should handle zigzag pattern
        /// </summary>
        [Fact]
        public void ChainShape_ShouldHandleZigzagPattern()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 1),
                new Vector2F(2, 0),
                new Vector2F(3, 1)
            };
            
            ChainShape chain = new ChainShape(vertices);
            
            Assert.Equal(3, chain.ChildCount);
        }

        /// <summary>
        ///     Tests that chain shape should inherit from shape
        /// </summary>
        [Fact]
        public void ChainShape_ShouldInheritFromShape()
        {
            ChainShape chain = new ChainShape();
            
            Assert.IsAssignableFrom<Shape>(chain);
        }

        /// <summary>
        ///     Tests that get child edge at first index should have no prev vertex
        /// </summary>
        [Fact]
        public void GetChildEdge_AtFirstIndex_ShouldHandleConnectivity()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(2, 0)
            };
            ChainShape chain = new ChainShape(vertices);
            
            EdgeShape edge = chain.GetChildEdge(0);
            
            Assert.False(edge.HasVertex0);
        }

        /// <summary>
        ///     Tests that get child edge at last index should have no next vertex
        /// </summary>
        [Fact]
        public void GetChildEdge_AtLastIndex_ShouldHandleConnectivity()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(2, 0)
            };
            ChainShape chain = new ChainShape(vertices);
            
            EdgeShape edge = chain.GetChildEdge(1);
            
            Assert.False(edge.HasVertex3);
        }
    }
}

