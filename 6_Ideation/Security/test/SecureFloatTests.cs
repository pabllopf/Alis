// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureFloatTest.cs
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

using Xunit;

namespace Alis.Core.Aspect.Security.Test
{
    /// <summary>
    ///     The secure float tests class
    /// </summary>
    public class SecureFloatTests
    {
        /// <summary>
        ///     Tests that test secure float constructor
        /// </summary>
        [Fact]
        public void Test_SecureFloat_Constructor()
        {
            SecureFloat secureFloat = new SecureFloat(10.0f);
            Assert.Equal(10.0f, (float) secureFloat);
        }

        /// <summary>
        ///     Tests that test secure float implicit conversion
        /// </summary>
        [Fact]
        public void Test_SecureFloat_ImplicitConversion()
        {
            SecureFloat secureFloat = 10.0f;
            Assert.Equal(10.0f, (float) secureFloat);
        }

        /// <summary>
        ///     Tests that test secure float equality operator
        /// </summary>
        [Fact]
        public void Test_SecureFloat_EqualityOperator()
        {
            SecureFloat secureFloat1 = 10.0f;
            SecureFloat secureFloat2 = 10.0f;
            Assert.True(secureFloat1 == secureFloat2);

            secureFloat2 = 20.0f;
            Assert.False(secureFloat1 == secureFloat2);
        }

        /// <summary>
        ///     Tests that test secure float inequality operator
        /// </summary>
        [Fact]
        public void Test_SecureFloat_InequalityOperator()
        {
            SecureFloat secureFloat1 = 10.0f;
            SecureFloat secureFloat2 = 20.0f;
            Assert.True(secureFloat1 != secureFloat2);

            secureFloat2 = 10.0f;
            Assert.False(secureFloat1 != secureFloat2);
        }

        /// <summary>
        ///     Tests that test secure float addition operator
        /// </summary>
        [Fact]
        public void Test_SecureFloat_AdditionOperator()
        {
            SecureFloat secureFloat1 = 10.0f;
            SecureFloat secureFloat2 = 20.0f;
            Assert.Equal(30.0f, (float) (secureFloat1 + secureFloat2));
        }

        /// <summary>
        ///     Tests that test secure float subtraction operator
        /// </summary>
        [Fact]
        public void Test_SecureFloat_SubtractionOperator()
        {
            SecureFloat secureFloat1 = 20.0f;
            SecureFloat secureFloat2 = 10.0f;
            Assert.Equal(10.0f, (float) (secureFloat1 - secureFloat2));
        }

        /// <summary>
        ///     Tests that test secure float multiplication operator
        /// </summary>
        [Fact]
        public void Test_SecureFloat_MultiplicationOperator()
        {
            SecureFloat secureFloat1 = 10.0f;
            SecureFloat secureFloat2 = 20.0f;
            Assert.Equal(200.0f, (float) (secureFloat1 * secureFloat2));
        }

        /// <summary>
        ///     Tests that test secure float division operator
        /// </summary>
        [Fact]
        public void Test_SecureFloat_DivisionOperator()
        {
            SecureFloat secureFloat1 = 20.0f;
            SecureFloat secureFloat2 = 10.0f;
            Assert.Equal(2.0f, (float) (secureFloat1 / secureFloat2));
        }

        /// <summary>
        ///     Tests that test secure float equals method
        /// </summary>
        [Fact]
        public void Test_SecureFloat_EqualsMethod()
        {
            SecureFloat secureFloat1 = 10.0f;
            SecureFloat secureFloat2 = 10.0f;
            Assert.True(secureFloat1.Equals(secureFloat2));

            secureFloat2 = 20.0f;
            Assert.False(secureFloat1.Equals(secureFloat2));
        }

