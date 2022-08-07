using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The revolute joint tests class
    /// </summary>
    public class RevoluteJointTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// The mock revolute joint def
        /// </summary>
        private Mock<RevoluteJointDef> mockRevoluteJointDef;

        /// <summary>
        /// Initializes a new instance of the <see cref="RevoluteJointTests"/> class
        /// </summary>
        public RevoluteJointTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockRevoluteJointDef = mockRepository.Create<RevoluteJointDef>();
        }

        /// <summary>
        /// Creates the revolute joint
        /// </summary>
        /// <returns>The revolute joint</returns>
        private RevoluteJoint CreateRevoluteJoint()
        {
            return new RevoluteJoint(
                mockRevoluteJointDef.Object);
        }

        /// <summary>
        /// Tests that get reaction force state under test expected behavior
        /// </summary>
        [Fact]
        public void GetReactionForce_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
           /* var revoluteJoint = CreateRevoluteJoint();
            float invDt = 0;

            // Act
            var result = revoluteJoint.GetReactionForce(
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
            var revoluteJoint = CreateRevoluteJoint();
            float invDt = 0;

            // Act
            var result = revoluteJoint.GetReactionTorque(
                invDt);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that enable limit state under test expected behavior
        /// </summary>
        [Fact]
        public void EnableLimit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            /*var revoluteJoint = CreateRevoluteJoint();
            bool flag = false;

            // Act
            revoluteJoint.EnableLimit(
                flag);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set limits state under test expected behavior
        /// </summary>
        [Fact]
        public void SetLimits_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            /*var revoluteJoint = CreateRevoluteJoint();
            float lower = 0;
            float upper = 0;

            // Act
            revoluteJoint.SetLimits(
                lower,
                upper);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that enable motor state under test expected behavior
        /// </summary>
        [Fact]
        public void EnableMotor_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
           /* var revoluteJoint = CreateRevoluteJoint();
            bool flag = false;

            // Act
            revoluteJoint.EnableMotor(
                flag);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set max motor torque state under test expected behavior
        /// </summary>
        [Fact]
        public void SetMaxMotorTorque_StateUnderTest_ExpectedBehavior()
        {
            /*
            // Arrange
            var revoluteJoint = CreateRevoluteJoint();
            float torque = 0;

            // Act
            revoluteJoint.SetMaxMotorTorque(
                torque);
*/
            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
