// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureCharTests.cs
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
    ///     The secure char tests class
    /// </summary>
    public class SecureCharTests
    {
        /// <summary>
        ///     Tests that test secure char constructor
        /// </summary>
        [Fact]
        public void Test_SecureChar_Constructor()
        {
            SecureChar secureChar = new SecureChar('a');
            Assert.Equal('a', (char) secureChar);
        }
        
        /// <summary>
        ///     Tests that test secure char implicit conversion
        /// </summary>
        [Fact]
        public void Test_SecureChar_ImplicitConversion()
        {
            SecureChar secureChar = 'a';
            Assert.Equal('a', (char) secureChar);
        }
        
        /// <summary>
        ///     Tests that test secure char equality operator
        /// </summary>
        [Fact]
        public void Test_SecureChar_EqualityOperator()
        {
            SecureChar secureChar1 = 'a';
            SecureChar secureChar2 = 'a';
            Assert.True(secureChar1 == secureChar2);
            
            secureChar2 = 'b';
            Assert.False(secureChar1 == secureChar2);
        }
        
        /// <summary>
        ///     Tests that test secure char inequality operator
        /// </summary>
        [Fact]
        public void Test_SecureChar_InequalityOperator()
        {
            SecureChar secureChar1 = 'a';
            SecureChar secureChar2 = 'b';
            Assert.True(secureChar1 != secureChar2);
            
            secureChar2 = 'a';
            Assert.False(secureChar1 != secureChar2);
        }
        
        /// <summary>
        ///     Tests that test secure char addition operator
        /// </summary>
        [Fact]
        public void Test_SecureChar_AdditionOperator()
        {
            SecureChar secureChar1 = 'a';
            SecureChar secureChar2 = (char) 1;
            Assert.Equal('b', (char) (secureChar1 + secureChar2));
        }
        
        /// <summary>
        ///     Tests that test secure char subtraction operator
        /// </summary>
        [Fact]
        public void Test_SecureChar_SubtractionOperator()
        {
            SecureChar secureChar1 = 'b';
            SecureChar secureChar2 = (char) 1;
            Assert.Equal('a', (char) (secureChar1 - secureChar2));
        }
        
        /// <summary>
        ///     Tests that test secure char equals method
        /// </summary>
        [Fact]
        public void Test_SecureChar_EqualsMethod()
        {
            SecureChar secureChar1 = 'a';
            SecureChar secureChar2 = 'a';
            Assert.True(secureChar1.Equals(secureChar2));
            
            secureChar2 = 'b';
            Assert.False(secureChar1.Equals(secureChar2));
        }
        
        /// <summary>
        ///     Tests that test secure char get hash code method
        /// </summary>
        [Fact]
        public void Test_SecureChar_GetHashCodeMethod()
        {
            SecureChar secureChar1 = 'a';
            SecureChar secureChar2 = 'a';
            Assert.Equal(secureChar1.GetHashCode(), secureChar2.GetHashCode());
            
            secureChar2 = 'b';
            Assert.NotEqual(secureChar1.GetHashCode(), secureChar2.GetHashCode());
        }
        
        /// <summary>
        ///     Tests that test secure char to string method
        /// </summary>
        [Fact]
        public void Test_SecureChar_ToStringMethod()
        {
            SecureChar secureChar = 'a';
            Assert.Equal("a", secureChar.ToString());
        }
        
        /// <summary>
        ///     Tests that test value set get
        /// </summary>
        [Fact]
        public void TestValueSetGet()
        {
            // Arrange
            SecureChar secureChar = new SecureChar('a');
            
            // Act
            char value = secureChar;
            
            // Assert
            Assert.Equal('a', value);
        }
        
        /// <summary>
        ///     Tests that test equality
        /// </summary>
        [Fact]
        public void TestEquality()
        {
            // Arrange
            SecureChar secureChar1 = new SecureChar('a');
            SecureChar secureChar2 = new SecureChar('a');
            
            // Assert
            Assert.True(secureChar1 == secureChar2);
        }
        
        /// <summary>
        ///     Tests that test inequality
        /// </summary>
        [Fact]
        public void TestInequality()
        {
            // Arrange
            SecureChar secureChar1 = new SecureChar('a');
            SecureChar secureChar2 = new SecureChar('b');
            
            // Assert
            Assert.True(secureChar1 != secureChar2);
        }
        
        /// <summary>
        ///     Tests that test addition
        /// </summary>
        [Fact]
        public void TestAddition()
        {
            // Arrange
            SecureChar secureChar1 = new SecureChar('a');
            SecureChar secureChar2 = new SecureChar('b');
            
            // Act
            SecureChar result = secureChar1 + secureChar2;
            
            // Assert
            Assert.Equal('a' + 'b', (char) result);
        }
        
        /// <summary>
        ///     Tests that test subtraction
        /// </summary>
        [Fact]
        public void TestSubtraction()
        {
            // Arrange
            SecureChar secureChar1 = new SecureChar('b');
            SecureChar secureChar2 = new SecureChar('a');
            
            // Act
            SecureChar result = secureChar1 - secureChar2;
            
            // Assert
            Assert.Equal('b' - 'a', (char) result);
        }
        
        /// <summary>
        ///     Tests that test multiplication
        /// </summary>
        [Fact]
        public void TestMultiplication()
        {
            // Arrange
            SecureChar secureChar1 = new SecureChar('a');
            SecureChar secureChar2 = new SecureChar('b');
            
            // Act
            SecureChar result = secureChar1 * secureChar2;
            
            // Assert
            Assert.Equal('a' * 'b', (char) result);
        }
        
        /// <summary>
        ///     Tests that test division
        /// </summary>
        [Fact]
        public void TestDivision()
        {
            // Arrange
            SecureChar secureChar1 = new SecureChar('b');
            SecureChar secureChar2 = new SecureChar('a');
            
            // Act
            SecureChar result = secureChar1 / secureChar2;
            
            // Assert
            Assert.Equal('b' / 'a', (char) result);
        }
    }
}