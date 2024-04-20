// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PulleyJointTest.cs
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
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Alis.Core.Physic.Test.Collision.BroadPhase.Sample;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The pulley joint test class
    /// </summary>
    public class PulleyJointTest
    {
        /// <summary>
        /// Tests that pulley joint constructor test
        /// </summary>
        [Fact]
        public void PulleyJointConstructorTest()
        {
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchorA = new Vector2(0.5f, 0.5f);
            Vector2 anchorB = new Vector2(1.5f, 1.5f);
            Vector2 worldAnchorA = new Vector2(-1.0f, 1.0f);
            Vector2 worldAnchorB = new Vector2(1.0f, 1.0f);
            float ratio = 1.0f;
            bool useWorldCoordinates = false;
            
            // Act
            PulleyJoint pulleyJoint = new PulleyJoint(bodyA, bodyB, anchorA, anchorB, worldAnchorA, worldAnchorB, ratio, useWorldCoordinates);
            
            // Assert
            Assert.Equal(bodyA, pulleyJoint.BodyA);
            Assert.Equal(bodyB, pulleyJoint.BodyB);
            Assert.Equal(anchorA, pulleyJoint.LocalAnchorA);
            Assert.Equal(anchorB, pulleyJoint.LocalAnchorB);
            Assert.Equal(worldAnchorA, pulleyJoint.WorldAnchorA);
            Assert.Equal(worldAnchorB, pulleyJoint.WorldAnchorB);
            Assert.Equal(ratio, pulleyJoint.Ratio);
        }
        
        /// <summary>
        /// Tests that pulley joint properties test
        /// </summary>
        [Fact]
        public void PulleyJointPropertiesTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchorA = new Vector2(0.5f, 0.5f);
            Vector2 anchorB = new Vector2(1.5f, 1.5f);
            Vector2 worldAnchorA = new Vector2(-1.0f, 1.0f);
            Vector2 worldAnchorB = new Vector2(1.0f, 1.0f);
            float ratio = 1.0f;
            bool useWorldCoordinates = false;
            PulleyJoint pulleyJoint = new PulleyJoint(bodyA, bodyB, anchorA, anchorB, worldAnchorA, worldAnchorB, ratio, useWorldCoordinates)
                {
                    // Act
                    LocalAnchorA = new Vector2(0.6f, 0.6f),
                    LocalAnchorB = new Vector2(1.6f, 1.6f),
                    Ratio = 0.8f
                };
            
            // Assert
            Assert.Equal(new Vector2(0.6f, 0.6f), pulleyJoint.LocalAnchorA);
            Assert.Equal(new Vector2(1.6f, 1.6f), pulleyJoint.LocalAnchorB);
            Assert.Equal(0.8f, pulleyJoint.Ratio);
        }
        
        /// <summary>
        /// Tests that pulley joint world anchor test
        /// </summary>
        [Fact]
        public void PulleyJointWorldAnchorTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchorA = new Vector2(0.5f, 0.5f);
            Vector2 anchorB = new Vector2(1.5f, 1.5f);
            Vector2 worldAnchorA = new Vector2(-1.0f, 1.0f);
            Vector2 worldAnchorB = new Vector2(1.0f, 1.0f);
            float ratio = 1.0f;
            bool useWorldCoordinates = false;
            PulleyJoint pulleyJoint = new PulleyJoint(bodyA, bodyB, anchorA, anchorB, worldAnchorA, worldAnchorB, ratio, useWorldCoordinates);
            
            // Act
            Vector2 resultWorldAnchorA = pulleyJoint.WorldAnchorA;
            Vector2 resultWorldAnchorB = pulleyJoint.WorldAnchorB;
            
            // Assert
            Assert.Equal(worldAnchorA, resultWorldAnchorA);
            Assert.Equal(worldAnchorB, resultWorldAnchorB);
        }
    }
}