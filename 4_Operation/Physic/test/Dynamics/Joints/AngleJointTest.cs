// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AngleJointTest.cs
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
    /// The angle joint test class
    /// </summary>
    public class AngleJointTest
    {
        /// <summary>
        /// Tests that angle joint constructor test
        /// </summary>
        [Fact]
        public void AngleJointConstructorTest()
        {
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            
            // Act
            AngleJoint angleJoint = new AngleJoint(bodyA, bodyB);
            
            // Assert
            Assert.Equal(bodyA, angleJoint.BodyA);
            Assert.Equal(bodyB, angleJoint.BodyB);
        }
        
        /// <summary>
        /// Tests that angle joint properties test
        /// </summary>
        [Fact]
        public void AngleJointPropertiesTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            AngleJoint angleJoint = new AngleJoint(bodyA, bodyB);
            
            // Act
            angleJoint.TargetAngle = 0.5f;
            
            // Assert
            Assert.Equal(0.5f, angleJoint.TargetAngle);
        }
        
        /// <summary>
        /// Tests that angle joint world anchor test
        /// </summary>
        [Fact]
        public void AngleJointWorldAnchorTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            AngleJoint angleJoint = new AngleJoint(bodyA, bodyB);
            
            // Act
            Vector2 worldAnchorA = angleJoint.WorldAnchorA;
            Vector2 worldAnchorB = angleJoint.WorldAnchorB;
            
            // Assert
            Assert.Equal(bodyA.Position, worldAnchorA);
            Assert.Equal(bodyB.Position, worldAnchorB);
        }
    }
}