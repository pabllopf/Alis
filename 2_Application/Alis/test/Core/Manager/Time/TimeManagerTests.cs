using Alis.Core.Manager.Time;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Manager.Time
{
    /// <summary>
    /// The time manager tests class
    /// </summary>
    public class TimeManagerTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="TimeManagerTests"/> class
        /// </summary>
        public TimeManagerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the manager
        /// </summary>
        /// <returns>The time manager</returns>
        private TimeManager CreateManager()
        {
            return new TimeManager();
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
