// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WheelJointTest.cs
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
    /// The wheel joint test class
    /// </summary>
    public class WheelJointTest
    {
        /// <summary>
        /// Tests that wheel joint type should be accessible
        /// </summary>
        [Fact]
        public void WheelJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(WheelJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies anchor and axis should set joint type to wheel
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAnchorAndAxis_ShouldSetJointTypeToWheel()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            Assert.Equal(JointType.Wheel, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies anchor and axis should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAnchorAndAxis_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
        }

        /// <summary>
        /// Tests that motor speed should round trip
        /// </summary>
        [Fact]
        public void MotorSpeed_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            joint.MotorSpeed = 10.0f;

            Assert.Equal(10.0f, joint.MotorSpeed);
        }

        /// <summary>
        /// Tests that max motor torque should round trip
        /// </summary>
        [Fact]
        public void MaxMotorTorque_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            joint.MaxMotorTorque = 200.0f;

            Assert.Equal(200.0f, joint.MaxMotorTorque);
        }

        /// <summary>
        /// Tests that frequency should round trip
        /// </summary>
        [Fact]
        public void Frequency_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            joint.Frequency = 5.0f;

            Assert.Equal(5.0f, joint.Frequency);
        }

        /// <summary>
        /// Tests that damping ratio should round trip
        /// </summary>
        [Fact]
        public void DampingRatio_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            joint.DampingRatio = 0.3f;

            Assert.Equal(0.3f, joint.DampingRatio);
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
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

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
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            joint.WorldAnchorA = new Vector2F(1, 0);

            Assert.Equal(new Vector2F(1, 0), joint.WorldAnchorA);
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
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

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
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            joint.WorldAnchorB = new Vector2F(2, 1);

            Assert.Equal(new Vector2F(2, 1), joint.WorldAnchorB);
        }

        /// <summary>
        /// Tests that Axis set updates the axis and local X axis
        /// </summary>
        [Fact]
        public void Axis_Set_ShouldUpdateAxis()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            joint.Axis = new Vector2F(1.0f, 0.0f);

            Assert.Equal(new Vector2F(1, 0), joint.Axis);
        }

        /// <summary>
        /// Tests that LocalXAxis returns the local X axis after axis is set
        /// </summary>
        [Fact]
        public void LocalXAxis_ShouldReturnLocalXAxis()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            Vector2F localX = joint.LocalXAxis;

            Assert.False(float.IsNaN(localX.X));
            Assert.False(float.IsNaN(localX.Y));
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
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            Vector2F force = joint.GetReactionForce(1f);

            Assert.Equal(0, force.X);
            Assert.Equal(0, force.Y);
        }

        /// <summary>
        /// Tests that MotorEnabled should round trip
        /// </summary>
        [Fact]
        public void MotorEnabled_ShouldRoundTrip()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WheelJoint joint = new WheelJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(0.0f, 1.0f));

            joint.MotorEnabled = true;
            Assert.True(joint.MotorEnabled);

            joint.MotorEnabled = false;
            Assert.False(joint.MotorEnabled);
        }
    }
}
