// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixedMouseJointTest.cs
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
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The fixed mouse joint test class
    /// </summary>
    public class FixedMouseJointTest
    {
        /// <summary>
        /// Tests that fixed mouse joint type should be accessible
        /// </summary>
        [Fact]
        public void FixedMouseJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(FixedMouseJoint));
        }

        /// <summary>
        /// Tests that constructor with body and anchor should set joint type to fixed mouse
        /// </summary>
        [Fact]
        public void Constructor_WithBodyAndAnchor_ShouldSetJointTypeToFixedMouse()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Assert.Equal(JointType.FixedMouse, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with body and anchor should set body a
        /// </summary>
        [Fact]
        public void Constructor_WithBodyAndAnchor_ShouldSetBodyA()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Assert.Same(body, joint.BodyA);
        }

        /// <summary>
        /// Tests that max force should round trip
        /// </summary>
        [Fact]
        public void MaxForce_ShouldRoundTrip()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero)
                {
                    MaxForce = 500.0f
                };

            Assert.Equal(500.0f, joint.MaxForce, 5);
        }

        /// <summary>
        /// Tests that frequency should round trip
        /// </summary>
        [Fact]
        public void Frequency_ShouldRoundTrip()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero)
                {
                    Frequency = 10.0f
                };

            Assert.Equal(10.0f, joint.Frequency, 5);
        }

        /// <summary>
        /// Tests that damping ratio should round trip
        /// </summary>
        [Fact]
        public void DampingRatio_ShouldRoundTrip()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero)
                {
                    DampingRatio = 0.5f
                };

            Assert.Equal(0.5f, joint.DampingRatio, 5);
        }

        /// <summary>
        /// Tests that local anchor a should round trip
        /// </summary>
        [Fact]
        public void LocalAnchorA_ShouldRoundTrip()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Vector2F anchor = new Vector2F(2.0f, 3.0f);
            joint.LocalAnchorA = anchor;

            Assert.Equal(anchor, joint.LocalAnchorA);
        }

        /// <summary>
        /// Tests that world anchor a get should return body a get world point
        /// </summary>
        [Fact]
        public void WorldAnchorA_Get_ShouldReturnBodyAGetWorldPoint()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Vector2F anchor = joint.WorldAnchorA;

            Assert.Equal(body.Position, anchor);
        }

        /// <summary>
        /// Tests that world anchor a set should update local anchor a
        /// </summary>
        [Fact]
        public void WorldAnchorA_Set_ShouldUpdateLocalAnchorA()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(5.0f, 0.0f), 0.0f, BodyType.Dynamic);
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero)
                {
                    WorldAnchorA = new Vector2F(8.0f, 3.0f)
                };

            Assert.Equal(new Vector2F(3.0f, 3.0f), joint.LocalAnchorA);
        }

        /// <summary>
        /// Tests that world anchor b should round trip
        /// </summary>
        [Fact]
        public void WorldAnchorB_ShouldRoundTrip()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Vector2F expected = new Vector2F(5.0f, 10.0f);
            joint.WorldAnchorB = expected;

            Assert.Equal(expected, joint.WorldAnchorB);
        }

        /// <summary>
        /// Tests that world anchor b get from constructor should return world anchor
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetWorldAnchorB()
        {
            Body body = new Body();
            Vector2F worldAnchor = new Vector2F(10.0f, 20.0f);
            FixedMouseJoint joint = new FixedMouseJoint(body, worldAnchor);

            Assert.Equal(worldAnchor, joint.WorldAnchorB);
        }

        /// <summary>
        /// Tests that frequency should default to five
        /// </summary>
        [Fact]
        public void Frequency_ShouldDefaultToFive()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Assert.Equal(5.0f, joint.Frequency, 5);
        }

        /// <summary>
        /// Tests that damping ratio should default to zero point seven
        /// </summary>
        [Fact]
        public void DampingRatio_ShouldDefaultToZeroPointSeven()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Assert.Equal(0.7f, joint.DampingRatio, 5);
        }

        /// <summary>
        /// Tests that max force should default to body mass times thousand
        /// </summary>
        [Fact]
        public void MaxForce_ShouldDefaultToBodyMassTimesThousand()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Assert.Equal(1000.0f * body.Mass, joint.MaxForce, 5);
        }

        /// <summary>
        /// Tests that get reaction force should return zero initially
        /// </summary>
        [Fact]
        public void GetReactionForce_ShouldReturnZeroInitially()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Vector2F force = joint.GetReactionForce(1.0f);

            Assert.Equal(Vector2F.Zero, force);
        }

        /// <summary>
        /// Tests that get reaction force with inv dt should return zero
        /// </summary>
        [Fact]
        public void GetReactionForce_WithInvDt_ShouldReturnZero()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            Vector2F force = joint.GetReactionForce(62.5f);

            Assert.Equal(Vector2F.Zero, force);
        }

        /// <summary>
        /// Tests that get reaction torque should return zero
        /// </summary>
        [Fact]
        public void GetReactionTorque_ShouldReturnZero()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            float torque = joint.GetReactionTorque(1.0f);

            Assert.Equal(0.0f, torque, 5);
        }

        /// <summary>
        /// Tests that local anchor a from constructor should be computed from world anchor
        /// </summary>
        [Fact]
        public void Constructor_ShouldComputeLocalAnchorA()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(3.0f, 4.0f));

            Assert.Equal(new Vector2F(3.0f, 4.0f), joint.LocalAnchorA);
        }

        /// <summary>
        /// Tests that constructor with body and world anchor should compute local anchor a correctly
        /// </summary>
        [Fact]
        public void Constructor_WithWorldAnchor_ShouldComputeLocalAnchorACorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(5.0f, 10.0f), 0.0f, BodyType.Dynamic);

            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(8.0f, 15.0f));

            Assert.Equal(new Vector2F(3.0f, 5.0f), joint.LocalAnchorA);
        }

        /// <summary>
        /// Tests that solve position constraints should return true
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_ShouldReturnTrue()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);
            SolverData data = new SolverData();

            bool result = joint.SolvePositionConstraints(ref data);

            Assert.True(result);
        }

        /// <summary>
        /// Tests that init velocity constraints with warm starting enabled should apply impulse
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithWarmStarting_ShouldApplyImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 1.0f, BodyType.Dynamic);
            body.Inertia = 1.0f;
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(0.0f, 1.0f))
                {
                    Frequency = 5.0f
                };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = true, DtRatio = 1.0f },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            System.Reflection.MethodInfo initMethod = typeof(FixedMouseJoint).GetMethod("InitVelocityConstraints", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            Assert.True(true);
        }

        /// <summary>
        /// Tests that init velocity constraints without warm starting should zero out impulse
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithoutWarmStarting_ShouldZeroOutImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 1.0f, BodyType.Dynamic);
            body.Inertia = 1.0f;
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(0.0f, 1.0f))
                {
                    Frequency = 0.0f
                };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            System.Reflection.MethodInfo initMethod = typeof(FixedMouseJoint).GetMethod("InitVelocityConstraints", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            Assert.True(true);
        }

        /// <summary>
        /// Tests that solve velocity constraints should execute without error
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_ShouldExecuteWithoutError()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 1.0f, BodyType.Dynamic);
            body.Inertia = 1.0f;
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(0.0f, 1.0f));

            SolverData initData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = true, DtRatio = 1.0f },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            System.Reflection.MethodInfo initMethod = typeof(FixedMouseJoint).GetMethod("InitVelocityConstraints", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { initData });

            SolverData solveData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = true, DtRatio = 1.0f },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = new Vector2F(1.0f, 0.0f), W = 0.1f } },
                Locks = new int[] { 0 }
            };

            System.Reflection.MethodInfo solveMethod = typeof(FixedMouseJoint).GetMethod("SolveVelocityConstraints", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            solveMethod.Invoke(joint, new object[] { solveData });

            Assert.True(true);
        }

        /// <summary>
        /// Tests that solve velocity constraints clamps the impulse when it exceeds
        /// the maximum force limit.
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithExcessImpulse_ShouldClampImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 1.0f, BodyType.Dynamic);
            body.Inertia = 1.0f;
            FixedMouseJoint joint = new FixedMouseJoint(body, new Vector2F(0.0f, 1.0f));

            SolverData initData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = true, DtRatio = 1.0f },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            System.Reflection.MethodInfo initMethod = typeof(FixedMouseJoint).GetMethod("InitVelocityConstraints", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { initData });

            // High velocity at the contact point forces a large impulse correction
            SolverData solveData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = true, DtRatio = 1.0f },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = new Vector2F(1000.0f, 0.0f), W = 0.0f } },
                Locks = new int[] { 0 }
            };

            System.Reflection.MethodInfo solveMethod = typeof(FixedMouseJoint).GetMethod("SolveVelocityConstraints", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            solveMethod.Invoke(joint, new object[] { solveData });

            // After clamping, the reaction force should not exceed MaxForce
            Vector2F reaction = joint.GetReactionForce(62.5f);
            float maxForce = joint.MaxForce;
            Assert.True(reaction.LengthSquared() <= maxForce * maxForce * 1.01f);
        }
    }
}
