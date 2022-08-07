using Alis.Core.Physic.Dynamics;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The fixture tests class
    /// </summary>
    public class FixtureTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="FixtureTests"/> class
        /// </summary>
        public FixtureTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the fixture
        /// </summary>
        /// <returns>The fixture</returns>
        private Fixture CreateFixture()
        {
            return new Fixture();
        }

        /// <summary>
        /// Tests that create state under test expected behavior
        /// </summary>
        [Fact]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var fixture = this.CreateFixture();
            BroadPhase broadPhase = null;
            Body body = null;
            XForm xf = default(global::Alis.Aspect.Math.XForm);
            FixtureDef def = null;

            // Act
            fixture.Create(
                broadPhase,
                body,
                xf,
                def);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that destroy state under test expected behavior
        /// </summary>
        [Fact]
        public void Destroy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var fixture = this.CreateFixture();
            BroadPhase broadPhase = null;

            // Act
            fixture.Destroy(
                broadPhase);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that dispose state under test expected behavior
        /// </summary>
        [Fact]
        public void Dispose_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var fixture = this.CreateFixture();

            // Act
            fixture.Dispose();

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
            var fixture = this.CreateFixture();
            MassData massData = default(global::Alis.Core.Physic.Collision.Shapes.MassData);

            // Act
            fixture.ComputeMass(
                out massData);

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
            var fixture = this.CreateFixture();
            Vector2 normal = default(global::Alis.Aspect.Math.Vector2);
            float offset = 0;
            Vector2 c = default(global::Alis.Aspect.Math.Vector2);

            // Act
            var result = fixture.ComputeSubmergedArea(
                normal,
                offset,
                out c);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that test point state under test expected behavior
        /// </summary>
        [Fact]
        public void TestPoint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var fixture = this.CreateFixture();
            Vector2 p = default(global::Alis.Aspect.Math.Vector2);

            // Act
            var result = fixture.TestPoint(
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
            var fixture = this.CreateFixture();
            float lambda = 0;
            Vector2 normal = default(global::Alis.Aspect.Math.Vector2);
            Segment segment = default(global::Alis.Core.Physic.Collision.Segment);
            float maxLambda = 0;

            // Act
            var result = fixture.TestSegment(
                out lambda,
                out normal,
                segment,
                maxLambda);

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
            var fixture = this.CreateFixture();
            Vector2 pivot = default(global::Alis.Aspect.Math.Vector2);

            // Act
            var result = fixture.ComputeSweepRadius(
                pivot);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
