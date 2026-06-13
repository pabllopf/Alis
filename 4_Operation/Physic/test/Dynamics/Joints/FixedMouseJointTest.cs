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
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            joint.MaxForce = 500.0f;

            Assert.Equal(500.0f, joint.MaxForce);
        }

        /// <summary>
        /// Tests that frequency should round trip
        /// </summary>
        [Fact]
        public void Frequency_ShouldRoundTrip()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            joint.Frequency = 10.0f;

            Assert.Equal(10.0f, joint.Frequency);
        }

        /// <summary>
        /// Tests that damping ratio should round trip
        /// </summary>
        [Fact]
        public void DampingRatio_ShouldRoundTrip()
        {
            Body body = new Body();
            FixedMouseJoint joint = new FixedMouseJoint(body, Vector2F.Zero);

            joint.DampingRatio = 0.5f;

            Assert.Equal(0.5f, joint.DampingRatio);
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
    }
}
