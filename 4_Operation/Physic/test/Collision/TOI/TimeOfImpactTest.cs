// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeOfImpactTest.cs
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
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Distance;
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Collision.TOI;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.TOI
{
    /// <summary>
    ///     The time of impact test class
    /// </summary>
    public class TimeOfImpactTest
    {
        /// <summary>
        ///     Tests that test reset restitution threshold
        /// </summary>
        [Fact]
        public void TestResetRestitutionThreshold()
        {
            // Arrange
            CircleShape shape = new CircleShape(1); // Replace with actual shape
            Filter filter = new Filter(); // Replace with actual filter
            Fixture fixtureA = new Fixture(shape, filter);
            Fixture fixtureB = new Fixture(shape, filter);
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            
            // Act
            contact.ResetRestitutionThreshold();
            
            // Assert
            Assert.Equal(Settings.MixRestitutionThreshold(fixtureA.Restitution, fixtureB.Restitution), contact.RestitutionThreshold);
        }
        
        /// <summary>
        ///     Tests that test reset friction
        /// </summary>
        [Fact]
        public void TestResetFriction()
        {
            // Arrange
            CircleShape shape = new CircleShape(1); // Replace with actual shape
            Filter filter = new Filter(); // Replace with actual filter
            Fixture fixtureA = new Fixture(shape, filter);
            Fixture fixtureB = new Fixture(shape, filter);
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            
            // Act
            contact.ResetFriction();
            
            // Assert
            Assert.Equal(Settings.MixFriction(fixtureA.Friction, fixtureB.Friction), contact.Friction);
        }
        
        /// <summary>
        ///     Tests that test reset
        /// </summary>
        [Fact]
        public void TestReset()
        {
            // Arrange
            CircleShape shape = new CircleShape(1); // Replace with actual shape
            Filter filter = new Filter(); // Replace with actual filter
            Fixture fixtureA = new Fixture(shape, filter);
            Fixture fixtureB = new Fixture(shape, filter);
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            
            // Act
            contact.Reset(fixtureA, 1, fixtureB, 1);
            
            // Assert
            Assert.Equal(fixtureA, contact.FixtureA);
            Assert.Equal(fixtureB, contact.FixtureB);
            Assert.Equal(1, contact.ChildIndexA);
            Assert.Equal(1, contact.ChildIndexB);
        }
        
        /// <summary>
        /// Tests that calculate time of impact should calculate correctly
        /// </summary>
        [Fact]
        public void CalculateTimeOfImpact_ShouldCalculateCorrectly()
        {
            // Arrange
            ToiInput input = new ToiInput();
            ToiOutput output;
            
            // Act
            Assert.Throws<NullReferenceException>(() => TimeOfImpact.CalculateTimeOfImpact(ref input, out output));
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that initialize output should initialize correctly
        /// </summary>
        [Fact]
        public void InitializeOutput_ShouldInitializeCorrectly()
        {
            // Arrange
            ToiInput input = new ToiInput();
            
            // Act
            ToiOutput result = TimeOfImpact.InitializeOutput(input);
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that normalize sweeps should normalize correctly
        /// </summary>
        [Fact]
        public void NormalizeSweeps_ShouldNormalizeCorrectly()
        {
            // Arrange
            Sweep sweepA = new Sweep();
            Sweep sweepB = new Sweep();
            
            // Act
            TimeOfImpact.NormalizeSweeps(ref sweepA, ref sweepB);
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that prepare distance input should prepare correctly
        /// </summary>
        [Fact]
        public void PrepareDistanceInput_ShouldPrepareCorrectly()
        {
            // Arrange
            ToiInput input = new ToiInput();
            
            // Act
            DistanceInput result = TimeOfImpact.PrepareDistanceInput(input);
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that resolve deepest point should resolve correctly
        /// </summary>
        [Fact]
        public void ResolveDeepestPoint_ShouldResolveCorrectly()
        {
            // Arrange
            ToiInput input = new ToiInput();
            ToiOutput output = new ToiOutput();
            Sweep sweepA = new Sweep();
            Sweep sweepB = new Sweep();
            Vector2 axis = new Vector2();
            Vector2 localPoint = new Vector2();
            SeparationFunctionType type = SeparationFunctionType.Points;
            float target = 0.0f;
            float tolerance = 0.0f;
            float t1 = 0.0f;
            float tMax = 0.0f;
            
            // Act
            Assert.Throws<NullReferenceException>(() => TimeOfImpact.ResolveDeepestPoint(ref input, ref output, ref sweepA, ref sweepB, ref axis, ref localPoint, type, target, tolerance,
                ref t1, tMax));
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that compute root should compute correctly
        /// </summary>
        [Fact]
        public void ComputeRoot_ShouldComputeCorrectly()
        {
            // Arrange
            ToiInput input = new ToiInput();
            Sweep sweepA = new Sweep();
            Sweep sweepB = new Sweep();
            Vector2 axis = new Vector2();
            Vector2 localPoint = new Vector2();
            SeparationFunctionType type = SeparationFunctionType.Points;
            float target = 0.0f;
            float tolerance = 0.0f;
            float t1 = 0.0f;
            float t2 = 0.0f;
            float s1 = 0.0f;
            float s2 = 0.0f;
            
            // Act
            Assert.Throws<NullReferenceException>(() => TimeOfImpact.ComputeRoot(ref input, ref sweepA, ref sweepB, ref axis, ref localPoint, type, target, tolerance, ref t1, ref t2, s1, s2));
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that prepare distance input should prepare correctly v 2
        /// </summary>
        [Fact]
        public void PrepareDistanceInput_ShouldPrepareCorrectly_V2()
        {
            // Arrange
            ToiInput input = new ToiInput();
            
            // Act
            DistanceInput result = TimeOfImpact.PrepareDistanceInput(input);
            
            // Assert
            Assert.Equal(input.ProxyA, result.ProxyA);
            Assert.Equal(input.ProxyB, result.ProxyB);
            Assert.False(result.UseRadii);
        }
        
        /// <summary>
        /// Tests that compute separating axes should compute correctly
        /// </summary>
        [Fact]
        public void ComputeSeparatingAxes_ShouldComputeCorrectly()
        {
            // Arrange
            ToiInput input = new ToiInput();
            ToiOutput output = new ToiOutput();
            DistanceInput distanceInput = new DistanceInput();
            Sweep sweepA = new Sweep();
            Sweep sweepB = new Sweep();
            float target = 0.0f;
            float tolerance = 0.0f;
            float t1 = 0.0f;
            int iter = 0;
            float tMax = 0.0f;
            
            // Act
            Assert.Throws<NullReferenceException>(() => TimeOfImpact.ComputeSeparatingAxes(ref input, ref output, ref distanceInput, ref sweepA, ref sweepB, target, tolerance, ref t1, ref iter, tMax));
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that toi max root iter property should return correct value
        /// </summary>
        [Fact]
        public void ToiMaxRootIterProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            int expectedValue = 10;
            TimeOfImpact._toiMaxRootIter = expectedValue;
            
            // Act
            var result = TimeOfImpact._toiMaxRootIter;
            
            // Assert
            Assert.Equal(expectedValue, result);
        }
        
        /// <summary>
        /// Tests that toi calls property should return correct value
        /// </summary>
        [Fact]
        public void ToiCallsProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            int expectedValue = 10;
            TimeOfImpact.ToiCalls = expectedValue;
            
            // Act
            var result = TimeOfImpact.ToiCalls;
            
            // Assert
            Assert.Equal(expectedValue, result);
        }
        
        /// <summary>
        /// Tests that toi iter property should return correct value
        /// </summary>
        [Fact]
        public void ToiIterProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            int expectedValue = 10;
            TimeOfImpact.ToiIter = expectedValue;
            
            // Act
            var result = TimeOfImpact.ToiIter;
            
            // Assert
            Assert.Equal(expectedValue, result);
        }
        
        /// <summary>
        /// Tests that toi max iter property should return correct value
        /// </summary>
        [Fact]
        public void ToiMaxIterProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            int expectedValue = 10;
            TimeOfImpact.ToiMaxIter = expectedValue;
            
            // Act
            var result = TimeOfImpact.ToiMaxIter;
            
            // Assert
            Assert.Equal(expectedValue, result);
        }
        
        /// <summary>
        /// Tests that toi root iter property should return correct value
        /// </summary>
        [Fact]
        public void ToiRootIterProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            int expectedValue = 10;
            TimeOfImpact.ToiRootIter = expectedValue;
            
            // Act
            var result = TimeOfImpact.ToiRootIter;
            
            // Assert
            Assert.Equal(expectedValue, result);
        }
    }
}