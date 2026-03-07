using Alis.Core.Aspect.Math.Shapes;
using Alis.Core.Aspect.Math.Shapes.Point;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape
{
    /// <summary>
    /// Extensive unit tests for PointF struct.
    /// Tests all operators, methods, properties, and edge cases.
    /// </summary>
    public class PointFExtensiveTest
    {
        

        /// <summary>
        /// Tests that constructor single value sets x and y to same value
        /// </summary>
        [Fact]
        public void Constructor_SingleValue_SetsXAndYToSameValue()
        {
            PointF point = new PointF(5.0f);
            Assert.Equal(5.0f, point.X);
            Assert.Equal(5.0f, point.Y);
        }

        /// <summary>
        /// Tests that constructor single value with zero
        /// </summary>
        [Fact]
        public void Constructor_SingleValue_WithZero()
        {
            PointF point = new PointF(0.0f);
            Assert.Equal(0.0f, point.X);
            Assert.Equal(0.0f, point.Y);
        }

        /// <summary>
        /// Tests that constructor single value with negative value
        /// </summary>
        [Fact]
        public void Constructor_SingleValue_WithNegativeValue()
        {
            PointF point = new PointF(-3.5f);
            Assert.Equal(-3.5f, point.X);
            Assert.Equal(-3.5f, point.Y);
        }

        /// <summary>
        /// Tests that constructor single value with large value
        /// </summary>
        [Fact]
        public void Constructor_SingleValue_WithLargeValue()
        {
            PointF point = new PointF(999999.99f);
            Assert.Equal(999999.99f, point.X);
            Assert.Equal(999999.99f, point.Y);
        }

        /// <summary>
        /// Tests that constructor two values sets x and y correctly
        /// </summary>
        [Fact]
        public void Constructor_TwoValues_SetsXAndYCorrectly()
        {
            PointF point = new PointF(3.0f, 4.0f);
            Assert.Equal(3.0f, point.X);
            Assert.Equal(4.0f, point.Y);
        }

        /// <summary>
        /// Tests that constructor two values with different signs
        /// </summary>
        [Fact]
        public void Constructor_TwoValues_WithDifferentSigns()
        {
            PointF point = new PointF(-2.5f, 7.8f);
            Assert.Equal(-2.5f, point.X);
            Assert.Equal(7.8f, point.Y);
        }

        /// <summary>
        /// Tests that constructor two values with zeros
        /// </summary>
        [Fact]
        public void Constructor_TwoValues_WithZeros()
        {
            PointF point = new PointF(0.0f, 0.0f);
            Assert.Equal(0.0f, point.X);
            Assert.Equal(0.0f, point.Y);
        }

        /// <summary>
        /// Tests that constructor copy constructor copies values
        /// </summary>
        [Fact]
        public void Constructor_CopyConstructor_CopiesValues()
        {
            PointF original = new PointF(5.5f, 6.6f);
            PointF copy = new PointF(original);

            Assert.Equal(original.X, copy.X);
            Assert.Equal(original.Y, copy.Y);
        }

        /// <summary>
        /// Tests that constructor copy constructor with zero point
        /// </summary>
        [Fact]
        public void Constructor_CopyConstructor_WithZeroPoint()
        {
            PointF original = new PointF(0.0f, 0.0f);
            PointF copy = new PointF(original);

            Assert.Equal(original.X, copy.X);
            Assert.Equal(original.Y, copy.Y);
        }

        /// <summary>
        /// Tests that constructor copy constructor is independent
        /// </summary>
        [Fact]
        public void Constructor_CopyConstructor_IsIndependent()
        {
            PointF original = new PointF(1.0f, 2.0f);
            PointF copy = new PointF(original);

            original.X = 10.0f;
            original.Y = 20.0f;

            Assert.Equal(1.0f, copy.X);
            Assert.Equal(2.0f, copy.Y);
        }

        /// <summary>
        /// Tests that constructor default creates zero point
        /// </summary>
        [Fact]
        public void Constructor_Default_CreatesZeroPoint()
        {
            PointF point = default;
            Assert.Equal(0.0f, point.X);
            Assert.Equal(0.0f, point.Y);
        }

        

        

        /// <summary>
        /// Tests that properties can be modified
        /// </summary>
        [Fact]
        public void Properties_CanBeModified()
        {
            PointF point = new PointF(1.0f, 2.0f);
            point.X = 10.0f;
            point.Y = 20.0f;

            Assert.Equal(10.0f, point.X);
            Assert.Equal(20.0f, point.Y);
        }

        /// <summary>
        /// Tests that properties with negative values
        /// </summary>
        [Fact]
        public void Properties_WithNegativeValues()
        {
            PointF point = new PointF(-5.5f, -7.8f);

            Assert.Equal(-5.5f, point.X);
            Assert.Equal(-7.8f, point.Y);
        }

        /// <summary>
        /// Tests that properties with very small values
        /// </summary>
        [Fact]
        public void Properties_WithVerySmallValues()
        {
            PointF point = new PointF(0.0001f, 0.00001f);

            Assert.Equal(0.0001f, point.X);
            Assert.Equal(0.00001f, point.Y);
        }

        /// <summary>
        /// Tests that properties with max value
        /// </summary>
        [Fact]
        public void Properties_WithMaxValue()
        {
            PointF point = new PointF(float.MaxValue, float.MaxValue);

            Assert.Equal(float.MaxValue, point.X);
            Assert.Equal(float.MaxValue, point.Y);
        }

        /// <summary>
        /// Tests that properties with min value
        /// </summary>
        [Fact]
        public void Properties_WithMinValue()
        {
            PointF point = new PointF(float.MinValue, float.MinValue);

            Assert.Equal(float.MinValue, point.X);
            Assert.Equal(float.MinValue, point.Y);
        }

        

        

        /// <summary>
        /// Tests that i shape point f implements interface
        /// </summary>
        [Fact]
        public void IShape_PointFImplementsInterface()
        {
            PointF point = new PointF(1.0f, 2.0f);
            Assert.IsAssignableFrom<IShape>(point);
        }

        

        

        /// <summary>
        /// Tests that struct is value type
        /// </summary>
        [Fact]
        public void Struct_IsValueType()
        {
            Assert.True(typeof(PointF).IsValueType);
        }


        /// <summary>
        /// Tests that value semantics copy is independent
        /// </summary>
        [Fact]
        public void ValueSemantics_CopyIsIndependent()
        {
            PointF point1 = new PointF(1.0f, 2.0f);
            PointF point2 = point1;
            point2.X = 10.0f;

            Assert.Equal(1.0f, point1.X);
            Assert.Equal(10.0f, point2.X);
        }

        

        

        /// <summary>
        /// Tests that constructor with positive infinity
        /// </summary>
        [Fact]
        public void Constructor_WithPositiveInfinity()
        {
            PointF point = new PointF(float.PositiveInfinity, float.PositiveInfinity);

            Assert.Equal(float.PositiveInfinity, point.X);
            Assert.Equal(float.PositiveInfinity, point.Y);
        }

        /// <summary>
        /// Tests that constructor with negative infinity
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeInfinity()
        {
            PointF point = new PointF(float.NegativeInfinity, float.NegativeInfinity);

            Assert.Equal(float.NegativeInfinity, point.X);
            Assert.Equal(float.NegativeInfinity, point.Y);
        }

        /// <summary>
        /// Tests that constructor with na n
        /// </summary>
        [Fact]
        public void Constructor_WithNaN()
        {
            PointF point = new PointF(float.NaN, float.NaN);

            Assert.True(float.IsNaN(point.X));
            Assert.True(float.IsNaN(point.Y));
        }

        /// <summary>
        /// Tests that constructor with mixed special values
        /// </summary>
        [Fact]
        public void Constructor_WithMixedSpecialValues()
        {
            PointF point = new PointF(float.PositiveInfinity, float.NegativeInfinity);

            Assert.Equal(float.PositiveInfinity, point.X);
            Assert.Equal(float.NegativeInfinity, point.Y);
        }

        
    }
}

