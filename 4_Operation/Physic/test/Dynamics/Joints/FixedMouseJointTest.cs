// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixedMouseJointTest.cs
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
    ///     The fixed mouse joint test class
    /// </summary>
    public class FixedMouseJointTest
    {
        /// <summary>
        ///     Tests that fixed mouse joint constructor test
        /// </summary>
        [Fact]
        public void FixedMouseJointConstructorTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 target = new Vector2(0.5f, 0.5f);
            
            // Act
            FixedMouseJoint fixedMouseJoint = new FixedMouseJoint(bodyA, bodyB, JointType.FixedMouse, false, target);
            
            // Assert
            Assert.Equal(bodyA, fixedMouseJoint.BodyA);
            Assert.Equal(bodyB, fixedMouseJoint.BodyB);
        }
        
        /// <summary>
        ///     Tests that fixed mouse joint world anchor a test
        /// </summary>
        [Fact]
        public void FixedMouseJointWorldAnchorATest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 target = new Vector2(0.5f, 0.5f);
            FixedMouseJoint fixedMouseJoint = new FixedMouseJoint(bodyA, bodyB, JointType.FixedMouse, false, target);
            
            // Act
            Vector2 worldAnchorA = fixedMouseJoint.WorldAnchorA;
            
            // Assert
            Assert.Equal(bodyA.GetWorldPoint(fixedMouseJoint.LocalAnchorA), worldAnchorA);
        }
        
        /// <summary>
        ///     Tests that fixed mouse joint world anchor b test
        /// </summary>
        [Fact]
        public void FixedMouseJointWorldAnchorBTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 target = new Vector2(0.5f, 0.5f);
            FixedMouseJoint fixedMouseJoint = new FixedMouseJoint(bodyA, bodyB, JointType.FixedMouse, false, target);
            
            // Act
            Vector2 worldAnchorB = fixedMouseJoint.WorldAnchorB;
            
            // Assert
            Assert.Equal(target, worldAnchorB);
        }
    }
}