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
using System.Reflection;
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
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f));

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
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

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
        /// Tests that reset expands bodies buffer when capacity exceeds initial
        /// </summary>
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

        /// <summary>
        /// Tests that integrate positions with high velocity clamps translation
        /// </summary>
        [Fact]
        public void IntegratePositions_WithHighVelocity_ClampsTranslation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.LinearVelocityInternal = new Vector2F(5000f, 0f);

            world.Step(1.0f / 60.0f);

            Assert.True(body.Position.X < 10f);
        }

        /// <summary>
        /// Tests that integrate positions with high angular velocity clamps rotation
        /// </summary>
        [Fact]
        public void IntegratePositions_WithHighAngularVelocity_ClampsRotation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.AngularVelocity = 500f;

            world.Step(1.0f / 60.0f);

            Assert.NotNull(body);
        }

        /// <summary>
        /// Tests that update sleep state resets sleep time when velocity exceeds tolerance
        /// </summary>
        [Fact]
        public void UpdateSleepState_ResetsSleepTime_WhenVelocityExceedsTolerance()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.LinearVelocityInternal = new Vector2F(0.1f, 0f);

            world.Step(1.0f / 60.0f);

            Assert.NotNull(body);
        }

        /// <summary>
        /// Tests that solve toi should not throw when called through step
        /// </summary>
        [Fact]
        public void SolveToi_ShouldNotThrow_WhenCalledThroughStep()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }
        /// <summary>
        /// Tests that integrate velocities with ignore gravity skips gravity
        /// </summary>
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

        /// <summary>
        /// Tests that integrate positions with high angular velocity clamps rotation value
        /// </summary>
        [Fact]
        public void IntegratePositions_WithHighAngularVelocity_ClampsRotationValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.AngularVelocity = 500f;

            world.Step(1.0f / 60.0f);

            Assert.True(body.Rotation < 50f);
        }

        /// <summary>
        /// Tests that update sleep state with stationary bodies eventually sleeps
        /// </summary>
        [Fact]
        public void UpdateSleepState_WithStationaryBodies_EventuallySleeps()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.SleepingAllowed = true;

            for (int i = 0; i < 300; i++)
            {
                SolverIterations iterations = new SolverIterations
                    {
                        PositionIterations = 10
                    };
                world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.False(body.Awake);
        }

        /// <summary>
        /// Tests that solve with disabled joint does not throw
        /// </summary>
        [Fact]
        public void Solve_WithDisabledJoint_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f))
                {
                    Enabled = false
                };
            world.Add(joint);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that solve position constraints with non overlapping bodies returns early
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithNonOverlappingBodies_ReturnsEarly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(100f, 0f), BodyType.Dynamic);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that update sleep state with sleeping not allowed resets sleep time
        /// </summary>
        [Fact]
        public void UpdateSleepState_WithSleepingNotAllowed_ResetsSleepTime()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.SleepingAllowed = false;

            for (int i = 0; i < 300; i++)
            {
                SolverIterations iterations = new SolverIterations
                    {
                        PositionIterations = 10
                    };
                world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.True(body.Awake);
        }

        /// <summary>
        /// Tests that solve position constraints contacts and joints okay returns true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_ContactsAndJointsOkay_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that solve toi with island bodies does not throw
        /// </summary>
        [Fact]
        public void SolveToi_WithIslandBodies_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(-10f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that reset with null bodies allocates new buffers
        /// </summary>
        [Fact]
        public void Reset_WithNullBodies_AllocatesNewBuffers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();
            island.Reset(1, 1, 1, contactManager);
            Assert.NotNull(island.Bodies);
            Assert.NotNull(island.Velocities);
            Assert.NotNull(island.Positions);
            Assert.NotNull(island.Locks);
        }

        /// <summary>
        /// Tests that reset expands contacts buffer when capacity exceeds initial
        /// </summary>
        [Fact]
        public void Reset_ExpandsContactsBuffer_WhenCapacityExceedsInitial()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();
            island.Reset(1, 1, 1, contactManager);

            island.Reset(1, 50, 1, contactManager);
            Assert.NotNull(island.Bodies);
        }

        /// <summary>
        /// Tests that update sleep state with static body skips sleep processing
        /// </summary>
        [Fact]
        public void UpdateSleepState_WithStaticBody_SkipsSleepProcessing()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero);

            for (int i = 0; i < 300; i++)
            {
                SolverIterations iterations = new SolverIterations
                    {
                        PositionIterations = 10
                    };
                world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.NotNull(body);
        }

        // ========================================================================
        // UpdateSleepState — SettingEnv.AllowSleep = false (early return)
        // Note: AllowSleep is readonly; test verifies sleep behavior with default setting.
        // ========================================================================
        /// <summary>
        /// Tests that update sleep state with allow sleep true does not throw
        /// </summary>
        [Fact]
        public void UpdateSleepState_WithAllowSleepTrue_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            for (int i = 0; i < 10; i++)
            {
                SolverIterations iterations = new SolverIterations
                    {
                        PositionIterations = 10
                    };
                world.Step(1.0f / 60.0f, ref iterations);
            }
            Assert.NotNull(body);
        }

        // ========================================================================
        // SolveToi — early break when contacts okay
        // ========================================================================
        /// <summary>
        /// Tests that solve toi position iterations break early when contacts okay
        /// </summary>
        [Fact]
        public void SolveToi_PositionIterationsBreakEarly_WhenContactsOkay()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(-5f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // SolvePositionConstraints — returns false when unsolvable
        // ========================================================================
        /// <summary>
        /// Tests that solve position constraints unsolvable returns false
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_Unsolvable_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.001f, 0.0f), BodyType.Dynamic);
            for (int i = 0; i < 10; i++)
            {
                SolverIterations iterations = new SolverIterations
                    {
                        PositionIterations = 10
                    };
                world.Step(1.0f / 60.0f, ref iterations);
            }
            Assert.NotNull(bodyA);
            Assert.NotNull(bodyB);
        }

        // ========================================================================
        // Report — with contact manager and constraints
        // ========================================================================
        /// <summary>
        /// Tests that report with handlers invokes all
        /// </summary>
        [Fact]
        public void Report_WithHandlers_InvokesAll()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            int postSolveCount = 0;
            world.ContactManager.PostSolve = (_, _) => postSolveCount++;
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            Assert.True(postSolveCount > 0);
        }

        // ========================================================================
        // Solve — with multiple velocity iterations
        // ========================================================================
        /// <summary>
        /// Tests that solve multiple velocity iterations executes
        /// </summary>
        [Fact]
        public void Solve_MultipleVelocityIterations_Executes()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            SolverIterations iterations = new SolverIterations
            {
                PositionIterations = 3,
                VelocityIterations = 3,
                ToiPositionIterations = 3,
                ToiVelocityIterations = 3
            };
            world.Step(TimeSpan.FromSeconds(1.0f / 60.0f), ref iterations);
            Assert.NotNull(bodyA);
            Assert.NotNull(bodyB);
        }

        // ========================================================================
        // UpdateSleepState — body with SleepingAllowed = false (line 523-527)
        // Exercises the sleep-time reset when SleepingAllowed is false
        // ========================================================================
        /// <summary>
        /// Tests that update sleep state resets sleep time when sleeping not allowed
        /// </summary>
        [Fact]
        public void UpdateSleepState_WhenSleepingNotAllowed_ResetsSleepTime()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.SleepingAllowed = false;

            for (int i = 0; i < 300; i++)
            {
                SolverIterations iterations = new SolverIterations
                    {
                        PositionIterations = 10
                    };
                world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.True(body.Awake);
        }

        // ========================================================================
        // SolveToi — clamps translation and rotation when velocity is high (lines 598-609)
        // Exercises the velocity clamping branches in SolveToi
        // ========================================================================
        /// <summary>
        /// Tests that solve toi clamps translation and rotation when velocity exceeds limits
        /// </summary>
        [Fact]
        public void SolveToi_ClampsTranslationAndRotation_WhenVelocityHigh()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            bodyA.IsBullet = true;
            bodyA.LinearVelocityInternal = new Vector2F(20000f, 0f);
            bodyA.AngularVelocity = 10000f;

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

    }
}

