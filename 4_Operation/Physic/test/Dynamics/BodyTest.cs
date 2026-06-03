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
    }
}