        /// <summary>
        ///     Tests that test secure float get hash code method
        /// </summary>
        [Fact]
        public void Test_SecureFloat_GetHashCodeMethod()
        {
            SecureFloat secureFloat1 = 10.0f;
            SecureFloat secureFloat2 = 10.0f;
            Assert.Equal(secureFloat1.GetHashCode(), secureFloat2.GetHashCode());

            secureFloat2 = 20.0f;
            Assert.NotEqual(secureFloat1.GetHashCode(), secureFloat2.GetHashCode());
        }

        /// <summary>
        ///     Tests that test secure float to string method
        /// </summary>
        [Fact]
        public void Test_SecureFloat_ToStringMethod()
        {
            SecureFloat secureFloat = 10.0f;
            Assert.Equal("10", secureFloat.ToString());
        }


        /// <summary>
        ///     Tests that test value set get
        /// </summary>
        [Fact]
        public void TestValueSetGet()
        {
            // Arrange
            SecureFloat secureFloat = new SecureFloat(10f);

            // Act
            float value = secureFloat;

            // Assert
            Assert.Equal(10f, value);
        }

        /// <summary>
        ///     Tests that test equality
        /// </summary>
        [Fact]
        public void TestEquality()
        {
            // Arrange
            SecureFloat secureFloat1 = new SecureFloat(10f);
            SecureFloat secureFloat2 = new SecureFloat(10f);

            // Assert
            Assert.True(secureFloat1 == secureFloat2);
        }

        /// <summary>
        ///     Tests that test inequality
        /// </summary>
        [Fact]
        public void TestInequality()
        {
            // Arrange
            SecureFloat secureFloat1 = new SecureFloat(10f);
            SecureFloat secureFloat2 = new SecureFloat(20f);

            // Assert
            Assert.True(secureFloat1 != secureFloat2);
        }

        /// <summary>
        ///     Tests that test increment
        /// </summary>
        [Fact]
        public void TestIncrement()
        {
            // Arrange
            SecureFloat secureFloat = new SecureFloat(10f);

            // Act
            secureFloat++;

            // Assert
            Assert.Equal(11f, (float) secureFloat);
        }

        /// <summary>
        ///     Tests that test decrement
        /// </summary>
        [Fact]
        public void TestDecrement()
        {
            // Arrange
            SecureFloat secureFloat = new SecureFloat(10f);

            // Act
            secureFloat--;

            // Assert
            Assert.Equal(9f, (float) secureFloat);
        }

        /// <summary>
        ///     Tests that test addition
        /// </summary>
        [Fact]
        public void TestAddition()
        {
            // Arrange
            SecureFloat secureFloat1 = new SecureFloat(10f);
            SecureFloat secureFloat2 = new SecureFloat(20f);

            // Act
            SecureFloat result = secureFloat1 + secureFloat2;

            // Assert
            Assert.Equal(30f, (float) result);
        }

        /// <summary>
        ///     Tests that test subtraction
        /// </summary>
        [Fact]
        public void TestSubtraction()
        {
            // Arrange
            SecureFloat secureFloat1 = new SecureFloat(20f);
            SecureFloat secureFloat2 = new SecureFloat(10f);

            // Act
            SecureFloat result = secureFloat1 - secureFloat2;

            // Assert
            Assert.Equal(10f, (float) result);
        }

        /// <summary>
        ///     Tests that test multiplication
        /// </summary>
        [Fact]
        public void TestMultiplication()
        {
            // Arrange
            SecureFloat secureFloat1 = new SecureFloat(10f);
            SecureFloat secureFloat2 = new SecureFloat(20f);

            // Act
            SecureFloat result = secureFloat1 * secureFloat2;

            // Assert
            Assert.Equal(200f, (float) result);
        }

        /// <summary>
        ///     Tests that test division
        /// </summary>
        [Fact]
        public void TestDivision()
        {
            // Arrange
            SecureFloat secureFloat1 = new SecureFloat(20f);
            SecureFloat secureFloat2 = new SecureFloat(10f);

            // Act
            SecureFloat result = secureFloat1 / secureFloat2;

            // Assert
            Assert.Equal(2f, (float) result);
        }
    }
}