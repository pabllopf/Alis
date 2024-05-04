// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureDoubleTests.cs
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
    ///     The secure double tests class
    /// </summary>
    public class SecureDoubleTests
    {
        /// <summary>
        ///     Tests that test secure double constructor
        /// </summary>
        [Fact]
        public void Test_SecureDouble_Constructor()
        {
            SecureDouble secureDouble = new SecureDouble(10.0);
            Assert.Equal(10.0, (double) secureDouble);
        }
        
        /// <summary>
        ///     Tests that test secure double implicit conversion
        /// </summary>
        [Fact]
        public void Test_SecureDouble_ImplicitConversion()
        {
            SecureDouble secureDouble = 10.0;
            Assert.Equal(10.0, (double) secureDouble);
        }
        
        /// <summary>
        ///     Tests that test secure double equality operator
        /// </summary>
        [Fact]
        public void Test_SecureDouble_EqualityOperator()
        {
            SecureDouble secureDouble1 = 10.0;
            SecureDouble secureDouble2 = 10.0;
            Assert.True(secureDouble1 == secureDouble2);
            
            secureDouble2 = 20.0;
            Assert.False(secureDouble1 == secureDouble2);
        }
        
        /// <summary>
        ///     Tests that test secure double inequality operator
        /// </summary>
        [Fact]
        public void Test_SecureDouble_InequalityOperator()
        {
            SecureDouble secureDouble1 = 10.0;
            SecureDouble secureDouble2 = 20.0;
            Assert.True(secureDouble1 != secureDouble2);
        }
        
        /// <summary>
        ///     Tests that test secure double addition operator
        /// </summary>
        [Fact]
        public void Test_SecureDouble_AdditionOperator()
        {
            SecureDouble secureDouble1 = 10.0;
            SecureDouble secureDouble2 = 20.0;
            Assert.Equal(30.0, (double) (secureDouble1 + secureDouble2));
        }
        
        /// <summary>
        ///     Tests that test secure double subtraction operator
        /// </summary>
        [Fact]
        public void Test_SecureDouble_SubtractionOperator()
        {
            SecureDouble secureDouble1 = 20.0;
            SecureDouble secureDouble2 = 10.0;
            Assert.Equal(10.0, (double) (secureDouble1 - secureDouble2));
        }
        
        /// <summary>
        ///     Tests that test secure double multiplication operator
        /// </summary>
        [Fact]
        public void Test_SecureDouble_MultiplicationOperator()
        {
            SecureDouble secureDouble1 = 10.0;
            SecureDouble secureDouble2 = 20.0;
            Assert.Equal(200.0, (double) (secureDouble1 * secureDouble2));
        }
        
        /// <summary>
        ///     Tests that test secure double division operator
        /// </summary>
        [Fact]
        public void Test_SecureDouble_DivisionOperator()
        {
            SecureDouble secureDouble1 = 20.0;
            SecureDouble secureDouble2 = 10.0;
            Assert.Equal(2.0, (double) (secureDouble1 / secureDouble2));
        }
        
        /// <summary>
        ///     Tests that test secure double equals method
        /// </summary>
        [Fact]
        public void Test_SecureDouble_EqualsMethod()
        {
            SecureDouble secureDouble1 = 10.0;
            SecureDouble secureDouble2 = 10.0;
            Assert.True(secureDouble1.Equals(secureDouble2));
            
            secureDouble2 = 20.0;
            Assert.False(secureDouble1.Equals(secureDouble2));
        }
        
        /// <summary>
        ///     Tests that test secure double get hash code method
        /// </summary>
        [Fact]
        public void Test_SecureDouble_GetHashCodeMethod()
        {
            SecureDouble secureDouble1 = 10.0;
            SecureDouble secureDouble2 = 10.0;
            Assert.Equal(secureDouble1.GetHashCode(), secureDouble2.GetHashCode());
            
            secureDouble2 = 20.0;
            Assert.NotEqual(secureDouble1.GetHashCode(), secureDouble2.GetHashCode());
        }
        
        /// <summary>
        ///     Tests that test secure double to string method
        /// </summary>
        [Fact]
        public void Test_SecureDouble_ToStringMethod()
        {
            SecureDouble secureDouble = 10.0;
            Assert.Equal("10", secureDouble.ToString());
        }
        
        
        /// <summary>
        ///     Tests that test value set get
        /// </summary>
        [Fact]
        public void TestValueSetGet()
        {
            // Arrange
            SecureDouble secureDouble = new SecureDouble(10.0);
            
            // Act
            double value = secureDouble;
            
            // Assert
            Assert.Equal(10.0, value);
        }
        
        /// <summary>
        ///     Tests that test equality
        /// </summary>
        [Fact]
        public void TestEquality()
        {
            // Arrange
            SecureDouble secureDouble1 = new SecureDouble(10.0);
            SecureDouble secureDouble2 = new SecureDouble(10.0);
            
            // Assert
            Assert.True(secureDouble1 == secureDouble2);
        }
        
        /// <summary>
        ///     Tests that test inequality
        /// </summary>
        [Fact]
        public void TestInequality()
        {
            // Arrange
            SecureDouble secureDouble1 = new SecureDouble(10.0);
            SecureDouble secureDouble2 = new SecureDouble(20.0);
            
            // Assert
            Assert.True(secureDouble1 != secureDouble2);
        }
        
        /// <summary>
        ///     Tests that test increment
        /// </summary>
        [Fact]
        public void TestIncrement()
        {
            // Arrange
            SecureDouble secureDouble = new SecureDouble(10.0);
            
            // Act
            secureDouble++;
            
            // Assert
            Assert.Equal(11.0, (double) secureDouble);
        }
        
        /// <summary>
        ///     Tests that test decrement
        /// </summary>
        [Fact]
        public void TestDecrement()
        {
            // Arrange
            SecureDouble secureDouble = new SecureDouble(10.0);
            
            // Act
            secureDouble--;
            
            // Assert
            Assert.Equal(9.0, (double) secureDouble);
        }
        
        /// <summary>
        ///     Tests that test addition
        /// </summary>
        [Fact]
        public void TestAddition()
        {
            // Arrange
            SecureDouble secureDouble1 = new SecureDouble(10.0);
            SecureDouble secureDouble2 = new SecureDouble(20.0);
            
            // Act
            SecureDouble result = secureDouble1 + secureDouble2;
            
            // Assert
            Assert.Equal(30.0, (double) result);
        }
        
        /// <summary>
        ///     Tests that test subtraction
        /// </summary>
        [Fact]
        public void TestSubtraction()
        {
            // Arrange
            SecureDouble secureDouble1 = new SecureDouble(20.0);
            SecureDouble secureDouble2 = new SecureDouble(10.0);
            
            // Act
            SecureDouble result = secureDouble1 - secureDouble2;
            
            // Assert
            Assert.Equal(10.0, (double) result);
        }
        
        /// <summary>
        ///     Tests that test multiplication
        /// </summary>
        [Fact]
        public void TestMultiplication()
        {
            // Arrange
            SecureDouble secureDouble1 = new SecureDouble(10.0);
            SecureDouble secureDouble2 = new SecureDouble(20.0);
            
            // Act
            SecureDouble result = secureDouble1 * secureDouble2;
            
            // Assert
            Assert.Equal(200.0, (double) result);
        }
        
        /// <summary>
        ///     Tests that test division
        /// </summary>
        [Fact]
        public void TestDivision()
        {
            // Arrange
            SecureDouble secureDouble1 = new SecureDouble(20.0);
            SecureDouble secureDouble2 = new SecureDouble(10.0);
            
            // Act
            SecureDouble result = secureDouble1 / secureDouble2;
            
            // Assert
            Assert.Equal(2.0, (double) result);
        }
    }
}