// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureIntTest.cs
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
    ///     The secure int tests class
    /// </summary>
    public class SecureIntTests
    {
        /// <summary>
        ///     Tests that test secure int constructor
        /// </summary>
        [Fact]
        public void Test_SecureInt_Constructor()
        {
            SecureInt secureInt = new SecureInt(10);
            Assert.Equal(10, (int) secureInt);
        }

        /// <summary>
        ///     Tests that test secure int implicit conversion
        /// </summary>
        [Fact]
        public void Test_SecureInt_ImplicitConversion()
        {
            SecureInt secureInt = 10;
            Assert.Equal(10, (int) secureInt);
        }

        /// <summary>
        ///     Tests that test secure int equality operator
        /// </summary>
        [Fact]
        public void Test_SecureInt_EqualityOperator()
        {
            SecureInt secureInt1 = 10;
            SecureInt secureInt2 = 10;
            Assert.True(secureInt1 == secureInt2);

            secureInt2 = 20;
            Assert.False(secureInt1 == secureInt2);
        }

        /// <summary>
        ///     Tests that test secure int inequality operator
        /// </summary>
        [Fact]
        public void Test_SecureInt_InequalityOperator()
        {
            SecureInt secureInt1 = 10;
            SecureInt secureInt2 = 20;
            Assert.True(secureInt1 != secureInt2);

            secureInt2 = 10;
            Assert.False(secureInt1 != secureInt2);
        }

        /// <summary>
        ///     Tests that test secure int addition operator
        /// </summary>
        [Fact]
        public void Test_SecureInt_AdditionOperator()
        {
            SecureInt secureInt1 = 10;
            SecureInt secureInt2 = 20;
            Assert.Equal(30, (int) (secureInt1 + secureInt2));
        }

        /// <summary>
        ///     Tests that test secure int subtraction operator
        /// </summary>
        [Fact]
        public void Test_SecureInt_SubtractionOperator()
        {
            SecureInt secureInt1 = 20;
            SecureInt secureInt2 = 10;
            Assert.Equal(10, (int) (secureInt1 - secureInt2));
        }

        /// <summary>
        ///     Tests that test secure int multiplication operator
        /// </summary>
        [Fact]
        public void Test_SecureInt_MultiplicationOperator()
        {
            SecureInt secureInt1 = 10;
            SecureInt secureInt2 = 20;
            Assert.Equal(200, (int) (secureInt1 * secureInt2));
        }

        /// <summary>
        ///     Tests that test secure int division operator
        /// </summary>
        [Fact]
        public void Test_SecureInt_DivisionOperator()
        {
            SecureInt secureInt1 = 20;
            SecureInt secureInt2 = 10;
            Assert.Equal(2, (int) (secureInt1 / secureInt2));
        }

        /// <summary>
        ///     Tests that test secure int equals method
        /// </summary>
        [Fact]
        public void Test_SecureInt_EqualsMethod()
        {
            SecureInt secureInt1 = 10;
            SecureInt secureInt2 = 10;
            Assert.True(secureInt1.Equals(secureInt2));

            secureInt2 = 20;
            Assert.False(secureInt1.Equals(secureInt2));
        }

        /// <summary>
        ///     Tests that test secure int get hash code method
        /// </summary>
        [Fact]
        public void Test_SecureInt_GetHashCodeMethod()
        {
            SecureInt secureInt1 = 10;
            SecureInt secureInt2 = 10;
            Assert.Equal(secureInt1.GetHashCode(), secureInt2.GetHashCode());

            secureInt2 = 20;
            Assert.NotEqual(secureInt1.GetHashCode(), secureInt2.GetHashCode());
        }

        /// <summary>
        ///     Tests that test secure int to string method
        /// </summary>
        [Fact]
        public void Test_SecureInt_ToStringMethod()
        {
            SecureInt secureInt = 10;
            Assert.Equal("10", secureInt.ToString());
        }

        /// <summary>
        ///     Tests that test value set get
        /// </summary>
        [Fact]
        public void TestValueSetGet()
        {
            // Arrange
            SecureInt secureInt = new SecureInt(10);

            // Act
            int value = secureInt;

            // Assert
            Assert.Equal(10, value);
        }

        /// <summary>
        ///     Tests that test equality
        /// </summary>
        [Fact]
        public void TestEquality()
        {
            // Arrange
            SecureInt secureInt1 = new SecureInt(10);
            SecureInt secureInt2 = new SecureInt(10);

            // Assert
            Assert.True(secureInt1 == secureInt2);
        }

        /// <summary>
        ///     Tests that test inequality
        /// </summary>
        [Fact]
        public void TestInequality()
        {
            // Arrange
            SecureInt secureInt1 = new SecureInt(10);
            SecureInt secureInt2 = new SecureInt(20);

            // Assert
            Assert.True(secureInt1 != secureInt2);
        }

        /// <summary>
        ///     Tests that test increment
        /// </summary>
        [Fact]
        public void TestIncrement()
        {
            // Arrange
            SecureInt secureInt = new SecureInt(10);

            // Act
            secureInt++;

            // Assert
            Assert.Equal(11, (int) secureInt);
        }

        /// <summary>
        ///     Tests that test decrement
        /// </summary>
        [Fact]
        public void TestDecrement()
        {
            // Arrange
            SecureInt secureInt = new SecureInt(10);

            // Act
            secureInt--;

            // Assert
            Assert.Equal(9, (int) secureInt);
        }

        /// <summary>
        ///     Tests that test addition
        /// </summary>
        [Fact]
        public void TestAddition()
        {
            // Arrange
            SecureInt secureInt1 = new SecureInt(10);
            SecureInt secureInt2 = new SecureInt(20);

            // Act
            SecureInt result = secureInt1 + secureInt2;

            // Assert
            Assert.Equal(30, (int) result);
        }

        /// <summary>
        ///     Tests that test subtraction
        /// </summary>
        [Fact]
        public void TestSubtraction()
        {
            // Arrange
            SecureInt secureInt1 = new SecureInt(20);
            SecureInt secureInt2 = new SecureInt(10);

            // Act
            SecureInt result = secureInt1 - secureInt2;

            // Assert
            Assert.Equal(10, (int) result);
        }

        /// <summary>
        ///     Tests that test multiplication
        /// </summary>
        [Fact]
        public void TestMultiplication()
        {
            // Arrange
            SecureInt secureInt1 = new SecureInt(10);
            SecureInt secureInt2 = new SecureInt(20);

            // Act
            SecureInt result = secureInt1 * secureInt2;

            // Assert
            Assert.Equal(200, (int) result);
        }

        /// <summary>
        ///     Tests that test division
        /// </summary>
        [Fact]
        public void TestDivision()
        {
            // Arrange
            SecureInt secureInt1 = new SecureInt(20);
            SecureInt secureInt2 = new SecureInt(10);

            // Act
            SecureInt result = secureInt1 / secureInt2;

            // Assert
            Assert.Equal(2, (int) result);
        }
    }
}