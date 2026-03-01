// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JointDelegateTest.cs
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

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The joint delegate test class
    /// </summary>
    public class JointDelegateTest
    {
        /// <summary>
        ///     Tests that joint delegate should be invokable
        /// </summary>
        [Fact]
        public void JointDelegate_ShouldBeInvokable()
        {
            bool invoked = false;
            JointDelegate callback = (sender, joint) =>
            {
                invoked = true;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.One);
            
            callback(world, joint);
            
            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that joint delegate should receive world parameter
        /// </summary>
        [Fact]
        public void JointDelegate_ShouldReceiveWorldParameter()
        {
            WorldPhysic capturedWorld = null;
            JointDelegate callback = (sender, joint) =>
            {
                capturedWorld = sender;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.One);
            
            callback(world, joint);
            
            Assert.Equal(world, capturedWorld);
        }

        /// <summary>
        ///     Tests that joint delegate should receive joint parameter
        /// </summary>
        [Fact]
        public void JointDelegate_ShouldReceiveJointParameter()
        {
            Joint capturedJoint = null;
            JointDelegate callback = (sender, joint) =>
            {
                capturedJoint = joint;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.One);
            
            callback(world, joint);
            
            Assert.Equal(joint, capturedJoint);
        }

        /// <summary>
        ///     Tests that joint delegate should be chainable
        /// </summary>
        [Fact]
        public void JointDelegate_ShouldBeChainable()
        {
            int callCount = 0;
            JointDelegate callback1 = (sender, joint) => callCount++;
            JointDelegate callback2 = (sender, joint) => callCount++;
            
            JointDelegate combined = callback1 + callback2;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.One);
            
            combined(world, joint);
            
            Assert.Equal(2, callCount);
        }

        /// <summary>
        ///     Tests that joint delegate should be removable
        /// </summary>
        [Fact]
        public void JointDelegate_ShouldBeRemovable()
        {
            int callCount = 0;
            JointDelegate callback1 = (sender, joint) => callCount++;
            JointDelegate callback2 = (sender, joint) => callCount++;
            
            JointDelegate combined = callback1 + callback2;
            combined -= callback1;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.One);
            
            combined(world, joint);
            
            Assert.Equal(1, callCount);
        }

        /// <summary>
        ///     Tests that joint delegate should handle null world
        /// </summary>
        [Fact]
        public void JointDelegate_ShouldHandleNullWorld()
        {
            bool invoked = false;
            JointDelegate callback = (sender, joint) =>
            {
                invoked = true;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.One);
            
            callback(null, joint);
            
            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that joint delegate should handle null joint
        /// </summary>
        [Fact]
        public void JointDelegate_ShouldHandleNullJoint()
        {
            bool invoked = false;
            JointDelegate callback = (sender, joint) =>
            {
                invoked = true;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            
            callback(world, null);
            
            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that joint delegate should support multiple invocations
        /// </summary>
        [Fact]
        public void JointDelegate_ShouldSupportMultipleInvocations()
        {
            int count = 0;
            JointDelegate callback = (sender, joint) => count++;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.One);
            
            callback(world, joint);
            callback(world, joint);
            
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that joint delegate should allow access to joint properties
        /// </summary>
        [Fact]
        public void JointDelegate_ShouldAllowAccessToJointProperties()
        {
            JointType capturedType = JointType.Unknown;
            JointDelegate callback = (sender, joint) =>
            {
                capturedType = joint.JointType;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.One);
            
            callback(world, joint);
            
            Assert.Equal(JointType.Distance, capturedType);
        }
    }
}

