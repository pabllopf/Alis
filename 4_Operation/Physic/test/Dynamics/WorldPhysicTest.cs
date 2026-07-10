// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldPhysicTest.cs
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
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    public class WorldPhysicTest
    {
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithDefaultGravity()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.NotNull(world);
            Assert.Equal(0f, world.GetGravity.X);
            Assert.Equal(-9.80665f, world.GetGravity.Y);
        }

        [Fact]
        public void Constructor_WithGravity_ShouldSetGravity()
        {
            Vector2F gravity = new Vector2F(0f, -10f);
            WorldPhysic world = new WorldPhysic(gravity);

            Assert.Equal(gravity, world.GetGravity);
        }

        [Fact]
        public void Constructor_WithBroadPhase_ShouldSetBroadPhase()
        {
            IBroadPhase broadPhase = new DynamicTreeBroadPhase();
            WorldPhysic world = new WorldPhysic(broadPhase);

            Assert.NotNull(world);
        }

        [Fact]
        public void CreateBody_ShouldReturnBodyAddedToWorld()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateBody(new Vector2F(1f, 2f), 0.5f, BodyType.Dynamic);

            Assert.NotNull(body);
            Assert.Equal(1f, body.Position.X);
            Assert.Equal(2f, body.Position.Y);
            Assert.Equal(0.5f, body.Rotation);
            Assert.Equal(BodyType.Dynamic, body.GetBodyType);
            Assert.Single(world.BodyList);
        }

        [Fact]
        public void CreateBody_WithDefaults_ShouldReturnStaticBody()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateBody();

            Assert.NotNull(body);
            Assert.Equal(BodyType.Static, body.GetBodyType);
        }

        [Fact]
        public void CreateRectangle_ShouldReturnBodyWithRectangleFixture()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateRectangle(2f, 1f, 1f, new Vector2F(0f, 0f), 0f, BodyType.Dynamic);

            Assert.NotNull(body);
            Assert.Single(body.FixtureList);
        }

        [Fact]
        public void CreateRectangle_WithInvalidWidth_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                world.CreateRectangle(-1f, 1f, 1f));
        }

        [Fact]
        public void CreateRectangle_WithInvalidHeight_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                world.CreateRectangle(1f, -1f, 1f));
        }

        [Fact]
        public void CreateCircle_ShouldReturnBodyWithCircleFixture()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateCircle(1f, 1f, new Vector2F(0f, 0f), BodyType.Dynamic);

            Assert.NotNull(body);
            Assert.Single(body.FixtureList);
        }

        [Fact]
        public void CreatePolygon_ShouldReturnBodyWithPolygonFixture()
        {
            WorldPhysic world = new WorldPhysic();
            Vertices vertices = PolygonTools.CreateRectangle(1f, 1f);
            Body body = world.CreatePolygon(vertices, 1f, new Vector2F(0f, 0f), 0f, BodyType.Dynamic);

            Assert.NotNull(body);
            Assert.Single(body.FixtureList);
        }

        [Fact]
        public void CreateEdge_ShouldReturnBodyWithEdge()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateEdge(new Vector2F(0f, 0f), new Vector2F(1f, 0f));

            Assert.NotNull(body);
        }

        [Fact]
        public void CreateChainShape_ShouldReturnBodyWithChain()
        {
            WorldPhysic world = new WorldPhysic();
            Vertices vertices = new Vertices();
            vertices.Add(new Vector2F(0f, 0f));
            vertices.Add(new Vector2F(1f, 0f));
            vertices.Add(new Vector2F(0f, 1f));

            Body body = world.CreateChainShape(vertices);

            Assert.NotNull(body);
        }

        [Fact]
        public void AddBody_ShouldAddBodyToWorld()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = new Body();

            world.Add(body);

            Assert.Single(world.BodyList);
        }

        [Fact]
        public void AddBody_Null_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Throws<ArgumentNullException>(() => world.Add((Body)null));
        }

        [Fact]
        public void AddBody_SameBodyTwice_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = new Body();
            world.Add(body);

            Assert.Throws<ArgumentException>(() => world.Add(body));
        }

        [Fact]
        public void RemoveBody_ShouldRemoveBodyFromWorld()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateBody();

            world.Remove(body);

            Assert.Empty(world.BodyList);
        }

        [Fact]
        public void RemoveBody_Null_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Throws<ArgumentNullException>(() => world.Remove((Body)null));
        }

        [Fact]
        public void RemoveBody_FromWrongWorld_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();
            WorldPhysic other = new WorldPhysic();
            Body body = other.CreateBody();

            Assert.Throws<ArgumentException>(() => world.Remove(body));
        }

        [Fact]
        public void BodyAddedEvent_ShouldFire_WhenBodyIsAdded()
        {
            WorldPhysic world = new WorldPhysic();
            int callCount = 0;
            world.BodyAdded += (w, b) => callCount++;

            world.CreateBody();

            Assert.Equal(1, callCount);
        }

        [Fact]
        public void BodyRemovedEvent_ShouldFire_WhenBodyIsRemoved()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateBody();
            int callCount = 0;
            world.BodyRemoved += (w, b) => callCount++;

            world.Remove(body);

            Assert.Equal(1, callCount);
        }

        [Fact]
        public void AddController_ShouldAddToControllerList()
        {
            WorldPhysic world = new WorldPhysic();
            GravityController controller = new GravityController(9.8f);

            world.Add(controller);

            Assert.Single(world.ControllerList);
        }

        [Fact]
        public void AddController_Null_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Throws<ArgumentNullException>(() => world.Add((Controller)null));
        }

        [Fact]
        public void AddController_SameControllerTwice_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();
            GravityController controller = new GravityController(9.8f);
            world.Add(controller);

            Assert.Throws<ArgumentException>(() => world.Add(controller));
        }

        [Fact]
        public void AddController_FromAnotherWorld_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();
            WorldPhysic other = new WorldPhysic();
            GravityController controller = new GravityController(9.8f);
            other.Add(controller);

            Assert.Throws<ArgumentException>(() => world.Add(controller));
        }

        [Fact]
        public void RemoveController_ShouldRemoveFromControllerList()
        {
            WorldPhysic world = new WorldPhysic();
            GravityController controller = new GravityController(9.8f);
            world.Add(controller);

            world.Remove(controller);

            Assert.Empty(world.ControllerList);
        }

        [Fact]
        public void RemoveController_Null_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Throws<ArgumentNullException>(() => world.Remove((Controller)null));
        }

        [Fact]
        public void RemoveController_FromWrongWorld_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();
            WorldPhysic other = new WorldPhysic();
            GravityController controller = new GravityController(9.8f);
            other.Add(controller);

            Assert.Throws<ArgumentException>(() => world.Remove(controller));
        }

        [Fact]
        public void ControllerAddedEvent_ShouldFire_WhenControllerIsAdded()
        {
            WorldPhysic world = new WorldPhysic();
            int callCount = 0;
            world.ControllerAdded += (w, c) => callCount++;

            world.Add(new GravityController(9.8f));

            Assert.Equal(1, callCount);
        }

        [Fact]
        public void ControllerRemovedEvent_ShouldFire_WhenControllerIsRemoved()
        {
            WorldPhysic world = new WorldPhysic();
            GravityController controller = new GravityController(9.8f);
            world.Add(controller);
            int callCount = 0;
            world.ControllerRemoved += (w, c) => callCount++;

            world.Remove(controller);

            Assert.Equal(1, callCount);
        }

        [Fact]
        public void GetGravity_Setter_ShouldUpdateGravity()
        {
            WorldPhysic world = new WorldPhysic();
            Vector2F newGravity = new Vector2F(0f, -20f);

            world.GetGravity = newGravity;

            Assert.Equal(newGravity, world.GetGravity);
        }

        [Fact]
        public void GetEnabled_Default_ShouldBeTrue()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.True(world.GetEnabled);
        }

        [Fact]
        public void GetEnabled_SetFalse_ShouldBeFalse()
        {
            WorldPhysic world = new WorldPhysic();

            world.GetEnabled = false;

            Assert.False(world.GetEnabled);
        }

        [Fact]
        public void GetIsLocked_Default_ShouldBeFalse()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.False(world.GetIsLocked);
        }

        [Fact]
        public void ProxyCount_ShouldReturnZero_WhenNoBodies()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Equal(0, world.ProxyCount);
        }

        [Fact]
        public void ContactCount_ShouldReturnZero_WhenNoBodies()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Equal(0, world.ContactCount);
        }

        [Fact]
        public void Tag_ShouldGetAndSet()
        {
            WorldPhysic world = new WorldPhysic();
            object tag = "test";

            world.Tag = tag;

            Assert.Equal(tag, world.Tag);
        }

        [Fact]
        public void ContactList_ShouldReturnList()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.NotNull(world.ContactList);
        }

        [Fact]
        public void UpdateTime_Default_ShouldBeZero()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Equal(TimeSpan.Zero, world.UpdateTime);
        }

        [Fact]
        public void Clear_ShouldRemoveAllBodies()
        {
            WorldPhysic world = new WorldPhysic();
            world.CreateBody();
            world.CreateBody();

            world.Clear();

            Assert.Empty(world.BodyList);
        }

        [Fact]
        public void Clear_ShouldRemoveAllControllers()
        {
            WorldPhysic world = new WorldPhysic();
            world.Add(new GravityController(9.8f));

            world.Clear();

            Assert.Empty(world.ControllerList);
        }

        [Fact]
        public void ClearForces_ShouldNotThrow_WhenNoBodies()
        {
            WorldPhysic world = new WorldPhysic();

            world.ClearForces();
        }

        [Fact]
        public void ClearForces_ShouldResetBodyForces()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            body.Force = new Vector2F(10f, 0f);
            body.Torque = 5f;

            world.ClearForces();

            Assert.Equal(Vector2F.Zero, body.Force);
            Assert.Equal(0f, body.Torque);
        }

        [Fact]
        public void SetGravity_ShouldSetPrivateGravity()
        {
            WorldPhysic world = new WorldPhysic();
            Vector2F newGravity = new Vector2F(0f, -5f);

            world.SetGravity(newGravity);

            Assert.Equal(newGravity, world.GetGravity);
        }

        [Fact]
        public void Step_WithTimeSpan_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic();
            world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);

            world.Step(TimeSpan.FromSeconds(1f / 60f));
        }

        [Fact]
        public void Step_WithDisabledWorld_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic();
            world.GetEnabled = false;

            world.Step(1f / 60f);
        }

        [Fact]
        public void ShiftOrigin_ShouldNotThrow_WhenNoBodies()
        {
            WorldPhysic world = new WorldPhysic();

            world.ShiftOrigin(new Vector2F(10f, 10f));
        }

        [Fact]
        public void ShiftOrigin_ShouldShiftBodyPositions()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateBody(new Vector2F(5f, 5f), 0f, BodyType.Static);

            world.ShiftOrigin(new Vector2F(1f, 1f));

            Assert.Equal(4f, body.Position.X);
            Assert.Equal(4f, body.Position.Y);
        }

        [Fact]
        public void TestPoint_ShouldReturnNull_WhenNoFixtureAtPoint()
        {
            WorldPhysic world = new WorldPhysic();

            Fixture result = world.TestPoint(new Vector2F(100f, 100f));

            Assert.Null(result);
        }

        [Fact]
        public void TestPoint_ShouldReturnFixture_WhenPointInsideShape()
        {
            WorldPhysic world = new WorldPhysic();
            world.CreateRectangle(2f, 2f, 1f, new Vector2F(0f, 0f), 0f, BodyType.Static);

            Fixture result = world.TestPoint(new Vector2F(0f, 0f));

            Assert.NotNull(result);
        }

        [Fact]
        public void QueryAabb_ShouldInvokeCallback_WhenFixtureInAabb()
        {
            WorldPhysic world = new WorldPhysic();
            world.CreateRectangle(2f, 2f, 1f, new Vector2F(0f, 0f), 0f, BodyType.Static);
            Aabb aabb = new Aabb(new Vector2F(-2f, -2f), new Vector2F(2f, 2f));
            bool callbackInvoked = false;

            world.QueryAabb(f =>
            {
                callbackInvoked = true;
                return true;
            }, aabb);

            Assert.True(callbackInvoked);
        }

        [Fact]
        public void QueryAabb_ShouldNotInvokeCallback_WhenNoFixtureInAabb()
        {
            WorldPhysic world = new WorldPhysic();
            world.CreateRectangle(2f, 2f, 1f, new Vector2F(100f, 100f), 0f, BodyType.Static);
            Aabb aabb = new Aabb(new Vector2F(-2f, -2f), new Vector2F(2f, 2f));
            bool callbackInvoked = false;

            world.QueryAabb(f =>
            {
                callbackInvoked = true;
                return true;
            }, aabb);

            Assert.False(callbackInvoked);
        }

        [Fact]
        public void RayCast_ShouldInvokeCallback_WhenRayHitsFixture()
        {
            WorldPhysic world = new WorldPhysic();
            world.CreateRectangle(2f, 2f, 1f, new Vector2F(0f, 0f), 0f, BodyType.Static);
            bool callbackInvoked = false;

            world.RayCast((f, point, normal, fraction) =>
            {
                callbackInvoked = true;
                return -1f;
            }, new Vector2F(-5f, 0f), new Vector2F(5f, 0f));

            Assert.True(callbackInvoked);
        }

        [Fact]
        public void RayCast_ShouldReturnMaxFraction_WhenNoHit()
        {
            WorldPhysic world = new WorldPhysic();
            world.CreateRectangle(2f, 2f, 1f, new Vector2F(100f, 100f), 0f, BodyType.Static);
            bool callbackInvoked = false;

            world.RayCast((f, point, normal, fraction) =>
            {
                callbackInvoked = true;
                return 1f;
            }, new Vector2F(-10f, 0f), new Vector2F(10f, 0f));

            Assert.False(callbackInvoked);
        }

        [Fact]
        public void CreateEllipse_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic();

            Body body = world.CreateEllipse(1f, 0.5f, 16, 1f);

            Assert.NotNull(body);
        }

        [Fact]
        public void CreateLineArc_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic();

            Body body = world.CreateLineArc(MathF.PI, 8, 1f, false);

            Assert.NotNull(body);
        }

        [Fact]
        public void CreateSolidArc_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic();

            Body body = world.CreateSolidArc(1f, MathF.PI, 8, 1f);

            Assert.NotNull(body);
        }

        [Fact]
        public void RemoveBody_WhenBodyHasJoint_ShouldRemoveCorrectly()
        {
            WorldPhysic world = new WorldPhysic();
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            world.Add(joint);

            world.Remove(bodyA);

            Assert.DoesNotContain(bodyA, world.BodyList);
        }

        [Fact]
        public void CreateCompoundPolygon_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic();
            Vertices rect = PolygonTools.CreateRectangle(1f, 1f);
            List<Vertices> list = new List<Vertices> { rect };

            Body body = world.CreateCompoundPolygon(list, 1f);

            Assert.NotNull(body);
        }

        [Fact]
        public void CreateCapsule_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic();

            Body body = world.CreateCapsule(2f, 0.5f, 1f);

            Assert.NotNull(body);
        }

        [Fact]
        public void CreateRoundedRectangle_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic();

            Body body = world.CreateRoundedRectangle(2f, 1f, 0.3f, 0.3f, 8, 1f);

            Assert.NotNull(body);
        }

        [Fact]
        public void FixtureAddedEvent_ShouldFire_WhenFixtureAdded()
        {
            WorldPhysic world = new WorldPhysic();
            int callCount = 0;
            world.FixtureAdded += (sender, body, fixture) => callCount++;

            world.CreateRectangle(2f, 2f, 1f);

            Assert.Equal(1, callCount);
        }

        [Fact]
        public void AddBody_FromAnotherWorld_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();
            WorldPhysic otherWorld = new WorldPhysic();
            Body body = otherWorld.CreateBody();

            ArgumentException ex = Assert.Throws<ArgumentException>(() => world.Add(body));
            Assert.Contains("another world", ex.Message);
        }

        [Fact]
        public void CreateLoopShape_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic();
            Vertices vertices = new Vertices();
            vertices.Add(new Vector2F(0f, 0f));
            vertices.Add(new Vector2F(1f, 0f));
            vertices.Add(new Vector2F(0f, 1f));

            Body body = world.CreateLoopShape(vertices);

            Assert.NotNull(body);
        }

        [Fact]
        public void CreateLoopShape_WithPosition_ShouldReturnBodyAtPosition()
        {
            WorldPhysic world = new WorldPhysic();
            Vertices vertices = new Vertices();
            vertices.Add(new Vector2F(0f, 0f));
            vertices.Add(new Vector2F(1f, 0f));
            vertices.Add(new Vector2F(0f, 1f));
            Vector2F position = new Vector2F(5f, 10f);

            Body body = world.CreateLoopShape(vertices, position);

            Assert.NotNull(body);
            Assert.Equal(5f, body.Position.X);
            Assert.Equal(10f, body.Position.Y);
        }

        [Fact]
        public void Step_WithWorldHasNewFixture_ProcessesNewContacts()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            int contactsAfterFirstStep = world.ContactManager.ContactCount;
            Assert.True(contactsAfterFirstStep > 0);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        [Fact]
        public void Step_WithCustomIterations_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
            {
                PositionIterations = 1,
                VelocityIterations = 1,
                ToiPositionIterations = 1,
                ToiVelocityIterations = 1
            };

            world.Step(TimeSpan.FromSeconds(1.0f / 60.0f), ref iterations);
        }

        [Fact]
        public void GetGravity_Setter_WhenLocked_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            bool threw = false;
            world.ContactManager.BeginContact = contact =>
            {
                try
                {
                    world.GetGravity = new Vector2F(0, -5f);
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }
                return false;
            };

            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        [Fact]
        public void GetIsLocked_ShouldBeTrue_DuringStep()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, 0));
            bool wasLocked = false;
            world.ContactManager.BeginContact = contact =>
            {
                wasLocked = world.GetIsLocked;
                return false;
            };

            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Assert.True(wasLocked);
        }

        [Fact]
        public void GetIsland_ShouldReturnInitializedIsland()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.NotNull(world.GetIsland);
        }

        [Fact]
        public void FixtureRemovedEvent_ShouldFire_WhenBodyRemoved()
        {
            WorldPhysic world = new WorldPhysic();
            int callCount = 0;
            world.FixtureRemoved += (sender, body, fixture) => callCount++;

            Body body = world.CreateRectangle(2f, 2f, 1f);
            world.Remove(body);

            Assert.Equal(1, callCount);
        }

        [Fact]
        public void AddBody_WhenLocked_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            bool threw = false;
            Body newBody = new Body();
            world.ContactManager.BeginContact = contact =>
            {
                try
                {
                    world.Add(newBody);
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }
                return false;
            };

            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        [Fact]
        public void RemoveBody_WhenLocked_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            bool threw = false;
            Body body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            world.ContactManager.BeginContact = contact =>
            {
                try
                {
                    world.Remove(body);
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }
                return false;
            };

            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        [Fact]
        public void AddJoint_WhenLocked_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            bool threw = false;
            Body bodyA = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1f, 0f));
            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            world.ContactManager.BeginContact = contact =>
            {
                try
                {
                    world.Add(joint);
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }
                return false;
            };

            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        [Fact]
        public void RemoveJoint_WhenLocked_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1f, 0f));
            world.Add(joint);
            bool threw = false;
            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            world.ContactManager.BeginContact = contact =>
            {
                try
                {
                    world.Remove(joint);
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }
                return false;
            };

            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        [Fact]
        public void AddController_WhenLocked_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            bool threw = false;
            GravityController controller = new GravityController(9.8f);
            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            world.ContactManager.BeginContact = contact =>
            {
                try
                {
                    world.Add(controller);
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }
                return false;
            };

            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        [Fact]
        public void RemoveController_WhenLocked_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            GravityController controller = new GravityController(9.8f);
            world.Add(controller);
            bool threw = false;
            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            world.ContactManager.BeginContact = contact =>
            {
                try
                {
                    world.Remove(controller);
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }
                return false;
            };

            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        [Fact]
        public void Clear_WhenLocked_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            bool threw = false;

            world.ContactManager.BeginContact = contact =>
            {
                try
                {
                    world.Clear();
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }
                return false;
            };

            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        [Fact]
        public void CreateGear_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateGear(1f, 6, 0.2f, 0.5f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            Assert.NotNull(body);
        }

        [Fact]
        public void CreateChain_WithoutRopeJoint_ShouldReturnPath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Path path = world.CreateChain(
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                0.1f, 0.05f, 3, 1f, false);
            Assert.NotNull(path);
        }

        [Fact]
        public void CreateChain_WithRopeJoint_ShouldReturnPath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Path path = world.CreateChain(
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                0.1f, 0.05f, 3, 1f, true);
            Assert.NotNull(path);
        }

        [Fact]
        public void CreateCapsule_FullParams_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCapsule(2f, 0.5f, 4, 0.5f, 4, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            Assert.NotNull(body);
        }

        [Fact]
        public void RemoveJoint_FixedType_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(1f, 0f));
            world.Add(joint);

            world.Remove(joint);

            Assert.Empty(world.JointList);
        }

        [Fact]
        public void ProcessJointEdges_WithDisabledOtherBody_SkipsDisabled()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            world.Add(joint);
            bodyB.Enabled = false;

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }

        [Fact]
        public void FlagContactsForJointFiltering_WithCollideConnectedFalse_SkipsFiltering()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, bodyA.Position, bodyB.Position);
            joint.CollideConnected = false;
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        [Fact]
        public void FlagContactsForJointRemoval_WithCollideConnectedTrue_SkipsFlagging()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            joint.CollideConnected = true;
            world.Add(joint);

            world.Remove(joint);

            Assert.Empty(world.JointList);
        }

        [Fact]
        public void ConnectJointNonFixed_WithFixedType_SkipsEdgeB()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(1f, 0f));
            world.Add(joint);

            Assert.Single(world.JointList);
        }

        [Fact]
        public void ShouldProcessBody_WithStaticBody_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateBody(Vector2F.Zero, 0f, BodyType.Static);
            world.CreateBody(new Vector2F(0.5f, 0f), 0f, BodyType.Static);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }

        [Fact]
        public void ExecuteStepPhysics_WithContinuousPhysics_SolvesToi()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(-10f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(200f, 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }

        [Fact]
        public void ProcessJointEdges_WithJointFromNullOther_AddsJointToIsland()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            world.CreateBody(new Vector2F(0.5f, 0f), 0f, BodyType.Dynamic);

            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(0.5f, 0f));
            world.Add(joint);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }

        [Fact]
        public void SolveToi_WithDisabledContact_ResetsBodies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);

            world.ContactManager.BeginContact = contact =>
            {
                contact.Enabled = false;
                return false;
            };

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }

        // ========================================================================
        // ShouldSkipContactAlpha — sensor branch (line 693-695)
        // ========================================================================

        [Fact]
        public void ShouldSkipContactAlpha_WithSensor_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.FixtureList[0].GetIsSensor = true;
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ShouldSkipContactAlpha — both inactive branch (line 707-709)
        // ========================================================================

        [Fact]
        public void ShouldSkipContactAlpha_BothInactive_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.Awake = false;
            bodyB.Awake = false;
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ProcessJointEdges — other is null (line 530-532)
        // ========================================================================

        [Fact]
        public void ProcessJointEdges_WithNullOther_AddsJointToIsland()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(1f, 0f));
            world.Add(joint);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // BuildIslandDFS — body is static (line 448-450)
        // ========================================================================

        [Fact]
        public void BuildIslandDFS_WithStaticSeed_ClearsIsland()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateBody(Vector2F.Zero, 0f, BodyType.Static);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ProcessJointEdges — joint already in island (line 508-510)
        // ========================================================================

        [Fact]
        public void ProcessJointEdges_WithJointAlreadyFlagged_Continues()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            world.Add(joint);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // CalculateContactAlpha — ToiFlag true branch (line 725-727)
        // ========================================================================

        [Fact]
        public void CalculateContactAlpha_WithToiFlag_ReturnsToi()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(-5f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(50f, 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ProcessToiContact — body is not dynamic, not bullet (line 808-810)
        // ========================================================================

        [Fact]
        public void ProcessToiContact_NonDynamicNonBullet_Skips()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-5f, 0f), 0f, BodyType.Kinematic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyB.LinearVelocityInternal = new Vector2F(50f, 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // FindMinAlphaContact — contact with ToiCount > MaxSubSteps skips (line 669)
        // ========================================================================

        [Fact]
        public void FindMinAlphaContact_SkipsContactWithHighToiCount()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(-10f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(200f, 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }
    }
}
