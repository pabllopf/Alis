using Alis;
using Moq;
using System;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The video game tests class
    /// </summary>
    public class VideoGameTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="VideoGameTests"/> class
        /// </summary>
        public VideoGameTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the video game
        /// </summary>
        /// <returns>The video game</returns>
        private VideoGame CreateVideoGame()
        {
            return new VideoGame();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var videoGame = this.CreateVideoGame();

            // Act
            var result = VideoGame.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
