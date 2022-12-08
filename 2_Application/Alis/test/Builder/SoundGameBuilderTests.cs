using Alis.Builder;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder
{
    /// <summary>
    /// The sound game builder tests class
    /// </summary>
    public class SoundGameBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SoundGameBuilderTests"/> class
        /// </summary>
        public SoundGameBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the sound game builder
        /// </summary>
        /// <returns>The sound game builder</returns>
        private SoundGameBuilder CreateSoundGameBuilder()
        {
            return new SoundGameBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var soundGameBuilder = this.CreateSoundGameBuilder();

            // Act
            var result = soundGameBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that run state under test expected behavior
        /// </summary>
        [Fact]
        public void Run_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var soundGameBuilder = this.CreateSoundGameBuilder();

            // Act
            soundGameBuilder.Run();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
