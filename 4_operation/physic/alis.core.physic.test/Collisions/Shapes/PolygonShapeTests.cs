using Alis.Aspect.Math;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Moq;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    /// The polygon shape tests class
    /// </summary>
    public class PolygonShapeTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonShapeTests"/> class
        /// </summary>
        public PolygonShapeTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the polygon shape
        /// </summary>
        /// <returns>The polygon shape</returns>
        private PolygonShape CreatePolygonShape()
        {
            return new PolygonShape();
        }

        /// <summary>
        /// Tests that set state under test expected behavior
        /// </summary>
        [Fact]
        public void Set_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var polygonShape = CreatePolygonShape();
            Vector2[] vertices = null;
            int count = 0;

            // Act
            polygonShape.Set(
                vertices,
                count);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set as box state under test expected behavior
        /// </summary>
        [Fact]
        public void SetAsBox_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var polygonShape = CreatePolygonShape();
            float hx = 0;
            float hy = 0;

            // Act
            polygonShape.SetAsBox(
                hx,
                hy);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set as box state under test expected behavior 1
        /// </summary>
        [Fact]
        public void SetAsBox_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var polygonShape = CreatePolygonShape();
            float hx = 0;
            float hy = 0;
            Vector2 center = default(Vector2);
            float angle = 0;

            // Act
            polygonShape.SetAsBox(
                hx,
                hy,
                center,
                angle);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that set as edge state under test expected behavior
        /// </summary>
        [Fact]
        public void SetAsEdge_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var polygonShape = CreatePolygonShape();
            Vector2 v1 = default(Vector2);
            Vector2 v2 = default(Vector2);

            // Act
            polygonShape.SetAsEdge(
                v1,
                v2);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that test point state under test expected behavior
        /// </summary>
        [Fact]
        public void TestPoint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var polygonShape = CreatePolygonShape();
            XForm xf = default(XForm);
            Vector2 p = default(Vector2);

            // Act
            var result = polygonShape.TestPoint(
                xf,
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
            var polygonShape = CreatePolygonShape();
            XForm xf = default(XForm);
            float lambda = 0;
            Vector2 normal = default(Vector2);
            Segment segment = default(Segment);
            float maxLambda = 0;

            // Act
            var result = polygonShape.TestSegment(
                xf,
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
            var polygonShape = CreatePolygonShape();
            Aabb aabb = default(Aabb);
            XForm xf = default(XForm);

            // Act
            polygonShape.ComputeAabb(
                out aabb,
                xf);

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
            var polygonShape = CreatePolygonShape();
            MassData massData = default(MassData);
            float denstity = 0;

            // Act
            polygonShape.ComputeMass(
                out massData,
                denstity);

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
            var polygonShape = CreatePolygonShape();
            Vector2 normal = default(Vector2);
            float offset = 0;
            XForm xf = default(XForm);
            Vector2 c = default(Vector2);

            // Act
            var result = polygonShape.ComputeSubmergedArea(
                normal,
                offset,
                xf,
                out c);

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
            var polygonShape = CreatePolygonShape();
            Vector2 pivot = default(Vector2);

            // Act
            var result = polygonShape.ComputeSweepRadius(
                pivot);

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
            var polygonShape = CreatePolygonShape();
            Vector2 d = default(Vector2);

            // Act
            var result = polygonShape.GetSupport(
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
            var polygonShape = CreatePolygonShape();
            Vector2 d = default(Vector2);

            // Act
            var result = polygonShape.GetSupportVertex(
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
            var polygonShape = CreatePolygonShape();
            int index = 0;

            // Act
            var result = polygonShape.GetVertex(
                index);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }

        /// <summary>
        /// Tests that compute centroid state under test expected behavior
        /// </summary>
        [Fact]
        public void ComputeCentroid_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var polygonShape = CreatePolygonShape();
            Vector2[] vs = null;
            int count = 0;

            // Act
            var result = PolygonShape.ComputeCentroid(
                vs,
                count);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
