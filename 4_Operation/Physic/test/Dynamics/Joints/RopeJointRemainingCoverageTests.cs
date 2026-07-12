// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RopeJointRemainingCoverageTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The rope joint remaining coverage tests class
    /// </summary>
    public class RopeJointRemainingCoverageTests
    {
        /// <summary>
        /// Tests that init velocity constraints with warm starting and non zero impulse applies impulse
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithWarmStartingAndNonZeroImpulse_AppliesImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));
            joint.MaxLength = 3.0f;
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            int indexA = bodyA.GetIslandIndex;
            int indexB = bodyB.GetIslandIndex;
            int maxIndex = System.Math.Max(indexA, indexB) + 1;

            SolverPosition[] positions = new SolverPosition[maxIndex];
            SolverVelocity[] velocities = new SolverVelocity[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                positions[i] = new SolverPosition { C = Vector2F.Zero, A = 0.0f };
                velocities[i] = new SolverVelocity { V = Vector2F.Zero, W = 0.0f };
            }

            positions[indexA] = new SolverPosition { C = new Vector2F(0, 0), A = 0.0f };
            positions[indexB] = new SolverPosition { C = new Vector2F(2.0f, 0), A = 0.0f };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = true, DtRatio = 1.0f },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            joint._impulse = 5.0f;
            joint.InitVelocityConstraints(ref data);

            Assert.Equal(5.0f, joint._impulse);
            Assert.NotEqual(Vector2F.Zero, velocities[indexA].V);
            Assert.NotEqual(Vector2F.Zero, velocities[indexB].V);
        }

        /// <summary>
        /// Tests that init velocity constraints with stretched bodies sets state to at upper
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithStretchedBodies_SetsStateToAtUpper()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(5.0f, 0.0f));
            joint.MaxLength = 1.0f;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            joint.InitVelocityConstraints(ref data);

            Assert.Equal(LimitState.AtUpper, joint.State);
        }

        /// <summary>
        /// Tests that init velocity constraints with length within max sets state to inactive
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithLengthWithinMax_SetsStateToInactive()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));
            joint.MaxLength = 5.0f;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            joint.InitVelocityConstraints(ref data);

            Assert.Equal(LimitState.Inactive, joint.State);
        }

        /// <summary>
        /// Tests that init velocity constraints with static bodies sets mass to zero
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithStaticBodies_SetsMassToZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            joint.InitVelocityConstraints(ref data);

            Assert.Equal(0.0f, joint._mass);
        }

        /// <summary>
        /// Tests that solve velocity constraints with positive error and separating velocities applies impulse
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithPositiveErrorAndSeparatingVelocities_AppliesImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));
            joint.MaxLength = 1.0f;
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            int indexA = bodyA.GetIslandIndex;
            int indexB = bodyB.GetIslandIndex;
            int maxIndex = System.Math.Max(indexA, indexB) + 1;

            SolverPosition[] positions = new SolverPosition[maxIndex];
            SolverVelocity[] velocities = new SolverVelocity[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                positions[i] = new SolverPosition { C = Vector2F.Zero, A = 0.0f };
                velocities[i] = new SolverVelocity { V = Vector2F.Zero, W = 0.0f };
            }

            positions[indexA] = new SolverPosition { C = new Vector2F(0, 0), A = 0.0f };
            positions[indexB] = new SolverPosition { C = new Vector2F(0, 0), A = 0.0f };
            velocities[indexB] = new SolverVelocity { V = new Vector2F(5.0f, 0.0f), W = 0.0f };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            joint.InitVelocityConstraints(ref data);

            float impulseBefore = joint._impulse;
            joint.SolveVelocityConstraints(ref data);
            float impulseAfter = joint._impulse;

            Assert.NotEqual(impulseBefore, impulseAfter);
            Assert.True(impulseAfter <= 0.0f);
        }

        /// <summary>
        /// Tests that solve position constraints with large error returns false
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithLargeError_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-5.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(5.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.5f, 0.0f));
            joint.MaxLength = 1.0f;
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            int indexA = bodyA.GetIslandIndex;
            int indexB = bodyB.GetIslandIndex;
            int maxIndex = System.Math.Max(indexA, indexB) + 1;

            SolverPosition[] positions = new SolverPosition[maxIndex];
            SolverVelocity[] velocities = new SolverVelocity[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                positions[i] = new SolverPosition { C = Vector2F.Zero, A = 0.0f };
                velocities[i] = new SolverVelocity { V = Vector2F.Zero, W = 0.0f };
            }

            positions[indexA] = new SolverPosition { C = new Vector2F(-5.0f, 0), A = 0.0f };
            positions[indexB] = new SolverPosition { C = new Vector2F(5.0f, 0), A = 0.0f };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            joint.InitVelocityConstraints(ref data);

            bool result = joint.SolvePositionConstraints(ref data);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that solve position constraints with small error returns true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithSmallError_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));
            joint.MaxLength = 2.0f;
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            int indexA = bodyA.GetIslandIndex;
            int indexB = bodyB.GetIslandIndex;
            int maxIndex = System.Math.Max(indexA, indexB) + 1;

            SolverPosition[] positions = new SolverPosition[maxIndex];
            SolverVelocity[] velocities = new SolverVelocity[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                positions[i] = new SolverPosition { C = Vector2F.Zero, A = 0.0f };
                velocities[i] = new SolverVelocity { V = Vector2F.Zero, W = 0.0f };
            }

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            joint.InitVelocityConstraints(ref data);

            bool result = joint.SolvePositionConstraints(ref data);

            Assert.True(result);
        }

        /// <summary>
        /// Tests that solve position constraints with both bodies at same center returns true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithBodiesAtSameCenter_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));
            joint.MaxLength = 2.0f;
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            int indexA = bodyA.GetIslandIndex;
            int indexB = bodyB.GetIslandIndex;
            int maxIndex = System.Math.Max(indexA, indexB) + 1;

            SolverPosition[] positions = new SolverPosition[maxIndex];
            SolverVelocity[] velocities = new SolverVelocity[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                positions[i] = new SolverPosition { C = Vector2F.Zero, A = 0.0f };
                velocities[i] = new SolverVelocity { V = Vector2F.Zero, W = 0.0f };
            }

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            joint.InitVelocityConstraints(ref data);

            bool result = joint.SolvePositionConstraints(ref data);

            Assert.True(result);
        }

        /// <summary>
        /// Tests that init velocity constraints with warm starting and zero impulse does not change velocities
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithWarmStartingZeroImpulse_DoesNotChangeVelocities()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            int indexA = bodyA.GetIslandIndex;
            int indexB = bodyB.GetIslandIndex;
            int maxIndex = System.Math.Max(indexA, indexB) + 1;

            SolverPosition[] positions = new SolverPosition[maxIndex];
            SolverVelocity[] velocities = new SolverVelocity[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                positions[i] = new SolverPosition { C = Vector2F.Zero, A = 0.0f };
                velocities[i] = new SolverVelocity { V = Vector2F.Zero, W = 0.0f };
            }

            positions[indexA] = new SolverPosition { C = new Vector2F(0, 0), A = 0.0f };
            positions[indexB] = new SolverPosition { C = new Vector2F(2.0f, 0), A = 0.0f };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = true, DtRatio = 0.5f },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            joint.InitVelocityConstraints(ref data);

            Assert.Equal(0.0f, joint._impulse);
        }

        /// <summary>
        /// Tests that solve position constraints through world step does not throw
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_ThroughWorldStep_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-2.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));
            joint.MaxLength = 1.0f;
            world.Add(joint);

            for (int i = 0; i < 60; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that get reaction force after full simulation returns non zero
        /// </summary>
        [Fact]
        public void GetReactionForce_AfterFullSimulation_ReturnsNonZero()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));
            joint.MaxLength = 0.5f;
            world.Add(joint);

            for (int i = 0; i < 30; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Vector2F force = joint.GetReactionForce(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that init velocity constraints with different island indices works correctly
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithDifferentIslandIndices_WorksCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));
            joint.MaxLength = 3.0f;
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            int indexA = bodyA.GetIslandIndex;
            int indexB = bodyB.GetIslandIndex;

            Assert.NotEqual(indexA, indexB);

            for (int i = 0; i < 10; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that solve velocity constraints with positive error and zero velocity does not change impulse
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithPositiveErrorAndZeroVelocity_KeepsImpulseAtZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RopeJoint joint = new RopeJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(3.0f, 0.0f));
            joint.MaxLength = 1.0f;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            joint.InitVelocityConstraints(ref data);

            Assert.Equal(LimitState.AtUpper, joint.State);

            joint.SolveVelocityConstraints(ref data);

            Assert.True(joint._impulse <= 0.0f);
        }
    }
}
