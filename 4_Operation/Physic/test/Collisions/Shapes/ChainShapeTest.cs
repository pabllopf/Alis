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
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
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

        /// <summary>
        ///     Tests that GetChildEdge at middle index sets both HasVertex0 and HasVertex3
        /// </summary>
        [Fact]
        public void GetChildEdge_AtMiddleIndex_ShouldSetBothHasVertexFlags()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(2, 0),
                new Vector2F(3, 0)
            };
            ChainShape chain = new ChainShape(vertices);

            EdgeShape edge = chain.GetChildEdge(1);

            Assert.True(edge.HasVertex0);
            Assert.True(edge.HasVertex3);
            Assert.Equal(vertices[0], edge.Vertex0);
            Assert.Equal(vertices[3], edge.Vertex3);
        }

        /// <summary>
        ///     Tests that GetChildEdge at first index with PrevVertex set propagates it
        /// </summary>
        [Fact]
        public void GetChildEdge_AtFirstIndexWithPrevVertex_ShouldPropagate()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(1, 0),
                new Vector2F(2, 0),
                new Vector2F(3, 0)
            };
            ChainShape chain = new ChainShape(vertices);
            chain.PrevVertex = new Vector2F(0, 0);

            EdgeShape edge = chain.GetChildEdge(0);

            Assert.True(edge.HasVertex0);
            Assert.Equal(new Vector2F(0, 0), edge.Vertex0);
        }

        /// <summary>
        ///     Tests that GetChildEdge at last index with NextVertex set propagates it
        /// </summary>
        [Fact]
        public void GetChildEdge_AtLastIndexWithNextVertex_ShouldPropagate()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(1, 0),
                new Vector2F(2, 0),
                new Vector2F(3, 0)
            };
            ChainShape chain = new ChainShape(vertices);
            chain.NextVertex = new Vector2F(4, 0);

            EdgeShape edge = chain.GetChildEdge(1);

            Assert.True(edge.HasVertex3);
            Assert.Equal(new Vector2F(4, 0), edge.Vertex3);
        }

        /// <summary>
        ///     Tests that RayCast delegates to EdgeShape
        /// </summary>
        [Fact]
        public void RayCast_ShouldDelegateToEdgeShape()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0),
                new Vector2F(10, 10)
            };
            ChainShape chain = new ChainShape(vertices);
            ControllerTransform transform = ControllerTransform.Identity;
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(5, -5),
                Point2 = new Vector2F(5, 5),
                MaxFraction = 1.0f
            };

            bool hit = chain.RayCast(out RayCastOutput output, ref input, ref transform, 0);

            Assert.True(hit);
        }

        /// <summary>
        ///     Tests that ComputeAabb returns valid bounds
        /// </summary>
        [Fact]
        public void ComputeAabb_ShouldReturnValidBounds()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0),
                new Vector2F(10, 10)
            };
            ChainShape chain = new ChainShape(vertices);
            ControllerTransform transform = ControllerTransform.Identity;

            chain.ComputeAabb(out Aabb aabb, ref transform, 0);

            Assert.Equal(0, aabb.LowerBound.X);
            Assert.Equal(10, aabb.UpperBound.X);
        }

        /// <summary>
        ///     Tests that ComputeSubmergedArea returns zero
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_ShouldReturnZero()
        {
            ChainShape chain = new ChainShape();
            Vector2F normal = new Vector2F(0, 1);
            ControllerTransform transform = ControllerTransform.Identity;

            float area = chain.ComputeSubmergedArea(ref normal, 0, ref transform, out Vector2F sc);

            Assert.Equal(0, area);
            Assert.Equal(Vector2F.Zero, sc);
        }

        /// <summary>
        ///     Tests that CompareTo returns true for identical chains
        /// </summary>
        [Fact]
        public void CompareTo_WithIdenticalChains_ShouldReturnTrue()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(2, 0)
            };
            ChainShape chain1 = new ChainShape(vertices);
            ChainShape chain2 = new ChainShape(vertices);

            bool result = chain1.CompareTo(chain2);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that CompareTo returns false for different vertex counts
        /// </summary>
        [Fact]
        public void CompareTo_WithDifferentVertexCount_ShouldReturnFalse()
        {
            Vertices vertices1 = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0)
            };
            Vertices vertices2 = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(2, 0)
            };
            ChainShape chain1 = new ChainShape(vertices1);
            ChainShape chain2 = new ChainShape(vertices2);

            bool result = chain1.CompareTo(chain2);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that CompareTo returns false for different vertices
        /// </summary>
        [Fact]
        public void CompareTo_WithDifferentVertices_ShouldReturnFalse()
        {
            Vertices vertices1 = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0)
            };
            Vertices vertices2 = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(5, 0)
            };
            ChainShape chain1 = new ChainShape(vertices1);
            ChainShape chain2 = new ChainShape(vertices2);

            bool result = chain1.CompareTo(chain2);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that CompareTo returns false for different prev vertex
        /// </summary>
        [Fact]
        public void CompareTo_WithDifferentPrevVertex_ShouldReturnFalse()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(2, 0)
            };
            ChainShape chain1 = new ChainShape(vertices);
            ChainShape chain2 = new ChainShape(vertices);
            chain1.PrevVertex = new Vector2F(-1, 0);

            bool result = chain1.CompareTo(chain2);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that CompareTo returns false for different next vertex
        /// </summary>
        [Fact]
        public void CompareTo_WithDifferentNextVertex_ShouldReturnFalse()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(2, 0)
            };
            ChainShape chain1 = new ChainShape(vertices);
            ChainShape chain2 = new ChainShape(vertices);
            chain1.NextVertex = new Vector2F(3, 0);

            bool result = chain1.CompareTo(chain2);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that Clone creates an equivalent chain
        /// </summary>
        [Fact]
        public void Clone_ShouldCreateEquivalentChain()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(2, 0)
            };
            ChainShape chain = new ChainShape(vertices);
            ChainShape clone = (ChainShape)chain.Clone();

            Assert.True(chain.CompareTo(clone));
        }

        /// <summary>
        ///     Tests that Clone creates an independent copy
        /// </summary>
        [Fact]
        public void Clone_ShouldCreateIndependentCopy()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(2, 0)
            };
            ChainShape chain = new ChainShape(vertices);
            ChainShape clone = (ChainShape)chain.Clone();

            clone.Vertices[0] = new Vector2F(99, 99);

            Assert.NotEqual(chain.Vertices[0], clone.Vertices[0]);
        }

        /// <summary>
        ///     Tests that TestPoint always returns false
        /// </summary>
        [Fact]
        public void TestPoint_ShouldAlwaysReturnFalse()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(2, 0)
            };
            ChainShape chain = new ChainShape(vertices);
            ControllerTransform transform = ControllerTransform.Identity;
            Vector2F point = new Vector2F(0.5f, 0);

            bool result = chain.TestPoint(ref transform, ref point);

            Assert.False(result);
        }
    }
}