// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceJointTest.cs
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
    /// The distance joint test class
    /// </summary>
    public class DistanceJointTest
    {
        /// <summary>
        /// Tests that distance joint constructor test
        /// </summary>
        [Fact]
        public void DistanceJointConstructorTest()
        {
            ContactManager contactManager = new ContactManager(new BroadPhaseImplementation());
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchorA = new Vector2(0.5f, 0.5f);
            Vector2 anchorB = new Vector2(1.5f, 1.5f);
            bool useWorldCoordinates = false;
            
            // Act
            DistanceJoint distanceJoint = new DistanceJoint(bodyA, bodyB, anchorA, anchorB, useWorldCoordinates);
            
            // Assert
            Assert.Equal(bodyA, distanceJoint.BodyA);
            Assert.Equal(bodyB, distanceJoint.BodyB);
            Assert.Equal(anchorA, distanceJoint.LocalAnchorA);
            Assert.Equal(anchorB, distanceJoint.LocalAnchorB);
        }
        
        /// <summary>
        /// Tests that distance joint properties test
        /// </summary>
        [Fact]
        public void DistanceJointPropertiesTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchorA = new Vector2(0.5f, 0.5f);
            Vector2 anchorB = new Vector2(1.5f, 1.5f);
            bool useWorldCoordinates = false;
            DistanceJoint distanceJoint = new DistanceJoint(bodyA, bodyB, anchorA, anchorB, useWorldCoordinates);
            
            // Act
            distanceJoint.LocalAnchorA = new Vector2(0.6f, 0.6f);
            distanceJoint.LocalAnchorB = new Vector2(1.6f, 1.6f);
            distanceJoint.Stiffness = 0.5f;
            distanceJoint.Damping = 0.5f;
            
            // Assert
            Assert.Equal(new Vector2(0.6f, 0.6f), distanceJoint.LocalAnchorA);
            Assert.Equal(new Vector2(1.6f, 1.6f), distanceJoint.LocalAnchorB);
            Assert.Equal(0.5f, distanceJoint.Stiffness);
            Assert.Equal(0.5f, distanceJoint.Damping);
        }
        
        /// <summary>
        /// Tests that distance joint world anchor test
        /// </summary>
        [Fact]
        public void DistanceJointWorldAnchorTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchorA = new Vector2(0.5f, 0.5f);
            Vector2 anchorB = new Vector2(1.5f, 1.5f);
            bool useWorldCoordinates = false;
            DistanceJoint distanceJoint = new DistanceJoint(bodyA, bodyB, anchorA, anchorB, useWorldCoordinates);
            
            // Act
            Vector2 worldAnchorA = distanceJoint.WorldAnchorA;
            Vector2 worldAnchorB = distanceJoint.WorldAnchorB;
            
            // Assert
            Assert.Equal(bodyA.GetWorldPoint(anchorA), worldAnchorA);
            Assert.Equal(bodyB.GetWorldPoint(anchorB), worldAnchorB);
        }
    }
}