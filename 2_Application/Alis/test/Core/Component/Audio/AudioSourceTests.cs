using Alis.Core.Component.Audio;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Audio
{
    /// <summary>
    /// The audio source tests class
    /// </summary>
    public class AudioSourceTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// The mock audio clip
        /// </summary>
        private Mock<AudioClip> mockAudioClip;

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioSourceTests"/> class
        /// </summary>
        public AudioSourceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockAudioClip = this.mockRepository.Create<AudioClip>();
        }

        /// <summary>
        /// Creates the audio source
        /// </summary>
        /// <returns>The audio source</returns>
        private AudioSource CreateAudioSource()
        {
            return new AudioSource(
                this.mockAudioClip.Object);
        }

        /// <summary>
        /// Tests that play state under test expected behavior
        /// </summary>
        [Fact]
        public void Play_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioSource = this.CreateAudioSource();

            // Act
            audioSource.Play();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that stop state under test expected behavior
        /// </summary>
        [Fact]
        public void Stop_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioSource = this.CreateAudioSource();

            // Act
            audioSource.Stop();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that resume state under test expected behavior
        /// </summary>
        [Fact]
        public void Resume_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioSource = this.CreateAudioSource();

            // Act
            audioSource.Resume();

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
            var audioSource = this.CreateAudioSource();

            // Act
            var result = audioSource.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that awake state under test expected behavior
        /// </summary>
        [Fact]
        public void Awake_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioSource = this.CreateAudioSource();

            // Act
            audioSource.Awake();

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
            var audioSource = this.CreateAudioSource();

            // Act
            audioSource.Start();

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
            var audioSource = this.CreateAudioSource();

            // Act
            audioSource.Update();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
