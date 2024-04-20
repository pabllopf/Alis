// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RevoluteJointTest.cs
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
    /// The revolute joint test class
    /// </summary>
    public class RevoluteJointTest
    {
        /// <summary>
        /// Tests that revolute joint constructor test
        /// </summary>
        [Fact]
        public void RevoluteJointConstructorTest()
        {
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchorA = new Vector2(0.5f, 0.5f);
            Vector2 anchorB = new Vector2(1.5f, 1.5f);
            bool useWorldCoordinates = false;
            
            // Act
            RevoluteJoint revoluteJoint = new RevoluteJoint(bodyA, bodyB, anchorA, anchorB, useWorldCoordinates);
            
            // Assert
            Assert.Equal(bodyA, revoluteJoint.BodyA);
            Assert.Equal(bodyB, revoluteJoint.BodyB);
            Assert.Equal(anchorA, revoluteJoint.LocalAnchorA);
            Assert.Equal(anchorB, revoluteJoint.LocalAnchorB);
        }
        
        /// <summary>
        /// Tests that revolute joint properties test
        /// </summary>
        [Fact]
        public void RevoluteJointPropertiesTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchorA = new Vector2(0.5f, 0.5f);
            Vector2 anchorB = new Vector2(1.5f, 1.5f);
            bool useWorldCoordinates = false;
            RevoluteJoint revoluteJoint = new RevoluteJoint(bodyA, bodyB, anchorA, anchorB, useWorldCoordinates)
                {
                    // Act
                    LocalAnchorA = new Vector2(0.6f, 0.6f),
                    LocalAnchorB = new Vector2(1.6f, 1.6f),
                    LowerAngle = 0.1f,
                    UpperAngle = 0.9f,
                    MotorSpeed = 0.5f,
                    MotorTorque = 0.5f,
                    EnableLimit = true,
                    EnableMotor = true
                };
            
            // Assert
            Assert.Equal(new Vector2(0.6f, 0.6f), revoluteJoint.LocalAnchorA);
            Assert.Equal(new Vector2(1.6f, 1.6f), revoluteJoint.LocalAnchorB);
            Assert.Equal(0.1f, revoluteJoint.LowerAngle);
            Assert.Equal(0.9f, revoluteJoint.UpperAngle);
            Assert.Equal(0.5f, revoluteJoint.MotorSpeed);
            Assert.Equal(0.5f, revoluteJoint.MotorTorque);
            Assert.True(revoluteJoint.EnableLimit);
            Assert.True(revoluteJoint.EnableMotor);
        }
        
        /// <summary>
        /// Tests that revolute joint world anchor test
        /// </summary>
        [Fact]
        public void RevoluteJointWorldAnchorTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchorA = new Vector2(0.5f, 0.5f);
            Vector2 anchorB = new Vector2(1.5f, 1.5f);
            bool useWorldCoordinates = false;
            RevoluteJoint revoluteJoint = new RevoluteJoint(bodyA, bodyB, anchorA, anchorB, useWorldCoordinates);
            
            // Act
            Vector2 worldAnchorA = revoluteJoint.WorldAnchorA;
            Vector2 worldAnchorB = revoluteJoint.WorldAnchorB;
            
            // Assert
            Assert.Equal(bodyA.GetWorldPoint(anchorA), worldAnchorA);
            Assert.Equal(bodyB.GetWorldPoint(anchorB), worldAnchorB);
        }
    }
}