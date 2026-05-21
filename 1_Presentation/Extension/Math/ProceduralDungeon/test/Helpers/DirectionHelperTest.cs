

using System;
using Alis.Extension.Math.ProceduralDungeon.Helpers;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test.Helpers
{
    /// <summary>
    ///     Test class for <see cref="DirectionHelper" />.
    ///     Verifies all direction-related utility methods.
    /// </summary>
    public class DirectionHelperTest
    {
        /// <summary>
        ///     Tests that GetOpposite returns the correct opposite direction for North.
        /// </summary>
        [Fact]
        public void GetOpposite_WithNorth_ReturnsSouth()
        {
            Direction direction = Direction.North;

            Direction opposite = DirectionHelper.GetOpposite(direction);

            Assert.Equal(Direction.South, opposite);
        }

        /// <summary>
        ///     Tests that GetOpposite returns the correct opposite direction for South.
        /// </summary>
        [Fact]
        public void GetOpposite_WithSouth_ReturnsNorth()
        {
            Direction direction = Direction.South;

            Direction opposite = DirectionHelper.GetOpposite(direction);

            Assert.Equal(Direction.North, opposite);
        }

        /// <summary>
        ///     Tests that GetOpposite returns the correct opposite direction for East.
        /// </summary>
        [Fact]
        public void GetOpposite_WithEast_ReturnsWest()
        {
            Direction direction = Direction.East;

            Direction opposite = DirectionHelper.GetOpposite(direction);

            Assert.Equal(Direction.West, opposite);
        }

        /// <summary>
        ///     Tests that GetOpposite returns the correct opposite direction for West.
        /// </summary>
        [Fact]
        public void GetOpposite_WithWest_ReturnsEast()
        {
            Direction direction = Direction.West;

            Direction opposite = DirectionHelper.GetOpposite(direction);

            Assert.Equal(Direction.East, opposite);
        }

        /// <summary>
        ///     Tests that GetOpposite throws exception for None direction.
        /// </summary>
        [Fact]
        public void GetOpposite_WithNone_ThrowsArgumentOutOfRangeException()
        {
            Direction direction = Direction.None;

            Assert.Throws<ArgumentOutOfRangeException>(() => DirectionHelper.GetOpposite(direction));
        }

        /// <summary>
        ///     Tests that IsValid returns true for valid directions.
        /// </summary>
        [Theory, InlineData(Direction.North), InlineData(Direction.South), InlineData(Direction.East), InlineData(Direction.West)]
        public void IsValid_WithValidDirection_ReturnsTrue(Direction direction)
        {
            bool isValid = DirectionHelper.IsValid(direction);

            Assert.True(isValid);
        }

        /// <summary>
        ///     Tests that IsValid returns false for None direction.
        /// </summary>
        [Fact]
        public void IsValid_WithNone_ReturnsFalse()
        {
            Direction direction = Direction.None;

            bool isValid = DirectionHelper.IsValid(direction);

            Assert.False(isValid);
        }

        /// <summary>
        ///     Tests that IsValid returns false for invalid enum value.
        /// </summary>
        [Fact]
        public void IsValid_WithInvalidValue_ReturnsFalse()
        {
            Direction direction = (Direction) 999;

            bool isValid = DirectionHelper.IsValid(direction);

            Assert.False(isValid);
        }

        /// <summary>
        ///     Tests that AreOpposite returns true for North and South.
        /// </summary>
        [Fact]
        public void AreOpposite_WithNorthAndSouth_ReturnsTrue()
        {
            Direction first = Direction.North;
            Direction second = Direction.South;

            bool areOpposite = DirectionHelper.AreOpposite(first, second);

            Assert.True(areOpposite);
        }

        /// <summary>
        ///     Tests that AreOpposite returns true for South and North.
        /// </summary>
        [Fact]
        public void AreOpposite_WithSouthAndNorth_ReturnsTrue()
        {
            Direction first = Direction.South;
            Direction second = Direction.North;

            bool areOpposite = DirectionHelper.AreOpposite(first, second);

            Assert.True(areOpposite);
        }

        /// <summary>
        ///     Tests that AreOpposite returns true for East and West.
        /// </summary>
        [Fact]
        public void AreOpposite_WithEastAndWest_ReturnsTrue()
        {
            Direction first = Direction.East;
            Direction second = Direction.West;

            bool areOpposite = DirectionHelper.AreOpposite(first, second);

            Assert.True(areOpposite);
        }

        /// <summary>
        ///     Tests that AreOpposite returns false for non-opposite directions.
        /// </summary>
        [Theory, InlineData(Direction.North, Direction.East), InlineData(Direction.North, Direction.West), InlineData(Direction.South, Direction.East), InlineData(Direction.South, Direction.West)]
        public void AreOpposite_WithNonOppositeDirections_ReturnsFalse(Direction first, Direction second)
        {
            bool areOpposite = DirectionHelper.AreOpposite(first, second);

            Assert.False(areOpposite);
        }

        /// <summary>
        ///     Tests that AreOpposite throws exception when first direction is None.
        /// </summary>
        [Fact]
        public void AreOpposite_WithFirstNone_ThrowsArgumentOutOfRangeException()
        {
            Direction first = Direction.None;
            Direction second = Direction.North;

            Assert.Throws<ArgumentOutOfRangeException>(() => DirectionHelper.AreOpposite(first, second));
        }

        /// <summary>
        ///     Tests that AreOpposite throws exception when second direction is None.
        /// </summary>
        [Fact]
        public void AreOpposite_WithSecondNone_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            Direction first = Direction.North;
            Direction second = Direction.None;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DirectionHelper.AreOpposite(first, second));
        }

        /// <summary>
        ///     Tests that GetOffset returns correct values for North.
        /// </summary>
        [Fact]
        public void GetOffset_WithNorth_ReturnsCorrectOffset()
        {
            // Arrange
            Direction direction = Direction.North;

            // Act
            (int x, int y) = DirectionHelper.GetOffset(direction);

            // Assert
            Assert.Equal(0, x);
            Assert.Equal(1, y);
        }

        /// <summary>
        ///     Tests that GetOffset returns correct values for South.
        /// </summary>
        [Fact]
        public void GetOffset_WithSouth_ReturnsCorrectOffset()
        {
            // Arrange
            Direction direction = Direction.South;

            // Act
            (int x, int y) = DirectionHelper.GetOffset(direction);

            // Assert
            Assert.Equal(0, x);
            Assert.Equal(-1, y);
        }

        /// <summary>
        ///     Tests that GetOffset returns correct values for East.
        /// </summary>
        [Fact]
        public void GetOffset_WithEast_ReturnsCorrectOffset()
        {
            // Arrange
            Direction direction = Direction.East;

            // Act
            (int x, int y) = DirectionHelper.GetOffset(direction);

            // Assert
            Assert.Equal(1, x);
            Assert.Equal(0, y);
        }

        /// <summary>
        ///     Tests that GetOffset returns correct values for West.
        /// </summary>
        [Fact]
        public void GetOffset_WithWest_ReturnsCorrectOffset()
        {
            // Arrange
            Direction direction = Direction.West;

            // Act
            (int x, int y) = DirectionHelper.GetOffset(direction);

            // Assert
            Assert.Equal(-1, x);
            Assert.Equal(0, y);
        }

        /// <summary>
        ///     Tests that GetOffset throws exception for None.
        /// </summary>
        [Fact]
        public void GetOffset_WithNone_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            Direction direction = Direction.None;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DirectionHelper.GetOffset(direction));
        }

        /// <summary>
        ///     Tests that IsHorizontal returns true for East.
        /// </summary>
        [Fact]
        public void IsHorizontal_WithEast_ReturnsTrue()
        {
            // Arrange
            Direction direction = Direction.East;

            // Act
            bool isHorizontal = DirectionHelper.IsHorizontal(direction);

            // Assert
            Assert.True(isHorizontal);
        }

        /// <summary>
        ///     Tests that IsHorizontal returns true for West.
        /// </summary>
        [Fact]
        public void IsHorizontal_WithWest_ReturnsTrue()
        {
            // Arrange
            Direction direction = Direction.West;

            // Act
            bool isHorizontal = DirectionHelper.IsHorizontal(direction);

            // Assert
            Assert.True(isHorizontal);
        }

        /// <summary>
        ///     Tests that IsHorizontal returns false for vertical directions.
        /// </summary>
        [Theory, InlineData(Direction.North), InlineData(Direction.South)]
        public void IsHorizontal_WithVerticalDirection_ReturnsFalse(Direction direction)
        {
            // Act
            bool isHorizontal = DirectionHelper.IsHorizontal(direction);

            // Assert
            Assert.False(isHorizontal);
        }

        /// <summary>
        ///     Tests that IsHorizontal throws exception for None.
        /// </summary>
        [Fact]
        public void IsHorizontal_WithNone_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            Direction direction = Direction.None;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DirectionHelper.IsHorizontal(direction));
        }

        /// <summary>
        ///     Tests that IsVertical returns true for North.
        /// </summary>
        [Fact]
        public void IsVertical_WithNorth_ReturnsTrue()
        {
            // Arrange
            Direction direction = Direction.North;

            // Act
            bool isVertical = DirectionHelper.IsVertical(direction);

            // Assert
            Assert.True(isVertical);
        }

        /// <summary>
        ///     Tests that IsVertical returns true for South.
        /// </summary>
        [Fact]
        public void IsVertical_WithSouth_ReturnsTrue()
        {
            // Arrange
            Direction direction = Direction.South;

            // Act
            bool isVertical = DirectionHelper.IsVertical(direction);

            // Assert
            Assert.True(isVertical);
        }

        /// <summary>
        ///     Tests that IsVertical returns false for horizontal directions.
        /// </summary>
        [Theory, InlineData(Direction.East), InlineData(Direction.West)]
        public void IsVertical_WithHorizontalDirection_ReturnsFalse(Direction direction)
        {
            // Act
            bool isVertical = DirectionHelper.IsVertical(direction);

            // Assert
            Assert.False(isVertical);
        }

        /// <summary>
        ///     Tests that IsVertical throws exception for None.
        /// </summary>
        [Fact]
        public void IsVertical_WithNone_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            Direction direction = Direction.None;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => DirectionHelper.IsVertical(direction));
        }
    }
}