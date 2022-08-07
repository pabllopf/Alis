using Alis.Core.Physic.Collisions;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The pair tests class
    /// </summary>
    public class PairTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="PairTests"/> class
        /// </summary>
        public PairTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the pair
        /// </summary>
        /// <returns>The pair</returns>
        private Pair CreatePair()
        {
            return new Pair();
        }

        /// <summary>
        /// Tests that set buffered state under test expected behavior
        /// </summary>
        [Fact]
        public void SetBuffered_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pair = CreatePair();

            // Act
            pair.SetBuffered();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that clear buffered state under test expected behavior
        /// </summary>
        [Fact]
        public void ClearBuffered_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pair = CreatePair();

            // Act
            pair.ClearBuffered();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that is buffered state under test expected behavior
        /// </summary>
        [Fact]
        public void IsBuffered_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pair = CreatePair();

            // Act
            var result = pair.IsBuffered();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set removed state under test expected behavior
        /// </summary>
        [Fact]
        public void SetRemoved_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pair = CreatePair();

            // Act
            pair.SetRemoved();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that clear removed state under test expected behavior
        /// </summary>
        [Fact]
        public void ClearRemoved_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pair = CreatePair();

            // Act
            pair.ClearRemoved();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that is removed state under test expected behavior
        /// </summary>
        [Fact]
        public void IsRemoved_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pair = CreatePair();

            // Act
            var result = pair.IsRemoved();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set final state under test expected behavior
        /// </summary>
        [Fact]
        public void SetFinal_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pair = CreatePair();

            // Act
            pair.SetFinal();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that is final state under test expected behavior
        /// </summary>
        [Fact]
        public void IsFinal_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pair = CreatePair();

            // Act
            var result = pair.IsFinal();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
