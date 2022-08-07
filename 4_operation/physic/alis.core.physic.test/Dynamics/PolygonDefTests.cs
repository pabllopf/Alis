using Alis.Core.Physic.Dynamics;
using Moq;
using System;
using Alis.Aspect.Math;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The polygon def tests class
    /// </summary>
    public class PolygonDefTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="PolygonDefTests"/> class
        /// </summary>
        public PolygonDefTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the polygon def
        /// </summary>
        /// <returns>The polygon def</returns>
        private PolygonDef CreatePolygonDef()
        {
            return new PolygonDef();
        }

        /// <summary>
        /// Tests that set as box state under test expected behavior
        /// </summary>
        [Fact]
        public void SetAsBox_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var polygonDef = CreatePolygonDef();
            float hx = 0;
            float hy = 0;

            // Act
            polygonDef.SetAsBox(
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
            var polygonDef = CreatePolygonDef();
            float hx = 0;
            float hy = 0;
            Vector2 center = default(Vector2);
            float angle = 0;

            // Act
            polygonDef.SetAsBox(
                hx,
                hy,
                center,
                angle);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
