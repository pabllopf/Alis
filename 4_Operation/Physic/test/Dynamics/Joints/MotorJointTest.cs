// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MotorJointTest.cs
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
    ///     The motor joint test class
    /// </summary>
    public class MotorJointTest
    {
        /// <summary>
        ///     Tests that motor joint constructor test
        /// </summary>
        [Fact]
        public void MotorJointConstructorTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 linearOffset = new Vector2(0.5f, 0.5f);
            float angularOffset = 0.0f;
            float maxForce = 1.0f;
            float maxTorque = 1.0f;
            float correctionFactor = 0.3f;
            
            // Act
            MotorJoint motorJoint = new MotorJoint(bodyA, bodyB, JointType.Motor, false, linearOffset, angularOffset, maxForce, maxTorque, correctionFactor);
            
            // Assert
            Assert.Equal(bodyA, motorJoint.BodyA);
            Assert.Equal(bodyB, motorJoint.BodyB);
            Assert.Equal(linearOffset, motorJoint.LinearOffset);
            Assert.Equal(angularOffset, motorJoint.AngularOffset);
            Assert.Equal(maxForce, motorJoint.Force);
            Assert.Equal(maxTorque, motorJoint.Torque);
            Assert.Equal(correctionFactor, motorJoint.CorrectionFactor);
        }
        
        /// <summary>
        ///     Tests that motor joint world anchor a test
        /// </summary>
        [Fact]
        public void MotorJointWorldAnchorATest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            MotorJoint motorJoint = new MotorJoint(bodyA, bodyB, true);
            
            // Act
            Vector2 worldAnchorA = motorJoint.WorldAnchorA;
            
            // Assert
            Assert.Equal(bodyA.Position, worldAnchorA);
        }
        
        /// <summary>
        ///     Tests that motor joint world anchor b test
        /// </summary>
        [Fact]
        public void MotorJointWorldAnchorBTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            MotorJoint motorJoint = new MotorJoint(bodyA, bodyB, true);
            
            // Act
            Vector2 worldAnchorB = motorJoint.WorldAnchorB;
            
            // Assert
            Assert.Equal(bodyB.Position, worldAnchorB);
        }
        
        /// <summary>
        ///     Tests that motor joint force test
        /// </summary>
        [Fact]
        public void MotorJointForceTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            float maxForce = 1.0f;
            MotorJoint motorJoint = new MotorJoint(bodyA, bodyB, JointType.Motor, false, new Vector2(0.5f, 0.5f), 0.0f, maxForce);
            
            // Act
            float force = motorJoint.Force;
            
            // Assert
            Assert.Equal(maxForce, force);
        }
        
        /// <summary>
        ///     Tests that motor joint torque test
        /// </summary>
        [Fact]
        public void MotorJointTorqueTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            float maxTorque = 1.0f;
            MotorJoint motorJoint = new MotorJoint(bodyA, bodyB, JointType.Motor, false, new Vector2(0.5f, 0.5f), 0.0f, 1.0f, maxTorque);
            
            // Act
            float torque = motorJoint.Torque;
            
            // Assert
            Assert.Equal(maxTorque, torque);
        }
        
        /// <summary>
        ///     Tests that motor joint correction factor test
        /// </summary>
        [Fact]
        public void MotorJointCorrectionFactorTest()
        {
            // Arrange
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            float correctionFactor = 0.3f;
            MotorJoint motorJoint = new MotorJoint(bodyA, bodyB, JointType.Motor, false, new Vector2(0.5f, 0.5f), 0.0f, 1.0f, 1.0f, correctionFactor);
            
            // Act
            float factor = motorJoint.CorrectionFactor;
            
            // Assert
            Assert.Equal(correctionFactor, factor);
        }
    }
}