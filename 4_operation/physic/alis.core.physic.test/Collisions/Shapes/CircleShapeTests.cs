using Alis.Aspect.Math;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    /// The circle shape tests class
    /// </summary>
    public class CircleShapeTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="CircleShapeTests"/> class
        /// </summary>
        public CircleShapeTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the circle shape
        /// </summary>
        /// <returns>The circle shape</returns>
        private CircleShape CreateCircleShape()
        {
            return new CircleShape();
        }

        /// <summary>
        /// Tests that test point state under test expected behavior
        /// </summary>
        [Fact]
        public void TestPoint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = CreateCircleShape();
            XForm transform = default(XForm);
            Vector2 p = default(Vector2);

            // Act
            var result = circleShape.TestPoint(
                transform,
                p);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that test segment state under test expected behavior
        /// </summary>
        [Fact]
        public void TestSegment_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = CreateCircleShape();
            XForm transform = default(XForm);
            float lambda = 0;
            Vector2 normal = default(Vector2);
            Segment segment = default(Segment);
            float maxLambda = 0;

            // Act
            var result = circleShape.TestSegment(
                transform,
                out lambda,
                out normal,
                segment,
                maxLambda);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that compute aabb state under test expected behavior
        /// </summary>
        [Fact]
        public void ComputeAabb_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = CreateCircleShape();
            Aabb aabb = default(Aabb);
            XForm transform = default(XForm);

            // Act
            circleShape.ComputeAabb(
                out aabb,
                transform);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that compute mass state under test expected behavior
        /// </summary>
        [Fact]
        public void ComputeMass_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = CreateCircleShape();
            MassData massData = default(MassData);
            float density = 0;

            // Act
            circleShape.ComputeMass(
                out massData,
                density);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that compute submerged area state under test expected behavior
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = CreateCircleShape();
            Vector2 normal = default(Vector2);
            float offset = 0;
            XForm xf = default(XForm);
            Vector2 c = default(Vector2);

            // Act
            var result = circleShape.ComputeSubmergedArea(
                normal,
                offset,
                xf,
                out c);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get support state under test expected behavior
        /// </summary>
        [Fact]
        public void GetSupport_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = CreateCircleShape();
            Vector2 d = default(Vector2);

            // Act
            var result = circleShape.GetSupport(
                d);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get support vertex state under test expected behavior
        /// </summary>
        [Fact]
        public void GetSupportVertex_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = CreateCircleShape();
            Vector2 d = default(Vector2);

            // Act
            var result = circleShape.GetSupportVertex(
                d);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get vertex state under test expected behavior
        /// </summary>
        [Fact]
        public void GetVertex_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = CreateCircleShape();
            int index = 0;

            // Act
            var result = circleShape.GetVertex(
                index);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that compute sweep radius state under test expected behavior
        /// </summary>
        [Fact]
        public void ComputeSweepRadius_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = CreateCircleShape();
            Vector2 pivot = default(Vector2);

            // Act
            var result = circleShape.ComputeSweepRadius(
                pivot);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
