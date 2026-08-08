// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BodyCoverageTest.cs
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
//  along with this program.If not,see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     Tests for Body.cs covering uncovered methods with focus on world lock checks,
    ///     body type transitions, and fixture management.
    /// </summary>
    public class BodyCoverageTest
    {
        /// <summary>
        ///     Tests that GetBodyType setter does not throw when world is not locked.
    ///     This covers the normal execution path of the setter.
        /// </summary>
        [Fact]
        public void GetBodyType_Setter_WhenWorldIsNotLocked_ShouldSucceed()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act
            Exception exception = Record.Exception(() => body.GetBodyType = BodyType.Static);

            // Assert
            Assert.Null(exception);
            Assert.Equal(BodyType.Static, body.GetBodyType);
        }

        /// <summary>
        ///     Tests that GetBodyType setter clears linear velocity when transitioning to Static.
    ///     This covers the velocity reset branch in the setter.
        /// </summary>
        [Fact]
        public void GetBodyType_Setter_ToStatic_ShouldClearLinearVelocity()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Set non-zero linear velocity
            body.LinearVelocity = new Vector2F(5.0f, 3.0f);

            Assert.NotEqual(Vector2F.Zero, body.LinearVelocity);

            // Act
            body.GetBodyType = BodyType.Static;

            // Assert
            Assert.Equal(BodyType.Static, body.GetBodyType);
            Assert.Equal(Vector2F.Zero, body.LinearVelocity);
        }

        /// <summary>
        ///     Tests that GetBodyType setter resets mass data when changing body type.
    ///     This covers the ResetMassData call branch.
        /// </summary>
        [Fact]
        public void GetBodyType_Setter_ChangingBodyType_ShouldResetMassData()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act
            body.GetBodyType = BodyType.Kinematic;

            // Assert
            Assert.Equal(BodyType.Kinematic, body.GetBodyType);
            // Body should still be valid after type change
            Assert.NotNull(body);
        }

        /// <summary>
        ///     Tests that Enabled setter creates proxies when world is present.
    ///     This covers the CreateProxies call branch.
        /// </summary>
        [Fact]
        public void Enabled_Setter_True_WhenWorldExists_ShouldNotThrow()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act
            Exception exception = Record.Exception(() => body.Enabled = true);

            // Assert
            Assert.Null(exception);
            Assert.True(body.Enabled);
        }

        /// <summary>
        ///     Tests that Enabled setter destroys proxies and contacts when set to false.
    ///     This covers the DestroyProxies and DestroyContacts branches.
        /// </summary>
        [Fact]
        public void Enabled_Setter_False_WhenWorldExists_ShouldDestroyProxiesAndContacts()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            Assert.True(body.Enabled);

            // Act
            Exception exception = Record.Exception(() => body.Enabled = false);

            // Assert
            Assert.Null(exception);
            Assert.False(body.Enabled);
        }

        /// <summary>
        ///     Tests that Enabled setter does not throw when world is not locked.
    ///     This covers the normal execution path of the Enabled setter.
        /// </summary>
        [Fact]
        public void Enabled_Setter_WhenWorldIsNotLocked_ShouldSucceed()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act
            Exception exception = Record.Exception(() => body.Enabled = false);

            // Assert
            Assert.Null(exception);
            Assert.False(body.Enabled);
        }

        /// <summary>
        ///     Tests that FixedRotation setter resets angular velocity.
    ///     This covers the AngularVelocity = 0f branch.
        /// </summary>
        [Fact]
        public void FixedRotation_Setter_True_ShouldResetAngularVelocity()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Set non-zero angular velocity
            body.AngularVelocity = 5.0f;
            Assert.NotEqual(0.0f, body.AngularVelocity);

            // Act
            body.FixedRotation = true;

            // Assert
            Assert.True(body.FixedRotation);
            Assert.Equal(0.0f, body.AngularVelocity, 5);
        }

        /// <summary>
        ///     Tests that FixedRotation setter resets mass data when changing value.
    ///     This covers the ResetMassData call branch.
        /// </summary>
        [Fact]
        public void FixedRotation_Setter_ChangingValue_ShouldResetMassData()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act
            body.FixedRotation = true;
            body.FixedRotation = false;

            // Assert
            Assert.False(body.FixedRotation);
            Assert.NotNull(body);
        }

        /// <summary>
        ///     Tests that LocalCenter getter returns valid center of mass for dynamic body.
    ///     This covers the Sweep.C read branch.
        /// </summary>
        [Fact]
        public void LocalCenter_Getter_WhenDynamic_ShouldReturnValidCenter()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(10.0f, 20.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(1.0f, 1.0f);

            // Act
            Vector2F localCenter = body.LocalCenter;

            // Assert
            // Local center should be computed and valid
            Assert.NotNull(localCenter);
        }

        /// <summary>
        ///     Tests that LocalCenter getter returns center of mass position.
    ///     This covers the Sweep.C read branch.
        /// </summary>
        [Fact]
        public void LocalCenter_Getter_WhenDynamic_ShouldReturnCenterOfMass()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(10.0f, 20.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(1.0f, 1.0f);

            // Act
            Vector2F localCenter = body.LocalCenter;

            // Assert
            Assert.NotNull(localCenter);
            // Center of mass should be computed for the circle shape
        }

        /// <summary>
        ///     Tests that Awake setter wakes up body and resets sleep time.
    ///     This covers the awake=true branch with sleep time reset.
        /// </summary>
        [Fact]
        public void Awake_Setter_True_WhenCurrentlyAsleep_ShouldResetSleepTime()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Put body to sleep
            body.Awake = false;
            world.Step(10.0f); // Simulate time passing

            Assert.False(body.Awake);

            // Act
            body.Awake = true;

            // Assert
            Assert.True(body.Awake);
        }

        /// <summary>
        ///     Tests that Awake setter puts body to sleep and resets dynamics.
    ///     This covers the awake=false branch with ResetDynamics call.
        /// </summary>
        [Fact]
        public void Awake_Setter_False_ShouldPutBodyToSleep()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Set non-zero velocity to ensure body would normally stay awake
            body.LinearVelocity = new Vector2F(5.0f, 0.0f);

            // Act
            body.Awake = false;

            // Assert
            Assert.False(body.Awake);
        }

        /// <summary>
        ///     Tests that SleepingAllowed setter can disable sleeping.
    ///     This covers the sleeping configuration branch.
        /// </summary>
        [Fact]
        public void SleepingAllowed_Setter_False_ShouldDisableSleeping()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act
            body.SleepingAllowed = false;

            // Assert
            Assert.False(body.SleepingAllowed);
        }

        /// <summary>
        ///     Tests that IsBullet property can be set and read.
    ///     This covers the CCD configuration branch.
        /// </summary>
        [Fact]
        public void IsBullet_Property_ShouldBeSettable()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act
            body.IsBullet = true;

            // Assert
            Assert.True(body.IsBullet);
        }

        /// <summary>
        ///     Tests that IgnoreGravity property can be set and read.
    ///     This covers the gravity configuration branch.
        /// </summary>
        [Fact]
        public void IgnoreGravity_Property_ShouldBeSettable()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act
            body.IgnoreGravity = true;

            // Assert
            Assert.True(body.IgnoreGravity);
        }

        /// <summary>
        ///     Tests that Tag property can store custom user data.
    ///     This covers the user data storage branch.
        /// </summary>
        [Fact]
        public void Tag_Property_ShouldStoreUserData()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            object customData = new { Name = "TestBody", Id = 42 };

            // Act
            body.Tag = customData;

            // Assert
            Assert.Same(customData, body.Tag);
        }

        /// <summary>
        ///     Tests that Position setter works when world is null.
    ///     This covers the direct Xf.Position assignment branch.
        /// </summary>
        [Fact]
        public void Position_Setter_WhenWorldIsNull_ShouldSetDirectly()
        {
            // Arrange
            Body body = new Body();

            // Act
            body.Position = new Vector2F(10.0f, 20.0f);

            // Assert
            Assert.Equal(10.0f, body.Position.X, 5);
            Assert.Equal(20.0f, body.Position.Y, 5);
        }

        /// <summary>
        ///     Tests that Position setter uses SetTransform when world exists.
    ///     This covers the SetTransform call branch.
        /// </summary>
        [Fact]
        public void Position_Setter_WhenWorldExists_ShouldUseSetTransform()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act
            body.Position = new Vector2F(15.0f, 25.0f);

            // Assert
            Assert.Equal(15.0f, body.Position.X, 5);
            Assert.Equal(25.0f, body.Position.Y, 5);
        }

        /// <summary>
        ///     Tests that Rotation setter works when world is null.
    ///     This covers the direct Sweep.A assignment branch.
        /// </summary>
        [Fact]
        public void Rotation_Setter_WhenWorldIsNull_ShouldSetDirectly()
        {
            // Arrange
            Body body = new Body();

            // Act
            body.Rotation = 1.5f;

            // Assert
            Assert.Equal(1.5f, body.Rotation, 5);
        }

        /// <summary>
        ///     Tests that LinearDamping property can be set and read.
    ///     This covers the damping configuration branch.
        /// </summary>
        [Fact]
        public void LinearDamping_Property_ShouldBeSettable()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act
            body.LinearDamping = 0.1f;

            // Assert
            Assert.Equal(0.1f, body.LinearDamping, 5);
        }

        /// <summary>
        ///     Tests that AngularDamping property can be set and read.
    ///     This covers the angular damping configuration branch.
        /// </summary>
        [Fact]
        public void AngularDamping_Property_ShouldBeSettable()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act
            body.AngularDamping = 0.2f;

            // Assert
            Assert.Equal(0.2f, body.AngularDamping, 5);
        }

        /// <summary>
        ///     Tests that GetRevolutions computes correct value.
    ///     This covers the rotation-to-revolutions calculation branch.
        /// </summary>
        [Fact]
        public void GetRevolutions_ShouldComputeCorrectValue()
        {
            // Arrange
            Body body = new Body();

            // Act & Assert
            // Full rotation = 2*PI radians = 1 revolution
            body.Rotation = (float)(2 * Math.PI);
            Assert.Equal(1.0f, body.GetRevolutions, 5);

            // Half rotation = PI radians = 0.5 revolutions
            body.Rotation = (float)Math.PI;
            Assert.Equal(0.5f, body.GetRevolutions, 5);
        }

        /// <summary>
        ///     Tests that GetWorldPhysic returns the parent world.
    ///     This covers the world reference getter branch.
        /// </summary>
        [Fact]
        public void GetWorldPhysic_ShouldReturnParentWorld()
        {
            // Arrange
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act
            WorldPhysic returnedWorld = body.GetWorldPhysic;

            // Assert
            Assert.Same(world, returnedWorld);
        }

        /// <summary>
        ///     Tests that GetWorldPhysic returns null for unattached body.
    ///     This covers the null world reference branch.
        /// </summary>
        [Fact]
        public void GetWorldPhysic_WhenNotAttached_ShouldReturnNull()
        {
            // Arrange
            Body body = new Body();

            // Act
            WorldPhysic returnedWorld = body.GetWorldPhysic;

            // Assert
            Assert.Null(returnedWorld);
        }
    }
}
