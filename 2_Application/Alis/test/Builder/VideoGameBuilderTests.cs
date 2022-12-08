using Alis.Builder;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder
{
    /// <summary>
    /// The video game builder tests class
    /// </summary>
    public class VideoGameBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="VideoGameBuilderTests"/> class
        /// </summary>
        public VideoGameBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the video game builder
        /// </summary>
        /// <returns>The video game builder</returns>
        private VideoGameBuilder CreateVideoGameBuilder()
        {
            return new VideoGameBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var videoGameBuilder = this.CreateVideoGameBuilder();

            // Act
            var result = videoGameBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that manager state under test expected behavior
        /// </summary>
        [Fact]
        public void Manager_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var videoGameBuilder = this.CreateVideoGameBuilder();
            //Func value = null;

            // Act
            //var result = videoGameBuilder.Manager(
              //  value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that settings state under test expected behavior
        /// </summary>
        [Fact]
        public void Settings_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var videoGameBuilder = this.CreateVideoGameBuilder();
            //Func value = null;

            // Act
            //var result = videoGameBuilder.Settings(
             //   value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that run state under test expected behavior
        /// </summary>
        [Fact]
        public void Run_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var videoGameBuilder = this.CreateVideoGameBuilder();

            // Act
            videoGameBuilder.Run();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
