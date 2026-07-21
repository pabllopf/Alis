// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WeldJointRemainingCoverageTests.cs
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
    /// The weld joint remaining coverage tests class
    /// </summary>
    public class WeldJointRemainingCoverageTests
    {
        /// <summary>
        /// Tests that solve position constraints with frequency positive and large error returns false
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithFrequencyPositiveAndLargeError_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            joint.FrequencyHz = 10.0f;
            world.Add(joint);

            SolverData initData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { initData });

            typeof(WeldJoint).GetField("_indexA", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(joint, 0);
            typeof(WeldJoint).GetField("_indexB", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(joint, 1);

            SolverData posData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[]
                {
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f },
                    new SolverPosition { C = new Vector2F(10, 0), A = 0.0f }
                },
                Velocities = new SolverVelocity[]
                {
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f },
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f }
                },
                Locks = new int[] { 0, 1 }
            };

            MethodInfo solvePosMethod = typeof(WeldJoint).GetMethod("SolvePositionConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            bool result = (bool)solvePosMethod.Invoke(joint, new object[] { posData });

            Assert.False(result);
        }

        /// <summary>
        /// Tests that solve position constraints with frequency zero and separated bodies returns false
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithFrequencyZeroAndSeparatedBodies_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            world.Add(joint);

            SolverData initData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { initData });

            typeof(WeldJoint).GetField("_indexA", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(joint, 0);
            typeof(WeldJoint).GetField("_indexB", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(joint, 1);

            SolverData posData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[]
                {
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f },
                    new SolverPosition { C = new Vector2F(10, 0), A = 0.3f }
                },
                Velocities = new SolverVelocity[]
                {
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f },
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f }
                },
                Locks = new int[] { 0, 1 }
            };

            MethodInfo solvePosMethod = typeof(WeldJoint).GetMethod("SolvePositionConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            bool result = (bool)solvePosMethod.Invoke(joint, new object[] { posData });

            Assert.False(result);
        }

        /// <summary>
        /// Tests that solve position constraints with frequency zero and non zero inertia and angular error returns false
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithFrequencyZeroAndNonZeroInertiaAndAngularError_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            world.Add(joint);

            SolverData initData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { initData });

            typeof(WeldJoint).GetField("_indexA", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(joint, 0);
            typeof(WeldJoint).GetField("_indexB", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(joint, 1);

            SolverData posData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[]
                {
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f },
                    new SolverPosition { C = new Vector2F(2, 0), A = 0.3f }
                },
                Velocities = new SolverVelocity[]
                {
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f },
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f }
                },
                Locks = new int[] { 0, 1 }
            };

            MethodInfo solvePosMethod = typeof(WeldJoint).GetMethod("SolvePositionConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            bool result = (bool)solvePosMethod.Invoke(joint, new object[] { posData });

            Assert.False(result);
        }

        /// <summary>
        /// Tests that init velocity constraints with frequency positive and large inertia should exercise frequency path
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithFrequencyPositiveAndLargeInertia_ShouldExerciseFrequencyPath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(100f, 1.0f);
            CircleShape shapeB = new CircleShape(100f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            joint.FrequencyHz = 10.0f;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            FieldInfo massField = typeof(WeldJoint).GetField("_mass", BindingFlags.NonPublic | BindingFlags.Instance);
            object mass = massField.GetValue(joint);

            FieldInfo gammaField = typeof(WeldJoint).GetField("_gamma", BindingFlags.NonPublic | BindingFlags.Instance);
            float gamma = (float)gammaField.GetValue(joint);

            Assert.Equal(0.0f, gamma);
            Assert.NotNull(mass);
        }

        /// <summary>
        /// Tests that init velocity constraints with frequency positive and damping should exercise frequency path
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithFrequencyPositiveAndDamping_ShouldExerciseFrequencyPath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(50f, 1.0f);
            CircleShape shapeB = new CircleShape(50f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            joint.FrequencyHz = 10.0f;
            joint.DampingRatio = 1.0f;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            FieldInfo gammaField = typeof(WeldJoint).GetField("_gamma", BindingFlags.NonPublic | BindingFlags.Instance);
            float gamma = (float)gammaField.GetValue(joint);

            FieldInfo biasField = typeof(WeldJoint).GetField("_bias", BindingFlags.NonPublic | BindingFlags.Instance);
            float bias = (float)biasField.GetValue(joint);

            Assert.Equal(0.0f, gamma);
            Assert.Equal(0.0f, bias);
        }

        /// <summary>
        /// Tests that solve velocity constraints with frequency positive and non default velocity should modify impulse
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithFrequencyPositiveAndNonDefaultVelocity_ShouldModifyImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            joint.FrequencyHz = 10.0f;
            joint.DampingRatio = 1.0f;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = new Vector2F(1, 0), W = 0.5f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            MethodInfo solveMethod = typeof(WeldJoint).GetMethod("SolveVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            solveMethod.Invoke(joint, new object[] { data });

            FieldInfo impulseField = typeof(WeldJoint).GetField("_impulse", BindingFlags.NonPublic | BindingFlags.Instance);
            Vector3F impulse = (Vector3F)impulseField.GetValue(joint);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that get reaction force with simulated joint should return non zero
        /// </summary>
        [Fact]
        public void GetReactionForce_WithSimulatedJoint_ShouldReturnNonZero()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            joint.FrequencyHz = 10.0f;
            joint.DampingRatio = 1.0f;
            world.Add(joint);

            for (int i = 0; i < 10; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Vector2F force = joint.GetReactionForce(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that get reaction torque with simulated joint should return non zero
        /// </summary>
        [Fact]
        public void GetReactionTorque_WithSimulatedJoint_ShouldReturnNonZero()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            joint.FrequencyHz = 10.0f;
            joint.DampingRatio = 1.0f;
            world.Add(joint);

            for (int i = 0; i < 10; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            float torque = joint.GetReactionTorque(1.0f / 60.0f);

            Assert.NotNull(joint);
        }

        /// <summary>
        /// Tests that InitVelocityConstraints with FrequencyHz > 0 and bodies
        /// having extremely tiny total inverse inertia (iA + iB &lt; float.Epsilon)
        /// triggers the 1.0f / invM branch of the _mass.Ez.Z ternary at line 286.
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithFrequencyPositiveAndNearZeroTotalInvI_ShouldHitMassEzInfinityBranch()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);

            CircleShape shapeA = new CircleShape(6000f, 1e30f);
            CircleShape shapeB = new CircleShape(6000f, 1e30f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);
            joint.FrequencyHz = 10.0f;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            FieldInfo massField = typeof(WeldJoint).GetField("_mass", BindingFlags.NonPublic | BindingFlags.Instance);
            object mass = massField.GetValue(joint);
            FieldInfo ezField = mass.GetType().GetField("Ez");
            object ez = ezField.GetValue(mass);
            System.Reflection.PropertyInfo zProp = ez.GetType().GetProperty("Z");
            float ezZ = (float)zProp.GetValue(ez);

            Assert.False(float.IsNaN(ezZ));
        }
    }
}
