using Alis.Core.Component.Render;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Render
{
    /// <summary>
    /// The sprite tests class
    /// </summary>
    public class SpriteTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SpriteTests"/> class
        /// </summary>
        public SpriteTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the sprite
        /// </summary>
        /// <returns>The sprite</returns>
        private Sprite CreateSprite()
        {
            return new Sprite();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var sprite = this.CreateSprite();

            // Act
            var result = sprite.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that init state under test expected behavior
        /// </summary>
        [Fact]
        public void Init_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var sprite = this.CreateSprite();

            // Act
            sprite.Init();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that awake state under test expected behavior
        /// </summary>
        [Fact]
        public void Awake_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var sprite = this.CreateSprite();

            // Act
            sprite.Awake();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that start state under test expected behavior
        /// </summary>
        [Fact]
        public void Start_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var sprite = this.CreateSprite();

            // Act
            sprite.Start();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that update state under test expected behavior
        /// </summary>
        [Fact]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var sprite = this.CreateSprite();

            // Act
            sprite.Update();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that exit state under test expected behavior
        /// </summary>
        [Fact]
        public void Exit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var sprite = this.CreateSprite();

            // Act
            sprite.Exit();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
