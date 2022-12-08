using Alis.Builder.Core.Setting;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Setting
{
    /// <summary>
    /// The general setting builder tests class
    /// </summary>
    public class GeneralSettingBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralSettingBuilderTests"/> class
        /// </summary>
        public GeneralSettingBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the general setting builder
        /// </summary>
        /// <returns>The general setting builder</returns>
        private GeneralSettingBuilder CreateGeneralSettingBuilder()
        {
            return new GeneralSettingBuilder();
        }

        /// <summary>
        /// Tests that author state under test expected behavior
        /// </summary>
        [Fact]
        public void Author_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var generalSettingBuilder = this.CreateGeneralSettingBuilder();
            string value = null;

            // Act
            var result = generalSettingBuilder.Author(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var generalSettingBuilder = this.CreateGeneralSettingBuilder();

            // Act
            var result = generalSettingBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that description state under test expected behavior
        /// </summary>
        [Fact]
        public void Description_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var generalSettingBuilder = this.CreateGeneralSettingBuilder();
            string value = null;

            // Act
            var result = generalSettingBuilder.Description(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that icon state under test expected behavior
        /// </summary>
        [Fact]
        public void Icon_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var generalSettingBuilder = this.CreateGeneralSettingBuilder();
            string value = null;

            // Act
            var result = generalSettingBuilder.Icon(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that name state under test expected behavior
        /// </summary>
        [Fact]
        public void Name_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var generalSettingBuilder = this.CreateGeneralSettingBuilder();
            string value = null;

            // Act
            var result = generalSettingBuilder.Name(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that splash screen state under test expected behavior
        /// </summary>
        [Fact]
        public void SplashScreen_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var generalSettingBuilder = this.CreateGeneralSettingBuilder();
            //Func value = null;

            // Act
            //var result = generalSettingBuilder.SplashScreen(
            //    value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
