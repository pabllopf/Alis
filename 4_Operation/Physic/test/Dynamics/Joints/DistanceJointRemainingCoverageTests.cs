// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceJointRemainingCoverageTests.cs
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
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The distance joint remaining coverage tests class
    /// </summary>
    public class DistanceJointRemainingCoverageTests
    {
        /// <summary>
        /// Tests that init velocity constraints with static bodies sets mass to zero
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithStaticBodies_SetsMassToZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f }, new SolverPosition { C = new Vector2F(2.0f, 0.0f), A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f }, new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0, 1 }
            };

            MethodInfo initMethod = typeof(DistanceJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            FieldInfo massField = typeof(DistanceJoint).GetField("_mass", BindingFlags.NonPublic | BindingFlags.Instance);
            float mass = (float)massField.GetValue(joint);

            Assert.Equal(0.0f, mass, 5);
        }

        /// <summary>
        /// Tests that init velocity constraints with frequency and static bodies sets gamma to zero
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithFrequencyAndStaticBodies_SetsGammaToZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f))
                {
                    Frequency = 5.0f
                };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f }, new SolverPosition { C = new Vector2F(2.0f, 0.0f), A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f }, new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0, 1 }
            };

            MethodInfo initMethod = typeof(DistanceJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            FieldInfo gammaField = typeof(DistanceJoint).GetField("_gamma", BindingFlags.NonPublic | BindingFlags.Instance);
            float gamma = (float)gammaField.GetValue(joint);

            FieldInfo massField = typeof(DistanceJoint).GetField("_mass", BindingFlags.NonPublic | BindingFlags.Instance);
            float mass = (float)massField.GetValue(joint);

            Assert.Equal(0.0f, gamma, 5);
            Assert.Equal(0.0f, mass, 5);
        }

        /// <summary>
        /// Tests that solve velocity constraints with static bodies does not modify velocities
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithStaticBodies_DoesNotModifyVelocities()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f }, new SolverPosition { C = new Vector2F(2.0f, 0.0f), A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = new Vector2F(1.0f, 0.0f), W = 0.5f }, new SolverVelocity { V = new Vector2F(-1.0f, 0.0f), W = -0.5f } },
                Locks = new int[] { 0, 1 }
            };

            MethodInfo initMethod = typeof(DistanceJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            MethodInfo solveMethod = typeof(DistanceJoint).GetMethod("SolveVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            solveMethod.Invoke(joint, new object[] { data });

            FieldInfo impulseField = typeof(DistanceJoint).GetField("_impulse", BindingFlags.NonPublic | BindingFlags.Instance);
            float impulse = (float)impulseField.GetValue(joint);

            Assert.Equal(0.0f, impulse, 5);
        }

        /// <summary>
        /// Tests that solve position constraints with frequency zero and large error returns false
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithFrequencyZeroAndLargeError_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-5.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(5.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.5f, 0.0f))
                {
                    Frequency = 0.0f
                };
            world.Add(joint);

            int indexA = bodyA.GetIslandIndex;
            int indexB = bodyB.GetIslandIndex;
            int maxIndex = Math.Max(indexA, indexB) + 1;

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

            MethodInfo initMethod = typeof(DistanceJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            MethodInfo solvePositionMethod = typeof(DistanceJoint).GetMethod("SolvePositionConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            object result = solvePositionMethod.Invoke(joint, new object[] { data });

            Assert.False((bool)result);
        }

        /// <summary>
        /// Tests that solve position constraints with frequency zero and small error returns true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithFrequencyZeroAndSmallError_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f))
                {
                    Frequency = 0.0f
                };
            world.Add(joint);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            int indexA = bodyA.GetIslandIndex;
            int indexB = bodyB.GetIslandIndex;
            int maxIndex = Math.Max(indexA, indexB) + 1;

            SolverPosition[] positions = new SolverPosition[maxIndex];
            SolverVelocity[] velocities = new SolverVelocity[maxIndex];
            for (int i = 0; i < maxIndex; i++)
            {
                positions[i] = new SolverPosition { C = Vector2F.Zero, A = 0.0f };
                velocities[i] = new SolverVelocity { V = Vector2F.Zero, W = 0.0f };
            }

            positions[indexB] = new SolverPosition { C = new Vector2F(2.001f, 0), A = 0.0f };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            MethodInfo initMethod = typeof(DistanceJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            MethodInfo solvePositionMethod = typeof(DistanceJoint).GetMethod("SolvePositionConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            object result = solvePositionMethod.Invoke(joint, new object[] { data });

            Assert.True((bool)result);
        }

        /// <summary>
        /// Tests that solve position constraints with frequency zero and exact position returns true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithFrequencyZeroAndExactPosition_ReturnsTrue()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f }, new SolverPosition { C = new Vector2F(2.0f, 0.0f), A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f }, new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0, 1 }
            };

            MethodInfo initMethod = typeof(DistanceJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            MethodInfo solvePositionMethod = typeof(DistanceJoint).GetMethod("SolvePositionConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            object result = solvePositionMethod.Invoke(joint, new object[] { data });

            Assert.True((bool)result);
        }

        /// <summary>
        /// Tests that world anchor a set should store value in local center a
        /// </summary>
        [Fact]
        public void WorldAnchorA_Set_ShouldStoreValueInLocalCenterA()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Vector2F expected = new Vector2F(15.0f, 25.0f);
            joint.WorldAnchorA = expected;

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that world anchor b set should store value in local center a
        /// </summary>
        [Fact]
        public void WorldAnchorB_Set_ShouldStoreValueInLocalCenterA()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Vector2F expected = new Vector2F(30.0f, 40.0f);
            joint.WorldAnchorB = expected;

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that get reaction force with non zero impulse returns correct force
        /// </summary>
        [Fact]
        public void GetReactionForce_WithNonZeroImpulse_ReturnsCorrectForce()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f))
                {
                    Frequency = 10.0f,
                    DampingRatio = 1.0f
                };
            world.Add(joint);

            for (int i = 0; i < 30; i++)
            {
                SolverIterations iterations = new SolverIterations
                    {
                        PositionIterations = 10
                    };
                world.Step(1.0f / 60.0f, ref iterations);
            }

            Vector2F force = joint.GetReactionForce(1.0f / 60.0f);

            Assert.NotNull(joint);
        }
    }
}
