// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JointFactoryTest.cs
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
    /// The joint factory test class
    /// </summary>
    public class JointFactoryTest
    {
        /// <summary>
        /// Tests that create distance joint should add joint to world
        /// </summary>
        [Fact]
        public void CreateDistanceJoint_ShouldAddJointToWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.4f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.4f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            DistanceJoint joint = JointFactory.CreateDistanceJoint(world, bodyA, bodyB);

            Assert.NotNull(joint);
            Assert.Equal(1, world.JointList.Count);
            Assert.Equal(JointType.Distance, joint.JointType);
        }

        /// <summary>
        /// Tests that create revolute joint should return joint connected to bodies
        /// </summary>
        [Fact]
        public void CreateRevoluteJoint_ShouldReturnJointConnectedToBodies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body anchor = world.CreateCircle(0.2f, 0.0f, new Vector2F(0.0f, 1.0f), BodyType.Static);
            Body body = world.CreateCircle(0.5f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);

            RevoluteJoint joint = JointFactory.CreateRevoluteJoint(world, anchor, body, new Vector2F(0.0f, 1.0f));

            Assert.Equal(anchor, joint.BodyA);
            Assert.Equal(body, joint.BodyB);
            Assert.Equal(1, world.JointList.Count);
        }

        /// <summary>
        /// Tests that create wheel joint should use expected joint type
        /// </summary>
        [Fact]
        public void CreateWheelJoint_ShouldUseExpectedJointType()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateRectangle(1.0f, 1.0f, 1.0f, new Vector2F(-1.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateRectangle(1.0f, 1.0f, 1.0f, new Vector2F(1.0f, 0.0f), 0.0f, BodyType.Dynamic);

            WheelJoint joint = JointFactory.CreateWheelJoint(world, bodyA, bodyB, new Vector2F(0.0f, 1.0f));

            Assert.NotNull(joint);
            Assert.Equal(JointType.Wheel, joint.JointType);
        }

        /// <summary>
        /// Tests that create fixed mouse joint should add joint to world
        /// </summary>
        [Fact]
        public void CreateFixedMouseJoint_ShouldAddJointToWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(0.5f, 1.0f, new Vector2F(2.0f, 3.0f), BodyType.Dynamic);

            FixedMouseJoint joint = JointFactory.CreateFixedMouseJoint(world, body, new Vector2F(2.0f, 3.0f));

            Assert.NotNull(joint);
            Assert.Equal(JointType.FixedMouse, joint.JointType);
            Assert.Single(world.JointList);
        }
    }
}

