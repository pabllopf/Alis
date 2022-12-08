using Alis.Builder.Core.Component.Audio;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Audio
{
    /// <summary>
    /// The audio recorder builder tests class
    /// </summary>
    public class AudioRecorderBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="AudioRecorderBuilderTests"/> class
        /// </summary>
        public AudioRecorderBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the audio recorder builder
        /// </summary>
        /// <returns>The audio recorder builder</returns>
        private AudioRecorderBuilder CreateAudioRecorderBuilder()
        {
            return new AudioRecorderBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioRecorderBuilder = this.CreateAudioRecorderBuilder();

            // Act
            var result = audioRecorderBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
