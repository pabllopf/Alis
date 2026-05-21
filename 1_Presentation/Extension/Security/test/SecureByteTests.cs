// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureByteTests.cs
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

namespace Alis.Extension.Security.Test
{
    /// <summary>
    ///     The secure byte tests class
    /// </summary>
    public class SecureByteTests
    {
        /// <summary>
        ///     Tests that test secure byte constructor
        /// </summary>
        [Fact]
        public void Test_SecureByte_Constructor()
        {
            SecureByte secureByte = new SecureByte(10);
            Assert.Equal(10, (byte) secureByte);
        }

        /// <summary>
        ///     Tests that test secure byte implicit conversion
        /// </summary>
        [Fact]
        public void Test_SecureByte_ImplicitConversion()
        {
            SecureByte secureByte = 10;
            Assert.Equal(10, (byte) secureByte);
        }

        /// <summary>
        ///     Tests that test secure byte equality operator
        /// </summary>
        [Fact]
        public void Test_SecureByte_EqualityOperator()
        {
            SecureByte secureByte1 = 10;
            SecureByte secureByte2 = 10;
            Assert.True(secureByte1 == secureByte2);

            secureByte2 = 20;
            Assert.False(secureByte1 == secureByte2);
        }

        /// <summary>
        ///     Tests that test secure byte inequality operator
        /// </summary>
        [Fact]
        public void Test_SecureByte_InequalityOperator()
        {
            SecureByte secureByte1 = 10;
            SecureByte secureByte2 = 20;
            Assert.True(secureByte1 != secureByte2);

            secureByte2 = 10;
            Assert.False(secureByte1 != secureByte2);
        }

        /// <summary>
        ///     Tests that test secure byte addition operator
        /// </summary>
        [Fact]
        public void Test_SecureByte_AdditionOperator()
        {
            SecureByte secureByte1 = 10;
            SecureByte secureByte2 = 20;
            Assert.Equal(30, (byte) (secureByte1 + secureByte2));
        }

        /// <summary>
        ///     Tests that test secure byte subtraction operator
        /// </summary>
        [Fact]
        public void Test_SecureByte_SubtractionOperator()
        {
            SecureByte secureByte1 = 20;
            SecureByte secureByte2 = 10;
            Assert.Equal(10, (byte) (secureByte1 - secureByte2));
        }

        /// <summary>
        ///     Tests that test secure byte multiplication operator
        /// </summary>
        [Fact]
        public void Test_SecureByte_MultiplicationOperator()
        {
            SecureByte secureByte1 = 10;
            SecureByte secureByte2 = 20;
            Assert.Equal(200, (byte) (secureByte1 * secureByte2));
        }

        /// <summary>
        ///     Tests that test secure byte division operator
        /// </summary>
        [Fact]
        public void Test_SecureByte_DivisionOperator()
        {
            SecureByte secureByte1 = 20;
            SecureByte secureByte2 = 10;
            Assert.Equal(2, (byte) (secureByte1 / secureByte2));
        }

        /// <summary>
        ///     Tests that test secure byte equals method
        /// </summary>
        [Fact]
        public void Test_SecureByte_EqualsMethod()
        {
            SecureByte secureByte1 = 10;
            SecureByte secureByte2 = 10;
            Assert.True(secureByte1.Equals(secureByte2));

            secureByte2 = 20;
            Assert.False(secureByte1.Equals(secureByte2));
        }

        /// <summary>
        ///     Tests that test secure byte get hash code method
        /// </summary>
        [Fact]
        public void Test_SecureByte_GetHashCodeMethod()
        {
            SecureByte secureByte1 = 10;
            SecureByte secureByte2 = 10;
            Assert.Equal(secureByte1.GetHashCode(), secureByte2.GetHashCode());

            secureByte2 = 20;
            Assert.NotEqual(secureByte1.GetHashCode(), secureByte2.GetHashCode());
        }

        /// <summary>
        ///     Tests that test secure byte to string method
        /// </summary>
        [Fact]
        public void Test_SecureByte_ToStringMethod()
        {
            SecureByte secureByte = 10;
            Assert.Equal("10", secureByte.ToString());
        }

        /// <summary>
        ///     Tests that test value set get
        /// </summary>
        [Fact]
        public void TestValueSetGet()
        {
            SecureByte secureByte = new SecureByte(10);

            byte value = secureByte;

            Assert.Equal(10, value);
        }

        /// <summary>
        ///     Tests that test equality
        /// </summary>
        [Fact]
        public void TestEquality()
        {
            SecureByte secureByte1 = new SecureByte(10);
            SecureByte secureByte2 = new SecureByte(10);

            Assert.True(secureByte1 == secureByte2);
        }

        /// <summary>
        ///     Tests that test inequality
        /// </summary>
        [Fact]
        public void TestInequality()
        {
            SecureByte secureByte1 = new SecureByte(10);
            SecureByte secureByte2 = new SecureByte(20);

            Assert.True(secureByte1 != secureByte2);
        }

        /// <summary>
        ///     Tests that test increment
        /// </summary>
        [Fact]
        public void TestIncrement()
        {
            SecureByte secureByte = new SecureByte(10);

            secureByte++;

            Assert.Equal(11, (byte) secureByte);
        }

        /// <summary>
        ///     Tests that test decrement
        /// </summary>
        [Fact]
        public void TestDecrement()
        {
            SecureByte secureByte = new SecureByte(10);

            secureByte--;

            Assert.Equal(9, (byte) secureByte);
        }

        /// <summary>
        ///     Tests that test addition
        /// </summary>
        [Fact]
        public void TestAddition()
        {
            SecureByte secureByte1 = new SecureByte(10);
            SecureByte secureByte2 = new SecureByte(20);

            SecureByte result = secureByte1 + secureByte2;

            Assert.Equal(30, (byte) result);
        }

        /// <summary>
        ///     Tests that test subtraction
        /// </summary>
        [Fact]
        public void TestSubtraction()
        {
            SecureByte secureByte1 = new SecureByte(20);
            SecureByte secureByte2 = new SecureByte(10);

            SecureByte result = secureByte1 - secureByte2;

            Assert.Equal(10, (byte) result);
        }

        /// <summary>
        ///     Tests that test multiplication
        /// </summary>
        [Fact]
        public void TestMultiplication()
        {
            SecureByte secureByte1 = new SecureByte(10);
            SecureByte secureByte2 = new SecureByte(20);

            SecureByte result = secureByte1 * secureByte2;

            Assert.Equal(200, (byte) result);
        }

        /// <summary>
        ///     Tests that test division
        /// </summary>
        [Fact]
        public void TestDivision()
        {
            SecureByte secureByte1 = new SecureByte(20);
            SecureByte secureByte2 = new SecureByte(10);

            SecureByte result = secureByte1 / secureByte2;

            Assert.Equal(2, (byte) result);
        }
    }
}