using Alis.Core.Component.Audio;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Audio
{
    /// <summary>
    /// The audio clip tests class
    /// </summary>
    public class AudioClipTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="AudioClipTests"/> class
        /// </summary>
        public AudioClipTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the audio clip
        /// </summary>
        /// <returns>The audio clip</returns>
        private AudioClip CreateAudioClip()
        {
            return new AudioClip("");
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioClip = this.CreateAudioClip();

            // Act
            //var result = audioClip.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
