using Alis.Core.Component.Render;
using Moq;
using System;
using Xunit;

namespace Alis.Test.Core.Component.Render
{
    /// <summary>
    /// The animator tests class
    /// </summary>
    public class AnimatorTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="AnimatorTests"/> class
        /// </summary>
        public AnimatorTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the animator
        /// </summary>
        /// <returns>The animator</returns>
        private Animator CreateAnimator()
        {
            return new Animator();
        }

        /// <summary>
        /// Tests that builder state under test expected behavior
        /// </summary>
        [Fact]
        public void Builder_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var animator = this.CreateAnimator();

            // Act
            var result = animator.Builder();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that add animation state under test expected behavior
        /// </summary>
        [Fact]
        public void AddAnimation_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var animator = this.CreateAnimator();
            Animation animation = null;

            // Act
            animator.AddAnimation(
                animation);

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
            var animator = this.CreateAnimator();

            // Act
            animator.Init();

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
            var animator = this.CreateAnimator();

            // Act
            animator.Awake();

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
            var animator = this.CreateAnimator();

            // Act
            animator.Start();

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
            var animator = this.CreateAnimator();

            // Act
            animator.Update();

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
            var animator = this.CreateAnimator();

            // Act
            animator.Exit();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that change animation to state under test expected behavior
        /// </summary>
        [Fact]
        public void ChangeAnimationTo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var animator = this.CreateAnimator();
            string nameAnimation = null;

            // Act
            animator.ChangeAnimationTo(
                nameAnimation);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
