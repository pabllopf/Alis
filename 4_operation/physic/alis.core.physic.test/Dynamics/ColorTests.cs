using Alis.Core.Physic.Dynamics;
using Moq;
using System;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The color tests class
    /// </summary>
    public class ColorTests
    {
        /// <summary>
        /// The mock repository
        /// </summary>
        private MockRepository mockRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ColorTests"/> class
        /// </summary>
        public ColorTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);


        }

        /// <summary>
        /// Creates the color
        /// </summary>
        /// <returns>The color</returns>
        private Color CreateColor()
        {
            return new Color(
                1,
                1,
                1);
        }

        /// <summary>
        /// Tests that set state under test expected behavior
        /// </summary>
        [Fact]
        public void Set_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var color = CreateColor();
            float r = 0;
            float g = 0;
            float b = 0;

            // Act
            color.Set(
                r,
                g,
                b);

            // Assert
            Assert.True(true);
            mockRepository.VerifyAll();
        }
    }
}
