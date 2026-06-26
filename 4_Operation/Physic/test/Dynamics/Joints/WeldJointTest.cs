// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WeldJointTest.cs
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
    /// The weld joint test class
    /// </summary>
    public class WeldJointTest
    {
        /// <summary>
        /// Tests that weld joint type should be accessible
        /// </summary>
        [Fact]
        public void WeldJoint_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(WeldJoint));
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set joint type to weld
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetJointTypeToWeld()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            Assert.Equal(JointType.Weld, joint.JointType);
        }

        /// <summary>
        /// Tests that constructor with bodies and anchors should set body a and body b
        /// </summary>
        [Fact]
        public void Constructor_WithBodiesAndAnchors_ShouldSetBodyAAndBodyB()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            Assert.Same(bodyA, joint.BodyA);
            Assert.Same(bodyB, joint.BodyB);
        }

        /// <summary>
        /// Tests that reference angle should round trip
        /// </summary>
        [Fact]
        public void ReferenceAngle_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            joint.ReferenceAngle = 0.5f;

            Assert.Equal(0.5f, joint.ReferenceAngle);
        }

        /// <summary>
        /// Tests that frequency should round trip
        /// </summary>
        [Fact]
        public void Frequency_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            joint.FrequencyHz = 10.0f;

            Assert.Equal(10.0f, joint.FrequencyHz);
        }

        /// <summary>
        /// Tests that damping ratio should round trip
        /// </summary>
        [Fact]
        public void DampingRatio_ShouldRoundTrip()
        {
            Body bodyA = new Body();
            Body bodyB = new Body();
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            joint.DampingRatio = 0.8f;

            Assert.Equal(0.8f, joint.DampingRatio);
        }

        /// <summary>
        /// Tests that WorldAnchorA get returns valid vector
        /// </summary>
        [Fact]
        public void WorldAnchorA_Get_ShouldReturnValidVector()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            Vector2F anchor = joint.WorldAnchorA;

            Assert.False(float.IsNaN(anchor.X));
            Assert.False(float.IsNaN(anchor.Y));
        }

        /// <summary>
        /// Tests that WorldAnchorA set changes local anchor
        /// </summary>
        [Fact]
        public void WorldAnchorA_Set_ShouldChangeLocalAnchor()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            joint.WorldAnchorA = new Vector2F(1, 0);

            Vector2F anchor = joint.WorldAnchorA;
            Assert.False(float.IsNaN(anchor.X));
            Assert.False(float.IsNaN(anchor.Y));
        }

        /// <summary>
        /// Tests that WorldAnchorB get returns valid vector
        /// </summary>
        [Fact]
        public void WorldAnchorB_Get_ShouldReturnValidVector()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            Vector2F anchor = joint.WorldAnchorB;

            Assert.False(float.IsNaN(anchor.X));
            Assert.False(float.IsNaN(anchor.Y));
        }

        /// <summary>
        /// Tests that WorldAnchorB set changes local anchor
        /// </summary>
        [Fact]
        public void WorldAnchorB_Set_ShouldChangeLocalAnchor()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            joint.WorldAnchorB = new Vector2F(2, 1);

            Vector2F anchor = joint.WorldAnchorB;
            Assert.False(float.IsNaN(anchor.X));
            Assert.False(float.IsNaN(anchor.Y));
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
            WeldJoint joint = new WeldJoint(bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

            Vector2F force = joint.GetReactionForce(1f);

            Assert.Equal(0, force.X);
            Assert.Equal(0, force.Y);
        }
    }
}
