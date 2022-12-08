using Alis.Core.Component.Body;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Body
{
    /// <summary>
    /// The body base tests class
    /// </summary>
    public class BodyBaseTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="BodyBaseTests"/> class
        /// </summary>
        public BodyBaseTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the body base
        /// </summary>
        /// <returns>The body base</returns>
        private BodyBase CreateBodyBase()
        {
            return new BodyBase();
        }

        /// <summary>
        /// Tests that start state under test expected behavior
        /// </summary>
        [Fact]
        public void Start_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var bodyBase = this.CreateBodyBase();

            // Act
            bodyBase.Start();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that update state under test expected behavior
        /// </summary>
        [Fact]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var bodyBase = this.CreateBodyBase();

            // Act
            bodyBase.Update();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
