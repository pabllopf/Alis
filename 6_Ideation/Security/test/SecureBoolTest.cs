// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SecureBoolTest.cs
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
    ///     The secure bool tests class
    /// </summary>
    public class SecureBoolTests
    {
        /// <summary>
        ///     Tests that test secure bool constructor
        /// </summary>
        [Fact]
        public void Test_SecureBool_Constructor()
        {
            SecureBool secureBool = new SecureBool(true);
            Assert.True((bool) secureBool);

            secureBool = new SecureBool();
            Assert.False((bool) secureBool);
        }

        /// <summary>
        ///     Tests that test secure bool implicit conversion
        /// </summary>
        [Fact]
        public void Test_SecureBool_ImplicitConversion()
        {
            SecureBool secureBool = true;
            Assert.True((bool) secureBool);

            secureBool = false;
            Assert.False((bool) secureBool);
        }

        /// <summary>
        ///     Tests that test secure bool equality operator
        /// </summary>
        [Fact]
        public void Test_SecureBool_EqualityOperator()
        {
            SecureBool secureBool1 = true;
            SecureBool secureBool2 = true;
            Assert.True(secureBool1 == secureBool2);

            secureBool2 = false;
            Assert.False(secureBool1 == secureBool2);
        }

        /// <summary>
        ///     Tests that test secure bool inequality operator
        /// </summary>
        [Fact]
        public void Test_SecureBool_InequalityOperator()
        {
            SecureBool secureBool1 = true;
            SecureBool secureBool2 = false;
            Assert.True(secureBool1 != secureBool2);

            secureBool2 = true;
            Assert.False(secureBool1 != secureBool2);
        }

        /// <summary>
        ///     Tests that test secure bool not operator
        /// </summary>
        [Fact]
        public void Test_SecureBool_NotOperator()
        {
            SecureBool secureBool = true;
            Assert.False(!secureBool);

            secureBool = false;
            Assert.True(!secureBool);
        }

        /// <summary>
        ///     Tests that test secure bool equals method
        /// </summary>
        [Fact]
        public void Test_SecureBool_EqualsMethod()
        {
            SecureBool secureBool1 = true;
            SecureBool secureBool2 = true;
            Assert.True(secureBool1.Equals(secureBool2));

            secureBool2 = false;
            Assert.False(secureBool1.Equals(secureBool2));
        }

        /// <summary>
        ///     Tests that test secure bool get hash code method
        /// </summary>
        [Fact]
        public void Test_SecureBool_GetHashCodeMethod()
        {
            SecureBool secureBool1 = true;
            SecureBool secureBool2 = true;
            Assert.Equal(secureBool1.GetHashCode(), secureBool2.GetHashCode());

            secureBool2 = false;
            Assert.NotEqual(secureBool1.GetHashCode(), secureBool2.GetHashCode());
        }

        /// <summary>
        ///     Tests that test secure bool to string method
        /// </summary>
        [Fact]
        public void Test_SecureBool_ToStringMethod()
        {
            SecureBool secureBool = true;
            Assert.Equal("True", secureBool.ToString());

            secureBool = false;
            Assert.Equal("False", secureBool.ToString());
        }
    }
}