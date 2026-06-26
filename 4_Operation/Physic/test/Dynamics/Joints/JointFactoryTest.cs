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

        /// <summary>
        /// Tests that create motor joint should add joint to world
        /// </summary>
        [Fact]
        public void CreateMotorJoint_ShouldAddJointToWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.4f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.4f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            MotorJoint joint = JointFactory.CreateMotorJoint(world, bodyA, bodyB);

            Assert.NotNull(joint);
            Assert.Equal(JointType.Motor, joint.JointType);
            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
            Assert.Single(world.JointList);
        }

        /// <summary>
        /// Tests that create revolute joint with anchor parameters should return joint
        /// </summary>
        [Fact]
        public void CreateRevoluteJoint_WithAnchors_ShouldReturnJoint()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.4f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.4f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            RevoluteJoint joint = JointFactory.CreateRevoluteJoint(world, bodyA, bodyB, new Vector2F(0.0f, 1.0f), new Vector2F(0.0f, -1.0f));

            Assert.NotNull(joint);
            Assert.Equal(JointType.Revolute, joint.JointType);
            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
            Assert.Single(world.JointList);
        }

        /// <summary>
        /// Tests that create rope joint should add joint to world
        /// </summary>
        [Fact]
        public void CreateRopeJoint_ShouldAddJointToWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.4f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.4f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            RopeJoint joint = JointFactory.CreateRopeJoint(world, bodyA, bodyB, new Vector2F(0.0f, 1.0f), new Vector2F(0.0f, -1.0f));

            Assert.NotNull(joint);
            Assert.Equal(JointType.Rope, joint.JointType);
            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
            Assert.Single(world.JointList);
        }

        /// <summary>
        /// Tests that create weld joint should add joint to world
        /// </summary>
        [Fact]
        public void CreateWeldJoint_ShouldAddJointToWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.4f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.4f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            WeldJoint joint = JointFactory.CreateWeldJoint(world, bodyA, bodyB, new Vector2F(0.0f, 1.0f), new Vector2F(0.0f, -1.0f));

            Assert.NotNull(joint);
            Assert.Equal(JointType.Weld, joint.JointType);
            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
            Assert.Single(world.JointList);
        }

        /// <summary>
        /// Tests that create prismatic joint should add joint to world
        /// </summary>
        [Fact]
        public void CreatePrismaticJoint_ShouldAddJointToWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.4f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.4f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            PrismaticJoint joint = JointFactory.CreatePrismaticJoint(world, bodyA, bodyB, new Vector2F(0.0f, 0.0f), new Vector2F(0.0f, 1.0f));

            Assert.NotNull(joint);
            Assert.Equal(JointType.Prismatic, joint.JointType);
            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
            Assert.Single(world.JointList);
        }

        /// <summary>
        /// Tests that create wheel joint with world coordinates should return joint
        /// </summary>
        [Fact]
        public void CreateWheelJoint_WithWorldCoordinates_ShouldReturnJoint()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateRectangle(1.0f, 1.0f, 1.0f, new Vector2F(-1.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateRectangle(1.0f, 1.0f, 1.0f, new Vector2F(1.0f, 0.0f), 0.0f, BodyType.Dynamic);

            WheelJoint joint = JointFactory.CreateWheelJoint(world, bodyA, bodyB, new Vector2F(0.0f, 0.0f), new Vector2F(0.0f, 1.0f));

            Assert.NotNull(joint);
            Assert.Equal(JointType.Wheel, joint.JointType);
            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
            Assert.Single(world.JointList);
        }

        /// <summary>
        /// Tests that create angle joint should add joint to world
        /// </summary>
        [Fact]
        public void CreateAngleJoint_ShouldAddJointToWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.4f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.4f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            AngleJoint joint = JointFactory.CreateAngleJoint(world, bodyA, bodyB);

            Assert.NotNull(joint);
            Assert.Equal(JointType.Angle, joint.JointType);
            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
            Assert.Single(world.JointList);
        }

        /// <summary>
        /// Tests that create distance joint with anchors should return joint
        /// </summary>
        [Fact]
        public void CreateDistanceJoint_WithAnchors_ShouldReturnJoint()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.4f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.4f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            DistanceJoint joint = JointFactory.CreateDistanceJoint(world, bodyA, bodyB, new Vector2F(0.0f, 1.0f), new Vector2F(0.0f, -1.0f));

            Assert.NotNull(joint);
            Assert.Equal(JointType.Distance, joint.JointType);
            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
            Assert.Single(world.JointList);
        }

        /// <summary>
        /// Tests that create friction joint with anchor should return joint
        /// </summary>
        [Fact]
        public void CreateFrictionJoint_WithAnchor_ShouldReturnJoint()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.4f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.4f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            FrictionJoint joint = JointFactory.CreateFrictionJoint(world, bodyA, bodyB, new Vector2F(0.0f, 0.0f));

            Assert.NotNull(joint);
            Assert.Equal(JointType.Friction, joint.JointType);
            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
            Assert.Single(world.JointList);
        }

        /// <summary>
        /// Tests that create friction joint default should return joint
        /// </summary>
        [Fact]
        public void CreateFrictionJoint_Default_ShouldReturnJoint()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.4f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.4f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            FrictionJoint joint = JointFactory.CreateFrictionJoint(world, bodyA, bodyB);

            Assert.NotNull(joint);
            Assert.Equal(JointType.Friction, joint.JointType);
            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
            Assert.Single(world.JointList);
        }

        /// <summary>
        /// Tests that create gear joint should add joint to world
        /// </summary>
        [Fact]
        public void CreateGearJoint_ShouldAddJointToWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.4f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.4f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            Body bodyC = world.CreateCircle(0.4f, 1.0f, new Vector2F(0.0f, 2.0f), BodyType.Dynamic);
            Body bodyD = world.CreateCircle(0.4f, 1.0f, new Vector2F(0.0f, -2.0f), BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyC, new Vector2F(0.0f, 1.0f), new Vector2F(0.0f, -1.0f));
            world.Add(jointA);
            RevoluteJoint jointB = new RevoluteJoint(bodyB, bodyD, new Vector2F(0.0f, 1.0f), new Vector2F(0.0f, -1.0f));
            world.Add(jointB);

            GearJoint joint = JointFactory.CreateGearJoint(world, bodyA, bodyB, jointA, jointB, 1.0f);

            Assert.NotNull(joint);
            Assert.Equal(JointType.Gear, joint.JointType);
            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
        }

        /// <summary>
        /// Tests that create pulley joint should add joint to world
        /// </summary>
        [Fact]
        public void CreatePulleyJoint_ShouldAddJointToWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.4f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.4f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            PulleyJoint joint = JointFactory.CreatePulleyJoint(world, bodyA, bodyB, new Vector2F(0.0f, 1.0f), new Vector2F(0.0f, -1.0f), new Vector2F(0.0f, 2.0f), new Vector2F(0.0f, -2.0f), 1.0f);

            Assert.NotNull(joint);
            Assert.Equal(JointType.Pulley, joint.JointType);
            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
            Assert.Single(world.JointList);
        }
    }
}

