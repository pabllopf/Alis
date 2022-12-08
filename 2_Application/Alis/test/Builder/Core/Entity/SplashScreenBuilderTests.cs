using Alis.Builder.Core.Entity;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Entity
{
    /// <summary>
    /// The splash screen builder tests class
    /// </summary>
    public class SplashScreenBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SplashScreenBuilderTests"/> class
        /// </summary>
        public SplashScreenBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the splash screen builder
        /// </summary>
        /// <returns>The splash screen builder</returns>
        private SplashScreenBuilder CreateSplashScreenBuilder()
        {
            return new SplashScreenBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var splashScreenBuilder = this.CreateSplashScreenBuilder();

            // Act
            var result = splashScreenBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that file path state under test expected behavior
        /// </summary>
        [Fact]
        public void FilePath_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var splashScreenBuilder = this.CreateSplashScreenBuilder();
            string value = null;

            // Act
            var result = splashScreenBuilder.FilePath(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that is active state under test expected behavior
        /// </summary>
        [Fact]
        public void IsActive_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var splashScreenBuilder = this.CreateSplashScreenBuilder();
            bool value = false;

            // Act
            var result = splashScreenBuilder.IsActive(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that style state under test expected behavior
        /// </summary>
        [Fact]
        public void Style_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var splashScreenBuilder = this.CreateSplashScreenBuilder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
