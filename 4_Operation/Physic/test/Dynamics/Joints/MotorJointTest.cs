// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MotorJointTest.cs
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
    /// The motor joint test class
    /// </summary>
    public class MotorJointTest
    {
        /// <summary>
        /// Tests that motor joint type should be accessible
        /// </summary>
        [Fact]
        public void MotorJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(MotorJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies should set joint type to motor
        /// </summary>
        [Fact]
        public void Constructor_WithBodies_ShouldSetJointTypeToMotor()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            Assert.Equal(JointType.Motor, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodies_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
        }

        /// <summary>
        /// Tests that max force should round trip
        /// </summary>
        [Fact]
        public void MaxForce_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            joint.MaxForce = 500.0f;

            Assert.Equal(500.0f, joint.MaxForce);
        }

        /// <summary>
        /// Tests that max torque should round trip
        /// </summary>
        [Fact]
        public void MaxTorque_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            joint.MaxTorque = 100.0f;

            Assert.Equal(100.0f, joint.MaxTorque);
        }

        /// <summary>
        /// Tests that get reaction force should return zero for default joint
        /// </summary>
        [Fact]
        public void GetReactionForce_ShouldReturnZeroForDefaultJoint()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            Vector2F force = joint.GetReactionForce(1.0f);

            Assert.Equal(Vector2F.Zero, force);
        }

        /// <summary>
        /// Tests that get reaction torque should return zero for default joint
        /// </summary>
        [Fact]
        public void GetReactionTorque_ShouldReturnZeroForDefaultJoint()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            float torque = joint.GetReactionTorque(1.0f);

            Assert.Equal(0.0f, torque);
        }

        /// <summary>
        /// Tests that linear offset should round trip
        /// </summary>
        [Fact]
        public void LinearOffset_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            Vector2F offset = new Vector2F(3.0f, 4.0f);
            joint.LinearOffset = offset;

            Assert.Equal(offset, joint.LinearOffset);
        }

        /// <summary>
        /// Tests that angular offset should round trip
        /// </summary>
        [Fact]
        public void AngularOffset_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            MotorJoint joint = new MotorJoint(bodyA, bodyB);

            joint.AngularOffset = 0.5f;

            Assert.Equal(0.5f, joint.AngularOffset);
        }
    }
}
