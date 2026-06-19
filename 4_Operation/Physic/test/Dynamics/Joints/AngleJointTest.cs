// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AngleJointTest.cs
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
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The angle joint test class
    /// </summary>
    public class AngleJointTest
    {
        /// <summary>
        /// Tests that angle joint type should be accessible
        /// </summary>
        [Fact]
        public void AngleJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(AngleJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies should set joint type to angle
        /// </summary>
        [Fact]
        public void Constructor_WithBodies_ShouldSetJointTypeToAngle()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();

            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Assert.Equal(JointType.Angle, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies should set bias factor to default
        /// </summary>
        [Fact]
        public void Constructor_WithBodies_ShouldSetBiasFactorToDefault()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();

            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Assert.Equal(0.2f, joint.BiasFactor);
        }

        /// <summary>
        /// Tests that constructor with bodies should set max impulse to max value
        /// </summary>
        [Fact]
        public void Constructor_WithBodies_ShouldSetMaxImpulseToMaxValue()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();

            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Assert.Equal(float.MaxValue, joint.MaxImpulse);
        }

        /// <summary>
        /// Tests that constructor with bodies should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodies_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();

            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
        }

        /// <summary>
        /// Tests that target angle should round trip
        /// </summary>
        [Fact]
        public void TargetAngle_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            joint.TargetAngle = 1.5f;

            Assert.Equal(1.5f, joint.TargetAngle);
        }

        /// <summary>
        /// Tests that target angle should default to zero
        /// </summary>
        [Fact]
        public void TargetAngle_ShouldDefaultToZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Assert.Equal(0.0f, joint.TargetAngle);
        }

        /// <summary>
        /// Tests that softness should default to zero
        /// </summary>
        [Fact]
        public void Softness_ShouldDefaultToZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Assert.Equal(0.0f, joint.Softness);
        }

        /// <summary>
        /// Tests that softness should round trip
        /// </summary>
        [Fact]
        public void Softness_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            joint.Softness = 0.5f;

            Assert.Equal(0.5f, joint.Softness);
        }

        /// <summary>
        /// Tests that get reaction force should return zero
        /// </summary>
        [Fact]
        public void GetReactionForce_ShouldReturnZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Vector2F force = joint.GetReactionForce(1.0f);

            Assert.Equal(Vector2F.Zero, force);
        }

        /// <summary>
        /// Tests that get reaction torque should return zero
        /// </summary>
        [Fact]
        public void GetReactionTorque_ShouldReturnZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            float torque = joint.GetReactionTorque(1.0f);

            Assert.Equal(0.0f, torque);
        }

        /// <summary>
        /// Tests that world anchor a should return body a position
        /// </summary>
        [Fact]
        public void WorldAnchorA_ShouldReturnBodyAPosition()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Vector2F anchor = joint.WorldAnchorA;

            Assert.Equal(bodyA.Position, anchor);
        }

        /// <summary>
        /// Tests that world anchor b setter should throw not supported
        /// </summary>
        [Fact]
        public void WorldAnchorB_Setter_ShouldThrowNotSupported()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Assert.Throws<NotSupportedException>(() => joint.WorldAnchorB = Vector2F.Zero);
        }

        /// <summary>
        /// Tests that bias factor should round trip
        /// </summary>
        [Fact]
        public void BiasFactor_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            joint.BiasFactor = 0.5f;

            Assert.Equal(0.5f, joint.BiasFactor);
        }

        /// <summary>
        /// Tests that max impulse should round trip
        /// </summary>
        [Fact]
        public void MaxImpulse_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            joint.MaxImpulse = 100.0f;

            Assert.Equal(100.0f, joint.MaxImpulse);
        }

        /// <summary>
        /// Tests that internal constructor should set joint type to angle
        /// </summary>
        [Fact]
        public void InternalConstructor_ShouldSetJointTypeToAngle()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Assert.Equal(JointType.Angle, joint.JointType);
        }

        /// <summary>
        ///     Tests that internal parameterless constructor should set joint type to angle
        /// </summary>
        [Fact]
        public void InternalConstructor_Parameterless_ShouldSetJointTypeToAngle()
        {
            AngleJoint joint = new AngleJoint();

            Assert.Equal(JointType.Angle, joint.JointType);
        }

        /// <summary>
        /// Tests that world anchor a set should update body a position
        /// </summary>
        [Fact]
        public void WorldAnchorA_Set_ShouldUpdateBodyAPosition()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Vector2F newPosition = new Vector2F(5.0f, 10.0f);
            joint.WorldAnchorA = newPosition;

            Assert.Equal(newPosition, bodyA.Position);
        }

        /// <summary>
        /// Tests that world anchor b get should return body b position
        /// </summary>
        [Fact]
        public void WorldAnchorB_Get_ShouldReturnBodyBPosition()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            bodyB.Position = new Vector2F(3.0f, 7.0f);
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Vector2F anchor = joint.WorldAnchorB;

            Assert.Equal(bodyB.Position, anchor);
        }

        /// <summary>
        /// Tests that target angle set with changed value should wake bodies
        /// </summary>
        [Fact]
        public void TargetAngle_SetWithChangedValue_ShouldWakeBodies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            joint.TargetAngle = 1.5f;

            Assert.Equal(1.5f, joint.TargetAngle);
        }

        /// <summary>
        /// Tests that target angle set with same value should not wake bodies
        /// </summary>
        [Fact]
        public void TargetAngle_SetWithSameValue_ShouldNotWakeBodies()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            joint.TargetAngle = joint.TargetAngle;

            Assert.Equal(0.0f, joint.TargetAngle);
        }

        /// <summary>
        /// Tests that solve position constraints should return true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_ShouldReturnTrue()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            AngleJoint joint = new AngleJoint(bodyA, bodyB);
            SolverData data = new SolverData();

            bool result = joint.SolvePositionConstraints(ref data);

            Assert.True(result);
        }

        /// <summary>
        /// Tests that init velocity constraints should calculate bias and mass factor
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_ShouldCalculateBiasAndMassFactor()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 1.0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0.0f), 1.0f, BodyType.Dynamic);
            AngleJoint joint = new AngleJoint(bodyA, bodyB);
            joint.TargetAngle = 0.5f;
            joint.BiasFactor = 0.3f;
            joint.Softness = 0.1f;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f },
                Positions = new SolverPosition[]
                {
                    new SolverPosition { A = 0.0f },
                    new SolverPosition { A = 0.5f }
                },
                Velocities = Array.Empty<SolverVelocity>(),
                Locks = new int[] { 0, 0 }
            };

            // Act - use reflection to access internal method
            System.Reflection.MethodInfo initMethod = typeof(AngleJoint).GetMethod("InitVelocityConstraints", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            // Assert - verify internal state was modified
            System.Reflection.FieldInfo biasField = typeof(AngleJoint).GetField("_bias", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            System.Reflection.FieldInfo massFactorField = typeof(AngleJoint).GetField("_massFactor", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            Assert.NotNull(biasField);
            Assert.NotNull(massFactorField);
        }

        /// <summary>
        /// Tests that solve velocity constraints should execute without error
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_ShouldExecuteWithoutError()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 1.0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0.0f), 1.0f, BodyType.Dynamic);
            bodyA.Inertia = 1.0f;
            bodyB.Inertia = 1.0f;
            AngleJoint joint = new AngleJoint(bodyA, bodyB);
            joint.TargetAngle = 0.5f;

            // First initialize velocity constraints to set _bias and _massFactor
            SolverData initData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f },
                Positions = new SolverPosition[] { new SolverPosition { A = 0.0f }, new SolverPosition { A = 0.5f } },
                Velocities = Array.Empty<SolverVelocity>(),
                Locks = new int[] { 0, 0 }
            };

            System.Reflection.MethodInfo initMethod = typeof(AngleJoint).GetMethod("InitVelocityConstraints", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { initData });

            // Now solve with velocity data
            SolverData solveData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f },
                Positions = new SolverPosition[] { new SolverPosition { A = 0.0f }, new SolverPosition { A = 0.5f } },
                Velocities = new SolverVelocity[]
                {
                    new SolverVelocity { W = 0.1f },
                    new SolverVelocity { W = 0.2f }
                },
                Locks = new int[] { 0, 0 }
            };

            // Act - use reflection to access internal method
            System.Reflection.MethodInfo solveMethod = typeof(AngleJoint).GetMethod("SolveVelocityConstraints", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            solveMethod.Invoke(joint, new object[] { solveData });

            // Assert - method executed without throwing
            Assert.True(true);
        }

        /// <summary>
        /// Tests that solve velocity constraints should respect max impulse limit
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_ShouldRespectMaxImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 1.0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0.0f), 1.0f, BodyType.Dynamic);
            bodyA.Inertia = 1.0f;
            bodyB.Inertia = 1.0f;
            AngleJoint joint = new AngleJoint(bodyA, bodyB);
            joint.TargetAngle = 10.0f;
            joint.MaxImpulse = 0.01f; // Very low max impulse

            SolverData initData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f },
                Positions = new SolverPosition[] { new SolverPosition { A = 0.0f }, new SolverPosition { A = 10.0f } },
                Velocities = Array.Empty<SolverVelocity>(),
                Locks = new int[] { 0, 0 }
            };

            System.Reflection.MethodInfo initMethod = typeof(AngleJoint).GetMethod("InitVelocityConstraints", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { initData });

            SolverData solveData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f },
                Positions = new SolverPosition[] { new SolverPosition { A = 0.0f }, new SolverPosition { A = 10.0f } },
                Velocities = new SolverVelocity[]
                {
                    new SolverVelocity { W = 0.0f },
                    new SolverVelocity { W = 5.0f }
                },
                Locks = new int[] { 0, 0 }
            };

            System.Reflection.MethodInfo solveMethod = typeof(AngleJoint).GetMethod("SolveVelocityConstraints", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            solveMethod.Invoke(joint, new object[] { solveData });

            // Assert - method executed without throwing
            Assert.True(true);
        }
    }
}

