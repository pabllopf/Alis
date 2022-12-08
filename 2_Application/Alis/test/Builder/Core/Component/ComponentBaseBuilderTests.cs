using Alis.Builder.Core.Component;
using Alis.Core.Component;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Component
{
    /// <summary>
    /// The component base builder tests class
    /// </summary>
    public class ComponentBaseBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// The mock component base
        /// </summary>
        private Mock<ComponentBase> mockComponentBase;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentBaseBuilderTests"/> class
        /// </summary>
        public ComponentBaseBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockComponentBase = this.mockRepository.Create<ComponentBase>();
        }

        /// <summary>
        /// Creates the component base builder
        /// </summary>
        /// <returns>The component base builder</returns>
        private ComponentBaseBuilder CreateComponentBaseBuilder()
        {
            return new ComponentBaseBuilder(
                this.mockComponentBase.Object);
        }

        /// <summary>
        /// Tests that build state under test expected behavior
        /// </summary>
        [Fact]
        public void Build_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var componentBaseBuilder = this.CreateComponentBaseBuilder();

            // Act
            var result = componentBaseBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
