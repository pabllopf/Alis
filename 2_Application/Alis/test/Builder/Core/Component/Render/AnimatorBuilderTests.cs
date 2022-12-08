using Alis.Builder.Core.Component.Render;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component.Render
{
    /// <summary>
    /// The animator builder tests class
    /// </summary>
    public class AnimatorBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="AnimatorBuilderTests"/> class
        /// </summary>
        public AnimatorBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the animator builder
        /// </summary>
        /// <returns>The animator builder</returns>
        private AnimatorBuilder CreateAnimatorBuilder()
        {
            return new AnimatorBuilder();
        }

        /// <summary>
        /// Tests that add animation state under test expected behavior
        /// </summary>
        [Fact]
        public void AddAnimation_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var animatorBuilder = this.CreateAnimatorBuilder();

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
            var animatorBuilder = this.CreateAnimatorBuilder();

            // Act
            var result = animatorBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
