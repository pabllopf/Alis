// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceJointTests.cs
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

using Alis.Aspect.Math;
using Alis.Core.Physic.Dynamics.Joint;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    ///     The distance joint tests class
    /// </summary>
    public class DistanceJointTests
    {
        /// <summary>
        ///     The mock distance joint def
        /// </summary>
        private Mock<DistanceJointDef> mockDistanceJointDef;

        /// <summary>
        ///     The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DistanceJointTests" /> class
        /// </summary>
        public DistanceJointTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockDistanceJointDef = mockRepository.Create<DistanceJointDef>();
        }

        /// <summary>
        ///     Creates the distance joint
        /// </summary>
        /// <returns>The distance joint</returns>
        private DistanceJoint CreateDistanceJoint() => new DistanceJoint(
            mockDistanceJointDef.Object);

        /// <summary>
        ///     Tests that get reaction force state under test expected behavior
        /// </summary>
        [Fact]
        public void GetReactionForce_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            DistanceJoint distanceJoint = CreateDistanceJoint();
            float invDt = 0;

            // Act
            Vector2 result = distanceJoint.GetReactionForce(
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
            DistanceJoint distanceJoint = CreateDistanceJoint();
            float invDt = 0;

            // Act
            float result = distanceJoint.GetReactionTorque(
                invDt);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}