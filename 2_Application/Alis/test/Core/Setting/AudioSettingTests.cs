using Alis.Core.Setting;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Setting
{
    /// <summary>
    /// The audio setting tests class
    /// </summary>
    public class AudioSettingTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="AudioSettingTests"/> class
        /// </summary>
        public AudioSettingTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the audio setting
        /// </summary>
        /// <returns>The audio setting</returns>
        private AudioSetting CreateAudioSetting()
        {
            return new AudioSetting();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioSetting = this.CreateAudioSetting();

            // Act
            var result = audioSetting.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
