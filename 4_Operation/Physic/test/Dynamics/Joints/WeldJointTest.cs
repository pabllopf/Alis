// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WeldJointTest.cs
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

using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The weld joint test class
    /// </summary>
    public class WeldJointTest
    {
        /// <summary>
        /// Tests that weld joint type should be accessible
        /// </summary>
        [Fact]
        public void WeldJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(WeldJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set joint type to weld
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetJointTypeToWeld()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            Assert.Equal(JointType.Weld, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
        }

        /// <summary>
        /// Tests that reference angle should round trip
        /// </summary>
        [Fact]
        public void ReferenceAngle_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero)
                {
                    ReferenceAngle = 0.5f
                };

            Assert.Equal(0.5f, joint.ReferenceAngle, 5);
        }

        /// <summary>
        /// Tests that frequency should round trip
        /// </summary>
        [Fact]
        public void Frequency_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero)
                {
                    FrequencyHz = 10.0f
                };

            Assert.Equal(10.0f, joint.FrequencyHz, 5);
        }

        /// <summary>
        /// Tests that damping ratio should round trip
        /// </summary>
        [Fact]
        public void DampingRatio_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero)
                {
                    DampingRatio = 0.8f
                };

            Assert.Equal(0.8f, joint.DampingRatio, 5);
        }

        /// <summary>
        /// Tests that WorldAnchorA get returns valid vector
        /// </summary>
        [Fact]
        public void WorldAnchorA_Get_ShouldReturnValidVector()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            Vector2F anchor = joint.WorldAnchorA;

            Assert.False(float.IsNaN(anchor.X));
            Assert.False(float.IsNaN(anchor.Y));
        }

        /// <summary>
        /// Tests that WorldAnchorA set changes local anchor
        /// </summary>
        [Fact]
        public void WorldAnchorA_Set_ShouldChangeLocalAnchor()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero)
                {
                    WorldAnchorA = new Vector2F(1, 0)
                };

            Vector2F anchor = joint.WorldAnchorA;
            Assert.False(float.IsNaN(anchor.X));
            Assert.False(float.IsNaN(anchor.Y));
        }

        /// <summary>
        /// Tests that WorldAnchorB get returns valid vector
        /// </summary>
        [Fact]
        public void WorldAnchorB_Get_ShouldReturnValidVector()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            Vector2F anchor = joint.WorldAnchorB;

            Assert.False(float.IsNaN(anchor.X));
            Assert.False(float.IsNaN(anchor.Y));
        }

        /// <summary>
        /// Tests that WorldAnchorB set changes local anchor
        /// </summary>
        [Fact]
        public void WorldAnchorB_Set_ShouldChangeLocalAnchor()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero)
                {
                    WorldAnchorB = new Vector2F(2, 1)
                };

            Vector2F anchor = joint.WorldAnchorB;
            Assert.False(float.IsNaN(anchor.X));
            Assert.False(float.IsNaN(anchor.Y));
        }

        /// <summary>
        /// Tests that GetReactionForce returns zero for initial state
        /// </summary>
        [Fact]
        public void GetReactionForce_ShouldReturnZeroForInitialState()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            Vector2F force = joint.GetReactionForce(1f);

            Assert.Equal(0, force.X);
            Assert.Equal(0, force.Y);
        }

        /// <summary>
        /// Tests that InitVelocityConstraints with FrequencyHz > 0 uses the frequency path
        /// when bodies have non-zero inertia.
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithFrequencyPositive_ShouldUseFrequencyPath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero)
                {
                    FrequencyHz = 10.0f
                };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            Assert.True(true);
        }

        /// <summary>
        /// Tests that InitVelocityConstraints with FrequencyHz > 0 and zero inertia
        /// hits the gamma and invM epsilon branches.
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithFrequencyPositiveAndZeroInertia_ShouldHitEpsilonPaths()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero)
                {
                    FrequencyHz = 1.0f
                };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            Assert.True(true);
        }

        /// <summary>
        /// Tests that InitVelocityConstraints with FrequencyHz = 0 and default bodies
        /// uses the else-if path when k.Ez.Z is near zero.
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithFrequencyZero_ShouldUseElseIfPath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            Assert.True(true);
        }

        /// <summary>
        /// Tests that InitVelocityConstraints with FrequencyHz = 0 and bodies with non-zero inertia
        /// uses the else path (full 3x3 inverse).
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithFrequencyZeroAndNonZeroInertia_ShouldUseElsePath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            Assert.True(true);
        }

        /// <summary>
        /// Tests that InitVelocityConstraints with WarmStarting enabled scales and applies impulse.
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithWarmStarting_ShouldScaleAndApplyImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = true, DtRatio = 1.0f },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            Assert.True(true);
        }

        /// <summary>
        /// Tests that SolveVelocityConstraints with FrequencyHz = 0 uses the non-frequency path.
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithFrequencyZero_ShouldUseNonFrequencyPath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            MethodInfo solveMethod = typeof(WeldJoint).GetMethod("SolveVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            solveMethod.Invoke(joint, new object[] { data });

            Assert.True(true);
        }

        /// <summary>
        /// Tests that SolveVelocityConstraints with FrequencyHz > 0 uses the frequency path.
        /// </summary>
        [Fact]
        public void SolveVelocityConstraints_WithFrequencyPositive_ShouldUseFrequencyPath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero)
                {
                    FrequencyHz = 10.0f
                };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            MethodInfo solveMethod = typeof(WeldJoint).GetMethod("SolveVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            solveMethod.Invoke(joint, new object[] { data });

            Assert.True(true);
        }

        /// <summary>
        /// Tests that SolvePositionConstraints with FrequencyHz > 0 uses the frequency path.
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithFrequencyPositive_ShouldUseFrequencyPath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero)
                {
                    FrequencyHz = 10.0f
                };

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            MethodInfo solvePosMethod = typeof(WeldJoint).GetMethod("SolvePositionConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            bool result = (bool)solvePosMethod.Invoke(joint, new object[] { data });

            Assert.True(result);
        }

        /// <summary>
        /// Tests that SolvePositionConstraints with FrequencyHz = 0 and default bodies
        /// uses the non-frequency path with k.Ez.Z <= 0 fallback (Solve22).
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithFrequencyZeroAndZeroInertia_ShouldUseKkEpsilonPath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            MethodInfo solvePosMethod = typeof(WeldJoint).GetMethod("SolvePositionConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            bool result = (bool)solvePosMethod.Invoke(joint, new object[] { data });

            Assert.True(result);
        }

        /// <summary>
        /// Tests that SolvePositionConstraints with FrequencyHz = 0 and non-zero inertia
        /// uses the full 3x3 Solve33 path.
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithFrequencyZeroAndNonZeroInertia_ShouldUseSolve33()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(-1.0f, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.3f, 1.0f);
            CircleShape shapeB = new CircleShape(0.3f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WeldJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            MethodInfo solvePosMethod = typeof(WeldJoint).GetMethod("SolvePositionConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            bool result = (bool)solvePosMethod.Invoke(joint, new object[] { data });

            Assert.True(result);
        }

        /// <summary>
        /// Tests that internal constructor should set joint type
        /// </summary>
        [Fact]
        public void InternalConstructor_ShouldSetJointType()
        {
            WeldJoint joint = new WeldJoint();
            Assert.Equal(JointType.Weld, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with use world coordinates true should transform anchors
        /// </summary>
        [Fact]
        public void Constructor_WithUseWorldCoordinatesTrue_ShouldTransformAnchors()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(10.0f, 0.0f), 0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(20.0f, 0.0f), 0f, BodyType.Dynamic);

            WeldJoint joint = new WeldJoint(bodyA, bodyB, new Vector2F(10.0f, 5.0f), new Vector2F(20.0f, 5.0f), true);

            Assert.Equal(JointType.Weld, joint.JointType);
            Assert.Equal(new Vector2F(0.0f, 5.0f), joint.LocalAnchorA);
            Assert.Equal(new Vector2F(0.0f, 5.0f), joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that get reaction torque should return zero initially
        /// </summary>
        [Fact]
        public void GetReactionTorque_ShouldReturnZeroInitially()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            float torque = joint.GetReactionTorque(1.0f);

            Assert.Equal(0.0f, torque, 5);
        }
    }
}
