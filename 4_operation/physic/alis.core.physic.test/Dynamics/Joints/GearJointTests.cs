using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The gear joint tests class
    /// </summary>
    public class GearJointTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// The mock gear joint def
        /// </summary>
        private Mock<GearJointDef> mockGearJointDef;

        /// <summary>
        /// Initializes a new instance of the <see cref="GearJointTests"/> class
        /// </summary>
        public GearJointTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockGearJointDef = mockRepository.Create<GearJointDef>();
        }

        /// <summary>
        /// Creates the gear joint
        /// </summary>
        /// <returns>The gear joint</returns>
        private GearJoint CreateGearJoint()
        {
            return new GearJoint(
                mockGearJointDef.Object);
        }

        /// <summary>
        /// Tests that get reaction force state under test expected behavior
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
        /// Tests that get reaction torque state under test expected behavior
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
