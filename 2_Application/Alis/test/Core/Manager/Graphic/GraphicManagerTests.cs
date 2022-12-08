using Alis.Core.Manager.Graphic;
using Moq;
using System;
using Alis.Core.Component.Render;
using Alis.Core.Graphic.D2.SFML.Graphics;
using Xunit;

namespace Alis.Test.Core.Manager.Graphic
{
    /// <summary>
    /// The graphic manager tests class
    /// </summary>
    public class GraphicManagerTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="GraphicManagerTests"/> class
        /// </summary>
        public GraphicManagerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the manager
        /// </summary>
        /// <returns>The graphic manager</returns>
        private GraphicManager CreateManager()
        {
            return new GraphicManager();
        }

        /// <summary>
        /// Tests that init state under test expected behavior
        /// </summary>
        [Fact]
        public void Init_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();

            // Act
            manager.Init();

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
            var manager = this.CreateManager();

            // Act
            manager.Awake();

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
            var manager = this.CreateManager();

            // Act
            manager.Start();

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
            var manager = this.CreateManager();

            // Act
            manager.BeforeUpdate();

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
            var manager = this.CreateManager();

            // Act
            manager.Update();

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
            var manager = this.CreateManager();

            // Act
            manager.AfterUpdate();

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
            var manager = this.CreateManager();

            // Act
            manager.DispatchEvents();

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
            var manager = this.CreateManager();

            // Act
            manager.FixedUpdate();

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
            var manager = this.CreateManager();

            // Act
            manager.Reset();

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
            var manager = this.CreateManager();

            // Act
            manager.Stop();

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
            var manager = this.CreateManager();

            // Act
            manager.Exit();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that attach state under test expected behavior
        /// </summary>
        [Fact]
        public void Attach_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();

            // Act
            //manager.Attach(
            //    new Sprite());

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that un attach state under test expected behavior
        /// </summary>
        [Fact]
        public void UnAttach_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();
            //Sprite sprite = null;

            // Act
            //manager.UnAttach(
             //   sprite);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set view state under test expected behavior
        /// </summary>
        [Fact]
        public void SetView_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();
            View view = null;

            // Act
            manager.SetView(
                view);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that attach collider state under test expected behavior
        /// </summary>
        [Fact]
        public void AttachCollider_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = this.CreateManager();
            Shape shape = null;

            // Act
            manager.AttachCollider(
                shape);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
