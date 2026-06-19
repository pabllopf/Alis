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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    ///     The circle shape test class
    /// </summary>
    public class CircleShapeTest
    {
        /// <summary>
        ///     Tests that constructor with radius and density should initialize correctly
        /// </summary>
        [Fact]
        public void Constructor_WithRadiusAndDensity_ShouldInitializeCorrectly()
        {
            float radius = 2.0f;
            float density = 1.5f;

            CircleShape circle = new CircleShape(radius, density);

            Assert.Equal(radius, circle.GetRadius);
            Assert.Equal(density, circle.GetDensity);
            Assert.Equal(ShapeType.Circle, circle.ShapeType);
        }

        /// <summary>
        ///     Tests that position should get and set correctly
        /// </summary>
        [Fact]
        public void Position_ShouldGetAndSetCorrectly()
        {
            CircleShape circle = new CircleShape(1.0f, 1.0f);
            Vector2F newPosition = new Vector2F(5.0f, 10.0f);

            circle.Position = newPosition;

            Assert.Equal(newPosition, circle.Position);
        }

        /// <summary>
        ///     Tests that child count should return one
        /// </summary>
        [Fact]
        public void ChildCount_ShouldReturnOne()
        {
            CircleShape circle = new CircleShape(1.0f, 1.0f);

            Assert.Equal(1, circle.ChildCount);
        }

        /// <summary>
        ///     Tests that test point should return true when point inside
        /// </summary>
        [Fact]
        public void TestPoint_ShouldReturnTrue_WhenPointInside()
        {
            CircleShape circle = new CircleShape(5.0f, 1.0f);
            ControllerTransform transform = new ControllerTransform
            {
                Position = new Vector2F(10.0f, 10.0f),
                Rotation = Complex.One
            };
            Vector2F point = new Vector2F(12.0f, 10.0f);

            bool result = circle.TestPoint(ref transform, ref point);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that test point should return false when point outside
        /// </summary>
        [Fact]
        public void TestPoint_ShouldReturnFalse_WhenPointOutside()
        {
            CircleShape circle = new CircleShape(1.0f, 1.0f);
            ControllerTransform transform = new ControllerTransform
            {
                Position = new Vector2F(0.0f, 0.0f),
                Rotation = Complex.One
            };
            Vector2F point = new Vector2F(10.0f, 10.0f);

            bool result = circle.TestPoint(ref transform, ref point);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that compute aabb should calculate correct bounds
        /// </summary>
        [Fact]
        public void ComputeAabb_ShouldCalculateCorrectBounds()
        {
            CircleShape circle = new CircleShape(2.0f, 1.0f);
            ControllerTransform transform = new ControllerTransform
            {
                Position = new Vector2F(5.0f, 5.0f),
                Rotation = Complex.One
            };

            circle.ComputeAabb(out Aabb aabb, ref transform, 0);

            Assert.Equal(3.0f, aabb.LowerBound.X, 5);
            Assert.Equal(3.0f, aabb.LowerBound.Y, 5);
            Assert.Equal(7.0f, aabb.UpperBound.X, 5);
            Assert.Equal(7.0f, aabb.UpperBound.Y, 5);
        }

        /// <summary>
        ///     Tests that mass data should be calculated correctly
        /// </summary>
        [Fact]
        public void MassData_ShouldBeCalculatedCorrectly()
        {
            float radius = 2.0f;
            float density = 1.0f;
            CircleShape circle = new CircleShape(radius, density);

            Assert.True(circle.MassData.Mass > 0);
            Assert.True(circle.MassData.Area > 0);
            Assert.True(circle.MassData.Inertia > 0);
        }

        /// <summary>
        ///     Tests that changing density should recalculate properties
        /// </summary>
        [Fact]
        public void ChangingDensity_ShouldRecalculateProperties()
        {
            CircleShape circle = new CircleShape(2.0f, 1.0f);
            float originalMass = circle.MassData.Mass;

            circle.GetDensity = 2.0f;

            Assert.True(circle.MassData.Mass > originalMass);
        }

        /// <summary>
        ///     Tests that changing radius should recalculate properties
        /// </summary>
        [Fact]
        public void ChangingRadius_ShouldRecalculateProperties()
        {
            CircleShape circle = new CircleShape(1.0f, 1.0f);
            float originalMass = circle.MassData.Mass;

            circle.GetRadius = 2.0f;

            Assert.True(circle.MassData.Mass > originalMass);
        }

        /// <summary>
        ///     Tests that test point at center should return true
        /// </summary>
        [Fact]
        public void TestPoint_AtCenter_ShouldReturnTrue()
        {
            CircleShape circle = new CircleShape(5.0f, 1.0f);
            ControllerTransform transform = new ControllerTransform
            {
                Position = new Vector2F(10.0f, 10.0f),
                Rotation = Complex.One
            };
            Vector2F point = new Vector2F(10.0f, 10.0f);

            bool result = circle.TestPoint(ref transform, ref point);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that constructor with zero radius should work
        /// </summary>
        [Fact]
        public void Constructor_WithZeroRadius_ShouldWork()
        {
            CircleShape circle = new CircleShape(0.0f, 1.0f);

            Assert.Equal(0.0f, circle.GetRadius);
        }

        /// <summary>
        ///     Tests that constructor with zero density should work
        /// </summary>
        [Fact]
        public void Constructor_WithZeroDensity_ShouldWork()
        {
            CircleShape circle = new CircleShape(1.0f, 0.0f);

            Assert.Equal(0.0f, circle.GetDensity);
        }

        /// <summary>
        ///     Tests that compute aabb with offset position should work
        /// </summary>
        [Fact]
        public void ComputeAabb_WithOffsetPosition_ShouldWork()
        {
            CircleShape circle = new CircleShape(1.0f, 1.0f);
            circle.Position = new Vector2F(2.0f, 3.0f);
            ControllerTransform transform = new ControllerTransform
            {
                Position = new Vector2F(5.0f, 5.0f),
                Rotation = Complex.One
            };

            circle.ComputeAabb(out Aabb aabb, ref transform, 0);

            Assert.NotNull(aabb);
        }

        /// <summary>
        ///     Tests that ray cast should return true when ray hits circle
        /// </summary>
        [Fact]
        public void RayCast_ShouldReturnTrue_WhenRayHitsCircle()
        {
            CircleShape circle = new CircleShape(5.0f, 1.0f);
            ControllerTransform transform = new ControllerTransform
            {
                Position = new Vector2F(0.0f, 0.0f),
                Rotation = Complex.One
            };
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(-10.0f, 0.0f),
                Point2 = new Vector2F(10.0f, 0.0f),
                MaxFraction = 1.0f
            };

            bool hit = circle.RayCast(out RayCastOutput output, ref input, ref transform, 0);

            Assert.True(hit);
            Assert.True(output.Fraction > 0.0f);
        }

        /// <summary>
        ///     Tests that ray cast should return false when ray misses circle
        /// </summary>
        [Fact]
        public void RayCast_ShouldReturnFalse_WhenRayMissesCircle()
        {
            CircleShape circle = new CircleShape(1.0f, 1.0f);
            ControllerTransform transform = new ControllerTransform
            {
                Position = new Vector2F(0.0f, 0.0f),
                Rotation = Complex.One
            };
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(10.0f, 10.0f),
                Point2 = new Vector2F(20.0f, 20.0f),
                MaxFraction = 1.0f
            };

            bool hit = circle.RayCast(out RayCastOutput output, ref input, ref transform, 0);

            Assert.False(hit);
        }

        /// <summary>
        ///     Tests that compute submerged area returns zero when circle is above water
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_AboveWater_ReturnsZero()
        {
            CircleShape circle = new CircleShape(1.0f, 1.0f);
            circle.Position = new Vector2F(0.0f, 0.0f);
            ControllerTransform transform = new ControllerTransform
            {
                Position = new Vector2F(0.0f, 0.0f),
                Rotation = Complex.One
            };
            Vector2F normal = new Vector2F(0.0f, 1.0f);

            float area = circle.ComputeSubmergedArea(ref normal, -10.0f, ref transform, out Vector2F sc);

            Assert.Equal(0.0f, area);
        }

        /// <summary>
        ///     Tests that compute submerged area returns full area when circle is under water
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_UnderWater_ReturnsFullArea()
        {
            CircleShape circle = new CircleShape(1.0f, 1.0f);
            circle.Position = new Vector2F(0.0f, 0.0f);
            ControllerTransform transform = new ControllerTransform
            {
                Position = new Vector2F(0.0f, 0.0f),
                Rotation = Complex.One
            };
            Vector2F normal = new Vector2F(0.0f, -1.0f);

            float area = circle.ComputeSubmergedArea(ref normal, 10.0f, ref transform, out Vector2F sc);

            Assert.True(area > 0.0f);
        }

        /// <summary>
        ///     Tests that compare to returns true for equal circles
        /// </summary>
        [Fact]
        public void CompareTo_EqualCircles_ReturnsTrue()
        {
            CircleShape a = new CircleShape(2.0f, 1.0f);
            CircleShape b = new CircleShape(2.0f, 1.0f);

            bool equal = a.CompareTo(b);

            Assert.True(equal);
        }

        /// <summary>
        ///     Tests that compare to returns false for different circles
        /// </summary>
        [Fact]
        public void CompareTo_DifferentCircles_ReturnsFalse()
        {
            CircleShape a = new CircleShape(2.0f, 1.0f);
            CircleShape b = new CircleShape(3.0f, 1.0f);

            bool equal = a.CompareTo(b);

            Assert.False(equal);
        }

        /// <summary>
        ///     Tests that clone creates independent copy
        /// </summary>
        [Fact]
        public void Clone_CreatesIndependentCopy()
        {
            CircleShape original = new CircleShape(2.0f, 1.0f);
            original.Position = new Vector2F(3.0f, 4.0f);

            CircleShape clone = (CircleShape)original.Clone();

            Assert.NotSame(original, clone);
            Assert.Equal(original.GetRadius, clone.GetRadius);
            Assert.Equal(original.Position, clone.Position);
            Assert.Equal(original.ShapeType, clone.ShapeType);
        }

        /// <summary>
        ///     Tests that compute submerged area returns partial area when partially submerged
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_PartiallySubmerged_ReturnsPartialArea()
        {
            CircleShape circle = new CircleShape(1.0f, 1.0f);
            circle.Position = new Vector2F(0.0f, 0.0f);
            ControllerTransform transform = new ControllerTransform
            {
                Position = new Vector2F(0.0f, 0.0f),
                Rotation = Complex.One
            };
            Vector2F normal = new Vector2F(0.0f, -1.0f);

            float area = circle.ComputeSubmergedArea(ref normal, 0.5f, ref transform, out Vector2F sc);

            Assert.True(area > 0.0f);
            Assert.True(area < Constant.Pi * 1.0f);
        }

        /// <summary>
        ///     Tests that ray cast returns false when ray starts inside circle
        /// </summary>
        [Fact]
        public void RayCast_WhenRayStartsInsideCircle_ReturnsFalse()
        {
            CircleShape circle = new CircleShape(5.0f, 1.0f);
            ControllerTransform transform = new ControllerTransform
            {
                Position = new Vector2F(0.0f, 0.0f),
                Rotation = Complex.One
            };
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(2.0f, 0.0f),
                Point2 = new Vector2F(10.0f, 0.0f),
                MaxFraction = 1.0f
            };

            bool hit = circle.RayCast(out RayCastOutput output, ref input, ref transform, 0);

            Assert.False(hit);
        }

        /// <summary>
        ///     Tests that test point on edge returns true
        /// </summary>
        [Fact]
        public void TestPoint_OnEdge_ShouldReturnTrue()
        {
            CircleShape circle = new CircleShape(5.0f, 1.0f);
            ControllerTransform transform = new ControllerTransform
            {
                Position = new Vector2F(0.0f, 0.0f),
                Rotation = Complex.One
            };
            Vector2F point = new Vector2F(5.0f, 0.0f);

            bool result = circle.TestPoint(ref transform, ref point);

            Assert.True(result);
        }
    }
}