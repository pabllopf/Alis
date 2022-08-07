using Alis.Core.Physic.Dynamics;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The edge def tests class
    /// </summary>
    public class EdgeDefTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeDefTests"/> class
        /// </summary>
        public EdgeDefTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the edge def
        /// </summary>
        /// <returns>The edge def</returns>
        private EdgeDef CreateEdgeDef()
        {
            return new EdgeDef();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var edgeDef = CreateEdgeDef();

            // Act


            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
