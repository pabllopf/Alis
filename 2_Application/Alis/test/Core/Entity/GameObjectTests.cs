using Alis.Core.Entity;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Entity
{
    /// <summary>
    /// The game object tests class
    /// </summary>
    public class GameObjectTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="GameObjectTests"/> class
        /// </summary>
        public GameObjectTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the game object
        /// </summary>
        /// <returns>The game object</returns>
        private GameObject CreateGameObject()
        {
            return new GameObject();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameObject = this.CreateGameObject();

            // Act
            var result = gameObject.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that create primitive state under test expected behavior
        /// </summary>
        [Fact]
        public void CreatePrimitive_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameObject = this.CreateGameObject();

            // Act
            //gameObject.CreatePrimitive();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that find state under test expected behavior
        /// </summary>
        [Fact]
        public void Find_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameObject = this.CreateGameObject();
            //string name = null;

            // Act
            //var result = gameObject.Find(
             //   name);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that find game objects with tag state under test expected behavior
        /// </summary>
        [Fact]
        public void FindGameObjectsWithTag_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameObject = this.CreateGameObject();

            // Act
            //gameObject.FindGameObjectsWithTag();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that find with tag state under test expected behavior
        /// </summary>
        [Fact]
        public void FindWithTag_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameObject = this.CreateGameObject();
            //string tag = null;

            // Act
            //var result = gameObject.FindWithTag(
            //    tag);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
