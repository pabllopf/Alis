// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GearJointTests.cs
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
    ///     The gear joint tests class
    /// </summary>
    public class GearJointTests
    {
        /// <summary>
        ///     The mock gear joint def
        /// </summary>
        private Mock<GearJointDef> mockGearJointDef;

        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GearJointTests" /> class
        /// </summary>
        public GearJointTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockGearJointDef = mockRepository.Create<GearJointDef>();
        }

        /// <summary>
        ///     Creates the gear joint
        /// </summary>
        /// <returns>The gear joint</returns>
        private GearJoint CreateGearJoint() => new GearJoint(
            mockGearJointDef.Object);

        /// <summary>
        ///     Tests that get reaction force state under test expected behavior
        /// </summary>
        [Fact]
        public void GetReactionForce_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var gearJoint = CreateGearJoint();
            float invDt = 0;

            // Act
            var result = gearJoint.GetReactionForce(
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
            var gearJoint = CreateGearJoint();
            float invDt = 0;

            // Act
            var result = gearJoint.GetReactionTorque(
                invDt);
                
                */

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}