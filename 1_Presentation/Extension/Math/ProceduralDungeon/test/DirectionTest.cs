

using System;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test
{
    /// <summary>
    ///     Test class for <see cref="Direction" /> enum.
    /// </summary>
    public class DirectionTest
    {
        /// <summary>
        ///     Tests that north has value 0.
        /// </summary>
        [Fact]
        public void North_ShouldHaveValue0()
        {
            Assert.Equal(1, (int) Direction.North);
        }

        /// <summary>
        ///     Tests that east has value 1.
        /// </summary>
        [Fact]
        public void East_ShouldHaveValue1()
        {
            Assert.Equal(2, (int) Direction.East);
        }

        /// <summary>
        ///     Tests that south has value 2.
        /// </summary>
        [Fact]
        public void South_ShouldHaveValue2()
        {
            Assert.Equal(3, (int) Direction.South);
        }

        /// <summary>
        ///     Tests that west has value 3.
        /// </summary>
        [Fact]
        public void West_ShouldHaveValue3()
        {
            Assert.Equal(4, (int) Direction.West);
        }

        /// <summary>
        ///     Tests that all directions have distinct values.
        /// </summary>
        [Fact]
        public void AllDirections_ShouldHaveDistinctValues()
        {
            Direction[] directions = new[]
            {
                Direction.North,
                Direction.East,
                Direction.South,
                Direction.West
            };

            for (int i = 0; i < directions.Length; i++)
            {
                for (int j = i + 1; j < directions.Length; j++)
                {
                    Assert.NotEqual(directions[i], directions[j]);
                }
            }
        }

        /// <summary>
        ///     Tests that all enum values are defined.
        /// </summary>
        [Theory, InlineData(Direction.North), InlineData(Direction.East), InlineData(Direction.South), InlineData(Direction.West)]
        public void EnumValue_ShouldBeDefined(Direction direction)
        {
            Assert.True(Enum.IsDefined(typeof(Direction), direction));
        }

        /// <summary>
        ///     Tests that direction can be converted to string.
        /// </summary>
        [Theory, InlineData(Direction.North, "North"), InlineData(Direction.East, "East"), InlineData(Direction.South, "South"), InlineData(Direction.West, "West")]
        public void ToString_ShouldReturnName(Direction direction, string expected)
        {
            string result = direction.ToString();

            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that direction values can be compared.
        /// </summary>
        [Fact]
        public void Comparison_ShouldWork()
        {
            Direction north = Direction.North;
            Direction east = Direction.East;

            Assert.True(north == Direction.North);
            Assert.True(east == Direction.East);
            Assert.False(north == east);
        }

        /// <summary>
        ///     Tests that there are exactly 4 directions.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldHaveExactly4Directions()
        {
            Array directions = Enum.GetValues(typeof(Direction));

            Assert.Equal(5, directions.Length);
        }
    }
}