using Alis.Builder.Core.Setting;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Setting
{
    /// <summary>
    /// The setting builder tests class
    /// </summary>
    public class SettingBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SettingBuilderTests"/> class
        /// </summary>
        public SettingBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the setting builder
        /// </summary>
        /// <returns>The setting builder</returns>
        private SettingBuilder CreateSettingBuilder()
        {
            return new SettingBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var settingBuilder = this.CreateSettingBuilder();

            // Act
            var result = settingBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
