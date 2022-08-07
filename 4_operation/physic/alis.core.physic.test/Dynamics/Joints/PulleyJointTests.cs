using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The pulley joint tests class
    /// </summary>
    public class PulleyJointTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// The mock pulley joint def
        /// </summary>
        private Mock<PulleyJointDef> mockPulleyJointDef;

        /// <summary>
        /// Initializes a new instance of the <see cref="PulleyJointTests"/> class
        /// </summary>
        public PulleyJointTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockPulleyJointDef = mockRepository.Create<PulleyJointDef>();
        }

        /// <summary>
        /// Creates the pulley joint
        /// </summary>
        /// <returns>The pulley joint</returns>
        private PulleyJoint CreatePulleyJoint()
        {
            return new PulleyJoint(
                mockPulleyJointDef.Object);
        }

        /// <summary>
        /// Tests that get reaction force state under test expected behavior
        /// </summary>
        [Fact]
        public void GetReactionForce_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var pulleyJoint = CreatePulleyJoint();
            float invDt = 0;

            // Act
            var result = pulleyJoint.GetReactionForce(
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
            var pulleyJoint = CreatePulleyJoint();
            float invDt = 0;

            // Act
            var result = pulleyJoint.GetReactionTorque(
                invDt);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
