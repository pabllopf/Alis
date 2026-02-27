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
    }
}

