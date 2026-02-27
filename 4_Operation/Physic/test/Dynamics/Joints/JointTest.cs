// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JointTest.cs
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
    ///     The joint test class
    /// </summary>
    public class JointTest
    {
        /// <summary>
        ///     The test joint class
        /// </summary>
        /// <seealso cref="Joint" />
        private class TestJoint : Joint
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="TestJoint" /> class
            /// </summary>
            /// <param name="bodyA">The body</param>
            /// <param name="bodyB">The body</param>
            public TestJoint(Body bodyA, Body bodyB) : base(bodyA, bodyB)
            {
                JointType = JointType.Unknown;
            }

            /// <summary>
            ///     Gets or sets the value of the world anchor a
            /// </summary>
            public override Vector2F WorldAnchorA { get; set; }

            /// <summary>
            ///     Gets or sets the value of the world anchor b
            /// </summary>
            public override Vector2F WorldAnchorB { get; set; }

            /// <summary>
            ///     Gets the reaction force using the specified inv dt
            /// </summary>
            /// <param name="invDt">The inv dt</param>
            /// <returns>The vector</returns>
            public override Vector2F GetReactionForce(float invDt) => Vector2F.Zero;

            /// <summary>
            ///     Gets the reaction torque using the specified inv dt
            /// </summary>
            /// <param name="invDt">The inv dt</param>
            /// <returns>The float</returns>
            public override float GetReactionTorque(float invDt) => 0.0f;

            /// <summary>
            ///     Inits the velocity constraints using the specified data
            /// </summary>
            /// <param name="data">The data</param>
            internal override void InitVelocityConstraints(ref SolverData data) { }

            /// <summary>
            ///     Solves the velocity constraints using the specified data
            /// </summary>
            /// <param name="data">The data</param>
            internal override void SolveVelocityConstraints(ref SolverData data) { }

            /// <summary>
            ///     Describes whether this instance solve position constraints
            /// </summary>
            /// <param name="data">The data</param>
            /// <returns>The bool</returns>
            internal override bool SolvePositionConstraints(ref SolverData data) => true;
        }

        /// <summary>
        ///     Tests that constructor should initialize with two bodies
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithTwoBodies()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            
            TestJoint joint = new TestJoint(bodyA, bodyB);
            
            Assert.Equal(bodyA, joint.BodyA);
            Assert.Equal(bodyB, joint.BodyB);
        }

        /// <summary>
        ///     Tests that enabled property should default to true
        /// </summary>
        [Fact]
        public void EnabledProperty_ShouldDefaultToTrue()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            
            TestJoint joint = new TestJoint(bodyA, bodyB);
            
            Assert.True(joint.Enabled);
        }

        /// <summary>
        ///     Tests that collide connected should default to false
        /// </summary>
        [Fact]
        public void CollideConnected_ShouldDefaultToFalse()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            
            TestJoint joint = new TestJoint(bodyA, bodyB);
            
            Assert.False(joint.CollideConnected);
        }

        /// <summary>
        ///     Tests that breakpoint should default to max value
        /// </summary>
        [Fact]
        public void Breakpoint_ShouldDefaultToMaxValue()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            
            TestJoint joint = new TestJoint(bodyA, bodyB);
            
            Assert.Equal(float.MaxValue, joint.Breakpoint);
        }

        /// <summary>
        ///     Tests that breakpoint property should set and get correctly
        /// </summary>
        [Fact]
        public void BreakpointProperty_ShouldSetAndGetCorrectly()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            TestJoint joint = new TestJoint(bodyA, bodyB);
            
            joint.Breakpoint = 100.0f;
            
            Assert.Equal(100.0f, joint.Breakpoint);
        }

        /// <summary>
        ///     Tests that enabled property should set and get correctly
        /// </summary>
        [Fact]
        public void EnabledProperty_ShouldSetAndGetCorrectly()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            TestJoint joint = new TestJoint(bodyA, bodyB);
            
            joint.Enabled = false;
            
            Assert.False(joint.Enabled);
        }

        /// <summary>
        ///     Tests that collide connected property should set and get correctly
        /// </summary>
        [Fact]
        public void CollideConnectedProperty_ShouldSetAndGetCorrectly()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            TestJoint joint = new TestJoint(bodyA, bodyB);
            
            joint.CollideConnected = true;
            
            Assert.True(joint.CollideConnected);
        }

        /// <summary>
        ///     Tests that tag property should set and get correctly
        /// </summary>
        [Fact]
        public void TagProperty_ShouldSetAndGetCorrectly()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            TestJoint joint = new TestJoint(bodyA, bodyB);
            object tag = new object();
            
            joint.Tag = tag;
            
            Assert.Equal(tag, joint.Tag);
        }

        /// <summary>
        ///     Tests that is fixed type should return false for unknown joint type
        /// </summary>
        [Fact]
        public void IsFixedType_ShouldReturnFalse_ForUnknownJointType()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            TestJoint joint = new TestJoint(bodyA, bodyB);
            
            bool isFixed = joint.IsFixedType();
            
            Assert.False(isFixed);
        }

        /// <summary>
        ///     Tests that joint should have edge a and edge b
        /// </summary>
        [Fact]
        public void Joint_ShouldHaveEdgeAAndEdgeB()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            TestJoint joint = new TestJoint(bodyA, bodyB);
            
            Assert.NotNull(joint.EdgeA);
            Assert.NotNull(joint.EdgeB);
        }
        
        /// <summary>
        ///     Tests that joint should be abstract class
        /// </summary>
        [Fact]
        public void Joint_ShouldBeAbstractClass()
        {
            var type = typeof(Joint);
            
            Assert.True(type.IsAbstract);
        }
    }
}

