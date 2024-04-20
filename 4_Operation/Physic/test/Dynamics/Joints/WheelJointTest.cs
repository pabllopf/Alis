// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WheelJointTest.cs
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
    /// The wheel joint test class
    /// </summary>
    public class WheelJointTest
    {
        /// <summary>
        /// Tests that wheel joint constructor test
        /// </summary>
        [Fact]
        public void WheelJointConstructorTest()
        {
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchor = new Vector2(0.5f, 0.5f);
            Vector2 axis = new Vector2(1, 0);
            bool useWorldCoordinates = false;
            
            // Act
            WheelJoint wheelJoint = new WheelJoint(bodyA, bodyB, anchor, axis, useWorldCoordinates);
            
            // Assert
            Assert.Equal(bodyA, wheelJoint.BodyA);
            Assert.Equal(bodyB, wheelJoint.BodyB);
            Assert.Equal(new Vector2(1.5f, 1.5f), wheelJoint.LocalAnchorA);
            Assert.Equal(anchor, wheelJoint.LocalAnchorB);
            Assert.Equal(axis, wheelJoint.LocalXAxisA);
        }
        
        /// <summary>
        /// Tests that wheel joint properties test
        /// </summary>
        [Fact]
        public void WheelJointPropertiesTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchor = new Vector2(0.5f, 0.5f);
            Vector2 axis = new Vector2(1, 0);
            bool useWorldCoordinates = false;
            WheelJoint wheelJoint = new WheelJoint(bodyA, bodyB, anchor, axis, useWorldCoordinates);
            
            // Act
            Vector2 worldAnchorA = wheelJoint.WorldAnchorA;
            Vector2 worldAnchorB = wheelJoint.WorldAnchorB;
            
            // Assert
            Assert.Equal(new Vector2(1.5f, 1.5f), worldAnchorA);
            Assert.Equal(bodyB.GetWorldPoint(anchor), worldAnchorB);
        }
        
        /// <summary>
        /// Tests that wheel joint joint translation test
        /// </summary>
        [Fact]
        public void WheelJointJointTranslationTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchor = new Vector2(0.5f, 0.5f);
            Vector2 axis = new Vector2(1, 0);
            bool useWorldCoordinates = false;
            WheelJoint wheelJoint = new WheelJoint(bodyA, bodyB, anchor, axis, useWorldCoordinates);
            
            // Act
            float jointTranslation = wheelJoint.JointTranslation;
            
            // Assert
            Assert.Equal(0, jointTranslation);
        }
    }
}