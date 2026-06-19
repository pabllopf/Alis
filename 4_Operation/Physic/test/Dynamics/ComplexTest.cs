// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComplexTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The complex test class
    /// </summary>
    public class ComplexTest
    {
        /// <summary>
        ///     Tests that constructor should initialize correctly
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeCorrectly()
        {
            Complex complex = new Complex(3.0f, 4.0f);

            Assert.Equal(3.0f, complex.R);
            Assert.Equal(4.0f, complex.I);
        }

        /// <summary>
        ///     Tests that one should have correct values
        /// </summary>
        [Fact]
        public void One_ShouldHaveCorrectValues()
        {
            Complex one = Complex.One;

            Assert.Equal(1.0f, one.R);
            Assert.Equal(0.0f, one.I);
        }

        /// <summary>
        ///     Tests that imaginary one should have correct values
        /// </summary>
        [Fact]
        public void ImaginaryOne_ShouldHaveCorrectValues()
        {
            Complex imaginaryOne = Complex.ImaginaryOne;

            Assert.Equal(0.0f, imaginaryOne.R);
            Assert.Equal(1.0f, imaginaryOne.I);
        }

        /// <summary>
        ///     Tests that from angle should create correct complex number
        /// </summary>
        [Fact]
        public void FromAngle_ShouldCreateCorrectComplexNumber()
        {
            Complex complex = Complex.FromAngle(90.0f);

            Assert.True(Math.Abs(complex.R) < 0.01f);
            Assert.True(Math.Abs(complex.I - 1.0f) < 0.01f);
        }

        /// <summary>
        ///     Tests that from angle zero should return one
        /// </summary>
        [Fact]
        public void FromAngle_Zero_ShouldReturnOne()
        {
            Complex complex = Complex.FromAngle(0.0f);

            Assert.Equal(1.0f, complex.R, 5);
            Assert.Equal(0.0f, complex.I, 5);
        }

        /// <summary>
        ///     Tests that magnitude should calculate correctly
        /// </summary>
        [Fact]
        public void Magnitude_ShouldCalculateCorrectly()
        {
            Complex complex = new Complex(3.0f, 4.0f);

            Assert.Equal(5.0f, complex.Magnitude, 5);
        }

        /// <summary>
        ///     Tests that magnitude squared should calculate correctly
        /// </summary>
        [Fact]
        public void MagnitudeSquared_ShouldCalculateCorrectly()
        {
            Complex complex = new Complex(3.0f, 4.0f);

            Assert.Equal(25.0f, complex.MagnitudeSquared(), 5);
        }

        /// <summary>
        ///     Tests that conjugate should negate imaginary part
        /// </summary>
        [Fact]
        public void Conjugate_ShouldNegateImaginaryPart()
        {
            Complex complex = new Complex(3.0f, 4.0f);

            complex.Conjugate();

            Assert.Equal(3.0f, complex.R);
            Assert.Equal(-4.0f, complex.I);
        }

        /// <summary>
        ///     Tests that negate should negate both parts
        /// </summary>
        [Fact]
        public void Negate_ShouldNegateBothParts()
        {
            Complex complex = new Complex(3.0f, 4.0f);

            complex.Negate();

            Assert.Equal(-3.0f, complex.R);
            Assert.Equal(-4.0f, complex.I);
        }

        /// <summary>
        ///     Tests that to angle should convert correctly
        /// </summary>
        [Fact]
        public void ToAngle_ShouldConvertCorrectly()
        {
            Complex complex = Complex.FromAngle(45.0f);

            float angle = complex.ToAngle();

            Assert.Equal(45.0f, angle, 1);
        }

        /// <summary>
        ///     Tests that phase should get and set correctly
        /// </summary>
        [Fact]
        public void Phase_ShouldGetAndSetCorrectly()
        {
            Complex complex = new Complex(1.0f, 0.0f);
            float expectedPhase = (float) Math.PI / 4;

            complex.Phase = expectedPhase;

            Assert.Equal(expectedPhase, complex.Phase, 2);
        }

        /// <summary>
        ///     Tests that phase zero should return one
        /// </summary>
        [Fact]
        public void Phase_Zero_ShouldReturnOne()
        {
            Complex complex = new Complex(1.0f, 1.0f);

            complex.Phase = 0.0f;

            Assert.Equal(1.0f, complex.R);
            Assert.Equal(0.0f, complex.I);
        }

        /// <summary>
        ///     Tests that normalize should produce unit complex
        /// </summary>
        [Fact]
        public void Normalize_ShouldProduceUnitComplex()
        {
            Complex complex = new Complex(3.0f, 4.0f);

            complex.Normalize();

            Assert.True(Math.Abs(complex.Magnitude - 1.0f) < 0.001f);
        }

        /// <summary>
        ///     Tests that to vector 2 returns correct vector
        /// </summary>
        [Fact]
        public void ToVector2_ReturnsCorrectVector()
        {
            Complex complex = new Complex(3.0f, 4.0f);

            Vector2F vector = complex.ToVector2();

            Assert.Equal(3.0f, vector.X);
            Assert.Equal(4.0f, vector.Y);
        }

        /// <summary>
        ///     Tests that multiply complex by complex returns correct result
        /// </summary>
        [Fact]
        public void Multiply_ComplexByComplex_ReturnsCorrectResult()
        {
            Complex a = new Complex(1.0f, 2.0f);
            Complex b = new Complex(3.0f, 4.0f);

            Complex result = Complex.Multiply(ref a, ref b);

            Assert.Equal(1*3 - 2*4, result.R);
            Assert.Equal(2*3 + 1*4, result.I);
        }

        /// <summary>
        ///     Tests that divide complex by complex returns correct result
        /// </summary>
        [Fact]
        public void Divide_ComplexByComplex_ReturnsCorrectResult()
        {
            Complex a = new Complex(1.0f, 2.0f);
            Complex b = new Complex(3.0f, 4.0f);

            Complex result = Complex.Divide(ref a, ref b);

            Assert.Equal(3*1 + 4*2, result.R);
            Assert.Equal(3*2 - 4*1, result.I);
        }

        /// <summary>
        ///     Tests that divide complex by complex with out parameter returns correct result
        /// </summary>
        [Fact]
        public void Divide_ComplexByComplex_WithOutParam_ReturnsCorrectResult()
        {
            Complex a = new Complex(1.0f, 2.0f);
            Complex b = new Complex(3.0f, 4.0f);

            Complex.Divide(ref a, ref b, out Complex result);

            Assert.Equal(3*1 + 4*2, result.R);
            Assert.Equal(3*2 - 4*1, result.I);
        }

        /// <summary>
        ///     Tests that multiply vector by complex returns rotated vector
        /// </summary>
        [Fact]
        public void Multiply_VectorByComplex_ReturnsRotatedVector()
        {
            Vector2F v = new Vector2F(1.0f, 0.0f);
            Complex c = new Complex(0.0f, 1.0f);

            Vector2F result = Complex.Multiply(ref v, ref c);

            Assert.Equal(0.0f, result.X, 5);
            Assert.Equal(1.0f, result.Y, 5);
        }

        /// <summary>
        ///     Tests that multiply vector by complex with out parameter returns rotated vector
        /// </summary>
        [Fact]
        public void Multiply_VectorByComplex_WithOutParam_ReturnsRotatedVector()
        {
            Vector2F v = new Vector2F(1.0f, 0.0f);
            Complex c = new Complex(0.0f, 1.0f);

            Complex.Multiply(ref v, ref c, out Vector2F result);

            Assert.Equal(0.0f, result.X, 5);
            Assert.Equal(1.0f, result.Y, 5);
        }

        /// <summary>
        ///     Tests that multiply vector by complex returns rotated vector
        /// </summary>
        [Fact]
        public void Multiply_VectorByComplex_Instance_ReturnsRotatedVector()
        {
            Vector2F v = new Vector2F(1.0f, 0.0f);
            Complex c = new Complex(0.0f, 1.0f);

            Vector2F result = Complex.Multiply(v, ref c);

            Assert.Equal(0.0f, result.X, 5);
            Assert.Equal(1.0f, result.Y, 5);
        }

        /// <summary>
        ///     Tests that divide vector by complex returns rotated vector
        /// </summary>
        [Fact]
        public void Divide_VectorByComplex_ReturnsRotatedVector()
        {
            Vector2F v = new Vector2F(0.0f, 1.0f);
            Complex c = new Complex(0.0f, 1.0f);

            Vector2F result = Complex.Divide(ref v, ref c);

            Assert.Equal(1.0f, result.X, 5);
            Assert.Equal(0.0f, result.Y, 5);
        }

        /// <summary>
        ///     Tests that divide vector by complex returns rotated vector
        /// </summary>
        [Fact]
        public void Divide_VectorByComplex_Instance_ReturnsRotatedVector()
        {
            Vector2F v = new Vector2F(0.0f, 1.0f);
            Complex c = new Complex(0.0f, 1.0f);

            Vector2F result = Complex.Divide(v, ref c);

            Assert.Equal(1.0f, result.X, 5);
            Assert.Equal(0.0f, result.Y, 5);
        }

        /// <summary>
        ///     Tests that divide vector by complex with out parameter returns rotated vector
        /// </summary>
        [Fact]
        public void Divide_VectorByComplex_WithOutParam_ReturnsRotatedVector()
        {
            Vector2F v = new Vector2F(0.0f, 1.0f);
            Complex c = new Complex(0.0f, 1.0f);

            Complex.Divide(v, ref c, out Vector2F result);

            Assert.Equal(1.0f, result.X, 5);
            Assert.Equal(0.0f, result.Y, 5);
        }

        /// <summary>
        ///     Tests that conjugate static returns conjugate
        /// </summary>
        [Fact]
        public void Conjugate_Static_ReturnsConjugate()
        {
            Complex complex = new Complex(3.0f, 4.0f);

            Complex result = Complex.Conjugate(ref complex);

            Assert.Equal(3.0f, result.R);
            Assert.Equal(-4.0f, result.I);
        }

        /// <summary>
        ///     Tests that negate static returns negated value
        /// </summary>
        [Fact]
        public void Negate_Static_ReturnsNegatedValue()
        {
            Complex complex = new Complex(3.0f, 4.0f);

            Complex result = Complex.Negate(ref complex);

            Assert.Equal(-3.0f, result.R);
            Assert.Equal(-4.0f, result.I);
        }

        /// <summary>
        ///     Tests that normalize static returns unit complex
        /// </summary>
        [Fact]
        public void Normalize_Static_ReturnsUnitComplex()
        {
            Complex complex = new Complex(3.0f, 4.0f);

            Complex result = Complex.Normalize(ref complex);

            Assert.True(Math.Abs(result.Magnitude - 1.0f) < 0.001f);
            Assert.True(result.R > 0);
        }

        /// <summary>
        ///     Tests that to string returns formatted string
        /// </summary>
        [Fact]
        public void ToString_ReturnsFormattedString()
        {
            Complex complex = new Complex(3.0f, 4.0f);

            string str = complex.ToString();

            Assert.Contains("3", str);
            Assert.Contains("4", str);
        }
    }
}