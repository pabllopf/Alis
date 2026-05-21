

using Alis.Extension.Math.ProceduralDungeon.Models;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test.Models
{
    /// <summary>
    ///     Test class for <see cref="Position" />.
    ///     Verifies position struct operations and properties.
    /// </summary>
    public class PositionTest
    {
        /// <summary>
        ///     Tests that constructor sets properties correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithValidValues_SetsProperties()
        {
            int x = 10;
            int y = 20;

            Position position = new Position(x, y);

            Assert.Equal(x, position.X);
            Assert.Equal(y, position.Y);
        }

        /// <summary>
        ///     Tests that Zero returns origin position.
        /// </summary>
        [Fact]
        public void Zero_ReturnsOriginPosition()
        {
            Position zero = Position.Zero;

            Assert.Equal(0, zero.X);
            Assert.Equal(0, zero.Y);
        }

        /// <summary>
        ///     Tests addition operator.
        /// </summary>
        [Fact]
        public void AdditionOperator_WithTwoPositions_ReturnsSum()
        {
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(3, 7);

            Position result = pos1 + pos2;

            Assert.Equal(8, result.X);
            Assert.Equal(17, result.Y);
        }

        /// <summary>
        ///     Tests subtraction operator.
        /// </summary>
        [Fact]
        public void SubtractionOperator_WithTwoPositions_ReturnsDifference()
        {
            Position pos1 = new Position(10, 20);
            Position pos2 = new Position(3, 7);

            Position result = pos1 - pos2;

            Assert.Equal(7, result.X);
            Assert.Equal(13, result.Y);
        }

        /// <summary>
        ///     Tests equality operator with equal positions.
        /// </summary>
        [Fact]
        public void EqualityOperator_WithEqualPositions_ReturnsTrue()
        {
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(5, 10);

            bool result = pos1 == pos2;

            Assert.True(result);
        }

        /// <summary>
        ///     Tests equality operator with different positions.
        /// </summary>
        [Fact]
        public void EqualityOperator_WithDifferentPositions_ReturnsFalse()
        {
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(3, 7);

            bool result = pos1 == pos2;

            Assert.False(result);
        }

        /// <summary>
        ///     Tests inequality operator with different positions.
        /// </summary>
        [Fact]
        public void InequalityOperator_WithDifferentPositions_ReturnsTrue()
        {
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(3, 7);

            bool result = pos1 != pos2;

            Assert.True(result);
        }

        /// <summary>
        ///     Tests inequality operator with equal positions.
        /// </summary>
        [Fact]
        public void InequalityOperator_WithEqualPositions_ReturnsFalse()
        {
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(5, 10);

            bool result = pos1 != pos2;

            Assert.False(result);
        }

        /// <summary>
        ///     Tests Equals method with equal position.
        /// </summary>
        [Fact]
        public void Equals_WithEqualPosition_ReturnsTrue()
        {
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(5, 10);

            bool result = pos1.Equals(pos2);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests Equals method with different position.
        /// </summary>
        [Fact]
        public void Equals_WithDifferentPosition_ReturnsFalse()
        {
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(3, 7);

            bool result = pos1.Equals(pos2);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests Equals method with object parameter.
        /// </summary>
        [Fact]
        public void Equals_WithObjectParameter_ReturnsCorrectResult()
        {
            Position pos1 = new Position(5, 10);
            object pos2 = new Position(5, 10);
            object notPosition = "not a position";

            bool equalResult = pos1.Equals(pos2);
            bool notEqualResult = pos1.Equals(notPosition);

            Assert.True(equalResult);
            Assert.False(notEqualResult);
        }

        /// <summary>
        ///     Tests GetHashCode returns consistent values.
        /// </summary>
        [Fact]
        public void GetHashCode_WithEqualPositions_ReturnsSameValue()
        {
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(5, 10);

            int hash1 = pos1.GetHashCode();
            int hash2 = pos2.GetHashCode();

            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Tests ToString returns formatted string.
        /// </summary>
        [Fact]
        public void ToString_ReturnsFormattedString()
        {
            Position position = new Position(5, 10);

            string result = position.ToString();

            Assert.Equal("(5, 10)", result);
        }

        /// <summary>
        ///     Tests ManhattanDistanceTo calculates correct distance.
        /// </summary>
        [Fact]
        public void ManhattanDistanceTo_WithAnotherPosition_ReturnsCorrectDistance()
        {
            Position pos1 = new Position(0, 0);
            Position pos2 = new Position(3, 4);

            int distance = pos1.ManhattanDistanceTo(pos2);

            Assert.Equal(7, distance);
        }

        /// <summary>
        ///     Tests ManhattanDistanceTo with negative coordinates.
        /// </summary>
        [Fact]
        public void ManhattanDistanceTo_WithNegativeCoordinates_ReturnsCorrectDistance()
        {
            Position pos1 = new Position(-5, -5);
            Position pos2 = new Position(3, 4);

            int distance = pos1.ManhattanDistanceTo(pos2);

            Assert.Equal(17, distance); // |3-(-5)| + |4-(-5)| = 8 + 9 = 17
        }

        /// <summary>
        ///     Tests ManhattanDistanceTo with same position.
        /// </summary>
        [Fact]
        public void ManhattanDistanceTo_WithSamePosition_ReturnsZero()
        {
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(5, 10);

            int distance = pos1.ManhattanDistanceTo(pos2);

            Assert.Equal(0, distance);
        }

        /// <summary>
        ///     Tests addition operator.
        /// </summary>
        [Fact]
        public void AdditionOperator_WithTwoPositions_ReturnsCorrectSum()
        {
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(3, 7);

            Position result = pos1 + pos2;

            Assert.Equal(8, result.X);
            Assert.Equal(17, result.Y);
        }

        /// <summary>
        ///     Tests addition operator with negative coordinates.
        /// </summary>
        [Fact]
        public void AdditionOperator_WithNegativeCoordinates_ReturnsCorrectSum()
        {
            Position pos1 = new Position(-5, 10);
            Position pos2 = new Position(3, -7);

            Position result = pos1 + pos2;

            Assert.Equal(-2, result.X);
            Assert.Equal(3, result.Y);
        }

        /// <summary>
        ///     Tests subtraction operator.
        /// </summary>
        [Fact]
        public void SubtractionOperator_WithTwoPositions_ReturnsCorrectDifference()
        {
            Position pos1 = new Position(10, 20);
            Position pos2 = new Position(3, 7);

            Position result = pos1 - pos2;

            Assert.Equal(7, result.X);
            Assert.Equal(13, result.Y);
        }

        /// <summary>
        ///     Tests subtraction operator resulting in negative coordinates.
        /// </summary>
        [Fact]
        public void SubtractionOperator_WithResultInNegativeValues_ReturnsCorrectDifference()
        {
            Position pos1 = new Position(3, 7);
            Position pos2 = new Position(10, 20);

            Position result = pos1 - pos2;

            Assert.Equal(-7, result.X);
            Assert.Equal(-13, result.Y);
        }

        /// <summary>
        ///     Tests Zero property returns correct origin.
        /// </summary>
        [Fact]
        public void Zero_ShouldReturnOriginPosition()
        {
            Position zero = Position.Zero;

            Assert.Equal(0, zero.X);
            Assert.Equal(0, zero.Y);
        }

        /// <summary>
        ///     Tests ManhattanDistanceTo with various coordinate combinations.
        /// </summary>
        [Theory, InlineData(0, 0, 1, 1, 2), InlineData(0, 0, 0, 0, 0), InlineData(0, 0, 10, 0, 10), InlineData(0, 0, 0, 10, 10), InlineData(5, 5, 10, 10, 10), InlineData(-5, -5, 5, 5, 20)]
        public void ManhattanDistanceTo_WithVariousPositions_ReturnsCorrectDistance(int x1, int y1, int x2, int y2, int expected)
        {
            Position pos1 = new Position(x1, y1);
            Position pos2 = new Position(x2, y2);

            int distance = pos1.ManhattanDistanceTo(pos2);

            Assert.Equal(expected, distance);
        }

        /// <summary>
        ///     Tests GetHashCode with various positions.
        /// </summary>
        [Fact]
        public void GetHashCode_WithDifferentPositions_ReturnsDifferentValues()
        {
            Position pos1 = new Position(5, 10);
            Position pos2 = new Position(5, 11);
            Position pos3 = new Position(6, 10);

            int hash1 = pos1.GetHashCode();
            int hash2 = pos2.GetHashCode();
            int hash3 = pos3.GetHashCode();

            Assert.NotEqual(hash1, hash2);
            Assert.NotEqual(hash1, hash3);
        }

        /// <summary>
        ///     Tests constructor with negative coordinates.
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeCoordinates_SetsPropertiesCorrectly()
        {
            int x = -100;
            int y = -200;

            Position position = new Position(x, y);

            Assert.Equal(x, position.X);
            Assert.Equal(y, position.Y);
        }

        /// <summary>
        ///     Tests with maximum and minimum integer values.
        /// </summary>
        [Fact]
        public void Constructor_WithExtremeLargeValues_SetsPropertiesCorrectly()
        {
            int x = int.MaxValue;
            int y = int.MinValue;

            Position position = new Position(x, y);

            Assert.Equal(x, position.X);
            Assert.Equal(y, position.Y);
        }
    }
}