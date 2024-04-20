// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JointEdgeTest.cs
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
    /// The joint edge test class
    /// </summary>
    public class JointEdgeTest
    {
        /// <summary>
        /// Tests that joint edge constructor test
        /// </summary>
        [Fact]
        public void JointEdgeConstructorTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Joint joint = new RevoluteJoint(bodyA, bodyB, new Vector2(0.5f, 0.5f), true);
            
            // Act
            JointEdge jointEdge = new JointEdge();
            
            Assert.Null( jointEdge.Other);
        }
        
        /// <summary>
        /// Tests that joint edge constructor test 2
        /// </summary>
        [Fact]
        public void JointEdgeConstructorTest2()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Joint joint = new RevoluteJoint(bodyA, bodyB, new Vector2(0.5f, 0.5f), true);
            
            // Act
            JointEdge jointEdge = new JointEdge();
            
            Assert.Null(jointEdge.Joint1);
        }
        
        /// <summary>
        /// Tests that joint edge constructor test 3
        /// </summary>
        [Fact]
        public void JointEdgeConstructorTest3()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Joint joint = new RevoluteJoint(bodyA, bodyB, new Vector2(0.5f, 0.5f), true);
            
            // Act
            JointEdge jointEdge = new JointEdge();
            
            Assert.Null(jointEdge.Next);
        }
        
        /// <summary>
        /// Tests that joint edge constructor test 4
        /// </summary>
        [Fact]
        public void JointEdgeConstructorTest4()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Joint joint = new RevoluteJoint(bodyA, bodyB, new Vector2(0.5f, 0.5f), true);
            
            // Act
            JointEdge jointEdge = new JointEdge();
            
            Assert.Null(jointEdge.Prev);
        }
    }
}