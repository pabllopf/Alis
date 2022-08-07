using Alis.Core.Physic.Dynamics.Joints;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    /// The joint def tests class
    /// </summary>
    public class JointDefTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="JointDefTests"/> class
        /// </summary>
        public JointDefTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the joint def
        /// </summary>
        /// <returns>The joint def</returns>
        private JointDef CreateJointDef()
        {
            return new JointDef();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var jointDef = this.CreateJointDef();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
