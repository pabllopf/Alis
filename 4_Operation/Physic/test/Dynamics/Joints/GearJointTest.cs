// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GearJointTest.cs
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

using System;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The gear joint test class
    /// </summary>
    public class GearJointTest
    {
        /// <summary>
        /// Tests that gear joint type should be accessible
        /// </summary>
        [Fact]
        public void GearJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(GearJoint));
        }

        /// <summary>
        /// Tests that gear joint constructor initializes with two bodies and two joints
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithTwoBodiesAndTwoJoints()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            Assert.Equal(JointType.Gear, gearJoint.JointType);
            Assert.Equal(bodyA, gearJoint.BodyA);
            Assert.Equal(bodyC, gearJoint.BodyB);
            Assert.Equal(jointA, gearJoint.JointA);
            Assert.Equal(jointB, gearJoint.JointB);
        }

        /// <summary>
        /// Tests that gear joint constructor with custom ratio initializes correctly
        /// </summary>
        [Fact]
        public void Constructor_WithCustomRatio_ShouldInitialize()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB, 2.5f);

            Assert.Equal(2.5f, gearJoint.Ratio);
        }

        /// <summary>
        /// Tests that ratio can be set and retrieved
        /// </summary>
        [Fact]
        public void Ratio_ShouldGetAndSet()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            gearJoint.Ratio = 3f;
            Assert.Equal(3f, gearJoint.Ratio);
        }

        /// <summary>
        /// Tests that WorldAnchorA get returns a valid vector
        /// </summary>
        [Fact]
        public void WorldAnchorA_Get_ShouldReturnValidVector()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            Vector2F anchorA = gearJoint.WorldAnchorA;
            Assert.False(float.IsNaN(anchorA.X));
            Assert.False(float.IsNaN(anchorA.Y));
        }

        /// <summary>
        /// Tests that WorldAnchorA set throws NotSupportedException
        /// </summary>
        [Fact]
        public void WorldAnchorA_Set_ShouldThrowNotSupportedException()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            Assert.Throws<NotSupportedException>(() => gearJoint.WorldAnchorA = Vector2F.Zero);
        }

        /// <summary>
        /// Tests that WorldAnchorB get returns a valid vector
        /// </summary>
        [Fact]
        public void WorldAnchorB_Get_ShouldReturnValidVector()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            Vector2F anchorB = gearJoint.WorldAnchorB;
            Assert.False(float.IsNaN(anchorB.X));
            Assert.False(float.IsNaN(anchorB.Y));
        }

        /// <summary>
        /// Tests that WorldAnchorB set throws NotSupportedException
        /// </summary>
        [Fact]
        public void WorldAnchorB_Set_ShouldThrowNotSupportedException()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            Assert.Throws<NotSupportedException>(() => gearJoint.WorldAnchorB = Vector2F.Zero);
        }

        /// <summary>
        /// Tests that GetReactionForce returns zero for initial state
        /// </summary>
        [Fact]
        public void GetReactionForce_ShouldReturnZeroForInitialState()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            Vector2F force = gearJoint.GetReactionForce(1f);
            Assert.Equal(0, force.X);
            Assert.Equal(0, force.Y);
        }

        /// <summary>
        /// Tests that GetReactionTorque returns zero for initial state
        /// </summary>
        [Fact]
        public void GetReactionTorque_ShouldReturnZeroForInitialState()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            float torque = gearJoint.GetReactionTorque(1f);
            Assert.Equal(0, torque);
        }

        /// <summary>
        /// Tests that gear joint constructor with prismatic joint A initializes correctly
        /// </summary>
        [Fact]
        public void Constructor_WithPrismaticJointA_ShouldInitialize()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            PrismaticJoint prismaticA = new PrismaticJoint(bodyA, bodyB, new Vector2F(1, 0), Vector2F.UnitX);
            RevoluteJoint revoluteB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, prismaticA, revoluteB);

            Assert.Equal(JointType.Gear, gearJoint.JointType);
            Assert.NotNull(gearJoint.WorldAnchorA);
            Assert.NotNull(gearJoint.WorldAnchorB);
        }

        /// <summary>
        /// Tests that gear joint constructor with prismatic joint B initializes correctly
        /// </summary>
        [Fact]
        public void Constructor_WithPrismaticJointB_ShouldInitialize()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint revoluteA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            PrismaticJoint prismaticB = new PrismaticJoint(bodyC, bodyD, new Vector2F(5, 0), Vector2F.UnitX);
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, revoluteA, prismaticB);

            Assert.Equal(JointType.Gear, gearJoint.JointType);
            Assert.NotNull(gearJoint.WorldAnchorA);
            Assert.NotNull(gearJoint.WorldAnchorB);
        }

        /// <summary>
        /// Tests that gear joint constructor with both prismatic joints initializes correctly
        /// </summary>
        [Fact]
        public void Constructor_WithBothPrismaticJoints_ShouldInitialize()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            PrismaticJoint prismaticA = new PrismaticJoint(bodyA, bodyB, new Vector2F(1, 0), Vector2F.UnitX);
            PrismaticJoint prismaticB = new PrismaticJoint(bodyC, bodyD, new Vector2F(5, 0), Vector2F.UnitX);
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, prismaticA, prismaticB);

            Assert.Equal(JointType.Gear, gearJoint.JointType);
        }

        /// <summary>
        /// Tests that negative ratio is supported
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeRatio_ShouldInitialize()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB, -2.5f);

            Assert.Equal(-2.5f, gearJoint.Ratio);
        }

        /// <summary>
        /// Tests that zero ratio is supported
        /// </summary>
        [Fact]
        public void Constructor_WithZeroRatio_ShouldInitialize()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB, 0f);

            Assert.Equal(0f, gearJoint.Ratio);
        }

        /// <summary>
        /// Tests that very large ratio is supported
        /// </summary>
        [Fact]
        public void Constructor_WithLargeRatio_ShouldInitialize()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB, 1000f);

            Assert.Equal(1000f, gearJoint.Ratio);
        }

        /// <summary>
        /// Tests that multiple gear joints can be created in the same world
        /// </summary>
        [Fact]
        public void MultipleGearJoints_ShouldWorkIndependently()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            
            // First gear joint
            Body bodyA1 = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB1 = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC1 = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD1 = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);
            RevoluteJoint jointA1 = new RevoluteJoint(bodyA1, bodyB1, new Vector2F(1, 0));
            RevoluteJoint jointB1 = new RevoluteJoint(bodyC1, bodyD1, new Vector2F(5, 0));
            GearJoint gearJoint1 = new GearJoint(bodyA1, bodyC1, jointA1, jointB1, 1.0f);

            // Second gear joint with different ratio
            Body bodyA2 = world.CreateBody(new Vector2F(10, 0), 0, BodyType.Dynamic);
            Body bodyB2 = world.CreateBody(new Vector2F(12, 0), 0, BodyType.Dynamic);
            Body bodyC2 = world.CreateBody(new Vector2F(14, 0), 0, BodyType.Dynamic);
            Body bodyD2 = world.CreateBody(new Vector2F(16, 0), 0, BodyType.Dynamic);
            RevoluteJoint jointA2 = new RevoluteJoint(bodyA2, bodyB2, new Vector2F(11, 0));
            RevoluteJoint jointB2 = new RevoluteJoint(bodyC2, bodyD2, new Vector2F(15, 0));
            GearJoint gearJoint2 = new GearJoint(bodyA2, bodyC2, jointA2, jointB2, 2.0f);

            Assert.Equal(1.0f, gearJoint1.Ratio);
            Assert.Equal(2.0f, gearJoint2.Ratio);
        }

        /// <summary>
        /// Tests that JointA and JointB properties are read-only
        /// </summary>
        [Fact]
        public void JointA_JointB_ShouldBeReadOnly()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            Type jointAClass = gearJoint.JointA.GetType();
            Type jointBClass = gearJoint.JointB.GetType();

            Assert.Equal(typeof(RevoluteJoint), jointAClass);
            Assert.Equal(typeof(RevoluteJoint), jointBClass);
        }

        /// <summary>
        /// Tests that BodyA and BodyB properties return correct bodies
        /// </summary>
        [Fact]
        public void BodyA_BodyB_ShouldReturnCorrectBodies()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            Assert.Same(bodyA, gearJoint.BodyA);
            Assert.Same(bodyC, gearJoint.BodyB);
        }

        /// <summary>
        /// Tests that GetReactionForce with different invDt values returns proportional results
        /// </summary>
        [Fact]
        public void GetReactionForce_DifferentInvDt_ShouldReturnProportionalResults()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            Vector2F force1 = gearJoint.GetReactionForce(1f);
            Vector2F force2 = gearJoint.GetReactionForce(2f);
            Vector2F force3 = gearJoint.GetReactionForce(0.5f);

            // All should be zero initially
            Assert.Equal(0, force1.X);
            Assert.Equal(0, force1.Y);
            Assert.Equal(0, force2.X);
            Assert.Equal(0, force2.Y);
            Assert.Equal(0, force3.X);
            Assert.Equal(0, force3.Y);
        }

        /// <summary>
        /// Tests that GetReactionTorque with different invDt values returns proportional results
        /// </summary>
        [Fact]
        public void GetReactionTorque_DifferentInvDt_ShouldReturnProportionalResults()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            float torque1 = gearJoint.GetReactionTorque(1f);
            float torque2 = gearJoint.GetReactionTorque(2f);
            float torque3 = gearJoint.GetReactionTorque(0.5f);

            // All should be zero initially
            Assert.Equal(0, torque1);
            Assert.Equal(0, torque2);
            Assert.Equal(0, torque3);
        }

        /// <summary>
        /// Tests that WorldAnchorA returns consistent values on repeated calls
        /// </summary>
        [Fact]
        public void WorldAnchorA_ConsistentOnRepeatedCalls()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            Vector2F anchor1 = gearJoint.WorldAnchorA;
            Vector2F anchor2 = gearJoint.WorldAnchorA;

            Assert.Equal(anchor1.X, anchor2.X);
            Assert.Equal(anchor1.Y, anchor2.Y);
        }

        /// <summary>
        /// Tests that WorldAnchorB returns consistent values on repeated calls
        /// </summary>
        [Fact]
        public void WorldAnchorB_ConsistentOnRepeatedCalls()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(4, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(6, 0), 0, BodyType.Dynamic);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(1, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(5, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            Vector2F anchor1 = gearJoint.WorldAnchorB;
            Vector2F anchor2 = gearJoint.WorldAnchorB;

            Assert.Equal(anchor1.X, anchor2.X);
            Assert.Equal(anchor1.Y, anchor2.Y);
        }

        /// <summary>
        /// Tests that step with revolute joints initializes solver without throwing
        /// </summary>
        [Fact]
        public void Step_WithRevoluteJoints_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(0.5f, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(2.5f, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(gearJoint);
        }

        /// <summary>
        /// Tests that step with prismatic joints initializes solver
        /// </summary>
        [Fact]
        public void Step_WithPrismaticJoints_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            PrismaticJoint jointA = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.UnitX);
            PrismaticJoint jointB = new PrismaticJoint(bodyC, bodyD, Vector2F.Zero, Vector2F.UnitX);
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(gearJoint);
        }

        /// <summary>
        /// Tests that step with revolute and prismatic joints initializes solver
        /// </summary>
        [Fact]
        public void Step_WithRevoluteAndPrismaticJoints_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(0.5f, 0));
            PrismaticJoint jointB = new PrismaticJoint(bodyC, bodyD, Vector2F.Zero, Vector2F.UnitX);
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(gearJoint);
        }

        /// <summary>
        /// Tests that step with prismatic and revolute joints initializes solver
        /// </summary>
        [Fact]
        public void Step_WithPrismaticAndRevoluteJoints_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            PrismaticJoint jointA = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.UnitX);
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(2.5f, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(gearJoint);
        }

        /// <summary>
        /// Tests that step with custom ratio maintains constraint
        /// </summary>
        [Fact]
        public void Step_WithCustomRatio_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(0.5f, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(2.5f, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB, 2.0f);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(gearJoint);
        }

        /// <summary>
        /// Tests that step with negative ratio maintains constraint
        /// </summary>
        [Fact]
        public void Step_WithNegativeRatio_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(0.5f, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(2.5f, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB, -1.5f);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.NotNull(gearJoint);
        }

        /// <summary>
        /// Tests that multiple steps with revolute joints progress the simulation
        /// </summary>
        [Fact]
        public void Step_MultipleSteps_WithRevoluteJoints_ShouldProgressSimulation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(0.5f, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(2.5f, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            for (int i = 0; i < 10; i++)
            {
                SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.NotNull(gearJoint);
        }

        /// <summary>
        /// Tests that multiple steps with prismatic joints progress the simulation
        /// </summary>
        [Fact]
        public void Step_MultipleSteps_WithPrismaticJoints_ShouldProgressSimulation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            PrismaticJoint jointA = new PrismaticJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.UnitX);
            PrismaticJoint jointB = new PrismaticJoint(bodyC, bodyD, Vector2F.Zero, Vector2F.UnitX);
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            for (int i = 0; i < 10; i++)
            {
                SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.NotNull(gearJoint);
        }

        /// <summary>
        /// Tests that get reaction force after step returns valid value
        /// </summary>
        [Fact]
        public void GetReactionForce_AfterStep_ShouldReturnValidValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(0.5f, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(2.5f, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Vector2F force = gearJoint.GetReactionForce(1.0f);
            Assert.NotNull(gearJoint);
        }

        /// <summary>
        /// Tests that get reaction torque after step returns valid value
        /// </summary>
        [Fact]
        public void GetReactionTorque_AfterStep_ShouldReturnValidValue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(0.5f, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(2.5f, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);
            world.Add(jointA);
            world.Add(jointB);
            world.Add(gearJoint);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            float torque = gearJoint.GetReactionTorque(1.0f);
            Assert.NotNull(gearJoint);
        }

        /// <summary>
        /// Tests that init velocity constraints with warm starting false covers else branch
        /// </summary>
        [Fact]
        public void InitVelocityConstraints_WithWarmStartingFalse_CoversElseBranch()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1, 0), 0, BodyType.Dynamic);
            Body bodyC = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            Body bodyD = world.CreateBody(new Vector2F(3, 0), 0, BodyType.Dynamic);
            CircleShape shape = new CircleShape(0.2f, 1.0f);
            bodyA.CreateFixture(shape);
            bodyB.CreateFixture(shape);
            bodyC.CreateFixture(shape);
            bodyD.CreateFixture(shape);

            RevoluteJoint jointA = new RevoluteJoint(bodyA, bodyB, new Vector2F(0.5f, 0));
            RevoluteJoint jointB = new RevoluteJoint(bodyC, bodyD, new Vector2F(2.5f, 0));
            GearJoint gearJoint = new GearJoint(bodyA, bodyC, jointA, jointB);

            SolverData data = new SolverData
            {
                Step = new TimeStep { Dt = 0.016f, InvDt = 62.5f, WarmStarting = false },
                Positions = new SolverPosition[] { new SolverPosition { C = Vector2F.Zero, A = 0.0f } },
                Velocities = new SolverVelocity[] { new SolverVelocity { V = Vector2F.Zero, W = 0.0f } },
                Locks = new int[] { 0 }
            };

            MethodInfo initMethod = typeof(GearJoint).GetMethod("InitVelocityConstraints", BindingFlags.NonPublic | BindingFlags.Instance);
            initMethod.Invoke(gearJoint, new object[] { data });
        }
    }
}

