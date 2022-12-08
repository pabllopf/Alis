using Alis.Builder.Core.Entity;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Builder.Core.Entity
{
    /// <summary>
    /// The game object builder tests class
    /// </summary>
    public class GameObjectBuilderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="GameObjectBuilderTests"/> class
        /// </summary>
        public GameObjectBuilderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the game object builder
        /// </summary>
        /// <returns>The game object builder</returns>
        private GameObjectBuilder CreateGameObjectBuilder()
        {
            return new GameObjectBuilder();
        }

        /// <summary>
        /// Tests that add component state under test expected behavior
        /// </summary>
        [Fact]
        public void AddComponent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameObjectBuilder = this.CreateGameObjectBuilder();


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that add component state under test expected behavior 1
        /// </summary>
        [Fact]
        public void AddComponent_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var gameObjectBuilder = this.CreateGameObjectBuilder();


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
            var gameObjectBuilder = this.CreateGameObjectBuilder();

            // Act
            var result = gameObjectBuilder.Build();

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
            var gameObjectBuilder = this.CreateGameObjectBuilder();
            string value = null;

            // Act
            var result = gameObjectBuilder.Name(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that transform state under test expected behavior
        /// </summary>
        [Fact]
        public void Transform_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameObjectBuilder = this.CreateGameObjectBuilder();


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that with tag state under test expected behavior
        /// </summary>
        [Fact]
        public void WithTag_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameObjectBuilder = this.CreateGameObjectBuilder();
            string value = null;

            // Act
            var result = gameObjectBuilder.WithTag(
                value);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
