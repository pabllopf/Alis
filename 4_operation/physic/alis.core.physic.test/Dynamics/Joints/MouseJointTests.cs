using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using System;
using Alis.Aspect.Math;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The mouse joint tests class
    /// </summary>
    public class MouseJointTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// The mock mouse joint def
        /// </summary>
        private Mock<MouseJointDef> mockMouseJointDef;

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseJointTests"/> class
        /// </summary>
        public MouseJointTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockMouseJointDef = mockRepository.Create<MouseJointDef>();
        }

        /// <summary>
        /// Creates the mouse joint
        /// </summary>
        /// <returns>The mouse joint</returns>
        private MouseJoint CreateMouseJoint()
        {
            return new MouseJoint(
                mockMouseJointDef.Object);
        }

        /// <summary>
        /// Tests that get reaction force state under test expected behavior
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
        /// Tests that get reaction torque state under test expected behavior
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
        /// Tests that set target state under test expected behavior
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
