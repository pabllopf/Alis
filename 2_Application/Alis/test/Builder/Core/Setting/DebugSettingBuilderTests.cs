using Alis.Builder.Core.Setting;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Setting
{
    /// <summary>
    /// The debug setting builder tests class
    /// </summary>
    public class DebugSettingBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="DebugSettingBuilderTests"/> class
        /// </summary>
        public DebugSettingBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the debug setting builder
        /// </summary>
        /// <returns>The debug setting builder</returns>
        private DebugSettingBuilder CreateDebugSettingBuilder()
        {
            return new DebugSettingBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var debugSettingBuilder = this.CreateDebugSettingBuilder();

            // Act
            var result = debugSettingBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
