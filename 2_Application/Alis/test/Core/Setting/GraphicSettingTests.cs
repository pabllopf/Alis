using Alis.Core.Setting;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Setting
{
    /// <summary>
    /// The graphic setting tests class
    /// </summary>
    public class GraphicSettingTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicSettingTests"/> class
        /// </summary>
        public GraphicSettingTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the graphic setting
        /// </summary>
        /// <returns>The graphic setting</returns>
        private GraphicSetting CreateGraphicSetting()
        {
            return new GraphicSetting();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var graphicSetting = this.CreateGraphicSetting();

            // Act
            var result = graphicSetting.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
