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
        /// Tests that joint translation follows the configured axis.
        /// </summary>
        [Fact]
        public void PrismaticJoint_JointTranslation_TracksAxisDisplacement()
        {
            Body bodyA = new Body {GetBodyType = BodyType.Dynamic, Position = new Vector2F(0.0f, 0.0f)};
            Body bodyB = new Body {GetBodyType = BodyType.Dynamic, Position = new Vector2F(5.0f, 0.0f)};

            PrismaticJoint joint = new PrismaticJoint(
                bodyA,
                bodyB,
                new Vector2F(0.0f, 0.0f),
                new Vector2F(1.0f, 0.0f));

            Assert.Equal(5.0f, joint.JointTranslation, 5);
        }

        /// <summary>
        /// Tests that the joint speed matches linear velocity projected onto the axis.
        /// </summary>
        [Fact]
        public void PrismaticJoint_JointSpeed_UsesRelativeAxisVelocity()
        {
            Body bodyA = new Body {GetBodyType = BodyType.Dynamic, Position = new Vector2F(0.0f, 0.0f)};
            Body bodyB = new Body {GetBodyType = BodyType.Dynamic, Position = new Vector2F(2.0f, 0.0f)};

            PrismaticJoint joint = new PrismaticJoint(
                bodyA,
                bodyB,
                new Vector2F(0.0f, 0.0f),
                new Vector2F(1.0f, 0.0f));

            bodyA.LinearVelocity = new Vector2F(1.0f, 0.0f);
            bodyB.LinearVelocity = new Vector2F(3.0f, 0.0f);

            Assert.Equal(2.0f, joint.JointSpeed, 5);
        }

        /// <summary>
        /// Tests that the axis is normalized and stored in local coordinates.
        /// </summary>
        [Fact]
        public void PrismaticJoint_Axis1_NormalizesLocalAxis()
        {
            Body bodyA = new Body {GetBodyType = BodyType.Dynamic};
            Body bodyB = new Body {GetBodyType = BodyType.Dynamic};

            PrismaticJoint joint = new PrismaticJoint(
                bodyA,
                bodyB,
                new Vector2F(0.0f, 0.0f),
                new Vector2F(2.0f, 0.0f));

            Assert.Equal(1.0f, joint.LocalXAxis.X, 5);
            Assert.Equal(0.0f, joint.LocalXAxis.Y, 5);
        }
    }
}
