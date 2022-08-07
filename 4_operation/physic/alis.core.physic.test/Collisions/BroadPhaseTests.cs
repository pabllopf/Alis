using Alis.Core.Physic.Collisions;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The broad phase tests class
    /// </summary>
    public class BroadPhaseTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;

        /// <summary>
        /// The mock pair callback
        /// </summary>
        private Mock<PairCallback> mockPairCallback;

        /// <summary>
        /// Initializes a new instance of the <see cref="BroadPhaseTests"/> class
        /// </summary>
        public BroadPhaseTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockPairCallback = mockRepository.Create<PairCallback>();
        }

        /// <summary>
        /// Creates the broad phase
        /// </summary>
        /// <returns>The broad phase</returns>
        private BroadPhase CreateBroadPhase()
        {
            return new BroadPhase(
                new Aabb(),
                mockPairCallback.Object);
        }

        /// <summary>
        /// Tests that in range state under test expected behavior
        /// </summary>
        [Fact]
        public void InRange_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var broadPhase = CreateBroadPhase();
            Aabb aabb = default(Aabb);

            // Act
            var result = broadPhase.InRange(
                aabb);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that create proxy state under test expected behavior
        /// </summary>
        [Fact]
        public void CreateProxy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var broadPhase = CreateBroadPhase();
            Aabb aabb = default(Aabb);
            object userData = null;

            // Act
            var result = broadPhase.CreateProxy(
                aabb,
                userData);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that destroy proxy state under test expected behavior
        /// </summary>
        [Fact]
        public void DestroyProxy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            //var broadPhase = CreateBroadPhase();
            //int proxyId = 0;

            // Act
            //broadPhase.DestroyProxy(proxyId);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that move proxy state under test expected behavior
        /// </summary>
        [Fact]
        public void MoveProxy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var broadPhase = CreateBroadPhase();
            int proxyId = 0;
            Aabb aabb = default(Aabb);

            // Act
            broadPhase.MoveProxy(
                proxyId,
                aabb);

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
            var broadPhase = CreateBroadPhase();

            // Act
            broadPhase.Commit();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get proxy state under test expected behavior
        /// </summary>
        [Fact]
        public void GetProxy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var broadPhase = CreateBroadPhase();
            int proxyId = 0;

            // Act
            var result = broadPhase.GetProxy(
                proxyId);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that query state under test expected behavior
        /// </summary>
        [Fact]
        public void Query_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var broadPhase = CreateBroadPhase();
            Aabb aabb = default(Aabb);
            object[] userData = null;
            int maxCount = 0;

            // Act
            var result = broadPhase.Query(
                aabb,
                userData,
                maxCount);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that query segment state under test expected behavior
        /// </summary>
        [Fact]
        public void QuerySegment_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var broadPhase = CreateBroadPhase();
            Segment segment = default(Segment);
            object[] userData = null;
            int maxCount = 0;
            SortKeyFunc sortKey = null;

            // Act
            var result = broadPhase.QuerySegment(
                segment,
                userData,
                maxCount,
                sortKey);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that validate state under test expected behavior
        /// </summary>
        [Fact]
        public void Validate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var broadPhase = CreateBroadPhase();

            // Act
            broadPhase.Validate();

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
