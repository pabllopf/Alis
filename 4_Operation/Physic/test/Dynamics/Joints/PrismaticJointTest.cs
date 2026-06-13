// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PrismaticJointTest.cs
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
    /// The prismatic joint test class
    /// </summary>
    public class PrismaticJointTest
    {
        /// <summary>
        /// Tests that prismatic joint type should be accessible
        /// </summary>
        [Fact]
        public void PrismaticJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(PrismaticJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies anchor and axis should set joint type to prismatic
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAnchorAndAxis_ShouldSetJointTypeToPrismatic()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            Assert.Equal(JointType.Prismatic, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies anchor and axis should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAnchorAndAxis_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
        }

        /// <summary>
        /// Tests that local anchor a should round trip
        /// </summary>
        [Fact]
        public void LocalAnchorA_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            Vector2F anchor = new Vector2F(2.0f, 3.0f);
            joint.LocalAnchorA = anchor;

            Assert.Equal(anchor, joint.LocalAnchorA);
        }

        /// <summary>
        /// Tests that local anchor b should round trip
        /// </summary>
        [Fact]
        public void LocalAnchorB_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            Vector2F anchor = new Vector2F(4.0f, 5.0f);
            joint.LocalAnchorB = anchor;

            Assert.Equal(anchor, joint.LocalAnchorB);
        }

        /// <summary>
        /// Tests that motor impulse should round trip
        /// </summary>
        [Fact]
        public void MotorImpulse_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            joint.MotorImpulse = 2.5f;

            Assert.Equal(2.5f, joint.MotorImpulse);
        }

        /// <summary>
        /// Tests that reference angle should round trip
        /// </summary>
        [Fact]
        public void ReferenceAngle_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(1.0f, 0.0f));

            joint.ReferenceAngle = 0.3f;

            Assert.Equal(0.3f, joint.ReferenceAngle);
        }
    }
}
