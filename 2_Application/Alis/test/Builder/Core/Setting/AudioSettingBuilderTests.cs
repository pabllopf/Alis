using Alis.Builder.Core.Setting;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Setting
{
    /// <summary>
    /// The audio setting builder tests class
    /// </summary>
    public class AudioSettingBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="AudioSettingBuilderTests"/> class
        /// </summary>
        public AudioSettingBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the audio setting builder
        /// </summary>
        /// <returns>The audio setting builder</returns>
        private AudioSettingBuilder CreateAudioSettingBuilder()
        {
            return new AudioSettingBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var audioSettingBuilder = this.CreateAudioSettingBuilder();

            // Act
            var result = audioSettingBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
