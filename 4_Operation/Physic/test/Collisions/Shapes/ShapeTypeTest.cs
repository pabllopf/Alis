

using Alis.Core.Physic.Collisions.Shapes;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    ///     The shape type test class
    /// </summary>
    public class ShapeTypeTest
    {
        /// <summary>
        ///     Tests that unknown should have value negative one
        /// </summary>
        [Fact]
        public void Unknown_ShouldHaveValueNegativeOne()
        {
            Assert.Equal(-1, (int) ShapeType.Unknown);
        }

        /// <summary>
        ///     Tests that circle should have value zero
        /// </summary>
        [Fact]
        public void Circle_ShouldHaveValueZero()
        {
            Assert.Equal(0, (int) ShapeType.Circle);
        }

        /// <summary>
        ///     Tests that edge should have value one
        /// </summary>
        [Fact]
        public void Edge_ShouldHaveValueOne()
        {
            Assert.Equal(1, (int) ShapeType.Edge);
        }

        /// <summary>
        ///     Tests that polygon should have value two
        /// </summary>
        [Fact]
        public void Polygon_ShouldHaveValueTwo()
        {
            Assert.Equal(2, (int) ShapeType.Polygon);
        }

        /// <summary>
        ///     Tests that chain should have value three
        /// </summary>
        [Fact]
        public void Chain_ShouldHaveValueThree()
        {
            Assert.Equal(3, (int) ShapeType.Chain);
        }

        /// <summary>
        ///     Tests that type count should have value four
        /// </summary>
        [Fact]
        public void TypeCount_ShouldHaveValueFour()
        {
            Assert.Equal(4, (int) ShapeType.TypeCount);
        }

        /// <summary>
        ///     Tests that all enum values should be unique
        /// </summary>
        [Fact]
        public void AllEnumValues_ShouldBeUnique()
        {
            ShapeType[] values = new[]
            {
                ShapeType.Unknown,
                ShapeType.Circle,
                ShapeType.Edge,
                ShapeType.Polygon,
                ShapeType.Chain,
                ShapeType.TypeCount
            };

            for (int i = 0; i < values.Length; i++)
            {
                for (int j = i + 1; j < values.Length; j++)
                {
                    Assert.NotEqual(values[i], values[j]);
                }
            }
        }
    }
}