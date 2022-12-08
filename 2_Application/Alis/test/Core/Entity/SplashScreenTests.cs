using Alis.Core.Entity;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Entity
{
    /// <summary>
    /// The splash screen tests class
    /// </summary>
    public class SplashScreenTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SplashScreenTests"/> class
        /// </summary>
        public SplashScreenTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the splash screen
        /// </summary>
        /// <returns>The splash screen</returns>
        private SplashScreen CreateSplashScreen()
        {
            return new SplashScreen();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var splashScreen = this.CreateSplashScreen();

            // Act
            var result = splashScreen.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
