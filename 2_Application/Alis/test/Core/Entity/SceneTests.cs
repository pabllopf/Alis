using Alis.Core.Entity;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Entity
{
    /// <summary>
    /// The scene tests class
    /// </summary>
    public class SceneTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SceneTests"/> class
        /// </summary>
        public SceneTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the scene
        /// </summary>
        /// <returns>The scene</returns>
        private Scene CreateScene()
        {
            return new Scene();
        }

        /// <summary>
        /// Tests that awake state under test expected behavior
        /// </summary>
        [Fact]
        public void Awake_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var scene = this.CreateScene();

            // Act
            scene.Awake();

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
            var scene = this.CreateScene();

            // Act
            scene.Start();

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
            var scene = this.CreateScene();

            // Act
            scene.BeforeUpdate();

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
            var scene = this.CreateScene();

            // Act
            scene.Update();

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
            var scene = this.CreateScene();

            // Act
            scene.AfterUpdate();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that fixed update state under test expected behavior
        /// </summary>
        [Fact]
        public void FixedUpdate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var scene = this.CreateScene();

            // Act
            scene.FixedUpdate();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that dispatch events state under test expected behavior
        /// </summary>
        [Fact]
        public void DispatchEvents_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var scene = this.CreateScene();

            // Act
            scene.DispatchEvents();

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
            var scene = this.CreateScene();

            // Act
            scene.Draw();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that reset state under test expected behavior
        /// </summary>
        [Fact]
        public void Reset_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var scene = this.CreateScene();

            // Act
            scene.Reset();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that stop state under test expected behavior
        /// </summary>
        [Fact]
        public void Stop_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var scene = this.CreateScene();

            // Act
            scene.Stop();

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
            var scene = this.CreateScene();

            // Act
            scene.Exit();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that add state under test expected behavior
        /// </summary>
        [Fact]
        public void Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var scene = this.CreateScene();
            GameObject gameObject = null;

            // Act
            scene.Add(
                gameObject);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
