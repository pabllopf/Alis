using Alis.Builder.Core.Component.Audio;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Audio
{
    /// <summary>
    /// The audio source builder tests class
    /// </summary>
    public class AudioSourceBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="AudioSourceBuilderTests"/> class
        /// </summary>
        public AudioSourceBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the audio source builder
        /// </summary>
        /// <returns>The audio source builder</returns>
        private AudioSourceBuilder CreateAudioSourceBuilder()
        {
            return new AudioSourceBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioSourceBuilder = this.CreateAudioSourceBuilder();

            // Act
            var result = audioSourceBuilder.Build();

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
            var audioSourceBuilder = this.CreateAudioSourceBuilder();
            bool value = false;

            // Act
            var result = audioSourceBuilder.IsActive(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that play on awake state under test expected behavior
        /// </summary>
        [Fact]
        public void PlayOnAwake_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioSourceBuilder = this.CreateAudioSourceBuilder();
            bool value = false;

            // Act
            var result = audioSourceBuilder.PlayOnAwake(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set audio clip state under test expected behavior
        /// </summary>
        [Fact]
        public void SetAudioClip_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioSourceBuilder = this.CreateAudioSourceBuilder();


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
