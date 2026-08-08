// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrictionJointRemainingCoverageTests.cs
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
    /// The friction joint remaining coverage tests class
    /// </summary>
    public class FrictionJointRemainingCoverageTests
    {
        /// <summary>
        /// Tests that solve position constraints always returns true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_AlwaysReturnsTrue()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo method = typeof(FrictionJoint).GetMethod("SolvePositionConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            object result = method.Invoke(joint, new object[] { data });

            Assert.True((bool)result);
        }

        /// <summary>
        /// Tests that init velocity constraints with zero angular mass leaves angular mass zero
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithZeroAngularMass_LeavesAngularMassZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(FrictionJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            FieldInfo angularMassField = typeof(FrictionJoint).GetField("_angularMass", BindingFlags.NonPublic | BindingFlags.Instance);
            float angularMass = (float)angularMassField.GetValue(joint);

            Assert.Equal(0.0f, angularMass, 5);
        }

        /// <summary>
        /// Tests that solve angular friction with excess torque clamps angular impulse
        /// </summary>
        [Fact]
        public void SolveAngularFriction_WithExcessTorque_ClampsAngularImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);
            joint.MaxTorque = 5.0f;
            world.Add(joint);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
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

            velocities[indexA] = new SolverVelocity { V = Vector2F.Zero, W = -20.0f };
            velocities[indexB] = new SolverVelocity { V = Vector2F.Zero, W = 20.0f };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            MethodInfo initMethod = typeof(FrictionJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            FieldInfo angularImpulseField = typeof(FrictionJoint).GetField("_angularImpulse", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo invIaField = typeof(FrictionJoint).GetField("invIa", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo invIbField = typeof(FrictionJoint).GetField("invIb", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo angularMassField = typeof(FrictionJoint).GetField("_angularMass", BindingFlags.NonPublic | BindingFlags.Instance);

            MethodInfo solveMethod = typeof(FrictionJoint).GetMethod("SolveVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            solveMethod.Invoke(joint, new object[] { data });

            float angularImpulse = (float)angularImpulseField.GetValue(joint);
            float maxImpulse = 0.016f * 5.0f;

            Assert.True(Math.Abs(angularImpulse) <= maxImpulse + 1e-6f);
        }

        /// <summary>
        /// Tests that solve linear friction with excess force clamps linear impulse
        /// </summary>
        [Fact]
        public void SolveLinearFriction_WithExcessForce_ClampsLinearImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);
            joint.MaxForce = 0.1f;
            world.Add(joint);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
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

            velocities[indexA] = new SolverVelocity { V = new Vector2F(-50, 0), W = 0.0f };
            velocities[indexB] = new SolverVelocity { V = new Vector2F(50, 0), W = 0.0f };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            MethodInfo initMethod = typeof(FrictionJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            MethodInfo solveMethod = typeof(FrictionJoint).GetMethod("SolveVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            solveMethod.Invoke(joint, new object[] { data });

            FieldInfo linearImpulseField = typeof(FrictionJoint).GetField("_linearImpulse", BindingFlags.NonPublic | BindingFlags.Instance);
            Vector2F linearImpulse = (Vector2F)linearImpulseField.GetValue(joint);

            float maxImpulse = 0.016f * 0.1f;
            Assert.True(linearImpulse.LengthSquared() <= maxImpulse * maxImpulse + 1e-6f);
        }

        /// <summary>
        /// Tests that solve velocity constraints with max force and torque zero does not modify velocity
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithMaxForceAndTorqueZero_DoesNotModifyVelocity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);
            joint.MaxForce = 0.0f;
            joint.MaxTorque = 0.0f;
            world.Add(joint);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
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

            velocities[indexA] = new SolverVelocity { V = new Vector2F(10, 0), W = 5.0f };
            velocities[indexB] = new SolverVelocity { V = new Vector2F(-5, 0), W = -3.0f };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = positions,
                Velocities = velocities,
                Locks = new int[maxIndex]
            };

            MethodInfo initMethod = typeof(FrictionJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            FieldInfo angularImpulseField = typeof(FrictionJoint).GetField("_angularImpulse", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo linearImpulseField = typeof(FrictionJoint).GetField("_linearImpulse", BindingFlags.NonPublic | BindingFlags.Instance);

            MethodInfo solveMethod = typeof(FrictionJoint).GetMethod("SolveVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            solveMethod.Invoke(joint, new object[] { data });

            float angularImpulse = (float)angularImpulseField.GetValue(joint);
            Vector2F linearImpulse = (Vector2F)linearImpulseField.GetValue(joint);

            Assert.Equal(0.0f, angularImpulse, 5);
            Assert.Equal(Vector2F.Zero, linearImpulse);
        }
    }
}
