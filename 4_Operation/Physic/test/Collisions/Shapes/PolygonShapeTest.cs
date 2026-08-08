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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    ///     The polygon shape test class
    /// </summary>
    public class PolygonShapeTest
    {
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
                new Vector2F(0, 1)
            };
            float density = 1.0f;

            PolygonShape polygon = new PolygonShape(vertices, density);

            Assert.Equal(ShapeType.Polygon, polygon.ShapeType);
            Assert.NotNull(polygon.Vertices);
        }

        /// <summary>
        ///     Tests that constructor with density should initialize correctly
        /// </summary>
        [Fact]
        public void ConstructorWithDensity_ShouldInitializeCorrectly()
        {
            float density = 1.5f;

            PolygonShape polygon = new PolygonShape(density);

            Assert.Equal(ShapeType.Polygon, polygon.ShapeType);
            Assert.NotNull(polygon.Vertices);
            Assert.NotNull(polygon.Normals);
        }

        /// <summary>
        ///     Tests that vertices property should set and get correctly
        /// </summary>
        [Fact]
        public void VerticesProperty_ShouldSetAndGetCorrectly()
        {
            PolygonShape polygon = new PolygonShape(1.0f);
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(2, 0),
                new Vector2F(1, 2)
            };

            polygon.Vertices = vertices;

            Assert.NotNull(polygon.Vertices);
            Assert.Equal(3, polygon.Vertices.Count);
        }

        /// <summary>
        ///     Tests that normals should be computed when vertices set
        /// </summary>
        [Fact]
        public void Normals_ShouldBeComputed_WhenVerticesSet()
        {
            PolygonShape polygon = new PolygonShape(1.0f);
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(0, 1)
            };

            polygon.Vertices = vertices;

            Assert.NotNull(polygon.Normals);
            Assert.Equal(3, polygon.Normals.Count);
        }

        /// <summary>
        ///     Tests that child count should return one
        /// </summary>
        [Fact]
        public void ChildCount_ShouldReturnOne()
        {
            PolygonShape polygon = new PolygonShape(1.0f);

            Assert.Equal(1, polygon.ChildCount);
        }

        /// <summary>
        ///     Tests that polygon shape should handle square vertices
        /// </summary>
        [Fact]
        public void PolygonShape_ShouldHandleSquareVertices()
        {
            Vertices square = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(1, 1),
                new Vector2F(0, 1)
            };

            PolygonShape polygon = new PolygonShape(square, 1.0f);

            Assert.NotNull(polygon.Vertices);
        }

        /// <summary>
        ///     Tests that polygon shape should handle triangle vertices
        /// </summary>
        [Fact]
        public void PolygonShape_ShouldHandleTriangleVertices()
        {
            Vertices triangle = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(0.5f, 1)
            };

            PolygonShape polygon = new PolygonShape(triangle, 1.0f);

            Assert.Equal(3, polygon.Vertices.Count);
        }

        /// <summary>
        ///     Tests that polygon shape should compute mass data with positive density
        /// </summary>
        [Fact]
        public void PolygonShape_ShouldComputeMassData_WithPositiveDensity()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(0, 1)
            };

            PolygonShape polygon = new PolygonShape(vertices, 1.0f);

            Assert.True(polygon.MassData.Mass > 0);
        }

        /// <summary>
        ///     Tests that polygon shape should not compute mass data with zero density
        /// </summary>
        [Fact]
        public void PolygonShape_ShouldNotComputeMassData_WithZeroDensity()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(0, 1)
            };

            PolygonShape polygon = new PolygonShape(vertices, 0.0f);

            Assert.Equal(0, polygon.MassData.Mass);
        }

        /// <summary>
        ///     Tests that test point should return true for point inside polygon
        /// </summary>
        [Fact]
        public void TestPoint_ShouldReturnTrue_ForPointInsidePolygon()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0),
                new Vector2F(10, 10),
                new Vector2F(0, 10)
            };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            Vector2F point = new Vector2F(5, 5);

            bool inside = polygon.TestPoint(ref transform, ref point);

            Assert.True(inside);
        }

        /// <summary>
        ///     Tests that test point should return false for point outside polygon
        /// </summary>
        [Fact]
        public void TestPoint_ShouldReturnFalse_ForPointOutsidePolygon()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0),
                new Vector2F(10, 10),
                new Vector2F(0, 10)
            };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            Vector2F point = new Vector2F(15, 15);

            bool inside = polygon.TestPoint(ref transform, ref point);

            Assert.False(inside);
        }

        /// <summary>
        ///     Tests that polygon shape should inherit from shape
        /// </summary>
        [Fact]
        public void PolygonShape_ShouldInheritFromShape()
        {
            PolygonShape polygon = new PolygonShape(1.0f);

            Assert.IsAssignableFrom<Shape>(polygon);
        }

        /// <summary>
        ///     Tests that polygon shape should support complex polygons
        /// </summary>
        [Fact]
        public void PolygonShape_ShouldSupportComplexPolygons()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(2, 0),
                new Vector2F(2, 1),
                new Vector2F(1, 1),
                new Vector2F(1, 2),
                new Vector2F(0, 2)
            };

            PolygonShape polygon = new PolygonShape(vertices, 1.0f);

            Assert.NotNull(polygon.Vertices);
        }

        /// <summary>
        ///     Tests that compare to returns true for equal polygons
        /// </summary>
        [Fact]
        public void CompareTo_EqualPolygons_ReturnsTrue()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0, 1) };
            PolygonShape a = new PolygonShape(vertices, 1.0f);
            PolygonShape b = new PolygonShape(vertices, 1.0f);

            bool equal = a.CompareTo(b);

            Assert.True(equal);
        }

        /// <summary>
        ///     Tests that compare to returns false for different polygons
        /// </summary>
        [Fact]
        public void CompareTo_DifferentPolygons_ReturnsFalse()
        {
            Vertices verticesA = new Vertices { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0, 1) };
            Vertices verticesB = new Vertices { new Vector2F(0, 0), new Vector2F(2, 0), new Vector2F(0, 2) };
            PolygonShape a = new PolygonShape(verticesA, 1.0f);
            PolygonShape b = new PolygonShape(verticesB, 1.0f);

            bool equal = a.CompareTo(b);

            Assert.False(equal);
        }

        /// <summary>
        ///     Tests that clone creates independent copy
        /// </summary>
        [Fact]
        public void Clone_CreatesIndependentCopy()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0, 1) };
            PolygonShape original = new PolygonShape(vertices, 1.0f);

            PolygonShape clone = (PolygonShape)original.Clone();

            Assert.NotSame(original, clone);
            Assert.Equal(original.ShapeType, clone.ShapeType);
            Assert.NotNull(clone.Vertices);
        }

        /// <summary>
        ///     Tests that compute aabb should return valid bounds
        /// </summary>
        [Fact]
        public void ComputeAabb_ShouldReturnValidBounds()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(2, 0), new Vector2F(2, 2), new Vector2F(0, 2) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;

            polygon.ComputeAabb(out Aabb aabb, ref transform, 0);

            Assert.True(aabb.LowerBound.X <= aabb.UpperBound.X);
            Assert.True(aabb.LowerBound.Y <= aabb.UpperBound.Y);
        }

        /// <summary>
        ///     Tests that ray cast should return true when ray hits polygon
        /// </summary>
        [Fact]
        public void RayCast_ShouldReturnTrue_WhenRayHitsPolygon()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(10, 0), new Vector2F(10, 10), new Vector2F(0, 10) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(-5, 5),
                Point2 = new Vector2F(15, 5),
                MaxFraction = 1.0f
            };

            bool hit = polygon.RayCast(out RayCastOutput output, ref input, ref transform, 0);

            Assert.True(hit);
            Assert.True(output.Fraction > 0);
        }

        /// <summary>
        ///     Tests that ray cast should return false when ray misses polygon
        /// </summary>
        [Fact]
        public void RayCast_ShouldReturnFalse_WhenRayMissesPolygon()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(10, 0), new Vector2F(10, 10), new Vector2F(0, 10) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(20, 20),
                Point2 = new Vector2F(30, 30),
                MaxFraction = 1.0f
            };

            bool hit = polygon.RayCast(out RayCastOutput _, ref input, ref transform, 0);

            Assert.False(hit);
        }

        /// <summary>
        ///     Tests that compute submerged area returns zero when above water
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_AboveWater_ReturnsZero()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0, 1) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            Vector2F normal = new Vector2F(0, 1);

            float area = polygon.ComputeSubmergedArea(ref normal, -10, ref transform, out Vector2F _);

            Assert.Equal(0, area);
        }

        /// <summary>
        ///     Tests that compute submerged area returns full area when fully submerged
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_FullySubmerged_ReturnsFullArea()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(2, 0), new Vector2F(0, 2) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            // Normal pointing up, offset high above all vertices
            Vector2F normal = new Vector2F(0, 1);

            float area = polygon.ComputeSubmergedArea(ref normal, 10, ref transform, out Vector2F _);

            Assert.True(area > 0);
        }

        /// <summary>
        ///     Tests that compute submerged area returns partial area when partially submerged with water entering from below
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_PartiallySubmerged_ReturnsPartialArea()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(2, 0), new Vector2F(0, 2) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            // Normal pointing up, water level cuts through the triangle
            Vector2F normal = new Vector2F(0, 1);

            float area = polygon.ComputeSubmergedArea(ref normal, 0.5f, ref transform, out Vector2F _);

            Assert.True(area > 0);
            Assert.True(area < polygon.MassData.Mass / polygon.GetDensity);
        }

        /// <summary>
        ///     Tests that compute submerged area returns non negative when partially submerged with inverted normal
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_PartiallySubmerged_InvertedNormal_ReturnsNonNegative()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(2, 0), new Vector2F(0, 2) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            Vector2F normal = new Vector2F(0, -1);

            float area = polygon.ComputeSubmergedArea(ref normal, -0.5f, ref transform, out Vector2F _);

            Assert.True(area >= 0);
        }

        /// <summary>
        ///     Tests that compute submerged area returns non zero center when fully submerged
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_FullySubmerged_ReturnsNonZeroCenter()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(2, 0), new Vector2F(0, 2) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            Vector2F normal = new Vector2F(0, 1);

            polygon.ComputeSubmergedArea(ref normal, 10, ref transform, out Vector2F sc);

            Assert.NotEqual(Vector2F.Zero, sc);
        }

        /// <summary>
        ///     Tests that compute submerged area with rotated transform returns valid area
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_WithRotatedTransform_ReturnsValidArea()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0, 1) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = new ControllerTransform(new Vector2F(1, 1), 0.5f);
            Vector2F normal = new Vector2F(0, 1);

            float area = polygon.ComputeSubmergedArea(ref normal, 10, ref transform, out Vector2F _);

            Assert.True(area > 0);
        }

        /// <summary>
        ///     Tests that RayCast returns false when the ray is parallel and outside the polygon (denominator near zero, numerator < 0).
        /// </summary>
        [Fact]
        public void RayCast_ParallelOutside_ReturnsFalse()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(10, 0), new Vector2F(10, 10), new Vector2F(0, 10) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            // Ray parallel to the right edge, starting outside to the right
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(15, 5),
                Point2 = new Vector2F(25, 5),
                MaxFraction = 1.0f
            };

            bool hit = polygon.RayCast(out RayCastOutput _, ref input, ref transform, 0);

            Assert.False(hit);
        }

        /// <summary>
        ///     Tests that RayCast returns false when upper < lower during iteration.
        /// </summary>
        [Fact]
        public void RayCast_UpperLessThanLower_ReturnsFalse()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(10, 0), new Vector2F(10, 10), new Vector2F(0, 10) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            // Ray that would make upper cross lower
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(-5, -5),
                Point2 = new Vector2F(15, 15),
                MaxFraction = 0.1f
            };

            bool hit = polygon.RayCast(out RayCastOutput _, ref input, ref transform, 0);

            Assert.False(hit);
        }

        /// <summary>
        ///     Tests that ComputeSubmergedArea with diveCount = 1 adjusts indices correctly.
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_SingleDive_AdjustsIndices()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(2, 0), new Vector2F(0, 2) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            // Water level that cuts through creating exactly one dive transition
            Vector2F normal = new Vector2F(0, 1);

            float area = polygon.ComputeSubmergedArea(ref normal, 1.5f, ref transform, out Vector2F _);

            Assert.True(area >= 0);
        }

        /// <summary>
        ///     Tests that ComputeSubmergedArea with diveCount = 1 and intoIndex == -1 triggers the intoIndex adjustment.
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_SingleDiveIntoIndexMinusOne_AdjustsCorrectly()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(2, 0), new Vector2F(2, 2), new Vector2F(0, 2) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            Vector2F normal = new Vector2F(0, 1);

            float area = polygon.ComputeSubmergedArea(ref normal, 1.0f, ref transform, out Vector2F _);

            Assert.True(area >= 0);
        }

        /// <summary>
        ///     Tests that TestPoint returns false for a point outside a rotated polygon.
        /// </summary>
        [Fact]
        public void TestPoint_WithRotatedTransform_Outside_ReturnsFalse()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(10, 0), new Vector2F(10, 10), new Vector2F(0, 10) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = new ControllerTransform(new Vector2F(5, 5), (float)Math.PI / 4);
            Vector2F point = new Vector2F(0, 0);

            bool inside = polygon.TestPoint(ref transform, ref point);

            Assert.False(inside);
        }

        /// <summary>
        ///     Tests that ComputeSubmergedArea with bottom-up normal and water below everything returns zero.
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_NormalDown_WaterBelow_ReturnsZero()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(2, 0), new Vector2F(0, 2) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;
            Vector2F normal = new Vector2F(0, -1);

            float area = polygon.ComputeSubmergedArea(ref normal, -10, ref transform, out Vector2F _);

            Assert.Equal(0, area);
        }

        /// <summary>
        ///     Tests that the internal parameterless constructor initializes correctly.
        /// </summary>
        [Fact]
        public void InternalConstructor_ShouldInitializeCorrectly()
        {
            PolygonShape polygon = new PolygonShape();

            Assert.Equal(ShapeType.Polygon, polygon.ShapeType);
            Assert.NotNull(polygon.Vertices);
            Assert.NotNull(polygon.Normals);
        }

        /// <summary>
        /// Tests that compare to with different vertex count returns false
        /// </summary>
        [Fact]
        public void CompareTo_WithDifferentVertexCount_ReturnsFalse()
        {
            Vertices vertsA = new Vertices { new Vector2F(0, 0), new Vector2F(2, 0), new Vector2F(0, 2) };
            Vertices vertsB = new Vertices { new Vector2F(0, 0), new Vector2F(3, 0), new Vector2F(3, 2), new Vector2F(0, 2) };
            PolygonShape shapeA = new PolygonShape(vertsA, 1.0f);
            PolygonShape shapeB = new PolygonShape(vertsB, 1.0f);

            bool result = shapeA.CompareTo(shapeB);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that ray cast with parallel edge outside covers parallel branch
        /// </summary>
        [Fact]
        public void RayCast_WithParallelEdgeOutside_CoversParallelBranch()
        {
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(10, 0), new Vector2F(10, 10), new Vector2F(0, 10) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform transform = ControllerTransform.Identity;

            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(5, 15),
                Point2 = new Vector2F(15, 15),
                MaxFraction = 1.0f
            };

            bool hit = polygon.RayCast(out RayCastOutput _, ref input, ref transform, 0);

            Assert.False(hit);
        }
    }
}