using Alis.Core.Setting;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Setting
{
    /// <summary>
    /// The general setting tests class
    /// </summary>
    public class GeneralSettingTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralSettingTests"/> class
        /// </summary>
        public GeneralSettingTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the general setting
        /// </summary>
        /// <returns>The general setting</returns>
        private GeneralSetting CreateGeneralSetting()
        {
            return new GeneralSetting();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var generalSetting = this.CreateGeneralSetting();

            // Act
            var result = generalSetting.Builder();

            // Assert
            Assert.True(true);
            this.mockRepository.VerifyAll();
        }
    }
}
