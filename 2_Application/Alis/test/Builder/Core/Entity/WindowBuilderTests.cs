using Alis.Builder.Core.Entity;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Entity
{
    /// <summary>
    /// The window builder tests class
    /// </summary>
    public class WindowBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="WindowBuilderTests"/> class
        /// </summary>
        public WindowBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the window builder
        /// </summary>
        /// <returns>The window builder</returns>
        private WindowBuilder CreateWindowBuilder()
        {
            return new WindowBuilder();
        }

        /// <summary>
        /// Tests that background state under test expected behavior
        /// </summary>
        [Fact]
        public void Background_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var windowBuilder = this.CreateWindowBuilder();


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var windowBuilder = this.CreateWindowBuilder();

            // Act
            var result = windowBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that resolution state under test expected behavior
        /// </summary>
        [Fact]
        public void Resolution_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var windowBuilder = this.CreateWindowBuilder();
            float x = 0;
            float y = 0;

            // Act
            var result = windowBuilder.Resolution(
                x,
                y);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
