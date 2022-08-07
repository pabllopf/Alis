using Alis.Core.Physic.Dynamics;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The fixture def tests class
    /// </summary>
    public class FixtureDefTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="FixtureDefTests"/> class
        /// </summary>
        public FixtureDefTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the fixture def
        /// </summary>
        /// <returns>The fixture def</returns>
        private FixtureDef CreateFixtureDef()
        {
            return new FixtureDef();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var fixtureDef = CreateFixtureDef();

            // Act


            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
