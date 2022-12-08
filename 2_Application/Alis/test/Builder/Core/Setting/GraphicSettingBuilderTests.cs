using Alis.Builder.Core.Setting;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Setting
{
    /// <summary>
    /// The graphic setting builder tests class
    /// </summary>
    public class GraphicSettingBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicSettingBuilderTests"/> class
        /// </summary>
        public GraphicSettingBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the graphic setting builder
        /// </summary>
        /// <returns>The graphic setting builder</returns>
        private GraphicSettingBuilder CreateGraphicSettingBuilder()
        {
            return new GraphicSettingBuilder();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var graphicSettingBuilder = this.CreateGraphicSettingBuilder();

            // Act
            var result = graphicSettingBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that window state under test expected behavior
        /// </summary>
        [Fact]
        public void Window_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var graphicSettingBuilder = this.CreateGraphicSettingBuilder();
            //Func value = null;

            // Act
            //var result = graphicSettingBuilder.Window(
             //   value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
