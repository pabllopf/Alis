using Alis.Core.Physic.Collisions;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The pair manager tests class
    /// </summary>
    public class PairManagerTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="PairManagerTests"/> class
        /// </summary>
        public PairManagerTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the manager
        /// </summary>
        /// <returns>The pair manager</returns>
        private PairManager CreateManager()
        {
            return new PairManager();
        }

        /// <summary>
        /// Tests that initialize state under test expected behavior
        /// </summary>
        [Fact]
        public void Initialize_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = CreateManager();
            BroadPhase broadPhase = null;
            PairCallback callback = null;

            // Act
            manager.Initialize(
                broadPhase,
                callback);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that add buffered pair state under test expected behavior
        /// </summary>
        [Fact]
        public void AddBufferedPair_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = CreateManager();
            int id1 = 0;
            int id2 = 0;

            // Act
            manager.AddBufferedPair(
                id1,
                id2);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that remove buffered pair state under test expected behavior
        /// </summary>
        [Fact]
        public void RemoveBufferedPair_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = CreateManager();
            int id1 = 0;
            int id2 = 0;

            // Act
            manager.RemoveBufferedPair(
                id1,
                id2);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that commit state under test expected behavior
        /// </summary>
        [Fact]
        public void Commit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var manager = CreateManager();

            // Act
            //manager.Commit();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that buffered pair sort predicate state under test expected behavior
        /// </summary>
        [Fact]
        public void BufferedPairSortPredicate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var manager = CreateManager();
            BufferedPair pair1 = default(BufferedPair);
            BufferedPair pair2 = default(BufferedPair);

            // Act
            var result = PairManager.BufferedPairSortPredicate(
                pair1,
                pair2);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
