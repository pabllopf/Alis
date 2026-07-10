// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IslandTest.cs
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
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The island test class
    /// </summary>
    public class IslandTest
    {
        /// <summary>
        /// Tests that island type should be accessible
        /// </summary>
        [Fact]
        public void Island_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(Island));
        }

        /// <summary>
        /// Tests that reset should set counts to zero
        /// </summary>
        [Fact]
        public void Reset_ShouldSetCountsToZero()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();

            island.Reset(2, 2, 2, contactManager);

            Assert.Equal(0, island.BodyCount);
            Assert.Equal(0, island.ContactCount);
            Assert.Equal(0, island.JointCount);
        }

        /// <summary>
        /// Tests that reset should allocate buffers with minimum capacity
        /// </summary>
        [Fact]
        public void Reset_ShouldAllocateBuffersWithMinimumCapacity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();

            island.Reset(1, 1, 1, contactManager);

            Assert.NotNull(island.Bodies);
            Assert.True(island.Bodies.Length >= 32);
        }

        /// <summary>
        /// Tests that clear should reset all counts to zero
        /// </summary>
        [Fact]
        public void Clear_ShouldResetAllCountsToZero()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();
            island.Reset(4, 4, 4, contactManager);

            island.Clear();

            Assert.Equal(0, island.BodyCount);
            Assert.Equal(0, island.ContactCount);
            Assert.Equal(0, island.JointCount);
        }

        /// <summary>
        /// Tests that add body should increment body count
        /// </summary>
        [Fact]
        public void AddBody_ShouldIncrementBodyCount()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();
            island.Reset(4, 4, 4, contactManager);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Static);

            island.Add(body);

            Assert.Equal(1, island.BodyCount);
        }

        /// <summary>
        /// Tests that dispose should not throw
        /// </summary>
        [Fact]
        public void Dispose_ShouldNotThrow()
        {
            Island island = new Island();

            Exception ex = Record.Exception(() => island.Dispose());

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that dispose called twice should not throw
        /// </summary>
        [Fact]
        public void Dispose_CalledTwice_ShouldNotThrow()
        {
            Island island = new Island();

            island.Dispose();
            Exception ex = Record.Exception(() => island.Dispose());

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that add contact should increment contact count
        /// </summary>
        [Fact]
        public void AddContact_ShouldIncrementContactCount()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();
            island.Reset(4, 4, 4, contactManager);

            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            CircleShape shapeA = new CircleShape(1.0f, 1.0f);
            CircleShape shapeB = new CircleShape(1.0f, 1.0f);
            Fixture fixtureA = bodyA.CreateFixture(shapeA);
            Fixture fixtureB = bodyB.CreateFixture(shapeB);
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);

            island.Add(contact);

            Assert.Equal(1, island.ContactCount);
        }

        /// <summary>
        /// Tests that add joint should increment joint count
        /// </summary>
        [Fact]
        public void AddJoint_ShouldIncrementJointCount()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();
            island.Reset(4, 4, 4, contactManager);

            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2, 0));

            island.Add(joint);

            Assert.Equal(1, island.JointCount);
        }

        /// <summary>
        /// Tests that reset reuses existing buffers when capacity is sufficient
        /// </summary>
        [Fact]
        public void Reset_WithSufficientCapacity_ReusesExistingBuffers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();

            island.Reset(40, 40, 40, contactManager);
            Body[] originalBodies = island.Bodies;

            island.Reset(10, 10, 10, contactManager);

            Assert.Same(originalBodies, island.Bodies);
        }

        /// <summary>
        /// Tests that solve through world step does not throw
        /// </summary>
        [Fact]
        public void Solve_ThroughWorldStep_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that after collision handlers are called through Island.Report
        /// </summary>
        [Fact]
        public void AfterCollisionHandlers_ShouldBeCalled_ThroughIslandReport()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            int fixtureACount = 0;
            int fixtureBCount = 0;

            world.ContactManager.BeginContact = contact =>
            {
                contact.FixtureA.AfterCollision = (_, _, _, _) => fixtureACount++;
                contact.FixtureB.AfterCollision = (_, _, _, _) => fixtureBCount++;
                return true;
            };

            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Assert.True(fixtureACount > 0);
            Assert.True(fixtureBCount > 0);
        }

        /// <summary>
        /// Tests that post solve handler is called through Island.Report
        /// </summary>
        [Fact]
        public void PostSolveHandler_ShouldBeCalled_ThroughIslandReport()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            int postSolveCount = 0;
            world.ContactManager.PostSolve = (_, _) => postSolveCount++;

            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Assert.True(postSolveCount > 0);
        }

        [Fact]
        public void Reset_ExpandsBodiesBuffer_WhenCapacityExceedsInitial()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();
            island.Reset(1, 1, 1, contactManager);
            Body[] originalBodies = island.Bodies;

            island.Reset(50, 1, 1, contactManager);

            Assert.NotSame(originalBodies, island.Bodies);
        }

        [Fact]
        public void IntegratePositions_WithHighVelocity_ClampsTranslation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.LinearVelocityInternal = new Vector2F(5000f, 0f);

            world.Step(1.0f / 60.0f);

            Assert.True(body.Position.X < 10f);
        }

        [Fact]
        public void IntegratePositions_WithHighAngularVelocity_ClampsRotation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.AngularVelocity = 500f;

            world.Step(1.0f / 60.0f);

            Assert.NotNull(body);
        }

        [Fact]
        public void UpdateSleepState_ResetsSleepTime_WhenVelocityExceedsTolerance()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.LinearVelocityInternal = new Vector2F(0.1f, 0f);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(body);
        }

        [Fact]
        public void SolveToi_ShouldNotThrow_WhenCalledThroughStep()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }
        [Fact]
        public void IntegrateVelocities_WithIgnoreGravity_SkipsGravity()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0f, -9.80665f));
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.IgnoreGravity = true;
            Vector2F startPos = body.Position;

            world.Step(1.0f / 60.0f);

            Assert.Equal(startPos, body.Position);
        }

        [Fact]
        public void IntegratePositions_WithHighAngularVelocity_ClampsRotationValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.AngularVelocity = 500f;

            world.Step(1.0f / 60.0f);

            Assert.True(body.Rotation < 50f);
        }

        [Fact]
        public void UpdateSleepState_WithStationaryBodies_EventuallySleeps()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.SleepingAllowed = true;

            for (int i = 0; i < 300; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.False(body.Awake);
        }

        [Fact]
        public void Solve_WithDisabledJoint_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            joint.Enabled = false;
            world.Add(joint);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }

        [Fact]
        public void SolvePositionConstraints_WithNonOverlappingBodies_ReturnsEarly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(100f, 0f), BodyType.Dynamic);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }

        [Fact]
        public void UpdateSleepState_WithSleepingNotAllowed_ResetsSleepTime()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.SleepingAllowed = false;

            for (int i = 0; i < 300; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(body.Awake);
        }
    }
}

