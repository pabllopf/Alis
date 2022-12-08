using Alis.Core.Entity;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Entity
{
    /// <summary>
    /// The window tests class
    /// </summary>
    public class WindowTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="WindowTests"/> class
        /// </summary>
        public WindowTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the window
        /// </summary>
        /// <returns>The window</returns>
        private Window CreateWindow()
        {
            return new Window();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var window = this.CreateWindow();

            // Act
            var result = window.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
