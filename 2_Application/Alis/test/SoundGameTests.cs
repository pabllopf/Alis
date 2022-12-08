using Alis;
using Moq;
using System;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The sound game tests class
    /// </summary>
    public class SoundGameTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SoundGameTests"/> class
        /// </summary>
        public SoundGameTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the sound game
        /// </summary>
        /// <returns>The sound game</returns>
        private SoundGame CreateSoundGame()
        {
            return new SoundGame();
        }

        /// <summary>
        /// Tests that run state under test expected behavior
        /// </summary>
        [Fact]
        public void Run_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var soundGame = this.CreateSoundGame();

            // Act
            soundGame.Run();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var soundGame = this.CreateSoundGame();

            // Act
            var result = SoundGame.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
