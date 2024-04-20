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
        /// Tests that weld joint constructor test
        /// </summary>
        [Fact]
        public void WeldJointConstructorTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 localAnchorA = new Vector2(0.5f, 0.5f);
            Vector2 localAnchorB = new Vector2(1.5f, 1.5f);
            float referenceAngle = 0.0f;
            float stiffness = 0.0f;
            float damping = 0.0f;
            
            // Act
            WeldJoint weldJoint = new WeldJoint(bodyA, bodyB, JointType.Weld, false, localAnchorA, localAnchorB, referenceAngle, stiffness, damping);
            
            // Assert
            Assert.Equal(bodyA, weldJoint.BodyA);
            Assert.Equal(bodyB, weldJoint.BodyB);
            Assert.Equal(localAnchorA, weldJoint.LocalAnchorA);
            Assert.Equal(localAnchorB, weldJoint.LocalAnchorB);
            Assert.Equal(referenceAngle, weldJoint.ReferenceAngle);
            Assert.Equal(stiffness, weldJoint.Stiffness);
            Assert.Equal(damping, weldJoint.Damping);
        }
        
        /// <summary>
        /// Tests that weld joint properties test
        /// </summary>
        [Fact]
        public void WeldJointPropertiesTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 localAnchorA = new Vector2(0.5f, 0.5f);
            Vector2 localAnchorB = new Vector2(1.5f, 1.5f);
            float referenceAngle = 0.0f;
            float stiffness = 0.0f;
            float damping = 0.0f;
            WeldJoint weldJoint = new WeldJoint(bodyA, bodyB, JointType.Weld, false, localAnchorA, localAnchorB, referenceAngle, stiffness, damping);
            
            // Act
            weldJoint.LocalAnchorA = new Vector2(0.6f, 0.6f);
            weldJoint.LocalAnchorB = new Vector2(1.6f, 1.6f);
            weldJoint.Stiffness = 0.8f;
            weldJoint.Damping = 0.7f;
            
            // Assert
            Assert.Equal(new Vector2(0.6f, 0.6f), weldJoint.LocalAnchorA);
            Assert.Equal(new Vector2(1.6f, 1.6f), weldJoint.LocalAnchorB);
            Assert.Equal(0.8f, weldJoint.Stiffness);
            Assert.Equal(0.7f, weldJoint.Damping);
        }
        
        /// <summary>
        /// Tests that weld joint world anchor test
        /// </summary>
        [Fact]
        public void WeldJointWorldAnchorTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 localAnchorA = new Vector2(0.5f, 0.5f);
            Vector2 localAnchorB = new Vector2(1.5f, 1.5f);
            float referenceAngle = 0.0f;
            float stiffness = 0.0f;
            float damping = 0.0f;
            WeldJoint weldJoint = new WeldJoint(bodyA, bodyB, JointType.Weld, false, localAnchorA, localAnchorB, referenceAngle, stiffness, damping);
            
            // Act
            Vector2 worldAnchorA = weldJoint.WorldAnchorA;
            Vector2 worldAnchorB = weldJoint.WorldAnchorB;
            
            // Assert
            Assert.Equal(bodyA.GetWorldPoint(localAnchorA), worldAnchorA);
            Assert.Equal(bodyB.GetWorldPoint(localAnchorB), worldAnchorB);
        }
    }
}