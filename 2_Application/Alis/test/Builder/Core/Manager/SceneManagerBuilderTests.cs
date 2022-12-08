using Alis.Builder.Core.Manager;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Manager
{
    /// <summary>
    /// The scene manager builder tests class
    /// </summary>
    public class SceneManagerBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SceneManagerBuilderTests"/> class
        /// </summary>
        public SceneManagerBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the scene manager builder
        /// </summary>
        /// <returns>The scene manager builder</returns>
        private SceneManagerBuilder CreateSceneManagerBuilder()
        {
            return new SceneManagerBuilder();
        }

        /// <summary>
        /// Tests that add state under test expected behavior
        /// </summary>
        [Fact]
        public void Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var sceneManagerBuilder = this.CreateSceneManagerBuilder();


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
            var sceneManagerBuilder = this.CreateSceneManagerBuilder();

            // Act
            var result = sceneManagerBuilder.Build();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
