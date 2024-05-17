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

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Alis.Core.Physic.Dynamics.Solver;
using Alis.Core.Physic.Test.Collision.BroadPhase.Sample;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    ///     The wheel joint test class
    /// </summary>
    public class WheelJointTest
    {
        /// <summary>
        ///     Tests that wheel joint constructor test
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
        ///     Tests that wheel joint properties test
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
        ///     Tests that wheel joint joint translation test
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
        
        /// <summary>
        /// Tests that wheel joint default constructor valid input
        /// </summary>
        [Fact]
        public void WheelJoint_DefaultConstructor_ValidInput()
        {
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchor = new Vector2(0, 0);
            Vector2 axis = new Vector2(1, 0);
            WheelJoint wheelJoint = new WheelJoint(bodyA, bodyB, anchor, axis);
            
            Assert.NotNull(wheelJoint);
        }
        
        /// <summary>
        /// Tests that wheel joint properties valid input
        /// </summary>
        [Fact]
        public void WheelJoint_Properties_ValidInput()
        {
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchor = new Vector2(0, 0);
            Vector2 axis = new Vector2(1, 0);
            WheelJoint wheelJoint = new WheelJoint(bodyA, bodyB, anchor, axis);
            
            wheelJoint.MotorSpeed = 10;
            wheelJoint.MotorTorque = 20;
            wheelJoint.UpperLimit = 30;
            wheelJoint.LowerLimit = 40;
            wheelJoint.Damping = 50;
            wheelJoint.Stiffness = 60;
            
            Assert.Equal(10, wheelJoint.MotorSpeed);
            Assert.Equal(20, wheelJoint.MotorTorque);
            Assert.Equal(30, wheelJoint.UpperLimit);
            Assert.Equal(40, wheelJoint.LowerLimit);
            Assert.Equal(50, wheelJoint.Damping);
            Assert.Equal(60, wheelJoint.Stiffness);
        }
        
        /// <summary>
        /// Tests that wheel joint methods valid input
        /// </summary>
        [Fact]
        public void WheelJoint_Methods_ValidInput()
        {
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchor = new Vector2(0, 0);
            Vector2 axis = new Vector2(1, 0);
            WheelJoint wheelJoint = new WheelJoint(bodyA, bodyB, anchor, axis);
            
            wheelJoint.SetLimits(10, 20);
            
            Assert.Equal(10, wheelJoint.LowerLimit);
            Assert.Equal(20, wheelJoint.UpperLimit);
        }
        
        /// <summary>
        /// Tests that wheel joint default constructor valid input v 2
        /// </summary>
        [Fact]
        public void WheelJoint_DefaultConstructor_ValidInput_v2()
        {
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchor = new Vector2(0, 0);
            Vector2 axis = new Vector2(1, 0);
            WheelJoint wheelJoint = new WheelJoint(bodyA, bodyB, anchor, axis);
            
            Assert.NotNull(wheelJoint);
        }
        
        /// <summary>
        /// Tests that wheel joint properties valid input v 2
        /// </summary>
        [Fact]
        public void WheelJoint_Properties_ValidInput_v2()
        {
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchor = new Vector2(0, 0);
            Vector2 axis = new Vector2(1, 0);
            WheelJoint wheelJoint = new WheelJoint(bodyA, bodyB, anchor, axis);
            
            wheelJoint.MotorSpeed = 10;
            wheelJoint.MotorTorque = 20;
            wheelJoint.UpperLimit = 30;
            wheelJoint.LowerLimit = 40;
            wheelJoint.Damping = 50;
            wheelJoint.Stiffness = 60;
            
            Assert.Equal(10, wheelJoint.MotorSpeed);
            Assert.Equal(20, wheelJoint.MotorTorque);
            Assert.Equal(30, wheelJoint.UpperLimit);
            Assert.Equal(40, wheelJoint.LowerLimit);
            Assert.Equal(50, wheelJoint.Damping);
            Assert.Equal(60, wheelJoint.Stiffness);
        }
        
        /// <summary>
        /// Tests that wheel joint methods valid input v 2
        /// </summary>
        [Fact]
        public void WheelJoint_Methods_ValidInput_v2()
        {
            Body bodyA = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Body bodyB = new Body(new Vector2(1, 1), new Vector2(1, 1));
            Vector2 anchor = new Vector2(0, 0);
            Vector2 axis = new Vector2(1, 0);
            WheelJoint wheelJoint = new WheelJoint(bodyA, bodyB, anchor, axis);
            
            wheelJoint.SetLimits(10, 20);
            
            Assert.Equal(10, wheelJoint.LowerLimit);
            Assert.Equal(20, wheelJoint.UpperLimit);
        }
        
        /// <summary>
        /// Tests that solve position constraints should calculate correctly
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_ShouldCalculateCorrectly()
        {
            // Arrange
            WheelJoint wheelJoint = new WheelJoint();
            SolverData data = new SolverData
            {
                Positions = new List<Position>(new Position[2]
                {
                    new Position {A = 1.0f, C = new Vector2(1.0f, 1.0f)},
                    new Position {A = 1.0f, C = new Vector2(1.0f, 1.0f)}
                })
            };
            
            // Act
            bool result = wheelJoint.SolvePositionConstraints(ref data);
            
            // Assert
            
            Assert.True(result);
            Assert.Equal(1.0f, data.Positions[0].A);
            Assert.Equal(new Vector2(1.0f, 1.0f), data.Positions[0].C);
            Assert.Equal(1.0f, data.Positions[1].A);
            Assert.Equal(new Vector2(1.0f, 1.0f), data.Positions[1].C);
        }
        
        /// <summary>
        /// Tests that get motor torque should calculate correctly
        /// </summary>
        [Fact]
        public void GetMotorTorque_ShouldCalculateCorrectly()
        {
            // Arrange
            WheelJoint wheelJoint = new WheelJoint();
            float invDt = 1.0f; // example value
            
            // Act
            float result = wheelJoint.GetMotorTorque(invDt);
            
            // Assert
            
            Assert.Equal(invDt * wheelJoint.MotorTorque, result);
        }
        
        /// <summary>
        /// Tests that get reaction torque should calculate correctly
        /// </summary>
        [Fact]
        public void GetReactionTorque_ShouldCalculateCorrectly()
        {
            // Arrange
            WheelJoint wheelJoint = new WheelJoint();
            float invDt = 1.0f; // example value
            
            // Act
            float result = wheelJoint.GetReactionTorque(invDt);
            
            // Assert
            
            Assert.Equal(invDt * wheelJoint.MotorTorque, result);
        }
        
        /// <summary>
        /// Tests that solve position constraints should calculate correctly v 2
        /// </summary>
        [Fact]
        public void SolvePositionConstraints_ShouldCalculateCorrectly_v2()
        {
            WheelJoint wheelJoint = new WheelJoint();
            SolverData data = new SolverData
            {
                Positions = new List<Position>() {new Position {A = 1.0f, C = new Vector2(1.0f, 1.0f)}, new Position {A = 1.0f, C = new Vector2(1.0f, 1.0f)}}
            };
            
            bool result = wheelJoint.SolvePositionConstraints(ref data);
            
            Assert.True(result);
            Assert.Equal(1.0f, data.Positions[0].A);
            Assert.Equal(new Vector2(1.0f, 1.0f), data.Positions[0].C);
            Assert.Equal(1.0f, data.Positions[1].A);
            Assert.Equal(new Vector2(1.0f, 1.0f), data.Positions[1].C);
        }
        
        /// <summary>
        /// Tests that apply warm starting should calculate correctly
        /// </summary>
        [Fact]
        public void ApplyWarmStarting_ShouldCalculateCorrectly()
        {
            // Arrange
            WheelJoint wheelJoint = new WheelJoint();
            SolverData data = new SolverData
            {
                Step = new TimeStep
                {
                    DeltaTimeRatio = 1.0f
                },
                Velocities = new List<Velocity>() { new Velocity(new Vector2(1.0f, 1.0f), 1.0f), new Velocity(new Vector2(1.0f, 1.0f), 1.0f) }
            };
            
            // Act
            wheelJoint.ApplyWarmStarting(ref data);
            
            // Assert
            Assert.Equal(1.0f, data.Velocities[0].V.X);
            Assert.Equal(1.0f, data.Velocities[0].V.Y);
            Assert.Equal(1.0f, data.Velocities[0].W);
            Assert.Equal(1.0f, data.Velocities[1].V.X);
            Assert.Equal(1.0f, data.Velocities[1].V.Y);
            Assert.Equal(1.0f, data.Velocities[1].W);
        }
    }
}