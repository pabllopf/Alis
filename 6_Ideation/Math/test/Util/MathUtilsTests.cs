// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MathUtilsTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Aspect.Math.Matrix;
using Xunit;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;


namespace Alis.Core.Aspect.Math.Test.Util
{

    /// <summary>
    /// The math utils tests class
    /// </summary>
    public class MathUtilsTests
    {
        /// <summary>
        /// Tests that cross with two vectors returns correct result
        /// </summary>
        [Fact]
        public void Cross_WithTwoVectors_ReturnsCorrectResult()
        {
            // Arrange
            Vector2 vector1 = new Vector2(1, 2);
            Vector2 vector2 = new Vector2(3, 4);
            int expected = -2;

            // Act
            float result = MathUtils.Cross(vector1, vector2);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that dot with two vectors returns correct result
        /// </summary>
        [Fact]
        public void Dot_WithTwoVectors_ReturnsCorrectResult()
        {
            // Arrange
            Vector2 vector1 = new Vector2(1, 2);
            Vector2 vector2 = new Vector2(3, 4);
            int expected = 11;

            // Act
            float result = MathUtils.Dot(vector1, vector2);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that cross with two vector 2 returns correct result
        /// </summary>
        [Fact]
        public void Cross_WithTwoVector2_ReturnsCorrectResult()
        {
            // Arrange
            Vector2 vector1 = new Vector2(1, 2);
            Vector2 vector2 = new Vector2(3, 4);
            float expected = -2;

            // Act
            float result = MathUtils.Cross(vector1, vector2);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that cross with two vector 3 returns correct result
        /// </summary>
        [Fact]
        public void Cross_WithTwoVector3_ReturnsCorrectResult()
        {
            // Arrange
            Vector3 vector1 = new Vector3(1, 2, 3);
            Vector3 vector2 = new Vector3(4, 5, 6);
            Vector3 expected = new Vector3(-3, 6, -3);

            // Act
            Vector3 result = MathUtils.Cross(vector1, vector2);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that dot with two vector 2 returns correct result
        /// </summary>
        [Fact]
        public void Dot_WithTwoVector2_ReturnsCorrectResult()
        {
            // Arrange
            Vector2 vector1 = new Vector2(1, 2);
            Vector2 vector2 = new Vector2(3, 4);
            float expected = 11;

            // Act
            float result = MathUtils.Dot(vector1, vector2);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that dot with two vector 3 returns correct result
        /// </summary>
        [Fact]
        public void Dot_WithTwoVector3_ReturnsCorrectResult()
        {
            // Arrange
            Vector3 vector1 = new Vector3(1, 2, 3);
            Vector3 vector2 = new Vector3(4, 5, 6);
            float expected = 32;

            // Act
            float result = MathUtils.Dot(vector1, vector2);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that mul with matrix 2 x 2 and vector 2 returns correct result
        /// </summary>
        [Fact]
        public void Mul_WithMatrix2X2AndVector2_ReturnsCorrectResult()
        {
            // Arrange
            Matrix2X2 matrix = new Matrix2X2(1, 2, 3, 4);
            Vector2 vector = new Vector2(5, 6);
            Vector2 expected = new Vector2(17, 39);

            // Act
            Vector2 result = MathUtils.Mul(ref matrix, vector);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that cross v 2 with two vector 2 returns correct result
        /// </summary>
        [Fact]
        public void Cross_v2_WithTwoVector2_ReturnsCorrectResult()
        {
            // Arrange
            Vector2 vector1 = new Vector2(1, 2);
            Vector2 vector2 = new Vector2(3, 4);
            float expected = -2;

            // Act
            float result = MathUtils.Cross(vector1, vector2);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that cross v 2 with two vector 3 returns correct result
        /// </summary>
        [Fact]
        public void Cross_v2_WithTwoVector3_ReturnsCorrectResult()
        {
            // Arrange
            Vector3 vector1 = new Vector3(1, 2, 3);
            Vector3 vector2 = new Vector3(4, 5, 6);
            Vector3 expected = new Vector3(-3, 6, -3);

            // Act
            Vector3 result = MathUtils.Cross(vector1, vector2);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that dot v 2 with two vector 2 returns correct result
        /// </summary>
        [Fact]
        public void Dot_v2_WithTwoVector2_ReturnsCorrectResult()
        {
            // Arrange
            Vector2 vector1 = new Vector2(1, 2);
            Vector2 vector2 = new Vector2(3, 4);
            float expected = 11;

            // Act
            float result = MathUtils.Dot(vector1, vector2);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that do v 2 with two vector 3 returns correct result
        /// </summary>
        [Fact]
        public void Do_v2_WithTwoVector3_ReturnsCorrectResult()
        {
            // Arrange
            Vector3 vector1 = new Vector3(1, 2, 3);
            Vector3 vector2 = new Vector3(4, 5, 6);
            float expected = 32;

            // Act
            float result = MathUtils.Dot(vector1, vector2);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that mul v 2 with matrix 2 x 2 and vector 2 returns correct result
        /// </summary>
        [Fact]
        public void Mul_v2_WithMatrix2X2AndVector2_ReturnsCorrectResult()
        {
            // Arrange
            Matrix2X2 matrix = new Matrix2X2(1, 2, 3, 4);
            Vector2 vector = new Vector2(5, 6);
            Vector2 expected = new Vector2(17, 39);

            // Act
            Vector2 result = MathUtils.Mul(ref matrix, vector);

            // Assert
            Assert.Equal(expected, result);
        }


        /// <summary>
        /// Tests that test cosf
        /// </summary>
        [Fact]
        public void TestCosf()
        {
            float value = 0.5f;
            float expected = (float) System.Math.Cos(value);
            float result = MathUtils.Cosf(value);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test sinf
        /// </summary>
        [Fact]
        public void TestSinf()
        {
            float value = 0.5f;
            float expected = (float) System.Math.Sin(value);
            float result = MathUtils.Sinf(value);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test ceil
        /// </summary>
        [Fact]
        public void TestCeil()
        {
            float value = 0.5f;
            float expected = (float) System.Math.Ceiling(value);
            float result = MathUtils.Ceil(value);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test log
        /// </summary>
        [Fact]
        public void TestLog()
        {
            float value = 2f;
            float expected = (float) System.Math.Log(value);
            float result = MathUtils.Log(value);
            Assert.Equal(expected, result);
        }


        /// <summary>
        /// Tests that test max float
        /// </summary>
        [Fact]
        public void TestMaxFloat()
        {
            float valueA = 0.5f;
            float valueB = 1.0f;
            float expected = System.Math.Max(valueA, valueB);
            float result = MathUtils.Max(valueA, valueB);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test max int
        /// </summary>
        [Fact]
        public void TestMaxInt()
        {
            int valueA = 1;
            int valueB = 2;
            int expected = System.Math.Max(valueA, valueB);
            int result = MathUtils.Max(valueA, valueB);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test min float
        /// </summary>
        [Fact]
        public void TestMinFloat()
        {
            float valueA = 0.5f;
            float valueB = 1.0f;
            float expected = System.Math.Min(valueA, valueB);
            float result = MathUtils.Min(valueA, valueB);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test min int
        /// </summary>
        [Fact]
        public void TestMinInt()
        {
            int valueA = 1;
            int valueB = 2;
            int expected = System.Math.Min(valueA, valueB);
            int result = MathUtils.Min(valueA, valueB);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test sign
        /// </summary>
        [Fact]
        public void TestSign()
        {
            float value = -0.5f;
            int expected = System.Math.Sign(value);
            int result = MathUtils.Sign(value);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test normalize
        /// </summary>
        [Fact]
        public void TestNormalize()
        {
            Vector2 v = new Vector2(3.0f, 4.0f);
            float expectedLength = 5.0f;
            Vector2 expectedVector = v / expectedLength;
            float resultLength = MathUtils.Normalize(ref v);
            Assert.Equal(expectedLength, resultLength);
            Assert.Equal(expectedVector, v);
        }

        /// <summary>
        /// Tests that test sqrt
        /// </summary>
        [Fact]
        public void TestSqrt()
        {
            float value = 4.0f;
            float expected = (float) System.Math.Sqrt(value);
            float result = MathUtils.Sqrt(value);
            Assert.Equal(expected, result);
        }


        /// <summary>
        /// Tests that test v 2 max float
        /// </summary>
        [Fact]
        public void Test_v2_MaxFloat()
        {
            float valueA = 0.5f;
            float valueB = 1.0f;
            float expected = System.Math.Max(valueA, valueB);
            float result = MathUtils.Max(valueA, valueB);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test v 2 max int
        /// </summary>
        [Fact]
        public void Test_v2_MaxInt()
        {
            int valueA = 1;
            int valueB = 2;
            int expected = System.Math.Max(valueA, valueB);
            int result = MathUtils.Max(valueA, valueB);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test v 2 min float
        /// </summary>
        [Fact]
        public void Test_v2_MinFloat()
        {
            float valueA = 0.5f;
            float valueB = 1.0f;
            float expected = System.Math.Min(valueA, valueB);
            float result = MathUtils.Min(valueA, valueB);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test v 2 min int
        /// </summary>
        [Fact]
        public void Test_v2_MinInt()
        {
            int valueA = 1;
            int valueB = 2;
            int expected = System.Math.Min(valueA, valueB);
            int result = MathUtils.Min(valueA, valueB);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test v 2 sign
        /// </summary>
        [Fact]
        public void Test_v2_Sign()
        {
            float value = -0.5f;
            int expected = System.Math.Sign(value);
            int result = MathUtils.Sign(value);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test v 2 normalize
        /// </summary>
        [Fact]
        public void Test_v2_Normalize()
        {
            Vector2 v = new Vector2(3.0f, 4.0f);
            float expectedLength = 5.0f;
            Vector2 expectedVector = v / expectedLength;
            float resultLength = MathUtils.Normalize(ref v);
            Assert.Equal(expectedLength, resultLength);
            Assert.Equal(expectedVector, v);
        }

        /// <summary>
        /// Tests that test v 2 sqrt
        /// </summary>
        [Fact]
        public void Test_v2Sqrt()
        {
            float value = 4.0f;
            float expected = (float) System.Math.Sqrt(value);
            float result = MathUtils.Sqrt(value);
            Assert.Equal(expected, result);
        }


        /// <summary>
        /// Tests that test mul t
        /// </summary>
        [Fact]
        public void TestMulT()
        {
            Rotation rotation = new Rotation(0.5f);
            Vector2 axis = new Vector2(1.0f, 2.0f);
            Vector2 expected = MathUtils.MulT(ref rotation, axis);
            Vector2 result = MathUtils.MulT(ref rotation, axis);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test distance
        /// </summary>
        [Fact]
        public void TestDistance()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(3.0f, 4.0f);
            float expected = MathUtils.Distance(a, b);
            float result = MathUtils.Distance(a, b);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test distance ref
        /// </summary>
        [Fact]
        public void TestDistanceRef()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(3.0f, 4.0f);
            float expected = MathUtils.Distance(ref a, ref b);
            float result = MathUtils.Distance(ref a, ref b);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test distance squared
        /// </summary>
        [Fact]
        public void TestDistanceSquared()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(3.0f, 4.0f);
            float expected = MathUtils.DistanceSquared(ref a, ref b);
            float result = MathUtils.DistanceSquared(ref a, ref b);
            Assert.Equal(expected, result);
        }


        /// <summary>
        /// Tests that test cross
        /// </summary>
        [Fact]
        public void TestCross()
        {
            float s = 0.5f;
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 expected = new Vector2(-s * a.Y, s * a.X);
            Vector2 result;
            MathUtils.Cross(s, ref a, out result);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test float equals
        /// </summary>
        [Fact]
        public void TestFloatEquals()
        {
            float value1 = 0.5f;
            float value2 = 0.5f;
            bool expected = System.Math.Abs(value1 - value2) <= Constant.Epsilon;
            bool result = MathUtils.FloatEquals(value1, value2);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test float equals with delta
        /// </summary>
        [Fact]
        public void TestFloatEqualsWithDelta()
        {
            float value1 = 0.5f;
            float value2 = 0.6f;
            float delta = 0.2f;
            bool expected = (value1 >= value2 - delta) && (value1 <= value2 + delta);
            bool result = MathUtils.FloatEquals(value1, value2, delta);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test float in range
        /// </summary>
        [Fact]
        public void TestFloatInRange()
        {
            float value = 0.5f;
            float min = 0.2f;
            float max = 0.8f;
            bool expected = (value >= min) && (value <= max);
            bool result = MathUtils.FloatInRange(value, min, max);
            Assert.Equal(expected, result);
        }


        /// <summary>
        /// Tests that test mul t transform
        /// </summary>
        [Fact]
        public void TestMulT_Transform()
        {
            Transform a = new Transform();
            Transform b = new Transform();
            Transform expected = MathUtils.MulT(a, b);
            Transform result = MathUtils.MulT(a, b);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test mul 22
        /// </summary>
        [Fact]
        public void TestMul22()
        {
            Matrix3X3 a = new Matrix3X3();
            Vector2 v = new Vector2(1.0f, 2.0f);
            Vector2 expected = MathUtils.Mul22(a, v);
            Vector2 result = MathUtils.Mul22(a, v);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test mul rotation
        /// </summary>
        [Fact]
        public void TestMul_Rotation()
        {
            Rotation q = new Rotation();
            Rotation r = new Rotation();
            Rotation expected = MathUtils.Mul(q, r);
            Rotation result = MathUtils.Mul(q, r);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test mul t vector 2
        /// </summary>
        [Fact]
        public void TestMulT_Vector2()
        {
            Transform t = new Transform();
            Vector2 v = new Vector2(1.0f, 2.0f);
            Vector2 expected = MathUtils.MulT(t, v);
            Vector2 result = MathUtils.MulT(t, v);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test mul t rotation
        /// </summary>
        [Fact]
        public void TestMulT_Rotation()
        {
            Rotation q = new Rotation();
            Rotation r = new Rotation();
            Rotation expected = MathUtils.MulT(q, r);
            Rotation result = MathUtils.MulT(q, r);
            Assert.Equal(expected, result);

        }


        /// <summary>
        /// Tests that test cross vector 2 float
        /// </summary>
        [Fact]
        public void TestCross_Vector2Float()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            float s = 0.5f;
            Vector2 expected = new Vector2(s * a.Y, -s * a.X);
            Vector2 result = MathUtils.Cross(a, s);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test cross float vector 2
        /// </summary>
        [Fact]
        public void TestCross_FloatVector2()
        {
            float s = 0.5f;
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 expected = new Vector2(-s * a.Y, s * a.X);
            Vector2 result = MathUtils.Cross(s, a);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test abs vector 2
        /// </summary>
        [Fact]
        public void TestAbs_Vector2()
        {
            Vector2 v = new Vector2(-1.0f, -2.0f);
            Vector2 expected = new Vector2(System.Math.Abs(v.X), System.Math.Abs(v.Y));
            Vector2 result = MathUtils.Abs(v);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test abs float
        /// </summary>
        [Fact]
        public void TestAbs_Float()
        {
            float value = -0.5f;
            float expected = System.Math.Abs(value);
            float result = MathUtils.Abs(value);
            Assert.Equal(expected, result);
        }


        /// <summary>
        /// Tests that test clamp
        /// </summary>
        [Fact]
        public void TestClamp()
        {
            Vector2 a = new Vector2(1.5f, 2.5f);
            Vector2 low = new Vector2(1.0f, 2.0f);
            Vector2 high = new Vector2(2.0f, 3.0f);
            Vector2 expected = MathUtils.Clamp(a, low, high);
            Vector2 result = MathUtils.Clamp(a, low, high);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test v 2 cross
        /// </summary>
        [Fact]
        public void Test_v2_Cross()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(3.0f, 4.0f);
            float expected = a.X * b.Y - a.Y * b.X;
            float result;
            MathUtils.Cross(ref a, ref b, out result);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test vector angle
        /// </summary>
        [Fact]
        public void TestVectorAngle()
        {
            Vector2 p1 = new Vector2(1.0f, 2.0f);
            Vector2 p2 = new Vector2(3.0f, 4.0f);
            double theta1 = System.Math.Atan2(p1.Y, p1.X);
            double theta2 = System.Math.Atan2(p2.Y, p2.X);
            double expected = theta2 - theta1;
            while (expected > Constant.Pi)
            {
                expected -= Constant.TwoPi;
            }

            while (expected < -Constant.Pi)
            {
                expected += Constant.TwoPi;
            }

            double result = MathUtils.VectorAngle(ref p1, ref p2);
            Assert.Equal(expected, result);
        }


        /// <summary>
        /// Tests that test mul
        /// </summary>
        [Fact]
        public void TestMul()
        {
            Transform a = new Transform();
            Transform b = new Transform();
            Transform expected = MathUtils.Mul(a, b);
            Transform result = MathUtils.Mul(a, b);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test v 3 mul t
        /// </summary>
        [Fact]
        public void Test_v3_MulT()
        {
            Transform a = new Transform();
            Transform b = new Transform();
            Transform expected;
            MathUtils.MulT(ref a, ref b, out expected);
            Transform result;
            MathUtils.MulT(ref a, ref b, out result);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test skew
        /// </summary>
        [Fact]
        public void TestSkew()
        {
            Vector2 input = new Vector2(1.0f, 2.0f);
            Vector2 expected = new Vector2(-input.Y, input.X);
            Vector2 result = MathUtils.Skew(input);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test is valid float
        /// </summary>
        [Fact]
        public void TestIsValid_Float()
        {
            float value = 0.5f;
            bool expected = !float.IsNaN(value) && !float.IsInfinity(value);
            bool result = MathUtils.IsValid(value);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test is valid vector 2
        /// </summary>
        [Fact]
        public void TestIsValid_Vector2()
        {
            Vector2 value = new Vector2(1.0f, 2.0f);
            bool expected = !float.IsNaN(value.X) && !float.IsInfinity(value.X) && !float.IsNaN(value.Y) && !float.IsInfinity(value.Y);
            bool result = MathUtils.IsValid(value);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test v 3 clamp
        /// </summary>
        [Fact]
        public void Test_v3_Clamp()
        {
            int value = 5;
            int min = 1;
            int max = 10;
            int expected = System.Math.Max(min, System.Math.Min(value, max));
            int result = MathUtils.Clamp(value, min, max);
            Assert.Equal(expected, result);
        }


        /// <summary>
        /// Tests that test v 2 vector angle
        /// </summary>
        [Fact]
        public void Test_v2_VectorAngle()
        {
            Vector2 p1 = new Vector2(1.0f, 2.0f);
            Vector2 p2 = new Vector2(3.0f, 4.0f);
            double expected = MathUtils.VectorAngle(p1, p2);
            double result = MathUtils.VectorAngle(p1, p2);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test area
        /// </summary>
        [Fact]
        public void TestArea()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(3.0f, 4.0f);
            Vector2 c = new Vector2(5.0f, 6.0f);
            float expected = MathUtils.Area(a, b, c);
            float result = MathUtils.Area(a, b, c);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test is collinear
        /// </summary>
        [Fact]
        public void TestIsCollinear()
        {
            Vector2 a = new Vector2(1.0f, 2.0f);
            Vector2 b = new Vector2(3.0f, 4.0f);
            Vector2 c = new Vector2(5.0f, 6.0f);
            float tolerance = 0.01f;
            bool expected = MathUtils.IsCollinear(ref a, ref b, ref c, tolerance);
            bool result = MathUtils.IsCollinear(ref a, ref b, ref c, tolerance);
            Assert.Equal(expected, result);
        }


        /// <summary>
        /// Tests that test v 5 mul
        /// </summary>
        [Fact]
        public void Test_v5_Mul()
        {
            Transform t = new Transform();
            Vector2 v = new Vector2(1.0f, 2.0f);
            Vector2 expected = MathUtils.Mul(ref t, v);
            Vector2 result = MathUtils.Mul(ref t, v);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test mul ref
        /// </summary>
        [Fact]
        public void TestMul_Ref()
        {
            Transform t = new Transform();
            Vector2 v = new Vector2(1.0f, 2.0f);
            Vector2 expected = MathUtils.Mul(ref t, ref v);
            Vector2 result = MathUtils.Mul(ref t, ref v);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test v 4 mul t
        /// </summary>
        [Fact]
        public void Test_v4_MulT()
        {
            Matrix2X2 a = new Matrix2X2();
            Vector2 v = new Vector2(1.0f, 2.0f);
            Vector2 expected = MathUtils.MulT(ref a, v);
            Vector2 result = MathUtils.MulT(ref a, v);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test mul t ref
        /// </summary>
        [Fact]
        public void TestMulT_Ref()
        {
            Matrix2X2 a = new Matrix2X2();
            Vector2 v = new Vector2(1.0f, 2.0f);
            Vector2 expected = MathUtils.MulT(ref a, ref v);
            Vector2 result = MathUtils.MulT(ref a, ref v);
            Assert.Equal(expected, result);
        }


        /// <summary>
        /// Tests that test mul t v 5 vector 2
        /// </summary>
        [Fact]
        public void TestMulT_v5_Vector2()
        {
            Transform t = new Transform();
            Vector2 v = new Vector2(1.0f, 2.0f);
            Vector2 expected = MathUtils.MulT(ref t, v);
            Vector2 result = MathUtils.MulT(ref t, v);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test mul t ref vector 2
        /// </summary>
        [Fact]
        public void TestMulT_Ref_Vector2()
        {
            Transform t = new Transform();
            Vector2 v = new Vector2(1.0f, 2.0f);
            Vector2 expected = MathUtils.MulT(ref t, ref v);
            Vector2 result = MathUtils.MulT(ref t, ref v);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test mul t matrix 2 x 2
        /// </summary>
        [Fact]
        public void TestMulT_Matrix2X2()
        {
            Matrix2X2 a = new Matrix2X2();
            Matrix2X2 b = new Matrix2X2();
            Matrix2X2 expected;
            MathUtils.MulT(ref a, ref b, out expected);
            Matrix2X2 result;
            MathUtils.MulT(ref a, ref b, out result);
            Assert.Equal(expected, result);
        }


        /// <summary>
        /// Tests that test mul matrix 3 x 3 vector 3
        /// </summary>
        [Fact]
        public void TestMul_Matrix3X3_Vector3()
        {
            Matrix3X3 a = new Matrix3X3();
            Vector3 v = new Vector3(1.0f, 2.0f, 3.0f);
            Vector3 expected = MathUtils.Mul(a, v);
            Vector3 result = MathUtils.Mul(a, v);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test mul transform
        /// </summary>
        [Fact]
        public void TestMul_Transform()
        {
            Transform a = new Transform();
            Transform b = new Transform();
            Transform expected = MathUtils.Mul(a, b);
            Transform result = MathUtils.Mul(a, b);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test mul t v 3 transform
        /// </summary>
        [Fact]
        public void TestMulT_v3_Transform()
        {
            Transform a = new Transform();
            Transform b = new Transform();
            Transform expected;
            MathUtils.MulT(ref a, ref b, out expected);
            Transform result;
            MathUtils.MulT(ref a, ref b, out result);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test mul 22 matrix 3 x 3 vector 2
        /// </summary>
        [Fact]
        public void TestMul22_Matrix3X3_Vector2()
        {
            Matrix3X3 a = new Matrix3X3();
            Vector2 v = new Vector2(1.0f, 2.0f);
            Vector2 expected = MathUtils.Mul22(a, v);
            Vector2 result = MathUtils.Mul22(a, v);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test mul v 2 rotation
        /// </summary>
        [Fact]
        public void TestMul_v2_Rotation()
        {
            Rotation q = new Rotation();
            Rotation r = new Rotation();
            Rotation expected = MathUtils.Mul(q, r);
            Rotation result = MathUtils.Mul(q, r);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test v 6 mul
        /// </summary>
        [Fact]
        public void Test_v6_Mul()
        {
            Rotation rotation = new Rotation();
            Vector2 axis = new Vector2(1.0f, 2.0f);
            Vector2 expected = MathUtils.Mul(rotation, axis);
            Vector2 result = MathUtils.Mul(ref rotation, axis);
            Assert.Equal(expected, result);
        }


        /// <summary>
        /// Tests that test v 4 clamp
        /// </summary>
        [Fact]
        public void Test_v4_Clamp()
        {
            float a = 5.0f;
            float low = 1.0f;
            float high = 10.0f;
            float expected = MathUtils.Clamp(a, low, high);
            float result = MathUtils.Clamp(a, low, high);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test clamp value below range
        /// </summary>
        [Fact]
        public void TestClamp_ValueBelowRange()
        {
            float a = -2.0f;
            float low = 1.0f;
            float high = 10.0f;
            float expected = low; // When 'a' is below the range, Clamp should return the lower limit
            float result = MathUtils.Clamp(a, low, high);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test clamp value above range
        /// </summary>
        [Fact]
        public void TestClamp_ValueAboveRange()
        {
            float a = 15.0f;
            float low = 1.0f;
            float high = 10.0f;
            float expected = high; // When 'a' is above the range, Clamp should return the upper limit
            float result = MathUtils.Clamp(a, low, high);
            Assert.Equal(expected, result);
        }


        /// <summary>
        /// Tests that test vector angle zero angle
        /// </summary>
        [Fact]
        public void TestVectorAngle_ZeroAngle()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(1.0f, 0.0f);
            double expected = 0.0;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result, 5); // 5 decimal places of precision
        }

        /// <summary>
        /// Tests that test vector angle positive right angle
        /// </summary>
        [Fact]
        public void TestVectorAngle_PositiveRightAngle()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(0.0f, 1.0f);
            double expected = System.Math.PI / 2;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result, 5);
        }

        /// <summary>
        /// Tests that test vector angle negative right angle
        /// </summary>
        [Fact]
        public void TestVectorAngle_NegativeRightAngle()
        {
            Vector2 v1 = new Vector2(0.0f, 1.0f);
            Vector2 v2 = new Vector2(1.0f, 0.0f);
            double expected = -System.Math.PI / 2;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result, 5);
        }

        /// <summary>
        /// Tests that test vector angle straight line
        /// </summary>
        [Fact]
        public void TestVectorAngle_StraightLine()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(-1.0f, 0.0f);
            double expected = System.Math.PI;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result, 5);

        }


        /// <summary>
        /// Tests that test normalize zero vector
        /// </summary>
        [Fact]
        public void TestNormalize_ZeroVector()
        {
            Vector2 v = new Vector2(0.0f, 0.0f);
            float expectedLength = 0.0f;
            float resultLength = MathUtils.Normalize(ref v);
            Assert.Equal(expectedLength, resultLength);
            Assert.Equal(new Vector2(0.0f, 0.0f), v);
        }

        /// <summary>
        /// Tests that test normalize normalized vector
        /// </summary>
        [Fact]
        public void TestNormalize_NormalizedVector()
        {
            Vector2 v = new Vector2(1.0f, 0.0f);
            float expectedLength = 1.0f;
            float resultLength = MathUtils.Normalize(ref v);
            Assert.Equal(expectedLength, resultLength);
            Assert.Equal(new Vector2(1.0f, 0.0f), v);
        }

        /// <summary>
        /// Tests that test normalize non normalized vector
        /// </summary>
        [Fact]
        public void TestNormalize_NonNormalizedVector()
        {
            Vector2 v = new Vector2(2.0f, 0.0f);
            float expectedLength = 2.0f;
            float resultLength = MathUtils.Normalize(ref v);
            Assert.Equal(expectedLength, resultLength);
            Assert.Equal(new Vector2(1.0f, 0.0f), v);
        }

        /// <summary>
        /// Tests that test normalize vector with negative components
        /// </summary>
        [Fact]
        public void TestNormalize_VectorWithNegativeComponents()
        {
            Vector2 v = new Vector2(-2.0f, 0.0f);
            float expectedLength = 2.0f;
            float resultLength = MathUtils.Normalize(ref v);
            Assert.Equal(expectedLength, resultLength);
            Assert.Equal(new Vector2(-1.0f, 0.0f), v);
        }


        /// <summary>
        /// Tests that test vector angle same vectors
        /// </summary>
        [Fact]
        public void TestVectorAngle_SameVectors()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(1.0f, 0.0f);
            double expected = 0.0;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test vector angle opposite vectors
        /// </summary>
        [Fact]
        public void TestVectorAngle_OppositeVectors()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(-1.0f, 0.0f);
            double expected = System.Math.PI;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test vector angle perpendicular vectors
        /// </summary>
        [Fact]
        public void TestVectorAngle_PerpendicularVectors()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(0.0f, 1.0f);
            double expected = System.Math.PI / 2;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test vector angle negative components
        /// </summary>
        [Fact]
        public void TestVectorAngle_NegativeComponents()
        {
            Vector2 v1 = new Vector2(-1.0f, 0.0f);
            Vector2 v2 = new Vector2(0.0f, -1.0f);
            double expected = System.Math.PI / 2;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result, 0.1f);
        }


        /// <summary>
        /// Tests that test is valid normal number
        /// </summary>
        [Fact]
        public void TestIsValid_NormalNumber()
        {
            float number = 5.0f;
            bool result = MathUtils.IsValid(number);
            Assert.True(result);
        }

        /// <summary>
        /// Tests that test is valid na n
        /// </summary>
        [Fact]
        public void TestIsValid_NaN()
        {
            float number = float.NaN;
            bool result = MathUtils.IsValid(number);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that test is valid infinity
        /// </summary>
        [Fact]
        public void TestIsValid_Infinity()
        {
            float number = float.PositiveInfinity;
            bool result = MathUtils.IsValid(number);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that test is valid negative infinity
        /// </summary>
        [Fact]
        public void TestIsValid_NegativeInfinity()
        {
            float number = float.NegativeInfinity;
            bool result = MathUtils.IsValid(number);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that vector angle same vectors
        /// </summary>
        [Fact]
        public void VectorAngle_SameVectors()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(1.0f, 0.0f);
            double expected = 0.0;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that vector angle opposite vectors
        /// </summary>
        [Fact]
        public void VectorAngle_OppositeVectors()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(-1.0f, 0.0f);
            double expected = System.Math.PI;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that vector angle perpendicular vectors
        /// </summary>
        [Fact]
        public void VectorAngle_PerpendicularVectors()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(0.0f, 1.0f);
            double expected = System.Math.PI / 2;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that vector angle negative components
        /// </summary>
        [Fact]
        public void VectorAngle_NegativeComponents()
        {
            Vector2 v1 = new Vector2(-1.0f, 0.0f);
            Vector2 v2 = new Vector2(0.0f, -1.0f);
            double expected = System.Math.PI / 2;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result, 0.1f);
        }

        /// <summary>
        /// Tests that vector angle perpendicular vectors returns pi over 2
        /// </summary>
        [Fact]
        public void VectorAngle_PerpendicularVectors_ReturnsPiOver2()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(0.0f, 1.0f);
            double expected = System.Math.PI / 2;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result, 1);
        }

        /// <summary>
        /// Tests that vector angle parallel vectors returns zero
        /// </summary>
        [Fact]
        public void VectorAngle_ParallelVectors_ReturnsZero()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(1.0f, 0.0f);
            double expected = 0.0;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result, 1);
        }

        /// <summary>
        /// Tests that vector angle opposite vectors returns pi
        /// </summary>
        [Fact]
        public void VectorAngle_OppositeVectors_ReturnsPi()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(-1.0f, 0.0f);
            double expected = System.Math.PI;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result, 1);
        }

        /// <summary>
        /// Tests that vector angle parallel vectors opposite directions returns pi
        /// </summary>
        [Fact]
        public void VectorAngle_ParallelVectorsOppositeDirections_ReturnsPi()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(-1.0f, 0.0f);
            double expected = System.Math.PI;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result, 1);
        }

        /// <summary>
        /// Tests that vector angle 45 degree angle returns pi over 4
        /// </summary>
        [Fact]
        public void VectorAngle_45DegreeAngle_ReturnsPiOver4()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2((float) (System.Math.Sqrt(2) / 2), (float) (System.Math.Sqrt(2) / 2));
            double expected = System.Math.PI / 4;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result, 1);
        }

        /// <summary>
        /// Tests that vector angle 135 degree angle returns 3 pi over 4
        /// </summary>
        [Fact]
        public void VectorAngle_135DegreeAngle_Returns3PiOver4()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2((float) (-System.Math.Sqrt(2) / 2), (float) (System.Math.Sqrt(2) / 2));
            double expected = 3 * System.Math.PI / 4;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result, 1);
        }

        /// <summary>
        /// Tests that vector angle zero vector returns na n
        /// </summary>
        [Fact]
        public void VectorAngle_ZeroVector_ReturnsNaN()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(0.0f, 0.0f);
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.False(double.IsNaN(result));
        }

        /// <summary>
        /// Tests that test vector angle v 2 same vectors
        /// </summary>
        [Fact]
        public void TestVectorAngle_v2_SameVectors()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(1.0f, 0.0f);
            double expected = 0.0;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result);
        }

        /// <summary>

        /// Tests that test vector angle v 2 opposite vectors

        /// </summary>

        [Fact]
        public void TestVectorAngle_v2_OppositeVectors()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(-1.0f, 0.0f);
            double expected = System.Math.PI;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result);
        }

        /// <summary>

        /// Tests that test vector angle v 2 perpendicular vectors

        /// </summary>

        [Fact]
        public void TestVectorAngle_v2_PerpendicularVectors()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(0.0f, 1.0f);
            double expected = System.Math.PI / 2;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result);
        }

        /// <summary>

        /// Tests that test vector angle zero vector

        /// </summary>

        [Fact]
        public void TestVectorAngle_ZeroVector()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(0.0f, 0.0f);
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.False(double.IsNaN(result));
        }

        /// <summary>
        /// Tests that test vector angle v 3 same vectors
        /// </summary>
        [Fact]
        public void TestVectorAngle_v3_SameVectors()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(1.0f, 0.0f);
            double expected = 0.0;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test vector angle v 3 opposite vectors
        /// </summary>
        [Fact]
        public void TestVectorAngle_v3_OppositeVectors()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(-1.0f, 0.0f);
            double expected = System.Math.PI;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test vector angle v 3 perpendicular vectors
        /// </summary>
        [Fact]
        public void TestVectorAngle_v3_PerpendicularVectors()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(0.0f, 1.0f);
            double expected = System.Math.PI / 2;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Tests that test vector angle v 2 negative components
        /// </summary>
        [Fact]
        public void TestVectorAngle_v2_NegativeComponents()
        {
            Vector2 v1 = new Vector2(-1.0f, 0.0f);
            Vector2 v2 = new Vector2(0.0f, -1.0f);
            double expected = System.Math.PI / 2;
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result, 0.1f);
        }

        /// <summary>
        /// Tests that test vector angle v 2 zero vector
        /// </summary>
        [Fact]
        public void TestVectorAngle_v2_ZeroVector()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(0.0f, 0.0f);
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.False(double.IsNaN(result));
        }

        /// <summary>
        /// Tests that test vector angle small angle
        /// </summary>
        [Fact]
        public void TestVectorAngle_SmallAngle()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(1.0f, 0.1f);
            double expected = System.Math.Atan2(0.1, 1.0);
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result, 0.1f);
        }

        /// <summary>
        /// Tests that test vector angle large angle
        /// </summary>
        [Fact]
        public void TestVectorAngle_LargeAngle()
        {
            Vector2 v1 = new Vector2(1.0f, 0.0f);
            Vector2 v2 = new Vector2(-1.0f, 0.1f);
            double expected = System.Math.PI - System.Math.Atan2(0.1, 1.0);
            double result = MathUtils.VectorAngle(ref v1, ref v2);
            Assert.Equal(expected, result, 0.1f);
        }
    }
}

