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
            float expectedPhase = (float)Math.PI / 4;
            
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
    }
}

