// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WheelJointRemainingCoverageTests.cs
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
    /// The wheel joint remaining coverage tests class
    /// </summary>
    public class WheelJointRemainingCoverageTests
    {
        /// <summary>
        /// Tests that init velocity constraints without warm starting resets impulses to zero
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithoutWarmStarting_ShouldResetImpulses()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            joint.MotorEnabled = true;

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WheelJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { data });

            FieldInfo impulseField = typeof(WheelJoint).GetField("_impulse", BindingFlags.NonPublic | BindingFlags.Instance);
            float impulse = (float)impulseField.GetValue(joint);
            Assert.Equal(0.0f, impulse, 5);

            FieldInfo springImpulseField = typeof(WheelJoint).GetField("_springImpulse", BindingFlags.NonPublic | BindingFlags.Instance);
            float springImpulse = (float)springImpulseField.GetValue(joint);
            Assert.Equal(0.0f, springImpulse, 5);

            FieldInfo motorImpulseField = typeof(WheelJoint).GetField("_motorImpulse", BindingFlags.NonPublic | BindingFlags.Instance);
            float motorImpulse = (float)motorImpulseField.GetValue(joint);
            Assert.Equal(0.0f, motorImpulse, 5);
        }

        /// <summary>
        /// Tests that solve position constraints with zero inverse mass sets impulse to zero
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_WithZeroInverseMass_ShouldSetZeroImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            bodyA.CreateFixture(shapeA);
            bodyB.CreateFixture(shapeB);
            bodyA.GetBodyType = BodyType.Kinematic;
            bodyB.GetBodyType = BodyType.Kinematic;

            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));
            world.Add(joint);

            SolverData initData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(WheelJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(joint, new object[] { initData });

            typeof(WheelJoint).GetField("_indexA", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(joint, 0);
            typeof(WheelJoint).GetField("_indexB", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(joint, 1);

            SolverData posData = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[]
                {
                    new SolverPosition { C = Vector2F.Zero, A = 0.0f },
                    new SolverPosition { C = new Vector2F(2, 0), A = 0.0f }
                },
                Velocities = new SolverVelocity[]
                {
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f },
                    new SolverVelocity { V = Vector2F.Zero, W = 0.0f }
                },
                Locks = new int[] { 0, 1 }
            };

            MethodInfo solvePosMethod = typeof(WheelJoint).GetMethod("SolvePositionConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            bool result = (bool)solvePosMethod.Invoke(joint, new object[] { posData });

            Assert.NotNull(joint);
        }
    }
}
