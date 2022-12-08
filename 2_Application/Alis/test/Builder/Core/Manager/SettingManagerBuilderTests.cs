using Alis.Builder.Core.Manager;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Manager
{
    /// <summary>
    /// The setting manager builder tests class
    /// </summary>
    public class SettingManagerBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SettingManagerBuilderTests"/> class
        /// </summary>
        public SettingManagerBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the setting manager builder
        /// </summary>
        /// <returns>The setting manager builder</returns>
        private SettingManagerBuilder CreateSettingManagerBuilder()
        {
            return new SettingManagerBuilder();
        }

        /// <summary>
        /// Tests that audio state under test expected behavior
        /// </summary>
        [Fact]
        public void Audio_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var settingManagerBuilder = this.CreateSettingManagerBuilder();
           

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
            var settingManagerBuilder = this.CreateSettingManagerBuilder();

            // Act
            var result = settingManagerBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that debug state under test expected behavior
        /// </summary>
        [Fact]
        public void Debug_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var settingManagerBuilder = this.CreateSettingManagerBuilder();
            
            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that general state under test expected behavior
        /// </summary>
        [Fact]
        public void General_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var settingManagerBuilder = this.CreateSettingManagerBuilder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that graphic state under test expected behavior
        /// </summary>
        [Fact]
        public void Graphic_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var settingManagerBuilder = this.CreateSettingManagerBuilder();


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
