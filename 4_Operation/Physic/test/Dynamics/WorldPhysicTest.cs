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
        /// Tests that constructor with gravity should set gravity
        /// </summary>
        [Fact]
        public void Constructor_WithGravity_ShouldSetGravity()
        {
            Vector2F gravity = new Vector2F(0.0f, -5.0f);
            WorldPhysic world = new WorldPhysic(gravity);

            Assert.Equal(gravity, world.GetGravity);
        }

        /// <summary>
        /// Tests that create body and remove body should update body list
        /// </summary>
        [Fact]
        public void CreateBody_AndRemoveBody_ShouldUpdateBodyList()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0.0f, -9.81f));
            Body body = world.CreateBody(new Vector2F(1.0f, 2.0f), 0.0f, BodyType.Dynamic);

            Assert.Single(world.BodyList);

            world.Remove(body);

            Assert.Empty(world.BodyList);
        }

        /// <summary>
        /// Tests that step when world disabled should not integrate bodies
        /// </summary>
        [Fact]
        public void Step_WhenWorldDisabled_ShouldNotIntegrateBodies()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0.0f, -9.81f));
            Body body = world.CreateCircle(0.5f, 1.0f, new Vector2F(0.0f, 4.0f), BodyType.Dynamic);
            Vector2F initialPosition = body.Position;
            world.GetEnabled = false;

            world.Step(1.0f / 30.0f);

            Assert.Equal(initialPosition, body.Position);
        }

        /// <summary>
        /// Tests that query aabb should find fixtures inside region
        /// </summary>
        [Fact]
        public void QueryAabb_ShouldFindFixturesInsideRegion()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(0.5f, 0.0f, new Vector2F(0.0f, 0.0f), BodyType.Static);
            world.CreateCircle(0.5f, 0.0f, new Vector2F(5.0f, 0.0f), BodyType.Static);

            Aabb area = new Aabb(new Vector2F(0.0f, 0.0f), 3.0f, 3.0f);
            int hits = 0;
            world.QueryAabb(_ =>
            {
                hits++;
                return true;
            }, ref area);

            Assert.Equal(1, hits);
        }

        /// <summary>
        /// Tests that ray cast should report at least one hit when crossing fixture
        /// </summary>
        [Fact]
        public void RayCast_ShouldReportAtLeastOneHit_WhenCrossingFixture()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(2.0f, 2.0f, 0.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Static);

            int hitCount = 0;
            world.RayCast((fixture, point, normal, fraction) =>
            {
                hitCount++;
                return 1.0f;
            }, new Vector2F(-4.0f, 0.0f), new Vector2F(4.0f, 0.0f));

            Assert.True(hitCount > 0);
        }

        /// <summary>
        /// Tests that test point should return fixture when point is inside shape
        /// </summary>
        [Fact]
        public void TestPoint_ShouldReturnFixture_WhenPointIsInsideShape()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 0.0f, new Vector2F(0.0f, 0.0f), BodyType.Static);

            Fixture fixture = world.TestPoint(new Vector2F(0.0f, 0.0f));

            Assert.NotNull(fixture);
        }

        /// <summary>
        /// Tests that shift origin should translate body positions
        /// </summary>
        [Fact]
        public void ShiftOrigin_ShouldTranslateBodyPositions()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(10.0f, 4.0f), 0.0f, BodyType.Dynamic);

            world.ShiftOrigin(new Vector2F(2.0f, 1.0f));

            Assert.Equal(new Vector2F(8.0f, 3.0f), body.Position);
        }

        /// <summary>
        /// Tests that set gravity should update gravity without lock checks
        /// </summary>
        [Fact]
        public void SetGravity_ShouldUpdateGravityWithoutLockChecks()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0.0f, -9.81f));

            world.SetGravity(new Vector2F(1.0f, -2.0f));

            Assert.Equal(new Vector2F(1.0f, -2.0f), world.GetGravity);
        }

        /// <summary>
        /// Tests that default constructor should initialize with default gravity
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithDefaultGravity()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Equal(new Vector2F(0.0f, -9.80665f), world.GetGravity);
        }

        /// <summary>
        /// Tests that set gravity updates gravity vector
        /// </summary>
        [Fact]
        public void SetGravity_ShouldUpdateGravityProperty()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vector2F newGravity = new Vector2F(0.0f, -9.81f);

            world.SetGravity(newGravity);

            Assert.Equal(newGravity, world.GetGravity);
        }

        /// <summary>
        /// Tests that default constructor should create body list
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldCreateBodyList()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.NotNull(world.BodyList);
            Assert.Empty(world.BodyList);
        }

        /// <summary>
        /// Tests that clear should remove all bodies
        /// </summary>
        [Fact]
        public void Clear_ShouldRemoveAllBodies()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0.0f, -9.81f));
            world.CreateBody(new Vector2F(1.0f, 2.0f), 0.0f, BodyType.Dynamic);

            world.Clear();

            Assert.Empty(world.BodyList);
        }

        /// <summary>
        /// Tests that add null body should throw argument null exception
        /// </summary>
        [Fact]
        public void Add_NullBody_ShouldThrowArgumentNullException()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Throws<ArgumentNullException>(() => world.Add((Body)null));
        }

        /// <summary>
        /// Tests that add same body twice should throw argument exception
        /// </summary>
        [Fact]
        public void Add_SameBodyTwice_ShouldThrowArgumentException()
        {
            WorldPhysic world = new WorldPhysic();
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Assert.Throws<ArgumentException>(() => world.Add(body));
        }

        /// <summary>
        /// Tests that create edge should create body in world
        /// </summary>
        [Fact]
        public void CreateEdge_ShouldCreateBodyInWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vector2F start = new Vector2F(0.0f, 0.0f);
            Vector2F end = new Vector2F(1.0f, 0.0f);

            Body body = world.CreateEdge(start, end);

            Assert.NotNull(body);
            Assert.Contains(body, world.BodyList);
        }

        /// <summary>
        /// Tests that body added event should fire when body is created
        /// </summary>
        [Fact]
        public void BodyAddedEvent_ShouldFire_WhenBodyIsCreated()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            int fireCount = 0;
            world.BodyAdded += (w, b) => fireCount++;

            world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            world.CreateBody(new Vector2F(1.0f, 1.0f), 0.0f, BodyType.Static);

            Assert.Equal(2, fireCount);
        }

        /// <summary>
        /// Tests that body removed event should fire when body is removed
        /// </summary>
        [Fact]
        public void BodyRemovedEvent_ShouldFire_WhenBodyIsRemoved()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            int fireCount = 0;
            world.BodyRemoved += (w, b) => fireCount++;

            world.Remove(body);

            Assert.Equal(1, fireCount);
        }

        /// <summary>
        /// Tests that remove null body should throw argument null exception
        /// </summary>
        [Fact]
        public void Remove_NullBody_ShouldThrowArgumentNullException()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Throws<ArgumentNullException>(() => world.Remove((Body)null));
        }

        /// <summary>
        /// Tests that remove body from wrong world should throw argument exception
        /// </summary>
        [Fact]
        public void Remove_BodyFromWrongWorld_ShouldThrowArgumentException()
        {
            WorldPhysic world = new WorldPhysic();
            WorldPhysic other = new WorldPhysic();
            Body body = other.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Assert.Throws<ArgumentException>(() => world.Remove(body));
        }

        /// <summary>
        /// Tests that create rectangle with zero width should throw
        /// </summary>
        [Fact]
        public void CreateRectangle_WithZeroWidth_ShouldThrow()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Throws<ArgumentOutOfRangeException>(() => world.CreateRectangle(0.0f, 2.0f, 1.0f));
        }

        /// <summary>
        /// Tests that clear forces should reset body forces
        /// </summary>
        [Fact]
        public void ClearForces_ShouldResetBodyForces()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.Force = new Vector2F(10.0f, 0.0f);
            body.Torque = 5.0f;

            world.ClearForces();

            Assert.Equal(Vector2F.Zero, body.Force);
            Assert.Equal(0.0f, body.Torque);
        }

        /// <summary>
        /// Tests that add body from another world should throw
        /// </summary>
        [Fact]
        public void Add_BodyFromAnotherWorld_ShouldThrowArgumentException()
        {
            WorldPhysic world = new WorldPhysic();
            WorldPhysic other = new WorldPhysic();
            Body body = other.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Assert.Throws<ArgumentException>(() => world.Add(body));
        }

        /// <summary>
        /// Tests that add null joint should throw argument null exception
        /// </summary>
        [Fact]
        public void Add_NullJoint_ShouldThrowArgumentNullException()
        {
            WorldPhysic world = new WorldPhysic();

            Assert.Throws<ArgumentNullException>(() => world.Add((Joint)null));
        }

        /// <summary>
        /// Tests that create circle should create body in world
        /// </summary>
        [Fact]
        public void CreateCircle_ShouldCreateBodyInWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);

            Assert.NotNull(body);
            Assert.Single(world.BodyList);
        }

        /// <summary>
        /// Tests that proxy count should return positive after adding body
        /// </summary>
        [Fact]
        public void ProxyCount_ShouldBePositive_AfterAddingBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            int initialProxyCount = world.ProxyCount;

            world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);

            Assert.True(world.ProxyCount > initialProxyCount);
        }

        /// <summary>
        /// Tests that contact count should return zero with no collisions
        /// </summary>
        [Fact]
        public void ContactCount_ShouldReturnZero_WhenNoCollisions()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            int count = world.ContactCount;

            Assert.Equal(0, count);
        }

        /// <summary>
        /// Tests that add controller should add to controller list
        /// </summary>
        [Fact]
        public void AddController_ShouldAddToControllerList()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Controller controller = new GravityController(9.81f);

            world.Add(controller);

            Assert.Single(world.ControllerList);
            Assert.Contains(controller, world.ControllerList);
        }

        /// <summary>
        /// Tests that remove controller should remove from controller list
        /// </summary>
        [Fact]
        public void RemoveController_ShouldRemoveFromControllerList()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Controller controller = new GravityController(9.81f);
            world.Add(controller);

            world.Remove(controller);

            Assert.Empty(world.ControllerList);
        }

        /// <summary>
        /// Tests that add joint should add to joint list
        /// </summary>
        [Fact]
        public void AddJoint_ShouldAddToJointList()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Static);
            Body bodyB = world.CreateBody(new Vector2F(2.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Joint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            world.Add(joint);

            Assert.Single(world.JointList);
            Assert.Contains(joint, world.JointList);
        }

        /// <summary>
        /// Tests that remove joint should remove from joint list
        /// </summary>
        [Fact]
        public void RemoveJoint_ShouldRemoveFromJointList()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Static);
            Body bodyB = world.CreateBody(new Vector2F(2.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Joint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            world.Add(joint);

            world.Remove(joint);

            Assert.Empty(world.JointList);
        }

        /// <summary>
        /// Tests that joint added event should fire when joint is added
        /// </summary>
        [Fact]
        public void JointAddedEvent_ShouldFire_WhenJointIsAdded()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Static);
            Body bodyB = world.CreateBody(new Vector2F(2.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Joint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            int fireCount = 0;
            world.JointAdded += (w, j) => fireCount++;

            world.Add(joint);

            Assert.Equal(1, fireCount);
        }

        /// <summary>
        /// Tests that joint removed event should fire when joint is removed
        /// </summary>
        [Fact]
        public void JointRemovedEvent_ShouldFire_WhenJointIsRemoved()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Static);
            Body bodyB = world.CreateBody(new Vector2F(2.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Joint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            world.Add(joint);
            int fireCount = 0;
            world.JointRemoved += (w, j) => fireCount++;

            world.Remove(joint);

            Assert.Equal(1, fireCount);
        }

        /// <summary>
        /// Tests that fixture added event should fire when fixture is created
        /// </summary>
        [Fact]
        public void FixtureAddedEvent_ShouldFire_WhenFixtureIsCreated()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            int fireCount = 0;
            world.FixtureAdded += (w, b, f) => fireCount++;

            world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);

            Assert.Equal(1, fireCount);
        }

        /// <summary>
        /// Tests that fixture removed event should fire when fixture is removed
        /// </summary>
        [Fact]
        public void FixtureRemovedEvent_ShouldFire_WhenFixtureIsRemoved()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Fixture fixture = body.FixtureList[0];
            int fireCount = 0;
            world.FixtureRemoved += (w, b, f) => fireCount++;

            world.Remove(body);

            Assert.Equal(1, fireCount);
        }

        /// <summary>
        /// Tests that create polygon should create body in world
        /// </summary>
        [Fact]
        public void CreatePolygon_ShouldCreateBodyInWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new Vector2F(-1.0f, -1.0f),
                new Vector2F(1.0f, -1.0f),
                new Vector2F(0.0f, 1.0f)
            };

            Body body = world.CreatePolygon(vertices, 1.0f, Vector2F.Zero);

            Assert.NotNull(body);
            Assert.Single(world.BodyList);
        }

        /// <summary>
        /// Tests that create chain shape should create body in world
        /// </summary>
        [Fact]
        public void CreateChainShape_ShouldCreateBodyInWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new Vector2F(0.0f, 0.0f),
                new Vector2F(1.0f, 0.0f),
                new Vector2F(1.0f, 1.0f)
            };

            Body body = world.CreateChainShape(vertices, Vector2F.Zero);

            Assert.NotNull(body);
            Assert.Single(world.BodyList);
        }

        /// <summary>
        /// Tests that create loop shape should create body in world
        /// </summary>
        [Fact]
        public void CreateLoopShape_ShouldCreateBodyInWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new Vector2F(0.0f, 0.0f),
                new Vector2F(1.0f, 0.0f),
                new Vector2F(0.5f, 1.0f)
            };

            Body body = world.CreateLoopShape(vertices, Vector2F.Zero);

            Assert.NotNull(body);
            Assert.Single(world.BodyList);
        }
    }
}

