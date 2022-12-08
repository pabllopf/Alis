using Alis.Core.Manager.Setting;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Manager.Setting
{
    /// <summary>
    /// The setting manager tests class
    /// </summary>
    public class SettingManagerTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SettingManagerTests"/> class
        /// </summary>
        public SettingManagerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the manager
        /// </summary>
        /// <returns>The setting manager</returns>
        private SettingManager CreateManager()
        {
            return new SettingManager();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var manager = this.CreateManager();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
