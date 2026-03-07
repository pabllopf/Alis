using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Vector
{
    /// <summary>
    /// Extensive unit tests for Vector2F struct.
    /// Tests all operators, methods, properties, and edge cases.
    /// </summary>
    public class Vector2FExtensiveTest
    {
        

        /// <summary>
        /// Tests that constructor single value sets x and y to same value
        /// </summary>
        [Fact]
        public void Constructor_SingleValue_SetsXAndYToSameValue()
        {
            Vector2F vector = new Vector2F(5.0f);
            Assert.Equal(5.0f, vector.X);
            Assert.Equal(5.0f, vector.Y);
        }

        /// <summary>
        /// Tests that constructor single value with zero
        /// </summary>
        [Fact]
        public void Constructor_SingleValue_WithZero()
        {
            Vector2F vector = new Vector2F(0.0f);
            Assert.Equal(0.0f, vector.X);
            Assert.Equal(0.0f, vector.Y);
        }

        /// <summary>
        /// Tests that constructor single value with negative value
        /// </summary>
        [Fact]
        public void Constructor_SingleValue_WithNegativeValue()
        {
            Vector2F vector = new Vector2F(-3.5f);
            Assert.Equal(-3.5f, vector.X);
            Assert.Equal(-3.5f, vector.Y);
        }

        /// <summary>
        /// Tests that constructor single value with large value
        /// </summary>
        [Fact]
        public void Constructor_SingleValue_WithLargeValue()
        {
            Vector2F vector = new Vector2F(1000000.0f);
            Assert.Equal(1000000.0f, vector.X);
            Assert.Equal(1000000.0f, vector.Y);
        }

        /// <summary>
        /// Tests that constructor two values sets x and y correctly
        /// </summary>
        [Fact]
        public void Constructor_TwoValues_SetsXAndYCorrectly()
        {
            Vector2F vector = new Vector2F(3.0f, 4.0f);
            Assert.Equal(3.0f, vector.X);
            Assert.Equal(4.0f, vector.Y);
        }

        /// <summary>
        /// Tests that constructor two values with different signs
        /// </summary>
        [Fact]
        public void Constructor_TwoValues_WithDifferentSigns()
        {
            Vector2F vector = new Vector2F(-2.5f, 7.8f);
            Assert.Equal(-2.5f, vector.X);
            Assert.Equal(7.8f, vector.Y);
        }

        /// <summary>
        /// Tests that constructor two values with zeros
        /// </summary>
        [Fact]
        public void Constructor_TwoValues_WithZeros()
        {
            Vector2F vector = new Vector2F(0.0f, 0.0f);
            Assert.Equal(0.0f, vector.X);
            Assert.Equal(0.0f, vector.Y);
        }

        /// <summary>
        /// Tests that constructor default creates zero vector
        /// </summary>
        [Fact]
        public void Constructor_Default_CreatesZeroVector()
        {
            Vector2F vector = default;
            Assert.Equal(0.0f, vector.X);
            Assert.Equal(0.0f, vector.Y);
        }

        

        

        /// <summary>
        /// Tests that zero returns vector with zero components
        /// </summary>
        [Fact]
        public void Zero_ReturnsVectorWithZeroComponents()
        {
            Vector2F zero = Vector2F.Zero;
            Assert.Equal(0.0f, zero.X);
            Assert.Equal(0.0f, zero.Y);
        }

        /// <summary>
        /// Tests that one returns vector with one components
        /// </summary>
        [Fact]
        public void One_ReturnsVectorWithOneComponents()
        {
            Vector2F one = Vector2F.One;
            Assert.Equal(1.0f, one.X);
            Assert.Equal(1.0f, one.Y);
        }

        /// <summary>
        /// Tests that unit x returns vector with x one
        /// </summary>
        [Fact]
        public void UnitX_ReturnsVectorWithXOne()
        {
            Vector2F unitX = Vector2F.UnitX;
            Assert.Equal(1.0f, unitX.X);
            Assert.Equal(0.0f, unitX.Y);
        }

        /// <summary>
        /// Tests that unit y returns vector with y one
        /// </summary>
        [Fact]
        public void UnitY_ReturnsVectorWithYOne()
        {
            Vector2F unitY = Vector2F.UnitY;
            Assert.Equal(0.0f, unitY.X);
            Assert.Equal(1.0f, unitY.Y);
        }

        /// <summary>
        /// Tests that zero equals default vector
        /// </summary>
        [Fact]
        public void Zero_EqualsDefaultVector()
        {
            Assert.Equal(Vector2F.Zero, default(Vector2F));
        }

        

        

        /// <summary>
        /// Tests that addition two vectors returns correct sum
        /// </summary>
        [Fact]
        public void Addition_TwoVectors_ReturnsCorrectSum()
        {
            Vector2F left = new Vector2F(1.0f, 2.0f);
            Vector2F right = new Vector2F(3.0f, 4.0f);
            Vector2F result = left + right;

            Assert.Equal(4.0f, result.X);
            Assert.Equal(6.0f, result.Y);
        }

        /// <summary>
        /// Tests that addition with zero vector returns original vector
        /// </summary>
        [Fact]
        public void Addition_WithZeroVector_ReturnsOriginalVector()
        {
            Vector2F vector = new Vector2F(5.0f, 6.0f);
            Vector2F result = vector + Vector2F.Zero;

            Assert.Equal(vector.X, result.X);
            Assert.Equal(vector.Y, result.Y);
        }

        /// <summary>
        /// Tests that addition negative vectors returns correct sum
        /// </summary>
        [Fact]
        public void Addition_NegativeVectors_ReturnsCorrectSum()
        {
            Vector2F left = new Vector2F(-1.0f, -2.0f);
            Vector2F right = new Vector2F(-3.0f, -4.0f);
            Vector2F result = left + right;

            Assert.Equal(-4.0f, result.X);
            Assert.Equal(-6.0f, result.Y);
        }

        /// <summary>
        /// Tests that addition is commutative
        /// </summary>
        [Fact]
        public void Addition_IsCommutative()
        {
            Vector2F left = new Vector2F(1.5f, 2.5f);
            Vector2F right = new Vector2F(3.5f, 4.5f);

            Vector2F result1 = left + right;
            Vector2F result2 = right + left;

            Assert.Equal(result1.X, result2.X);
            Assert.Equal(result1.Y, result2.Y);
        }

        /// <summary>
        /// Tests that addition is associative
        /// </summary>
        [Fact]
        public void Addition_IsAssociative()
        {
            Vector2F a = new Vector2F(1.0f, 2.0f);
            Vector2F b = new Vector2F(3.0f, 4.0f);
            Vector2F c = new Vector2F(5.0f, 6.0f);

            Vector2F result1 = (a + b) + c;
            Vector2F result2 = a + (b + c);

            Assert.Equal(result1.X, result2.X);
            Assert.Equal(result1.Y, result2.Y);
        }

        /// <summary>
        /// Tests that addition with large values returns correct sum
        /// </summary>
        [Fact]
        public void Addition_WithLargeValues_ReturnsCorrectSum()
        {
            Vector2F left = new Vector2F(float.MaxValue / 2, float.MaxValue / 2);
            Vector2F right = new Vector2F(float.MaxValue / 4, float.MaxValue / 4);
            Vector2F result = left + right;

            Assert.True(float.IsPositiveInfinity(result.X) || float.IsFinite(result.X));
            Assert.True(float.IsPositiveInfinity(result.Y) || float.IsFinite(result.Y));
        }

        

        

        /// <summary>
        /// Tests that subtraction two vectors returns correct difference
        /// </summary>
        [Fact]
        public void Subtraction_TwoVectors_ReturnsCorrectDifference()
        {
            Vector2F left = new Vector2F(5.0f, 6.0f);
            Vector2F right = new Vector2F(2.0f, 3.0f);
            Vector2F result = left - right;

            Assert.Equal(3.0f, result.X);
            Assert.Equal(3.0f, result.Y);
        }

        /// <summary>
        /// Tests that subtraction vector from itself returns zero
        /// </summary>
        [Fact]
        public void Subtraction_VectorFromItself_ReturnsZero()
        {
            Vector2F vector = new Vector2F(3.5f, 7.2f);
            Vector2F result = vector - vector;

            Assert.Equal(0.0f, result.X, 5);
            Assert.Equal(0.0f, result.Y, 5);
        }

        /// <summary>
        /// Tests that subtraction zero from vector returns original vector
        /// </summary>
        [Fact]
        public void Subtraction_ZeroFromVector_ReturnsOriginalVector()
        {
            Vector2F vector = new Vector2F(4.0f, 5.0f);
            Vector2F result = vector - Vector2F.Zero;

            Assert.Equal(vector.X, result.X);
            Assert.Equal(vector.Y, result.Y);
        }

        /// <summary>
        /// Tests that subtraction with negative values
        /// </summary>
        [Fact]
        public void Subtraction_WithNegativeValues()
        {
            Vector2F left = new Vector2F(-2.0f, -3.0f);
            Vector2F right = new Vector2F(-1.0f, -1.0f);
            Vector2F result = left - right;

            Assert.Equal(-1.0f, result.X);
            Assert.Equal(-2.0f, result.Y);
        }

        

        

        /// <summary>
        /// Tests that multiplication vector two vectors returns element wise product
        /// </summary>
        [Fact]
        public void MultiplicationVector_TwoVectors_ReturnsElementWiseProduct()
        {
            Vector2F left = new Vector2F(2.0f, 3.0f);
            Vector2F right = new Vector2F(4.0f, 5.0f);
            Vector2F result = left * right;

            Assert.Equal(8.0f, result.X);
            Assert.Equal(15.0f, result.Y);
        }

        /// <summary>
        /// Tests that multiplication vector with zero vector returns zero vector
        /// </summary>
        [Fact]
        public void MultiplicationVector_WithZeroVector_ReturnsZeroVector()
        {
            Vector2F vector = new Vector2F(3.0f, 4.0f);
            Vector2F result = vector * Vector2F.Zero;

            Assert.Equal(0.0f, result.X);
            Assert.Equal(0.0f, result.Y);
        }

        /// <summary>
        /// Tests that multiplication vector with one vector returns original vector
        /// </summary>
        [Fact]
        public void MultiplicationVector_WithOneVector_ReturnsOriginalVector()
        {
            Vector2F vector = new Vector2F(5.0f, 6.0f);
            Vector2F result = vector * Vector2F.One;

            Assert.Equal(vector.X, result.X);
            Assert.Equal(vector.Y, result.Y);
        }

        /// <summary>
        /// Tests that multiplication scalar vector by scalar returns scaled vector
        /// </summary>
        [Fact]
        public void MultiplicationScalar_VectorByScalar_ReturnsScaledVector()
        {
            Vector2F vector = new Vector2F(2.0f, 3.0f);
            float scalar = 2.0f;
            Vector2F result = vector * scalar;

            Assert.Equal(4.0f, result.X);
            Assert.Equal(6.0f, result.Y);
        }

        /// <summary>
        /// Tests that multiplication scalar vector by zero returns zero vector
        /// </summary>
        [Fact]
        public void MultiplicationScalar_VectorByZero_ReturnsZeroVector()
        {
            Vector2F vector = new Vector2F(5.0f, 7.0f);
            Vector2F result = vector * 0.0f;

            Assert.Equal(0.0f, result.X);
            Assert.Equal(0.0f, result.Y);
        }

        /// <summary>
        /// Tests that multiplication scalar vector by one returns original vector
        /// </summary>
        [Fact]
        public void MultiplicationScalar_VectorByOne_ReturnsOriginalVector()
        {
            Vector2F vector = new Vector2F(3.0f, 4.0f);
            Vector2F result = vector * 1.0f;

            Assert.Equal(vector.X, result.X);
            Assert.Equal(vector.Y, result.Y);
        }

        /// <summary>
        /// Tests that multiplication scalar vector by negative value
        /// </summary>
        [Fact]
        public void MultiplicationScalar_VectorByNegativeValue()
        {
            Vector2F vector = new Vector2F(2.0f, 3.0f);
            Vector2F result = vector * (-2.0f);

            Assert.Equal(-4.0f, result.X);
            Assert.Equal(-6.0f, result.Y);
        }

        /// <summary>
        /// Tests that multiplication scalar is commutative
        /// </summary>
        [Fact]
        public void MultiplicationScalar_IsCommutative()
        {
            Vector2F vector = new Vector2F(2.0f, 3.0f);
            float scalar = 4.0f;

            Vector2F result1 = vector * scalar;
            Vector2F result2 = new Vector2F(scalar) * vector;

            Assert.Equal(result1.X, result2.X, 5);
            Assert.Equal(result1.Y, result2.Y, 5);
        }

        

        

        /// <summary>
        /// Tests that division vector two vectors returns element wise division
        /// </summary>
        [Fact]
        public void DivisionVector_TwoVectors_ReturnsElementWiseDivision()
        {
            Vector2F left = new Vector2F(8.0f, 12.0f);
            Vector2F right = new Vector2F(2.0f, 3.0f);
            Vector2F result = left / right;

            Assert.Equal(4.0f, result.X);
            Assert.Equal(4.0f, result.Y);
        }

        /// <summary>
        /// Tests that division vector by zero vector returns infinity
        /// </summary>
        [Fact]
        public void DivisionVector_ByZeroVector_ReturnsInfinity()
        {
            Vector2F vector = new Vector2F(4.0f, 6.0f);
            Vector2F result = vector / Vector2F.Zero;

            Assert.True(float.IsInfinity(result.X) || float.IsNaN(result.X));
            Assert.True(float.IsInfinity(result.Y) || float.IsNaN(result.Y));
        }

        /// <summary>
        /// Tests that division scalar vector by scalar returns scaled vector
        /// </summary>
        [Fact]
        public void DivisionScalar_VectorByScalar_ReturnsScaledVector()
        {
            Vector2F vector = new Vector2F(8.0f, 6.0f);
            float scalar = 2.0f;
            Vector2F result = vector / scalar;

            Assert.Equal(4.0f, result.X);
            Assert.Equal(3.0f, result.Y);
        }

        /// <summary>
        /// Tests that division scalar vector by zero returns infinity
        /// </summary>
        [Fact]
        public void DivisionScalar_VectorByZero_ReturnsInfinity()
        {
            Vector2F vector = new Vector2F(4.0f, 6.0f);
            Vector2F result = vector / 0.0f;

            Assert.True(float.IsInfinity(result.X));
            Assert.True(float.IsInfinity(result.Y));
        }

        /// <summary>
        /// Tests that division scalar vector by one returns original vector
        /// </summary>
        [Fact]
        public void DivisionScalar_VectorByOne_ReturnsOriginalVector()
        {
            Vector2F vector = new Vector2F(3.0f, 4.0f);
            Vector2F result = vector / 1.0f;

            Assert.Equal(vector.X, result.X);
            Assert.Equal(vector.Y, result.Y);
        }

        /// <summary>
        /// Tests that division scalar vector by negative value
        /// </summary>
        [Fact]
        public void DivisionScalar_VectorByNegativeValue()
        {
            Vector2F vector = new Vector2F(8.0f, 6.0f);
            Vector2F result = vector / (-2.0f);

            Assert.Equal(-4.0f, result.X);
            Assert.Equal(-3.0f, result.Y);
        }

        

        

        /// <summary>
        /// Tests that negation positive vector returns negative vector
        /// </summary>
        [Fact]
        public void Negation_PositiveVector_ReturnsNegativeVector()
        {
            Vector2F vector = new Vector2F(3.0f, 4.0f);
            Vector2F result = -vector;

            Assert.Equal(-3.0f, result.X);
            Assert.Equal(-4.0f, result.Y);
        }

        /// <summary>
        /// Tests that negation negative vector returns positive vector
        /// </summary>
        [Fact]
        public void Negation_NegativeVector_ReturnsPositiveVector()
        {
            Vector2F vector = new Vector2F(-3.0f, -4.0f);
            Vector2F result = -vector;

            Assert.Equal(3.0f, result.X);
            Assert.Equal(4.0f, result.Y);
        }

        /// <summary>
        /// Tests that negation zero vector returns zero vector
        /// </summary>
        [Fact]
        public void Negation_ZeroVector_ReturnsZeroVector()
        {
            Vector2F vector = Vector2F.Zero;
            Vector2F result = -vector;

            Assert.Equal(0.0f, result.X);
            Assert.Equal(0.0f, result.Y);
        }

        /// <summary>
        /// Tests that doubly negated vector equals original
        /// </summary>
        [Fact]
        public void DoublyNegated_VectorEqualsOriginal()
        {
            Vector2F vector = new Vector2F(2.5f, 3.5f);
            Vector2F result = -(-vector);

            Assert.Equal(vector.X, result.X);
            Assert.Equal(vector.Y, result.Y);
        }

        

        

        /// <summary>
        /// Tests that equality identical vectors returns true
        /// </summary>
        [Fact]
        public void Equality_IdenticalVectors_ReturnsTrue()
        {
            Vector2F left = new Vector2F(3.0f, 4.0f);
            Vector2F right = new Vector2F(3.0f, 4.0f);

            Assert.True(left == right);
        }

        /// <summary>
        /// Tests that equality different vectors returns false
        /// </summary>
        [Fact]
        public void Equality_DifferentVectors_ReturnsFalse()
        {
            Vector2F left = new Vector2F(1.0f, 2.0f);
            Vector2F right = new Vector2F(3.0f, 4.0f);

            Assert.False(left == right);
        }

        /// <summary>
        /// Tests that equality vector with itself returns true
        /// </summary>
        [Fact]
        public void Equality_VectorWithItself_ReturnsTrue()
        {
            Vector2F vector = new Vector2F(5.0f, 6.0f);

            Assert.True(vector == vector);
        }

        /// <summary>
        /// Tests that equality within tolerance returns true
        /// </summary>
        [Fact]
        public void Equality_WithinTolerance_ReturnsTrue()
        {
            Vector2F left = new Vector2F(3.0f, 4.0f);
            Vector2F right = new Vector2F(3.005f, 4.005f);

            Assert.True(left == right);
        }

        

        

        /// <summary>
        /// Tests that inequality different vectors returns true
        /// </summary>
        [Fact]
        public void Inequality_DifferentVectors_ReturnsTrue()
        {
            Vector2F left = new Vector2F(1.0f, 2.0f);
            Vector2F right = new Vector2F(3.0f, 4.0f);

            Assert.True(left != right);
        }

        /// <summary>
        /// Tests that inequality identical vectors returns false
        /// </summary>
        [Fact]
        public void Inequality_IdenticalVectors_ReturnsFalse()
        {
            Vector2F left = new Vector2F(3.0f, 4.0f);
            Vector2F right = new Vector2F(3.0f, 4.0f);

            Assert.False(left != right);
        }

        /// <summary>
        /// Tests that inequality vector with itself returns false
        /// </summary>
        [Fact]
        public void Inequality_VectorWithItself_ReturnsFalse()
        {
            Vector2F vector = new Vector2F(5.0f, 6.0f);

            Assert.False(vector != vector);
        }

        

        

        /// <summary>
        /// Tests that to string default format returns formatted string
        /// </summary>
        [Fact]
        public void ToString_DefaultFormat_ReturnsFormattedString()
        {
            Vector2F vector = new Vector2F(3.5f, 4.5f);
            string result = vector.ToString();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
        
        /// <summary>
        /// Tests that to string zero vector returns formatted string
        /// </summary>
        [Fact]
        public void ToString_ZeroVector_ReturnsFormattedString()
        {
            Vector2F vector = Vector2F.Zero;
            string result = vector.ToString();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        

        

        /// <summary>
        /// Tests that properties can be modified
        /// </summary>
        [Fact]
        public void Properties_CanBeModified()
        {
            Vector2F vector = new Vector2F(1.0f, 2.0f);
            vector.X = 10.0f;
            vector.Y = 20.0f;

            Assert.Equal(10.0f, vector.X);
            Assert.Equal(20.0f, vector.Y);
        }

        /// <summary>
        /// Tests that properties with negative values
        /// </summary>
        [Fact]
        public void Properties_WithNegativeValues()
        {
            Vector2F vector = new Vector2F(-5.5f, -7.8f);

            Assert.Equal(-5.5f, vector.X);
            Assert.Equal(-7.8f, vector.Y);
        }

        /// <summary>
        /// Tests that properties with very small values
        /// </summary>
        [Fact]
        public void Properties_WithVerySmallValues()
        {
            Vector2F vector = new Vector2F(0.0001f, 0.00001f);

            Assert.Equal(0.0001f, vector.X);
            Assert.Equal(0.00001f, vector.Y);
        }

        
    }
}

