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
using Alis.Core.Aspect.Math.Vector;
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
    }
}

