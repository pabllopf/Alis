using Alis.Core.Component.Collider;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Collider
{
    /// <summary>
    /// The box collider tests class
    /// </summary>
    public class BoxColliderTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="BoxColliderTests"/> class
        /// </summary>
        public BoxColliderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the box collider
        /// </summary>
        /// <returns>The box collider</returns>
        private BoxCollider CreateBoxCollider()
        {
            return new BoxCollider();
        }

        /// <summary>
        /// Tests that init state under test expected behavior
        /// </summary>
        [Fact]
        public void Init_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxCollider = this.CreateBoxCollider();

            // Act
            boxCollider.Init();

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
            var boxCollider = this.CreateBoxCollider();

            // Act
            boxCollider.Awake();

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
            var boxCollider = this.CreateBoxCollider();

            // Act
            boxCollider.Start();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that before update state under test expected behavior
        /// </summary>
        [Fact]
        public void BeforeUpdate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxCollider = this.CreateBoxCollider();

            // Act
            boxCollider.BeforeUpdate();

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
            var boxCollider = this.CreateBoxCollider();

            // Act
            boxCollider.Update();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that after update state under test expected behavior
        /// </summary>
        [Fact]
        public void AfterUpdate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxCollider = this.CreateBoxCollider();

            // Act
            boxCollider.AfterUpdate();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that draw state under test expected behavior
        /// </summary>
        [Fact]
        public void Draw_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxCollider = this.CreateBoxCollider();

            // Act
            boxCollider.Draw();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var boxCollider = this.CreateBoxCollider();

            // Act
            var result = boxCollider.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
