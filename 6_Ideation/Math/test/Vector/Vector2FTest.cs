// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector2FTest.cs
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

using System;
using System.Globalization;
using System.Runtime.Serialization;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Vector
{
    /// <summary>
    ///     Comprehensive unit tests for Vector2F class
    /// </summary>
    public class Vector2FTest
    {
        /// <summary>
        ///     Tests that constructor with single value initializes both components
        /// </summary>
        [Fact]
        public void Constructor_WithSingleValue_InitializesBothComponents()
        {
            Vector2F v = new Vector2F(5f);

            Assert.Equal(5f, v.X);
            Assert.Equal(5f, v.Y);
        }

        /// <summary>
        ///     Tests that constructor with two values initializes components correctly
        /// </summary>
        [Fact]
        public void Constructor_WithTwoValues_InitializesComponentsCorrectly()
        {
            Vector2F v = new Vector2F(3f, 4f);

            Assert.Equal(3f, v.X);
            Assert.Equal(4f, v.Y);
        }


        /// <summary>
        ///     Tests that static property zero returns vector with zero components
        /// </summary>
        [Fact]
        public void StaticProperty_Zero_ReturnsVectorWithZeroComponents()
        {
            Vector2F v = Vector2F.Zero;

            Assert.Equal(0f, v.X);
            Assert.Equal(0f, v.Y);
        }

        /// <summary>
        ///     Tests that static property one returns vector with one components
        /// </summary>
        [Fact]
        public void StaticProperty_One_ReturnsVectorWithOneComponents()
        {
            Vector2F v = Vector2F.One;

            Assert.Equal(1f, v.X);
            Assert.Equal(1f, v.Y);
        }

        /// <summary>
        ///     Tests that static property unit x returns vector one zero
        /// </summary>
        [Fact]
        public void StaticProperty_UnitX_ReturnsVectorOneZero()
        {
            Vector2F v = Vector2F.UnitX;

            Assert.Equal(1f, v.X);
            Assert.Equal(0f, v.Y);
        }

        /// <summary>
        ///     Tests that static property unit y returns vector zero one
        /// </summary>
        [Fact]
        public void StaticProperty_UnitY_ReturnsVectorZeroOne()
        {
            Vector2F v = Vector2F.UnitY;

            Assert.Equal(0f, v.X);
            Assert.Equal(1f, v.Y);
        }


        /// <summary>
        ///     Tests that operator addition adds two vectors
        /// </summary>
        [Fact]
        public void OperatorAddition_AddsTwoVectors()
        {
            Vector2F v1 = new Vector2F(1, 2);
            Vector2F v2 = new Vector2F(3, 4);

            Vector2F result = v1 + v2;

            Assert.Equal(4, result.X);
            Assert.Equal(6, result.Y);
        }

        /// <summary>
        ///     Tests that operator subtraction subtracts two vectors
        /// </summary>
        [Fact]
        public void OperatorSubtraction_SubtractsTwoVectors()
        {
            Vector2F v1 = new Vector2F(3, 4);
            Vector2F v2 = new Vector2F(1, 2);

            Vector2F result = v1 - v2;

            Assert.Equal(2, result.X);
            Assert.Equal(2, result.Y);
        }

        /// <summary>
        ///     Tests that operator negation negates vector
        /// </summary>
        [Fact]
        public void OperatorNegation_NegatesVector()
        {
            Vector2F v = new Vector2F(3, 4);

            Vector2F result = -v;

            Assert.Equal(-3, result.X);
            Assert.Equal(-4, result.Y);
        }

        /// <summary>
        ///     Tests that operator multiplication multiply vector by scalar
        /// </summary>
        [Fact]
        public void OperatorMultiplication_MultiplyVectorByScalar()
        {
            Vector2F v = new Vector2F(2, 3);
            float scalar = 2f;

            Vector2F result = v * scalar;

            Assert.Equal(4, result.X);
            Assert.Equal(6, result.Y);
        }

        /// <summary>
        ///     Tests that operator multiplication multiply scalar by vector
        /// </summary>
        [Fact]
        public void OperatorMultiplication_MultiplyScalarByVector()
        {
            float scalar = 2f;
            Vector2F v = new Vector2F(2, 3);

            Vector2F result = scalar * v;

            Assert.Equal(4, result.X);
            Assert.Equal(6, result.Y);
        }

        /// <summary>
        ///     Tests that operator multiplication multiply vector by vector
        /// </summary>
        [Fact]
        public void OperatorMultiplication_MultiplyVectorByVector()
        {
            Vector2F v1 = new Vector2F(2, 3);
            Vector2F v2 = new Vector2F(4, 5);

            Vector2F result = v1 * v2;

            Assert.Equal(8, result.X);
            Assert.Equal(15, result.Y);
        }

        /// <summary>
        ///     Tests that operator division divide vector by scalar
        /// </summary>
        [Fact]
        public void OperatorDivision_DivideVectorByScalar()
        {
            Vector2F v = new Vector2F(6, 8);
            float scalar = 2;

            Vector2F result = v / scalar;

            Assert.Equal(3, result.X);
            Assert.Equal(4, result.Y);
        }

        /// <summary>
        ///     Tests that operator division divide vector by vector
        /// </summary>
        [Fact]
        public void OperatorDivision_DivideVectorByVector()
        {
            Vector2F v1 = new Vector2F(6, 8);
            Vector2F v2 = new Vector2F(2, 4);

            Vector2F result = v1 / v2;

            Assert.Equal(3, result.X);
            Assert.Equal(2, result.Y);
        }


        /// <summary>
        ///     Tests that operator equality with equal vectors returns true
        /// </summary>
        [Fact]
        public void OperatorEquality_WithEqualVectors_ReturnsTrue()
        {
            Vector2F v1 = new Vector2F(1f, 2f);
            Vector2F v2 = new Vector2F(1f, 2f);

            Assert.True(v1 == v2);
        }

        /// <summary>
        ///     Tests that operator equality with different vectors returns false
        /// </summary>
        [Fact]
        public void OperatorEquality_WithDifferentVectors_ReturnsFalse()
        {
            Vector2F v1 = new Vector2F(1f, 2f);
            Vector2F v2 = new Vector2F(3f, 4f);

            Assert.False(v1 == v2);
        }

        /// <summary>
        ///     Tests that operator equality within tolerance returns true
        /// </summary>
        [Fact]
        public void OperatorEquality_WithinTolerance_ReturnsTrue()
        {
            Vector2F v1 = new Vector2F(1f, 2f);
            Vector2F v2 = new Vector2F(1.005f, 2.005f);

            Assert.True(v1 == v2);
        }

        /// <summary>
        ///     Tests that operator inequality with different vectors returns true
        /// </summary>
        [Fact]
        public void OperatorInequality_WithDifferentVectors_ReturnsTrue()
        {
            Vector2F v1 = new Vector2F(1f, 2f);
            Vector2F v2 = new Vector2F(3f, 4f);

            Assert.True(v1 != v2);
        }

        /// <summary>
        ///     Tests that operator inequality with equal vectors returns false
        /// </summary>
        [Fact]
        public void OperatorInequality_WithEqualVectors_ReturnsFalse()
        {
            Vector2F v1 = new Vector2F(1f, 2f);
            Vector2F v2 = new Vector2F(1f, 2f);

            Assert.False(v1 != v2);
        }


        /// <summary>
        ///     Tests that add static method adds two vectors
        /// </summary>
        [Fact]
        public void Add_StaticMethod_AddsTwoVectors()
        {
            Vector2F v1 = new Vector2F(1, 2);
            Vector2F v2 = new Vector2F(3, 4);

            Vector2F result = Vector2F.Add(v1, v2);

            Assert.Equal(4, result.X);
            Assert.Equal(6, result.Y);
        }

        /// <summary>
        ///     Tests that subtract static method subtracts two vectors
        /// </summary>
        [Fact]
        public void Subtract_StaticMethod_SubtractsTwoVectors()
        {
            Vector2F v1 = new Vector2F(5, 6);
            Vector2F v2 = new Vector2F(2, 1);

            Vector2F result = Vector2F.Subtract(v1, v2);

            Assert.Equal(3, result.X);
            Assert.Equal(5, result.Y);
        }

        /// <summary>
        ///     Tests that multiply static method with two vectors multiply elementwise
        /// </summary>
        [Fact]
        public void Multiply_StaticMethod_WithTwoVectors_MultiplyElementwise()
        {
            Vector2F v1 = new Vector2F(2, 3);
            Vector2F v2 = new Vector2F(4, 5);

            Vector2F result = Vector2F.Multiply(v1, v2);

            Assert.Equal(8, result.X);
            Assert.Equal(15, result.Y);
        }

        /// <summary>
        ///     Tests that multiply static method with scalar scales vector
        /// </summary>
        [Fact]
        public void Multiply_StaticMethod_WithScalar_ScalesVector()
        {
            Vector2F v = new Vector2F(2, 3);
            float scalar = 2f;

            Vector2F result = Vector2F.Multiply(v, scalar);

            Assert.Equal(4, result.X);
            Assert.Equal(6, result.Y);
        }

        /// <summary>
        ///     Tests that multiply static method with scalar first scales vector
        /// </summary>
        [Fact]
        public void Multiply_StaticMethod_WithScalarFirst_ScalesVector()
        {
            float scalar = 3f;
            Vector2F v = new Vector2F(2, 4);

            Vector2F result = Vector2F.Multiply(scalar, v);

            Assert.Equal(6, result.X);
            Assert.Equal(12, result.Y);
        }

        /// <summary>
        ///     Tests that divide static method with two vectors divides elementwise
        /// </summary>
        [Fact]
        public void Divide_StaticMethod_WithTwoVectors_DividesElementwise()
        {
            Vector2F v1 = new Vector2F(8, 10);
            Vector2F v2 = new Vector2F(2, 5);

            Vector2F result = Vector2F.Divide(v1, v2);

            Assert.Equal(4, result.X);
            Assert.Equal(2, result.Y);
        }

        /// <summary>
        ///     Tests that divide static method with scalar divides by scalar
        /// </summary>
        [Fact]
        public void Divide_StaticMethod_WithScalar_DividesByScalar()
        {
            Vector2F v = new Vector2F(6, 9);
            float divisor = 3f;

            Vector2F result = Vector2F.Divide(v, divisor);

            Assert.Equal(2, result.X);
            Assert.Equal(3, result.Y);
        }

        /// <summary>
        ///     Tests that negate static method negates vector
        /// </summary>
        [Fact]
        public void Negate_StaticMethod_NegatesVector()
        {
            Vector2F v = new Vector2F(3, 4);

            Vector2F result = Vector2F.Negate(v);

            Assert.Equal(-3, result.X);
            Assert.Equal(-4, result.Y);
        }


        /// <summary>
        ///     Tests that distance calculates euclidean distance
        /// </summary>
        [Fact]
        public void Distance_CalculatesEuclideanDistance()
        {
            Vector2F v1 = new Vector2F(0, 0);
            Vector2F v2 = new Vector2F(3, 4);

            float distance = Vector2F.Distance(v1, v2);

            Assert.Equal(5, distance);
        }

        /// <summary>
        ///     Tests that distance squared calculates squared distance
        /// </summary>
        [Fact]
        public void DistanceSquared_CalculatesSquaredDistance()
        {
            Vector2F v1 = new Vector2F(0, 0);
            Vector2F v2 = new Vector2F(3, 4);

            float distanceSquared = Vector2F.DistanceSquared(v1, v2);

            Assert.Equal(25, distanceSquared);
        }

        /// <summary>
        ///     Tests that dot calculates dot product
        /// </summary>
        [Fact]
        public void Dot_CalculatesDotProduct()
        {
            Vector2F v1 = new Vector2F(1, 2);
            Vector2F v2 = new Vector2F(3, 4);

            float dot = Vector2F.Dot(v1, v2);

            Assert.Equal(11, dot);
        }

        /// <summary>
        ///     Tests that abs returns absolute values
        /// </summary>
        [Fact]
        public void Abs_ReturnsAbsoluteValues()
        {
            Vector2F v = new Vector2F(-3, -4);

            Vector2F result = Vector2F.Abs(v);

            Assert.Equal(3, result.X);
            Assert.Equal(4, result.Y);
        }

        /// <summary>
        ///     Tests that normalize normalizes vector
        /// </summary>
        [Fact]
        public void Normalize_NormalizesVector()
        {
            Vector2F v = new Vector2F(3, 4);

            Vector2F result = Vector2F.Normalize(v);

            Assert.Equal(0.6f, result.X, 1);
            Assert.Equal(0.8f, result.Y, 1);
        }

        /// <summary>
        ///     Tests that normalize zero vector returns na n
        /// </summary>
        [Fact]
        public void Normalize_ZeroVector_ReturnsNaN()
        {
            Vector2F v = new Vector2F(0, 0);

            Vector2F result = Vector2F.Normalize(v);

            Assert.True(float.IsNaN(result.X) || float.IsInfinity(result.X));
        }

        /// <summary>
        ///     Tests that square root calculates component wise square root
        /// </summary>
        [Fact]
        public void SquareRoot_CalculatesComponentWiseSquareRoot()
        {
            Vector2F v = new Vector2F(4, 9);

            Vector2F result = Vector2F.SquareRoot(v);

            Assert.Equal(2, result.X);
            Assert.Equal(3, result.Y);
        }

        /// <summary>
        ///     Tests that clamp restricts value between min and max
        /// </summary>
        [Fact]
        public void Clamp_RestrictsValueBetweenMinAndMax()
        {
            Vector2F value = new Vector2F(5, 5);
            Vector2F min = new Vector2F(0, 0);
            Vector2F max = new Vector2F(3, 3);

            Vector2F result = Vector2F.Clamp(value, min, max);

            Assert.Equal(3, result.X);
            Assert.Equal(3, result.Y);
        }

        /// <summary>
        ///     Tests that min returns componentwise minimum
        /// </summary>
        [Fact]
        public void Min_ReturnsComponentwiseMinimum()
        {
            Vector2F v1 = new Vector2F(5, 2);
            Vector2F v2 = new Vector2F(3, 4);

            Vector2F result = Vector2F.Min(v1, v2);

            Assert.Equal(3, result.X);
            Assert.Equal(2, result.Y);
        }

        /// <summary>
        ///     Tests that max returns componentwise maximum
        /// </summary>
        [Fact]
        public void Max_ReturnsComponentwiseMaximum()
        {
            Vector2F v1 = new Vector2F(5, 2);
            Vector2F v2 = new Vector2F(3, 4);

            Vector2F result = Vector2F.Max(v1, v2);

            Assert.Equal(5, result.X);
            Assert.Equal(4, result.Y);
        }

        /// <summary>
        ///     Tests that ler p interpolates between vectors
        /// </summary>
        [Fact]
        public void LerP_InterpolatesBetweenVectors()
        {
            Vector2F v1 = new Vector2F(0, 0);
            Vector2F v2 = new Vector2F(10, 20);
            float amount = 0.5f;

            Vector2F result = Vector2F.LerP(v1, v2, amount);

            Assert.Equal(5, result.X);
            Assert.Equal(10, result.Y);
        }

        /// <summary>
        ///     Tests that ler p with amount zero returns first vector
        /// </summary>
        [Fact]
        public void LerP_WithAmountZero_ReturnsFirstVector()
        {
            Vector2F v1 = new Vector2F(1, 2);
            Vector2F v2 = new Vector2F(5, 6);

            Vector2F result = Vector2F.LerP(v1, v2, 0f);

            Assert.Equal(1, result.X);
            Assert.Equal(2, result.Y);
        }

        /// <summary>
        ///     Tests that ler p with amount one returns second vector
        /// </summary>
        [Fact]
        public void LerP_WithAmountOne_ReturnsSecondVector()
        {
            Vector2F v1 = new Vector2F(1, 2);
            Vector2F v2 = new Vector2F(5, 6);

            Vector2F result = Vector2F.LerP(v1, v2, 1f);

            Assert.Equal(5, result.X);
            Assert.Equal(6, result.Y);
        }

        /// <summary>
        ///     Tests that reflect reflects vector off normal
        /// </summary>
        [Fact]
        public void Reflect_ReflectsVectorOffNormal()
        {
            Vector2F vector = new Vector2F(1, -1);
            Vector2F normal = new Vector2F(0, 1);

            Vector2F result = Vector2F.Reflect(vector, normal);

            Assert.Equal(1, result.X);
            Assert.Equal(1, result.Y);
        }


        /// <summary>
        ///     Tests that length calculates vector length
        /// </summary>
        [Fact]
        public void Length_CalculatesVectorLength()
        {
            Vector2F v = new Vector2F(3, 4);

            float length = v.Length();

            Assert.Equal(5, length);
        }

        /// <summary>
        ///     Tests that length squared calculates squared length
        /// </summary>
        [Fact]
        public void LengthSquared_CalculatesSquaredLength()
        {
            Vector2F v = new Vector2F(3, 4);

            float lengthSquared = v.LengthSquared();

            Assert.Equal(25, lengthSquared);
        }

        /// <summary>
        ///     Tests that normalize instance normalizes this vector
        /// </summary>
        [Fact]
        public void Normalize_Instance_NormalizesThisVector()
        {
            Vector2F v = new Vector2F(3, 4);

            v.Normalize();

            Assert.Equal(0.6f, v.X, 1);
            Assert.Equal(0.8f, v.Y, 1);
        }

        /// <summary>
        ///     Tests that copy to copies components to array
        /// </summary>
        [Fact]
        public void CopyTo_CopiesComponentsToArray()
        {
            Vector2F v = new Vector2F(1, 2);
            float[] array = new float[4];

            v.CopyTo(array, 1);

            Assert.Equal(0, array[0]);
            Assert.Equal(1, array[1]);
            Assert.Equal(2, array[2]);
            Assert.Equal(0, array[3]);
        }

        /// <summary>
        ///     Tests that copy to with null array throws null reference exception
        /// </summary>
        [Fact]
        public void CopyTo_WithNullArray_ThrowsNullReferenceException()
        {
            Vector2F v = new Vector2F(1, 2);

            Assert.Throws<NullReferenceException>(() => v.CopyTo(null));
        }

        /// <summary>
        ///     Tests that copy to with invalid index throws exception
        /// </summary>
        [Fact]
        public void CopyTo_WithInvalidIndex_ThrowsException()
        {
            Vector2F v = new Vector2F(1, 2);
            float[] array = new float[2];

            Assert.Throws<ArgumentOutOfRangeException>(() => v.CopyTo(array, -1));
        }

        /// <summary>
        ///     Tests that copy to with insufficient space throws exception
        /// </summary>
        [Fact]
        public void CopyTo_WithInsufficientSpace_ThrowsException()
        {
            Vector2F v = new Vector2F(1, 2);
            float[] array = new float[2];

            Assert.Throws<ArgumentException>(() => v.CopyTo(array, 1));
        }


        /// <summary>
        ///     Tests that transform with matrix 3 x 2 transforms vector
        /// </summary>
        [Fact]
        public void Transform_WithMatrix3X2_TransformsVector()
        {
            Vector2F v = new Vector2F(1, 0);
            Matrix3X2 matrix = new Matrix3X2(2f, 0f, 0f, 3f, 5f, 6f);

            Vector2F result = Vector2F.Transform(v, matrix);

            Assert.Equal(7f, result.X);
            Assert.Equal(6f, result.Y);
        }

        /// <summary>
        ///     Tests that transform with matrix 4 x 4 transforms vector
        /// </summary>
        [Fact]
        public void Transform_WithMatrix4X4_TransformsVector()
        {
            Vector2F v = new Vector2F(1, 0);
            Matrix4X4 matrix = new Matrix4X4(
                2f, 0f, 0f, 0f,
                0f, 3f, 0f, 0f,
                0f, 0f, 1f, 0f,
                5f, 6f, 0f, 1f);

            Vector2F result = Vector2F.Transform(v, matrix);

            Assert.Equal(7f, result.X);
            Assert.Equal(6f, result.Y);
        }

        /// <summary>
        ///     Tests that transform with quaternion rotates vector
        /// </summary>
        [Fact]
        public void Transform_WithQuaternion_RotatesVector()
        {
            Vector2F v = new Vector2F(1, 0);
            Quaternion rotation = new Quaternion(0, 0, (float) System.Math.Sin(System.Math.PI / 8), (float) System.Math.Cos(System.Math.PI / 8));

            Vector2F result = Vector2F.Transform(v, rotation);

            Assert.False(System.Math.Abs(result.X - 0.9238f) < 0.01f);
        }

        /// <summary>
        ///     Tests that transform normal with matrix 3 x 2 transforms normal
        /// </summary>
        [Fact]
        public void TransformNormal_WithMatrix3X2_TransformsNormal()
        {
            Vector2F normal = new Vector2F(1, 0);
            Matrix3X2 matrix = new Matrix3X2(2f, 0f, 0f, 3f, 5f, 6f);

            Vector2F result = Vector2F.TransformNormal(normal, matrix);

            Assert.Equal(2f, result.X);
            Assert.Equal(0f, result.Y);
        }

        /// <summary>
        ///     Tests that transform normal with matrix 4 x 4 transforms normal
        /// </summary>
        [Fact]
        public void TransformNormal_WithMatrix4X4_TransformsNormal()
        {
            Vector2F normal = new Vector2F(0, 1);
            Matrix4X4 matrix = new Matrix4X4(
                2f, 0f, 0f, 0f,
                0f, 3f, 0f, 0f,
                0f, 0f, 1f, 0f,
                5f, 6f, 0f, 1f);

            Vector2F result = Vector2F.TransformNormal(normal, matrix);

            Assert.Equal(0f, result.X);
            Assert.Equal(3f, result.Y);
        }


        /// <summary>
        ///     Tests that dot ref method calculates dot product
        /// </summary>
        [Fact]
        public void Dot_RefMethod_CalculatesDotProduct()
        {
            Vector2F v1 = new Vector2F(1, 2);
            Vector2F v2 = new Vector2F(3, 4);

            Vector2F.Dot(ref v1, ref v2, out float result);

            Assert.Equal(11, result);
        }

        /// <summary>
        ///     Tests that add ref method adds vectors
        /// </summary>
        [Fact]
        public void Add_RefMethod_AddsVectors()
        {
            Vector2F v1 = new Vector2F(1, 2);
            Vector2F v2 = new Vector2F(3, 4);

            Vector2F.Add(ref v1, ref v2, out Vector2F result);

            Assert.Equal(4, result.X);
            Assert.Equal(6, result.Y);
        }

        /// <summary>
        ///     Tests that subtract ref method subtracts vectors
        /// </summary>
        [Fact]
        public void Subtract_RefMethod_SubtractsVectors()
        {
            Vector2F v1 = new Vector2F(5, 6);
            Vector2F v2 = new Vector2F(2, 1);

            Vector2F.Subtract(ref v1, ref v2, out Vector2F result);

            Assert.Equal(3, result.X);
            Assert.Equal(5, result.Y);
        }

        /// <summary>
        ///     Tests that multiply ref method with two vectors multiply elementwise
        /// </summary>
        [Fact]
        public void Multiply_RefMethod_WithTwoVectors_MultiplyElementwise()
        {
            Vector2F v1 = new Vector2F(2, 3);
            Vector2F v2 = new Vector2F(4, 5);

            Vector2F.Multiply(ref v1, ref v2, out Vector2F result);

            Assert.Equal(8, result.X);
            Assert.Equal(15, result.Y);
        }

        /// <summary>
        ///     Tests that multiply ref method with scalar scales vector
        /// </summary>
        [Fact]
        public void Multiply_RefMethod_WithScalar_ScalesVector()
        {
            Vector2F v = new Vector2F(2, 3);
            float scalar = 2f;

            Vector2F.Multiply(ref v, scalar, out Vector2F result);

            Assert.Equal(4, result.X);
            Assert.Equal(6, result.Y);
        }

        /// <summary>
        ///     Tests that divide ref method divides by scalar
        /// </summary>
        [Fact]
        public void Divide_RefMethod_DividesByScalar()
        {
            Vector2F v = new Vector2F(6, 9);
            float divisor = 3f;

            Vector2F.Divide(ref v, divisor, out Vector2F result);

            Assert.Equal(2, result.X);
            Assert.Equal(3, result.Y);
        }

        /// <summary>
        ///     Tests that min ref method returns componentwise minimum
        /// </summary>
        [Fact]
        public void Min_RefMethod_ReturnsComponentwiseMinimum()
        {
            Vector2F v1 = new Vector2F(5, 2);
            Vector2F v2 = new Vector2F(3, 4);

            Vector2F.Min(ref v1, ref v2, out Vector2F result);

            Assert.Equal(3, result.X);
            Assert.Equal(2, result.Y);
        }

        /// <summary>
        ///     Tests that max ref method returns componentwise maximum
        /// </summary>
        [Fact]
        public void Max_RefMethod_ReturnsComponentwiseMaximum()
        {
            Vector2F v1 = new Vector2F(5, 2);
            Vector2F v2 = new Vector2F(3, 4);

            Vector2F.Max(ref v1, ref v2, out Vector2F result);

            Assert.Equal(5, result.X);
            Assert.Equal(4, result.Y);
        }

        /// <summary>
        ///     Tests that distance ref method calculates distance
        /// </summary>
        [Fact]
        public void Distance_RefMethod_CalculatesDistance()
        {
            Vector2F v1 = new Vector2F(0, 0);
            Vector2F v2 = new Vector2F(3, 4);

            Vector2F.Distance(ref v1, ref v2, out float result);

            Assert.Equal(5, result);
        }

        /// <summary>
        ///     Tests that distance squared ref method calculates squared distance
        /// </summary>
        [Fact]
        public void DistanceSquared_RefMethod_CalculatesSquaredDistance()
        {
            Vector2F v1 = new Vector2F(0, 0);
            Vector2F v2 = new Vector2F(3, 4);

            Vector2F.DistanceSquared(ref v1, ref v2, out float result);

            Assert.Equal(25, result);
        }


        /// <summary>
        ///     Tests that equals with same vector returns true
        /// </summary>
        [Fact]
        public void Equals_WithSameVector_ReturnsTrue()
        {
            Vector2F v1 = new Vector2F(1f, 2f);
            Vector2F v2 = new Vector2F(1f, 2f);

            Assert.True(v1.Equals(v2));
        }

        /// <summary>
        ///     Tests that equals with different vector returns false
        /// </summary>
        [Fact]
        public void Equals_WithDifferentVector_ReturnsFalse()
        {
            Vector2F v1 = new Vector2F(1f, 2f);
            Vector2F v2 = new Vector2F(3f, 4f);

            Assert.False(v1.Equals(v2));
        }

        /// <summary>
        ///     Tests that equals object override with vector returns true
        /// </summary>
        [Fact]
        public void Equals_ObjectOverride_WithVector_ReturnsTrue()
        {
            Vector2F v1 = new Vector2F(1f, 2f);
            object v2 = new Vector2F(1f, 2f);

            Assert.True(v1.Equals(v2));
        }

        /// <summary>
        ///     Tests that equals object override with non vector returns false
        /// </summary>
        [Fact]
        public void Equals_ObjectOverride_WithNonVector_ReturnsFalse()
        {
            Vector2F v = new Vector2F(1f, 2f);
            object obj = "not a vector";

            Assert.False(v.Equals(obj));
        }

        /// <summary>
        ///     Tests that get hash code with same vector returns same hash
        /// </summary>
        [Fact]
        public void GetHashCode_WithSameVector_ReturnsSameHash()
        {
            Vector2F v1 = new Vector2F(1f, 2f);
            Vector2F v2 = new Vector2F(1f, 2f);

            Assert.Equal(v1.GetHashCode(), v2.GetHashCode());
        }

        /// <summary>
        ///     Tests that to string override returns formatted string
        /// </summary>
        [Fact]
        public void ToString_Override_ReturnsFormattedString()
        {
            Vector2F v = new Vector2F(1f, 2f);
            string str = v.ToString();

            Assert.Contains("X:", str);
            Assert.Contains("Y:", str);
            Assert.Contains("1", str);
            Assert.Contains("2", str);
        }

        /// <summary>
        ///     Tests that to string with format returns formatted string
        /// </summary>
        [Fact]
        public void ToString_WithFormat_ReturnsFormattedString()
        {
            Vector2F v = new Vector2F(1.234f, 2.567f);
            string str = v.ToString("F2", CultureInfo.InvariantCulture);

            Assert.Contains("1.23", str);
            Assert.Contains("2.57", str);
        }

        /// <summary>
        ///     Tests that to string with format and culture returns formatted string
        /// </summary>
        [Fact]
        public void ToString_WithFormatAndCulture_ReturnsFormattedString()
        {
            Vector2F v = new Vector2F(1.5f, 2.5f);
            CultureInfo culture = CultureInfo.InvariantCulture;

            string str = v.ToString("F1", culture);

            Assert.Contains("1.5", str);
            Assert.Contains("2.5", str);
        }


        /// <summary>
        ///     Tests that get object data serializes vector
        /// </summary>
        [Fact]
        public void GetObjectData_SerializesVector()
        {
            Vector2F v = new Vector2F(3f, 4f);
            SerializationInfo serializationInfo = new SerializationInfo(typeof(Vector2F), new FormatterConverter());

            v.GetObjectData(serializationInfo, default(StreamingContext));

            Assert.Equal(3f, serializationInfo.GetSingle("x"));
            Assert.Equal(4f, serializationInfo.GetSingle("y"));
        }


        /// <summary>
        ///     Tests that vector 2 normalize
        /// </summary>
        [Fact]
        public void Vector2_Normalize()
        {
            Vector2F vector = new Vector2F(3, 4);

            Vector2F normalized = Vector2F.Normalize(vector);

            Assert.Equal(0.6f, normalized.X, 2);
            Assert.Equal(0.8f, normalized.Y, 2);
        }

        /// <summary>
        ///     Tests that test equals method
        /// </summary>
        [Fact]
        public void TestEqualsMethod()
        {
            // Arrange
            Vector2F vectorA = new Vector2F(1.0f, 2.0f);
            Vector2F vectorB = new Vector2F(1.0f, 2.0f);
            Vector2F vectorC = new Vector2F(2.0f, 3.0f);

            // Act & Assert
            Assert.True(vectorA.Equals(vectorB)); // Vector A should be equal to Vector B
            Assert.False(vectorA.Equals(vectorC)); // Vector A should not be equal to Vector C
        }


        /// <summary>
        ///     Tests that test static addition method
        /// </summary>
        [Fact]
        public void TestStaticAdditionMethod()
        {
            // Arrange
            Vector2F vectorA = new Vector2F(1.0f, 2.0f);
            Vector2F vectorB = new Vector2F(3.0f, 4.0f);

            // Act
            Vector2F result = Vector2F.Add(vectorA, vectorB);

            // Assert
            Assert.Equal(new Vector2F(4.0f, 6.0f), result);
        }

        /// <summary>
        ///     Tests that test dot product method
        /// </summary>
        [Fact]
        public void TestDotProductMethod()
        {
            // Arrange
            Vector2F vectorA = new Vector2F(2.0f, 3.0f);
            Vector2F vectorB = new Vector2F(4.0f, 1.0f);

            // Act
            float dotProduct = Vector2F.Dot(vectorA, vectorB);

            // Assert
            Assert.Equal(11.0f, dotProduct); // (2 * 4) + (3 * 1) = 11
        }

        /// <summary>
        ///     Tests that test equals method
        /// </summary>
        [Fact]
        public void TestEqualsWithObjectMethod()
        {
            // Arrange
            Vector2F vector1 = new Vector2F(10.0f, 20.0f);
            Vector2F vector2F = new Vector2F(10.0f, 20.0f);
            Vector2F vector3 = new Vector2F(5.0f, 10.0f);

            // Act & Assert
            Assert.True(vector1.Equals(vector2F));
            Assert.False(vector1.Equals(vector3));
        }

        /// <summary>
        ///     Tests that test get hash code method
        /// </summary>
        [Fact]
        public void TestGetHashCodeMethod()
        {
            // Arrange
            Vector2F vector = new Vector2F(10.0f, 20.0f);

            // Act
            int hashCode = vector.GetHashCode();

            // Assert
            // You can add specific assertions based on your implementation
            Assert.NotEqual(0, hashCode);
        }

        /// <summary>
        ///     Tests that test length method
        /// </summary>
        [Fact]
        public void TestLengthMethod()
        {
            // Arrange
            Vector2F vector = new Vector2F(3.0f, 4.0f); // A 3-4-5 right triangle

            // Act
            float length = vector.Length();

            // Assert
            Assert.Equal(5.0f, length);
        }

        /// <summary>
        ///     Tests that test min method
        /// </summary>
        [Fact]
        public void TestMinMethod()
        {
            // Arrange
            Vector2F vector1 = new Vector2F(5.0f, 10.0f);
            Vector2F vector2F = new Vector2F(8.0f, 7.0f);

            // Act
            Vector2F result = Vector2F.Min(vector1, vector2F);

            // Assert
            Assert.Equal(5.0f, result.X);
            Assert.Equal(7.0f, result.Y);
        }


        /// <summary>
        ///     Tests that test distance method
        /// </summary>
        [Fact]
        public void TestDistanceMethod()
        {
            // Arrange
            Vector2F point1 = new Vector2F(1.0f, 2.0f);
            Vector2F point2 = new Vector2F(4.0f, 6.0f);

            // Act
            float distance = Vector2F.Distance(point1, point2);

            // Assert
            Assert.Equal(5.0f, distance); // Distance between (1,2) and (4,6) is 5
        }

        /// <summary>
        ///     Tests that test equals same instance returns true
        /// </summary>
        [Fact]
        public void TestEquals_SameInstance_ReturnsTrue()
        {
            // Arrange
            Vector2F vector = new Vector2F(2.0f, 3.0f);

            // Act
            bool result = vector.Equals(vector);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that test equals equal vectors returns true
        /// </summary>
        [Fact]
        public void TestEquals_EqualVectors_ReturnsTrue()
        {
            // Arrange
            Vector2F vector1 = new Vector2F(2.0f, 3.0f);
            Vector2F vector2F = new Vector2F(2.0f, 3.0f);

            // Act
            bool result = vector1.Equals(vector2F);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that test equals null object returns false
        /// </summary>
        [Fact]
        public void TestEquals_NullObject_ReturnsFalse()
        {
            // Arrange
            Vector2F vector = new Vector2F(2.0f, 3.0f);

            // Act
            bool result = vector.Equals(null);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that test equals different vectors returns false
        /// </summary>
        [Fact]
        public void TestEquals_DifferentVectors_ReturnsFalse()
        {
            // Arrange
            Vector2F vector1 = new Vector2F(2.0f, 3.0f);
            Vector2F vector2F = new Vector2F(4.0f, 5.0f);

            // Act
            bool result = vector1.Equals(vector2F);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that test inequality equal vectors returns false
        /// </summary>
        [Fact]
        public void TestInequality_EqualVectors_ReturnsFalse()
        {
            // Arrange
            Vector2F vector1 = new Vector2F(2.0f, 3.0f);
            Vector2F vector2F = new Vector2F(2.0f, 3.0f);

            // Act
            bool result = vector1 != vector2F;

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that test inequality different vectors returns true
        /// </summary>
        [Fact]
        public void TestInequality_DifferentVectors_ReturnsTrue()
        {
            // Arrange
            Vector2F vector1 = new Vector2F(2.0f, 3.0f);
            Vector2F vector2F = new Vector2F(4.0f, 5.0f);

            // Act
            bool result = vector1 != vector2F;

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that test inequality different precision vectors returns true
        /// </summary>
        [Fact]
        public void TestInequality_DifferentPrecisionVectors_ReturnsTrue()
        {
            // Arrange
            Vector2F vector1 = new Vector2F(2.0f, 3.0f);
            Vector2F vector2F = new Vector2F(2.1f + float.Epsilon, 3.1f + float.Epsilon);

            // Act
            bool result = vector1 != vector2F;

            // Assert
            Assert.True(result);
        }
    }
}