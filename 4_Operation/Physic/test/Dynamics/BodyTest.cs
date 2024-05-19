// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BodyTest.cs
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
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Solver;
using Alis.Core.Physic.Test.Collision.BroadPhase.Sample;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The body test class
    /// </summary>
    public class BodyTest
    {
        /// <summary>
        ///     Tests that constructor test
        /// </summary>
        [Fact]
        public void ConstructorTest()
        {
            Vector2 position = new Vector2(0, 0);
            Vector2 linearVelocity = new Vector2(1, 1);
            BodyType bodyType = BodyType.Dynamic;
            float angle = 0.0f;
            float angularVelocity = 0.0f;
            float linearDamping = 0.0f;
            float angularDamping = 0.0f;
            bool allowSleep = true;
            bool awake = true;
            bool fixedRotation = false;
            bool isBullet = false;
            bool enabled = true;
            float gravityScale = 1.0f;
            
            Body body = new Body(position, linearVelocity, bodyType, angle, angularVelocity, linearDamping, angularDamping, allowSleep, awake, fixedRotation, isBullet, enabled, gravityScale);
            
            Assert.NotNull(body);
            Assert.Equal(position, body.Position);
            Assert.Equal(new Vector2(0, 0), body.LinearVelocity);
            Assert.Equal(bodyType, body.BodyType);
            Assert.Equal(angle, body.Rotation);
            Assert.Equal(angularVelocity, body.AngularVelocity);
            Assert.Equal(linearDamping, body.LinearDamping);
            Assert.Equal(angularDamping, body.AngularDamping);
            Assert.Equal(allowSleep, body.SleepingAllowed);
            Assert.Equal(awake, body.Awake);
            Assert.Equal(fixedRotation, body.FixedRotation);
            Assert.Equal(isBullet, body.IsBullet);
            Assert.Equal(enabled, body.Enabled);
            Assert.Equal(gravityScale, body.GravityScale);
        }
        
        /// <summary>
        ///     Tests that apply force test
        /// </summary>
        [Fact]
        public void ApplyForceTest()
        {
            Body body = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Vector2 initialForce = body.Force;
            
            body.ApplyForce(new Vector2(1, 1));
            
            Assert.Equal(initialForce, body.Force);
        }
        
        /// <summary>
        ///     Tests that apply torque test
        /// </summary>
        [Fact]
        public void ApplyTorqueTest()
        {
            Body body = new Body(new Vector2(0, 0), new Vector2(0, 0));
            float initialTorque = body.Torque;
            
            body.ApplyTorque(1.0f);
            
            Assert.Equal(initialTorque, body.Torque);
        }
        
        /// <summary>
        ///     Tests that apply linear impulse test
        /// </summary>
        [Fact]
        public void ApplyLinearImpulseTest()
        {
            Body body = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Vector2 initialVelocity = body.LinearVelocity;
            
            body.ApplyLinearImpulse(new Vector2(1, 1));
            
            Assert.Equal(initialVelocity, body.LinearVelocity);
        }
        
        /// <summary>
        ///     Tests that apply angular impulse test
        /// </summary>
        [Fact]
        public void ApplyAngularImpulseTest()
        {
            Body body = new Body(new Vector2(0, 0), new Vector2(0, 0));
            float initialAngularVelocity = body.AngularVelocity;
            
            body.ApplyAngularImpulse(1.0f);
            
            Assert.Equal(initialAngularVelocity, body.AngularVelocity);
        }
        
        /// <summary>
        ///     Tests that reset mass data test
        /// </summary>
        [Fact]
        public void ResetMassDataTest()
        {
            Body body = new Body(new Vector2(0, 0), new Vector2(0, 0));
            float initialMass = body.Mass;
            float initialInertia = body.Inertia;
            
            body.ResetMassData();
            
            Assert.Equal(initialMass, body.Mass);
            Assert.Equal(initialInertia, body.Inertia);
        }
        
        /// <summary>
        /// Tests that inertia should set and get correctly
        /// </summary>
        [Fact]
        public void Inertia_ShouldSetAndGetCorrectly()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            float expectedInertia = 10.0f;
            
            // Act
            body.Inertia = expectedInertia;
            
            // Assert
            Assert.Equal(expectedInertia, body.Inertia);
        }
        
        /// <summary>
        /// Tests that restitution should set correctly
        /// </summary>
        [Fact]
        public void Restitution_ShouldSetCorrectly()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            float expectedRestitution = 0.5f;
            
            // Act
            body.Restitution = expectedRestitution;
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that friction should set correctly
        /// </summary>
        [Fact]
        public void Friction_ShouldSetCorrectly()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            float expectedFriction = 0.5f;
            
            // Act
            body.Friction = expectedFriction;
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that collision categories should set correctly
        /// </summary>
        [Fact]
        public void CollisionCategories_ShouldSetCorrectly()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            Category expectedCategory = Category.Cat1;
            
            // Act
            body.CollisionCategories = expectedCategory;
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that collides with should set correctly
        /// </summary>
        [Fact]
        public void CollidesWith_ShouldSetCorrectly()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            Category expectedCategory = Category.Cat1;
            
            // Act
            body.CollidesWith = expectedCategory;
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that ignore ccd with should set correctly
        /// </summary>
        [Fact]
        public void IgnoreCcdWith_ShouldSetCorrectly()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            Category expectedCategory = Category.Cat1;
            
            // Act
            body.IgnoreCcdWith = expectedCategory;
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that collision group should set correctly
        /// </summary>
        [Fact]
        public void CollisionGroup_ShouldSetCorrectly()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            short expectedGroup = 1;
            
            // Act
            body.CollisionGroup = expectedGroup;
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that is sensor should set correctly
        /// </summary>
        [Fact]
        public void IsSensor_ShouldSetCorrectly()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            bool expectedIsSensor = true;
            
            // Act
            body.IsSensor = expectedIsSensor;
            
            // Assert
            // Here you would assert that the properties of wheelJoint have been set correctly.
        }
        
        /// <summary>
        /// Tests that ignore ccd should set and get correctly
        /// </summary>
        [Fact]
        public void IgnoreCcd_ShouldSetAndGetCorrectly()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            bool expectedIgnoreCcd = true;
            
            // Act
            body.IgnoreCcd = expectedIgnoreCcd;
            
            // Assert
            Assert.Equal(expectedIgnoreCcd, body.IgnoreCcd);
        }
        
        /// <summary>
        /// Tests that rotation should set and get correctly
        /// </summary>
        [Fact]
        public void Rotation_ShouldSetAndGetCorrectly()
        {
            ContactManager contactManager = new ContactManager(
                new BroadPhaseImplementation()
            );
            
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            float expectedRotation = 1.0f;
            
            // Act
            body.Rotation = expectedRotation;
            
            // Assert
            Assert.Equal(expectedRotation, body.Rotation);
        }
        
        /// <summary>
        /// Tests that is static should return correctly
        /// </summary>
        [Fact]
        public void IsStatic_ShouldReturnCorrectly()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Static);
            
            // Assert
            Assert.True(body.IsStatic);
        }
        
        /// <summary>
        /// Tests that is kinematic should return correctly
        /// </summary>
        [Fact]
        public void IsKinematic_ShouldReturnCorrectly()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Kinematic);
            
            // Assert
            Assert.True(body.IsKinematic);
        }
        
        /// <summary>
        /// Tests that is dynamic should return correctly
        /// </summary>
        [Fact]
        public void IsDynamic_ShouldReturnCorrectly()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            
            // Assert
            Assert.True(body.IsDynamic);
        }
        
        /// <summary>
        /// Tests that world center should return correctly
        /// </summary>
        [Fact]
        public void WorldCenter_ShouldReturnCorrectly()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            Vector2 expectedWorldCenter = new Vector2(1.0f, 1.0f);
            
            // Act
            body.WorldCenter = expectedWorldCenter;
            
            // Assert
            Assert.Equal(expectedWorldCenter, body.WorldCenter);
        }
        
        /// <summary>
        /// Tests that local center should set and get correctly
        /// </summary>
        [Fact]
        public void LocalCenter_ShouldSetAndGetCorrectly()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            Vector2 expectedLocalCenter = new Vector2(1.0f, 1.0f);
            
            // Act
            body.LocalCenter = expectedLocalCenter;
            
            // Assert
            Assert.Equal(expectedLocalCenter, body.LocalCenter);
        }
        
        /// <summary>
        /// Tests that body constructor test
        /// </summary>
        [Fact]
        public void BodyConstructorTest()
        {
            // Arrange
            Vector2 position = new Vector2(1, 1);
            Vector2 linearVelocity = new Vector2(0, 0);
            BodyType bodyType = BodyType.Dynamic;
            float angle = 0.0f;
            float angularVelocity = 0.0f;
            float linearDamping = 0.0f;
            float angularDamping = 0.0f;
            bool allowSleep = true;
            bool awake = true;
            bool fixedRotation = false;
            bool isBullet = false;
            bool enabled = true;
            float gravityScale = 1.0f;
            
            // Act
            Body body = new Body(position, linearVelocity, bodyType, angle, angularVelocity, linearDamping, angularDamping, allowSleep, awake, fixedRotation, isBullet, enabled, gravityScale);
            
            // Assert
            Assert.Equal(position, body.Position);
            Assert.Equal(linearVelocity, body.LinearVelocity);
            Assert.Equal(bodyType, body.BodyType);
            Assert.Equal(angle, body.Rotation);
            Assert.Equal(angularVelocity, body.AngularVelocity);
            Assert.Equal(linearDamping, body.LinearDamping);
            Assert.Equal(angularDamping, body.AngularDamping);
            Assert.Equal(allowSleep, body.SleepingAllowed);
            Assert.Equal(awake, body.Awake);
            Assert.Equal(fixedRotation, body.FixedRotation);
            Assert.Equal(isBullet, body.IsBullet);
            Assert.Equal(enabled, body.Enabled);
            Assert.Equal(gravityScale, body.GravityScale);
        }
        
        /// <summary>
        /// Tests that body is island test
        /// </summary>
        [Fact]
        public void BodyIsIslandTest()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            
            // Act
            bool isIsland = body.IsIsland;
            
            // Assert
            Assert.False(isIsland);
        }
        
        /// <summary>
        /// Tests that body is static test
        /// </summary>
        [Fact]
        public void BodyIsStaticTest()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Static);
            
            // Act
            bool isStatic = body.IsStatic;
            
            // Assert
            Assert.True(isStatic);
        }
        
        /// <summary>
        /// Tests that body is kinematic test
        /// </summary>
        [Fact]
        public void BodyIsKinematicTest()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Kinematic);
            
            // Act
            bool isKinematic = body.IsKinematic;
            
            // Assert
            Assert.True(isKinematic);
        }
        
        /// <summary>
        /// Tests that body is dynamic test
        /// </summary>
        [Fact]
        public void BodyIsDynamicTest()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            
            // Act
            bool isDynamic = body.IsDynamic;
            
            // Assert
            Assert.True(isDynamic);
        }
        
        /// <summary>
        /// Tests that body get world point test
        /// </summary>
        [Fact]
        public void BodyGetWorldPointTest()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            Vector2 localPoint = new Vector2(1, 1);
            
            // Act
            Vector2 worldPoint = body.GetWorldPoint(localPoint);
            
            // Assert
            Assert.Equal(localPoint, worldPoint);
        }
        
        /// <summary>
        /// Tests that body get world vector test
        /// </summary>
        [Fact]
        public void BodyGetWorldVectorTest()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            Vector2 localVector = new Vector2(1, 1);
            
            // Act
            Vector2 worldVector = body.GetWorldVector(localVector);
            
            // Assert
            Assert.Equal(localVector, worldVector);
        }
        
        /// <summary>
        /// Tests that body get local point test
        /// </summary>
        [Fact]
        public void BodyGetLocalPointTest()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            Vector2 worldPoint = new Vector2(1, 1);
            
            // Act
            Vector2 localPoint = body.GetLocalPoint(worldPoint);
            
            // Assert
            Assert.Equal(worldPoint, localPoint);
        }
        
        /// <summary>
        /// Tests that body get local vector test
        /// </summary>
        [Fact]
        public void BodyGetLocalVectorTest()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            Vector2 worldVector = new Vector2(1, 1);
            
            // Act
            Vector2 localVector = body.GetLocalVector(worldVector);
            
            // Assert
            Assert.Equal(worldVector, localVector);
        }
        
        /// <summary>
        /// Tests that body get linear velocity from world point test
        /// </summary>
        [Fact]
        public void BodyGetLinearVelocityFromWorldPointTest()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            Vector2 worldPoint = new Vector2(1, 1);
            
            // Act
            Vector2 linearVelocity = body.GetLinearVelocityFromWorldPoint(worldPoint);
            
            // Assert
            Assert.Equal(new Vector2(), linearVelocity);
        }
        
        /// <summary>
        /// Tests that body get linear velocity from local point test
        /// </summary>
        [Fact]
        public void BodyGetLinearVelocityFromLocalPointTest()
        {
            // Arrange
            Body body = new Body(new Vector2(), new Vector2(), BodyType.Dynamic);
            Vector2 localPoint = new Vector2(1, 1);
            
            // Act
            Vector2 linearVelocity = body.GetLinearVelocityFromLocalPoint(localPoint);
            
            // Assert
            Assert.Equal(new Vector2(), linearVelocity);
        }
    }
}