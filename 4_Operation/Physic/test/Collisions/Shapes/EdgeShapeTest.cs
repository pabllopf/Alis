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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    ///     The edge shape test class
    /// </summary>
    public class EdgeShapeTest
    {
        /// <summary>
        ///     Tests that constructor with vertices should initialize correctly
        /// </summary>
        [Fact]
        public void ConstructorWithVertices_ShouldInitializeCorrectly()
        {
            Vector2F start = new Vector2F(0, 0);
            Vector2F end = new Vector2F(10, 0);

            EdgeShape edge = new EdgeShape(start, end);

            Assert.Equal(ShapeType.Edge, edge.ShapeType);
            Assert.Equal(start, edge.Vertex1);
            Assert.Equal(end, edge.Vertex2);
        }

        /// <summary>
        ///     Tests that child count should return one
        /// </summary>
        [Fact]
        public void ChildCount_ShouldReturnOne()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, new Vector2F(1, 0));

            Assert.Equal(1, edge.ChildCount);
        }

        /// <summary>
        ///     Tests that set should update vertices
        /// </summary>
        [Fact]
        public void Set_ShouldUpdateVertices()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);
            Vector2F newStart = new Vector2F(5, 5);
            Vector2F newEnd = new Vector2F(10, 10);

            edge.Set(newStart, newEnd);

            Assert.Equal(newStart, edge.Vertex1);
            Assert.Equal(newEnd, edge.Vertex2);
        }

        /// <summary>
        ///     Tests that vertex1 property should set and get correctly
        /// </summary>
        [Fact]
        public void Vertex1Property_ShouldSetAndGetCorrectly()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);
            Vector2F newVertex = new Vector2F(3, 4);

            edge.Vertex1 = newVertex;

            Assert.Equal(newVertex, edge.Vertex1);
        }

        /// <summary>
        ///     Tests that vertex2 property should set and get correctly
        /// </summary>
        [Fact]
        public void Vertex2Property_ShouldSetAndGetCorrectly()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);
            Vector2F newVertex = new Vector2F(5, 6);

            edge.Vertex2 = newVertex;

            Assert.Equal(newVertex, edge.Vertex2);
        }

        /// <summary>
        ///     Tests that has vertex0 property should set and get correctly
        /// </summary>
        [Fact]
        public void HasVertex0Property_ShouldSetAndGetCorrectly()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);

            edge.HasVertex0 = true;

            Assert.True(edge.HasVertex0);
        }

        /// <summary>
        ///     Tests that has vertex3 property should set and get correctly
        /// </summary>
        [Fact]
        public void HasVertex3Property_ShouldSetAndGetCorrectly()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);

            edge.HasVertex3 = true;

            Assert.True(edge.HasVertex3);
        }

        /// <summary>
        ///     Tests that vertex0 property should set and get correctly
        /// </summary>
        [Fact]
        public void Vertex0Property_ShouldSetAndGetCorrectly()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);
            Vector2F vertex0 = new Vector2F(-1, 0);

            edge.Vertex0 = vertex0;

            Assert.Equal(vertex0, edge.Vertex0);
        }

        /// <summary>
        ///     Tests that vertex3 property should set and get correctly
        /// </summary>
        [Fact]
        public void Vertex3Property_ShouldSetAndGetCorrectly()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);
            Vector2F vertex3 = new Vector2F(2, 1);

            edge.Vertex3 = vertex3;

            Assert.Equal(vertex3, edge.Vertex3);
        }

        /// <summary>
        ///     Tests that test point should always return false
        /// </summary>
        [Fact]
        public void TestPoint_ShouldAlwaysReturnFalse()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, new Vector2F(10, 0));
            ControllerTransform transform = ControllerTransform.Identity;
            Vector2F point = new Vector2F(5, 0);

            bool result = edge.TestPoint(ref transform, ref point);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that edge shape should handle vertical edges
        /// </summary>
        [Fact]
        public void EdgeShape_ShouldHandleVerticalEdges()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(5, 0), new Vector2F(5, 10));

            Assert.Equal(5, edge.Vertex1.X);
            Assert.Equal(5, edge.Vertex2.X);
            Assert.NotEqual(edge.Vertex1.Y, edge.Vertex2.Y);
        }

        /// <summary>
        ///     Tests that edge shape should handle horizontal edges
        /// </summary>
        [Fact]
        public void EdgeShape_ShouldHandleHorizontalEdges()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0, 5), new Vector2F(10, 5));

            Assert.Equal(5, edge.Vertex1.Y);
            Assert.Equal(5, edge.Vertex2.Y);
            Assert.NotEqual(edge.Vertex1.X, edge.Vertex2.X);
        }

        /// <summary>
        ///     Tests that edge shape should handle diagonal edges
        /// </summary>
        [Fact]
        public void EdgeShape_ShouldHandleDiagonalEdges()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 10));

            Assert.Equal(0, edge.Vertex1.X);
            Assert.Equal(10, edge.Vertex2.X);
        }

        /// <summary>
        ///     Tests that edge shape should support adjacent vertices
        /// </summary>
        [Fact]
        public void EdgeShape_ShouldSupportAdjacentVertices()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 0));
            edge.HasVertex0 = true;
            edge.HasVertex3 = true;
            edge.Vertex0 = new Vector2F(-10, 0);
            edge.Vertex3 = new Vector2F(20, 0);

            Assert.True(edge.HasVertex0);
            Assert.True(edge.HasVertex3);
            Assert.Equal(new Vector2F(-10, 0), edge.Vertex0);
            Assert.Equal(new Vector2F(20, 0), edge.Vertex3);
        }

        /// <summary>
        ///     Tests that edge shape should inherit from shape
        /// </summary>
        [Fact]
        public void EdgeShape_ShouldInheritFromShape()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);

            Assert.IsAssignableFrom<Shape>(edge);
        }

        /// <summary>
        ///     Tests that set should reset has vertex flags
        /// </summary>
        [Fact]
        public void Set_ShouldResetHasVertexFlags()
        {
            EdgeShape edge = new EdgeShape(Vector2F.Zero, Vector2F.One);
            edge.HasVertex0 = true;
            edge.HasVertex3 = true;

            edge.Set(new Vector2F(5, 5), new Vector2F(10, 10));

            Assert.False(edge.HasVertex0);
            Assert.False(edge.HasVertex3);
        }

    #region RayCast Tests

    /// <summary>
    ///     Tests that RayCast hits an edge from below with correct fraction and normal
    /// </summary>
    [Fact]
    public void RayCast_FromBelowEdge_HitsWithCorrectFraction()
    {
        EdgeShape edge = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 0));
        ControllerTransform transform = ControllerTransform.Identity;
        RayCastInput input = new RayCastInput
        {
            Point1 = new Vector2F(5, -5),
            Point2 = new Vector2F(5, 5),
            MaxFraction = 1.0f
        };

        bool hit = edge.RayCast(out RayCastOutput output, ref input, ref transform, 0);

        Assert.True(hit);
        Assert.Equal(0.5f, output.Fraction, 5);
        Assert.Equal(new Vector2F(0, -1), output.Normal);
    }

    /// <summary>
    ///     Tests that RayCast from above the edge flips the normal direction
    /// </summary>
    [Fact]
    public void RayCast_FromAboveEdge_FlipsNormal()
    {
        EdgeShape edge = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 0));
        ControllerTransform transform = ControllerTransform.Identity;
        RayCastInput input = new RayCastInput
        {
            Point1 = new Vector2F(5, 5),
            Point2 = new Vector2F(5, -5),
            MaxFraction = 1.0f
        };

        bool hit = edge.RayCast(out RayCastOutput output, ref input, ref transform, 0);

        Assert.True(hit);
        Assert.Equal(0.5f, output.Fraction, 5);
        Assert.Equal(new Vector2F(0, 1), output.Normal);
    }

    /// <summary>
    ///     Tests that RayCast parallel to edge returns false
    /// </summary>
    [Fact]
    public void RayCast_ParallelToEdge_ReturnsFalse()
    {
        EdgeShape edge = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 0));
        ControllerTransform transform = ControllerTransform.Identity;
        RayCastInput input = new RayCastInput
        {
            Point1 = new Vector2F(5, -5),
            Point2 = new Vector2F(15, -5),
            MaxFraction = 1.0f
        };

        bool hit = edge.RayCast(out RayCastOutput output, ref input, ref transform, 0);

        Assert.False(hit);
    }

    /// <summary>
    ///     Tests that RayCast returns false when intersection is beyond max fraction
    /// </summary>
    [Fact]
    public void RayCast_BeyondMaxFraction_ReturnsFalse()
    {
        EdgeShape edge = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 0));
        ControllerTransform transform = ControllerTransform.Identity;
        RayCastInput input = new RayCastInput
        {
            Point1 = new Vector2F(5, -5),
            Point2 = new Vector2F(5, 5),
            MaxFraction = 0.1f
        };

        bool hit = edge.RayCast(out RayCastOutput output, ref input, ref transform, 0);

        Assert.False(hit);
    }

    /// <summary>
    ///     Tests that RayCast returns false when intersection is behind ray start
    /// </summary>
    [Fact]
    public void RayCast_BehindStart_ReturnsFalse()
    {
        EdgeShape edge = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 0));
        ControllerTransform transform = ControllerTransform.Identity;
        RayCastInput input = new RayCastInput
        {
            Point1 = new Vector2F(5, 5),
            Point2 = new Vector2F(5, 10),
            MaxFraction = 1.0f
        };

        bool hit = edge.RayCast(out RayCastOutput output, ref input, ref transform, 0);

        Assert.False(hit);
    }

    /// <summary>
    ///     Tests that RayCast returns false when intersection is outside edge segment
    /// </summary>
    [Fact]
    public void RayCast_OutsideSegment_ReturnsFalse()
    {
        EdgeShape edge = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 0));
        ControllerTransform transform = ControllerTransform.Identity;
        RayCastInput input = new RayCastInput
        {
            Point1 = new Vector2F(-5, -5),
            Point2 = new Vector2F(-5, 5),
            MaxFraction = 1.0f
        };

        bool hit = edge.RayCast(out RayCastOutput output, ref input, ref transform, 0);

        Assert.False(hit);
    }

    /// <summary>
    ///     Tests that RayCast returns false for a zero-length edge (degenerate)
    /// </summary>
    [Fact]
    public void RayCast_ZeroLengthEdge_ReturnsFalse()
    {
        EdgeShape edge = new EdgeShape(new Vector2F(0, 0), new Vector2F(0.00001f, 0));
        ControllerTransform transform = ControllerTransform.Identity;
        RayCastInput input = new RayCastInput
        {
            Point1 = new Vector2F(0.5f, -1),
            Point2 = new Vector2F(0.5f, 1),
            MaxFraction = 1.0f
        };

        bool hit = edge.RayCast(out RayCastOutput output, ref input, ref transform, 0);

        Assert.False(hit);
    }

    #endregion

    #region ComputeAabb Tests

    /// <summary>
    ///     Tests that ComputeAabb for a horizontal edge returns correct bounds
    /// </summary>
    [Fact]
    public void ComputeAabb_HorizontalEdge_ReturnsCorrectBounds()
    {
        EdgeShape edge = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 0));
        ControllerTransform transform = ControllerTransform.Identity;
        float radius = edge.GetRadius;

        edge.ComputeAabb(out Aabb aabb, ref transform, 0);

        Assert.Equal(-radius, aabb.LowerBound.X);
        Assert.Equal(10 + radius, aabb.UpperBound.X);
        Assert.Equal(-radius, aabb.LowerBound.Y);
        Assert.Equal(radius, aabb.UpperBound.Y);
    }

    /// <summary>
    ///     Tests that ComputeAabb for a vertical edge returns correct bounds
    /// </summary>
    [Fact]
    public void ComputeAabb_VerticalEdge_ReturnsCorrectBounds()
    {
        EdgeShape edge = new EdgeShape(new Vector2F(5, 0), new Vector2F(5, 10));
        ControllerTransform transform = ControllerTransform.Identity;
        float radius = edge.GetRadius;

        edge.ComputeAabb(out Aabb aabb, ref transform, 0);

        Assert.Equal(5 - radius, aabb.LowerBound.X);
        Assert.Equal(5 + radius, aabb.UpperBound.X);
        Assert.Equal(-radius, aabb.LowerBound.Y);
        Assert.Equal(10 + radius, aabb.UpperBound.Y);
    }

    /// <summary>
    ///     Tests that ComputeAabb for a reversed edge (v1X > v2X) still returns correct bounds
    /// </summary>
    [Fact]
    public void ComputeAabb_ReversedEdge_SortsBoundsCorrectly()
    {
        EdgeShape edge = new EdgeShape(new Vector2F(10, 5), new Vector2F(0, 5));
        ControllerTransform transform = ControllerTransform.Identity;
        float radius = edge.GetRadius;

        edge.ComputeAabb(out Aabb aabb, ref transform, 0);

        Assert.Equal(-radius, aabb.LowerBound.X);
        Assert.Equal(10 + radius, aabb.UpperBound.X);
    }

    #endregion

    #region ComputeSubmergedArea Tests

    /// <summary>
    ///     Tests that ComputeSubmergedArea always returns zero for edge shapes
    /// </summary>
    [Fact]
    public void ComputeSubmergedArea_ShouldReturnZero()
    {
        EdgeShape edge = new EdgeShape(Vector2F.Zero, new Vector2F(10, 0));
        ControllerTransform transform = ControllerTransform.Identity;
        Vector2F normal = new Vector2F(0, 1);

        float area = edge.ComputeSubmergedArea(ref normal, 0, ref transform, out Vector2F sc);

        Assert.Equal(0, area);
        Assert.Equal(Vector2F.Zero, sc);
    }

    #endregion

    #region CompareTo Tests

    /// <summary>
    ///     Tests that CompareTo returns true for identical edges
    /// </summary>
    [Fact]
    public void CompareTo_EqualEdges_ReturnsTrue()
    {
        EdgeShape edge1 = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 0));
        EdgeShape edge2 = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 0));
        edge1.HasVertex0 = true;
        edge1.HasVertex3 = true;
        edge1.Vertex0 = new Vector2F(-10, 0);
        edge1.Vertex3 = new Vector2F(20, 0);
        edge2.HasVertex0 = true;
        edge2.HasVertex3 = true;
        edge2.Vertex0 = new Vector2F(-10, 0);
        edge2.Vertex3 = new Vector2F(20, 0);

        bool result = edge1.CompareTo(edge2);

        Assert.True(result);
    }

    /// <summary>
    ///     Tests that CompareTo returns false for different edges
    /// </summary>
    [Fact]
    public void CompareTo_DifferentEdges_ReturnsFalse()
    {
        EdgeShape edge1 = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 0));
        EdgeShape edge2 = new EdgeShape(new Vector2F(0, 0), new Vector2F(20, 0));

        bool result = edge1.CompareTo(edge2);

        Assert.False(result);
    }

    /// <summary>
    ///     Tests that CompareTo returns false when HasVertex0 differs
    /// </summary>
    [Fact]
    public void CompareTo_DifferentHasVertex0_ReturnsFalse()
    {
        EdgeShape edge1 = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 0));
        EdgeShape edge2 = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 0));
        edge1.HasVertex0 = true;

        bool result = edge1.CompareTo(edge2);

        Assert.False(result);
    }

    #endregion

    #region Clone Tests

    /// <summary>
    ///     Tests that Clone creates an independent copy with identical properties
    /// </summary>
    [Fact]
    public void Clone_ShouldCopyAllProperties()
    {
        EdgeShape original = new EdgeShape(new Vector2F(1, 2), new Vector2F(3, 4));
        original.HasVertex0 = true;
        original.HasVertex3 = true;
        original.Vertex0 = new Vector2F(-1, 0);
        original.Vertex3 = new Vector2F(5, 4);

        EdgeShape clone = (EdgeShape)original.Clone();

        Assert.NotSame(original, clone);
        Assert.True(original.CompareTo(clone));
        Assert.Equal(original.Vertex1, clone.Vertex1);
        Assert.Equal(original.Vertex2, clone.Vertex2);
        Assert.Equal(original.HasVertex0, clone.HasVertex0);
        Assert.Equal(original.HasVertex3, clone.HasVertex3);
        Assert.Equal(original.Vertex0, clone.Vertex0);
        Assert.Equal(original.Vertex3, clone.Vertex3);
        Assert.Equal(original.ShapeType, clone.ShapeType);
        Assert.Equal(original.GetRadius, clone.GetRadius);
    }

    /// <summary>
    ///     Tests that Clone creates an independent copy (modifying clone does not affect original)
    /// </summary>
    [Fact]
    public void Clone_ShouldBeIndependentCopy()
    {
        EdgeShape original = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 0));
        EdgeShape clone = (EdgeShape)original.Clone();

        clone.Vertex1 = new Vector2F(5, 5);

        Assert.Equal(new Vector2F(0, 0), original.Vertex1);
    }

    #endregion

    #region ComputeProperties (via Vertex setter) Tests

    /// <summary>
    ///     Tests that setting Vertex1 or Vertex2 updates the centroid
    /// </summary>
    [Fact]
    public void VertexSetter_UpdatesCentroid()
    {
        EdgeShape edge = new EdgeShape(new Vector2F(0, 0), new Vector2F(10, 0));

        edge.Vertex1 = new Vector2F(2, 2);
        edge.Vertex2 = new Vector2F(8, 6);

        Vector2F expectedCentroid = new Vector2F(5, 4);

        Assert.Equal(expectedCentroid, edge.MassData.Centroid);
    }

    #endregion
    }
}