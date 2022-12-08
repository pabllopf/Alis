using Alis.Builder.Core.Entity;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Entity
{
    /// <summary>
    /// The scene builder tests class
    /// </summary>
    public class SceneBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SceneBuilderTests"/> class
        /// </summary>
        public SceneBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the scene builder
        /// </summary>
        /// <returns>The scene builder</returns>
        private SceneBuilder CreateSceneBuilder()
        {
            return new SceneBuilder();
        }

        /// <summary>
        /// Tests that add state under test expected behavior
        /// </summary>
        [Fact]
        public void Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var sceneBuilder = this.CreateSceneBuilder();


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
            var sceneBuilder = this.CreateSceneBuilder();

            // Act
            var result = sceneBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that name state under test expected behavior
        /// </summary>
        [Fact]
        public void Name_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var sceneBuilder = this.CreateSceneBuilder();
            string value = null;

            // Act
            var result = sceneBuilder.Name(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
