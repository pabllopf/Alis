using Alis.Core.Physic.Collision;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Collision
{
    /// <summary>
    /// The segment tests class
    /// </summary>
    public class SegmentTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentTests"/> class
        /// </summary>
        public SegmentTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the segment
        /// </summary>
        /// <returns>The segment</returns>
        private Segment CreateSegment()
        {
            return new Segment();
        }

        /// <summary>
        /// Tests that test segment state under test expected behavior
        /// </summary>
        [Fact]
        public void TestSegment_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var segment = this.CreateSegment();
            float lambda = 0;
            Vector2 normal = default(global::Alis.Aspect.Math.Vector2);
            Segment segment = default(global::Alis.Core.Physic.Collision.Segment);
            float maxLambda = 0;

            // Act
            var result = segment.TestSegment(
                out lambda,
                out normal,
                segment,
                maxLambda);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
