// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrictionJointTest.cs
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
    /// The friction joint test class
    /// </summary>
    public class FrictionJointTest
    {
        /// <summary>
        /// Tests that friction joint type should be accessible
        /// </summary>
        [Fact]
        public void FrictionJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(FrictionJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set joint type to friction
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetJointTypeToFriction()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

            Assert.Equal(JointType.Friction, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

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
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

            joint.MaxForce = 300.0f;

            Assert.Equal(300.0f, joint.MaxForce);
        }

        /// <summary>
        /// Tests that max torque should round trip
        /// </summary>
        [Fact]
        public void MaxTorque_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            FrictionJoint joint = new FrictionJoint(bodyA, bodyB, Vector2F.Zero);

            joint.MaxTorque = 50.0f;

            Assert.Equal(50.0f, joint.MaxTorque);
        }
    }
}
