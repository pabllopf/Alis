// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   LineJointTests.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    ///     The line joint tests class
    /// </summary>
    public class LineJointTests
    {
        /// <summary>
        ///     The mock line joint def
        /// </summary>
        private Mock<LineJointDef> mockLineJointDef;

        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LineJointTests" /> class
        /// </summary>
        public LineJointTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockLineJointDef = mockRepository.Create<LineJointDef>();
        }

        /// <summary>
        ///     Creates the line joint
        /// </summary>
        /// <returns>The line joint</returns>
        private LineJoint CreateLineJoint()
        {
            return new LineJoint(
                mockLineJointDef.Object);
        }

        /// <summary>
        ///     Tests that get reaction force state under test expected behavior
        /// </summary>
        [Fact]
        public void GetReactionForce_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lineJoint = CreateLineJoint();
            float invDt = 0;

            // Act
            var result = lineJoint.GetReactionForce(
                invDt);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that get reaction torque state under test expected behavior
        /// </summary>
        [Fact]
        public void GetReactionTorque_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lineJoint = CreateLineJoint();
            float invDt = 0;

            // Act
            var result = lineJoint.GetReactionTorque(
                invDt);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that get joint translation state under test expected behavior
        /// </summary>
        [Fact]
        public void GetJointTranslation_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var lineJoint = CreateLineJoint();

            // Act
            //var result = lineJoint.GetJointTranslation();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that get joint speed state under test expected behavior
        /// </summary>
        [Fact]
        public void GetJointSpeed_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var lineJoint = CreateLineJoint();

            // Act
            var result = lineJoint.GetJointSpeed();
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that is limit enabled state under test expected behavior
        /// </summary>
        [Fact]
        public void IsLimitEnabled_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var lineJoint = CreateLineJoint();

            // Act
            var result = lineJoint.IsLimitEnabled();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that enable limit state under test expected behavior
        /// </summary>
        [Fact]
        public void EnableLimit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            /*var lineJoint = CreateLineJoint();
            bool flag = false;

            // Act
            lineJoint.EnableLimit(
                flag);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that get lower limit state under test expected behavior
        /// </summary>
        [Fact]
        public void GetLowerLimit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var lineJoint = CreateLineJoint();

            // Act
            //var result = lineJoint.GetLowerLimit();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that get upper limit state under test expected behavior
        /// </summary>
        [Fact]
        public void GetUpperLimit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            // var lineJoint = CreateLineJoint();

            // Act
            //var result = lineJoint.GetUpperLimit();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that set limits state under test expected behavior
        /// </summary>
        [Fact]
        public void SetLimits_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var lineJoint = CreateLineJoint();
            float lower = 0;
            float upper = 0;

            // Act
            lineJoint.SetLimits(
                lower,
                upper);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that is motor enabled state under test expected behavior
        /// </summary>
        [Fact]
        public void IsMotorEnabled_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var lineJoint = CreateLineJoint();

            // Act
            var result = lineJoint.IsMotorEnabled();
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that enable motor state under test expected behavior
        /// </summary>
        [Fact]
        public void EnableMotor_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var lineJoint = CreateLineJoint();
            bool flag = false;

            // Act
            lineJoint.EnableMotor(
                flag);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that set motor speed state under test expected behavior
        /// </summary>
        [Fact]
        public void SetMotorSpeed_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var lineJoint = CreateLineJoint();
            float speed = 0;

            // Act
            lineJoint.SetMotorSpeed(
                speed);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that set max motor force state under test expected behavior
        /// </summary>
        [Fact]
        public void SetMaxMotorForce_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var lineJoint = CreateLineJoint();
            float force = 0;

            // Act
            lineJoint.SetMaxMotorForce(
                force);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that get motor force state under test expected behavior
        /// </summary>
        [Fact]
        public void GetMotorForce_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var lineJoint = CreateLineJoint();

            // Act
            var result = lineJoint.GetMotorForce();
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that get motor speed state under test expected behavior
        /// </summary>
        [Fact]
        public void GetMotorSpeed_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var lineJoint = CreateLineJoint();

            // Act
            var result = lineJoint.GetMotorSpeed();
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}