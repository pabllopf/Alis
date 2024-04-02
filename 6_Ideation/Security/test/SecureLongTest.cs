// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureLongTest.cs
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
    ///     The secure long tests class
    /// </summary>
    public class SecureLongTests
    {
        /// <summary>
        ///     Tests that test secure long constructor
        /// </summary>
        [Fact]
        public void Test_SecureLong_Constructor()
        {
            SecureLong secureLong = new SecureLong(10L);
            Assert.Equal(10L, (long) secureLong);
        }

        /// <summary>
        ///     Tests that test secure long implicit conversion
        /// </summary>
        [Fact]
        public void Test_SecureLong_ImplicitConversion()
        {
            SecureLong secureLong = 10L;
            Assert.Equal(10L, (long) secureLong);
        }

        /// <summary>
        ///     Tests that test secure long equality operator
        /// </summary>
        [Fact]
        public void Test_SecureLong_EqualityOperator()
        {
            SecureLong secureLong1 = 10L;
            SecureLong secureLong2 = 10L;
            Assert.True(secureLong1 == secureLong2);

            secureLong2 = 20L;
            Assert.False(secureLong1 == secureLong2);
        }

        /// <summary>
        ///     Tests that test secure long inequality operator
        /// </summary>
        [Fact]
        public void Test_SecureLong_InequalityOperator()
        {
            SecureLong secureLong1 = 10L;
            SecureLong secureLong2 = 20L;
            Assert.True(secureLong1 != secureLong2);

            secureLong2 = 10L;
            Assert.False(secureLong1 != secureLong2);
        }

        /// <summary>
        ///     Tests that test secure long addition operator
        /// </summary>
        [Fact]
        public void Test_SecureLong_AdditionOperator()
        {
            SecureLong secureLong1 = 10L;
            SecureLong secureLong2 = 20L;
            Assert.Equal(30L, (long) (secureLong1 + secureLong2));
        }

        /// <summary>
        ///     Tests that test secure long subtraction operator
        /// </summary>
        [Fact]
        public void Test_SecureLong_SubtractionOperator()
        {
            SecureLong secureLong1 = 20L;
            SecureLong secureLong2 = 10L;
            Assert.Equal(10L, (long) (secureLong1 - secureLong2));
        }

        /// <summary>
        ///     Tests that test secure long multiplication operator
        /// </summary>
        [Fact]
        public void Test_SecureLong_MultiplicationOperator()
        {
            SecureLong secureLong1 = 10L;
            SecureLong secureLong2 = 20L;
            Assert.Equal(200L, (long) (secureLong1 * secureLong2));
        }

        /// <summary>
        ///     Tests that test secure long division operator
        /// </summary>
        [Fact]
        public void Test_SecureLong_DivisionOperator()
        {
            SecureLong secureLong1 = 20L;
            SecureLong secureLong2 = 10L;
            Assert.Equal(2L, (long) (secureLong1 / secureLong2));
        }

        /// <summary>
        ///     Tests that test secure long equals method
        /// </summary>
        [Fact]
        public void Test_SecureLong_EqualsMethod()
        {
            SecureLong secureLong1 = 10L;
            SecureLong secureLong2 = 10L;
            Assert.True(secureLong1.Equals(secureLong2));

            secureLong2 = 20L;
            Assert.False(secureLong1.Equals(secureLong2));
        }

        /// <summary>
        ///     Tests that test secure long get hash code method
        /// </summary>
        [Fact]
        public void Test_SecureLong_GetHashCodeMethod()
        {
            SecureLong secureLong1 = 10L;
            SecureLong secureLong2 = 10L;
            Assert.Equal(secureLong1.GetHashCode(), secureLong2.GetHashCode());

            secureLong2 = 20L;
            Assert.NotEqual(secureLong1.GetHashCode(), secureLong2.GetHashCode());
        }

        /// <summary>
        ///     Tests that test secure long to string method
        /// </summary>
        [Fact]
        public void Test_SecureLong_ToStringMethod()
        {
            SecureLong secureLong = 10L;
            Assert.Equal("10", secureLong.ToString());
        }

        /// <summary>
        ///     Tests that test value set get
        /// </summary>
        [Fact]
        public void TestValueSetGet()
        {
            // Arrange
            SecureLong secureLong = new SecureLong(10);

            // Act
            long value = secureLong;

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
            SecureLong secureLong1 = new SecureLong(10);
            SecureLong secureLong2 = new SecureLong(10);

            // Assert
            Assert.True(secureLong1 == secureLong2);
        }

        /// <summary>
        ///     Tests that test inequality
        /// </summary>
        [Fact]
        public void TestInequality()
        {
            // Arrange
            SecureLong secureLong1 = new SecureLong(10);
            SecureLong secureLong2 = new SecureLong(20);

            // Assert
            Assert.True(secureLong1 != secureLong2);
        }

        /// <summary>
        ///     Tests that test increment
        /// </summary>
        [Fact]
        public void TestIncrement()
        {
            // Arrange
            SecureLong secureLong = new SecureLong(10);

            // Act
            secureLong++;

            // Assert
            Assert.Equal(11, (long) secureLong);
        }

        /// <summary>
        ///     Tests that test decrement
        /// </summary>
        [Fact]
        public void TestDecrement()
        {
            // Arrange
            SecureLong secureLong = new SecureLong(10);

            // Act
            secureLong--;

            // Assert
            Assert.Equal(9, (long) secureLong);
        }

        /// <summary>
        ///     Tests that test addition
        /// </summary>
        [Fact]
        public void TestAddition()
        {
            // Arrange
            SecureLong secureLong1 = new SecureLong(10);
            SecureLong secureLong2 = new SecureLong(20);

            // Act
            SecureLong result = secureLong1 + secureLong2;

            // Assert
            Assert.Equal(30, (long) result);
        }

        /// <summary>
        ///     Tests that test subtraction
        /// </summary>
        [Fact]
        public void TestSubtraction()
        {
            // Arrange
            SecureLong secureLong1 = new SecureLong(20);
            SecureLong secureLong2 = new SecureLong(10);

            // Act
            SecureLong result = secureLong1 - secureLong2;

            // Assert
            Assert.Equal(10, (long) result);
        }

        /// <summary>
        ///     Tests that test multiplication
        /// </summary>
        [Fact]
        public void TestMultiplication()
        {
            // Arrange
            SecureLong secureLong1 = new SecureLong(10);
            SecureLong secureLong2 = new SecureLong(20);

            // Act
            SecureLong result = secureLong1 * secureLong2;

            // Assert
            Assert.Equal(200, (long) result);
        }

        /// <summary>
        ///     Tests that test division
        /// </summary>
        [Fact]
        public void TestDivision()
        {
            // Arrange
            SecureLong secureLong1 = new SecureLong(20);
            SecureLong secureLong2 = new SecureLong(10);

            // Act
            SecureLong result = secureLong1 / secureLong2;

            // Assert
            Assert.Equal(2, (long) result);
        }
    }
}