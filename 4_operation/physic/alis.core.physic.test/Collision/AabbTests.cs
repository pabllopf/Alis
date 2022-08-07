using Alis.Core.Physic.Collision;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
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
            this.mockRepository = new MockRepository(MockBehavior.Strict);


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
            var aabb = this.CreateAabb();
            Aabb aabb1 = default(global::Alis.Core.Physic.Collision.Aabb);
            Aabb aabb2 = default(global::Alis.Core.Physic.Collision.Aabb);

            // Act
            aabb.Combine(
                aabb1,
                aabb2);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that contains state under test expected behavior
        /// </summary>
        [Fact]
        public void Contains_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var aabb = this.CreateAabb();
            Aabb aabb = default(global::Alis.Core.Physic.Collision.Aabb);

            // Act
            var result = aabb.Contains(
                aabb);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that ray cast state under test expected behavior
        /// </summary>
        [Fact]
        public void RayCast_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var aabb = this.CreateAabb();
            RayCastOutput output = default(global::Alis.Core.Physic.Collision.RayCastOutput);
            RayCastInput input = default(global::Alis.Core.Physic.Collision.RayCastInput);

            // Act
            aabb.RayCast(
                out output,
                input);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
