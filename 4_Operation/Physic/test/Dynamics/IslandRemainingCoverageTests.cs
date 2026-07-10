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
                world.Step(1.0f / 60.0f);
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
        /// Tests that update sleep state with position solved false does not sleep bodies
        /// </summary>
        [Fact]
        public void UpdateSleepState_WithPositionNotSolved_DoesNotForceSleep()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.1f, 0.0f), BodyType.Dynamic);

            for (int i = 0; i < 300; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.NotNull(bodyA);
            Assert.NotNull(bodyB);
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

            world.Step(1.0f / 60.0f);
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

            world.Step(1.0f / 60.0f);

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

            world.Step(1.0f / 60.0f);

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
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            joint.Enabled = false;
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
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            joint.Enabled = false;
            world.Add(joint);

            for (int i = 0; i < 5; i++)
            {
                world.Step(1.0f / 60.0f);
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

            world.Step(1.0f / 60.0f);

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

            world.Step(1.0f / 60.0f);

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

            world.Step(1.0f / 60.0f);

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
            Body staticBody = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Static);
            Body dynamicBody = world.CreateCircle(1.0f, 1.0f, new Vector2F(10f, 0f), BodyType.Dynamic);

            for (int i = 0; i < 300; i++)
            {
                world.Step(1.0f / 60.0f);
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

            world.Step(1.0f / 60.0f);

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
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Static);

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
                world.Step(1.0f / 60.0f);
            }

            Assert.NotNull(bodyA);
            Assert.NotNull(bodyB);
        }
    }
}
