using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The mouse joint def tests class
    /// </summary>
    public class MouseJointDefTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="MouseJointDefTests"/> class
        /// </summary>
        public MouseJointDefTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the mouse joint def
        /// </summary>
        /// <returns>The mouse joint def</returns>
        private MouseJointDef CreateMouseJointDef()
        {
            return new MouseJointDef();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var mouseJointDef = this.CreateMouseJointDef();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
