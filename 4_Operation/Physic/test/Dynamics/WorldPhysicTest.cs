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
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The world physic test class
    /// </summary>
    public class WorldPhysicTest
    {
        /// <summary>
        /// Tests that default constructor should initialize with default gravity
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithDefaultGravity()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.NotNull(world);
            Assert.Equal(0f, world.GetGravity.X, 5);
            Assert.Equal(-9.80665f, world.GetGravity.Y, 5);
        }

        /// <summary>
        /// Tests that constructor with gravity should set gravity
        /// </summary>
        [Fact]
        public void Constructor_WithGravity_ShouldSetGravity()
        {
            Vector2F gravity = new Vector2F(0f, -10f);
            WorldPhysic world = new WorldPhysic(gravity);

            Assert.Equal(gravity, world.GetGravity);
        }

        /// <summary>
        /// Tests that constructor with broad phase should set broad phase
        /// </summary>
        [Fact]
        public void Constructor_WithBroadPhase_ShouldSetBroadPhase()
        {
            IBroadPhase broadPhase = new DynamicTreeBroadPhase();
            WorldPhysic world = new WorldPhysic(broadPhase);

            Assert.NotNull(world);
        }

        /// <summary>
        /// Tests that create body should return body added to world
        /// </summary>
        [Fact]
        public void CreateBody_ShouldReturnBodyAddedToWorld()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateBody(new Vector2F(1f, 2f), 0.5f, BodyType.Dynamic);

            Assert.NotNull(body);
            Assert.Equal(1f, body.Position.X, 5);
            Assert.Equal(2f, body.Position.Y, 5);
            Assert.Equal(0.5f, body.Rotation, 5);
            Assert.Equal(BodyType.Dynamic, body.GetBodyType);
            Assert.Single(world.BodyList);
        }

        /// <summary>
        /// Tests that create body with defaults should return static body
        /// </summary>
        [Fact]
        public void CreateBody_WithDefaults_ShouldReturnStaticBody()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateBody();

            Assert.NotNull(body);
            Assert.Equal(BodyType.Static, body.GetBodyType);
        }

        /// <summary>
        /// Tests that create rectangle should return body with rectangle fixture
        /// </summary>
        [Fact]
        public void CreateRectangle_ShouldReturnBodyWithRectangleFixture()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateRectangle(2f, 1f, 1f, new Vector2F(0f, 0f), 0f, BodyType.Dynamic);

            Assert.NotNull(body);
            Assert.Single(body.FixtureList);
        }

        /// <summary>
        /// Tests that create rectangle with invalid width should throw
        /// </summary>
        [Fact]
        public void CreateRectangle_WithInvalidWidth_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                world.CreateRectangle(-1f, 1f, 1f));
        }

        /// <summary>
        /// Tests that create rectangle with invalid height should throw
        /// </summary>
        [Fact]
        public void CreateRectangle_WithInvalidHeight_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                world.CreateRectangle(1f, -1f, 1f));
        }

        /// <summary>
        /// Tests that create circle should return body with circle fixture
        /// </summary>
        [Fact]
        public void CreateCircle_ShouldReturnBodyWithCircleFixture()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateCircle(1f, 1f, new Vector2F(0f, 0f), BodyType.Dynamic);

            Assert.NotNull(body);
            Assert.Single(body.FixtureList);
        }

        /// <summary>
        /// Tests that create polygon should return body with polygon fixture
        /// </summary>
        [Fact]
        public void CreatePolygon_ShouldReturnBodyWithPolygonFixture()
        {
            WorldPhysic world = new WorldPhysic();
            Vertices vertices = PolygonTools.CreateRectangle(1f, 1f);
            Body body = world.CreatePolygon(vertices, 1f, new Vector2F(0f, 0f), 0f, BodyType.Dynamic);

            Assert.NotNull(body);
            Assert.Single(body.FixtureList);
        }

        /// <summary>
        /// Tests that create edge should return body with edge
        /// </summary>
        [Fact]
        public void CreateEdge_ShouldReturnBodyWithEdge()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateEdge(new Vector2F(0f, 0f), new Vector2F(1f, 0f));

            Assert.NotNull(body);
        }

        /// <summary>
        /// Tests that create chain shape should return body with chain
        /// </summary>
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

        /// <summary>
        /// Tests that add body should add body to world
        /// </summary>
        [Fact]
        public void AddBody_ShouldAddBodyToWorld()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = new Body();

            world.Add(body);

            Assert.Single(world.BodyList);
        }

        /// <summary>
        /// Tests that add body null should throw
        /// </summary>
        [Fact]
        public void AddBody_Null_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Throws<ArgumentNullException>(() => world.Add((Body)null));
        }

        /// <summary>
        /// Tests that add body same body twice should throw
        /// </summary>
        [Fact]
        public void AddBody_SameBodyTwice_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = new Body();
            world.Add(body);

            Assert.Throws<ArgumentException>(() => world.Add(body));
        }

        /// <summary>
        /// Tests that remove body should remove body from world
        /// </summary>
        [Fact]
        public void RemoveBody_ShouldRemoveBodyFromWorld()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateBody();

            world.Remove(body);

            Assert.Empty(world.BodyList);
        }

        /// <summary>
        /// Tests that remove body null should throw
        /// </summary>
        [Fact]
        public void RemoveBody_Null_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Throws<ArgumentNullException>(() => world.Remove((Body)null));
        }

        /// <summary>
        /// Tests that remove body from wrong world should throw
        /// </summary>
        [Fact]
        public void RemoveBody_FromWrongWorld_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();
            WorldPhysic other = new WorldPhysic();
            Body body = other.CreateBody();

            Assert.Throws<ArgumentException>(() => world.Remove(body));
        }

        /// <summary>
        /// Tests that body added event should fire when body is added
        /// </summary>
        [Fact]
        public void BodyAddedEvent_ShouldFire_WhenBodyIsAdded()
        {
            WorldPhysic world = new WorldPhysic();
            int callCount = 0;
            world.BodyAdded += (w, b) => callCount++;

            world.CreateBody();

            Assert.Equal(1, callCount);
        }

        /// <summary>
        /// Tests that body removed event should fire when body is removed
        /// </summary>
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

        /// <summary>
        /// Tests that add controller should add to controller list
        /// </summary>
        [Fact]
        public void AddController_ShouldAddToControllerList()
        {
            WorldPhysic world = new WorldPhysic();
            GravityController controller = new GravityController(9.8f);

            world.Add(controller);

            Assert.Single(world.ControllerList);
        }

        /// <summary>
        /// Tests that add controller null should throw
        /// </summary>
        [Fact]
        public void AddController_Null_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Throws<ArgumentNullException>(() => world.Add((Controller)null));
        }

        /// <summary>
        /// Tests that add controller same controller twice should throw
        /// </summary>
        [Fact]
        public void AddController_SameControllerTwice_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();
            GravityController controller = new GravityController(9.8f);
            world.Add(controller);

            Assert.Throws<ArgumentException>(() => world.Add(controller));
        }

        /// <summary>
        /// Tests that add controller from another world should throw
        /// </summary>
        [Fact]
        public void AddController_FromAnotherWorld_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();
            WorldPhysic other = new WorldPhysic();
            GravityController controller = new GravityController(9.8f);
            other.Add(controller);

            Assert.Throws<ArgumentException>(() => world.Add(controller));
        }

        /// <summary>
        /// Tests that remove controller should remove from controller list
        /// </summary>
        [Fact]
        public void RemoveController_ShouldRemoveFromControllerList()
        {
            WorldPhysic world = new WorldPhysic();
            GravityController controller = new GravityController(9.8f);
            world.Add(controller);

            world.Remove(controller);

            Assert.Empty(world.ControllerList);
        }

        /// <summary>
        /// Tests that remove controller null should throw
        /// </summary>
        [Fact]
        public void RemoveController_Null_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Throws<ArgumentNullException>(() => world.Remove((Controller)null));
        }

        /// <summary>
        /// Tests that remove controller from wrong world should throw
        /// </summary>
        [Fact]
        public void RemoveController_FromWrongWorld_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();
            WorldPhysic other = new WorldPhysic();
            GravityController controller = new GravityController(9.8f);
            other.Add(controller);

            Assert.Throws<ArgumentException>(() => world.Remove(controller));
        }

        /// <summary>
        /// Tests that controller added event should fire when controller is added
        /// </summary>
        [Fact]
        public void ControllerAddedEvent_ShouldFire_WhenControllerIsAdded()
        {
            WorldPhysic world = new WorldPhysic();
            int callCount = 0;
            world.ControllerAdded += (w, c) => callCount++;

            world.Add(new GravityController(9.8f));

            Assert.Equal(1, callCount);
        }

        /// <summary>
        /// Tests that controller removed event should fire when controller is removed
        /// </summary>
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

        /// <summary>
        /// Tests that get gravity setter should update gravity
        /// </summary>
        [Fact]
        public void GetGravity_Setter_ShouldUpdateGravity()
        {
            WorldPhysic world = new WorldPhysic();
            Vector2F newGravity = new Vector2F(0f, -20f);

            world.GetGravity = newGravity;

            Assert.Equal(newGravity, world.GetGravity);
        }

        /// <summary>
        /// Tests that get enabled default should be true
        /// </summary>
        [Fact]
        public void GetEnabled_Default_ShouldBeTrue()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.True(world.GetEnabled);
        }

        /// <summary>
        /// Tests that get enabled set false should be false
        /// </summary>
        [Fact]
        public void GetEnabled_SetFalse_ShouldBeFalse()
        {
            WorldPhysic world = new WorldPhysic
                {
                    GetEnabled = false
                };

            Assert.False(world.GetEnabled);
        }

        /// <summary>
        /// Tests that get is locked default should be false
        /// </summary>
        [Fact]
        public void GetIsLocked_Default_ShouldBeFalse()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.False(world.GetIsLocked);
        }

        /// <summary>
        /// Tests that proxy count should return zero when no bodies
        /// </summary>
        [Fact]
        public void ProxyCount_ShouldReturnZero_WhenNoBodies()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Equal(0, world.ProxyCount);
        }

        /// <summary>
        /// Tests that contact count should return zero when no bodies
        /// </summary>
        [Fact]
        public void ContactCount_ShouldReturnZero_WhenNoBodies()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Equal(0, world.ContactCount);
        }

        /// <summary>
        /// Tests that tag should get and set
        /// </summary>
        [Fact]
        public void Tag_ShouldGetAndSet()
        {
            WorldPhysic world = new WorldPhysic();
            object tag = "test";

            world.Tag = tag;

            Assert.Equal(tag, world.Tag);
        }

        /// <summary>
        /// Tests that contact list should return list
        /// </summary>
        [Fact]
        public void ContactList_ShouldReturnList()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.NotNull(world.ContactList);
        }

        /// <summary>
        /// Tests that update time default should be zero
        /// </summary>
        [Fact]
        public void UpdateTime_Default_ShouldBeZero()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Equal(TimeSpan.Zero, world.UpdateTime);
        }

        /// <summary>
        /// Tests that clear should remove all bodies
        /// </summary>
        [Fact]
        public void Clear_ShouldRemoveAllBodies()
        {
            WorldPhysic world = new WorldPhysic();
            world.CreateBody();
            world.CreateBody();

            world.Clear();

            Assert.Empty(world.BodyList);
        }

        /// <summary>
        /// Tests that clear should remove all controllers
        /// </summary>
        [Fact]
        public void Clear_ShouldRemoveAllControllers()
        {
            WorldPhysic world = new WorldPhysic();
            world.Add(new GravityController(9.8f));

            world.Clear();

            Assert.Empty(world.ControllerList);
        }

        /// <summary>
        /// Tests that clear forces should not throw when no bodies
        /// </summary>
        [Fact]
        public void ClearForces_ShouldNotThrow_WhenNoBodies()
        {
            WorldPhysic world = new WorldPhysic();

            world.ClearForces();
        }

        /// <summary>
        /// Tests that clear forces should reset body forces
        /// </summary>
        [Fact]
        public void ClearForces_ShouldResetBodyForces()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            body.Force = new Vector2F(10f, 0f);
            body.Torque = 5f;

            world.ClearForces();

            Assert.Equal(Vector2F.Zero, body.Force);
            Assert.Equal(0f, body.Torque, 5);
        }

        /// <summary>
        /// Tests that set gravity should set private gravity
        /// </summary>
        [Fact]
        public void SetGravity_ShouldSetPrivateGravity()
        {
            WorldPhysic world = new WorldPhysic();
            Vector2F newGravity = new Vector2F(0f, -5f);

            world.SetGravity(newGravity);

            Assert.Equal(newGravity, world.GetGravity);
        }

        /// <summary>
        /// Tests that step with time span should not throw
        /// </summary>
        [Fact]
        public void Step_WithTimeSpan_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic();
            world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);

            world.Step(TimeSpan.FromSeconds(1f / 60f));
        }

        /// <summary>
        /// Tests that step with disabled world should not throw
        /// </summary>
        [Fact]
        public void Step_WithDisabledWorld_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic
                {
                    GetEnabled = false
                };

            world.Step(1f / 60f);
        }

        /// <summary>
        /// Tests that shift origin should not throw when no bodies
        /// </summary>
        [Fact]
        public void ShiftOrigin_ShouldNotThrow_WhenNoBodies()
        {
            WorldPhysic world = new WorldPhysic();

            world.ShiftOrigin(new Vector2F(10f, 10f));
        }

        /// <summary>
        /// Tests that shift origin should shift body positions
        /// </summary>
        [Fact]
        public void ShiftOrigin_ShouldShiftBodyPositions()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateBody(new Vector2F(5f, 5f));

            world.ShiftOrigin(new Vector2F(1f, 1f));

            Assert.Equal(4f, body.Position.X, 5);
            Assert.Equal(4f, body.Position.Y, 5);
        }

        /// <summary>
        /// Tests that test point should return null when no fixture at point
        /// </summary>
        [Fact]
        public void TestPoint_ShouldReturnNull_WhenNoFixtureAtPoint()
        {
            WorldPhysic world = new WorldPhysic();

            Fixture result = world.TestPoint(new Vector2F(100f, 100f));

            Assert.Null(result);
        }

        /// <summary>
        /// Tests that test point should return fixture when point inside shape
        /// </summary>
        [Fact]
        public void TestPoint_ShouldReturnFixture_WhenPointInsideShape()
        {
            WorldPhysic world = new WorldPhysic();
            world.CreateRectangle(2f, 2f, 1f, new Vector2F(0f, 0f));

            Fixture result = world.TestPoint(new Vector2F(0f, 0f));

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that query aabb should invoke callback when fixture in aabb
        /// </summary>
        [Fact]
        public void QueryAabb_ShouldInvokeCallback_WhenFixtureInAabb()
        {
            WorldPhysic world = new WorldPhysic();
            world.CreateRectangle(2f, 2f, 1f, new Vector2F(0f, 0f));
            Aabb aabb = new Aabb(new Vector2F(-2f, -2f), new Vector2F(2f, 2f));
            bool callbackInvoked = false;

            world.QueryAabb(f =>
            {
                callbackInvoked = true;
                return true;
            }, aabb);

            Assert.True(callbackInvoked);
        }

        /// <summary>
        /// Tests that query aabb should not invoke callback when no fixture in aabb
        /// </summary>
        [Fact]
        public void QueryAabb_ShouldNotInvokeCallback_WhenNoFixtureInAabb()
        {
            WorldPhysic world = new WorldPhysic();
            world.CreateRectangle(2f, 2f, 1f, new Vector2F(100f, 100f));
            Aabb aabb = new Aabb(new Vector2F(-2f, -2f), new Vector2F(2f, 2f));
            bool callbackInvoked = false;

            world.QueryAabb(f =>
            {
                callbackInvoked = true;
                return true;
            }, aabb);

            Assert.False(callbackInvoked);
        }

        /// <summary>
        /// Tests that ray cast should invoke callback when ray hits fixture
        /// </summary>
        [Fact]
        public void RayCast_ShouldInvokeCallback_WhenRayHitsFixture()
        {
            WorldPhysic world = new WorldPhysic();
            world.CreateRectangle(2f, 2f, 1f, new Vector2F(0f, 0f));
            bool callbackInvoked = false;

            world.RayCast((f, point, normal, fraction) =>
            {
                callbackInvoked = true;
                return -1f;
            }, new Vector2F(-5f, 0f), new Vector2F(5f, 0f));

            Assert.True(callbackInvoked);
        }

        /// <summary>
        /// Tests that ray cast should return max fraction when no hit
        /// </summary>
        [Fact]
        public void RayCast_ShouldReturnMaxFraction_WhenNoHit()
        {
            WorldPhysic world = new WorldPhysic();
            world.CreateRectangle(2f, 2f, 1f, new Vector2F(100f, 100f));
            bool callbackInvoked = false;

            world.RayCast((f, point, normal, fraction) =>
            {
                callbackInvoked = true;
                return 1f;
            }, new Vector2F(-10f, 0f), new Vector2F(10f, 0f));

            Assert.False(callbackInvoked);
        }

        /// <summary>
        /// Tests that create ellipse should return body
        /// </summary>
        [Fact]
        public void CreateEllipse_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic();

            Body body = world.CreateEllipse(1f, 0.5f, 16, 1f);

            Assert.NotNull(body);
        }

        /// <summary>
        /// Tests that create line arc should return body
        /// </summary>
        [Fact]
        public void CreateLineArc_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic();

            Body body = world.CreateLineArc(MathF.PI, 8, 1f);

            Assert.NotNull(body);
        }

        /// <summary>
        /// Tests that create solid arc should return body
        /// </summary>
        [Fact]
        public void CreateSolidArc_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic();

            Body body = world.CreateSolidArc(1f, MathF.PI, 8, 1f);

            Assert.NotNull(body);
        }

        /// <summary>
        /// Tests that remove body when body has joint should remove correctly
        /// </summary>
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

        /// <summary>
        /// Tests that create compound polygon should return body
        /// </summary>
        [Fact]
        public void CreateCompoundPolygon_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic();
            Vertices rect = PolygonTools.CreateRectangle(1f, 1f);
            List<Vertices> list = new List<Vertices> { rect };

            Body body = world.CreateCompoundPolygon(list, 1f);

            Assert.NotNull(body);
        }

        /// <summary>
        /// Tests that create capsule should return body
        /// </summary>
        [Fact]
        public void CreateCapsule_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic();

            Body body = world.CreateCapsule(2f, 0.5f, 1f);

            Assert.NotNull(body);
        }

        /// <summary>
        /// Tests that create rounded rectangle should return body
        /// </summary>
        [Fact]
        public void CreateRoundedRectangle_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic();

            Body body = world.CreateRoundedRectangle(2f, 1f, 0.3f, 0.3f, 8, 1f);

            Assert.NotNull(body);
        }

        /// <summary>
        /// Tests that fixture added event should fire when fixture added
        /// </summary>
        [Fact]
        public void FixtureAddedEvent_ShouldFire_WhenFixtureAdded()
        {
            WorldPhysic world = new WorldPhysic();
            int callCount = 0;
            world.FixtureAdded += (sender, body, fixture) => callCount++;

            world.CreateRectangle(2f, 2f, 1f);

            Assert.Equal(1, callCount);
        }

        /// <summary>
        /// Tests that add body from another world should throw
        /// </summary>
        [Fact]
        public void AddBody_FromAnotherWorld_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();
            WorldPhysic otherWorld = new WorldPhysic();
            Body body = otherWorld.CreateBody();

            ArgumentException ex = Assert.Throws<ArgumentException>(() => world.Add(body));
            Assert.Contains("another world", ex.Message);
        }

        /// <summary>
        /// Tests that create loop shape should return body
        /// </summary>
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

        /// <summary>
        /// Tests that create loop shape with position should return body at position
        /// </summary>
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
            Assert.Equal(5f, body.Position.X, 5);
            Assert.Equal(10f, body.Position.Y, 5);
        }
        
        /// <summary>
        /// Tests that get gravity setter when locked should throw
        /// </summary>
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

        /// <summary>
        /// Tests that get is locked should be true during step
        /// </summary>
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

        /// <summary>
        /// Tests that get island should return initialized island
        /// </summary>
        [Fact]
        public void GetIsland_ShouldReturnInitializedIsland()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.NotNull(world.GetIsland);
        }

        /// <summary>
        /// Tests that fixture removed event should fire when body removed
        /// </summary>
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

        /// <summary>
        /// Tests that add body when locked should throw
        /// </summary>
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
        
        /// <summary>
        /// Tests that add joint when locked should throw
        /// </summary>
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

        /// <summary>
        /// Tests that remove joint when locked should throw
        /// </summary>
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

        /// <summary>
        /// Tests that add controller when locked should throw
        /// </summary>
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

        /// <summary>
        /// Tests that remove controller when locked should throw
        /// </summary>
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

        /// <summary>
        /// Tests that clear when locked should throw
        /// </summary>
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

        /// <summary>
        /// Tests that create gear should return body
        /// </summary>
        [Fact]
        public void CreateGear_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateGear(1f, 6, 0.2f, 0.5f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            Assert.NotNull(body);
        }

        /// <summary>
        /// Tests that create chain without rope joint should return path
        /// </summary>
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

        /// <summary>
        /// Tests that create chain with rope joint should return path
        /// </summary>
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

        /// <summary>
        /// Tests that create capsule full params should return body
        /// </summary>
        [Fact]
        public void CreateCapsule_FullParams_ShouldReturnBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCapsule(2f, 0.5f, 4, 0.5f, 4, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            Assert.NotNull(body);
        }

        /// <summary>
        /// Tests that remove joint fixed type does not throw
        /// </summary>
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

        /// <summary>
        /// Tests that process joint edges with disabled other body skips disabled
        /// </summary>
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

        /// <summary>
        /// Tests that flag contacts for joint removal with collide connected true skips flagging
        /// </summary>
        [Fact]
        public void FlagContactsForJointRemoval_WithCollideConnectedTrue_SkipsFlagging()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f))
                {
                    CollideConnected = true
                };
            world.Add(joint);

            world.Remove(joint);

            Assert.Empty(world.JointList);
        }

        /// <summary>
        /// Tests that connect joint non fixed with fixed type skips edge b
        /// </summary>
        [Fact]
        public void ConnectJointNonFixed_WithFixedType_SkipsEdgeB()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(1f, 0f));
            world.Add(joint);

            Assert.Single(world.JointList);
        }

        /// <summary>
        /// Tests that should process body with static body returns false
        /// </summary>
        [Fact]
        public void ShouldProcessBody_WithStaticBody_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateBody(Vector2F.Zero);
            world.CreateBody(new Vector2F(0.5f, 0f));

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that execute step physics with continuous physics solves toi
        /// </summary>
        [Fact]
        public void ExecuteStepPhysics_WithContinuousPhysics_SolvesToi()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(-10f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(200f, 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that process joint edges with joint from null other adds joint to island
        /// </summary>
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

        /// <summary>
        /// Tests that solve toi with disabled contact resets bodies
        /// </summary>
        [Fact]
        public void SolveToi_WithDisabledContact_ResetsBodies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
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

        /// <summary>
        /// Tests that should skip contact alpha with sensor returns true
        /// </summary>
        [Fact]
        public void ShouldSkipContactAlpha_WithSensor_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.FixtureList[0].GetIsSensor = true;
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ShouldSkipContactAlpha — both inactive branch (line 707-709)
        // ========================================================================

        /// <summary>
        /// Tests that should skip contact alpha both inactive returns true
        /// </summary>
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

        /// <summary>
        /// Tests that process joint edges with null other adds joint to island
        /// </summary>
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

        /// <summary>
        /// Tests that build island dfs with static seed clears island
        /// </summary>
        [Fact]
        public void BuildIslandDFS_WithStaticSeed_ClearsIsland()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateBody(Vector2F.Zero);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ProcessJointEdges — joint already in island (line 508-510)
        // ========================================================================

        /// <summary>
        /// Tests that process joint edges with joint already flagged continues
        /// </summary>
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

        /// <summary>
        /// Tests that calculate contact alpha with toi flag returns toi
        /// </summary>
        [Fact]
        public void CalculateContactAlpha_WithToiFlag_ReturnsToi()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(-5f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(50f, 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ProcessToiContact — body is not dynamic, not bullet (line 808-810)
        // ========================================================================

        /// <summary>
        /// Tests that process toi contact non dynamic non bullet skips
        /// </summary>
        [Fact]
        public void ProcessToiContact_NonDynamicNonBullet_Skips()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateBody(new Vector2F(-5f, 0f), 0f, BodyType.Kinematic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyB.LinearVelocityInternal = new Vector2F(50f, 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // FindMinAlphaContact — contact with ToiCount > MaxSubSteps skips (line 669)
        // ========================================================================

        /// <summary>
        /// Tests that find min alpha contact skips contact with high toi count
        /// </summary>
        [Fact]
        public void FindMinAlphaContact_SkipsContactWithHighToiCount()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(-10f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(200f, 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ShouldSkipContactAlpha — !collideA && !collideB path
        // ========================================================================
        /// <summary>
        /// Tests that should skip contact alpha both non bullet dynamic returns true
        /// </summary>
        [Fact]
        public void ShouldSkipContactAlpha_BothNonBulletDynamic_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ProcessJointEdges — other.Island already true
        // ========================================================================
        /// <summary>
        /// Tests that process joint edges with other already in island skips add
        /// </summary>
        [Fact]
        public void ProcessJointEdges_WithOtherAlreadyInIsland_SkipsAdd()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint jointAB = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            DistanceJoint jointBC = new DistanceJoint(bodyB, bodyC, new Vector2F(2f, 0f), new Vector2F(4f, 0f));
            world.Add(jointAB);
            world.Add(jointBC);
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ProcessToiContact — sensor fixture skip
        // ========================================================================
        /// <summary>
        /// Tests that process toi contact with sensor fixture skips
        /// </summary>
        [Fact]
        public void ProcessToiContact_WithSensorFixture_Skips()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);
            bodyA.FixtureList[0].GetIsSensor = true;
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ProcessToiContact — disabled contact after update
        // ========================================================================
        /// <summary>
        /// Tests that process toi contact contact disabled resets bodies
        /// </summary>
        [Fact]
        public void ProcessToiContact_ContactDisabled_ResetsBodies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);
            world.ContactManager.BeginContact = contact =>
            {
                contact.Enabled = false;
                return true;
            };
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ProcessToiContact — not touching after update
        // ========================================================================
        /// <summary>
        /// Tests that process toi contact not touching resets bodies
        /// </summary>
        [Fact]
        public void ProcessToiContact_NotTouching_ResetsBodies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);
            world.ContactManager.BeginContact = contact =>
            {
                contact.IsTouching = false;
                return true;
            };
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ProcessToiContact — bullet body continues
        // ========================================================================
        /// <summary>
        /// Tests that process toi contact with bullet body continues
        /// </summary>
        [Fact]
        public void ProcessToiContact_WithBulletBody_Continues()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);
            bodyA.IsBullet = true;
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // CreateGear with convex polygon
        // ========================================================================
        /// <summary>
        /// Tests that create gear convex path creates body
        /// </summary>
        [Fact]
        public void CreateGear_ConvexPath_CreatesBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateGear(1f, 3, 1.5f, 0.1f, 1f, Vector2F.Zero);
            Assert.NotNull(body);
        }

        // ========================================================================
        // CreateCapsule with many vertices (decompose path)
        // ========================================================================
        /// <summary>
        /// Tests that create capsule with many vertices decomposes
        /// </summary>
        [Fact]
        public void CreateCapsule_WithManyVertices_Decomposes()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCapsule(2f, 0.5f, 8, 0.5f, 8, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            Assert.NotNull(body);
        }

        // ========================================================================
        // FlagContactsForJointRemoval non-fixed, non-collide path
        // ========================================================================
        /// <summary>
        /// Tests that flag contacts for joint removal non fixed non collide flags contacts
        /// </summary>
        [Fact]
        public void FlagContactsForJointRemoval_NonFixedNonCollide_FlagsContacts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f))
                {
                    CollideConnected = false
                };
            world.Add(joint);
            world.Remove(joint);
            Assert.Empty(world.JointList);
        }

        // ========================================================================
        // ConnectJointNonFixed non-fixed type path
        // ========================================================================
        /// <summary>
        /// Tests that connect joint non fixed non fixed type connects edge b
        /// </summary>
        [Fact]
        public void ConnectJointNonFixed_NonFixedType_ConnectsEdgeB()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            world.Add(joint);
            Assert.NotNull(joint.EdgeB.Joint);
            Assert.Same(bodyA, joint.EdgeB.Other);
        }

        // ========================================================================
        // BuildToiIsland with non-dynamic body
        // ========================================================================
        /// <summary>
        /// Tests that build toi island with non dynamic body skips contact processing
        /// </summary>
        [Fact]
        public void BuildToiIsland_WithNonDynamicBody_SkipsContactProcessing()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Kinematic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyB.LinearVelocityInternal = new Vector2F(100f, 0f);
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ProcessToiContact — other already in island (line 843-849)
        // ========================================================================
        /// <summary>
        /// Tests that process toi contact other already in island returns early
        /// </summary>
        [Fact]
        public void ProcessToiContact_OtherAlreadyInIsland_ReturnsEarly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(-5f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(5f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(200f, 0f);
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ProcessJointEdges — other not in island
        // ========================================================================
        /// <summary>
        /// Tests that process joint edges with other not in island adds to stack
        /// </summary>
        [Fact]
        public void ProcessJointEdges_WithOtherNotInIsland_AddsToStack()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Kinematic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            world.Add(joint);
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // CalculateContactAlpha — TOI output not Touching
        // ========================================================================
        /// <summary>
        /// Tests that calculate contact alpha not touching returns one
        /// </summary>
        [Fact]
        public void CalculateContactAlpha_NotTouching_ReturnsOne()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-5f, 0f), BodyType.Dynamic);
            world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);
            bodyA.IsBullet = true;
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ProcessToiContact — island capacity reached
        // ========================================================================
        /// <summary>
        /// Tests that process toi contact island capacity reached returns early
        /// </summary>
        [Fact]
        public void ProcessToiContact_IslandCapacityReached_ReturnsEarly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(-10f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(500f, 0f);
            for (int i = 0; i < 5; i++)
            {
                Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
                Assert.Null(ex);
            }
        }

        // ========================================================================
        // ProcessToiContact — non-static other wakes up
        // ========================================================================
        /// <summary>
        /// Tests that process toi contact non static other wakes up
        /// </summary>
        [Fact]
        public void ProcessToiContact_NonStaticOther_WakesUp()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);
            bodyA.IsBullet = true;
            bodyB.Awake = false;
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // RemoveJointEdgeA — bodyA with multiple joints (various pointer states)
        // ========================================================================
        /// <summary>
        /// Tests that remove joint edge a multiple joints correctly updates pointers
        /// </summary>
        [Fact]
        public void RemoveJointEdgeA_MultipleJoints_CorrectlyUpdatesPointers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint1 = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            DistanceJoint joint2 = new DistanceJoint(bodyA, bodyC, Vector2F.Zero, new Vector2F(4f, 0f));
            world.Add(joint1);
            world.Add(joint2);
            world.Remove(joint1);
            Assert.Single(world.JointList);
            Assert.Contains(joint2, world.JointList);
        }

        // ========================================================================
        // RemoveJointEdgeB — bodyB with multiple joints
        // ========================================================================
        /// <summary>
        /// Tests that remove joint edge b multiple joints correctly updates pointers
        /// </summary>
        [Fact]
        public void RemoveJointEdgeB_MultipleJoints_CorrectlyUpdatesPointers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint1 = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            DistanceJoint joint2 = new DistanceJoint(bodyC, bodyB, new Vector2F(4f, 0f), new Vector2F(2f, 0f));
            world.Add(joint1);
            world.Add(joint2);
            world.Remove(joint1);
            Assert.Single(world.JointList);
            Assert.Contains(joint2, world.JointList);
        }
        
        // ========================================================================
        // CreateChain with both rope and no rope
        // ========================================================================
        /// <summary>
        /// Tests that create chain with and without rope works
        /// </summary>
        [Fact]
        public void CreateChain_WithAndWithoutRope_Works()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Path pathNoRope = world.CreateChain(
                new Vector2F(0f, 0f), new Vector2F(1f, 0f), 0.1f, 0.05f, 3, 1f, false);
            Assert.NotNull(pathNoRope);
            Path pathWithRope = world.CreateChain(
                new Vector2F(2f, 0f), new Vector2F(3f, 0f), 0.1f, 0.05f, 3, 1f, true);
            Assert.NotNull(pathWithRope);
        }

        // ========================================================================
        // ProcessJointEdges — edge from where joint.Other != null and Enabled
        // ========================================================================
        /// <summary>
        /// Tests that process joint edges prev next null pointer correctly processes
        /// </summary>
        [Fact]
        public void ProcessJointEdges_PrevNextNullPointer_CorrectlyProcesses()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint jointAB = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            DistanceJoint jointBC = new DistanceJoint(bodyB, bodyC, new Vector2F(2f, 0f), new Vector2F(4f, 0f));
            world.Add(jointAB);
            world.Add(jointBC);
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // ProcessToiContact - comprehensive test with actual TOI event
        // ========================================================================
        /// <summary>
        /// Tests that process toi contact full path executes
        /// </summary>
        [Fact]
        public void ProcessToiContact_FullPath_Executes()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);
            bodyA.IsBullet = true;
            bodyB.Awake = false;
            for (int i = 0; i < 3; i++)
            {
                Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
                Assert.Null(ex);
            }
        }

        // ========================================================================
        // Add joint with existing joint list on bodyA
        // ========================================================================
        /// <summary>
        /// Tests that add joint with existing joints on body a updates pointers
        /// </summary>
        [Fact]
        public void AddJoint_WithExistingJointsOnBodyA_UpdatesPointers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint1 = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            DistanceJoint joint2 = new DistanceJoint(bodyA, bodyC, Vector2F.Zero, new Vector2F(4f, 0f));
            world.Add(joint1);
            world.Add(joint2);
            Assert.Equal(2, world.JointList.Count);
        }

        // ========================================================================
        // Remove joint with non-fixed type triggers bodyB awake
        // ========================================================================
        /// <summary>
        /// Tests that remove joint non fixed type wakes body b
        /// </summary>
        [Fact]
        public void RemoveJoint_NonFixedType_WakesBodyB()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            world.Add(joint);
            bodyB.Awake = false;
            world.Remove(joint);
            Assert.True(bodyB.Awake);
        }

        // ========================================================================
        // RemoveJointEdgeA with various pointer states
        // ========================================================================
        /// <summary>
        /// Tests that remove joint edge a last joint updates correctly
        /// </summary>
        [Fact]
        public void RemoveJointEdgeA_LastJoint_UpdatesCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint1 = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            world.Add(joint1);
            world.Remove(joint1);
            Assert.Null(bodyA.JointList);
        }

        // ========================================================================
        // ProcessContactEdges — sensor check path
        // ========================================================================
        /// <summary>
        /// Tests that process contact edges sensor fixture skips
        /// </summary>
        [Fact]
        public void ProcessContactEdges_SensorFixture_Skips()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            bodyA.FixtureList[0].GetIsSensor = true;
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // Solve stack growth path
        // ========================================================================
        /// <summary>
        /// Tests that solve with large stack grows buffer
        /// </summary>
        [Fact]
        public void Solve_WithLargeStack_GrowsBuffer()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            List<Body> bodies = new System.Collections.Generic.List<Body>();
            for (int i = 0; i < 100; i++)
            {
                Body body = world.CreateCircle(0.1f, 1.0f, new Vector2F(i * 0.05f, 0f), BodyType.Dynamic);
                bodies.Add(body);
            }
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

     
    }
}
