using Alis.Core.Physic.Collisions.Shapes;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    /// The mass data tests class
    /// </summary>
    public class MassDataTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="MassDataTests"/> class
        /// </summary>
        public MassDataTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the mass data
        /// </summary>
        /// <returns>The mass data</returns>
        private MassData CreateMassData()
        {
            return new MassData();
        }

        /// <summary>
        /// Tests that test method 1
        /// </summary>
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var massData = CreateMassData();

            // Act


            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
