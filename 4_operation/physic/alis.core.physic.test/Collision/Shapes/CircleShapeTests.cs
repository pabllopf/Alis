using Alis.Core.Physic.Collision.Shapes;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.Shapes
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
            this.mockRepository = new MockRepository(MockBehavior.Strict);


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
            var circleShape = this.CreateCircleShape();
            XForm transform = default(global::Alis.Aspect.Math.XForm);
            Vector2 p = default(global::Alis.Aspect.Math.Vector2);

            // Act
            var result = circleShape.TestPoint(
                transform,
                p);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that test segment state under test expected behavior
        /// </summary>
        [Fact]
        public void TestSegment_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = this.CreateCircleShape();
            XForm transform = default(global::Alis.Aspect.Math.XForm);
            float lambda = 0;
            Vector2 normal = default(global::Alis.Aspect.Math.Vector2);
            Segment segment = default(global::Alis.Core.Physic.Collision.Segment);
            float maxLambda = 0;

            // Act
            var result = circleShape.TestSegment(
                transform,
                out lambda,
                out normal,
                segment,
                maxLambda);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that compute aabb state under test expected behavior
        /// </summary>
        [Fact]
        public void ComputeAabb_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = this.CreateCircleShape();
            Aabb aabb = default(global::Alis.Core.Physic.Collision.Aabb);
            XForm transform = default(global::Alis.Aspect.Math.XForm);

            // Act
            circleShape.ComputeAabb(
                out aabb,
                transform);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that compute mass state under test expected behavior
        /// </summary>
        [Fact]
        public void ComputeMass_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = this.CreateCircleShape();
            MassData massData = default(global::Alis.Core.Physic.Collision.Shapes.MassData);
            float density = 0;

            // Act
            circleShape.ComputeMass(
                out massData,
                density);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that compute submerged area state under test expected behavior
        /// </summary>
        [Fact]
        public void ComputeSubmergedArea_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = this.CreateCircleShape();
            Vector2 normal = default(global::Alis.Aspect.Math.Vector2);
            float offset = 0;
            XForm xf = default(global::Alis.Aspect.Math.XForm);
            Vector2 c = default(global::Alis.Aspect.Math.Vector2);

            // Act
            var result = circleShape.ComputeSubmergedArea(
                normal,
                offset,
                xf,
                out c);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get support state under test expected behavior
        /// </summary>
        [Fact]
        public void GetSupport_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = this.CreateCircleShape();
            Vector2 d = default(global::Alis.Aspect.Math.Vector2);

            // Act
            var result = circleShape.GetSupport(
                d);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get support vertex state under test expected behavior
        /// </summary>
        [Fact]
        public void GetSupportVertex_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = this.CreateCircleShape();
            Vector2 d = default(global::Alis.Aspect.Math.Vector2);

            // Act
            var result = circleShape.GetSupportVertex(
                d);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that get vertex state under test expected behavior
        /// </summary>
        [Fact]
        public void GetVertex_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = this.CreateCircleShape();
            int index = 0;

            // Act
            var result = circleShape.GetVertex(
                index);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that compute sweep radius state under test expected behavior
        /// </summary>
        [Fact]
        public void ComputeSweepRadius_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var circleShape = this.CreateCircleShape();
            Vector2 pivot = default(global::Alis.Aspect.Math.Vector2);

            // Act
            var result = circleShape.ComputeSweepRadius(
                pivot);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
