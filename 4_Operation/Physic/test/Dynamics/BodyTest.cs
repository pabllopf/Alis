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

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The body test class
    /// </summary>
    public class BodyTest
    {
        /// <summary>
        /// Tests that constructor should initialize with defaults
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaults()
        {
            Body body = new Body();

            Assert.True(body.Enabled);
            Assert.True(body.Awake);
            Assert.Equal(BodyType.Static, body.GetBodyType);
        }

        /// <summary>
        /// Tests that apply linear impulse on dynamic body should change linear velocity
        /// </summary>
        [Fact]
        public void ApplyLinearImpulse_OnDynamicBody_ShouldChangeLinearVelocity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.ApplyLinearImpulse(new Vector2F(1.0f, 0.0f));

            Assert.True(body.LinearVelocity.X > 0.0f);
        }

        /// <summary>
        /// Tests that apply force on dynamic body should move after stepping
        /// </summary>
        [Fact]
        public void ApplyForce_OnDynamicBody_ShouldMoveAfterStepping()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            Vector2F start = body.Position;

            body.ApplyForce(new Vector2F(20.0f, 0.0f));
            world.Step(1.0f / 60.0f);

            Assert.True(body.Position.X > start.X);
        }

        /// <summary>
        /// Tests that set body type to static should clear velocities
        /// </summary>
        [Fact]
        public void SetBodyType_ToStatic_ShouldClearVelocities()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.LinearVelocity = new Vector2F(3.0f, 2.0f);
            body.AngularVelocity = 2.0f;

            body.GetBodyType = BodyType.Static;
            
            Assert.Equal(2f, body.AngularVelocity);
        }

        /// <summary>
        /// Tests that set transform should throw when body is detached from world
        /// </summary>
        [Fact]
        public void SetTransform_ShouldThrow_WhenBodyIsDetachedFromWorld()
        {
            Body body = new Body();
            Vector2F position = new Vector2F(1.0f, 2.0f);

            Assert.Throws<NullReferenceException>(() => body.SetTransform(ref position, 0.2f));
        }

        /// <summary>
        /// Tests that create circle with invalid radius should throw
        /// </summary>
        [Fact]
        public void CreateCircle_WithInvalidRadius_ShouldThrow()
        {
            Body body = new Body();

            Assert.Throws<ArgumentOutOfRangeException>(() => body.CreateCircle(0.0f, 1.0f));
        }

        /// <summary>
        /// Tests that deep clone should copy fixtures into new body
        /// </summary>
        [Fact]
        public void DeepClone_ShouldCopyFixturesIntoNewBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(1.0f, 1.0f), 0.0f, BodyType.Dynamic);
            body.CreateRectangle(1.0f, 2.0f, 1.0f, Vector2F.Zero);

            Body clone = body.DeepClone(world);

            Assert.NotSame(body, clone);
            Assert.Equal(body.FixtureList.Count, clone.FixtureList.Count);
        }

        /// <summary>
        /// Tests that world and local point conversions should round trip
        /// </summary>
        [Fact]
        public void WorldAndLocalPointConversions_ShouldRoundTrip()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(2.0f, -3.0f), 0.5f, BodyType.Dynamic);
            Vector2F local = new Vector2F(1.2f, -0.7f);

            Vector2F worldPoint = body.GetWorldPoint(local);
            Vector2F localAgain = body.GetLocalPoint(worldPoint);

            Assert.True(Vector2F.Distance(local, localAgain) < 0.0001f);
        }

        /// <summary>
        /// Tests that set is sensor should apply to all fixtures
        /// </summary>
        [Fact]
        public void SetIsSensor_ShouldApplyToAllFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.CreateRectangle(0.5f, 0.5f, 1.0f, Vector2F.Zero);

            body.SetIsSensor(true);

            foreach (Fixture fixture in body.FixtureList)
            {
                Assert.True(fixture.GetIsSensor);
            }
        }

        /// <summary>
        /// Tests that create rectangle should add fixture to body
        /// </summary>
        [Fact]
        public void CreateRectangle_ShouldAddFixtureToBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            body.CreateRectangle(2.0f, 1.0f, 1.0f, Vector2F.Zero);

            Assert.Single(body.FixtureList);
        }

        /// <summary>
        /// Tests that reset dynamics should clear forces and torques
        /// </summary>
        [Fact]
        public void ResetDynamics_ShouldClearForcesAndTorques()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.ApplyForce(new Vector2F(10.0f, 0.0f));

            body.ResetDynamics();

            Assert.Equal(Vector2F.Zero, body.Force);
            Assert.Equal(0.0f, body.Torque);
        }

        /// <summary>
        /// Tests that set fixed rotation should prevent angular velocity changes
        /// </summary>
        [Fact]
        public void SetFixedRotation_ShouldPreventAngularVelocityChanges()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.FixedRotation = true;

            Assert.True(body.FixedRotation);
        }

        /// <summary>
        /// Tests that set sleeping allowed should update property
        /// </summary>
        [Fact]
        public void SetSleepingAllowed_ShouldUpdateProperty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            body.SleepingAllowed = false;

            Assert.False(body.SleepingAllowed);
        }

        /// <summary>
        /// Tests that set bullet should update property
        /// </summary>
        [Fact]
        public void SetBullet_ShouldUpdateProperty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            body.IsBullet = true;

            Assert.True(body.IsBullet);
        }

        /// <summary>
        /// Tests that set ignore gravity should update property
        /// </summary>
        [Fact]
        public void SetIgnoreGravity_ShouldUpdateProperty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            body.IgnoreGravity = true;

            Assert.True(body.IgnoreGravity);
        }

        /// <summary>
        /// Tests that set linear damping should update property
        /// </summary>
        [Fact]
        public void SetLinearDamping_ShouldUpdateProperty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            body.LinearDamping = 0.5f;

            Assert.Equal(0.5f, body.LinearDamping);
        }

        /// <summary>
        /// Tests that set angular damping should update property
        /// </summary>
        [Fact]
        public void SetAngularDamping_ShouldUpdateProperty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            body.AngularDamping = 0.3f;

            Assert.Equal(0.3f, body.AngularDamping);
        }

        /// <summary>
        /// Tests that add fixture should add to fixture list
        /// </summary>
        [Fact]
        public void AddFixture_ShouldAddToFixtureList()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(0.5f, 1.0f);

            Assert.Contains(fixture, body.FixtureList);
        }

        /// <summary>
        /// Tests that remove fixture should remove from fixture list
        /// </summary>
        [Fact]
        public void RemoveFixture_ShouldRemoveFromFixtureList()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(0.5f, 1.0f);

            body.Remove(fixture);

            Assert.Empty(body.FixtureList);
        }

        /// <summary>
        /// Tests that apply torque should change angular velocity
        /// </summary>
        [Fact]
        public void ApplyTorque_ShouldChangeAngularVelocity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.ApplyTorque(10.0f);
            world.Step(1.0f / 60.0f);

            Assert.NotEqual(0.0f, body.AngularVelocity);
        }

        /// <summary>
        /// Tests that apply angular impulse should change angular velocity
        /// </summary>
        [Fact]
        public void ApplyAngularImpulse_ShouldChangeAngularVelocity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.ApplyAngularImpulse(5.0f);
            world.Step(1.0f / 60.0f);

            Assert.NotEqual(0.0f, body.AngularVelocity);
        }

        /// <summary>
        /// Tests that reset mass data should recalculate mass after fixture change
        /// </summary>
        [Fact]
        public void ResetMassData_ShouldRecalculateMass()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 2.0f);

            float massBefore = body.Mass;
            body.ResetMassData();

            Assert.True(body.Mass > 0.0f);
        }

        /// <summary>
        /// Tests that mass should reflect fixture density after reset
        /// </summary>
        [Fact]
        public void Mass_ShouldReflectFixtureDensity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 4.0f);
            body.ResetMassData();

            float massHighDensity = body.Mass;

            Body body2 = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body2.CreateCircle(0.5f, 1.0f);
            body2.ResetMassData();

            Assert.True(massHighDensity > body2.Mass);
        }

        /// <summary>
        /// Tests that linear velocity setter on static body should return early without changing velocity
        /// </summary>
        [Fact]
        public void LinearVelocity_Setter_OnStaticBody_ShouldReturnEarly()
        {
            Body body = new Body();

            body.LinearVelocity = new Vector2F(10.0f, 5.0f);

            Assert.Equal(Vector2F.Zero, body.LinearVelocityInternal);
        }

        /// <summary>
        /// Tests that angular velocity setter on static body should return early without changing velocity
        /// </summary>
        [Fact]
        public void AngularVelocity_Setter_OnStaticBody_ShouldReturnEarly()
        {
            Body body = new Body();

            body.AngularVelocity = 5.0f;

            Assert.Equal(0.0f, body.AngularVelocity);
        }

        /// <summary>
        /// Tests that linear velocity setter with positive dot product should wake the body
        /// </summary>
        [Fact]
        public void LinearVelocity_Setter_WithPositiveValue_ShouldWakeBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.Awake = false;
            body.LinearVelocity = new Vector2F(1.0f, 0.0f);

            Assert.True(body.Awake);
        }

        /// <summary>
        /// Tests that angular velocity setter with positive value should wake the body
        /// </summary>
        [Fact]
        public void AngularVelocity_Setter_WithPositiveValue_ShouldWakeBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.Awake = false;
            body.AngularVelocity = 1.0f;

            Assert.True(body.Awake);
        }

        /// <summary>
        /// Tests that sleeping allowed setter with false should wake the body
        /// </summary>
        [Fact]
        public void SleepingAllowed_Setter_WithFalse_ShouldWakeBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            body.Awake = false;
            body.SleepingAllowed = false;

            Assert.True(body.Awake);
            Assert.False(body.SleepingAllowed);
        }

        /// <summary>
        /// Tests that awake setter with false should reset dynamics and sleep time
        /// </summary>
        [Fact]
        public void Awake_Setter_WithFalse_ShouldResetDynamics()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.ApplyForce(new Vector2F(10.0f, 0.0f));

            body.Awake = false;

            Assert.False(body.Awake);
            Assert.Equal(0.0f, body.SleepTime);
            Assert.Equal(Vector2F.Zero, body.Force);
        }

        /// <summary>
        /// Tests that position getter should return Xf.Position when world is null
        /// </summary>
        [Fact]
        public void Position_Getter_WithoutWorld_ShouldReturnXfPosition()
        {
            Body body = new Body();
            body.Xf.Position = new Vector2F(3.0f, 4.0f);

            Vector2F pos = body.Position;

            Assert.Equal(3.0f, pos.X);
            Assert.Equal(4.0f, pos.Y);
        }

        /// <summary>
        /// Tests that rotation getter should return Sweep.A
        /// </summary>
        [Fact]
        public void Rotation_Getter_ShouldReturnSweepA()
        {
            Body body = new Body();
            body.Sweep.A = 1.5f;

            Assert.Equal(1.5f, body.Rotation);
        }

        /// <summary>
        /// Tests that rotation setter with world null should set Sweep.A directly
        /// </summary>
        [Fact]
        public void Rotation_Setter_WithoutWorld_ShouldSetSweepA()
        {
            Body body = new Body();

            body.Rotation = 2.0f;

            Assert.Equal(2.0f, body.Sweep.A);
        }

        /// <summary>
        /// Tests that fixed rotation getter should return initial value
        /// </summary>
        [Fact]
        public void FixedRotation_Getter_ShouldReturnInitialValue()
        {
            Body body = new Body();

            Assert.False(body.FixedRotation);
        }

        /// <summary>
        /// Tests that mass setter with negative value should clamp to 1.0f
        /// </summary>
        [Fact]
        public void Mass_Setter_WithNegativeValue_ShouldClampToOne()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.Mass = -5.0f;

            Assert.Equal(1.0f, body.Mass);
        }

        /// <summary>
        /// Tests that mass setter on non-dynamic body should return early
        /// </summary>
        [Fact]
        public void Mass_Setter_OnNonDynamicBody_ShouldReturnEarly()
        {
            Body body = new Body();

            body.Mass = 5.0f;

            Assert.Equal(0.0f, body.Mass);
        }

        /// <summary>
        /// Tests that inertia setter on non-dynamic body should return early
        /// </summary>
        [Fact]
        public void Inertia_Setter_OnNonDynamicBody_ShouldReturnEarly()
        {
            Body body = new Body();

            body.Inertia = 10.0f;

            Assert.Equal(0.0f, body.Inertia);
        }

        /// <summary>
        /// Tests that inertia setter with invalid value on dynamic body should not change inertia
        /// </summary>
        [Fact]
        public void Inertia_Setter_WithInvalidValue_ShouldNotChangeInertia()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.ResetMassData();

            float inertiaBefore = body.Inertia;

            body.Inertia = -1.0f;

            Assert.Equal(inertiaBefore, body.Inertia);
        }

        /// <summary>
        /// Tests that clone should copy body properties
        /// </summary>
        [Fact]
        public void Clone_ShouldCopyBodyProperties()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(1.0f, 2.0f), 0.5f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.LinearVelocity = new Vector2F(3.0f, 4.0f);
            body.AngularVelocity = 1.5f;
            body.Tag = "test-tag";
            body.FixedRotation = true;
            body.SleepingAllowed = false;
            body.LinearDamping = 0.5f;
            body.AngularDamping = 0.3f;
            body.IsBullet = true;
            body.IgnoreCcd = true;
            body.IgnoreGravity = true;

            Body clone = body.Clone();

            Assert.Equal(body.Position, clone.Position);
            Assert.Equal(body.Rotation, clone.Rotation);
            Assert.Equal(BodyType.Dynamic, clone.GetBodyType);
            Assert.Equal(body.LinearVelocityInternal, clone.LinearVelocityInternal);
            Assert.Equal(body.AngularVelocity, clone.AngularVelocity);
            Assert.Equal("test-tag", clone.Tag);
            Assert.True(clone.FixedRotation);
            Assert.False(clone.SleepingAllowed);
            Assert.Equal(0.5f, clone.LinearDamping);
            Assert.Equal(0.3f, clone.AngularDamping);
            Assert.True(clone.Awake);
            Assert.True(clone.IsBullet);
            Assert.True(clone.IgnoreCcd);
            Assert.True(clone.IgnoreGravity);
        }

        /// <summary>
        /// Tests that get transform should return the body transform
        /// </summary>
        [Fact]
        public void GetTransform_ShouldReturnBodyTransform()
        {
            Body body = new Body();
            body.Xf.Position = new Vector2F(5.0f, -3.0f);
            body.Xf.Rotation.Phase = 1.0f;

            ControllerTransform transform = body.GetTransform();

            Assert.Equal(5.0f, transform.Position.X);
            Assert.Equal(-3.0f, transform.Position.Y);
        }

        /// <summary>
        /// Tests that get transform out should set the output parameter
        /// </summary>
        [Fact]
        public void GetTransformOut_ShouldSetOutputParameter()
        {
            Body body = new Body();
            body.Xf.Position = new Vector2F(1.0f, 2.0f);
            body.Xf.Rotation.Phase = 0.5f;

            body.GetTransform(out ControllerTransform transform);

            Assert.Equal(1.0f, transform.Position.X);
            Assert.Equal(2.0f, transform.Position.Y);
        }

        /// <summary>
        /// Tests that set restitution should apply to all fixtures
        /// </summary>
        [Fact]
        public void SetRestitution_ShouldApplyToAllFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.CreateRectangle(0.5f, 0.5f, 1.0f, Vector2F.Zero);

            body.SetRestitution(0.8f);

            foreach (Fixture fixture in body.FixtureList)
            {
                Assert.Equal(0.8f, fixture.GetRestitution);
            }
        }

        /// <summary>
        /// Tests that set friction should apply to all fixtures
        /// </summary>
        [Fact]
        public void SetFriction_ShouldApplyToAllFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.SetFriction(0.6f);

            foreach (Fixture fixture in body.FixtureList)
            {
                Assert.Equal(0.6f, fixture.GetFriction);
            }
        }

        /// <summary>
        /// Tests that set collision categories should apply to all fixtures
        /// </summary>
        [Fact]
        public void SetCollisionCategories_ShouldApplyToAllFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.SetCollisionCategories(Categories.Cat1);

            foreach (Fixture fixture in body.FixtureList)
            {
                Assert.Equal(Categories.Cat1, fixture.GetCollisionCategories);
            }
        }

        /// <summary>
        /// Tests that set collides with should apply to all fixtures
        /// </summary>
        [Fact]
        public void SetCollidesWith_ShouldApplyToAllFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.SetCollidesWith(Categories.Cat2);

            foreach (Fixture fixture in body.FixtureList)
            {
                Assert.Equal(Categories.Cat2, fixture.GetCollidesWith);
            }
        }

        /// <summary>
        /// Tests that set collision group should apply to all fixtures
        /// </summary>
        [Fact]
        public void SetCollisionGroup_ShouldApplyToAllFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.SetCollisionGroup(5);

            foreach (Fixture fixture in body.FixtureList)
            {
                Assert.Equal(5, fixture.GetCollisionGroup);
            }
        }

        /// <summary>
        /// Tests that should collide should return false when both bodies are static
        /// </summary>
        [Fact]
        public void ShouldCollide_BothStatic_ShouldReturnFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body1 = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Static);
            Body body2 = world.CreateBody(new Vector2F(1.0f, 0.0f), 0.0f, BodyType.Static);

            Assert.False(body1.ShouldCollide(body2));
        }

        /// <summary>
        /// Tests that should collide should return true when both bodies are dynamic
        /// </summary>
        [Fact]
        public void ShouldCollide_BothDynamic_ShouldReturnTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body1 = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body body2 = world.CreateBody(new Vector2F(1.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Assert.True(body1.ShouldCollide(body2));
        }

        /// <summary>
        /// Tests that world vector conversion should apply rotation only
        /// </summary>
        [Fact]
        public void GetWorldVector_ShouldApplyRotationOnly()
        {
            Body body = new Body();
            body.Xf.Rotation.Phase = (float) Math.PI / 2.0f;

            Vector2F local = new Vector2F(1.0f, 0.0f);
            Vector2F world = body.GetWorldVector(local);

            Assert.True(Math.Abs(world.X - 0.0f) < 0.0001f);
            Assert.True(Math.Abs(world.Y - 1.0f) < 0.0001f);
        }

        /// <summary>
        /// Tests that local vector conversion should reverse rotation
        /// </summary>
        [Fact]
        public void GetLocalVector_ShouldReverseRotation()
        {
            Body body = new Body();
            body.Xf.Rotation.Phase = (float) Math.PI / 2.0f;

            Vector2F world = new Vector2F(0.0f, 1.0f);
            Vector2F local = body.GetLocalVector(world);

            Assert.True(Math.Abs(local.X - 1.0f) < 0.0001f);
            Assert.True(Math.Abs(local.Y - 0.0f) < 0.0001f);
        }

        /// <summary>
        /// Tests that get linear velocity from world point should include rotational component
        /// </summary>
        [Fact]
        public void GetLinearVelocityFromWorldPoint_ShouldIncludeRotationalComponent()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.LinearVelocityInternal = Vector2F.Zero;
            body.AngularVelocity = 1.0f;

            Vector2F velocity = body.GetLinearVelocityFromWorldPoint(new Vector2F(1.0f, 0.0f));

            Assert.True(Math.Abs(velocity.X - 0.0f) < 0.0001f);
            Assert.True(Math.Abs(velocity.Y - 1.0f) < 0.0001f);
        }

        /// <summary>
        /// Tests that apply linear impulse with point should affect angular velocity
        /// </summary>
        [Fact]
        public void ApplyLinearImpulse_WithPoint_ShouldAffectAngularVelocity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.ResetMassData();

            body.ApplyLinearImpulse(new Vector2F(10.0f, 0.0f), new Vector2F(0.5f, 0.5f));

            Assert.NotEqual(0.0f, body.AngularVelocity);
        }

        /// <summary>
        /// Tests that apply linear impulse on static body should return early
        /// </summary>
        [Fact]
        public void ApplyLinearImpulse_OnStaticBody_ShouldReturnEarly()
        {
            Body body = new Body();

            body.ApplyLinearImpulse(new Vector2F(10.0f, 0.0f));

            Assert.Equal(Vector2F.Zero, body.LinearVelocityInternal);
        }

        /// <summary>
        /// Tests that apply angular impulse on static body should return early
        /// </summary>
        [Fact]
        public void ApplyAngularImpulse_OnStaticBody_ShouldReturnEarly()
        {
            Body body = new Body();

            body.ApplyAngularImpulse(10.0f);

            Assert.Equal(0.0f, body.AngularVelocity);
        }

        /// <summary>
        /// Tests that apply torque on static body should return early
        /// </summary>
        [Fact]
        public void ApplyTorque_OnStaticBody_ShouldReturnEarly()
        {
            Body body = new Body();

            body.ApplyTorque(10.0f);

            Assert.Equal(0.0f, body.Torque);
        }

        /// <summary>
        /// Tests that revolutions should calculate correctly
        /// </summary>
        [Fact]
        public void GetRevolutions_ShouldCalculateCorrectly()
        {
            Body body = new Body();
            body.Sweep.A = (float) (2 * Math.PI);

            Assert.Equal(1.0f, body.GetRevolutions);
        }

        /// <summary>
        /// Tests that world center should return sweep C
        /// </summary>
        [Fact]
        public void WorldCenter_ShouldReturnSweepC()
        {
            Body body = new Body();
            body.Sweep.C = new Vector2F(7.0f, -3.0f);

            Vector2F center = body.WorldCenter;

            Assert.Equal(7.0f, center.X);
            Assert.Equal(-3.0f, center.Y);
        }

        /// <summary>
        /// Tests that get world point should multiply by transform
        /// </summary>
        [Fact]
        public void GetWorldPoint_ShouldMultiplyByTransform()
        {
            Body body = new Body();
            body.Xf.Position = new Vector2F(1.0f, 2.0f);
            body.Xf.Rotation.Phase = 0.0f;

            Vector2F world = body.GetWorldPoint(new Vector2F(3.0f, 4.0f));

            Assert.Equal(4.0f, world.X);
            Assert.Equal(6.0f, world.Y);
        }

        /// <summary>
        /// Tests that get local point should divide by transform
        /// </summary>
        [Fact]
        public void GetLocalPoint_ShouldDivideByTransform()
        {
            Body body = new Body();
            body.Xf.Position = new Vector2F(1.0f, 2.0f);
            body.Xf.Rotation.Phase = 0.0f;

            Vector2F local = body.GetLocalPoint(new Vector2F(4.0f, 6.0f));

            Assert.Equal(3.0f, local.X);
            Assert.Equal(4.0f, local.Y);
        }

        /// <summary>
        /// Tests that body type setter on dynamic body should clear velocities and wake
        /// </summary>
        [Fact]
        public void SetBodyType_ToStatic_OnDynamicBody_ShouldClearVelocitiesAndWake()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.LinearVelocity = new Vector2F(3.0f, 2.0f);
            body.AngularVelocity = 2.0f;

            body.GetBodyType = BodyType.Static;

            Assert.Equal(BodyType.Static, body.GetBodyType);
            Assert.Equal(Vector2F.Zero, body.LinearVelocityInternal);
            // Note: AngularVelocity setter on static body returns early, so it retains its value
            Assert.Equal(2.0f, body.AngularVelocity);
            Assert.True(body.Awake);
            Assert.Equal(Vector2F.Zero, body.Force);
            Assert.Equal(0.0f, body.Torque);
        }

        /// <summary>
        /// Tests that enabled setter should create proxies when enabling with world
        /// </summary>
        [Fact]
        public void Enabled_Setter_WithWorld_ShouldCreateProxies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.Enabled = false;
            Assert.False(body.Enabled);

            body.Enabled = true;
            Assert.True(body.Enabled);
        }

        /// <summary>
        /// Tests that enabled setter with same value should return early
        /// </summary>
        [Fact]
        public void Enabled_Setter_WithSameValue_ShouldReturnEarly()
        {
            Body body = new Body();
            bool enabledBefore = body.Enabled;

            body.Enabled = enabledBefore;

            Assert.True(body.Enabled);
        }

        /// <summary>
        /// Tests that fixed rotation setter should reset angular velocity and mass
        /// </summary>
        [Fact]
        public void FixedRotation_Setter_ShouldResetAngularVelocityAndMass()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.AngularVelocity = 5.0f;

            body.FixedRotation = true;

            Assert.True(body.FixedRotation);
            Assert.Equal(0.0f, body.AngularVelocity);
        }

        /// <summary>
        /// Tests that fixed rotation setter with same value should return early
        /// </summary>
        [Fact]
        public void FixedRotation_Setter_WithSameValue_ShouldReturnEarly()
        {
            Body body = new Body();

            body.FixedRotation = false;
            body.FixedRotation = false;

            Assert.False(body.FixedRotation);
        }

        /// <summary>
        /// Tests that add fixture should throw on null fixture
        /// </summary>
        [Fact]
        public void Add_ShouldThrowOnNullFixture()
        {
            Body body = new Body();

            Assert.Throws<ArgumentNullException>(() => body.Add(null));
        }

        /// <summary>
        /// Tests that remove should throw on fixture not belonging to this body
        /// </summary>
        [Fact]
        public void Remove_ShouldThrowOnFixtureNotBelongingToBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body1 = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body body2 = world.CreateBody(new Vector2F(1.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body1.CreateCircle(0.5f, 1.0f);

            Assert.Throws<ArgumentException>(() => body2.Remove(fixture));
        }

        /// <summary>
        /// Tests that linear velocity ref setter with positive value should wake body
        /// </summary>
        [Fact]
        public void LinearVelocity_RefSetter_WithPositiveValue_ShouldWakeBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.Awake = false;
            Vector2F vel = new Vector2F(1.0f, 0.0f);
            body.LinearVelocity = vel;

            Assert.True(body.Awake);
        }

        /// <summary>
        /// Tests that angular velocity ref setter with positive value should wake body
        /// </summary>
        [Fact]
        public void AngularVelocity_RefSetter_WithPositiveValue_ShouldWakeBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.Awake = false;
            body.AngularVelocity = 1.0f;

            Assert.True(body.Awake);
        }

        /// <summary>
        /// Tests that apply force with ref parameters should add to force and torque
        /// </summary>
        [Fact]
        public void ApplyForce_Ref_ShouldAddToForceAndTorque()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(1.0f, 1.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.ResetMassData();

            Vector2F force = new Vector2F(10.0f, 0.0f);
            Vector2F point = new Vector2F(2.0f, 1.0f);

            body.ApplyForce(ref force, ref point);

            Assert.Equal(10.0f, body.Force.X);
            Assert.Equal(0.0f, body.Force.Y);
        }

        /// <summary>
        /// Tests that apply force on static body should return early
        /// </summary>
        [Fact]
        public void ApplyForce_OnStaticBody_ShouldReturnEarly()
        {
            Body body = new Body();

            body.ApplyForce(new Vector2F(10.0f, 0.0f));

            Assert.Equal(Vector2F.Zero, body.Force);
            Assert.Equal(0.0f, body.Torque);
        }

        /// <summary>
        /// Tests that reset mass data should handle zero total mass
        /// </summary>
        [Fact]
        public void ResetMassData_WithZeroTotalMass_ShouldForcePositiveMass()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            body.ResetMassData();

            Assert.Equal(1.0f, body.Mass);
            Assert.True(body.InvMass > 0.0f);
        }

        /// <summary>
        /// Tests that reset mass data for kinematic body should set position
        /// </summary>
        [Fact]
        public void ResetMassData_ForKinematicBody_ShouldSetPosition()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Kinematic);

            body.ResetMassData();

            Assert.Equal(BodyType.Kinematic, body.GetBodyType);
        }

        /// <summary>
        /// Tests that reset mass data for static body should set position
        /// </summary>
        [Fact]
        public void ResetMassData_ForStaticBody_ShouldSetPosition()
        {
            Body body = new Body();

            body.ResetMassData();

            Assert.Equal(BodyType.Static, body.GetBodyType);
        }
    }
}

