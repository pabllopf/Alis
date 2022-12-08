using Alis.Builder.Core.Component.Audio;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Audio
{
    /// <summary>
    /// The audio clip builder tests class
    /// </summary>
    public class AudioClipBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="AudioClipBuilderTests"/> class
        /// </summary>
        public AudioClipBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the audio clip builder
        /// </summary>
        /// <returns>The audio clip builder</returns>
        private AudioClipBuilder CreateAudioClipBuilder()
        {
            return new AudioClipBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioClipBuilder = this.CreateAudioClipBuilder();

            // Act
            var result = audioClipBuilder.Build();

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
            var audioClipBuilder = this.CreateAudioClipBuilder();
            string value = null;

            // Act
            var result = audioClipBuilder.FilePath(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that mute state under test expected behavior
        /// </summary>
        [Fact]
        public void Mute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioClipBuilder = this.CreateAudioClipBuilder();
            bool value = false;

            // Act
            var result = audioClipBuilder.Mute(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that volume state under test expected behavior
        /// </summary>
        [Fact]
        public void Volume_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioClipBuilder = this.CreateAudioClipBuilder();
            float value = 0;

            // Act
            var result = audioClipBuilder.Volume(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
