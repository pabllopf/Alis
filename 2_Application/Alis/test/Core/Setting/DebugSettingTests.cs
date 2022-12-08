using Alis.Core.Setting;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Setting
{
    /// <summary>
    /// The debug setting tests class
    /// </summary>
    public class DebugSettingTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="DebugSettingTests"/> class
        /// </summary>
        public DebugSettingTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the debug setting
        /// </summary>
        /// <returns>The debug setting</returns>
        private DebugSetting CreateDebugSetting()
        {
            return new DebugSetting();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var debugSetting = this.CreateDebugSetting();

            // Act
            var result = debugSetting.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
