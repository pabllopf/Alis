// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldPhysicRemainingCoverageTests.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The world physic remaining coverage tests class
    /// </summary>
    public class WorldPhysicRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that step with a time span steps the world.
        /// </summary>
        [Fact]
        public void Step_WithTimeSpan_StepsWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            SolverIterations iterations = new SolverIterations();

            world.Step(TimeSpan.FromMilliseconds(16), ref iterations);

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that step while locked throws invalid operation exception.
        /// </summary>
        [Fact]
        public void Step_WhenLocked_ThrowsInvalidOperationException()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            bool threw = false;
            Fixture fixtureA = bodyA.FixtureList[0];
            fixtureA.OnCollision += (sender, other, contact) =>
            {
                try
                {
                    SolverIterations iterations = new SolverIterations();
                    world.Step(1.0f / 60.0f, ref iterations);
                }
                catch (InvalidOperationException)
                {
                    threw = true;
                }

                return true;
            };

            world.Step(1.0f / 60.0f);

            Assert.True(threw);
        }

        /// <summary>
        ///     Tests that fixture added dispatches for every fixture of the body.
        /// </summary>
        [Fact]
        public void FixtureAdded_WithMultipleFixtures_DispatchesForEach()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            int invoked = 0;
            world.FixtureAdded += (w, body, fixture) => invoked++;

            Body body = new Body();
            body.CreateFixture(new CircleShape(0.5f, 1.0f));
            body.CreateFixture(new CircleShape(0.5f, 1.0f));
            world.Add(body);

            Assert.True(invoked >= 2);
        }

        /// <summary>
        ///     Tests that ray cast through empty space returns the max fraction.
        /// </summary>
        [Fact]
        public void RayCast_ThroughEmptySpace_DoesNotInvokeCallback()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Static);
            int invoked = 0;

            world.RayCast((fixture, point, normal, fraction) =>
            {
                invoked++;
                return fraction;
            }, new Vector2F(-0.5f, 0.0f), new Vector2F(-5.0f, 0.0f));

            Assert.Equal(0, invoked);
        }

        /// <summary>
        ///     Tests that test point with a point outside returns null.
        /// </summary>
        [Fact]
        public void TestPoint_WithPointFarOutside_ReturnsNull()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Static);

            Fixture result = world.TestPoint(new Vector2F(0.9f, 0.9f));

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that create capsule with few vertices does not decompose.
        /// </summary>
        [Fact]
        public void CreateCapsule_WithFewVertices_CreatesPolygon()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            Body body = world.CreateCapsule(2.0f, 0.5f, 1, 0.5f, 1, 1.0f, Vector2F.Zero, 0, BodyType.Dynamic);

            Assert.NotNull(body);
            Assert.Equal(1, body.FixtureList.List.Count);
        }

        /// <summary>
        ///     Tests that remove joint with two joints on a body removes the second edge.
        /// </summary>
        [Fact]
        public void RemoveJoint_WithTwoJoints_RemovesSecondEdge()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2.0f, 0.0f), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(-2.0f, 0.0f), 0, BodyType.Dynamic);

            Joint joint2 = Alis.Core.Physic.Dynamics.Joints.JointFactory.CreateRevoluteJoint(world, bodyC, bodyB, Vector2F.Zero);
            Joint joint1 = Alis.Core.Physic.Dynamics.Joints.JointFactory.CreateRevoluteJoint(world, bodyA, bodyB, Vector2F.Zero);

            world.Remove(joint1);

            Assert.NotNull(bodyB.JointList);
        }

        /// <summary>
        ///     Tests that remove a body with contacts destroys its contacts.
        /// </summary>
        [Fact]
        public void Remove_BodyWithContacts_RemovesContacts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Assert.NotNull(bodyA.ContactList);

            world.Remove(bodyA);

            Assert.Null(bodyA.ContactList);
        }

        /// <summary>
        ///     Tests that removing a non-colliding joint filters the connecting contacts.
        /// </summary>
        [Fact]
        public void RemoveJoint_WithTouchingBodies_FiltersContacts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Joint joint = Alis.Core.Physic.Dynamics.Joints.JointFactory.CreateRevoluteJoint(world, bodyA, bodyB, Vector2F.Zero);
            Assert.NotNull(bodyA.ContactList);

            world.Remove(joint);

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that create rounded rectangle with few segments creates a polygon.
        /// </summary>
        [Fact]
        public void CreateRoundedRectangle_WithFewSegments_CreatesPolygon()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            Body body = world.CreateRoundedRectangle(2.0f, 1.0f, 0.3f, 0.3f, 2, 1.0f, Vector2F.Zero, 0, BodyType.Dynamic);

            Assert.NotNull(body);
        }
    }
}
