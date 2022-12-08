using Alis.Core.Component.Audio;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Audio
{
    /// <summary>
    /// The audio recorder tests class
    /// </summary>
    public class AudioRecorderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="AudioRecorderTests"/> class
        /// </summary>
        public AudioRecorderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the audio recorder
        /// </summary>
        /// <returns>The audio recorder</returns>
        private AudioRecorder CreateAudioRecorder()
        {
            return new AudioRecorder();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioRecorder = this.CreateAudioRecorder();

            // Act
            var result = audioRecorder.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that start state under test expected behavior
        /// </summary>
        [Fact]
        public void Start_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioRecorder = this.CreateAudioRecorder();

            // Act
            audioRecorder.Start();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that update state under test expected behavior
        /// </summary>
        [Fact]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioRecorder = this.CreateAudioRecorder();

            // Act
            audioRecorder.Update();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
