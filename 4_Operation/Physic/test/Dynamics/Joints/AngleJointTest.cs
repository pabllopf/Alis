// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AngleJointTest.cs
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

using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The angle joint test class
    /// </summary>
    public class AngleJointTest
    {
        /// <summary>
        /// Tests that angle joint type should be accessible
        /// </summary>
        [Fact]
        public void AngleJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(AngleJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies should set joint type to angle
        /// </summary>
        [Fact]
        public void Constructor_WithBodies_ShouldSetJointTypeToAngle()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();

            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Assert.Equal(JointType.Angle, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies should set bias factor to default
        /// </summary>
        [Fact]
        public void Constructor_WithBodies_ShouldSetBiasFactorToDefault()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();

            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Assert.Equal(0.2f, joint.BiasFactor);
        }

        /// <summary>
        /// Tests that constructor with bodies should set max impulse to max value
        /// </summary>
        [Fact]
        public void Constructor_WithBodies_ShouldSetMaxImpulseToMaxValue()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();

            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Assert.Equal(float.MaxValue, joint.MaxImpulse);
        }

        /// <summary>
        /// Tests that constructor with bodies should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodies_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();

            AngleJoint joint = new AngleJoint(bodyA, bodyB);

            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
        }
    }
}

