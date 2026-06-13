// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceJointTest.cs
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
    /// The distance joint test class
    /// </summary>
    public class DistanceJointTest
    {
        /// <summary>
        /// Tests that distance joint type should be accessible
        /// </summary>
        [Fact]
        public void DistanceJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(DistanceJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set joint type to distance
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetJointTypeToDistance()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Assert.Equal(JointType.Distance, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
        }

        /// <summary>
        /// Tests that get reaction torque should return zero
        /// </summary>
        [Fact]
        public void GetReactionTorque_ShouldReturnZero()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            float torque = joint.GetReactionTorque(1.0f);

            Assert.Equal(0.0f, torque);
        }

        /// <summary>
        /// Tests that frequency should round trip
        /// </summary>
        [Fact]
        public void Frequency_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

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
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            joint.DampingRatio = 0.5f;

            Assert.Equal(0.5f, joint.DampingRatio);
        }

        /// <summary>
        /// Tests that length should round trip
        /// </summary>
        [Fact]
        public void Length_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2.0f, 0.0f));

            joint.Length = 3.0f;

            Assert.Equal(3.0f, joint.Length);
        }
    }
}
