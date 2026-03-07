using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Matrix
{
    /// <summary>
    /// The matrix test class
    /// </summary>
    public class Matrix3X2Test
    {
        /// <summary>
        /// Tests that constructor sets all components
        /// </summary>
        [Fact]
        public void Constructor_SetsAllComponents()
        {
            Matrix3X2 matrix = new Matrix3X2(1f, 2f, 3f, 4f, 5f, 6f);

            Assert.Equal(1f, matrix.M11);
            Assert.Equal(2f, matrix.M12);
            Assert.Equal(3f, matrix.M21);
            Assert.Equal(4f, matrix.M22);
            Assert.Equal(5f, matrix.M31);
            Assert.Equal(6f, matrix.M32);
        }

        /// <summary>
        /// Tests that translation setter updates m 31 and m 32
        /// </summary>
        [Fact]
        public void Translation_Setter_UpdatesM31AndM32()
        {
            Matrix3X2 matrix = new Matrix3X2(1f, 0f, 0f, 1f, 0f, 0f)
            {
                Translation = new Vector2F(8f, 9f)
            };

            Assert.Equal(8f, matrix.M31);
            Assert.Equal(9f, matrix.M32);
        }

        /// <summary>
        /// Tests that operators add subtract negate and scale return expected values
        /// </summary>
        [Fact]
        public void Operators_AddSubtractNegateAndScale_ReturnExpectedValues()
        {
            Matrix3X2 left = new Matrix3X2(1f, 2f, 3f, 4f, 5f, 6f);
            Matrix3X2 right = new Matrix3X2(2f, 3f, 4f, 5f, 6f, 7f);

            Matrix3X2 sum = left + right;
            Matrix3X2 diff = left - right;
            Matrix3X2 negated = -left;
            Matrix3X2 scaled = left * 2f;

            Assert.Equal(3f, sum.M11);
            Assert.Equal(5f, sum.M12);
            Assert.Equal(-1f, diff.M11);
            Assert.Equal(-1f, diff.M12);
            Assert.Equal(-1f, negated.M11);
            Assert.Equal(-6f, negated.M32);
            Assert.Equal(2f, scaled.M11);
            Assert.Equal(12f, scaled.M32);
        }

        /// <summary>
        /// Tests that multiply matrix by matrix computes affine product
        /// </summary>
        [Fact]
        public void Multiply_MatrixByMatrix_ComputesAffineProduct()
        {
            Matrix3X2 left = new Matrix3X2(1f, 2f, 3f, 4f, 5f, 6f);
            Matrix3X2 right = new Matrix3X2(7f, 8f, 9f, 10f, 11f, 12f);

            Matrix3X2 result = left * right;

            Assert.Equal(25f, result.M11);
            Assert.Equal(28f, result.M12);
            Assert.Equal(57f, result.M21);
            Assert.Equal(64f, result.M22);
            Assert.Equal(100f, result.M31);
            Assert.Equal(112f, result.M32);
        }

        /// <summary>
        /// Tests that equality uses tolerance
        /// </summary>
        [Fact]
        public void Equality_UsesTolerance()
        {
            Matrix3X2 first = new Matrix3X2(1f, 2f, 3f, 4f, 5f, 6f);
            Matrix3X2 second = new Matrix3X2(1.05f, 2.05f, 3.05f, 4.05f, 5.05f, 6.05f);
            Matrix3X2 third = new Matrix3X2(1.2f, 2f, 3f, 4f, 5f, 6f);

            Assert.True(first == second);
            Assert.False(first != second);
            Assert.True(first != third);
        }

        /// <summary>
        /// Tests that utility members return expected values
        /// </summary>
        [Fact]
        public void UtilityMembers_ReturnExpectedValues()
        {
            Matrix3X2 matrix = new Matrix3X2(2f, 3f, 4f, 5f, 0f, 0f);

            Assert.Equal(-2f, matrix.GetDeterminant());
            Assert.Contains("M11:2", matrix.ToString());
            Assert.Contains("M22:5", matrix.ToString());

            Matrix3X2 added = Matrix3X2.Add(matrix, matrix);
            Assert.Equal(4f, added.M11);
            Assert.Equal(6f, added.M12);
            Assert.Equal(8f, added.M21);
            Assert.Equal(10f, added.M22);
            Assert.Equal(0f, added.M31);
            Assert.Equal(0f, added.M32);
        }
    }
}
