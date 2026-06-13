// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RevoluteJointTest.cs
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
    /// The revolute joint test class
    /// </summary>
    public class RevoluteJointTest
    {
        /// <summary>
        /// Tests that revolute joint type should be accessible
        /// </summary>
        [Fact]
        public void RevoluteJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(RevoluteJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies and anchor should set joint type to revolute
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchor_ShouldSetJointTypeToRevolute()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            Assert.Equal(JointType.Revolute, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies and anchor should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchor_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

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
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            Vector2F anchor = new Vector2F(1.0f, 2.0f);
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
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, Vector2F.Zero);

            Vector2F anchor = new Vector2F(3.0f, 4.0f);
            joint.LocalAnchorB = anchor;

            Assert.Equal(anchor, joint.LocalAnchorB);
        }
    }
}
