// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PrismaticJointTest.cs
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
    /// The prismatic joint test class
    /// </summary>
    public class PrismaticJointTest
    {
        /// <summary>
        /// Tests that prismatic joint constructor test
        /// </summary>
        [Fact]
        public void PrismaticJointConstructorTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchorA = new Vector2(0.5f, 0.5f);
            Vector2 anchorB = new Vector2(0.5f, 0.5f);
            Vector2 axis = new Vector2(1, 0);
            bool useWorldCoordinates = false;
            
            // Act
            PrismaticJoint prismaticJoint = new PrismaticJoint(bodyA, bodyB, anchorA, anchorB, axis, useWorldCoordinates);
            
            // Assert
            Assert.Equal(bodyA, prismaticJoint.BodyA);
            Assert.Equal(bodyB, prismaticJoint.BodyB);
            Assert.Equal(axis, prismaticJoint.LocalXAxisA);
        }
        
        /// <summary>
        /// Tests that prismatic joint world anchor a test
        /// </summary>
        [Fact]
        public void PrismaticJointWorldAnchorATest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchorA = new Vector2(0.5f, 0.5f);
            Vector2 anchorB = new Vector2(0.5f, 0.5f);
            Vector2 axis = new Vector2(1, 0);
            bool useWorldCoordinates = false;
            PrismaticJoint prismaticJoint = new PrismaticJoint(bodyA, bodyB, anchorA, anchorB, axis, useWorldCoordinates);
            
            // Act
            Vector2 worldAnchorA = prismaticJoint.WorldAnchorA;
            
            // Assert
            Assert.Equal(bodyA.GetWorldPoint(anchorA), worldAnchorA);
        }
        
        /// <summary>
        /// Tests that prismatic joint world anchor b test
        /// </summary>
        [Fact]
        public void PrismaticJointWorldAnchorBTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchorA = new Vector2(0.5f, 0.5f);
            Vector2 anchorB = new Vector2(0.5f, 0.5f);
            Vector2 axis = new Vector2(1, 0);
            bool useWorldCoordinates = false;
            PrismaticJoint prismaticJoint = new PrismaticJoint(bodyA, bodyB, anchorA, anchorB, axis, useWorldCoordinates);
            
            // Act
            Vector2 worldAnchorB = prismaticJoint.WorldAnchorB;
            
            // Assert
            Assert.Equal(bodyB.GetWorldPoint(anchorB), worldAnchorB);
        }
        
        /// <summary>
        /// Tests that prismatic joint joint translation test
        /// </summary>
        [Fact]
        public void PrismaticJointJointTranslationTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchorA = new Vector2(0.5f, 0.5f);
            Vector2 anchorB = new Vector2(0.5f, 0.5f);
            Vector2 axis = new Vector2(1, 0);
            bool useWorldCoordinates = false;
            PrismaticJoint prismaticJoint = new PrismaticJoint(bodyA, bodyB, anchorA, anchorB, axis, useWorldCoordinates);
            
            // Act
            float jointTranslation = prismaticJoint.JointTranslation;
            
            // Assert
            Assert.Equal(Vector2.Dot(axis, bodyB.GetWorldPoint(anchorB) - bodyA.GetWorldPoint(anchorA)), jointTranslation);
        }
    }
}