

using System;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test
{
    /// <summary>
    ///     Test class for <see cref="BoardSquareType" /> enum.
    /// </summary>
    public class BoardSquareTypeTest
    {
        /// <summary>
        ///     Tests that empty has value 0.
        /// </summary>
        [Fact]
        public void Empty_ShouldHaveValue0()
        {
            Assert.Equal(0, (int) BoardSquareType.Empty);
        }

        /// <summary>
        ///     Tests that floor has value 1.
        /// </summary>
        [Fact]
        public void Floor_ShouldHaveValue1()
        {
            Assert.Equal(1, (int) BoardSquareType.Floor);
        }

        /// <summary>
        ///     Tests that all wall types have distinct values.
        /// </summary>
        [Fact]
        public void WallTypes_ShouldHaveDistinctValues()
        {
            BoardSquareType[] wallTypes = new[]
            {
                BoardSquareType.WallTop,
                BoardSquareType.WallDown,
                BoardSquareType.WallLeft,
                BoardSquareType.WallRight
            };

            for (int i = 0; i < wallTypes.Length; i++)
            {
                for (int j = i + 1; j < wallTypes.Length; j++)
                {
                    Assert.NotEqual(wallTypes[i], wallTypes[j]);
                }
            }
        }

        /// <summary>
        ///     Tests that all corner types have distinct values.
        /// </summary>
        [Fact]
        public void CornerTypes_ShouldHaveDistinctValues()
        {
            BoardSquareType[] cornerTypes = new[]
            {
                BoardSquareType.CornerLeftUp,
                BoardSquareType.CornerLeftDown,
                BoardSquareType.CornerRightUp,
                BoardSquareType.CornerRightDown,
                BoardSquareType.CornerInternalLeftUp,
                BoardSquareType.CornerInternalLeftDown,
                BoardSquareType.CornerInternalRightUp,
                BoardSquareType.CornerInternalRightDown
            };

            for (int i = 0; i < cornerTypes.Length; i++)
            {
                for (int j = i + 1; j < cornerTypes.Length; j++)
                {
                    Assert.NotEqual(cornerTypes[i], cornerTypes[j]);
                }
            }
        }

        /// <summary>
        ///     Tests that all enum values are defined.
        /// </summary>
        [Theory, InlineData(BoardSquareType.Empty), InlineData(BoardSquareType.Floor), InlineData(BoardSquareType.WallTop), InlineData(BoardSquareType.WallDown), InlineData(BoardSquareType.WallLeft), InlineData(BoardSquareType.WallRight), InlineData(BoardSquareType.CornerLeftUp), InlineData(BoardSquareType.CornerLeftDown), InlineData(BoardSquareType.CornerRightUp),
         InlineData(BoardSquareType.CornerRightDown), InlineData(BoardSquareType.CornerInternalLeftUp), InlineData(BoardSquareType.CornerInternalLeftDown), InlineData(BoardSquareType.CornerInternalRightUp), InlineData(BoardSquareType.CornerInternalRightDown)]
        public void EnumValue_ShouldBeDefined(BoardSquareType type)
        {
            Assert.True(Enum.IsDefined(typeof(BoardSquareType), type));
        }

        /// <summary>
        ///     Tests that enum can be converted to string.
        /// </summary>
        [Fact]
        public void ToString_ShouldReturnName()
        {
            BoardSquareType type = BoardSquareType.Floor;

            string result = type.ToString();

            Assert.Equal("Floor", result);
        }

        /// <summary>
        ///     Tests that enum values can be compared.
        /// </summary>
        [Fact]
        public void Comparison_ShouldWork()
        {
            BoardSquareType empty = BoardSquareType.Empty;
            BoardSquareType floor = BoardSquareType.Floor;

            Assert.True(empty == BoardSquareType.Empty);
            Assert.True(floor == BoardSquareType.Floor);
            Assert.False(empty == floor);
        }

        /// <summary>
        ///     Tests that all wall types are distinct from floor and empty.
        /// </summary>
        [Theory, InlineData(BoardSquareType.WallTop), InlineData(BoardSquareType.WallDown), InlineData(BoardSquareType.WallLeft), InlineData(BoardSquareType.WallRight)]
        public void WallTypes_ShouldBeDistinctFromFloorAndEmpty(BoardSquareType wallType)
        {
            Assert.NotEqual(BoardSquareType.Empty, wallType);
            Assert.NotEqual(BoardSquareType.Floor, wallType);
        }

        /// <summary>
        ///     Tests that all corner types are distinct from floor and empty.
        /// </summary>
        [Theory, InlineData(BoardSquareType.CornerLeftUp), InlineData(BoardSquareType.CornerLeftDown), InlineData(BoardSquareType.CornerRightUp), InlineData(BoardSquareType.CornerRightDown)]
        public void OuterCornerTypes_ShouldBeDistinctFromFloorAndEmpty(BoardSquareType cornerType)
        {
            Assert.NotEqual(BoardSquareType.Empty, cornerType);
            Assert.NotEqual(BoardSquareType.Floor, cornerType);
        }

        /// <summary>
        ///     Tests that all internal corner types are distinct from floor and empty.
        /// </summary>
        [Theory, InlineData(BoardSquareType.CornerInternalLeftUp), InlineData(BoardSquareType.CornerInternalLeftDown), InlineData(BoardSquareType.CornerInternalRightUp), InlineData(BoardSquareType.CornerInternalRightDown)]
        public void InternalCornerTypes_ShouldBeDistinctFromFloorAndEmpty(BoardSquareType cornerType)
        {
            Assert.NotEqual(BoardSquareType.Empty, cornerType);
            Assert.NotEqual(BoardSquareType.Floor, cornerType);
        }
    }
}