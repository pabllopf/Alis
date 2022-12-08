using Alis.Core.Entity;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Entity
{
    /// <summary>
    /// The transform tests class
    /// </summary>
    public class TransformTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="TransformTests"/> class
        /// </summary>
        public TransformTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the transform
        /// </summary>
        /// <returns>The transform</returns>
        private Transform CreateTransform()
        {
            return new Transform();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var transform = this.CreateTransform();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
