using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The prismatic joint tests class
    /// </summary>
    public class PrismaticJointTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// The mock prismatic joint def
        /// </summary>
        private Mock<PrismaticJointDef> mockPrismaticJointDef;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrismaticJointTests"/> class
        /// </summary>
        public PrismaticJointTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockPrismaticJointDef = mockRepository.Create<PrismaticJointDef>();
        }

        /// <summary>
        /// Creates the prismatic joint
        /// </summary>
        /// <returns>The prismatic joint</returns>
        private PrismaticJoint CreatePrismaticJoint()
        {
            return new PrismaticJoint(
                mockPrismaticJointDef.Object);
        }

        /// <summary>
        /// Tests that get reaction force state under test expected behavior
        /// </summary>
        [Fact]
        public void GetReactionForce_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var prismaticJoint = CreatePrismaticJoint();
            float invDt = 0;

            // Act
            var result = prismaticJoint.GetReactionForce(
                invDt);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get reaction torque state under test expected behavior
        /// </summary>
        [Fact]
        public void GetReactionTorque_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var prismaticJoint = CreatePrismaticJoint();
            float invDt = 0;

            // Act
            var result = prismaticJoint.GetReactionTorque(
                invDt);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that enable limit state under test expected behavior
        /// </summary>
        [Fact]
        public void EnableLimit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var prismaticJoint = CreatePrismaticJoint();
            bool flag = false;

            // Act
            prismaticJoint.EnableLimit(
                flag);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set limits state under test expected behavior
        /// </summary>
        [Fact]
        public void SetLimits_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var prismaticJoint = CreatePrismaticJoint();
            float lower = 0;
            float upper = 0;

            // Act
            prismaticJoint.SetLimits(
                lower,
                upper);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that enable motor state under test expected behavior
        /// </summary>
        [Fact]
        public void EnableMotor_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var prismaticJoint = CreatePrismaticJoint();
            bool flag = false;

            // Act
            prismaticJoint.EnableMotor(
                flag);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set max motor force state under test expected behavior
        /// </summary>
        [Fact]
        public void SetMaxMotorForce_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var prismaticJoint = CreatePrismaticJoint();
            float force = 0;

            // Act
            prismaticJoint.SetMaxMotorForce(
                force);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
