// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureDecimalTest.cs
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
    ///     The secure decimal tests class
    /// </summary>
    public class SecureDecimalTests
    {
        /// <summary>
        ///     Tests that test secure decimal constructor
        /// </summary>
        [Fact]
        public void Test_SecureDecimal_Constructor()
        {
            SecureDecimal secureDecimal = new SecureDecimal(10.0m);
            Assert.Equal(10.0m, (decimal) secureDecimal);
        }

        /// <summary>
        ///     Tests that test secure decimal implicit conversion
        /// </summary>
        [Fact]
        public void Test_SecureDecimal_ImplicitConversion()
        {
            SecureDecimal secureDecimal = 10.0m;
            Assert.Equal(10.0m, (decimal) secureDecimal);
        }

        /// <summary>
        ///     Tests that test secure decimal equality operator
        /// </summary>
        [Fact]
        public void Test_SecureDecimal_EqualityOperator()
        {
            SecureDecimal secureDecimal1 = 10.0m;
            SecureDecimal secureDecimal2 = 10.0m;
            Assert.True(secureDecimal1 == secureDecimal2);

            secureDecimal2 = 20.0m;
            Assert.False(secureDecimal1 == secureDecimal2);
        }

        /// <summary>
        ///     Tests that test secure decimal inequality operator
        /// </summary>
        [Fact]
        public void Test_SecureDecimal_InequalityOperator()
        {
            SecureDecimal secureDecimal1 = 10.0m;
            SecureDecimal secureDecimal2 = 20.0m;
            Assert.True(secureDecimal1 != secureDecimal2);

            secureDecimal2 = 10.0m;
            Assert.False(secureDecimal1 != secureDecimal2);
        }

        /// <summary>
        ///     Tests that test secure decimal addition operator
        /// </summary>
        [Fact]
        public void Test_SecureDecimal_AdditionOperator()
        {
            SecureDecimal secureDecimal1 = 10.0m;
            SecureDecimal secureDecimal2 = 20.0m;
            Assert.Equal(30.0m, (decimal) (secureDecimal1 + secureDecimal2));
        }

        /// <summary>
        ///     Tests that test secure decimal subtraction operator
        /// </summary>
        [Fact]
        public void Test_SecureDecimal_SubtractionOperator()
        {
            SecureDecimal secureDecimal1 = 20.0m;
            SecureDecimal secureDecimal2 = 10.0m;
            Assert.Equal(10.0m, (decimal) (secureDecimal1 - secureDecimal2));
        }

        /// <summary>
        ///     Tests that test secure decimal multiplication operator
        /// </summary>
        [Fact]
        public void Test_SecureDecimal_MultiplicationOperator()
        {
            SecureDecimal secureDecimal1 = 10.0m;
            SecureDecimal secureDecimal2 = 20.0m;
            Assert.Equal(200.0m, (decimal) (secureDecimal1 * secureDecimal2));
        }

        /// <summary>
        ///     Tests that test secure decimal division operator
        /// </summary>
        [Fact]
        public void Test_SecureDecimal_DivisionOperator()
        {
            SecureDecimal secureDecimal1 = 20.0m;
            SecureDecimal secureDecimal2 = 10.0m;
            Assert.Equal(2.0m, (decimal) (secureDecimal1 / secureDecimal2));
        }

        /// <summary>
        ///     Tests that test secure decimal equals method
        /// </summary>
        [Fact]
        public void Test_SecureDecimal_EqualsMethod()
        {
            SecureDecimal secureDecimal1 = 10.0m;
            SecureDecimal secureDecimal2 = 10.0m;
            Assert.True(secureDecimal1.Equals(secureDecimal2));

            secureDecimal2 = 20.0m;
            Assert.False(secureDecimal1.Equals(secureDecimal2));
        }

        /// <summary>
        ///     Tests that test secure decimal get hash code method
        /// </summary>
        [Fact]
        public void Test_SecureDecimal_GetHashCodeMethod()
        {
            SecureDecimal secureDecimal1 = 10.0m;
            SecureDecimal secureDecimal2 = 10.0m;
            Assert.Equal(secureDecimal1.GetHashCode(), secureDecimal2.GetHashCode());

            secureDecimal2 = 20.0m;
            Assert.NotEqual(secureDecimal1.GetHashCode(), secureDecimal2.GetHashCode());
        }

        /// <summary>
        ///     Tests that test secure decimal to string method
        /// </summary>
        [Fact]
        public void Test_SecureDecimal_ToStringMethod()
        {
            SecureDecimal secureDecimal = 10.0m;
            Assert.Equal("10.0", secureDecimal.ToString());
        }
    }
}