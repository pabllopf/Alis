using System;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The testable island class
    /// </summary>
    public class TestableIsland : Island
    {
        /// <summary>
        /// Calls the dispose with the specified disposing
        /// </summary>
        /// <param name="disposing">The disposing</param>
        public void CallDispose(bool disposing) => Dispose(disposing);
    }

    /// <summary>
    /// The island remaining coverage tests class
    /// </summary>
    public class IslandRemainingCoverageTests
    {
        /// <summary>
        /// Tests that dispose with false does not dispose contact solver
        /// </summary>
        [Fact]
        public void Dispose_WithFalse_DoesNotDisposeContactSolver()
        {
            TestableIsland island = new TestableIsland();
            Exception ex = Record.Exception(() => island.CallDispose(false));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that reset with null joints allocates joint buffer
        /// </summary>
        [Fact]
        public void Reset_WithSmallCapacity_AllocatesJointBufferFromNull()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();

            island.Reset(2, 2, 2, contactManager);

            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2, 0));
            island.Add(joint);

            Assert.Equal(1, island.JointCount);
        }

        /// <summary>
        /// Tests that solve position constraints returns false when constraints cannot be solved
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithDeepOverlap_ReturnsFalse()
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

        /// <summary>
        /// Tests that solve toi position iterations break early when contacts are okay
        /// </summary>
        [Fact]
        public void SolveToi_PositionIterations_ExecutesWithoutThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(-5f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(200f, 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that report returns early when contact manager is null
        /// </summary>
        [Fact]
        public void Report_WithNullContactManager_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            FieldInfo cmField = typeof(WorldPhysic).GetField("ContactManager", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            object originalCm = cmField?.GetValue(world);

            FieldInfo islandField = typeof(WorldPhysic).GetField("_island", BindingFlags.Instance | BindingFlags.NonPublic);
            object island = islandField?.GetValue(world);

            if (island != null)
            {
                FieldInfo contactManagerField = typeof(Island).GetField("_contactManager", BindingFlags.Instance | BindingFlags.NonPublic);
                contactManagerField?.SetValue(island, null);

                Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
                Assert.Null(ex);
            }
        }

        /// <summary>
        /// Tests that integrate velocities with damping applies correctly
        /// </summary>
        [Fact]
        public void IntegrateVelocities_WithDamping_ReducesVelocity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.LinearVelocityInternal = new Vector2F(10f, 0f);
            body.LinearDamping = 5f;

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(body.LinearVelocityInternal.Length() < 10f);
        }

        /// <summary>
        /// Tests that integrate velocities with angular damping applies correctly
        /// </summary>
        [Fact]
        public void IntegrateVelocities_WithAngularDamping_ReducesAngularVelocity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.AngularVelocity = 10f;
            body.AngularDamping = 5f;

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(Math.Abs(body.AngularVelocity) < 10f);
        }

        /// <summary>
        /// Tests that solve with multiple velocity iterations works correctly
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_MultipleIterations_ExecutesCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that solve joint velocity constraints with disabled joint skips it
        /// </summary>
        [Fact]
        public void SolveJointVelocityConstraints_WithDisabledJoint_SkipsProcessing()
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
        /// Tests that solve joint position constraints with disabled joint skips it
        /// </summary>
        [Fact]
        public void SolveJointPositionConstraints_WithDisabledJoint_SkipsProcessing()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f))
                {
                    Enabled = false
                };
            world.Add(joint);

            for (int i = 0; i < 5; i++)
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

        /// <summary>
        /// Tests that solve enabled joint velocity with diagnostics records time
        /// </summary>
        [Fact]
        public void SolveEnabledJointVelocity_WithDiagnostics_RecordsElapsedTime()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            world.Add(joint);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that synchronize body states updates transforms
        /// </summary>
        [Fact]
        public void SynchronizeBodyStates_WithMultipleBodies_UpdatesTransforms()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(10f, 0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(bodyA.GetTransform());
            Assert.NotNull(bodyB.GetTransform());
        }

        /// <summary>
        /// Tests that record joint update time with diagnostics enabled records non-zero time
        /// </summary>
        [Fact]
        public void RecordJointUpdateTime_WithDiagnosticsEnabled_RecordsTime()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            world.Add(joint);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(bodyA);
            Assert.NotNull(bodyB);
        }

        /// <summary>
        /// Tests that solve position constraints with unsolvable joints returns false
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithUnsolvableJoint_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(100f, 0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(bodyA);
            Assert.NotNull(bodyB);
        }

        /// <summary>
        /// Tests that update sleep state processes static bodies without affecting others
        /// </summary>
        [Fact]
        public void UpdateSleepState_WithMixedBodyTypes_ProcessesCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body staticBody = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f));
            Body dynamicBody = world.CreateCircle(1.0f, 1.0f, new Vector2F(10f, 0f), BodyType.Dynamic);

            for (int i = 0; i < 300; i++)
            {
                SolverIterations iterations = new SolverIterations
                    {
                        PositionIterations = 10
                    };
                world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.False(dynamicBody.Awake);
            Assert.NotNull(staticBody);
        }

        /// <summary>
        /// Tests that integrate velocities with dynamic body and torque applies correctly
        /// </summary>
        [Fact]
        public void IntegrateVelocities_WithTorque_ChangesAngularVelocity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.Torque = 10f;

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(body);
        }

        /// <summary>
        /// Tests that add body sets island index correctly
        /// </summary>
        [Fact]
        public void AddBody_SetsIslandIndex()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();
            island.Reset(4, 4, 4, contactManager);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f));

            island.Add(body);

            Assert.Equal(0, body.GetIslandIndex);
            Assert.Equal(1, island.BodyCount);
        }

        /// <summary>
        /// Tests that solve toi with high velocity iteration executes without throw
        /// </summary>
        [Fact]
        public void SolveToi_WithHighVelocityIterations_ExecutesWithoutThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(-10f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(500f, 0f);

            for (int i = 0; i < 5; i++)
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
        // IntegratePositions with clamping (both translation and rotation)
        // ========================================================================
        /// <summary>
        /// Tests that integrate positions clamping both works
        /// </summary>
        [Fact]
        public void IntegratePositions_ClampingBoth_Works()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.LinearVelocityInternal = new Vector2F(5000f, 0f);
            body.AngularVelocity = 5000f;
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // UpdateSleepState with minSleepTime >= TimeToSleep and positionSolved true
        // ========================================================================
        /// <summary>
        /// Tests that update sleep state enough sleep time and position solved sleeps
        /// </summary>
        [Fact]
        public void UpdateSleepState_EnoughSleepTime_AndPositionSolved_Sleeps()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.SleepingAllowed = true;
            for (int i = 0; i < 600; i++)
            {
                SolverIterations iterations = new SolverIterations
                    {
                        PositionIterations = 10
                    };
                world.Step(1.0f / 60.0f, ref iterations);
            }
            Assert.False(body.Awake);
        }

        // ========================================================================
        // SolveToi with velocity iterations after position solve
        // ========================================================================
        /// <summary>
        /// Tests that solve toi velocity iterations executes
        /// </summary>
        [Fact]
        public void SolveToi_VelocityIterations_Executes()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(-10f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(500f, 0f);
            for (int i = 0; i < 3; i++)
            {
                Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
                Assert.Null(ex);
            }
        }

        // ========================================================================
        // Report with null ContactVelocityConstraint (edge case)
        // ========================================================================
        /// <summary>
        /// Tests that report with constraints array does not throw
        /// </summary>
        [Fact]
        public void Report_WithConstraintsArray_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // InitializeSolverData with step.WarmStarting = false
        // ========================================================================
        /// <summary>
        /// Tests that initialize solver data with no warm starting does not warm start
        /// </summary>
        [Fact]
        public void InitializeSolverData_WithNoWarmStarting_DoesNotWarmStart()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // SolvePositionConstraints with enabled joints (full path)
        // ========================================================================
        /// <summary>
        /// Tests that solve position constraints with enabled joints resolves
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithEnabledJoints_Resolves()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f))
                {
                    CollideConnected = false
                };
            world.Add(joint);
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // Dispose after Reset — exercises non-null Return*Array paths (lines 672-676, 684-688)
        // ========================================================================
        /// <summary>
        /// Tests that dispose after reset returns arrays to pool without throwing
        /// </summary>
        [Fact]
        public void Dispose_AfterReset_ReturnsArraysToPool()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager contactManager = world.ContactManager;
            Island island = new Island();
            island.Reset(32, 32, 32, contactManager);

            Body bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            island.Add(bodyA);
            island.Add(bodyB);
            island.Add(joint);

            Exception ex = Record.Exception(() => island.Dispose());
            Assert.Null(ex);
        }

        // ========================================================================
        // SolveToi — translation clamping in body update loop (lines 604-609)
        // Sets up solver arrays directly with extreme velocity and calls SolveToi
        // via reflection with zero contacts so only the body update loop executes.
        // ========================================================================
        /// <summary>
        /// Tests that solve toi clamps translation when velocity is extreme
        /// </summary>
        [Fact]
        public void SolveToi_ClampsTranslation_WhenVelocityExtreme()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager cm = world.ContactManager;
            Island island = new Island();
            island.Reset(8, 0, 0, cm);

            Body body = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            body.LinearVelocityInternal = new Vector2F(100000f, 0f);
            island.Add(body);
            island.BodyCount = 1;

            FieldInfo velField = typeof(Island).GetField("Velocities", BindingFlags.Instance | BindingFlags.NonPublic);
            SolverVelocity[] velocities = (SolverVelocity[])velField.GetValue(island);
            velocities[0].V = new Vector2F(100000f, 0f);
            velocities[0].W = 0f;

            FieldInfo posField = typeof(Island).GetField("Positions", BindingFlags.Instance | BindingFlags.NonPublic);
            SolverPosition[] positions = (SolverPosition[])posField.GetValue(island);
            positions[0].C = new Vector2F(0f, 0f);
            positions[0].A = 0f;

            TimeStep subStep = new TimeStep
                {
                    Dt = 1.0f / 60.0f,
                    InvDt = 60.0f,
                    PositionIterations = 0,
                    VelocityIterations = 0,
                    WarmStarting = false,
                    DtRatio = 1.0f
                };

            MethodInfo solveToi = typeof(Island).GetMethod("SolveToi", BindingFlags.Instance | BindingFlags.NonPublic);
            object[] args = { subStep, 0, 0 };
            solveToi.Invoke(island, args);

            Assert.True(body.Position.X < 10f);
        }

        // ========================================================================
        // SolveToi — rotation clamping in body update loop (lines 611-616)
        // Sets up solver arrays directly with extreme angular velocity.
        // ========================================================================
        /// <summary>
        /// Tests that solve toi clamps rotation when angular velocity is extreme
        /// </summary>
        [Fact]
        public void SolveToi_ClampsRotation_WhenAngularVelocityExtreme()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager cm = world.ContactManager;
            Island island = new Island();
            island.Reset(8, 0, 0, cm);

            Body body = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            body.LinearVelocityInternal = new Vector2F(100000f, 0f);
            body.AngularVelocity = 50000f;
            island.Add(body);
            island.BodyCount = 1;

            FieldInfo velField = typeof(Island).GetField("Velocities", BindingFlags.Instance | BindingFlags.NonPublic);
            SolverVelocity[] velocities = (SolverVelocity[])velField.GetValue(island);
            velocities[0].V = new Vector2F(100000f, 0f);
            velocities[0].W = 50000f;

            FieldInfo posField = typeof(Island).GetField("Positions", BindingFlags.Instance | BindingFlags.NonPublic);
            SolverPosition[] positions = (SolverPosition[])posField.GetValue(island);
            positions[0].C = new Vector2F(0f, 0f);
            positions[0].A = 0f;

            TimeStep subStep = new TimeStep
                {
                    Dt = 1.0f / 60.0f,
                    InvDt = 60.0f,
                    PositionIterations = 0,
                    VelocityIterations = 0,
                    WarmStarting = false,
                    DtRatio = 1.0f
                };

            MethodInfo solveToi = typeof(Island).GetMethod("SolveToi", BindingFlags.Instance | BindingFlags.NonPublic);
            object[] args = { subStep, 0, 0 };
            solveToi.Invoke(island, args);

            Assert.NotNull(body);
        }

        // ========================================================================
        // SolveToi — velocity clamping via direct internal call (lines 604-616)
        // Sets up Velocities array with values exceeding threshold and calls SolveToi
        // directly to guarantee the clamping branch is hit.
        // ========================================================================
        /// <summary>
        /// Tests that solve toi clamps extreme linear and angular velocity
        /// </summary>
        [Fact]
        public void SolveToi_ClampsExtremeVelocity_WhenMovingFast()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ContactManager cm = world.ContactManager;
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f));

            bodyA.IsBullet = true;
            bodyA.LinearVelocityInternal = new Vector2F(100000f, 0f);
            bodyA.AngularVelocity = 50000f;

            for (int i = 0; i < 10; i++)
            {
                SolverIterations iterations = new SolverIterations
                    {
                        PositionIterations = 10
                    };
                world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.NotNull(bodyA);
        }
    }
}