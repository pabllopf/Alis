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
    }
}
