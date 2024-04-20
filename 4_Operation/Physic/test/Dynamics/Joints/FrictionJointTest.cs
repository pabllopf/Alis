// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrictionJointTest.cs
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
    /// The friction joint test class
    /// </summary>
    public class FrictionJointTest
    {
        /// <summary>
        /// Tests that friction joint constructor test
        /// </summary>
        [Fact]
        public void FrictionJointConstructorTest()
        {
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 localAnchorA = new Vector2(0.5f, 0.5f);
            Vector2 localAnchorB = new Vector2(1.5f, 1.5f);
            float maxForce = 0.0f;
            float maxTorque = 0.0f;
            
            // Act
            FrictionJoint frictionJoint = new FrictionJoint(bodyA, bodyB, JointType.Friction, false, localAnchorA, localAnchorB, maxForce, maxTorque);
            
            // Assert
            Assert.Equal(bodyA, frictionJoint.BodyA);
            Assert.Equal(bodyB, frictionJoint.BodyB);
        }
        
        /// <summary>
        /// Tests that friction joint world anchor a test
        /// </summary>
        [Fact]
        public void FrictionJointWorldAnchorATest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 localAnchorA = new Vector2(0.5f, 0.5f);
            Vector2 localAnchorB = new Vector2(1.5f, 1.5f);
            float maxForce = 0.0f;
            float maxTorque = 0.0f;
            FrictionJoint frictionJoint = new FrictionJoint(bodyA, bodyB, JointType.Friction, false, localAnchorA, localAnchorB, maxForce, maxTorque);
            
            // Act
            Vector2 worldAnchorA = frictionJoint.WorldAnchorA;
            
            // Assert
            Assert.Equal(bodyA.GetWorldPoint(localAnchorA), worldAnchorA);
        }
        
        /// <summary>
        /// Tests that friction joint world anchor b test
        /// </summary>
        [Fact]
        public void FrictionJointWorldAnchorBTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 localAnchorA = new Vector2(0.5f, 0.5f);
            Vector2 localAnchorB = new Vector2(1.5f, 1.5f);
            float maxForce = 0.0f;
            float maxTorque = 0.0f;
            FrictionJoint frictionJoint = new FrictionJoint(bodyA, bodyB, JointType.Friction, false, localAnchorA, localAnchorB, maxForce, maxTorque);
            
            // Act
            Vector2 worldAnchorB = frictionJoint.WorldAnchorB;
            
            // Assert
            Assert.Equal(bodyB.GetWorldPoint(localAnchorB), worldAnchorB);
        }
    }
}