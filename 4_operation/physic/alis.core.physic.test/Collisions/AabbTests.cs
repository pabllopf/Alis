using Alis.Core.Physic.Collisions;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The aabb tests class
    /// </summary>
    public class AabbTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="AabbTests"/> class
        /// </summary>
        public AabbTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the aabb
        /// </summary>
        /// <returns>The aabb</returns>
        private Aabb CreateAabb()
        {
            return new Aabb();
        }

        /// <summary>
        /// Tests that combine state under test expected behavior
        /// </summary>
        [Fact]
        public void Combine_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var aabb = CreateAabb();
            Aabb aabb1 = default(Aabb);
            Aabb aabb2 = default(Aabb);

            // Act
            aabb.Combine(
                aabb1,
                aabb2);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that contains state under test expected behavior
        /// </summary>
        [Fact]
        public void Contains_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var aabb = CreateAabb();
            Aabb aabb = default(Aabb);

            // Act
            var result = aabb.Contains(
                aabb);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that ray cast state under test expected behavior
        /// </summary>
        [Fact]
        public void RayCast_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var aabb = CreateAabb();
            RayCastOutput output = default(RayCastOutput);
            RayCastInput input = default(RayCastInput);

            // Act
            aabb.RayCast(
                out output,
                input);

            // Assert
            Assert.True(false);
            mockRepository.VerifyAll();
        }
    }
}
