using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The distance joint tests class
    /// </summary>
    public class DistanceJointTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// The mock distance joint def
        /// </summary>
        private Mock<DistanceJointDef> mockDistanceJointDef;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistanceJointTests"/> class
        /// </summary>
        public DistanceJointTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockDistanceJointDef = this.mockRepository.Create<DistanceJointDef>();
        }

        /// <summary>
        /// Creates the distance joint
        /// </summary>
        /// <returns>The distance joint</returns>
        private DistanceJoint CreateDistanceJoint()
        {
            return new DistanceJoint(
                this.mockDistanceJointDef.Object);
        }

        /// <summary>
        /// Tests that get reaction force state under test expected behavior
        /// </summary>
        [Fact]
        public void GetReactionForce_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var distanceJoint = this.CreateDistanceJoint();
            float invDt = 0;

            // Act
            var result = distanceJoint.GetReactionForce(
                invDt);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get reaction torque state under test expected behavior
        /// </summary>
        [Fact]
        public void GetReactionTorque_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var distanceJoint = this.CreateDistanceJoint();
            float invDt = 0;

            // Act
            var result = distanceJoint.GetReactionTorque(
                invDt);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
