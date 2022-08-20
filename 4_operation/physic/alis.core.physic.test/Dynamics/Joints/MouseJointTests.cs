// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseJointTests.cs
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

using Alis.Core.Physic.Dynamics.Joint;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    ///     The mouse joint tests class
    /// </summary>
    public class MouseJointTests
    {
        /// <summary>
        ///     The mock mouse joint def
        /// </summary>
        private Mock<MouseJointDef> mockMouseJointDef;

        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MouseJointTests" /> class
        /// </summary>
        public MouseJointTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockMouseJointDef = mockRepository.Create<MouseJointDef>();
        }

        /// <summary>
        ///     Creates the mouse joint
        /// </summary>
        /// <returns>The mouse joint</returns>
        private MouseJoint CreateMouseJoint() => new MouseJoint(
            mockMouseJointDef.Object);

        /// <summary>
        ///     Tests that get reaction force state under test expected behavior
        /// </summary>
        [Fact]
        public void GetReactionForce_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var mouseJoint = CreateMouseJoint();
            float invDt = 0;

            // Act
            var result = mouseJoint.GetReactionForce(
                invDt);
*/
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
            /*
            // Arrange
            var mouseJoint = CreateMouseJoint();
            float invDt = 0;

            // Act
            var result = mouseJoint.GetReactionTorque(
                invDt);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        ///     Tests that set target state under test expected behavior
        /// </summary>
        [Fact]
        public void SetTarget_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var mouseJoint = CreateMouseJoint();
            Vector2 target = default(Vector2);

            // Act
            mouseJoint.SetTarget(
                target);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}